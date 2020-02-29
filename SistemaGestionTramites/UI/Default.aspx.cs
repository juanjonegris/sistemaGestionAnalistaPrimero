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
    public partial class Default : System.Web.UI.Page
    {

        ServicioGestionEntidades sergesent = new ServicioGestionEntidades();

        ServicioGestionTramites sergestra = new ServicioGestionTramites();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    Session["ListaEntidades"] = sergesent.ListarEnti();
                    grdListaEntidades.DataSource = (List<Entidad>)Session["ListaEntidades"];

                    grdListaEntidades.DataBind();
                }
                catch (Exception ex)
                {
                    lblMensaje.Text = ex.Message;
                }
            }

        }

       
        public void grdListaEntidades_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            try
            {
                List<Entidad> listenti = (List<Entidad>)Session["ListaEntidades"];
                Entidad enti = listenti[grdListaEntidades.SelectedIndex];
                lblTramite.Visible = true;
                lblTramite.Text = "Lista de Trámites";
                grdListaTramites.Visible = true;
                grdListaTramites.DataSource = sergestra.ListarTramites(enti);
                grdListaTramites.DataBind();
            }
            catch (Exception ex)
            {
                lblMensaje.Text = ex.Message;
            }
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            lblTramite.Text ="";
            grdListaTramites.Visible = false;
        }
    }
}