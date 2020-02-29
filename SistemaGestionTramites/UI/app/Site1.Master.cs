using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EntidadesCompartidas;
namespace UI.app
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["Usuario"] == null)
                Response.Redirect("Default.aspx");

            Empleado empleado = (Empleado)Session["Usuario"];
            lblBienvenido.Text = empleado.Nombre;
        }

        protected void btnDestroySession_Click(object sender, EventArgs e)
        {
            Session["Usuario"] = null; 
                Response.Redirect("Default.aspx");
        }
    }
}