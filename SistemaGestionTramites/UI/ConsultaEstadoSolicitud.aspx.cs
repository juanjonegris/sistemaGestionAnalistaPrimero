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
    public partial class ConsultaEstadoSolicitud : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["Solicitud"] = null;
        }

        protected void btnNumeroSolicitud_Click(object sender, EventArgs e)
        {
            

            ServicioGestionSolicitudes sergessol = new ServicioGestionSolicitudes();

            try
            {
                int numeroSolicitud = Convert.ToInt32(txtNumeroSolicitud.Text);

                Solicitud solicit = sergessol.conseguirSolicitud(numeroSolicitud);

                if (solicit != null)
                {
                    lblEstadoSolicitud.Text = "El estado de la solicitud es "+ solicit.Estado.ToString();

                    Session["Solicitud"] = solicit;

                } else
                {
                    lblEstadoSolicitud.Text = "El número de la solicitud ingresado no existe";
                }
            }
            catch (Exception ex)
            {
                lblMensaje.Text = ex.Message;
            }
        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            lblEstadoSolicitud.Text="";
            txtNumeroSolicitud.Text="";
            lblMensaje.Text="";
        }
    }
}