using AutoFixProyectoWeb.ModelDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoFixProyectoWeb.ViewModels.ClienteView
{
    public class ProyectoCreateVM
    {
        public List<VEHICULOS_DE_CLIENTE_Result> vehiculos { get; set; }
        public List<SERVICIO> servicios { get; set; }
        public List<USUARIO> mecanicos { get; set; }
    }
}