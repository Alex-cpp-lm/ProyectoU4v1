using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        DAOBase x;
        List<Producto> lista = new List<Producto>();
        decimal total = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            x = new DAOBase();
            if (x.login(textBox1.Text, textBox2.Text) == true)
            {
                loginP.Enabled = false;
                perfilP.Enabled = true;
                busquedaP.Enabled = true;

                productoP.Enabled = true;
                perfilP.Visible = true;
                dataGridView2.Visible = true;
                dataGridView2.Enabled = true;
                x.actualizarVentas(dataGridView2);
                rellenarDatos();
                this.Size = new Size(1006, 550);


            }
            else
            {
                label5.Visible = true;
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void rellenarDatos()
        {
            nombre_apellidos.Text = x.user.nombre + " " + x.user.apellido;
            pictureBox1.ImageLocation = x.user.imagen;
            usuario.Text = x.user.usuario;
            idEmp.Text = "ID:" + x.user.idempleado;
            sueldo.Text = "SUELDO: $" + x.user.salario + " SEMANALES.";
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click_1(object sender, EventArgs e)
        {

        }

        private void label6_Click_2(object sender, EventArgs e)
        {

        }

        private void cobro_Click(object sender, EventArgs e)
        {
            if (lista.Count > 0)
            {
                x.vender(lista, textBox4.Text, total);
                actualizarTotal();
                x.actualizarTabla(dataGridView1);
                x.actualizarVentas(dataGridView2);
            }
            else
            {
                MessageBox.Show("LA VENTA ESTA VACIA");
            }


        }

        private void perfilP_MouseEnter(object sender, EventArgs e)
        {
            perfilP.BackColor = SystemColors.GrayText;
        }

        private void perfilP_MouseLeave(object sender, EventArgs e)
        {
            perfilP.BackColor = SystemColors.Window;
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void perfilP_MouseClick(object sender, MouseEventArgs e)
        {
            if (perfilP.Height == 79)
            {
                perfilP.Size = new Size(240, 159);
            }
            else
            {
                perfilP.Size = new Size(240, 79);
            }
        }

        private void label7_Click_1(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            // Realizar la búsqueda cuando el texto cambie
            string textoBusqueda = textBox3.Text;
            buscar(textoBusqueda);
        }

        private void dataGridView2_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void busquedaP_Paint(object sender, PaintEventArgs e)
        {

        }


        private void buscar(string texto)
        {
            // Llamar al método buscar desde la instancia de DAOBase
            x.buscar(texto, busquedaa);
        }
        public void rellenarProducto()
        {
            codigoPr.Text = "Codigo: " + x.productoS.Codigo;
            nombrePr.Text = "Nombre: " + x.productoS.Nombre;
            cantPr.Text = "Cantidad: " + x.productoS.Cantidad;
            precioPr.Text = "Precio: $" + x.productoS.Precio;
            productoImagen.ImageLocation = x.productoS.Imagen;
        }

        private void busquedaa_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string codigo = busquedaa.Rows[e.RowIndex].Cells["idProducto"].Value.ToString();
                x.productoSeleccionado(codigo);
                rellenarProducto();
            }

        }

        private void agregarB_Click(object sender, EventArgs e)
        {

            x.productoS.cant = int.Parse(numericUpDown1.Text);
            lista.Add(x.enviarP());
            x.ventaBack(x.enviarP());
            x.actualizarTabla(dataGridView1);
            actualizarTotal();
        }
        private void actualizarTotal()
        {
            total = 0;
            for (int i = 0; i < lista.Count; i++)
            {
                total = total + (lista[i].Precio * lista[i].cant);
            }
            totalT.Text = "$" + total;
        }

        private void eliminarP_Click(object sender, EventArgs e)
        {
            lista.Remove(x.enviarP());
            x.eliminarPa(x.productoS.IdProducto);
            x.actualizarTabla(dataGridView1);
            actualizarTotal();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            if (int.Parse(numericUpDown1.Text) > x.productoS.Cantidad)
            {
                MessageBox.Show("NO HAY EN INVENTARIO");
                numericUpDown1.Value = x.productoS.Cantidad;
            }
       
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string codigo = dataGridView1.Rows[e.RowIndex].Cells["idProducto"].Value.ToString();
                x.productoSeleccionado(codigo);
                rellenarProducto();
            }
        }

        private void cancelar_Click(object sender, EventArgs e)
        {
            x.cancelarTransaccion();
            x.actualizarTabla(dataGridView1);
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }


        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.A)
            {
                agregarB_Click(sender, e);
            }
            else if (e.KeyCode == Keys.F10)
            {
                eliminarP_Click(sender, e);
            }
            else if (e.KeyCode == Keys.F11)
            {
                cancelar_Click(sender, e);
            }
            else if (e.KeyCode == Keys.F12) ;
            {
                cobro_Click(sender, e);

            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if(loginP.Enabled == false)
            {
                x.cancelarTransaccion();
                x.CerrarDAO();
            }
            
            
        }
    }
}
