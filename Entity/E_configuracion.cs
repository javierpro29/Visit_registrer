using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class E_configuracion
    {

        private int e_id;
        private string e_nombre;

        private int a_id;
        private string a_nombre;

        public int ID_Edificio { get => e_id; set => e_id = value; }
        public string Nombre_Edificio { get => e_nombre; set => e_nombre = value; }

        public int ID_Aula { get => a_id; set => a_id = value; }
        public string Nombre_Aula { get => a_nombre; set => a_nombre = value; }
    }
}
