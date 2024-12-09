using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Turnos
    {
        private string CodigoTurno;
        private string DNIPaciente;
        private int LegajoMedico;
        private string Dia;
        private string Hora;
        private string Especialidad;
        private string Estado;
        private string Observacion;
        public string getObservacion()
        {
            return Observacion;
        }
        public void setObservacion(string observacion)
        {
            Observacion = observacion;
        }


        public string getCodigoTurno()
        {
            return CodigoTurno;
        }

        public void setCodigoTurno(string Codigo)
        {
            CodigoTurno = Codigo;
        }

        public string getDNIPaciente()
        {
            return DNIPaciente;
        }

        public void setDNIPaciente(string DNI)
        {
            DNIPaciente = DNI;
        }

        public int getLegajo()
        {
            return LegajoMedico;
        }

        public void setLegajo(int legajo)
        {
            LegajoMedico = legajo;
        }

        public string getDia()
        {
            return Dia;
        }

        public void setDia(string dia)
        {
            Dia = dia;
        }

        public string getHora()
        {
            return Hora;
        }

        public void setHora(string hora)
        {
            Hora = hora;
        }

        public string getEspecialidad()
        {
            return Especialidad;
        }

        public void setEspecialidad(string especialidad)
        {
            Especialidad = especialidad;
        }


        public string getEstado()
        {
            return Estado;
        }

        public void setEstado(string estado)
        {
            Estado = estado;
        }
    }
}
