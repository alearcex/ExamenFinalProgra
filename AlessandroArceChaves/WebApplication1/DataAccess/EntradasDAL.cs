using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebApplication1.Model;

namespace WebApplication1.DataAccess
{
    public class EntradasDAL
    {
        public static List<Entradas> Obtener(string connectionString)
        {
            List<Entradas> listaEntradas = new List<Entradas>();
            string query = "SELECT e.Cedula, e.Destino, e.Fecha, e.PuntoSalida, e.IdOficial, o.Nombre " +
                           "FROM Salidas e " +
                           "INNER JOIN Oficial o ON o.IdOficial = e.IdOficial";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Entradas entrada = new Entradas(
                                Convert.ToInt32(reader["IdSalida"]),
                                reader["Cedula"].ToString(),
                                reader["Destino"].ToString(),
                                Convert.ToDateTime(reader["Fecha"]),
                                reader["PuntoSalida"].ToString(),
                                Convert.ToInt32(reader["IdOficial"])
                            );

                            listaEntradas.Add(entrada);
                        }
                    }
                }
            }
            return listaEntradas;
        }

        public static int Insertar(Entradas datos, string connectionString)
        {
            int response = 0;
            string query = "INSERT INTO Entradas (Cedula, Origen, Fecha, PuntoEntrada, IdOficial) " +
                           "VALUES (@Cedula, @Origen, @Fecha, @PuntoEntrada, @IdOficial)";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.Add(new SqlParameter("@Cedula", datos.Cedula));
                        command.Parameters.Add(new SqlParameter("@Origen", datos.Origen));
                        command.Parameters.Add(new SqlParameter("@Fecha", datos.Fecha));
                        command.Parameters.Add(new SqlParameter("@PuntoEntrada", datos.PuntoEntrada));
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