using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
namespace Dao
{
    public class DaoMedico
    {
        private AccesoDatos ad = new AccesoDatos();
        public DaoMedico()
        {
        }
        // Método para cargar las provincias en el DropDownList
        public SqlDataReader obtenerProvincias()
        {
            SqlConnection Conexion = ad.ObtenerConexion();
            string consulta = "SELECT ID_PROVINCIA, NOMBRE_PROVINCIA FROM PROVINCIAS";
            SqlCommand comando = new SqlCommand(consulta, Conexion);

            SqlDataReader lector = comando.ExecuteReader();
            return lector;
        }

        public SqlDataReader obtenerLocalidades(int IdProvincia)
        {
            SqlConnection Conexion = ad.ObtenerConexion();
            string consulta = "SELECT * FROM Localidad INNER JOIN Provincias ON Provincias.Id_Provincia = Localidad.Id_Provincia WHERE Provincias.Id_Provincia = @Id_Provincia;";
            SqlCommand comando = new SqlCommand(consulta, Conexion);
            comando.Parameters.AddWithValue("@Id_Provincia", IdProvincia);
            SqlDataReader lector = comando.ExecuteReader();
            return lector;
        }

        public SqlDataReader obtenerEspecialidades()
        {
            SqlConnection Conexion = ad.ObtenerConexion();
            string consulta = "SELECT ID_ESPECIALIDAD_E, NOMBRE_E FROM ESPECIALIDADES";
            SqlCommand comando = new SqlCommand(consulta, Conexion);

            SqlDataReader lector = comando.ExecuteReader();
            return lector;
        }

        //public int agregarCategoria(Categoria cat)
        //{

        //    cat.setIdCategoria(ds.ObtenerMaximo("SELECT max(idCategoría) FROM Categorías") + 1);
        //    SqlCommand comando = new SqlCommand();
        //    ArmarParametrosCategoriaAgregar(ref comando, cat);
        //    return ds.EjecutarProcedimientoAlmacenado(comando, "spAgregarCategoria");
        //}

        //public Boolean existeCategoría(Categoria cat)
        //{
        //    String consulta = "Select * from categorías where NombreCategoría='" + cat.getNombreCategoria() + "'";
        //    return ds.existe(consulta);
        //}

        public Boolean existeMedico(Medico med)
        {
            String consulta = "SELECT * FROM MEDICOS WHERE ID_USUARIO_MEDICO='" + med.getId_Usuario() + "'";
            return ad.existe(consulta);
        }

        public Boolean existeLEGAJO(Medico med)
        {
            String consulta = "SELECT * FROM MEDICOS WHERE LEGAJO_MEDICO='"+ med.getLegajo() + "'";
            return ad.existe(consulta); 
        }
        
        public Boolean existeDNI(Medico med)
        {
            String consulta = "SELECT * FROM MEDICOS WHERE DNI_MEDICO='"+ med.getDNI() + "'";
            return ad.existe(consulta);
        }


        public int ExisteHorario(int legajo, string dia, string hora)
        {
            string consulta = "SELECT COUNT(*) FROM HORARIOS_ATENCION WHERE LEGAJO_DOC_HA = @LEGAJO AND DIA_HA = @DIA AND HORA_HA = @HORA";

            SqlConnection Conexion = ad.ObtenerConexion();

            SqlCommand cmd = new SqlCommand(consulta, Conexion);
                cmd.Parameters.AddWithValue("@LEGAJO", legajo);
                cmd.Parameters.AddWithValue("@DIA", dia);
                cmd.Parameters.AddWithValue("@HORA", hora);

                int count = (int)cmd.ExecuteScalar();

                return count;
        }

            public int AgregarMedico(Medico med)
        {
            //med.setId_Usuario(ad.ObtenerMaximo("SELECT max(ID_USUARIO_MEDICO) FROM MEDICOS")+1);
            SqlCommand comando = new SqlCommand();
            ArmarParametrosMedicoAgregar(ref comando, med);
            return ad.EjecutarProcedimientoAlmacenado(comando,"spAgregarMEDICO");
        }

        public int agregarUsuario(Medico medico)
        {
            //medico.setId_Usuario(1);
            SqlCommand comando = new SqlCommand();
            ArmarParametrosUsuarioAgregar(ref comando, medico);
            return ad.EjecutarProcedimientoAlmacenado(comando, "spAgregarUsuario");
        }

