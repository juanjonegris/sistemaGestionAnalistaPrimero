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
    public partial class Logueo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["Usuario"] = null;
        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            
            ServicioGestionEmpleados sergesemp = new ServicioGestionEmpleados();
            try
            {
                int cedula = Convert.ToInt32(txtUsuario.Text);
                string contrasena = txtContrasena.Text;

                Empleado empleado = sergesemp.loginEmpleado(cedula, contrasena);
                
                if (empleado != null)
                { 
                Session["Usuario"] = empleado;
                Response.Redirect("HomeUser.aspx");
                } else
                {
                    throw new Exception("Usuario y/o contraseña incorrectos");
                }

            }
            catch (Exception ex)
            {
                lblMensaje.Text = ex.Message;
            }

        }
    }
}