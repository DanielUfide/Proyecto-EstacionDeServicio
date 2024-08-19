using AutoFixProyectoWeb.Entities;
using AutoFixProyectoWeb.ModelDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoFixProyectoWeb.ViewModels.ClienteView
{
    public class VehiculoCreateMV
    {
        public List<VEHICULOS_DE_CLIENTE_Result> vehiculos { get; set; }
        public VehiculoEnt addVehicleModel{ get; set; }
    }
}