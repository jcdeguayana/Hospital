using Negocio;
using System;
using System.Web.UI.WebControls;
namespace Vistas
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Label1.Text = "";
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
            }
        }

        protected void btnLogin_Click1(object sender, EventArgs e)
        {
            NegocioMedico medico = new NegocioMedico();
            string Usuario = medico.Login(txtUsername.Text, txtPassword.Text);
            if (Usuario == "Administrador")
            {
                Session["Usuario"] = txtUsername.Text;
                Session["TipoUsuario"] = "Administrador";
                Response.Redirect("MainPage.aspx");
            }
            else if (Usuario == "Medico")
            {
                Session["Usuario"] = txtUsername.Text;
                Session["TipoUsuario"] = "Medico";
                int legajo = medico.ObtenerLegajoUsuarioMedico(txtUsername.Text, txtPassword.Text);
                Session["LegajoMedico"] = legajo;
                Response.Redirect("MainPageMedico.aspx");
            }
            else
            {
                Label1.Text = "Usuario o Contraseña incorrectos";
                Label1.ForeColor = System.Drawing.Color.Red;
                Label1.CssClass = "error-message";
            }
        }

        protected void lnkCerrarSesion_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Session.Abandon();
            Response.Redirect("Login.aspx");
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
    }
}