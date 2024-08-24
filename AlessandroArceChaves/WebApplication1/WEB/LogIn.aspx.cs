using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication1.DataAccess;
using WebApplication1.Model;

namespace WebApplication1.WEB
{
    public partial class LogIn : System.Web.UI.Page
    {
        private static string conn = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            #region Validaciones
            if (string.IsNullOrEmpty(txtUsuario.Text) || string.IsNullOrEmpty(txtPassword.Text))
            {
                MostrarMensaje("Todos los campos son obligatorios.");
                return;
            }
            if (!int.TryParse(txtUsuario.Text, out int usuarioId))
            {
                MostrarMensaje("El campo Usuario debe ser un número entero.");
                return;
            }
            #endregion

            Usuarios datos = new Usuarios(int.Parse(txtUsuario.Text), txtPassword.Text);

            var resultado = IngresoDAL.ValidarIngreso(datos, conn);

            switch (resultado)
            {
                case 0:
                    MostrarMensaje("Cédula o contraseña incorrectos.");
                    break;
                case -1:
                    MostrarMensaje("Ha ocurrido un error al conectar con la base de datos.");
                    break;
                default:
                    Session["IdOficial"] = txtUsuario.Text;
                    Response.Redirect("Persona.aspx");
                    break;
            }
        }

        public void MostrarMensaje(string mensaje)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "alert", $"alert('{mensaje}');", true);
        }

    }
}