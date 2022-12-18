using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using Data;
using System.Xml.Linq;

namespace Business
{
    public class B_visitas
    {
        D_usuarios objUsuarios = new D_usuarios();
        D_visitas objVisitas = new D_visitas();

        public List<E_visitas> listandoVisitas(string buscar)
        {
            return objVisitas.listarVisitas(buscar);
        }

        public void insertandoVisita(E_visitas visita)
        {
            objVisitas.insertarVisita(visita);
        }

        public void editandoVisita(E_visitas visita)
        {
            objVisitas.editarVisitas(visita);
        }

        public void eliminandoVisita(E_visitas visita)
        {
            objVisitas.eliminarVisitas(visita);
        }

    }
}
