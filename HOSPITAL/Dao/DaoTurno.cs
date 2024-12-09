using Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dao
{
    public class DaoTurno
    {
        private AccesoDatos ad = new AccesoDatos();

        public Boolean existeTurno(Turnos turno)
        {
            String consulta = "SELECT * FROM TURNOS WHERE COD_TURNO_TUR='" + turno.getCodigoTurno() + "'";
            return ad.existe(consulta);
        }

        //public int ExisteTurno(int legajo, string dia, string hora)
        //{
        //    string consulta = "SELECT COUNT(*) FROM TURNOS WHERE LEGAJO_MED_TUR = @LEGAJO AND DIA_TURNOS = @DIA AND HORA_TURNOS = @HORA";

        //    SqlConnection Conexion = ad.ObtenerConexion();

        //    SqlCommand cmd = new SqlCommand(consulta, Conexion);
        //    cmd.Parameters.AddWithValue("@LEGAJO", legajo);
        //    cmd.Parameters.AddWithValue("@DIA", dia);
        //    cmd.Parameters.AddWithValue("@HORA", hora);

        //    int count = (int)cmd.ExecuteScalar();

        //    return count;
        //}
        public int agregarTurno(Turnos turno)
        {
            SqlCommand comando = new SqlCommand();
            ArmarParametrosTurnoAgregar(ref comando, turno);
            return ad.EjecutarProcedimientoAlmacenado(comando, "spAgregarTurno");
        }
        private void ArmarParametrosTurnoAgregar(ref SqlCommand Comando, Turnos turno)
        {
            SqlParameter SqlParametros = new SqlParameter();
            SqlParametros = Comando.Parameters.Add("@COD_TURNO_TUR", SqlDbType.VarChar);
            SqlParametros.Value = turno.getCodigoTurno();
            SqlParametros = Comando.Parameters.Add("@DNI_PACIENTE_TUR", SqlDbType.Char);
            SqlParametros.Value = turno.getDNIPaciente();
            SqlParametros = Comando.Parameters.Add("@LEGAJO_MED_TUR", SqlDbType.Int);
            SqlParametros.Value = turno.getLegajo();
            SqlParametros = Comando.Parameters.Add("@DIA_TURNOS", SqlDbType.VarChar);
            SqlParametros.Value = turno.getDia();
            SqlParametros = Comando.Parameters.Add("@HORA_TURNOS", SqlDbType.Time);
            SqlParametros.Value = turno.getHora();
            SqlParametros = Comando.Parameters.Add("@ESPECIALIDAD", SqlDbType.VarChar);
            SqlParametros.Value = turno.getEspecialidad();
        }
        public int ActualizarMisTurnos(Turnos turno)
        {
            SqlCommand comando = new SqlCommand();
            ArmarParametrosActualizarMisHorarios(ref comando, turno);
            return ad.EjecutarProcedimientoAlmacenado(comando, "Sp_ActualizarHoraMisTurnos");
        }

        public int ActualizarEstadoTurno(Turnos turno)
        {
            SqlCommand comando = new SqlCommand();
            ArmarParametrosActualizarEstadoTurnos(ref comando, turno);
            return ad.EjecutarProcedimientoAlmacenado(comando, "Sp_ActualizarEstadoMisTurnos");
        }

        public int ActualizarHorario(Turnos turno)
        {
            SqlCommand comando = new SqlCommand();
            ArmarParametroHorarioActualizar(ref comando, turno);
            return ad.EjecutarProcedimientoAlmacenado(comando, "spActualizarHORARIO");
        }

        private void ArmarParametroHorarioActualizar(ref SqlCommand comando, Turnos turno)
        {
            SqlParameter sqlParametros = new SqlParameter();
            sqlParametros = comando.Parameters.Add("@LEGAJO_DOC_HA", SqlDbType.Int);
            sqlParametros.Value = turno.getLegajo();

            sqlParametros = comando.Parameters.Add("@DIA_HA", SqlDbType.VarChar);
            sqlParametros.Value = turno.getDia();

            sqlParametros = comando.Parameters.Add("@HORA_HA", SqlDbType.Time);
            sqlParametros.Value = turno.getHora();
        }


        private void ArmarParametrosActualizarMisHorarios(ref SqlCommand Comando, Turnos turno)
        {
            SqlParameter SqlParametros = new SqlParameter();
            SqlParametros = Comando.Parameters.Add("@LEGAJO", SqlDbType.Int);
            SqlParametros.Value = turno.getLegajo();
            SqlParametros = Comando.Parameters.Add("@DIA", SqlDbType.VarChar);
            SqlParametros.Value = turno.getDia();
            SqlParametros = Comando.Parameters.Add("@HORA", SqlDbType.Time);
            SqlParametros.Value = turno.getHora();
        }

        private void ArmarParametrosActualizarEstadoTurnos(ref SqlCommand Comando, Turnos turno)
        {

            SqlParameter SqlParametros = new SqlParameter();
            SqlParametros = Comando.Parameters.Add("@ESTADO", SqlDbType.VarChar);
            SqlParametros.Value = turno.getEstado();
            SqlParametros = Comando.Parameters.Add("@OBSERVACIONES", SqlDbType.Text);
            SqlParametros.Value = turno.getObservacion();
            SqlParametros = Comando.Parameters.Add("@LEGAJO", SqlDbType.Int);
            SqlParametros.Value = turno.getLegajo();
            SqlParametros = Comando.Parameters.Add("@DIA", SqlDbType.VarChar);
            SqlParametros.Value = turno.getDia();
            SqlParametros = Comando.Parameters.Add("@HORA", SqlDbType.Time);
            SqlParametros.Value = turno.getHora();
            SqlParametros = Comando.Parameters.Add("@DNIPACIENTE", SqlDbType.VarChar);
            SqlParametros.Value = turno.getDNIPaciente();
        }

        public DataTable BusquedaTurnos(string legajo, string dni)
        {
            SqlConnection con = ad.ObtenerConexion();
            DataTable dt = new DataTable();
            string consulta = "SELECT * FROM TURNOS WHERE DNI_PACIENTE_TUR = @DNI OR LEGAJO_MED_TUR = @LEGAJO";
            SqlCommand cmd = new SqlCommand(consulta, con);
            cmd.Parameters.AddWithValue("@DNI", dni);
            cmd.Parameters.AddWithValue("@LEGAJO", legajo);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }
        public DataTable FiltroPorDNiPaciente(int legajo, string dni)
        {
            SqlConnection con = ad.ObtenerConexion();
            DataTable dt = new DataTable();
            string consulta = "SELECT * FROM TURNOS WHERE DNI_PACIENTE_TUR = @DNI AND LEGAJO_MED_TUR = @LEGAJO";
            SqlCommand cmd = new SqlCommand(consulta, con);
            cmd.Parameters.AddWithValue("@DNI", dni);
            cmd.Parameters.AddWithValue("@LEGAJO", legajo);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }

        public DataTable ListarTurnos()
        {
            SqlConnection con = ad.ObtenerConexion();
            DataTable dt = new DataTable();
            string consulta = "SELECT * FROM TURNOS";
            SqlCommand cmd = new SqlCommand(consulta, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }

        public double Ausencias()
        {
            SqlConnection con = ad.ObtenerConexion();
            string consulta = "SELECT CAST(SUM(CASE WHEN ESTADO = 'Ausente' THEN 1 ELSE 0 END) AS FLOAT) / NULLIF(COUNT(*), 0) AS promedioAus FROM TURNOS;";
            SqlCommand cmd = new SqlCommand(consulta, con);
            object resultado = cmd.ExecuteScalar();
            if (resultado != null)
            {
                return Convert.ToDouble(resultado);
            }
            return 0;
        }

        public double Presentes()
        {
            SqlConnection con = ad.ObtenerConexion();
            string consulta = "SELECT CAST(SUM(CASE WHEN ESTADO = 'Presente' THEN 1 ELSE 0 END) AS FLOAT) / NULLIF(COUNT(*), 0) AS promedioAus FROM TURNOS;";
            SqlCommand cmd = new SqlCommand(consulta, con);
            object resultado = cmd.ExecuteScalar();
            if (resultado != null)
            {
                return Convert.ToDouble(resultado);
            }
            return 0;

        }
    }
}

