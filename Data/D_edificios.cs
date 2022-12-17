using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;

namespace Data
{
    public class D_edificios
    {

        SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["conection"].ConnectionString);
    
        
        public DataTable cargarComboEdificio()
        {
            SqlDataAdapter adapter = new SqlDataAdapter("SP_CARGAREDIFICIOS", conexion);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            return dt;
        }
        
    }
}
