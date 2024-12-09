using Negocio;
using System;
using System.Data;
using System.Web.UI.WebControls;

namespace Vistas
{
    public partial class ListadoMedicos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["Usuario"] != null)
                {
                    lblUsuario.Text = "Usuario: " + Session["Usuario"].ToString();
                    MostrarMedicos();
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

        protected void btnFiltrar_Click1(object sender, EventArgs e)
        {
            NegocioMedico med = new NegocioMedico();
            string dni = txtDNI.Text;
            string user = txtUsuario.Text;
            if(string.IsNullOrEmpty(dni) && string.IsNullOrEmpty(user))
            {
                MostrarMedicos();
            }
            else
            {
                DataTable filtro = new DataTable();
                filtro = med.BusquedaMedico(dni, user);
                grdMedicos.DataSource = filtro;
                grdMedicos.DataBind();
                txtDNI.Text = "";
                txtUsuario.Text = "";
            }
        }
            

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string id_int = ((Label)grdMedicos.Rows[e.RowIndex].FindControl("lblId")).Text;
            string legajo_int = ((Label)grdMedicos.Rows[e.RowIndex].FindControl("lblLegajo")).Text;
            int legajo = Convert.ToInt32(legajo_int);
            int id_Usuario = Convert.ToInt32(id_int);

            NegocioMedico med = new NegocioMedico();
            med.EliminarHorarios(legajo);
            med.EliminarMedico(id_Usuario);
            MostrarMedicos();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            NegocioMedico medico = new NegocioMedico();
            int legajo = Convert.ToInt32(((Label)grdMedicos.Rows[e.RowIndex].FindControl("lblLegajo")).Text);
            string dni = ((TextBox)grdMedicos.Rows[e.RowIndex].FindControl("txtDNIed")).Text;
            string nombre = ((TextBox)grdMedicos.Rows[e.RowIndex].FindControl("txtNombreEd")).Text;
            string apellido = ((TextBox)grdMedicos.Rows[e.RowIndex].FindControl("txtApe")).Text;
            string fecha = ((TextBox)grdMedicos.Rows[e.RowIndex].FindControl("txtFecha")).Text;
            string direccion = ((TextBox)grdMedicos.Rows[e.RowIndex].FindControl("txtDireccion")).Text;
            string email = ((TextBox)grdMedicos.Rows[e.RowIndex].FindControl("txtMail")).Text;
            string telefono = ((TextBox)grdMedicos.Rows[e.RowIndex].FindControl("txtTelefono")).Text;
            int especialidad = Convert.ToInt32(((DropDownList)grdMedicos.Rows[e.RowIndex].FindControl("ddlEspecialidad")).SelectedValue);
            medico.ActualizarMed(legajo, especialidad, dni, nombre, apellido, fecha, direccion, email, telefono);

            grdMedicos.EditIndex = -1;
            MostrarMedicos();
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grdMedicos.EditIndex = e.NewEditIndex;
            MostrarMedicos();
        }

        protected void grdMedicos_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            grdMedicos.EditIndex = -1;
            MostrarMedicos();
        }

        public void MostrarMedicos()
        {
            NegocioMedico med = new NegocioMedico();
            DataTable dt = new DataTable();
            dt = med.ListadoMedicos();
            grdMedicos.DataSource = dt;
            grdMedicos.DataBind();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
    }
}