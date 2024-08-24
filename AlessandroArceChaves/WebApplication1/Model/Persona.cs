using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Model
{
    public class Persona
    {
        public string Cedula { get; set; }
        public string Nombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public string PaisNacimiento { get; set; }
        public string Nacionalidad { get; set; }
        public int Telefono { get; set; }
        public int Edad { get; set; }
        public Persona(string cedula, string nombre, string primerApellido, string segundoApellido, string paisNacimiento, string nacionalidad, int telefono, int edad)
        {
            Cedula = cedula;
            Nombre = nombre;
            PrimerApellido = primerApellido;
            SegundoApellido = segundoApellido;
            PaisNacimiento = paisNacimiento;
            Nacionalidad = nacionalidad;
            Telefono = telefono;
            Edad = edad;
        }
    }

}