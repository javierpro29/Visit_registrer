using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;

namespace Business
{
    public class B_usuarios
    {

        D_usuarios objUsuarios = new Data.D_usuarios();

        public bool login(string USERNAME, string PASSWORD)
        {
            return(objUsuarios.Login(USERNAME, PASSWORD)); 
        }

    }
}
