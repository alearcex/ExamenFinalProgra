using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Model
{
    public class Salidas
    {
        public int IdSalida { get; set; }
        public string Cedula { get; set; }
        public string Destino { get; set; }
        public DateTime Fecha { get; set; }
        public string PuntoSalida { get; set; }
        public int IdOficial { get; set; }
        public string Oficial { get; set; }


        public Salidas(int idSalida, string cedula, string destino, DateTime fecha, string puntoSalida, int idOficial)
        {
            IdSalida = idSalida;
            Cedula = cedula;
            Destino = destino;
            Fecha = fecha;
            PuntoSalida = puntoSalida;
            IdOficial = idOficial;
        }
    }
}