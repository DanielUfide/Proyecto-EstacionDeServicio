using AutoFixProyectoWeb.ModelDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoFixProyectoWeb.Models.Request
{
    public class Servicio_Proyecto
    {
        public string SERVICIO { get; set; }
        public string DESCRIPCION { get; set; }
        public double PRECIO { get; set; }
        public int idProyecto { get; set; }
    }
}