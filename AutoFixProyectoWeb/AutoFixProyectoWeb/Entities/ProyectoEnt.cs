using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoFixProyectoWeb.Entities
{
    public class ProyectoEnt
    {
        public string idVehiculo { get; set; }
        public int idMecanico { get; set; } 
        public string comentario { get; set; }
        public DateTime fecha{ get; set; }
    }
}