using AutoFixProyectoWeb.ModelDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoFixProyectoWeb.Models.Response
{
    public class Proyecto_Cliente
    {
        public PROYECTOS_DE_CLIENTE_Result PROYECTO { get; set; }
        public List<SERVICIOS_DE_PROYECTO_Result> SERVICIOS { get; set; }        

    }
 
}