using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dao
{
    public class AccesoDatos
    {
        String rutaBDHOSPITAL =
      "Data Source=localhost\\sqlexpress;Initial Catalog=HOSPITAL;Integrated Security=True;Encrypt=False";

        public AccesoDatos()
        {
            // TODO: Agregar aquí la lógica del constructor
        }

        public SqlConnection ObtenerConexion()
        {
            SqlConnection cn = new SqlConnection(rutaBDHOSPITAL);
            try
            {
                cn.Open();
                return cn;
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        public SqlDataAdapter ObtenerAdaptador(String consultaSql, SqlConnection cn)
        {
            SqlDataAdapter adaptador;
            try
            {
                adaptador = new SqlDataAdapter(consultaSql, cn);
                return adaptador;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        //public int EjecutarSelect(string consulta)
        //{
        //    int rol = 1;
        //    SqlConnection Conexion = ObtenerConexion();
        //    SqlCommand command = new SqlCommand(consulta, Conexion);
        //    SqlDataReader reader = command.ExecuteReader();
        //    if (reader.HasRows)
        //    {
        //        while (reader.Read())
        //        {
        //            rol = Convert.ToInt32(reader["ID_ROL_USUARIO"]);
        //        }
        //    }
        //    else
        //    {
        //        rol = 0;
        //    }
        //    reader.Close();
        //    Conexion.Close();
        //    return rol;
        //}

        public string Ejecutar(string consulta)
        {
            string Usuario = "";
            SqlConnection Conexion = ObtenerConexion();
            SqlCommand command = new SqlCommand(consulta, Conexion);
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Usuario = Convert.ToString(reader["TIPO_USUARIO"]);
                }
            }
            else
            {
                Usuario = null;
            }
            reader.Close();
            Conexion.Close();
            return Usuario;
        }

        public DataTable ObtenerTabla(String NombreTabla, String Sql)
        {
            DataSet ds = new DataSet();
            SqlConnection Conexion = ObtenerConexion();
            SqlDataAdapter adp = ObtenerAdaptador(Sql, Conexion);
            adp.Fill(ds, NombreTabla);
            Conexion.Close();
            return ds.Tables[NombreTabla];
        }

        public int EjecutarProcedimientoAlmacenado(SqlCommand Comando, String NombreSP)
        {
            int FilasCambiadas;
            SqlConnection Conexion = ObtenerConexion();
            SqlCommand cmd = new SqlCommand();
            cmd = Comando;
            cmd.Connection = Conexion;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = NombreSP;
            FilasCambiadas = cmd.ExecuteNonQuery();
            Conexion.Close();
            return FilasCambiadas;
        }

        public Boolean existe(String consulta)
        {
            Boolean estado = false;
            SqlConnection Conexion = ObtenerConexion();
            SqlCommand cmd = new SqlCommand(consulta, Conexion);
            SqlDataReader datos = cmd.ExecuteReader();
            if (datos.Read())
            {
                estado = true;
            }
            return estado;
        }

        public int ObtenerMaximo(String consulta)
        {
            int max = 0;
            SqlConnection Conexion = ObtenerConexion();
            SqlCommand cmd = new SqlCommand(consulta, Conexion);
            SqlDataReader datos = cmd.ExecuteReader();
            if (datos.Read())
            {
                max = Convert.ToInt32(datos[0].ToString());
            }
            return max;
        }
    }
}
