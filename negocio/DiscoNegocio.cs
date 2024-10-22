using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;
using System.Data;
using System.Data.SqlClient;

namespace negocio
{
    public class DiscoNegocio
    {
        public List<Disco> listar()
        {
            List<Disco> lista = new List<Disco>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("SELECT d.Id, d.Titulo, d.FechaLanzamiento, d.CantidadCanciones, d.UrlImagenTapa, e.Descripcion, t.Descripcion, e.Id IdTipo, t.Id IdEdicion FROM DISCOS d join ESTILOS e on d.IdEstilo = e.Id join TIPOSEDICION t on d.IdTipoEdicion=t.Id");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Disco disco = new Disco();
                    disco.Codigo = Convert.ToInt32(datos.Lector[0]);
                    disco.Nombre = Convert.ToString(datos.Lector[1]);
                    disco.FechaLanzamiento = Convert.ToDateTime(datos.Lector[2]);
                    disco.CantCanciones = Convert.ToInt32(datos.Lector[3]);
                    disco.UrlImagen = Convert.ToString(datos.Lector[4]);
                    disco.Tipo = new Estilo();
                    disco.Tipo.Codigo = Convert.ToInt32(datos.Lector["IdTipo"]);
                    disco.Tipo.Descripcion = Convert.ToString(datos.Lector[5]);
                    disco.Edicion = new TipoEdicion();
                    disco.Edicion.Id = Convert.ToInt32(datos.Lector["IdEdicion"]);
                    disco.Edicion.Descripcion = Convert.ToString(datos.Lector[6]);

                    lista.Add(disco);
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

        public void agregar(Disco nuevo)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("INSERT INTO DISCOS (Titulo, FechaLanzamiento, CantidadCanciones, UrlImagenTapa, IdEstilo, IdTipoEdicion) VALUES(@titulo, @fechaLanzamiento, @cantCanciones, @urlImagen, @idEstilo, @idTipoEdicion)");
                datos.setearParametro("@titulo", nuevo.Nombre);
                datos.setearParametro("fechaLanzamiento", nuevo.FechaLanzamiento);
                datos.setearParametro("@cantCanciones", nuevo.CantCanciones);
                datos.setearParametro("@urlImagen", nuevo.UrlImagen);
                datos.setearParametro("@idEstilo", nuevo.Tipo.codigo);
                datos.setearParametro("idTipoEdicion", nuevo.Edicion.id);
                datos.ejecutarAccion();
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

        public void modificar(Disco modificar)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("UPDATE DISCOS SET Titulo = @titulo,  FechaLanzamiento = @fechaLanzamiento, CantidadCanciones = @cantCanciones, UrlImagenTapa = @urlImagen, IdEstilo = @idEstilo, IdTipoEdicion = @idTipoEdicion WHERE Id = @codigo");
                datos.setearParametro("@codigo", modificar.Codigo);
                datos.setearParametro("@titulo", modificar.Nombre);
                datos.setearParametro("fechaLanzamiento", modificar.FechaLanzamiento);
                datos.setearParametro("@cantCanciones", modificar.CantCanciones);
                datos.setearParametro("@urlImagen", modificar.UrlImagen);
                datos.setearParametro("@idEstilo", modificar.Tipo.codigo);
                datos.setearParametro("idTipoEdicion", modificar.Edicion.id);
                datos.ejecutarAccion();
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

        public void eliminar(int codigo)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("Delete Discos Where Id = @codigo");
                datos.setearParametro("@codigo", codigo);
                datos.ejecutarAccion();
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
       public List<Disco> filtrar(string campo, string criterio, string filtro)
        {
            List<Disco> lista = new List<Disco>();
            AccesoDatos datos = new AccesoDatos();

            try
            {  
                string consulta = "SELECT d.Id, d.Titulo, d.FechaLanzamiento, d.CantidadCanciones, d.UrlImagenTapa, e.Descripcion, t.Descripcion, e.Id IdTipo, t.Id IdEdicion FROM DISCOS d join ESTILOS e on d.IdEstilo = e.Id join TIPOSEDICION t on d.IdTipoEdicion=t.Id WHERE ";
                
                if(campo == "Nombre")
                {
                    switch (criterio)
                    {
                        case "Empieza con:":
                            consulta += "Titulo LIKE '" + filtro + "%'";
                            break;
                        case "Termina con:":
                            consulta += "Titulo LIKE '%" + filtro + "'";
                            break;
                        default:
                            consulta += "Titulo LIKE '%" + filtro + "%'";
                            break;
                    }
                }
                else
                {

                    switch (criterio)
                    {
                        case "Mayor a:":
                            consulta += "cantidadCanciones > " + filtro;
                            break;
                        case "Menor a:":
                            consulta += "cantidadCanciones < " + filtro;
                            break;
                        default:
                            consulta += "cantidadCanciones = " + filtro;
                            break;
                    }
                }
                datos.setearConsulta(consulta);
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Disco disco = new Disco();
                    disco.Codigo = Convert.ToInt32(datos.Lector[0]);
                    disco.Nombre = Convert.ToString(datos.Lector[1]);
                    disco.FechaLanzamiento = Convert.ToDateTime(datos.Lector[2]);
                    disco.CantCanciones = Convert.ToInt32(datos.Lector[3]);
                    disco.UrlImagen = Convert.ToString(datos.Lector[4]);
                    disco.Tipo = new Estilo();
                    disco.Tipo.Codigo = Convert.ToInt32(datos.Lector["IdTipo"]);
                    disco.Tipo.Descripcion = Convert.ToString(datos.Lector[5]);
                    disco.Edicion = new TipoEdicion();
                    disco.Edicion.Id = Convert.ToInt32(datos.Lector["IdEdicion"]);
                    disco.Edicion.Descripcion = Convert.ToString(datos.Lector[6]);

                    lista.Add(disco);
                }

                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }

}
