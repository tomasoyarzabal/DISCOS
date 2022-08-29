using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DISCOS_DB
{
    class DiscosConexion
    {
        public List<Discos> Listar()
        {
            List<Discos> Lista = new List<Discos>();
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;

            try
            {
                conexion.ConnectionString = "server=.\\SQLEXPRESS; Data Source=DESKTOP-4H2VBMB\\SQLEXPRESS;Initial Catalog=DISCOS_DB;Integrated Security=True";
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "select d.Id, Titulo, FechaLanzamiento, CantidadCanciones, UrlimagenTapa, E.Descripcion ESTILO, T.Descripcion TipodeEdicion from DISCOS D, ESTILOS E, TIPOSEDICION T where D.IdEstilo = e.Id and D.IdTipoEdicion = t.Id";
                comando.Connection = conexion;

                conexion.Open();
                lector = comando.ExecuteReader();

                while (lector.Read())
                {
                    Discos aux = new Discos();
                    aux.Id = lector.GetInt32(0);
                    aux.Titulo = (string)lector["Titulo"];
                    aux.FechaLanzamiento = (DateTime)lector["FechaLanzamiento"];
                    aux.CantidadCanciones = (int)lector["CantidadCanciones"];
                    aux.UrlImagen = (string)lector["urlimagenTapa"];
                    aux.Estilo = (string)lector["ESTILO"];
                    aux.TipoEdicion = (string)lector["TipodeEdicion"];

                    Lista.Add(aux);
                }

                conexion.Close();
                return Lista;
            }
            catch (Exception Ex)
            {

                throw Ex;
            }

        }
    }
}
