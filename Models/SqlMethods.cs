using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Semana5.Models
{
    public class SqlMethods
    {
        public SqlConnection ConexionDB()
        {
            SqlConnection connection;
            try
            {
                // Cadena de conexión a la base de datos
                string connectionString = "Data Source=tiusr28pl.cuc-carrera-ti.ac.cr\\MSSQLSERVER2019;Initial Catalog=TrabajoGrupo04;" +
                                          "User ID=Grupo04;Password=1k911Grn@";

                // Crea una conexión a la base de datos
                connection = new SqlConnection(connectionString);
            }
            catch (Exception)
            {
                throw;
            }
            return connection;
        }//end conection




        public bool SubirImagen( string titulo , string tipo , byte[] imagenByte)
        {
            SqlConnection con = ConexionDB();
            bool valido = false;
            try
            {
                string sql = string.Format("INSERT INTO Grupo04.Tarjetas " +
                    "(titulo, tipo, imagen) VALUES (@titulo, @tipo, @imagen)");


                SqlCommand cmd = new SqlCommand(sql, con);
                con.Open();

                cmd.Parameters.AddWithValue("@titulo", titulo);
                cmd.Parameters.AddWithValue("@tipo", tipo);
                cmd.Parameters.AddWithValue("@imagen", imagenByte);

                //SqlDataReader reader = cmd.ExecuteReader();
                int x = cmd.ExecuteNonQuery();

                if (x > 0)
                {
                    valido = true;
                }
                //reader.Close();


            }
            catch (Exception)
            {
                throw;
            }
            finally { con.Close(); }
            return valido;

        }//end subir imagen


        public List<Tarjeta> CargarImagenes()
        {
            SqlConnection con = ConexionDB();
            List<Tarjeta> listaTarjetas = new List<Tarjeta>();

            try
            {
                string sql = string.Format("SELECT * FROM Grupo04.Tarjetas");

                SqlCommand cmd = new SqlCommand(sql, con);
                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    string titulo = Convert.ToString(reader.GetString(0));
                    string tipo = Convert.ToString(reader.GetString(1));
                    byte[] imagenBytes = (byte[])reader["imagen"];
                    string ImagenURL64 = "data:image/jpg;base64," + Convert.ToBase64String(imagenBytes);

                    Tarjeta tarjeta = new Tarjeta(titulo, tipo, ImagenURL64);
                    listaTarjetas.Add(tarjeta);
                }
                reader.Close();
            }
            catch (Exception)
            {
                throw;
            }

            return listaTarjetas;
        }





    }
}