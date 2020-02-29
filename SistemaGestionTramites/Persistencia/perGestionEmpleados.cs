using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using EntidadesCompartidas;

namespace Persistencia
{
    public class perGestionEmpleados
    {
        public Empleado conseguirEmpleado(int cedula)
        {
            SqlConnection connection = new SqlConnection(Conexion.cnn);
            SqlCommand cmd = new SqlCommand("sp_buscarEmpleado", connection);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter[] parametros = new SqlParameter[1];
            parametros[0] = new SqlParameter("Cedula", cedula);
            cmd.Parameters.AddRange(parametros);

            connection.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            Empleado emple = null;

            if (dr.HasRows)
            {
                dr.Read();
                int ci = Convert.ToInt32(dr["Cedula"]);
                string pwr = dr["Contrasena"].ToString();
                string nom = dr["Nombre"].ToString();

                emple = new Empleado(ci, nom, pwr);
            }
            dr.Close();
            connection.Close();
            return emple;
        }

        public Empleado loginEmpleado(int cedula, string contra)
        {
            try
            {
                SqlConnection connection = new SqlConnection(Conexion.cnn);
                SqlCommand cmd = new SqlCommand("sp_corroborarUseryPwr", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter[] parametros = new SqlParameter[2];
                parametros[0] = new SqlParameter("Cedula", cedula);
                parametros[1] = new SqlParameter("Contrasena", contra);
                cmd.Parameters.AddRange(parametros);

                connection.Open();
                SqlDataReader dr = cmd.ExecuteReader();


                Empleado emplea = null;
                int ced;
                string nombre;
                string contrase;
                if (dr.HasRows)
                {
                    dr.Read();
                    ced = Convert.ToInt32(dr["Cedula"]);
                    nombre = (string)dr["Nombre"];
                    contrase = (string)dr["Contrasena"];
                    emplea = new Empleado(ced, nombre, contrase);
                }
                dr.Close();
                connection.Close();
                return emplea;

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void altaEmpleado(Empleado emp)
        {
            try
            {
                SqlParameter[] parametros = new SqlParameter[3];
                parametros[0] = new SqlParameter("Cedula", emp.Cedula);
                parametros[1] = new SqlParameter("Contrasena", emp.Contrasena);
                parametros[2] = new SqlParameter("Nombre", emp.Nombre);

                int r = Conexion.EjecutarComando("sp_altaEmpleado", parametros);

                if (r != 1)
                    throw new Exception("Ha habido un problema en dar alta al empleado");

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void eliminarEmpleado(Empleado emp)
        {
            try
            {
                SqlParameter[] parametros = new SqlParameter[1];
                parametros[0] = new SqlParameter("Cedula", emp.Cedula);

                int r = Conexion.EjecutarComando("sp_eliminarEmpleado", parametros);

                if (r == -1)
                    throw new Exception("No se puede eliminar el empleado porque tiene solicitudes pendientes a su nombre.");
                else if (r == -2)
                    throw new Exception("No existe el empleado que intenta eliminar.");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        public void modificarEmpleado(Empleado emp)
        {
            try
            {
                SqlParameter[] parametros = new SqlParameter[3];
                parametros[0] = new SqlParameter("Cedula", emp.Cedula);
                parametros[1] = new SqlParameter("Contrasena", emp.Contrasena);
                parametros[2] = new SqlParameter("Nombre", emp.Nombre);

                int r = Conexion.EjecutarComando("sp_modificarEmpleado", parametros);

                if (r == -1)
                    throw new Exception("El empleado no existe.");
                else if (r == -2)
                    throw new Exception("Ha habido un error.");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
