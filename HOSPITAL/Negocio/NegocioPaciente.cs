using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Dao;
using Entidades;

namespace Negocio
{
    public class NegocioPaciente
    {
        public NegocioPaciente() { }

        private DaoPaciente paci = new DaoPaciente();
        private Paciente paciente = new Paciente();

        public SqlDataReader obtenerPacientes()
        {
            return paci.obtenerPacientes();
        }

        public SqlDataReader Dias()
        {
            return paci.Dias();
        }

        public SqlDataReader Horas()
        {
            return paci.Horas();
        }

        public SqlDataReader obtenerMedicos(int IdEspecialidad)
        {
            return paci.obtenerMedicos(IdEspecialidad);
        }

        public SqlDataReader obtenerDias(int legajo)
        {
            return paci.obtenerDias(legajo);
        }

        public SqlDataReader obtenerHoras(string dia)
        {
            return paci.obtenerHoras(dia);
        }

        public bool AgregarPaciente(string dni, string nombre, string apellido, string sexo, string nacionalidad, string fecha, string direccion, int IdLocalidad, string email, string telefono)
        {
            int cantFilasPaciente = 0;
            paciente.setdni(dni);
            paciente.setnombre(nombre);
            paciente.setapellido(apellido);
            paciente.setsexo(sexo);
            paciente.setnacionalidad(nacionalidad);
            paciente.setfecha_nacimiento(fecha);
            paciente.setdireccion(direccion);
            paciente.setId_localidad(IdLocalidad + 1);
            paciente.setcorreo(email);
            paciente.settelefono(telefono);

            // Verificar si el paciente ya existe
            if (paci.existePaciente(paciente) == false)
            {
                // Agregar  paciente
                cantFilasPaciente = paci.AgregarPaciente(paciente);
            }

            // Si tanto el usuario como el paciente fueron agregados exitosamente, devolver true
            if (cantFilasPaciente == 1)
                return true;
            else
                return false;
        }
        public void ActualizarPaciente(string dni, string nombre, string apellido, string sexo, string nacionalidad, string fecha, string direccion, int IdLocalidad, string email, string telefono)
        {
            DaoPaciente paciente = new DaoPaciente();
            Paciente paci = new Paciente();
            {
                paci.setdni(dni);
                paci.setnombre(nombre);
                paci.setapellido(apellido);
                paci.setsexo(sexo);
                paci.setprovincia(nacionalidad);
                paci.setfecha_nacimiento(fecha);
                paci.setdireccion(direccion);
                paci.setId_localidad(IdLocalidad);
                paci.setcorreo(email);
                paci.settelefono(telefono);

                paciente.ActualizarPaciente(paci);
            }
        }

        public bool EliminarPaciente(string dni)
        {
            int cantFilasPaciente = 0;
            int cantFilasTurnos = 0;
            DaoPaciente dao = new DaoPaciente();

            cantFilasTurnos = dao.EliminarTurnoPaciente(dni);
            cantFilasPaciente = dao.EliminarPaciente(dni);

            if (cantFilasTurnos == 1 && cantFilasPaciente == 1)
                return true;
            else
                return false;
        }

        public DataTable buscarPaciente(string dni)
        {
            DaoPaciente dao = new DaoPaciente();
            return dao.FiltrarPaciente(dni);
        }

        public DataTable listarPacientes()
        {
            DaoPaciente dao = new DaoPaciente();
            return dao.ListarPacientes();
        }

        
    }
}