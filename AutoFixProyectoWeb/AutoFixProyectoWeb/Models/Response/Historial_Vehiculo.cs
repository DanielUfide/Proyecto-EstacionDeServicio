using AutoFixProyectoWeb.ModelDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoFixProyectoWeb.Models.Response
{
    public class Historial_Vehiculo
    {
        public HISTORIAL_DE_VEHICULO_Result HISTORIAL { get; set; }
        public List<SERVICIOS_DE_PROYECTO_Result> SERVICIOS { get; set; }
    }
}