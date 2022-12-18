using Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Entity;

namespace Data
{
    public class D_configuracion
    {

        SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["conection"].ConnectionString);

        public List<E_configuracion> mostrarEdificios()
        {
            SqlDataReader leerFila;
            SqlCommand cmd = new SqlCommand("SP_CARGAREDIFICIOS", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();

            leerFila = cmd.ExecuteReader();

            List<E_configuracion> Listar = new List<E_configuracion>();
            while (leerFila.Read())
            {
                Listar.Add(new E_configuracion
                {
                    ID_Edificio = leerFila.GetInt32(0),
                    Nombre_Edificio = leerFila.GetString(1),
                });
            }
            conexion.Close();
            leerFila.Close();
            return Listar;
        }


        public List<E_configuracion> mostrarAulas()
        {
            SqlDataReader leerFila;
            SqlCommand cmd = new SqlCommand("SP_CARGARAULA", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();

            leerFila = cmd.ExecuteReader();

            List<E_configuracion> Listar = new List<E_configuracion>();
            while (leerFila.Read())
            {
                Listar.Add(new E_configuracion
                {
                    ID_Aula = leerFila.GetInt32(0),
                    Nombre_Aula = leerFila.GetString(1),
                });
            }
            conexion.Close();
            leerFila.Close();
            return Listar;
        }

        public void insertarEdificio(E_configuracion edificio)
        {
            SqlCommand cmd = new SqlCommand("SP_INSERTAREDIFICIO", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();

            cmd.Parameters.AddWithValue("@NOMBRE", edificio.Nombre_Edificio);
            cmd.ExecuteNonQuery();
            conexion.Close();
        }

        public void insertarAula(E_configuracion aula)
        {
            SqlCommand cmd = new SqlCommand("SP_INSERTARAULA", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();

            cmd.Parameters.AddWithValue("@NOMBRE", aula.Nombre_Aula);
            cmd.ExecuteNonQuery();
            conexion.Close();
        }

        public void editarEdificio(E_configuracion edificio)
        {
            SqlCommand cmd = new SqlCommand("SP_EDITAREDIFICIO", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();

            cmd.Parameters.AddWithValue("@ID", edificio.ID_Edificio);
            cmd.Parameters.AddWithValue("@NOMBRE", edificio.Nombre_Edificio);

            cmd.ExecuteNonQuery();
            conexion.Close();
        }

        public void editarAula(E_configuracion aula)
        {
            SqlCommand cmd = new SqlCommand("SP_EDITARAULA", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();

            cmd.Parameters.AddWithValue("@ID", aula.ID_Aula);
            cmd.Parameters.AddWithValue("@NOMBRE", aula.Nombre_Aula);

            cmd.ExecuteNonQuery();
            conexion.Close();
        }

        public void eliminarEdificio(E_configuracion edificio)
        {
            SqlCommand cmd = new SqlCommand("SP_ELIMINAREDIFICIO", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();

            cmd.Parameters.AddWithValue("@ID", edificio.ID_Edificio);

            cmd.ExecuteNonQuery();
            conexion.Close();
        }

        public void eliminarAula(E_configuracion aula)
        {
            SqlCommand cmd = new SqlCommand("SP_ELIMINARAULA", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();

            cmd.Parameters.AddWithValue("@ID", aula.ID_Aula);

            cmd.ExecuteNonQuery();
            conexion.Close();
        }
    }
}
