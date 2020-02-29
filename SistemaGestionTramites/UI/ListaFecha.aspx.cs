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
    public partial class ListaFecha : System.Web.UI.Page
    {
        ServicioGestionSolicitudes sergessol = new ServicioGestionSolicitudes();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void cldSeleccionarFecha_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                lblMensaje.Text="";
                lblMostrarInfoSolEntYTramite.Visible = false;
                DateTime fechaseleccionada = cldSeleccionarFecha.SelectedDate;
                //if (DateTime.Now > fechaseleccionada)
                //    throw new Exception("La fecha debe ser posterior al dia de hoy");
                List<Solicitud> listsol = sergessol.ListarSolicitudesPorFechaYHora(fechaseleccionada);
                Session["ListaSolicitudes"] = null;
                Session["ListaSolicitudes"] = listsol;
                grdSolicitudPorFechaYHora.Visible = true;
                grdSolicitudPorFechaYHora.DataSource = listsol;
                grdSolicitudPorFechaYHora.DataBind();

            }
            catch (Exception ex)
            {
                lblMensaje.Text = ex.Message;
            }
        }

        protected void grdSolicitudPorFechaYHora_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<Solicitud> listsol = new List<Solicitud>();
            listsol = (List<Solicitud>)Session["ListaSolicitudes"];
            Solicitud soli = listsol[grdSolicitudPorFechaYHora.SelectedIndex];

            lblMostrarInfoSolEntYTramite.Visible = true;
             
            string infomostrar = "SOLICITUD: "+ soli.ToString() + " EMPLEADO: " + soli.empleado.ToString()+" TIPO DE TRAMITE: "+ soli.tipoTramite.ToString() + " ENTIDAD: " + soli.tipoTramite.entidad.ToString();
            lblMostrarInfoSolEntYTramite.Text = infomostrar;
        }
    }
}