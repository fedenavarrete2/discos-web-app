using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace negocio
{
    public class EstiloNegocio
    {
        public List<Estilo> listar()
        {
            List<Estilo> lista = new List<Estilo>();
            AccesoDatos datos = new AccesoDatos();
            
            try
            {
                datos.setearConsulta("SELECT Id, Descripcion FROM ESTILOS");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Estilo estilo = new Estilo();
                    estilo.Codigo = Convert.ToInt32(datos.Lector["Id"]);
                    estilo.Descripcion = Convert.ToString(datos.Lector["Descripcion"]);

                    lista.Add(estilo);
                }


                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }




    }
}
