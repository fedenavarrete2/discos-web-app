using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace dominio
{
    public class Disco
    {
        private int codigo;
        private string nombre;
        private DateTime fechaLanzamiento;
        private int cantCanciones;
        private string urlImagen;
        private Estilo tipo;
        private TipoEdicion edicion;

        public int Codigo
        { get { return codigo; }
        set { codigo = value; } }

        public string Nombre
        { get { return nombre; }
        set { nombre = value; } }

        public DateTime FechaLanzamiento
        { get { return fechaLanzamiento;}
        set { fechaLanzamiento = value; } }

        public int CantCanciones
        { get { return cantCanciones; }
          set {  cantCanciones = value;} }

        public string UrlImagen
        { get { return urlImagen; } set { urlImagen = value; } }   

        public Estilo Tipo
        { get { return tipo; } set {  tipo = value; } }

        public TipoEdicion Edicion
        { get { return edicion; } set { edicion = value; } }

    }
}
