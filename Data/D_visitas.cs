using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using System.Data;

namespace Data
{
    public class D_visitas
    {

        SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["conection"].ConnectionString);


        public List<E_visitas> listarVisitas(string buscar)
        {
            SqlDataReader leerFila;
            SqlCommand cmd = new SqlCommand("SP_BUSCARVISITAEDIFICIO", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();

            cmd.Parameters.AddWithValue("@BUSCAREDIFICIO", buscar);
            leerFila = cmd.ExecuteReader();

            List<E_visitas> Listar = new List<Entity.E_visitas>();
            while(leerFila.Read())
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


        public void insertarVisita(E_visitas visita)
        {
            SqlCommand cmd = new SqlCommand("SP_INSERTARVISITA", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();

            cmd.Parameters.AddWithValue("@NOMBRE", visita.Name);
            cmd.Parameters.AddWithValue("@APELLIDO", visita.Apellido);
            cmd.Parameters.AddWithValue("@CAREER", visita.Carrera);
            cmd.Parameters.AddWithValue("@CORREO", visita.Correo);
            cmd.Parameters.AddWithValue("@EDIFICIO", visita.Edifico);
            cmd.Parameters.AddWithValue("@AULA", visita.Aula);
            cmd.Parameters.AddWithValue("@HORA_ENTRADA", visita.HoraEntrada);
            cmd.Parameters.AddWithValue("@HORA_SALIDA", visita.HoraSalida);
            cmd.Parameters.AddWithValue("@MOTIVO", visita.Motivo);

            cmd.ExecuteNonQuery();
            conexion.Close();
        }


        public void editarVisitas(E_visitas visita)
        {
            SqlCommand cmd = new SqlCommand("SP_EDITARVISITA", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();

            cmd.Parameters.AddWithValue("@ID", visita.Id);
            cmd.Parameters.AddWithValue("@NOMBRE", visita.Name);
            cmd.Parameters.AddWithValue("@APELLIDO", visita.Apellido);
            cmd.Parameters.AddWithValue("@CAREER", visita.Carrera);
            cmd.Parameters.AddWithValue("@CORREO", visita.Correo);
            cmd.Parameters.AddWithValue("@EDIFICIO", visita.Edifico);
            cmd.Parameters.AddWithValue("@AULA", visita.Aula);
            cmd.Parameters.AddWithValue("@HORA_ENTRADA", visita.HoraEntrada);
            cmd.Parameters.AddWithValue("@HORA_SALIDA", visita.HoraSalida);
            cmd.Parameters.AddWithValue("@MOTIVO", visita.Motivo);

            cmd.ExecuteNonQuery();
            conexion.Close();
        }


        public void eliminarVisitas(E_visitas visita)
        {
            SqlCommand cmd = new SqlCommand("SP_ELIMINARVISITA", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();

            cmd.Parameters.AddWithValue("@ID", visita.Id);
            cmd.ExecuteNonQuery();
            conexion.Close();

        }

    }
}
