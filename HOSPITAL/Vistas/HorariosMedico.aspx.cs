using Negocio;
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Vistas
{
    public partial class HorariosMedico : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["Usuario"] != null)
                {
                    lblUsuario.Text = "Usuario: " + Session["Usuario"].ToString();
                    cargarDdl();
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

        private void cargarDdl()
        {
            NegocioMedico neo = new NegocioMedico();
            DataTable dt = new DataTable();
            dt = neo.CargarLegajos();
            ddlLegajo.DataSource = dt;
            ddlLegajo.DataTextField = "LEGAJO_MEDICO";
            ddlLegajo.DataBind();
        }

        protected void btnFiltrar_Click(object sender, EventArgs e)
        {
            NegocioMedico neo = new NegocioMedico();
            int Legajo = Convert.ToInt32(ddlLegajo.SelectedItem.Text);
            string dia = ddlDia.SelectedItem.Text;
            string hora = ddlHorarios.SelectedItem.Text;
            int existen = neo.VerificarExistenciaHoraria(Legajo, dia, hora);
            if (existen > 0)
            {
                lblAviso.Text = "Ya existe este horario para el médico.";
                lblAviso.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                neo.AgregarHorario(Legajo, dia, hora);
                lblAviso.Text = "Datos ingresados correctamente.";
                lblAviso.ForeColor = System.Drawing.Color.Green;
            }
        }
    }
}