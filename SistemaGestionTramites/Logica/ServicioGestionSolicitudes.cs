using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntidadesCompartidas;
using Persistencia;


namespace Logica
{
    public class ServicioGestionSolicitudes
    {

        perGestionSolicitudes pergesol = new perGestionSolicitudes();
        public Solicitud conseguirSolicitud(int numeroSolicitud)
        {

            Solicitud solicitud = pergesol.conseguirSolicitud(numeroSolicitud);
            return solicitud;

        }

        public void altaSolicitud(Solicitud solicitud)
        {
            if (DateTime.Now > solicitud.FechaHora)
                throw new Exception("La fecha debe ser posterior al dia de hoy");

            pergesol.altaSolicitud(solicitud);
        }

        public List<Solicitud> ListarSolicitudesPorFechaYHora(DateTime fechaseleccionada)
        {
           return pergesol.listarSolicitudesPorFechaYHora(fechaseleccionada);
        }

        public List<Solicitud> ListarSolicitudesAlta()
        {
            return pergesol.listarSolicitudesAlta();
        }

        public void cambiarEstadoSolicitud(Solicitud sol)
        {
            pergesol.modificarEstadoSolicitud(sol);
        }

        public List<Solicitud> listarSolicitudesATramiteCronologica(Tramite tram)
        {
            return pergesol.listarSolicitudesATramiteCronologica(tram);
        }
    }
}
