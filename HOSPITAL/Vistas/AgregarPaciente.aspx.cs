using Negocio;
using Entidades;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using System.Web.UI;

namespace Vistas
{
    public partial class AgregarPaciente : System.Web.UI.Page
    {
        NegocioPaciente paciente = new NegocioPaciente();
        NegocioMedico med = new NegocioMedico();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                if (Session["Usuario"] != null)
                {
                    lblUsuario.Text = "Usuario: " + Session["Usuario"].ToString();
                    ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
                    CargarProvincias();
                    ddlProvincia.Items.Insert(0, new ListItem("-seleccione-", "0"));
                    ddlLocalidad.Items.Insert(0, new ListItem("-seleccione-", "0"));
                    ddlSexo.Items.Insert(0, new ListItem("Hombre", "0"));
                    ddlSexo.Items.Insert(1, new ListItem("Mujer", "1"));
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

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text;
            lblUsuario.Text = $"Usuario agregado: {nombre}";
        }

        protected void ddlProvincia_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarLocalidades();
        }

        public void CargarLocalidades()
        {
            int idProvincia = int.Parse(ddlProvincia.SelectedValue);
            SqlDataReader localidades = med.obtenerLocalidades(idProvincia);
            ddlLocalidad.DataSource = localidades;
            ddlLocalidad.DataTextField = "NOMBRE_LOCALIDAD";
            ddlLocalidad.DataValueField = "ID_LOCALIDAD";
            ddlLocalidad.DataBind();
        }

        public void CargarProvincias()
        {
            SqlDataReader provincias = med.obtenerProvincias();
            ddlProvincia.DataSource = provincias;
            ddlProvincia.DataTextField = "NOMBRE_PROVINCIA";
            ddlProvincia.DataValueField = "ID_PROVINCIA";
            ddlProvincia.DataBind();
        }

        protected void ddlProvincia_SelectedIndexChanged1(object sender, EventArgs e)
        {
            CargarLocalidades();
        }

        protected void btnAgregar_Click2(object sender, EventArgs e)
        {
            NegocioPaciente paciente = new NegocioPaciente();
            Paciente paci = new Paciente();
            if (paciente.AgregarPaciente(txtDNI.Text, txtNombre.Text, txtApellido.Text, Convert.ToString(ddlSexo.SelectedItem), Convert.ToString(ddlProvincia.SelectedItem), txtFechaNacimiento.Text, txtDireccion.Text, Convert.ToInt32(ddlLocalidad.SelectedValue), txtCorreoElectronico.Text, txtTelefono.Text))
            {
                limpiarTxt();
                lblMensaje.Text = "Paciente agregado correctamente";
                lblMensaje.ForeColor = System.Drawing.Color.Green;

            }
            else
            {
                lblMensaje.Text = "No se pudo agregar al paciente";
                lblMensaje.ForeColor = System.Drawing.Color.Red;
            }
        }




        public void limpiarTxt()
        {
            txtApellido.Text = "";
            txtNombre.Text = "";
            txtDireccion.Text = "";
            txtDNI.Text = "";
            txtFechaNacimiento.Text = "";
            txtCorreoElectronico.Text = "";
            txtTelefono.Text = "";
        }
    }
}