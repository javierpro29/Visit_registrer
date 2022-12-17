using Entity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class D_consultas
    {

        SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["conection"].ConnectionString);


        public List<E_visitas> consultarEdificio(string buscar)
        {
            SqlDataReader leerFila;
            SqlCommand cmd = new SqlCommand("SP_BUSCARVISITAEDIFICIO", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();

            cmd.Parameters.AddWithValue("@BUSCAREDIFICIO", buscar);
            leerFila = cmd.ExecuteReader();

            List<E_visitas> Listar = new List<Entity.E_visitas>();
            while (leerFila.Read())
            {
                Listar.Add(new Entity.E_visitas
                {
                    Id = leerFila.GetInt32(0),
                    Codigo = leerFila.GetString(1),
                    Name = leerFila.GetString(2),
                    Apellido = leerFila.GetString(3),
                    Carrera = leerFila.GetString(4),
                    Correo = leerFila.GetString(5),


                    Edificios = leerFila.GetString(6),
                    Aulas = leerFila.GetString(7),


                    HoraEntrada = leerFila.GetDateTime(8),
                    HoraSalida = leerFila.GetDateTime(9),
                    Motivo = leerFila.GetString(10),

                    Edifico = leerFila.GetInt32(11),
                    Aula = leerFila.GetInt32(12)
                });
            }
            conexion.Close();
            leerFila.Close();
            return Listar;
        }


        public List<E_visitas> consultarAula(string buscar)
        {
            SqlDataReader leerFila;
            SqlCommand cmd = new SqlCommand("SP_BUSCARVISITAAULA", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();

            cmd.Parameters.AddWithValue("@BUSCARAULA", buscar);
            leerFila = cmd.ExecuteReader();

            List<E_visitas> Listar = new List<Entity.E_visitas>();
            while (leerFila.Read())
            {
                Listar.Add(new Entity.E_visitas
                {
                    Id = leerFila.GetInt32(0),
                    Codigo = leerFila.GetString(1),
                    Name = leerFila.GetString(2),
                    Apellido = leerFila.GetString(3),
                    Carrera = leerFila.GetString(4),
                    Correo = leerFila.GetString(5),


                    Edificios = leerFila.GetString(6),
                    Aulas = leerFila.GetString(7),


                    HoraEntrada = leerFila.GetDateTime(8),
                    HoraSalida = leerFila.GetDateTime(9),
                    Motivo = leerFila.GetString(10),

                    Edifico = leerFila.GetInt32(11),
                    Aula = leerFila.GetInt32(12)
                });
            }
            conexion.Close();
            leerFila.Close();
            return Listar;
        }



        public List<E_visitas> consultarNombre(string buscar)
        {
            SqlDataReader leerFila;
            SqlCommand cmd = new SqlCommand("SP_BUSCARVISITANOMBRE", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();

            cmd.Parameters.AddWithValue("@BUSCARNOMBRE", buscar);
            leerFila = cmd.ExecuteReader();

            List<E_visitas> Listar = new List<Entity.E_visitas>();
            while (leerFila.Read())
            {
                Listar.Add(new Entity.E_visitas
                {
                    Id = leerFila.GetInt32(0),
                    Codigo = leerFila.GetString(1),
                    Name = leerFila.GetString(2),
                    Apellido = leerFila.GetString(3),
                    Carrera = leerFila.GetString(4),
                    Correo = leerFila.GetString(5),


                    Edificios = leerFila.GetString(6),
                    Aulas = leerFila.GetString(7),


                    HoraEntrada = leerFila.GetDateTime(8),
                    HoraSalida = leerFila.GetDateTime(9),
                    Motivo = leerFila.GetString(10),

                    Edifico = leerFila.GetInt32(11),
                    Aula = leerFila.GetInt32(12)
                });
            }
            conexion.Close();
            leerFila.Close();
            return Listar;
        }

    }
}
