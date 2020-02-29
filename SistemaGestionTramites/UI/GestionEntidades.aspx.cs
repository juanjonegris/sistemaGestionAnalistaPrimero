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
    public partial class GestionEntidades : System.Web.UI.Page
    {

        ServicioGestionEntidades sergesent = new ServicioGestionEntidades();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.LimpioFormulario();
                this.DesactivoBotones();
            }
        }


        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            string nombreEnt = txtNombreEntidad.Text;

            try
            {

                Entidad entid = sergesent.buscarEntidad(nombreEnt);

                if (entid != null)
                {
                    txtNombreEntidad.Text = entid.Nombre;
                    txtDireccion.Text = entid.Direccion;
                    lbTelefonos.DataSource = entid.Telefonos;
                    lbTelefonos.DataBind();
                    Session["Entidad"] = entid;

                    btnAltatel.Enabled = true;
                    btnEliminar.Enabled = true;
                    btnEliminarTel.Enabled = true;
                    btnLimpiar.Enabled = true;
                    btnModificar.Enabled = true;
                }
                else
                {
                    lblMensaje.Text = "No se ha encontrado una entidad con ese nombre";
                    Session["Entidad"] = null;
                    btnAgregar.Enabled = true;
                    btnAltatel.Enabled = true;
                    btnEliminarTel.Enabled = true;
                }
            }
            catch (Exception ex)
            {

                lblMensaje.Text = ex.Message;
            }

        }


        private void DesactivoBotones()
        {
            btnAgregar.Enabled = false;
            btnAltatel.Enabled = false;
            btnEliminar.Enabled = false;
            btnEliminarTel.Enabled = false;
            btnLimpiar.Enabled = false;
            btnModificar.Enabled = false;

        }

        private void LimpioFormulario()
        {
            txtNombreEntidad.Text = "";
            txtDireccion.Text = "";
            txtTelefonos.Text = "";
            lbTelefonos.Items.Clear();
            lblMensaje.Text="";
        }

        protected void btnAltatel_Click(object sender, EventArgs e)
        {

            string tel = txtTelefonos.Text.Trim();
            try
            {
                foreach (ListItem item in lbTelefonos.Items)
                {
                    if (item.Text == tel)
                    
                        throw new Exception("Ya existe el número de teléfono en la lista");

                }
                lbTelefonos.Items.Add(tel);

                txtTelefonos.Text = "";
                
            }
            catch (Exception ex)
            {
                lblMensaje.Text = ex.Message;
            }
        }

        protected void btnEliminarTel_Click(object sender, EventArgs e)
        {
            if (lbTelefonos.SelectedIndex >= 0)
            {
                lbTelefonos.Items.RemoveAt(lbTelefonos.SelectedIndex);
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            string nombre = txtNombreEntidad.Text;
            string direccion = txtDireccion.Text;
            try
            {

            List<string> listatel = new List<string>();

            foreach (ListItem item in lbTelefonos.Items)
            {
                listatel.Add(item.Text);
            }
           
                Entidad enti = new Entidad(nombre, listatel, direccion);
                sergesent.altaEntidad(enti);
                lblMensaje.Text = "Se ha ingresado la entidad: " + enti.Nombre + " con éxito.";
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
                Entidad entidad = (Entidad)Session["Entidad"];

                sergesent.eliminarEntidad(entidad);
                lblMensaje.Text="Eliminación exitosa";
                this.LimpioFormulario();
                this.DesactivoBotones();
            }
            catch (Exception ex)
            {
                lblMensaje.Text = ex.Message;
            }
        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.LimpioFormulario();
            this.DesactivoBotones();
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            string nombre = txtNombreEntidad.Text;
            string direccion = txtDireccion.Text;
            try
            {

                List<string> listatel = new List<string>();

            foreach (ListItem item in lbTelefonos.Items)
            {
                listatel.Add(item.Text);
            }
            
                Entidad entidad = (Entidad)Session["Entidad"];
                entidad.Nombre = nombre;
                entidad.Direccion = direccion;
                entidad.Telefonos = listatel;

                sergesent.modificarEntidad(entidad);

                lblMensaje.Text = "Se ha modificado la entidad: " + entidad.Nombre + " con éxito.";
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