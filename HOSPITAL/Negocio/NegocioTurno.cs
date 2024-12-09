using Entidades;
using Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Negocio
{
    public class NegocioTurno
    {
        public bool AgregarTurno(string CodigoTurno,string DNIPaciente,int LegajoMedico,string Dia,string Hora,string Especialidad)
        {
            int CantFilasTurnos = 0;
            Turnos tur = new Turnos();
            DaoTurno turno = new DaoTurno();
            tur.setCodigoTurno(CodigoTurno);
            tur.setDNIPaciente(DNIPaciente);
            tur.setLegajo(LegajoMedico);
            tur.setDia(Dia);
            tur.setHora(Hora);
            tur.setEspecialidad(Especialidad);

            if (turno.existeTurno(tur) == false)
            {
                CantFilasTurnos = turno.agregarTurno(tur);
                ActualizarHORARIO(LegajoMedico,Dia,Hora);
            }
            if (CantFilasTurnos == 1)
                return true;
            else
                return false;
            
        }
        public void ActualizarEstadoTurnos(string estado, string observaciones, int Legajo, string dia, string hora, string dni)
        {
            Turnos tur = new Turnos();
            DaoTurno turno = new DaoTurno();

            tur.setEstado(estado);
            tur.setObservacion(observaciones);
            tur.setLegajo(Legajo);
            tur.setDia(dia);
            tur.setHora(hora);
            tur.setDNIPaciente(dni);

            turno.ActualizarEstadoTurno(tur);

        }

        public DataTable BusquedaTurnos(string legajoMed, string dni)
        {
            DaoTurno tur = new DaoTurno();
            return tur.BusquedaTurnos(legajoMed, dni);
        }
        public DataTable FiltroPorDNI(int legajoMed, string dni)
        {
            DaoTurno tur = new DaoTurno();
            return tur.FiltroPorDNiPaciente(legajoMed, dni);
        }
        public void ActualizarMisHorarios(int Legajo, string dia, string hora)
        {
            Turnos tur = new Turnos();
            DaoTurno turno = new DaoTurno();

            tur.setLegajo(Legajo);
            tur.setDia(dia);
            tur.setHora(hora);

            turno.ActualizarMisTurnos(tur);

        }

        public void ActualizarHORARIO(int Legajo, string Dia, string Hora)
        {
            Turnos tur = new Turnos();
            DaoTurno turno = new DaoTurno();
            tur.setLegajo(Legajo);
            tur.setDia(Dia);
            tur.setHora(Hora);

            turno.ActualizarHorario(tur);
        }

        //public int VerificarExistenciaTurno(int legajo, string dia, string hora)
        //{
        //    DaoTurno dao = new DaoTurno();
        //    return dao.ExisteTurno(legajo, dia, hora);
        //}
        public DataTable ListarTurnos()
        {
            DaoTurno dao = new DaoTurno();
            return dao.ListarTurnos();
        }

        public double Ausencias()
        {
            DaoTurno dao = new DaoTurno();
            return dao.Ausencias();
        }

        public double Presentes()
        {
            DaoTurno dao = new DaoTurno();
            return dao.Presentes();
        }
    }
}
