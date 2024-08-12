using AutoFixProyectoWeb.ModelDB;
using AutoFixProyectoWeb.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoFixProyectoWeb.ViewModels.AdminView
{
    public class AdminHistoryVM
    {
        public bool notFound { get; set; }
        public List<Historial_Vehiculo> historial { get; set; }
    }
}