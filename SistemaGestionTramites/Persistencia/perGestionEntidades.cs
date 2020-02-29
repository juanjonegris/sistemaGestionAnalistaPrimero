using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using EntidadesCompartidas;

namespace Persistencia
{
    public class perGestionEntidades
    {
        public Entidad conseguirEntidad(string nombreEntidad)
        {
            try
            {
                SqlConnection connection = new SqlConnection(Conexion.cnn);
                SqlCommand cmd = new SqlCommand("sp_mostrarEntidad", connection);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter[] parametros = new SqlParameter[1];
                parametros[0] = new SqlParameter("Nombre", nombreEntidad);
                cmd.Parameters.AddRange(parametros);
                connection.Open();
                SqlDataReader dr = cmd.ExecuteReader();


                Entidad ent = null;
                string nombre;
                string direccion;
                List<string> listatel;
                if (dr.HasRows)
                {
                    dr.Read();
                    nombre = (string)dr["Nombre"];
                    direccion = (string)dr["Direccion"];
                    listatel = this.listarTelefonos(nombreEntidad);
                    ent = new Entidad(nombre, listatel, direccion);
                }
                dr.Close();
                connection.Close();
                return ent;

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public void altaEntidad(Entidad enti)
        {
            try
            {
                SqlParameter[] parametros = new SqlParameter[2];
                parametros[0] = new SqlParameter("Nom", enti.Nombre);
                parametros[1] = new SqlParameter("Direccion", enti.Direccion);

                int r = Conexion.EjecutarComando("sp_altaEntidad", parametros);

                if (r != 1)
                    throw new Exception("Ha habido un probema al dar de alta la entidad");

                this.altaTelefono(enti);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public void eliminarEntidad(Entidad entidad)
        {
            SqlParameter[] parametros = new SqlParameter[1];
            parametros[0] = new SqlParameter("NombreEntidad", entidad.Nombre);

            int r = Conexion.EjecutarComando("sp_eliminarEntidad", parametros);

            if (r == -1)
                throw new Exception("No se puede eliminar ya que tiene solicitudes asociadas");
            else if (r == -2)
                throw new Exception("Error al eliminar entidades y tramites asociados");
            else if (r == -3)
                throw new Exception("Entidad no existe");

        }

      
        public void modificarEntidad(Entidad entidad)
        {
            try
            {
                SqlParameter[] parametros = new SqlParameter[2];
                parametros[0] = new SqlParameter("Nombre", entidad.Nombre);
                parametros[1] = new SqlParameter("Direccion", entidad.Direccion);

                int r = Conexion.EjecutarComando("sp_modificarEntidad", parametros);

                if (r == -1)
                    throw new Exception("No existe la entidad");
                else if (r == -2)
                    throw new Exception("Ha ocurrid un error al actualizar la entidad");

                this.eliminarTelefonos(entidad);
                this.altaTelefono(entidad);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal void eliminarTelefonos(Entidad entidad)
        {
            SqlParameter[] parametros = new SqlParameter[1];
            parametros[0] = new SqlParameter("Nombre", entidad.Nombre);

            int r = Conexion.EjecutarComando("sp_eliminarTelefonosPorEntidad", parametros);

            if (r == -1)
                throw new Exception("No existe la entidad");


        }

        internal void altaTelefono(Entidad enti)
        {

            SqlConnection conn = new SqlConnection(Conexion.cnn);

            SqlCommand comando = new SqlCommand("sp_altaTelefono", conn);
            comando.CommandType = CommandType.StoredProcedure;

            SqlParameter retorno = new SqlParameter("Retorno", SqlDbType.Int);
            retorno.Direction = ParameterDirection.ReturnValue;
            comando.Parameters.Add(retorno);

            comando.Parameters.AddWithValue("Nombre", enti.Nombre);

            SqlParameter telefono = new SqlParameter("Numero", SqlDbType.VarChar, 20);
            comando.Parameters.Add(telefono);


            try
            {
                conn.Open();

                foreach (string numero in enti.Telefonos)
                {
                    telefono.Value = numero;
                    comando.ExecuteNonQuery();

                    if ((int)retorno.Value == -1)
                        throw new Exception("No existe la entidad a la que intenta ingresar el teléfono");
                    else if ((int)retorno.Value == -2)
                        throw new Exception("El dato que intenta ingresar ya existe");
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }


        internal List<string> listarTelefonos(string nombre)
        {
            try
            {
                SqlConnection connection = new SqlConnection(Conexion.cnn);
                SqlCommand cmd = new SqlCommand("sp_mostrarTelefonosPorEntidad", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter[] parametros = new SqlParameter[1];
                parametros[0] = new SqlParameter("Nombre", nombre);
                cmd.Parameters.AddRange(parametros);
                connection.Open();
                SqlDataReader dr = cmd.ExecuteReader();


                List<string> telefonos = new List<string>();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        string number = (string)dr["Numero"];

                        telefonos.Add(number);
                    }


                }
                dr.Close();
                connection.Close();
                return telefonos;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }


        public List<Entidad> listarEnt()
        {
            try
            {
                SqlConnection connection = new SqlConnection(Conexion.cnn);
                SqlCommand cmd = new SqlCommand("sp_listarEntidades", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                connection.Open();
                SqlDataReader dr = cmd.ExecuteReader();


                List<Entidad> listaentidad = new List<Entidad>();
                string nombre;
                string direccion;
                Entidad ent = null;
                while (dr.Read())
                {
                    nombre = (string)dr["Nombre"];
                    direccion = (string)dr["Direccion"];
                    ent = new Entidad(nombre, this.listarTelefonos(nombre), direccion);
                    listaentidad.Add(ent);
                }

                dr.Close();
                connection.Close();
                return listaentidad;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }

}
