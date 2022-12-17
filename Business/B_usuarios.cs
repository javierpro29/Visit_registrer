using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using Entity;

namespace Business
{
    public class B_usuarios
    {
        E_usuarios objUsuario = new E_usuarios();
        D_usuarios objUsuarios = new Data.D_usuarios();

        public bool login(string USERNAME, string PASSWORD)
        {
            return(objUsuarios.Login(USERNAME, PASSWORD)); 
        }

        public List<E_usuarios> MostrandoUsuarios(String buscar)
        {
            return objUsuarios.mostarUsuarios(buscar);
        }

        public void insertandoUsuarios(E_usuarios usuario)
        {
            objUsuarios.insertarUsuarios(usuario);
        }

        public void editandoUsuarios(E_usuarios usuario)
        {
            objUsuarios.editarUsuarios(usuario);
        }

        public void eliminandoUsuarios(E_usuarios usuario)
        {
            objUsuarios.eliminarUsuario(usuario);
        }
    }
}
