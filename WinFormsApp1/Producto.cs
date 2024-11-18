using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    public class Producto
    {
        public int IdProducto;
        public string Nombre;
        public string Codigo;
        public string Descripcion;
        public int Cantidad;
        public int IdMarca;
        public string Imagen;
        public decimal Precio;
        public int cant = 1;

        public Producto(int idProducto, string nombre, string codigo, string descripcion, int cantidad, int idMarca, string imagen, decimal precio)
        {
            IdProducto = idProducto;
            Nombre = nombre;
            Codigo = codigo;
            Descripcion = descripcion;
            Cantidad = cantidad;
            IdMarca = idMarca;
            Imagen = imagen;
            Precio = precio;
        }
        
    }


}