using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows.Forms;
using System.Xml.Linq;
using MySql.Data.MySqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace WinFormsApp1
{
    internal class DAOBase
    {
        public EmpleadoObj user;
        public bool trasa = false;
        MySqlConnection cn = new MySqlConnection();
        public Producto productoS = new Producto (0, "", "", "" , 0 , 1, "", 0 );
        MySqlTransaction transaction = null;
        public Producto enviarP()
        {
            return productoS;
        }
        public DAOBase()
        {
            /// CREAR LA CONEXIÓN, CONFIGURAR Y ABRIRLA
            cn.ConnectionString = "server=localhost; database=tiendau4; user=root; pwd=root";
            cn.Open();
            Console.WriteLine("Conectado " + cn.State);
        }
        public void cancelarTransaccion()
        {
            if(trasa == true)
            {
                transaction.Rollback();
                trasa = false;
            }
           
        }
        public void iniciarTransaccion()
        {

            transaction = cn.BeginTransaction();
            trasa = true;
            string strSQL = @"DROP TABLE IF EXISTS ventaActual; create table ventaActual (
            idProducto int not null,
            nombre varchar(30) not null,
            codigo char(12) not null,
            cantidadV int not null,
            precio decimal(3) null,
            descripcion varchar(200) not null,
            cantidad int not null,
            idMarca int not null,
            imagen varchar(1000),
            foreign key (idMarca) references marca(idMarca))";
            using (var cmd = new MySqlCommand(strSQL, cn))
            {
                // Ejecutar el comando
                cmd.ExecuteNonQuery();
                Console.WriteLine("Tabla 'ventaActual' creada exitosamente.");
            }
        }
        public void terminarTransaccion()
        {
            string strSQL = @"drop table ventaActual";
            using (var cmd = new MySqlCommand(strSQL, cn))
            {
                // Ejecutar el comando
                cmd.ExecuteNonQuery();
            }
                transaction.Commit();
            trasa = false;
                 iniciarTransaccion();
            // Eliminar valores de variables
        }
        
        public void vender(List<Producto> lista, string descripcion, decimal total)
        {
            string queryVenta = "INSERT INTO ventas (descripcion, total, fecha, idEmpleado) VALUES (@descripcion, @total, @fecha, @idEmpleado)";
            MySqlCommand cmdVenta = new MySqlCommand(queryVenta, cn, transaction);
            cmdVenta.Parameters.AddWithValue("@descripcion", descripcion);
            cmdVenta.Parameters.AddWithValue("@total", total);
            cmdVenta.Parameters.AddWithValue("@fecha", DateTime.Now);
            cmdVenta.Parameters.AddWithValue("@idEmpleado", user.idempleado);
            cmdVenta.ExecuteNonQuery();
            long idVenta = cmdVenta.LastInsertedId;
            string queryDetalle = "INSERT INTO detalles_ventas (idProducto, idVenta, cantidad, precioVenta) " +
                                  "VALUES (@idProducto, @idVenta, @cantidad, @precioVenta)";
            MySqlCommand cmdDetalle = new MySqlCommand(queryDetalle, cn, transaction);

            for (int i = 0; i < lista.Count ; i++)
            {
                cmdDetalle.Parameters.Clear();
                cmdDetalle.Parameters.AddWithValue("@idProducto", lista[i].IdProducto);
                cmdDetalle.Parameters.AddWithValue("@idVenta", idVenta);
                cmdDetalle.Parameters.AddWithValue("@cantidad", lista[i].cant);
                cmdDetalle.Parameters.AddWithValue("@precioVenta", lista[i].Precio);

                // Ejecuta la inserción para cada producto
                cmdDetalle.ExecuteNonQuery();
            }

            // Si todo fue bien, confirma la transacción
            terminarTransaccion();
            MessageBox.Show("Venta realizada con éxito!");
        }
        public bool login(string username, string password)
        {
            string strSQL = @"select * from Empleados where usuario = @username and pass = SHA2(@password, 256)";
            MySqlCommand comando = new MySqlCommand(strSQL, cn);
            comando.Parameters.AddWithValue("@username", username);
            comando.Parameters.AddWithValue("@password", password);
            MySqlDataReader dr = comando.ExecuteReader();
            if (dr.Read())
            {
                Console.WriteLine("INGRESASTE CORRECTAMENTE");
                int idEmpleado = dr.GetInt32("idEmpleado");
                string nombre = dr.GetString("nombre");
                string apellido = dr.GetString("apellido");
                string usuario = dr.GetString("usuario");
                string pass = dr.GetString("pass");
                float salario = dr.GetFloat("salario");
                string foto = dr.GetString("foto");
                user = new EmpleadoObj(idEmpleado, nombre, apellido, usuario, salario, foto);
                Console.WriteLine("Se hizo");
                comando.Dispose();
                dr.Close();
                iniciarTransaccion();
                return true;
            }
            else
            {
                Console.WriteLine("NO SE ENCONTRÓ RESULTADO");
                comando.Dispose();
                dr.Close();
                return false;
            }
        }
        public void buscar(string texto, DataGridView dataGridView)
        {
            string strSQL = @"SELECT codigo, nombre, precio, idProducto FROM productos WHERE nombre LIKE @text or  idProducto LIKE @text or codigo like @text";
            MySqlCommand comando = new MySqlCommand(strSQL, cn);
            comando.Parameters.AddWithValue("@text", "%" + texto + "%");
            MySqlDataReader dr = comando.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dataGridView.DataSource = dt;  // Aquí se asignan los resultados al DataGridView
            dr.Close();
        }
        public void productoSeleccionado(string codigo)
        {
            string strSQL = @"SELECT * FROM productos WHERE idProducto = @text";
            MySqlCommand comando = new MySqlCommand(strSQL, cn);
            comando.Parameters.AddWithValue("@text", int.Parse(codigo));
            MySqlDataReader dr = comando.ExecuteReader();
            if (dr.Read())  // Aquí llamamos a Read() antes de intentar acceder a los datos
            {
                 productoS = new Producto(
                            dr.GetInt32("idProducto"),
                            dr.GetString("nombre"),
                            dr.GetString("codigo"),
                            dr.GetString("descripcion"),
                            dr.GetInt32("cantidad"),
                            dr.GetInt32("idMarca"),
                            dr.GetString("imagen"),
                            dr.GetDecimal("precio"));
            }
            else
            {
                MessageBox.Show("No se hizo");
            }
            dr.Close();
       
        }


        public void CerrarDAO()
        {
            cn.Close();
            cn.Dispose();
        }
        public void ventaBack(Producto producto)
        {
            string strSelectSQL = @"SELECT COUNT(*) FROM ventaActual WHERE codigo = @Codigo";
            string strInsertSQL = @"
    INSERT INTO ventaActual (idProducto, nombre, codigo, cantidadV, precio, descripcion, cantidad, idMarca, imagen)
    VALUES (@idproducto,@Nombre, @Codigo, @CantidadV, @Precio, @Descripcion, @Cantidad, @IdMarca, @Imagen)";

            string strUpdateSQL = @"
    UPDATE ventaActual 
    SET cantidadV = @CantidadV
    WHERE codigo = @Codigo";

            MySqlCommand cmdSelect = new MySqlCommand(strSelectSQL, cn);
            cmdSelect.Parameters.AddWithValue("@Codigo", producto.Codigo);

            int count = Convert.ToInt32(cmdSelect.ExecuteScalar());  // Ejecutamos SELECT COUNT(*)

            if (count > 0)
            {
                // Si el producto ya existe, actualizamos la cantidadV
                MySqlCommand cmdUpdate = new MySqlCommand(strUpdateSQL, cn);
                cmdUpdate.Parameters.AddWithValue("@Codigo", producto.Codigo);
                cmdUpdate.Parameters.AddWithValue("@CantidadV", producto.cant);

                int result = cmdUpdate.ExecuteNonQuery();  // Ejecutamos el UPDATE

                if (result > 0)
                    Console.WriteLine("Cantidad actualizada correctamente.");
                else
                    Console.WriteLine("Error al actualizar la cantidad.");
            }
            else
            {
                // Si el producto no existe, insertamos un nuevo producto
                MySqlCommand cmdInsert = new MySqlCommand(strInsertSQL, cn);
                cmdInsert.Parameters.AddWithValue("@Nombre", producto.Nombre);
                cmdInsert.Parameters.AddWithValue("@Codigo", producto.Codigo);
                cmdInsert.Parameters.AddWithValue("@CantidadV", producto.cant);
                cmdInsert.Parameters.AddWithValue("@Precio", producto.Precio);
                cmdInsert.Parameters.AddWithValue("@Descripcion", producto.Descripcion);
                cmdInsert.Parameters.AddWithValue("@Cantidad", producto.Cantidad);
                cmdInsert.Parameters.AddWithValue("@IdMarca", producto.IdMarca);
                cmdInsert.Parameters.AddWithValue("@Imagen", producto.Imagen);
                cmdInsert.Parameters.AddWithValue("@idProducto" , producto.IdProducto);

                int result = cmdInsert.ExecuteNonQuery();  // Ejecutamos el INSERT

                if (result > 0)
                    Console.WriteLine("Producto insertado correctamente.");
                else
                    Console.WriteLine("Error al insertar el producto.");
            }
        }
        public void eliminarPa(int idProducto)
        {
            string strSQL = @"DELETE FROM ventaActual WHERE IdProducto = @IdProducto";
            MySqlCommand cmd = new MySqlCommand(strSQL, cn);
            cmd.Parameters.AddWithValue("@IdProducto", idProducto);
            int result = cmd.ExecuteNonQuery();
        }
        public void actualizarTabla(DataGridView dataGridView)
        {
            string strSQL = @"SELECT codigo, nombre, precio, idProducto, cantidadV FROM ventaActual";
            MySqlCommand comando = new MySqlCommand(strSQL, cn);
            MySqlDataReader dr = comando.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dataGridView.DataSource = dt;
            dr.Close();
        }
        public void actualizarVentas(DataGridView dataGridView)
        {
            string strSQL = @"SELECT * FROM ventas where idEmpleado = @user";
            MySqlCommand comando = new MySqlCommand(strSQL, cn);
            comando.Parameters.AddWithValue("@user", user.idempleado);
            MySqlDataReader dr = comando.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dataGridView.DataSource = dt;
            dr.Close();
        }
    }
}
    