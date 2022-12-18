using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Data;

namespace Business
{
   public class B_aulas
    {

        D_aulas objAulas = new D_aulas();

        public DataTable cargarComboAula()
        {
            return objAulas.cargarComboAula();
        }
    }
}
