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
    public partial class GestionEmpleados : System.Web.UI.Page
    {
        ServicioGestionEmpleados sergesemp = new ServicioGestionEmpleados();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.LimpioFormulario();
                this.DesactivoBotones();
            }

        }


        public void DesactivoBotones()
        {
            btnAgregar.Enabled = false;
            btnEliminar.Enabled = false;
            btnModificar.Enabled = false;
        }

        private void LimpioFormulario()
        {
            txtCedula.Text = "";
            txtNombre.Text = "";
            txtContrasena.Text = "";
        }

     
        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {

                int cedula = Convert.ToInt32(txtCedula.Text);
                string nombre = txtNombre.Text;
                string contrasena = txtContrasena.Text;

                Empleado emp = new Empleado(cedula, nombre, contrasena);
                sergesemp.altaEmpleado(emp);
                lblMensaje.Text = "Se ha ingresado el empleado: " + emp.Cedula + " con éxito.";
                this.DesactivoBotones();
                this.LimpioFormulario();
            }
            catch (Exception ex)
            {

                lblMensaje.Text = ex.Message;
            }
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            int cedula = (Convert.ToInt32(txtCedula.Text));
            string nombre = txtNombre.Text;
            string contrasena = txtContrasena.Text;

            try
            {
                Empleado empleado = (Empleado)Session["Empleado"];
                empleado.Cedula = cedula;
                empleado.Nombre = nombre;
                empleado.Contrasena = contrasena;


                sergesemp.modificarEmpleado(empleado);

                lblMensaje.Text = "Se ha modificado el empleado: " + empleado.Cedula + " con éxito.";
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
                Empleado emp = (Empleado)Session["Empleado"];

                sergesemp.eliminarEmpleado(emp);
                lblMensaje.Text = "Eliminado con exito";
                this.LimpioFormulario();
                this.DesactivoBotones();
            }
            catch (Exception ex)
            {
                lblMensaje.Text = ex.Message;
            }
        }

        protected void btnBuscarEmpleado_Click1(object sender, EventArgs e)
        {
            try
            {
                int cedula = Convert.ToInt32(txtCedula.Text);

                Empleado emp = sergesemp.BuscarEmpleado(cedula);

                if (emp != null)
                {
                    txtCedula.Text = emp.Cedula.ToString();
                    txtNombre.Text = emp.Nombre;
                    txtContrasena.Text = emp.Contrasena;

                    Session["Empleado"] = emp;

                    btnEliminar.Enabled = true;
                    btnModificar.Enabled = true;
                }
                else
                {
                    lblMensaje.Text = "No se ha encontrado empleado con ese nombre";
                    Session["Empleado"] = null;
                    btnAgregar.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                lblMensaje.Text = ex.Message;
            }
        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.LimpioFormulario();
        }
    }
}