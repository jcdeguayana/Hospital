using Negocio;
using System;
using System.Data;
using System.Web.UI.WebControls;

namespace Vistas
{
    public partial class ListadoTurnos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["Usuario"] != null)
                {
                    lblUsuario.Text = "Usuario: " + Session["Usuario"].ToString();
                    MostrarTurnos();
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

        public void MostrarTurnos()
        {
            NegocioTurno turno = new NegocioTurno();
            DataTable dt = new DataTable();
            dt = turno.ListarTurnos();
            grdTurnos.DataSource = dt;
            grdTurnos.DataBind();
        }

        protected void btnAus_Click(object sender, EventArgs e)
        {
            NegocioTurno turno = new NegocioTurno();
            double promedio = turno.Ausencias();
            lblAusentes.Text = $"Promedio de ausentes: {promedio:P2}";
        }

        protected void btnPres_Click(object sender, EventArgs e)
        {
            NegocioTurno turno = new NegocioTurno();
            double promedio = turno.Presentes();
            lblAusentes.Text = $"Promedio de presentes: {promedio:P2}";
        }

        protected void btnFiltrar_Click(object sender, EventArgs e)
        {
            NegocioTurno turno = new NegocioTurno();
            string dni = txtDNI.Text;
            string legajo = txtLegajo.Text;
            if (string.IsNullOrEmpty(dni) && string.IsNullOrEmpty(legajo))
            {
                MostrarTurnos();
            }
            else
            {
                DataTable filtro = new DataTable();
                filtro = turno.BusquedaTurnos(legajo, dni);
                grdTurnos.DataSource = filtro;
                grdTurnos.DataBind();
                txtDNI.Text = "";
                txtLegajo.Text = "";
            }
        
        }

        protected void grdTurnos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdTurnos.PageIndex = e.NewPageIndex;
            MostrarTurnos();
        }
    }
}