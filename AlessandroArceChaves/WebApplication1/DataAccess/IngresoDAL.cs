using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebApplication1.Model;

namespace WebApplication1.DataAccess
{
    public class IngresoDAL
    {
        public static int ValidarIngreso(Usuarios datos, string connectionString)
        {
            int response = 0;
            string query = "SELECT COUNT(*) FROM Usuarios " +
                           "WHERE Cedula = @Cedula AND Contraseña = @Contra";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@Cedula", datos.IdOficial);
                        cmd.Parameters.AddWithValue("@Contra", datos.Contrasenna);

                        connection.Open();
                        response = (int)cmd.ExecuteScalar();
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