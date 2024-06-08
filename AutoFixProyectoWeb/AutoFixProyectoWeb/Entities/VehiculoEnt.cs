using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoFixProyectoWeb.Entities
{
    public class VehiculoEnt
    {
        public string placa { get; set; }
        public string marca { get; set; }
        public string modelo { get; set; }
        public string chasis { get; set; }
        public int id_usuario { get; set; }
        public bool estado { get; set; }
    }
}