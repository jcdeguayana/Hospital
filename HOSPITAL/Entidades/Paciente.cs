using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Paciente
    {
        public Paciente() { }


        private string dni;
        private string nombre;
        private string apellido;
        private string sexo;
        private string nacionalidad;
        private string fecha_nacimiento;
        private string direccion;
        private int Id_localidad;
        private string provincia;
        private string correo;
        private string telefono;

        public string getdni()
        {
            return dni;
        }
        public void setdni(string _dni)
        {
            dni = _dni;
        }
        public string getnombre()
        {
            return nombre;
        }
        public void setnombre(string nom)
        {
            nombre = nom;
        }
        public string getapellido()
        {
            return apellido;
        }
        public void setapellido(string ape)
        {
            apellido = ape;
        }
        public string getsexo()
        {
            return sexo;
        }
        public void setsexo(string sex)
        {
            sexo = sex;
        }
        public string getnacionalidad()
        {
            return nacionalidad;
        }
        public void setnacionalidad(string nacion)
        {
            nacionalidad = nacion;
        }
        public string getfecha_nacimiento()
        {
            return fecha_nacimiento;
        }
        public void setfecha_nacimiento(string naci)
        {
            fecha_nacimiento = naci;
        }
        public string getdireccion()
        {
            return direccion;
        }

        public void setdireccion(string dire)
        {
            direccion = dire;
        }

        public int getId_localidad()
        {
            return Id_localidad;
        }

        public void setId_localidad(int idlocal)
        {
            Id_localidad = idlocal;
        }

        public string getprovincia()
        {
            return provincia;
        }

        public void setprovincia(string provin)
        {
            provincia = provin;
        }

        public string getcorreo()
        {
            return correo;
        }

        public void setcorreo(string email)
        {
            correo = email;
        }

        public string gettelefono()
        {
            return telefono;
        }

        public void settelefono(string numero)
        {
            telefono = numero;
        }
    }
}
