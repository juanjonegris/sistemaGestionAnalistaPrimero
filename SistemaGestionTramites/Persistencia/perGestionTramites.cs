using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using EntidadesCompartidas;
using System.Data;

namespace Persistencia
{
    public class perGestionTramites
    {
        perGestionEntidades pergesent = new perGestionEntidades();
        public Tramite conseguirTramite(string codtra, string noment)
        {
            try
            {
                SqlConnection connection = new SqlConnection(Conexion.cnn);
                SqlCommand cmd = new SqlCommand("sp_mostrarTramite", connection);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter[] parametros = new SqlParameter[2];
                parametros[0] = new SqlParameter("Codigo", codtra);
                parametros[1] = new SqlParameter("NombreEntidad", noment);
                cmd.Parameters.AddRange(parametros);

                connection.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                Tramite tramit = null;

                if (dr.HasRows)
                {
                    dr.Read();
                    Entidad entid = pergesent.conseguirEntidad(noment);
                    string nomtra = dr["NombreTramite"].ToString();
                    string desc = dr["Descripcion"].ToString();
                    tramit = new Tramite(codtra, nomtra, entid, desc);
                }

                dr.Close();
                connection.Close();
                return tramit;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Tramite> listarTodosTramites()
        {
            try
            {
                SqlConnection connection = new SqlConnection(Conexion.cnn);
                SqlCommand cmd = new SqlCommand("sp_mostrarTramitesOrdenPorNombre", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                connection.Open();
                SqlDataReader dr = cmd.ExecuteReader();


                List<Tramite> listatramite = new List<Tramite>();

                string codigo;
                string nombre;
                Entidad ent = null;
                string descripcion;

                Tramite tra = null;
                perGestionEntidades pergesent = new perGestionEntidades();
                while (dr.Read())
                {
                    codigo = (string)dr["Codigo"];
                    nombre = (string)dr["NombreTramite"];
                    ent = pergesent.conseguirEntidad((string)dr["NombreEntidad"]);
                    descripcion = (string)dr["Descripcion"];

                    tra = new Tramite(codigo, nombre, ent, descripcion);
                    listatramite.Add(tra);
                }

                dr.Close();
                connection.Close();
                return listatramite;

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void altaTramite(Tramite tramite)
        {
            try
            {
                SqlParameter[] parametros = new SqlParameter[4];
                parametros[0] = new SqlParameter("Codigo", tramite.Codigo);
                parametros[1] = new SqlParameter("NombreEntidad", tramite.entidad.Nombre);
                parametros[2] = new SqlParameter("NombreTramite", tramite.Nombre);
                parametros[3] = new SqlParameter("Descripcion", tramite.Descripcion);

                int r = Conexion.EjecutarComando("sp_altaTramite", parametros);

                if (r == -1)
                    throw new Exception("No existe la Entidad a la que pertenece el trámite");
                else if (r == -2)
                    throw new Exception("El trámite que intenta crear ya existe");
                else if (r == -3)
                    throw new Exception("Ha habido un error");

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void eliminarTramite(Tramite tramite)
        {
            try
            {
                SqlParameter[] parametros = new SqlParameter[2];
                parametros[0] = new SqlParameter("Codigo", tramite.Codigo);
                parametros[1] = new SqlParameter("NombreEntidad", tramite.entidad.Nombre);

                int r = Conexion.EjecutarComando("sp_eliminarTramite", parametros);

                if (r == -1)
                    throw new Exception("El trámite con el código y el nombre de entidad provisto no existe");
                else if (r == -2)
                    throw new Exception("Ha habido un problema al ejecutar la transacción. Inténtelo más tarde.");

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void modificarTramite(Tramite tramite)
        {
            SqlParameter[] parametros = new SqlParameter[4];
            parametros[0] = new SqlParameter("Codigo", tramite.Codigo);
            parametros[1] = new SqlParameter("NombreEntidad", tramite.entidad.Nombre);
            parametros[2] = new SqlParameter("NombreTramite", tramite.Nombre);
            parametros[3] = new SqlParameter("Descripcion", tramite.Descripcion);
            
            int r = Conexion.EjecutarComando("sp_modificarTramite", parametros);

            if (r == -1)
                throw new Exception("No existe el Trámite que intenta modificar");
            else if (r == -2)
                throw new Exception("Ha ocurrid un error al actualizar el tramite");

        }

        public List<Tramite> listarTra( Entidad ent)
        {
            try
            {
                SqlConnection connection = new SqlConnection(Conexion.cnn);
                SqlCommand cmd = new SqlCommand("sp_listarTramitesPorEntidades", connection);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter[] parametros = new SqlParameter[1];
                parametros[0] = new SqlParameter("NombreEntidad", ent.Nombre);
                cmd.Parameters.AddRange(parametros);

                connection.Open();
                SqlDataReader dr = cmd.ExecuteReader(); 

                List<Tramite> listatramite = new List<Tramite>();

                string codigo;
                string nombre;
                string descripcion;
                Tramite tra = null;

                while (dr.Read())
                {
                    codigo = (string)dr["Codigo"];
                    nombre = (string)dr["NombreTramite"];
                    descripcion = (string)dr["Descripcion"];

                    tra = new Tramite(codigo, nombre, ent, descripcion);
                    listatramite.Add(tra);
                }

                dr.Close();
                connection.Close();

                return listatramite;


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
