using Negocio;
using System;
using System.Data;
using System.Web.UI.WebControls;

namespace Vistas
{
    public partial class ListadoPacientes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["Usuario"] != null)
                {
                    lblUsuario.Text = "Usuario: " + Session["Usuario"].ToString();
                    MostrarPacientes();
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

        protected void btnFiltrar_Click(object sender, EventArgs e)
        {
            NegocioPaciente paci = new NegocioPaciente();
            string dni = txtDNI.Text;
            if (string.IsNullOrEmpty(dni))
            {
                MostrarPacientes();
            }
            else
            {
                DataTable filtro = new DataTable();
                filtro = paci.buscarPaciente(dni);
                grdPacientes.DataSource = filtro;
                grdPacientes.DataBind();
                txtDNI.Text = "";
            }           
        }

        protected void grdPacientes_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string dni = ((Label)grdPacientes.Rows[e.RowIndex].FindControl("lbl_it_dni")).Text;
            NegocioPaciente paci = new NegocioPaciente();
            paci.EliminarPaciente(dni);
            MostrarPacientes();
        }

        public void MostrarPacientes()
        {
            NegocioPaciente paci = new NegocioPaciente();
            DataTable dt = new DataTable();
            dt = paci.listarPacientes();
            grdPacientes.DataSource = dt;
            grdPacientes.DataBind();
        }

        protected void grdPacientes_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            NegocioPaciente paci = new NegocioPaciente();
            string dni = ((TextBox)grdPacientes.Rows[e.RowIndex].FindControl("txt_ed_dni")).Text;
            string nombre = ((TextBox)grdPacientes.Rows[e.RowIndex].FindControl("txt_ed_nom")).Text;
            string apellido = ((TextBox)grdPacientes.Rows[e.RowIndex].FindControl("txt_ed_ape")).Text;
            string sexo = Convert.ToString(((DropDownList)grdPacientes.Rows[e.RowIndex].FindControl("ddlSexo")).SelectedItem);
            string nacionalidad = Convert.ToString(((DropDownList)grdPacientes.Rows[e.RowIndex].FindControl("ddlProvincia")).SelectedItem);
            string fecha = ((TextBox)grdPacientes.Rows[e.RowIndex].FindControl("txt_ed_fecha")).Text;
            string direccion = ((TextBox)grdPacientes.Rows[e.RowIndex].FindControl("txt_ed_dire")).Text;
            int localidad = Convert.ToInt32(((DropDownList)grdPacientes.Rows[e.RowIndex].FindControl("ddlLocalidad")).SelectedValue);
            string email = ((TextBox)grdPacientes.Rows[e.RowIndex].FindControl("txt_ed_correo")).Text;
            string telefono = ((TextBox)grdPacientes.Rows[e.RowIndex].FindControl("txt_ed_Tel")).Text;
            paci.ActualizarPaciente(dni, nombre, apellido, sexo, nacionalidad, fecha, direccion, localidad, email, telefono);
            grdPacientes.EditIndex = -1;
            MostrarPacientes();
        }

        protected void grdPacientes_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grdPacientes.EditIndex = e.NewEditIndex;
            MostrarPacientes();
        }

        protected void grdPacientes_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            grdPacientes.EditIndex = -1;
            MostrarPacientes();
        }

        protected void grdPacientes_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdPacientes.PageIndex = e.NewPageIndex;
            MostrarPacientes();
        }
    }
}