        public int EliminarMedico(int id)
        {
            SqlCommand comando = new SqlCommand();
            ArmarParametrosMedicoEliminar(ref comando, id);
            return ad.EjecutarProcedimientoAlmacenado(comando, "spEliminarMEDICO");
        }

        public int EliminarHorariosMedico(int legajo)
        {
            SqlCommand comando = new SqlCommand();
            ArmarParametrosMedicoHorarios(ref comando, legajo);
            return ad.EjecutarProcedimientoAlmacenado(comando, "sp_EliminarHORARIOS");
        }

        public int EliminarTurno(int legajo)
        {
            SqlCommand comando = new SqlCommand();
            ArmarParametroEliminarTurno(ref comando, legajo);
            return ad.EjecutarProcedimientoAlmacenado(comando,"sp_EliminarTURNO");
        }


        public int ActualizarMedico(Medico medico)
        {
            SqlCommand comando = new SqlCommand();
            ArmarParametrosMedicoActualizar(ref comando, medico);
            return ad.EjecutarProcedimientoAlmacenado(comando, "sp_ActualizarMedico");
        }

        public int ActualizarUsuario(Medico medico)
        {
            SqlCommand comando = new SqlCommand();
            ArmarParametrosUsuarioActualizar(ref comando, medico);
            return ad.EjecutarProcedimientoAlmacenado(comando, "sp_ActualizarUsuario");
        }

        public int EliminarUsuario(int id)
        {
            SqlCommand comando = new SqlCommand();
            ArmarParametrosUsuarioEliminar(ref comando, id);
            return ad.EjecutarProcedimientoAlmacenado(comando, "spEliminarUSUARIO");
        }

        public int InsertarHorarios(Medico Medico)
        {
            SqlCommand comando = new SqlCommand();
            ArmarParametrosHorarios(ref comando, Medico);
            return ad.EjecutarProcedimientoAlmacenado(comando, "Sp_AgregarHorarios");
        }

        private void ArmarParametrosMedicoEliminar(ref SqlCommand Comando, int id)
        {
            SqlParameter SqlParametros = new SqlParameter();
            SqlParametros = Comando.Parameters.Add("@ID_USUARIO_MEDICO", SqlDbType.Int);
            SqlParametros.Value = id;
        }

        private void ArmarParametroEliminarTurno(ref SqlCommand comando, int legajo)
        {
            SqlParameter SqlParametros = new SqlParameter();
            SqlParametros = comando.Parameters.Add("@LEGAJO_MED_TUR", SqlDbType.Int);
            SqlParametros.Value = legajo;
        }
        private void ArmarParametrosMedicoHorarios(ref SqlCommand Comando, int legajo)
        {
            SqlParameter SqlParametros = new SqlParameter();
            SqlParametros = Comando.Parameters.Add("@LEGAJO", SqlDbType.Int);
            SqlParametros.Value = legajo;
        }


        private void ArmarParametrosUsuarioEliminar(ref SqlCommand Comando, int id)
        {
            SqlParameter SqlParametros = new SqlParameter();
            SqlParametros = Comando.Parameters.Add("@ID_USUARIO", SqlDbType.Int);
            SqlParametros.Value = id;
        }

        private void ArmarParametrosUsuarioAgregar(ref SqlCommand Comando, Medico medico)
        {
            SqlParameter SqlParametros = new SqlParameter();
            SqlParametros = Comando.Parameters.Add("@ID_USUARIO", SqlDbType.Int);
            SqlParametros.Value = medico.getId_Usuario();
            SqlParametros = Comando.Parameters.Add("@NOMBRE_USUARIO", SqlDbType.VarChar);
            SqlParametros.Value = medico.getNombre_Usuario();
            SqlParametros = Comando.Parameters.Add("@CONTRASEÑA", SqlDbType.VarChar);
            SqlParametros.Value = medico.getContraseña();
            SqlParametros = Comando.Parameters.Add("@TIPO_USUARIO", SqlDbType.VarChar);
            SqlParametros.Value = medico.getTipoUsuario();
        }

