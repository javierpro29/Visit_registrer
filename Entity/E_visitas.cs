using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class E_visitas
    {
        private int _id;
        private string _codigo;
        private string _name;
        private string _apellido;
        private string _carrera;
        private string _correo;

        private string _edificios;
        private string _aulas;

        private DateTime _horaEntrada;
        private DateTime _horaSalida;
        private string _motivo;


        private int _edificio;
        private int _aula;



        public int Id { get => _id; set => _id = value; }
        public string Codigo { get => _codigo; set => _codigo = value; }
        public string Name { get => _name; set => _name = value; }
        public string Apellido { get => _apellido; set => _apellido = value; }
        public string Carrera { get => _carrera; set => _carrera = value; }
        public string Correo { get => _correo; set => _correo = value; }

        public string Edificios { get => _edificios; set => _edificios = value; }
        public string Aulas { get => _aulas; set => _aulas = value; }


        public DateTime HoraEntrada { get => _horaEntrada; set => _horaEntrada = value; }
        public DateTime HoraSalida { get => _horaSalida; set => _horaSalida = value; }
        public string Motivo { get => _motivo; set => _motivo = value; }
       

        public int Edifico { get => _edificio; set => _edificio = value; }
        public int Aula { get => _aula; set => _aula = value; }
    }
}
