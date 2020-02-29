using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using EntidadesCompartidas;

namespace Persistencia
{
    public class perGestionSolicitudes
    {
        perGestionEmpleados pergesemp = new perGestionEmpleados();
        perGestionTramites pergestra = new perGestionTramites();

        public Solicitud conseguirSolicitud(int numeroSolicitud)
        {
            try
            {
                SqlConnection connection = new SqlConnection(Conexion.cnn);
                SqlCommand cmd = new SqlCommand("sp_consultaEspadoDeSolicitud", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter[] parametros = new SqlParameter[1];
                parametros[0] = new SqlParameter("NumeroSolicitud", numeroSolicitud);

                cmd.Parameters.AddRange(parametros);

                connection.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                Solicitud solicitud = null;

                if (dr.HasRows)
                {
                    dr.Read();
                    int num = Convert.ToInt32(dr["NumeroSolicitud"]);

                    Empleado emp = pergesemp.conseguirEmpleado(Convert.ToInt32(dr["CedulaEmpleado"]));
                    string codtra = dr["CodigoTramite"].ToString();
                    string noment = dr["NombreEntidad"].ToString();
                    Tramite tra = pergestra.conseguirTramite(codtra, noment);
                    string nomsol = dr["NombreSolicitante"].ToString();
                    DateTime fechhor = Convert.ToDateTime(dr["FechaHora"]);
                    string estado = dr["estado"].ToString();

                    solicitud = new Solicitud(numeroSolicitud, emp, tra, fechhor, nomsol, estado);
                }
                dr.Close();
                connection.Close();
                return solicitud;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<Solicitud> listarSolicitudesPorFechaYHora(DateTime fechaseleccionada)
        {
            try
            {
                SqlConnection connection = new SqlConnection(Conexion.cnn);
                SqlCommand cmd = new SqlCommand("sp_listarSolicitudesAltaPorPeriodo", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter[] parametros = new SqlParameter[1];
                parametros[0] = new SqlParameter("Fecha", fechaseleccionada);
                cmd.Parameters.AddRange(parametros);
                connection.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                List<Solicitud> listsolfechhor = new List<Solicitud>();

                int num;
                int cedula;
                Empleado emp = null;
                string codigoTramite;
                string nombreEntidad;
                Tramite tra = null;
                string nombreSolicitante;
                DateTime fechahora;
                string estado;
                Solicitud sol = null;

                if (dr.HasRows)
                {

                    while (dr.Read())
                    {
                        num = Convert.ToInt32(dr["NumeroSolicitud"]);
                        cedula = Convert.ToInt32(dr["CedulaEmpleado"]);
                        emp = pergesemp.conseguirEmpleado(cedula);
                        codigoTramite = dr["CodigoTramite"].ToString();
                        nombreEntidad = dr["NombreEntidad"].ToString();
                        tra = pergestra.conseguirTramite(codigoTramite, nombreEntidad);
                        nombreSolicitante = dr["NombreSolicitante"].ToString();
                        fechahora = Convert.ToDateTime(dr["FechaHora"]);
                        estado = dr["Estado"].ToString();
                        sol = new Solicitud(num, emp, tra, fechahora, nombreSolicitante, estado);
                        listsolfechhor.Add(sol);
                    }

                }
                dr.Close();
                connection.Close();
                return listsolfechhor;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Solicitud> listarSolicitudesATramiteCronologica(Tramite tram)
        {
            try
            {

                SqlConnection connection = new SqlConnection(Conexion.cnn);
                SqlCommand cmd = new SqlCommand("sp_mostrarSolicitudesDeTramite", connection);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter[] parametros = new SqlParameter[2];
                parametros[0] = new SqlParameter("Codigo", tram.Codigo);
                parametros[1] = new SqlParameter("Nombreentidad", tram.entidad.Nombre);
                cmd.Parameters.AddRange(parametros);

                connection.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                List<Solicitud> listsolordered = new List<Solicitud>();

                int num;
                int cedula;
                Empleado emp = null;
                string nombreSolicitante;
                DateTime fechahora;
                string estado;
                Solicitud sol = null;

                if (dr.HasRows)
                {

                    while (dr.Read())
                    {
                        num = Convert.ToInt32(dr["NumeroSolicitud"]);
                        cedula = Convert.ToInt32(dr["CedulaEmpleado"]);
                        emp = pergesemp.conseguirEmpleado(cedula);
                        nombreSolicitante = dr["NombreSolicitante"].ToString();
                        fechahora = Convert.ToDateTime(dr["FechaHora"]);
                        estado = dr["Estado"].ToString();
                        sol = new Solicitud(num, emp, tram, fechahora, nombreSolicitante, estado);
                        listsolordered.Add(sol);
                    }

                }
                dr.Close();
                connection.Close();
                return listsolordered;

            }
            catch (Exception ex)
            {

                throw ex;
            }
            
    
        }

        public void modificarEstadoSolicitud(Solicitud sol)
        {
            try
            {
                SqlParameter[] parametros = new SqlParameter[2];
                parametros[0] = new SqlParameter("Estado", sol.Estado);
                parametros[1] = new SqlParameter("NumeroSolicitud", sol.Numero);

                int r = Conexion.EjecutarComando("sp_actualizarEstadoSolicitudes", parametros);

                if (r == -1)
                    throw new Exception("No existe la Solicitud que intenta actualizar.");
                else if (r == -2)
                    throw new Exception("Ha habido un error al intentar cambiar el estado de la solicitud.");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void altaSolicitud(Solicitud solicitud)
        {
            try
            {
                SqlParameter[] parametros = new SqlParameter[5];
                parametros[0] = new SqlParameter("CedulaEmpleado", solicitud.empleado.Cedula);
                parametros[1] = new SqlParameter("CodigoTramite", solicitud.tipoTramite.Codigo);
                parametros[2] = new SqlParameter("NombreEntidad", solicitud.tipoTramite.entidad.Nombre);
                parametros[3] = new SqlParameter("NombreSolicitante", solicitud.NombreSolicitante);
                parametros[4] = new SqlParameter("FechaHora", solicitud.FechaHora);


                int r = Conexion.EjecutarComando("sp_altaSolicitud", parametros);

                if (r == -1)
                    throw new Exception("No existe el Trámite al que se intenta asociar la Solicitud.");
                else if (r == -2)
                    throw new Exception("El empleado que realiza la solicitud no se encuentra registrado.");
                else if (r <= 0)
                    throw new Exception("Ha habido un error");

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<Solicitud> listarSolicitudesAlta()
        {
            try
            {
                SqlConnection connection = new SqlConnection(Conexion.cnn);
                SqlCommand cmd = new SqlCommand("sp_mostrarSolicitudesEstadoAlta", connection);
                cmd.CommandType = CommandType.StoredProcedure;

                connection.Open();
                SqlDataReader dr = cmd.ExecuteReader();


                List<Solicitud> listsolalta = new List<Solicitud>();

                int num;
                int cedula;
                Empleado emp = null;
                string codigoTramite;
                string nombreEntidad;
                Tramite tra = null;
                string nombreSolicitante;
                DateTime fechahora;
                string estado;
                Solicitud sol = null;

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        num = Convert.ToInt32(dr["NumeroSolicitud"]);
                        cedula = Convert.ToInt32(dr["CedulaEmpleado"]);
                        emp = pergesemp.conseguirEmpleado(cedula);
                        codigoTramite = dr["CodigoTramite"].ToString();
                        nombreEntidad = dr["NombreEntidad"].ToString();
                        tra = pergestra.conseguirTramite(codigoTramite, nombreEntidad);
                        nombreSolicitante = dr["NombreSolicitante"].ToString();
                        fechahora = Convert.ToDateTime(dr["FechaHora"]);
                        estado = dr["Estado"].ToString();
                        sol = new Solicitud(num, emp, tra, fechahora, nombreSolicitante, estado);
                        listsolalta.Add(sol);
                    }
                }
                dr.Close();
                connection.Close();
                return listsolalta;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
