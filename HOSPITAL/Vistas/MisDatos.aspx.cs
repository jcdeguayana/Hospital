using Negocio;
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Vistas
{
    public partial class MisDatos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["Usuario"] != null)
                {
                    ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
                    lblUsuario.Text = "Usuario: " + Session["Usuario"].ToString();
                    string Usuario = Session["Usuario"].ToString();
                    CargarDatos(Usuario);
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

        public void CargarDatos(string Usuario)
        {
            NegocioMedico neg = new NegocioMedico();
            DataTable dt = new DataTable();
            dt = neg.DatosMedico(Usuario);
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
        }

        protected void btnModificar_Click1(object sender, EventArgs e)
        {
        }

        protected void btnModificar_Click2(object sender, EventArgs e)
        {
            NegocioMedico medico = new NegocioMedico();
            string UsuarioNuevo = txtNuevoUsuario.Text;
            string ContraseñaNueva = txtNuevaContrasena.Text;
            string Usuario_Actual = Session["Usuario"].ToString();

            if (medico.ActualizarUsuario(Usuario_Actual, UsuarioNuevo, ContraseñaNueva))
            {
                Label1.Text = "Usuario modificado con éxito";
                Label1.ForeColor = System.Drawing.Color.Green;
                Session["Usuario"] = UsuarioNuevo; // Actualizar la sesión con el nuevo usuario
                lblUsuario.Text = "Usuario: " + UsuarioNuevo; // Actualizar el label con el nuevo usuario
            }
            else
            {
                Label1.Text = "No se pudo modificar el usuario";
                Label1.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}