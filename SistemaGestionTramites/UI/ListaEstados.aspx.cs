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
    public partial class ListaEstados : System.Web.UI.Page
    {
        ServicioGestionTramites sergestra = new ServicioGestionTramites();
        ServicioGestionSolicitudes sergessol = new ServicioGestionSolicitudes();
        protected void Page_Load(object sender, EventArgs e)
        {
            if ( ! IsPostBack)
            { 
            List<Entidad> listent = new List<Entidad>();
            listent = (List<Entidad>)Session["ListaEntidades"];
                grdListaEntidades.DataSource = listent;
            grdListaEntidades.DataBind();
            }
        }

        protected void grdListaEntidades_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                limpiarTodo();
                List<Entidad> listent = new List<Entidad>();
                listent = (List<Entidad>)Session["ListaEntidades"];
                Entidad enti = listent[grdListaEntidades.SelectedIndex];
                List<Tramite> tramlist = new List<Tramite>();
                tramlist = sergestra.ListarTramites(enti);
                Session["ListaTramites"] = tramlist;

                if (tramlist.Count > 0)
                {
                    lblTituloTramite.Visible = true;
                    grdListaTramites.Visible = true;
                    grdListaTramites.DataSource = tramlist;
                    grdListaTramites.DataBind();
                }
                else
                {
                    lblErrorTramite.Visible = true;
                    lblErrorTramite.Text = "No se encontraron trámites para esa entidad";
                }
            }
            catch (Exception ex)
            {
                lblMensaje.Text = ex.Message;
            }

        }

        private void limpiarTodo()
        {
            lblTituloTramite.Visible = false;
            grdListaTramites.Visible = false;
            lblErrorTramite.Visible = false;
            grdSolicitud.Visible = false;
            cmbFiltro.Visible = false;
            btnFiltrar.Visible = false;
        }

        protected void grdListaTramites_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<Tramite> listra = new List<Tramite>();
            listra = (List<Tramite>)Session["ListaTramites"];
            Tramite tram = listra[grdListaTramites.SelectedIndex];
            List<Solicitud> listsol = new List<Solicitud>();
            listsol = sergessol.listarSolicitudesATramiteCronologica(tram);
            Session["SolicitudesOrdenadas"] = null;
            Session["SolicitudesOrdenadas"] = listsol;
            grdSolicitud.Visible = true;
            cmbFiltro.Visible = true;
            btnFiltrar.Visible = true;
            grdSolicitud.DataSource = listsol;
            grdSolicitud.DataBind();
        }



        protected void btnFiltrar_Click(object sender, EventArgs e)
        {
            try
            {

                List<Solicitud> listall = (List<Solicitud>)Session["SolicitudesOrdenadas"];
                List<Solicitud> listafiltrada = new List<Solicitud>();
                string selval = cmbFiltro.SelectedValue;
                if (selval == "Ejecutadas")
                {
                    foreach (Solicitud sol in listall)
                    {
                        if (sol.Estado.ToLower() == "ejecutada")
                        {
                            listafiltrada.Add(sol);
                        }
                    }
                    grdSolicitud.DataSource = listafiltrada;
                    grdSolicitud.DataBind();
                }
                else if (selval == "Anuladas")
                {
                    foreach (Solicitud sol in listall)
                    {
                        if (sol.Estado.ToLower() == "anulada")
                        {
                            listafiltrada.Add(sol);
                        }
                    }
                    grdSolicitud.DataSource = listafiltrada;
                    grdSolicitud.DataBind();
                } else
                {
                    grdSolicitud.DataSource = listall;
                    grdSolicitud.DataBind();
                }
            }
            catch (Exception ex)
            {
                lblMensaje.Text = ex.Message;
            }
        }
    }
}