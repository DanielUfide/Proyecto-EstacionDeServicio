using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoFixProyectoWeb.Entities
{
    public class InventarioEnt
    {

        public int id_inventario { get; set; }
        public int id_categoria { get; set; }
        public string nombre { get; set; }
        public int cantidad { get; set; }
        public float precio_compra { get; set; }
        public float precio_venta { get; set; }
    }
}