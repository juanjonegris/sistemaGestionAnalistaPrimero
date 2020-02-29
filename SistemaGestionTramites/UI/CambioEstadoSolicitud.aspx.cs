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
    public partial class CambioEstadoSolicitud : System.Web.UI.Page
    {
        ServicioGestionSolicitudes sergessol = new ServicioGestionSolicitudes();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.Cargo();
            }
        }

        protected void grdEstadoSolicitud_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                List<Solicitud> listsolses = new List<Solicitud>();
                Solicitud solicit = null;
                int index = Convert.ToInt32(e.CommandArgument);
                listsolses = (List<Solicitud>)Session["ListaSolicitudes"];
                solicit = listsolses[index];

                if (e.CommandName == "Ejecutada")
                {
                    solicit.Estado = "Ejecutada";
                    sergessol.cambiarEstadoSolicitud(solicit);
                }
                else if (e.CommandName == "Anulada")
                {
                     solicit.Estado = "Anulada";
                     sergessol.cambiarEstadoSolicitud(solicit);
                }

                //Response.Redirect("~/CambioEstadoSolicitud.aspx");
                this.Cargo();

            }
            catch (Exception ex)
            {
                lblMensaje.Text = ex.Message; 
            }
        }

        private void Cargo()
        {
            try
            {
                Session["ListaSolicitudes"] = sergessol.ListarSolicitudesAlta();
                grdEstadoSolicitud.DataSource = (List<Solicitud>)Session["ListaSolicitudes"];
                grdEstadoSolicitud.DataBind();
            }
            catch (Exception ex)
            {
                lblMensaje.Text = ex.Message;
            }

        }

    }
}