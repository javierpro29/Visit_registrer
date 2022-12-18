using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Entity;
using Entity.cache;

namespace Data
{
    public class D_usuarios
    {

        SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["conection"].ConnectionString);


        public bool login(string USERNAME, string PASSWORD)
        {
            conexion.Open();

            using (var cmd = new SqlCommand("SP_VALIDAR_USUARIO", conexion))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@USERNAME", USERNAME);
                cmd.Parameters.AddWithValue("@PASSWORD", PASSWORD);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        C_login.id = reader.GetInt32(0);
                        C_login.nombre = reader.GetString(2);
                        C_login.apellido = reader.GetString(3);
                        C_login.username = reader.GetString(6);
                        C_login.password = reader.GetString(7);
                        C_login.permisos = reader.GetString(5);


                    }

                    return true;
                }
                else
                {
                    return false;
                }
            }


        }



        public List<E_usuarios> mostarUsuarios(String buscar)
        {
            SqlDataReader leerFila;
            SqlCommand cmd = new SqlCommand("SP_BUSCARUSUARIO", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();

            cmd.Parameters.AddWithValue("@BUSCARNOMBRE", buscar);
            leerFila = cmd.ExecuteReader();

            List<E_usuarios> Listar = new List<E_usuarios>();
            while (leerFila.Read())
            {
                Listar.Add(new E_usuarios
                {
                    Id = leerFila.GetInt32(0),
                    Codigo = leerFila.GetString(1),
                    Nombre = leerFila.GetString(2),
                    Apellido = leerFila.GetString(3),
                    Fecha_nacimiento = leerFila.GetDateTime(4),
                    Permisos = leerFila.GetString(5),
                    Username = leerFila.GetString(6),
                    Password = leerFila.GetString(7),
                   
                });
            }
            conexion.Close();
            leerFila.Close();
            return Listar;
        }

        public void insertarUsuarios(E_usuarios usuario)
        {
            SqlCommand cmd = new SqlCommand("SP_INSERTARUSUARIO", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();

            cmd.Parameters.AddWithValue("@NOMBRE", usuario.Nombre);
            cmd.Parameters.AddWithValue("@APELLIDO", usuario.Apellido);
            cmd.Parameters.AddWithValue("@FECHA_NACIMIENTO", usuario.Fecha_nacimiento);
            cmd.Parameters.AddWithValue("@PERMISOS", usuario.Permisos);
            cmd.Parameters.AddWithValue("@USERNAME", usuario.Username);
            cmd.Parameters.AddWithValue("@PASSWORD", usuario.Password);

            cmd.ExecuteNonQuery();
            conexion.Close();
        }

        public void editarUsuarios(E_usuarios usuario)
        {
            SqlCommand cmd = new SqlCommand("SP_EDITANDOUSUARIO", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();

            cmd.Parameters.AddWithValue("@ID", usuario.Id);
            cmd.Parameters.AddWithValue("@NOMBRE", usuario.Nombre);
            cmd.Parameters.AddWithValue("@APELLIDO", usuario.Apellido);
            cmd.Parameters.AddWithValue("@FECHA_NACIMIENTO", usuario.Fecha_nacimiento);
            cmd.Parameters.AddWithValue("@PERMISOS", usuario.Permisos);
            cmd.Parameters.AddWithValue("@USERNAME", usuario.Username);
            cmd.Parameters.AddWithValue("@PASSWORD", usuario.Password);

            cmd.ExecuteNonQuery();
            conexion.Close();
        }

        public void eliminarUsuario(E_usuarios usuario)
        {
            SqlCommand cmd = new SqlCommand("SP_ELIMINARUSUARIO", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();

            cmd.Parameters.AddWithValue("@ID", usuario.Id);
            cmd.ExecuteNonQuery();
            conexion.Close();

        }


    }
}
