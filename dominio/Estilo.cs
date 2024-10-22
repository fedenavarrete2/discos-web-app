using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Estilo
    {
        public int codigo;
        private string descripcion;

        public int Codigo
        { get { return codigo; } set { codigo = value; } }

        public string Descripcion
        { get { return descripcion; } set { descripcion = value; } }

        public override string ToString()
        {
            return descripcion;
        }
    }
}