        private void ArmarParametrosMedicoAgregar(ref SqlCommand Comando, Medico medico)
        {
            SqlParameter sqlParametros = new SqlParameter();
            sqlParametros = Comando.Parameters.Add("@LEGAJO_MEDICO",SqlDbType.Int);
            sqlParametros.Value = medico.getLegajo();
            sqlParametros = Comando.Parameters.Add("@ID_USUARIO_MEDICO", SqlDbType.Int);
            sqlParametros.Value = medico.getId_Usuario();
            sqlParametros = Comando.Parameters.Add("@ID_ESPECIALIDAD", SqlDbType.Int);
            sqlParametros.Value = medico.getId_Especialidad();
            sqlParametros = Comando.Parameters.Add("@ID_LOCALIDAD_MEDICO", SqlDbType.Int);
            sqlParametros.Value = medico.getId_Localidad();
            sqlParametros = Comando.Parameters.Add("@DNI_MEDICO", SqlDbType.Char);
            sqlParametros.Value = medico.getDNI();
            sqlParametros = Comando.Parameters.Add("@NOMBRE_MEDICO", SqlDbType.VarChar);
            sqlParametros.Value = medico.getNombre();
            sqlParametros = Comando.Parameters.Add("@APELLIDO_MEDICO", SqlDbType.VarChar);
            sqlParametros.Value = medico.getApellido();
            sqlParametros = Comando.Parameters.Add("@SEXO_MEDICO", SqlDbType.VarChar);
            sqlParametros.Value = medico.getSexo();
            sqlParametros = Comando.Parameters.Add("@NACIONALIDAD_MEDICO", SqlDbType.VarChar);
            sqlParametros.Value = medico.getNacionalidad();
            sqlParametros = Comando.Parameters.Add("@FECHA_NACIMIENTO_MEDICO", SqlDbType.Date);
            sqlParametros.Value = medico.getFecha_Nacimiento();
            sqlParametros = Comando.Parameters.Add("@DIRECCION_MEDICO", SqlDbType.VarChar);
            sqlParametros.Value = medico.getDireccion();
            sqlParametros = Comando.Parameters.Add("@EMAIL_MEDICO", SqlDbType.VarChar);
            sqlParametros.Value = medico.getEmail();
            sqlParametros = Comando.Parameters.Add("@TELEFONO_MEDICO", SqlDbType.Char);
            sqlParametros.Value = medico.getTelefono();
        }

        private void ArmarParametrosUsuarioActualizar(ref SqlCommand comando, Medico medico)
        {
            SqlParameter sqlParametros = new SqlParameter();
            sqlParametros = comando.Parameters.Add("@NOMBRE_USUARIO_ACTUAL", SqlDbType.VarChar);
            sqlParametros.Value = medico.getNombre_Usuario();
            sqlParametros = comando.Parameters.Add("@NUEVO_NOMBRE_USUARIO", SqlDbType.VarChar);
            sqlParametros.Value = medico.getNombre_Usuario_Nuevo();
            sqlParametros = comando.Parameters.Add("@NUEVA_CONTRASEÑA", SqlDbType.VarChar);
            sqlParametros.Value = medico.getContraseña();
        }


        private void ArmarParametrosMedicoActualizar(ref SqlCommand Comando, Medico medico)
        {

            SqlParameter sqlParametros = new SqlParameter();
            sqlParametros = Comando.Parameters.Add("@LEGAJO_MEDICO", SqlDbType.Int);
            sqlParametros.Value = medico.getLegajo();

            //sqlParametros = Comando.Parameters.Add("@ID_USUARIO_MEDICO", SqlDbType.Int);
            //sqlParametros.Value = medico.getId_Usuario();

            sqlParametros = Comando.Parameters.Add("@ID_ESPECIALIDAD", SqlDbType.Int);
            sqlParametros.Value = medico.getId_Especialidad();

            //sqlParametros = Comando.Parameters.Add("@ID_LOCALIDAD_MEDICO", SqlDbType.Int);
            //sqlParametros.Value = medico.getId_Localidad();

            sqlParametros = Comando.Parameters.Add("@DNI_MEDICO", SqlDbType.Char);
            sqlParametros.Value = medico.getDNI();

            sqlParametros = Comando.Parameters.Add("@NOMBRE_MEDICO", SqlDbType.VarChar);
            sqlParametros.Value = medico.getNombre();

            sqlParametros = Comando.Parameters.Add("@APELLIDO_MEDICO", SqlDbType.VarChar);
            sqlParametros.Value = medico.getApellido();

            //sqlParametros = Comando.Parameters.Add("@SEXO_MEDICO", SqlDbType.VarChar);
            //sqlParametros.Value = medico.getSexo();

            //sqlParametros = Comando.Parameters.Add("@NACIONALIDAD_MEDICO", SqlDbType.VarChar);
            //sqlParametros.Value = medico.getNacionalidad();

            sqlParametros = Comando.Parameters.Add("@FECHA_NACIMIENTO_MEDICO", SqlDbType.Date);
            sqlParametros.Value = medico.getFecha_Nacimiento();

            sqlParametros = Comando.Parameters.Add("@DIRECCION_MEDICO", SqlDbType.VarChar);
            sqlParametros.Value = medico.getDireccion();

            sqlParametros = Comando.Parameters.Add("@EMAIL_MEDICO", SqlDbType.VarChar);
            sqlParametros.Value = medico.getEmail();

            sqlParametros = Comando.Parameters.Add("@TELEFONO_MEDICO", SqlDbType.Char);
            sqlParametros.Value = medico.getTelefono();
        }




