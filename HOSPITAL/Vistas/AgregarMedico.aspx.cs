using Negocio;
using Entidades;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using System.Web.UI;

namespace Vistas
{
    public partial class AgregarMedico : System.Web.UI.Page
    {
        NegocioMedico medico = new NegocioMedico();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["Usuario"] != null)
                {
                    lblUsuario.Text = "Usuario: " + Session["Usuario"].ToString();

                    ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
                    txtTipoUsuario.Text = "Medico";

                    CargarProvincias();
                    CargarEspecialidades();

                    ddlProvincia.Items.Insert(0, new ListItem("-Seleccione-", "0"));
                    ddlLocalidad.Items.Insert(0, new ListItem("-Seleccione-", "0"));
                    ddlSexo.Items.Insert(0, new ListItem("Hombre", "0"));
                    ddlSexo.Items.Insert(1, new ListItem("Mujer", "1"));
                    ddlNacionalidad.Items.Insert(0, new ListItem("Argentina", "0"));
                    ddlNacionalidad.Items.Insert(1, new ListItem("Venezuela", "1"));
                    ddlNacionalidad.Items.Insert(2, new ListItem("Brasil", "2"));
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
            string nombre = txtUsername.Text;
            lblUsuario.Text = $"Usuario agregado: {nombre}";
        }

        protected void ddlProvincia_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarLocalidades();
        }

        public void CargarLocalidades()
        {
            int idProvincia = int.Parse(ddlProvincia.SelectedValue);
            SqlDataReader localidades = medico.obtenerLocalidades(idProvincia);
            ddlLocalidad.DataSource = localidades;
            ddlLocalidad.DataTextField = "NOMBRE_LOCALIDAD";
            ddlLocalidad.DataValueField = "ID_LOCALIDAD";
            ddlLocalidad.DataBind();
        }

        public void CargarProvincias()
        {
            SqlDataReader provincias = medico.obtenerProvincias();
            ddlProvincia.DataSource = provincias;
            ddlProvincia.DataTextField = "NOMBRE_PROVINCIA";
            ddlProvincia.DataValueField = "ID_PROVINCIA";
            ddlProvincia.DataBind();
        }

        public void CargarEspecialidades()
        {
            SqlDataReader especialidades = medico.obtenerEspecialidades();
            ddlEspecialidad.DataSource = especialidades;
            ddlEspecialidad.DataTextField = "NOMBRE_E";
            ddlEspecialidad.DataValueField = "ID_ESPECIALIDAD_E";
            ddlEspecialidad.DataBind();
        }

        protected void btnAgregar_Click1(object sender, EventArgs e)
        {
            NegocioMedico neg = new NegocioMedico();
            Medico med = new Medico();

            if (neg.AgregarMedico(Convert.ToInt32(txtID.Text), txtUsername.Text, txtTipoUsuario.Text, txtPassword.Text, Convert.ToInt32(txtLegajo.Text), txtDNI.Text, txtNombre.Text, txtApellido.Text, Convert.ToString(ddlSexo.SelectedValue), Convert.ToString(ddlNacionalidad.SelectedValue), txtFechaNacimiento.Text, txtDireccion.Text, Convert.ToInt32(ddlLocalidad.SelectedValue), txtEmail.Text, txtTelefono.Text, Convert.ToInt32(ddlEspecialidad.SelectedValue)))
            {
                vaciarTxt();

                lblMensaje.Text = "Medico agregado con éxito";
                lblMensaje.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                lblMensaje.Text = "No se pudo agregar el médico";
                lblMensaje.ForeColor = System.Drawing.Color.Red;
            }
        }


        protected void ddlLocalidad_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        protected void txtDNI_TextChanged(object sender, EventArgs e)
        {
        }
        public void vaciarTxt()
        {
            txtUsername.Text = "";
            txtTipoUsuario.Text = "";
            txtPassword.Text = "";
            txtDNI.Text = "";
            txtEmail.Text = "";
            txtTelefono.Text = "";
            txtID.Text = "";
            txtConfirmPassword.Text = "";
            txtDireccion.Text = "";
            txtApellido.Text = "";
            txtFechaNacimiento.Text = "";
            txtNombre.Text = "";
            txtLegajo.Text = "";
        }
    }
}