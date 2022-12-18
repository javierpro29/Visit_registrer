using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using Data;

namespace Business
{
    public class B_configuracion
    {

        E_configuracion entConfiguracion = new E_configuracion();
        D_configuracion objConfiguracion = new D_configuracion();


        public List<E_configuracion> mostrarEdificios()
        {
            return objConfiguracion.mostrarEdificios();
        }

        public List<E_configuracion> mostrarAulas()
        {
            return objConfiguracion.mostrarAulas();
        }

        public void insertarEdificio(E_configuracion edificio)
        {
            objConfiguracion.insertarEdificio(edificio);
        }

        public void insertarAula(E_configuracion aula)
        {
            objConfiguracion.insertarAula(aula);
        }

        public void editarEdificio(E_configuracion edificio)
        {
            objConfiguracion.editarEdificio(edificio);
        }

        public void editarAula(E_configuracion aula)
        {
            objConfiguracion.editarAula(aula);
        }

        public void eliminarEdificio(E_configuracion  edificio)
        {
            objConfiguracion.eliminarEdificio(edificio);
        }

        public void eliminarAula(E_configuracion aula)
        {
            objConfiguracion.eliminarAula(aula);
        }

    }
}
