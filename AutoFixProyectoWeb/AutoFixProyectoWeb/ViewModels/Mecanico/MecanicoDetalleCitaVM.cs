using AutoFixProyectoWeb.Models.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoFixProyectoWeb.ViewModels.Mecanico
{
    public class MecanicoDetalleCitaVM
    {        
        public List<ModelDB.SERVICIOS_DE_PROYECTO_Result> servicios { get; set; }
        public Servicio_Proyecto addServiceModel { get; set; }
    }
}