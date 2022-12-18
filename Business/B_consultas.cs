using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using Entity;

namespace Business
{
    public class B_consultas
    {

        D_consultas objConsultas = new D_consultas();

        public List<E_visitas> consultadoEdificio(string buscar)
        {
            return objConsultas.consultarEdificio(buscar);
        }

        public List<E_visitas> consultadoAula(string buscar)
        {
            return objConsultas.consultarAula(buscar);
        }

        public List<E_visitas> consultadoNombre(string buscar)
        {
            return objConsultas.consultarNombre(buscar);
        }

    }
}
