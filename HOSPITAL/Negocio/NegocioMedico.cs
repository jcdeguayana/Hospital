using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Dao;
using Entidades;

namespace Negocio
{
    public class NegocioMedico
    {
        public NegocioMedico() { }
    
        private DaoMedico provincias = new DaoMedico();
        private DaoMedico localidades = new DaoMedico();
        private DaoMedico medico = new DaoMedico();
        private Medico med = new Medico();

        // Método para obtener las provincias
        public SqlDataReader obtenerProvincias()
        {
            return provincias.obtenerProvincias();
        }
        public SqlDataReader obtenerLocalidades(int Provincia)
        {
            return localidades.obtenerLocalidades(Provincia);
        }

        public SqlDataReader obtenerEspecialidades()
        {
            return medico.obtenerEspecialidades();
        }

        public string Login(string Usuario, string Contraseña)
        {
            string TipoUsuario;
            string consulta = "SELECT * FROM USUARIO WHERE NOMBRE_USUARIO = '" + Usuario + "' AND CONTRASEÑA = '" + Contraseña +"'";
            AccesoDatos Dao = new AccesoDatos();
            TipoUsuario = Dao.Ejecutar(consulta);
            return TipoUsuario;
        }

        public void AgregarHorario(int Legajo, string Dia, string Hora)
        {
            DaoMedico medico = new DaoMedico();
            Medico med = new Medico();

            {
            med.setLegajoAtencion(Legajo);
            med.setDia(Dia);
            med.setHora(Hora);

            medico.InsertarHorarios(med);
            }
        }

        public bool AgregarMedico(int Id_Usuario,string Nombre_Usuario,string TipoUsuario, string contraseña, int legajo, string dni, string nombre, string apellido, string sexo, string nacionalidad, string fecha, string direccion, int idLocalidad, string email, string telefono, int especialidad/*, int diasAtencion, string horaInicio, string horaFin*/)
        {
            int cantFilasMedico = 0;
            int cantFilasUsuario = 0;
            med.setId_Usuario(Id_Usuario);
            med.setNombre_Usuario(Nombre_Usuario);
            med.setTipoUsuario(TipoUsuario);
            med.setContraseña(contraseña);
            med.setLegajo(legajo);
            med.setDNI(dni);
            med.setNombre(nombre);
            med.setApellido(apellido);
            med.setSexo(sexo);
            med.setNacionalidad(nacionalidad);
            med.setFecha_Nacimiento(fecha);
            med.setDireccion(direccion);
            med.setId_Localidad(idLocalidad + 1);
            med.setEmail(email);
            med.setTelefono(telefono);
            med.setId_Especialidad(especialidad);
            //med.setDiaAtencion(diasAtencion + 1);
            //med.setHoraInicio(horaInicio);
            //med.setHoraFin(horaFin);

            if (medico.existeMedico(med)==false && medico.existeDNI(med)==false && medico.existeLEGAJO(med)==false)
            {
                cantFilasUsuario = medico.agregarUsuario(med);
                cantFilasMedico = medico.AgregarMedico(med);
            }
            if (cantFilasUsuario == 1 && cantFilasMedico == 1)
                return true;
            else
                return false;
        }

        public void ActualizarMed(int legajo, int Especialidad, string DNI, string Nombre, string Apellido, string Fecha, string Direccion, string Email, string Telefono)
        {
            DaoMedico medico = new DaoMedico();
            Medico med = new Medico();
            {
                med.setLegajo(legajo);
                med.setId_Especialidad(Especialidad);
                med.setDNI(DNI);
                med.setNombre(Nombre);
                med.setApellido(Apellido);
                med.setFecha_Nacimiento(Fecha);
                med.setDireccion(Direccion);
                med.setEmail(Email);
                med.setTelefono(Telefono);

                medico.ActualizarMedico(med);
            }
        }

        public bool ActualizarUsuario(string Usuario_Actual, string Usuario_Nuevo, string Contraseña_Nueva)
        {
            int CantFilasAfectadas = 0;
            DaoMedico medico = new DaoMedico();
            Medico med = new Medico();
            med.setNombre_Usuario(Usuario_Actual);
            med.setNombre_Usuario_Nuevo(Usuario_Nuevo);
            med.setContraseña(Contraseña_Nueva);

            CantFilasAfectadas = medico.ActualizarUsuario(med);

            if (CantFilasAfectadas == 1)
                return true;
            else
                return false;
        }

        public void EliminarHorarios(int legajo)
        {
            DaoMedico dao = new DaoMedico();
            dao.EliminarTurno(legajo);
            dao.EliminarHorariosMedico(legajo);
        }

    public bool EliminarMedico(int id)
        {
            int CantFilasUsuario = 0;
            int CantFilasMedico = 0;

            DaoMedico dao = new DaoMedico();

            CantFilasMedico = dao.EliminarMedico(id);
            CantFilasUsuario = dao.EliminarUsuario(id);

            if (CantFilasUsuario == 1 && CantFilasMedico == 1)
                return true;
            else
                return false;
        }

        public DataTable BusquedaMedico(string dni, string usuario)
        {
            DaoMedico dao = new DaoMedico();
            return dao.FiltroMedicos(dni, usuario);
            
        }


        public int VerificarExistenciaHoraria(int legajo, string dia, string hora)
        {
            DaoMedico dao = new DaoMedico();
            return dao.ExisteHorario(legajo, dia, hora);
        }

        public DataTable CargarLegajos()
        {
            DaoMedico dao = new DaoMedico();
            return dao.ObtenerLegajos();
        }
        public DataTable ListadoMedicos()
        {
            DaoMedico dao = new DaoMedico();
            return dao.ListadoMedicos();
        }

        public DataTable DatosMedico(string Usuario)
        {
            DaoMedico Dao = new DaoMedico();
            return Dao.DatosMedico(Usuario);
        }

        public int ObtenerLegajoUsuarioMedico(string usuario, string pass)
        {
            DaoMedico dao = new DaoMedico();
            int legajo = dao.ObtenerLegajoLogin(usuario, pass);
            return legajo;
        }

        public DataTable MisTurnos(int legajo)
        {
            DaoMedico dao = new DaoMedico();
            return dao.MisTurnos(legajo);
        }
    }
}
