using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoFixProyectoWeb.Entities
{
    public class FacturaEnt
    {

        public int id_factura { get; set; }
        public int id_usuario { get; set; }
        public string detalle { get; set; }
        public float monto { get; set; }
        public string metodo_pago { get; set; }
        public bool cancelado { get; set; }

    }
}