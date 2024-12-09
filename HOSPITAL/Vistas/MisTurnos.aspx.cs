using Negocio;
using System;
using System.Data;
using System.Drawing;
using System.Web.UI.WebControls;

namespace Vistas
{
    public partial class MisTurnos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                if (Session["Usuario"] != null && Session["LegajoMedico"] != null)
                {
                    lblUsuario.Text = "Usuario: " + Session["Usuario"].ToString();
                    int legajo = Convert.ToInt32(Session["LegajoMedico"]);
                    cargarMisTurnos(legajo);
                }
                else
                {
                    Response.Redirect("Login.aspx");
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

        public void cargarMisTurnos(int legajo)
        {
            NegocioMedico nego = new NegocioMedico();
            DataTable dt = new DataTable();
            dt = nego.MisTurnos(legajo);
            grdMisTurnos.DataSource = dt;
            grdMisTurnos.DataBind();
        }

        protected void grdMisTurnos_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            NegocioTurno negoTur = new NegocioTurno();
            string estado = ((DropDownList)grdMisTurnos.Rows[e.RowIndex].FindControl("ddlPresencia")).SelectedItem.Text;
            string observacion = ((TextBox)grdMisTurnos.Rows[e.RowIndex].FindControl("txtObservacion")).Text;
            string legajo = ((Label)grdMisTurnos.Rows[e.RowIndex].FindControl("lblLegajo_eit")).Text;
            string dia = ((Label)grdMisTurnos.Rows[e.RowIndex].FindControl("lblDia_eit")).Text;
            string hora = ((Label)grdMisTurnos.Rows[e.RowIndex].FindControl("lblHora_eit")).Text;
            string dni = ((Label)grdMisTurnos.Rows[e.RowIndex].FindControl("lblDni_eit")).Text;
            int legajoMed = Convert.ToInt32(legajo);
            negoTur.ActualizarEstadoTurnos(estado, observacion, legajoMed, dia, hora, dni);
            if (estado == "Presente" || estado == "Ausente")
            {
                negoTur.ActualizarMisHorarios(legajoMed, dia, hora);
            }
            grdMisTurnos.EditIndex = -1;
            cargarMisTurnos(legajoMed);
        }

        protected void grdMisTurnos_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grdMisTurnos.EditIndex = e.NewEditIndex;
            int legajo = Convert.ToInt32(Session["LegajoMedico"]);
            cargarMisTurnos(legajo);
        }

        protected void grdMisTurnos_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            grdMisTurnos.EditIndex = -1;
            int legajo = Convert.ToInt32(Session["LegajoMedico"]);
            cargarMisTurnos(legajo);
        }

        protected void btnFiltrar_Click(object sender, EventArgs e)
        {
            NegocioTurno neo = new NegocioTurno();
            int legajo = Convert.ToInt32(Session["LegajoMedico"]);
            string dni = txtFiltro.Text;
            if (!string.IsNullOrEmpty(dni))
            {
                DataTable dt = new DataTable();
                dt = neo.FiltroPorDNI(legajo, dni);
                grdMisTurnos.DataSource = dt;
                grdMisTurnos.DataBind();
            }
            else
            {
                cargarMisTurnos(legajo);
            }

        }

        protected void grdMisTurnos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdMisTurnos.PageIndex = e.NewPageIndex;
            int legajo = Convert.ToInt32(Session["LegajoMedico"]);
            cargarMisTurnos(legajo);
        }
    }
}