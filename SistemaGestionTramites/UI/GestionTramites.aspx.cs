using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Logica;
using EntidadesCompartidas;

namespace UI
{
    public partial class GestionTramites : System.Web.UI.Page
    {
        ServicioGestionTramites sergestra = new ServicioGestionTramites();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.LimpioFormulario();
                this.DesactivoBotones();
            }
        }

        private void DesactivoBotones()
        {
            btnAgregar.Enabled = false;
            btnEliminar.Enabled = false;
            btnModificar.Enabled = false;
        }

        private void LimpioFormulario()
        {
            txtDescripcionTramite.Text="";
            txtNombreEntidad.Text ="";
            txtNombreTramite.Text ="";
            txtNumeroTramite.Text ="";
        }

        protected void btnBuscarTramite_Click(object sender, EventArgs e)
        {
            string codigo = txtNumeroTramite.Text.Trim();
            string nombreent = txtNombreEntidad.Text.Trim();

           
            try
            {
                Tramite tramite = sergestra.conseguirTramite(codigo, nombreent);

                if(tramite != null)
                {
                    txtNumeroTramite.Text = tramite.Codigo;
                    txtNombreEntidad.Text = tramite.entidad.Nombre;
                    txtNombreTramite.Text = tramite.Nombre;
                    txtDescripcionTramite.Text = tramite.Descripcion;
                    Session["Tramite"] = tramite;

                    
                    btnEliminar.Enabled = true;
                    btnModificar.Enabled = true;
                }else
                {
                    lblMensaje.Text = "No se ha encontrado un trámite con ese nombre";
                    Session["Tramite"] = null;
                    btnAgregar.Enabled = true;
                }


            }
            catch (Exception ex)
            {
                lblMensaje.Text = ex.Message;
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            string codigo = txtNumeroTramite.Text;
            string nombreEntidad = txtNombreEntidad.Text;
            string nombreTramite = txtNombreTramite.Text;
            string descripcion = txtDescripcionTramite.Text;
            try
            {
                sergestra.altaTramite(codigo, nombreEntidad, nombreTramite, descripcion);
                lblMensaje.Text = "Se ha ingresado el trámite " + nombreTramite + " con éxito.";
                this.DesactivoBotones();
                this.LimpioFormulario();
            }
            catch (Exception ex)
            {

                lblMensaje.Text = ex.Message;
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                Tramite tramite = (Tramite)Session["Tramite"];

                sergestra.eliminarTramite(tramite);
                lblMensaje.Text = "Eliminación exitosa";
                this.LimpioFormulario();
                this.DesactivoBotones();
            }
            catch (Exception ex)
            {
                lblMensaje.Text = ex.Message;
            }
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            string codigo = txtNumeroTramite.Text;
            string nombreEntidad = txtNombreEntidad.Text;
            string nombreTramite = txtNombreTramite.Text;
            string descripcion = txtDescripcionTramite.Text;

            ServicioGestionEntidades sergesent = new ServicioGestionEntidades();
            try
            {
                Tramite tramite = (Tramite)Session["Tramite"];
                tramite.Codigo = codigo;
                tramite.entidad = sergesent.conseguirEntidad(nombreEntidad);
                tramite.Nombre = nombreTramite;
                tramite.Descripcion = descripcion;

                sergestra.modificarTramite(tramite);

                lblMensaje.Text = "Se ha modificado el trámite: " + nombreTramite + " con éxito.";
                this.DesactivoBotones();
                this.LimpioFormulario();
            }
            catch (Exception ex)
            {
                lblMensaje.Text = ex.Message;
            }
        }
    }
}