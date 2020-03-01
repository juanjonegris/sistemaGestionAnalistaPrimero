using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Persistencia
{
    internal class Conexion
    {
        
        internal static string cnn = "Data Source=.; Initial Catalog=SistemaGestion;Integrated Security=True";

        internal static int EjecutarComando(string sp, SqlParameter[] parametros)
        {
            SqlConnection conection = new SqlConnection(cnn);
            conection.Open();

            SqlCommand cmd = new SqlCommand(sp, conection);
            
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddRange(parametros);

            SqlParameter retorno = new SqlParameter();
            retorno.Direction = ParameterDirection.ReturnValue;
            cmd.Parameters.Add(retorno);

            cmd.ExecuteNonQuery();
            conection.Close();
            return Convert.ToInt32(retorno.Value);
        }

        //internal static SqlDataReader DevolverDataReader(string sp,
        //    SqlParameter[] parametros)
        //{
        //    SqlConnection connection = new SqlConnection(cnn);
        //    connection.Open();
        //    SqlCommand cmd = new SqlCommand(sp, connection);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    if (parametros != null)
        //        cmd.Parameters.AddRange(parametros);

        //    return cmd.ExecuteReader();
        //}
    }
}
