using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Model
{
    public class Entradas 
    {
        public int IdEntrada { get; set; }
        public string Cedula { get; set; }
        public string Origen { get; set; }
        public DateTime Fecha { get; set; }
        public string PuntoEntrada { get; set; }
        public int IdOficial { get; set; }


        public Entradas(int idEntrada, string cedula, string origen, DateTime fecha, string puntoEntrada, int idOficial)
        {
            IdEntrada = idEntrada;
            Cedula = cedula;
            Origen = origen;
            Fecha = fecha;
            PuntoEntrada = puntoEntrada;
            IdOficial = idOficial;
        }

    }
}