using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebApplication1.Model;

namespace WebApplication1.DataAccess
{
    public class SalidasDAL
    {
        public static List<Salidas> Obtener(string connectionString)
        {
            List<Salidas> listaSalidas = new List<Salidas>();
            string query = "SELECT s.IdSalida, s.Cedula, s.Destino, s.Fecha, s.PuntoSalida, s.IdOficial, o.Nombre " +
                           "FROM Salidas s " +
                           "LEFT JOIN Oficial o ON o.IdOficial = s.IdOficial";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Salidas salida = new Salidas(
                                Convert.ToInt32(reader["IdSalida"]),
                                reader["Cedula"].ToString(),
                                reader["Destino"].ToString(),
                                Convert.ToDateTime(reader["Fecha"]),
                                reader["PuntoSalida"].ToString(),
                                Convert.ToInt32(reader["IdOficial"])
                            );

                            listaSalidas.Add(salida);
                        }
                    }
                }
            }
            return listaSalidas;
        }

        public static int Insertar(Salidas datos, string connectionString)
        {
            int response = 0;
            string query = "INSERT INTO Salidas (Cedula, Origen, Fecha, Destino, IdOficial) " +
                           "VALUES (@Cedula, @Origen, @Fecha, @Destino, @IdOficial)";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.Add(new SqlParameter("@Cedula", datos.Cedula));
                        command.Parameters.Add(new SqlParameter("@Origen", datos.Destino));
                        command.Parameters.Add(new SqlParameter("@Fecha", datos.Fecha));
                        command.Parameters.Add(new SqlParameter("@PuntoSalida", datos.PuntoSalida));
                        command.Parameters.Add(new SqlParameter("@IdOficial", datos.IdOficial));

                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception)
            {
                response = -1;
            }

            return response;
        }

    }
}