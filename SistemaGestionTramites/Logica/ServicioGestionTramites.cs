using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntidadesCompartidas;
using Persistencia;

namespace Logica
{
    public class ServicioGestionTramites
    {
        
        perGestionEntidades pergesent = new perGestionEntidades();

        perGestionTramites pergestra = new perGestionTramites();

       

        public Tramite conseguirTramite(string codigo, string nombreent)
        {
            Tramite tram = pergestra.conseguirTramite(codigo, nombreent);

            return tram;
        }

        public List<Tramite> ListarTodosTramites()
        {
            List<Tramite> listra = pergestra.listarTodosTramites();

            return listra;
        }

        public void altaTramite(string codigo, string nombreEntidad, string nombreTramite, string descripcion)
        {


            try
            {
                Entidad entidad = pergesent.conseguirEntidad(nombreEntidad);
                Tramite tramite = new Tramite(codigo, nombreTramite, entidad, descripcion);
                if (tramite == null)
                    throw new Exception("No se encontro trámite");
                pergestra.altaTramite(tramite);
            }
            catch (Exception ex)
            {
                throw ex;
                
            }
           

        }

        public void eliminarTramite(Tramite tramite)
        {
            pergestra.eliminarTramite(tramite);
        }

        public void modificarTramite(Tramite tramite)
        {
            pergestra.modificarTramite(tramite);
        }

          public List<Tramite> ListarTramites(Entidad enti)
        {
            List<Tramite> listatra = pergestra.listarTra( enti);
            return listatra;
          }
    }
}
