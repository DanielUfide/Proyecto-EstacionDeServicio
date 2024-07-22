using AutoFixProyectoWeb.ModelDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoFixProyectoWeb.ViewModels.AdminView
{
    public class AdminHistoryVM
    {
        public bool notFound { get; set; }
        public List<HISTORIAL_DE_VEHICULO_Result> historial { get; set; }
    }
}