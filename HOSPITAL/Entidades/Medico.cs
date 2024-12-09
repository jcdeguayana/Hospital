using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Medico
    {
        public Medico()
        {
        }
        private string Nombre_Usuario;
        private string Nombre_Usuario_Nuevo;
        private string Contraseña;
        private string Tipo_Usuario;
        private int Legajo;
        private int Id_Usuario;
        private int Id_Especialidad;
        private int Id_Localidad;
        private string Email;
        private string Telefono;
        private string DNI;
        private string Nombre;
        private string Apellido;
        private string Sexo;
        private string Nacionalidad;
        private string Fecha_Nacimiento;
        private string Direccion;
        private int DiasAtencion;
        private string HoraInicio;
        private string HoraFin;
        private int Legajo_Horario;
        private string Dia;
        private string hora;

      
        public string getHora() { 
        
            return hora;
        }

        public void setHora(string horario)
        {
            hora = horario;
        }

        public string getDia() { 
        
            return Dia;
        }

        public void setDia(string DiaAtencion)
        {
            Dia = DiaAtencion;
        }

        public int getLegajoAtencion()
        {
            return Legajo_Horario;
        }

        public void setLegajoAtencion(int legajoAtencion)
        {
            Legajo_Horario = legajoAtencion;
        }

        public string getHoraFin()
        {
            return HoraFin;
        }
        public void setHoraFin(string hora)
        {
            HoraFin = hora;
        }
        public string getHoraInicio()
        {
            return HoraInicio;
        }
        public void setHoraInicio(string hora)
        {
            HoraInicio = hora;
        }
        public int getDiaAtencion()
        {
            return DiasAtencion;
        }
        public void setDiaAtencion(int dia)
        {
            DiasAtencion = dia;
        }
        public string getTipoUsuario()
        {
            return Tipo_Usuario;
        }
        public void setTipoUsuario(string tipo)
        {
            Tipo_Usuario = tipo;
        }
        public string getContraseña()
        {
            return Contraseña;
        }
        public void setContraseña(string password)
        {
            Contraseña = password;
        }
        public string getNombre_Usuario()
        {
            return Nombre_Usuario;
        }
        public void setNombre_Usuario(string nombre)
        {
            Nombre_Usuario = nombre;
        }

        public string getNombre_Usuario_Nuevo()
        {
            return Nombre_Usuario_Nuevo;
        }

        public void setNombre_Usuario_Nuevo(string nombre)
        {
            Nombre_Usuario_Nuevo = nombre;
        }
        public int getLegajo()
        {
            return Legajo;
        }

        public void setLegajo(int legajo)
        {
            Legajo = legajo;
        }

        public int getId_Usuario()
        {
            return Id_Usuario;
        }

        public void setId_Usuario(int idUsuario)
        {
            Id_Usuario = idUsuario;
        }

        public int getId_Especialidad()
        {
            return Id_Especialidad;
        }

        public void setId_Especialidad(int idEspecialidad)
        {
            Id_Especialidad = idEspecialidad;
        }

        public int getId_Localidad()
        {
            return Id_Localidad;
        }

        public void setId_Localidad(int idLocalidad)
        {
            Id_Localidad = idLocalidad;
        }

        public string getDNI()
        {
            return DNI;
        }

        public void setDNI(string dni)
        {
            DNI = dni;
        }

        public string getNombre()
        {
            return Nombre;
        }

        public void setNombre(string nombre)
        {
            Nombre = nombre;
        }

        public string getApellido()
        {
            return Apellido;
        }

        public void setApellido(string apellido)
        {
            Apellido = apellido;
        }

        public string getSexo()
        {
            return Sexo;
        }

        public void setSexo(string sexo)
        {
            Sexo = sexo;
        }

        public string getNacionalidad()
        {
            return Nacionalidad;
        }

        public void setNacionalidad(string nacionalidad)
        {
            Nacionalidad = nacionalidad;
        }

        public string getFecha_Nacimiento()
        {
            return Fecha_Nacimiento;
        }

        public void setFecha_Nacimiento(string fechaNacimiento)
        {
            Fecha_Nacimiento = fechaNacimiento;
        }

        public string getDireccion()
        {
            return Direccion;
        }

        public void setDireccion(string direccion)
        {
            Direccion = direccion;
        }

        public string getEmail()
        {
            return Email;
        }

        public void setEmail(string email)
        {
            Email = email;
        }

        public string getTelefono()
        {
            return Telefono;
        }

        public void setTelefono(string telefono)
        {
            Telefono = telefono;
        }

    }
}
