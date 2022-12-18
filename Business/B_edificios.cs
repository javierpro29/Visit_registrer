using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using Data;

namespace Business
{
    public class B_edificios
    {

        D_edificios objEdificios = new D_edificios();

        public DataTable cargarComboEdificio()
        {
            return objEdificios.cargarComboEdificio();
        }

    }
}
