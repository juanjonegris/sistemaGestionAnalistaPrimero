using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Persistencia;
using EntidadesCompartidas;

namespace Logica
{
    public class ServicioGestionEntidades
    {
        perGestionEntidades pergesent = new perGestionEntidades();

        public Entidad conseguirEntidad(string nombre)
        {
            Entidad entidad = null;
            try
            {
                entidad = pergesent.conseguirEntidad(nombre);
                if (entidad == null)
                    throw new Exception("No se encontró la entidad");
                return entidad;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public List<Entidad> ListarEnti()
        {

            List<Entidad> listaentidades = pergesent.listarEnt();
            return listaentidades;

        }
        public Entidad buscarEntidad(string nombreEnt)
        {
            
            return pergesent.conseguirEntidad(nombreEnt);
                
        }

        public void altaEntidad(Entidad enti)
        {
           pergesent.altaEntidad(enti);
        }

        public void eliminarEntidad(Entidad entidad)
        {
            pergesent.eliminarEntidad(entidad);
        }

        public void modificarEntidad(Entidad entidad)
        {
            pergesent.modificarEntidad(entidad);
        }
    }
}
