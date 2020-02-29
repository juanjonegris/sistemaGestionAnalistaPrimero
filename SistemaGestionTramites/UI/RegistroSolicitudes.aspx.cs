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
    public partial class RegistroSolicitudes : System.Web.UI.Page
    {
        ServicioGestionSolicitudes sergessol = new ServicioGestionSolicitudes();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ServicioGestionTramites sergestra = new ServicioGestionTramites();

                try
                {
                    List<Tramite> listra = sergestra.ListarTodosTramites();
                    Session["ListaTramite"] = listra;
                    grdListaTramites.DataSource = listra;
                    grdListaTramites.DataBind();
                }
                catch (Exception ex)
                {
                    lblMensaje.Text = ex.Message;
                }
            }
        }

        protected void grdListaTramites_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                List<Tramite> listra = (List<Tramite>)Session["ListaTramite"];
                Tramite tram = listra[grdListaTramites.SelectedIndex];
                
                Session["Tramite"] = tram;

                lblMensaje.Text = tram.ToString();
                lblExplicacionHora.Visible = true;
                cldFechaHora.Visible = true;
                lblNombreSolicitante.Visible = true;
                txtNombreSolicitante.Visible = true;
                btnAltaSolicitud.Visible = true;
                txtHora.Visible = true;
                txtMinuto.Visible = true;
            }
            catch (Exception ex)
            {
                lblMensaje.Text = ex.Message;
            }

        }

        protected void btnAltaSolicitud_Click(object sender, EventArgs e)
        {
            try
            {
                Empleado emp = (Empleado)Session["Usuario"];
                Tramite tramite = (Tramite)Session["Tramite"];
                string nombreTramite = tramite.Nombre;
                double hora = 0;
                double minuto = 0;
                //Chequear si el formato hora es correcto
                int _error = 0;
                bool reshor;
                int a;
                reshor = int.TryParse(txtHora.Text, out a);
                if (txtHora.Text.Length != 2 || !reshor)
                { 
                    _error += 1;
                }
                else
                { 
                     hora = Convert.ToDouble(txtHora.Text);

                    if(hora < 0 || hora > 23)
                        _error += 1;

                }
                //Chequear si el formato minuto es correcto
                bool resmin;
                int b;
                resmin = int.TryParse(txtMinuto.Text, out b);
                if (txtMinuto.Text.Length != 2 || !resmin)
                { 
                    _error += 1;
                }else
                {
                    minuto = Convert.ToDouble(txtMinuto.Text);

                    if(minuto < 0 || minuto > 59)
                        _error += 1;
                }

                if (_error > 0)
                   throw new Exception("Formato de hora ingresado incorrecto");

                DateTime fechahora = (DateTime)Session["FechaHora"];

                if(hora != 0)
                    fechahora.AddHours(hora);

                if (minuto != 0)
                    fechahora.AddMinutes(minuto);

                string estado = "Alta";
                string nombreSolicitante = txtNombreSolicitante.Text;

                Solicitud solicitud = new Solicitud(0, emp, tramite, fechahora, nombreSolicitante, estado);
                sergessol.altaSolicitud(solicitud);
                lblMensaje.Text = "Alta de solicitud realizada con éxito";
                cldFechaHora.Visible = false;
                lblNombreSolicitante.Visible = false;
                txtNombreSolicitante.Visible = false;
                btnAltaSolicitud.Visible = false;
                lblExplicacionHora.Visible = false;
                txtHora.Visible = false;
                txtMinuto.Visible = false;
                Session["FechaHora"] = null;
                Session["Tramite"] = null;
            }
            catch (Exception ex)
            {
                lblMensaje.Text = ex.Message;
            }
        }

        protected void cldFechaHora_SelectionChanged(object sender, EventArgs e)
        {
            DateTime fechahora = cldFechaHora.SelectedDate;
            Session["FechaHora"] = fechahora;
        }
    }
}