using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebApplication1.Model;

namespace WebApplication1.DataAccess
{
    public class PersonaDAL
    {
        public static List<Persona> Obtener(string connectionString)
        {
            List<Persona> listaPersonas = new List<Persona>();
            string query = "SELECT Cedula, Nombre, PrimerApellido, SegundoApellido, PaisNacimiento, " +
                           "Nacionalidad, Telefono, Edad FROM Persona WHERE Habilitado = 1";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Persona persona = new Persona(
                                reader["Cedula"].ToString(),
                                reader["Nombre"].ToString(),
                                reader["PrimerApellido"].ToString(),
                                reader["SegundoApellido"]?.ToString(),
                                reader["PaisNacimiento"].ToString(),
                                reader["Nacionalidad"].ToString(),
                                Convert.ToInt32(reader["Telefono"]),
                                Convert.ToInt32(reader["Edad"])
                            );

                            listaPersonas.Add(persona);
                        }
                    }
                }
            }
            return listaPersonas;
        }

        public static int Insertar(Persona datos, string connectionString)
        {
            int response = 0;
            string query = "INSERT INTO Persona (Cedula, Nombre, PrimerApellido, SegundoApellido, PaisNacimiento, Nacionalidad, Telefono, Edad) " +
                           "VALUES (@Cedula, @Nombre, @PrimerApellido, @SegundoApellido, @PaisNacimiento, @Nacionalidad, @Telefono, @Edad)";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.Add(new SqlParameter("@Cedula", datos.Cedula));
                        command.Parameters.Add(new SqlParameter("@Nombre", datos.Nombre));
                        command.Parameters.Add(new SqlParameter("@PrimerApellido", datos.PrimerApellido));
                        command.Parameters.Add(new SqlParameter("@SegundoApellido", datos.SegundoApellido ?? (object)DBNull.Value)); 
                        command.Parameters.Add(new SqlParameter("@PaisNacimiento", datos.PaisNacimiento));
                        command.Parameters.Add(new SqlParameter("@Nacionalidad", datos.Nacionalidad));
                        command.Parameters.Add(new SqlParameter("@Telefono", datos.Telefono));
                        command.Parameters.Add(new SqlParameter("@Edad", datos.Edad));

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

        //Se hace un borrado lógico para que la persona no se muestre el el grid
        //sin que se pierda alguna entrada o salida
        public static int Eliminar(Persona datos, string connectionString)
        {
            int response = 0;
            string query = "UPDATE Persona SET Habilitado = 0 WHERE Cedula = @Cedula";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.Add(new SqlParameter("@Cedula", datos.Cedula));

                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception)
            {
                response = -1;
            }

            return response;
        }
        public static int Editar(Persona datos, string connectionString)
        {
            int response = 0;
            string query = "UPDATE Persona SET " +
                           "Nombre = @Nombre, PrimerApellido = @PrimerApellido, " +
                           "SegundoApellido = @SegundoApellido, PaisNacimiento = @PaisNacimiento, " +
                           "Nacionalidad = @Nacionalidad, Telefono = @Telefono, " +
                           "Edad = @Edad WHERE Cedula = @Cedula";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.Add(new SqlParameter("@Cedula", datos.Cedula));
                        command.Parameters.Add(new SqlParameter("@Nombre", datos.Nombre));
                        command.Parameters.Add(new SqlParameter("@PrimerApellido", datos.PrimerApellido));
                        command.Parameters.Add(new SqlParameter("@SegundoApellido", datos.SegundoApellido ?? (object)DBNull.Value));
                        command.Parameters.Add(new SqlParameter("@PaisNacimiento", datos.PaisNacimiento));
                        command.Parameters.Add(new SqlParameter("@Nacionalidad", datos.Nacionalidad));
                        command.Parameters.Add(new SqlParameter("@Telefono", datos.Telefono));
                        command.Parameters.Add(new SqlParameter("@Edad", datos.Edad));

                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();
                        response = rowsAffected;
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