        private void ArmarParametrosHorarios(ref SqlCommand Comando, Medico medico)
        {
            SqlParameter SqlParametros = new SqlParameter();
            SqlParametros = Comando.Parameters.Add("@LEGAJO", SqlDbType.Int);
            SqlParametros.Value = medico.getLegajoAtencion();
            SqlParametros = Comando.Parameters.Add("@DIA", SqlDbType.VarChar);
            SqlParametros.Value = medico.getDia();
            SqlParametros = Comando.Parameters.Add("@HORA", SqlDbType.Time);
            SqlParametros.Value = medico.getHora();
            
        }

        public DataTable FiltroMedicos(string consulta1, string consulta2)
        {
            SqlConnection con = ad.ObtenerConexion();
            DataTable dt = new DataTable();
            string consulta = "SELECT LEGAJO_MEDICO AS LEGAJO, NOMBRE_E AS ESPECIALIDAD, DNI_MEDICO AS DNI, NOMBRE_MEDICO AS NOMBRE, APELLIDO_MEDICO AS APELLIDO, FECHA_NACIMIENTO_MEDICO AS NACIMIENTO, DIRECCION_MEDICO AS DIRECCION, EMAIL_MEDICO AS EMAIL, TELEFONO_MEDICO AS TELEFONO, ID_USUARIO_MEDICO AS USUARIO FROM MEDICOS INNER JOIN ESPECIALIDADES ON ID_ESPECIALIDAD_MEDICO = ID_ESPECIALIDAD_E INNER JOIN USUARIO ON ID_USUARIO_MEDICO = ID_USUARIO WHERE DNI_MEDICO = @DNI OR NOMBRE_USUARIO = @Usuario";
            SqlCommand cmd = new SqlCommand(consulta, con);
            cmd.Parameters.AddWithValue("@DNI", consulta1);
            cmd.Parameters.AddWithValue("@Usuario", consulta2);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }

        public DataTable ListadoMedicos()
        {
            SqlConnection con = ad.ObtenerConexion();
            DataTable dt = new DataTable();
            string consulta = "SELECT LEGAJO_MEDICO AS LEGAJO, NOMBRE_E AS ESPECIALIDAD, DNI_MEDICO AS DNI, NOMBRE_MEDICO AS NOMBRE, APELLIDO_MEDICO AS APELLIDO, FECHA_NACIMIENTO_MEDICO AS NACIMIENTO, DIRECCION_MEDICO AS DIRECCION, EMAIL_MEDICO AS EMAIL, TELEFONO_MEDICO AS TELEFONO, ID_USUARIO_MEDICO AS USUARIO FROM MEDICOS INNER JOIN ESPECIALIDADES ON ID_ESPECIALIDAD_MEDICO = ID_ESPECIALIDAD_E INNER JOIN USUARIO ON ID_USUARIO_MEDICO = ID_USUARIO";
            SqlCommand cmd = new SqlCommand(consulta, con);      
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }

        public DataTable DatosMedico(string Usuario)
        {
            SqlConnection con = ad.ObtenerConexion();
            DataTable dt = new DataTable();
            string consulta = "SELECT LEGAJO_MEDICO AS LEGAJO, DNI_MEDICO AS DNI, NOMBRE_MEDICO AS NOMBRE, APELLIDO_MEDICO AS APELLIDO, FECHA_NACIMIENTO_MEDICO AS FECHA, DIRECCION_MEDICO AS DIRECCION, EMAIL_MEDICO AS EMAIL FROM MEDICOS INNER JOIN USUARIO ON MEDICOS.ID_USUARIO_MEDICO = USUARIO.ID_USUARIO WHERE USUARIO.NOMBRE_USUARIO = @USUARIO;";
            SqlCommand cmd = new SqlCommand(consulta, con);
            cmd.Parameters.AddWithValue("@USUARIO",Usuario);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }


