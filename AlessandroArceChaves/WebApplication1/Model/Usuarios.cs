using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Model
{
    public class Usuarios
    {
        public int IdOficial { get; set; }
        public string Contrasenna { get; set; }

        public Usuarios(int idOficial, string contrasena)
        {
            IdOficial = idOficial;
            Contrasenna = contrasena;
        }

    }
}