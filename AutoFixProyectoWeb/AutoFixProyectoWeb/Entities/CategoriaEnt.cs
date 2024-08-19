using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoFixProyectoWeb.Entities
{
    public class CategoriaEnt
    {
        public int id_categoria { get; set; }
        public int id_proveedor  { get; set; }
        public string categoria { get; set; }
        public string descripcion { get; set; }
    }
}