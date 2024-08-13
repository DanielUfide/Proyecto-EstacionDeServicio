using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoFixProyectoWeb.Entities
{
    public class DetalleFacturas
    {
        public int id_factura { get; set; }
        public string detalle { get; set; }
        public double monto { get; set; }
        public int id_usuario { get; set; }
        public string nombre { get; set; }
        public string telefono { get; set; }
        public string metodo_pago { get; set; }

    }
}