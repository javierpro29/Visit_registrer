using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Data
{
    public class D_usuarios
    {

        SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["conection"].ConnectionString);


        public bool Login(string USERNAME, string PASSWORD)
        {
            SqlCommand cmd = new SqlCommand("SP_VALIDAR_USUARIO", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();

            cmd.Parameters.AddWithValue("@USERNAME", USERNAME);
            cmd.Parameters.AddWithValue("@PASSWORD", PASSWORD);

            SqlDataReader reader = cmd.ExecuteReader();

            return reader.Read();

        }


    }
}
