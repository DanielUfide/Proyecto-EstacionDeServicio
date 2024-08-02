using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoFixProyectoWeb.Entities
{
    public class Proyecto_PiezasEnt
    {
        public int idProyecto { get; set; }
        public int idInventario { get; set; }
        public int idCosto { get; set; }
        public int cantidad { get; set; }
        public int estado { get; set; }
        public int idSolicitud { get; set; }
    }
}