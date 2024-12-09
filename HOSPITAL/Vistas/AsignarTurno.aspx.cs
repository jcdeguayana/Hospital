using Entidades;
using Negocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Vistas
{
    public partial class AsignarTurno : System.Web.UI.Page
    {
        NegocioMedico medico = new NegocioMedico();
        NegocioPaciente paciente = new NegocioPaciente();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["Usuario"] != null)
                {
                    lblUsuario.Text = "Usuario: " + Session["Usuario"].ToString();

                    ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
                    CargarEspecialidades();
                    CargarPacientes();
                    ddlPacientes.Items.Insert(0, new ListItem("-- Seleccionar un Paciente --", "0"));
                    ddlEspecialidad.Items.Insert(0, new ListItem("-- Seleccionar una Especialidad --", "0"));
                    ddlMedico.Items.Insert(0, new ListItem("-- Seleccionar un Medico --", "0"));
                    ddlDiasAtencion.Items.Insert(0, new ListItem("-- Seleccionar un dia --", "0"));
                    ddlHorario.Items.Insert(0, new ListItem("-- Seleccionar una hora --", "0"));
                }
                else
                {
                    Response.Redirect("Login.aspx");
                }
            }
        }

        protected void lnkMenuPrincipal_Click(object sender, EventArgs e)
        {
            if (Session["Usuario"] != null && Session["TipoUsuario"] != null)
            {
                string tipoUsuario = Session["TipoUsuario"].ToString();

                if (tipoUsuario == "Administrador")
                {
                    Response.Redirect("MainPage.aspx");
                }
                else if (tipoUsuario == "Medico")
                {
                    Response.Redirect("MainPageMedico.aspx");
                }
            }
            else
            {
                Response.Redirect("Login.aspx");
            }
        }

        protected void lnkCerrarSesion_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Session.Abandon();
            Response.Redirect("Login.aspx");
        }

        public void CargarPacientes()
        {
            SqlDataReader pacientes = paciente.obtenerPacientes();
            ddlPacientes.DataSource = pacientes;
            ddlPacientes.DataTextField = "DNI_PACIENTE";
            ddlPacientes.DataBind();
        }

        public void Dias()
        {
            SqlDataReader dias = paciente.Dias();
            ddlDiasAtencion.DataSource = dias;
            ddlDiasAtencion.DataTextField = "DIA_HA";
            ddlDiasAtencion.DataBind();
        }

        public void Horas()
        {
            SqlDataReader horas = paciente.Horas();
            ddlHorario.DataSource = horas;
            ddlHorario.DataTextField = "HORA_HA";
            ddlHorario.DataBind();
        }

        public void CargarEspecialidades()
        {
            SqlDataReader especialidades = medico.obtenerEspecialidades();
            ddlEspecialidad.DataSource = especialidades;
            ddlEspecialidad.DataTextField = "NOMBRE_E";
            ddlEspecialidad.DataValueField = "ID_ESPECIALIDAD_E";
            ddlEspecialidad.DataBind();
        }

        public void CargarMedicos()
        {
            int idEspecialidad = int.Parse(ddlEspecialidad.SelectedValue);
            SqlDataReader Medicos = paciente.obtenerMedicos(idEspecialidad);
            ddlMedico.DataSource = Medicos;
            ddlMedico.DataTextField = "LEGAJO_MEDICO";
            ddlMedico.DataValueField = "LEGAJO_MEDICO";
            ddlMedico.DataBind();
        }

        public void CargarDias()
        {
            int legajo = int.Parse(ddlMedico.SelectedValue);
            SqlDataReader Dias = paciente.obtenerDias(legajo);
            ddlDiasAtencion.DataSource = Dias;
            ddlDiasAtencion.DataTextField = "DIA_HA";
            ddlDiasAtencion.DataValueField = "DIA_HA";
            ddlDiasAtencion.DataBind();
        }

        public void CargarHoras()
        {
            string dia = ddlDiasAtencion.SelectedValue;
            SqlDataReader horas = paciente.obtenerHoras(dia);
            ddlHorario.DataSource = horas;
            ddlHorario.DataTextField = "HORA_HA";
            ddlHorario.DataValueField = "HORA_HA";
            ddlHorario.DataBind();
        }

        protected void ddlEspecialidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlMedico.Items.Clear();
            CargarMedicos();
            ddlDiasAtencion.Items.Clear();
            ddlHorario.Items.Clear();
        }

        protected void ddlMedico_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlDiasAtencion.Items.Clear();
            CargarDias();
            ddlHorario.Items.Clear();
        }

        protected void btnAsignar_Click(object sender, EventArgs e)
        {
            NegocioTurno neg = new NegocioTurno();
            Turnos tur = new Turnos();

            if (neg.AgregarTurno(txtCodigo.Text, ddlPacientes.SelectedValue, Convert.ToInt32(ddlMedico.SelectedValue), Convert.ToString(ddlDiasAtencion.SelectedValue), ddlHorario.SelectedValue, ddlEspecialidad.SelectedValue))
            {
                Label1.Text = "Turno agregado con éxito";
                Label1.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                Label1.Text = "No se pudo agregar el turno";
                Label1.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void ddlDiasAtencion_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlHorario.Items.Clear();
            CargarHoras();
        }
    }
}