        public DataTable ObtenerLegajos()
        {
            SqlConnection con = ad.ObtenerConexion();
            DataTable dt = new DataTable();
            string consulta = "SELECT DISTINCT LEGAJO_MEDICO FROM MEDICOS";
            SqlCommand cmd = new SqlCommand(consulta, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }

        public int ObtenerLegajoLogin(string usuario, string pass)
        {
            SqlConnection con = ad.ObtenerConexion();
            int legajo = 0;
            string consulta = "SELECT LEGAJO_MEDiCO FROM USUARIO INNER JOIN MEDICOS ON ID_USUARIO = ID_USUARIO_MEDICO WHERE NOMBRE_USUARIO = @USUARIO AND CONTRASEÑA = @PASS";
            SqlCommand cmd = new SqlCommand(consulta, con);
            cmd.Parameters.AddWithValue("@USUARIO", usuario);
            cmd.Parameters.AddWithValue("@PASS", pass);

            legajo = (int)cmd.ExecuteScalar();
            return legajo;
        }

        public DataTable MisTurnos(int legajo)
        {
            SqlConnection con = ad.ObtenerConexion();
            DataTable dt = new DataTable();
            string consulta = "SELECT * FROM TURNOS WHERE LEGAJO_MED_TUR = @LEGAJO";
            SqlCommand cmd = new SqlCommand(consulta, con);
            cmd.Parameters.AddWithValue("@LEGAJO", legajo);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }

        //        GO
        //CREATE PROCEDURE spEliminarMedico
        //(
        //    @ID_USUARIO_MEDICO INT
        //)
        //AS
        //BEGIN
        //    DELETE FROM MEDICOS
        //    WHERE ID_USUARIO_MEDICO = @ID_USUARIO_MEDICO;
        //END
        //GO

        //        GO
        //CREATE PROCEDURE spEliminarUsuario
        //(
        //    @ID_USUARIO INT
        //)
        //AS
        //BEGIN
        //    DELETE FROM USUARIO
        //    WHERE ID_USUARIO = @ID_USUARIO;
        //END
        //GO

        //        GO
        //CREATE PROCEDURE spAgregarUSUARIO
        //(
        //@ID_USUARIO INT,
        //@NOMBRE_USUARIO VARCHAR(50),
        //@CONTRASEÑA VARCHAR(50),
        //@TIPO_USUARIO VARCHAR(20)
        //)
        //AS
        //INSERT INTO USUARIO(ID_USUARIO, NOMBRE_USUARIO, CONTRASEÑA, TIPO_USUARIO)
        //VALUES(@ID_USUARIO, @NOMBRE_USUARIO, @CONTRASEÑA, @TIPO_USUARIO)
        //RETURN
        //GO

        //       GO
        //CREATE PROCEDURE spAgregarMEDICO
        //(
        //@LEGAJO_MEDICO INT,
        //@ID_USUARIO_MEDICO INT,
        //@ID_ESPECIALIDAD INT,
        //@ID_LOCALIDAD_MEDICO INT,
        //@DNI_MEDICO CHAR(8),
        //@NOMBRE_MEDICO VARCHAR(30),
        //@APELLIDO_MEDICO VARCHAR(30),
        //@SEXO_MEDICO VARCHAR(6),
        //@NACIONALIDAD_MEDICO VARCHAR(50),
        //@FECHA_NACIMIENTO_MEDICO DATE,
        //@DIRECCION_MEDICO VARCHAR(50),
        //@EMAIL_MEDICO VARCHAR(50),
        //@TELEFONO_MEDICO CHAR(10)
        //)
        //AS
        //INSERT INTO MEDICOS
        //(LEGAJO_MEDICO, ID_USUARIO_MEDICO, ID_ESPECIALIDAD_MEDICO, ID_LOCALIDAD_MEDICO,
        //DNI_MEDICO, NOMBRE_MEDICO, APELLIDO_MEDICO, SEXO_MEDICO, NACIONALIDAD_MEDICO, FECHA_NACIMIENTO_MEDICO, DIRECCION_MEDICO, EMAIL_MEDICO, TELEFONO_MEDICO)
        //VALUES(@LEGAJO_MEDICO, @ID_USUARIO_MEDICO, @ID_ESPECIALIDAD, @ID_LOCALIDAD_MEDICO,
        //@DNI_MEDICO, @NOMBRE_MEDICO, @APELLIDO_MEDICO, @SEXO_MEDICO, @NACIONALIDAD_MEDICO, @FECHA_NACIMIENTO_MEDICO, @DIRECCION_MEDICO, @EMAIL_MEDICO, @TELEFONO_MEDICO)
        //RETURN
        //GO
    }
}
