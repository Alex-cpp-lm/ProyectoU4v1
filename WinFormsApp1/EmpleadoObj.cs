using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    internal class EmpleadoObj
    {
       public int idempleado;
       public string nombre;
        public string apellido;
        public string usuario;
        public double salario;
        public string imagen;
        public EmpleadoObj(int idempleadox, string nombrex, string apellidox, string usuariox , double salariox, string imagenx)
        {
            idempleado = idempleadox;
            nombre = nombrex;
            apellido = apellidox;
            usuario = usuariox;
            salario = salariox;
            imagen = imagenx;
        }

        public override string? ToString()
        {
            return base.ToString();
        }

    }
}
