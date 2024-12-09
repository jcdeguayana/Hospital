using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace Dao
{
    public class DaoPaciente
    {
        private AccesoDatos ad = new AccesoDatos();
        public DaoPaciente()
        {
        }

        public Boolean existePaciente(Paciente Paci)
        {
            String consulta = "SELECT * FROM PACIENTES WHERE DNI_PACIENTE='" + Paci.getdni() + "'";
            return ad.existe(consulta);
        }
        public int AgregarPaciente(Paciente Paci)
        {
            SqlCommand comando = new SqlCommand();
            ArmarParametrosPacienteAgregar(ref comando, Paci);
            return ad.EjecutarProcedimientoAlmacenado(comando, "spAgregarPACIENTE");
        }

        public int EliminarPaciente(string dni)
        {
            SqlCommand comando = new SqlCommand();
            ArmarParametrosPacienteEliminar(ref comando, dni);
            return ad.EjecutarProcedimientoAlmacenado(comando, "spEliminarPACIENTE");
        }

        public int EliminarTurnoPaciente(string dni)
        {
            SqlCommand comando = new SqlCommand();
            ArmarParametrosTurnoPacienteEliminar(ref comando, dni);
            return ad.EjecutarProcedimientoAlmacenado(comando, "spEliminarTurnoPaciente");
        }
        public int ActualizarPaciente(Paciente paciente)
        {
            SqlCommand comando = new SqlCommand();
            ArmarParametroPacienteActu(ref comando, paciente);
            return ad.EjecutarProcedimientoAlmacenado(comando, "spActualizarPACIENTE");
        }


        private void ArmarParametrosPacienteAgregar(ref SqlCommand Comando, Paciente paciente)
        {
            SqlParameter sqlParametros = new SqlParameter();

            // Agregar parámetros para la tabla de pacientes
            sqlParametros = Comando.Parameters.Add("@DNI_PACIENTE", SqlDbType.Char);
            sqlParametros.Value = paciente.getdni();

            sqlParametros = Comando.Parameters.Add("@ID_LOCALIDAD_PACIENTE", SqlDbType.Int);
            sqlParametros.Value = paciente.getId_localidad();

            sqlParametros = Comando.Parameters.Add("@NOMBRE_P", SqlDbType.VarChar);
            sqlParametros.Value = paciente.getnombre();

            sqlParametros = Comando.Parameters.Add("@APELLIDO_P", SqlDbType.VarChar);
            sqlParametros.Value = paciente.getapellido();

            sqlParametros = Comando.Parameters.Add("@SEXO_P", SqlDbType.VarChar);
            sqlParametros.Value = paciente.getsexo();

            sqlParametros = Comando.Parameters.Add("@NACIONALIDAD_P", SqlDbType.VarChar);
            sqlParametros.Value = paciente.getnacionalidad();

            sqlParametros = Comando.Parameters.Add("@FECHA_NACIMIENTO_P", SqlDbType.Date);
            sqlParametros.Value = paciente.getfecha_nacimiento();

            sqlParametros = Comando.Parameters.Add("@DIRECCION", SqlDbType.VarChar);
            sqlParametros.Value = paciente.getdireccion();

            sqlParametros = Comando.Parameters.Add("@EMAIL_P", SqlDbType.VarChar);
            sqlParametros.Value = paciente.getcorreo();

            sqlParametros = Comando.Parameters.Add("@TELEFONO", SqlDbType.Char);
            sqlParametros.Value = paciente.gettelefono();

        }
        private void ArmarParametrosPacienteEliminar(ref SqlCommand comando, string dni)
        {
            SqlParameter sqlParametros = new SqlParameter();
            sqlParametros = comando.Parameters.Add("@DNI_PACIENTE", SqlDbType.Char);
            sqlParametros.Value = dni;
        }

        private void ArmarParametrosTurnoPacienteEliminar(ref SqlCommand comando, string dni)
        {
            SqlParameter sqlParametros = new SqlParameter();
            sqlParametros = comando.Parameters.Add("@DNI_PACIENTE_TUR", SqlDbType.Char);
            sqlParametros.Value = dni;
        }

        private void ArmarParametroPacienteActu(ref SqlCommand comando, Paciente paciente)
        {
            SqlParameter sqlParametros = new SqlParameter();
            sqlParametros = comando.Parameters.Add("@DNI_PACIENTE", SqlDbType.Char);
            sqlParametros.Value = paciente.getdni();

            sqlParametros = comando.Parameters.Add("@ID_LOCALIDAD_PACIENTE", SqlDbType.Int);
            sqlParametros.Value = paciente.getId_localidad();

            sqlParametros = comando.Parameters.Add("@NOMBRE_P", SqlDbType.VarChar);
            sqlParametros.Value = paciente.getnombre();

            sqlParametros = comando.Parameters.Add("@APELLIDO_P", SqlDbType.VarChar);
            sqlParametros.Value = paciente.getapellido();

            sqlParametros = comando.Parameters.Add("@SEXO_P", SqlDbType.VarChar);
            sqlParametros.Value = paciente.getsexo();

            sqlParametros = comando.Parameters.Add("@NACIONALIDAD_P", SqlDbType.VarChar);
            sqlParametros.Value = paciente.getprovincia();

            sqlParametros = comando.Parameters.Add("@FECHA_NACIMIENTO_P", SqlDbType.Date);
            sqlParametros.Value = paciente.getfecha_nacimiento();

            sqlParametros = comando.Parameters.Add("@DIRECCION", SqlDbType.VarChar);
            sqlParametros.Value = paciente.getdireccion();

            sqlParametros = comando.Parameters.Add("@EMAIL_P", SqlDbType.VarChar);
            sqlParametros.Value = paciente.getcorreo();

            sqlParametros = comando.Parameters.Add("@TELEFONO", SqlDbType.Char);
            sqlParametros.Value = paciente.gettelefono();
        }

        public DataTable FiltrarPaciente(string consulta)
        {
            SqlConnection con = ad.ObtenerConexion();
            DataTable dt = new DataTable();
            string Consulta = "SELECT DNI_PACIENTE AS dni,ID_LOCALIDAD_PACIENTE AS Id_localidad, NOMBRE_P AS nombre, APELLIDO_P AS apellido, SEXO_P AS sexo, NACIONALIDAD_P AS nacionalidad, FECHA_NACIMIENTO_P AS fecha_nacimiento, DIRECCION AS direccion, EMAIL_P AS correo, TELEFONO AS telefono FROM PACIENTES WHERE DNI_PACIENTE = @DNI";
            SqlCommand CMD = new SqlCommand(Consulta, con);
            CMD.Parameters.AddWithValue("@DNI", consulta);
            SqlDataAdapter da = new SqlDataAdapter(CMD);
            da.Fill(dt);
            return dt;
        }

        public DataTable ListarPacientes()
        {
            SqlConnection con = ad.ObtenerConexion();
            DataTable dt = new DataTable();
            string consulta = "SELECT DNI_PACIENTE AS dni,ID_LOCALIDAD_PACIENTE AS Id_localidad, NOMBRE_P AS nombre, APELLIDO_P AS apellido, SEXO_P AS sexo, NACIONALIDAD_P AS nacionalidad, FECHA_NACIMIENTO_P AS fecha_nacimiento, DIRECCION AS direccion, EMAIL_P AS correo, TELEFONO AS telefono FROM PACIENTES";
            SqlCommand CMD = new SqlCommand(consulta, con);
            SqlDataAdapter da = new SqlDataAdapter(CMD);
            da.Fill(dt);
            return dt;
        }

        public SqlDataReader obtenerPacientes()
        {
            SqlConnection Conexion = ad.ObtenerConexion();
            string consulta = "SELECT DNI_PACIENTE FROM PACIENTES";
            SqlCommand comando = new SqlCommand(consulta, Conexion);

            SqlDataReader lector = comando.ExecuteReader();
            return lector;
        }

        public SqlDataReader Dias()
        {
            SqlConnection conexion = ad.ObtenerConexion();
            string consulta = "SELECT DISTINCT DIA_HA FROM HORARIOS_ATENCION";
            SqlCommand comando = new SqlCommand(consulta,conexion);
            SqlDataReader lector = comando.ExecuteReader();
            return lector;
        }

        public SqlDataReader Horas()
        {
            SqlConnection conexion = ad.ObtenerConexion();
            string consulta = "SELECT DISTINCT HORA_HA FROM HORARIOS_ATENCION";
            SqlCommand comando = new SqlCommand(consulta, conexion);
            SqlDataReader lector = comando.ExecuteReader();
            return lector;
        }
        public SqlDataReader obtenerMedicos(int IdEspecialidad)
        {
            SqlConnection Conexion = ad.ObtenerConexion();
            string consulta = "SELECT LEGAJO_MEDICO FROM MEDICOS INNER JOIN ESPECIALIDADES ON MEDICOS.ID_ESPECIALIDAD_MEDICO = ESPECIALIDADES.ID_ESPECIALIDAD_E WHERE MEDICOS.ID_ESPECIALIDAD_MEDICO = @ID_ESPECIALIDAD;";
            SqlCommand comando = new SqlCommand(consulta, Conexion);
            comando.Parameters.AddWithValue("@ID_ESPECIALIDAD", IdEspecialidad);
            SqlDataReader lector = comando.ExecuteReader();
            return lector;
        }

        public SqlDataReader obtenerDias(int legajo)
        {
            SqlConnection conexion = ad.ObtenerConexion();
            string consulta = "SELECT DISTINCT DIA_HA FROM HORARIOS_ATENCION WHERE ESTADO_HA = 1 AND LEGAJO_DOC_HA = @LEGAJO;";
            SqlCommand comando = new SqlCommand(consulta,conexion);
            comando.Parameters.AddWithValue("@LEGAJO",legajo);
            SqlDataReader lector = comando.ExecuteReader();
            return lector;
        }

        public SqlDataReader obtenerHoras(string dia)
        {
            SqlConnection conexion = ad.ObtenerConexion();
            string consulta = "SELECT HORA_HA FROM HORARIOS_ATENCION WHERE ESTADO_HA = 1 AND DIA_HA = @DIA;";
            SqlCommand comando = new SqlCommand(consulta, conexion);
            comando.Parameters.AddWithValue("@DIA", dia);
            SqlDataReader lector = comando.ExecuteReader();
            return lector;
        }
    }      
}
