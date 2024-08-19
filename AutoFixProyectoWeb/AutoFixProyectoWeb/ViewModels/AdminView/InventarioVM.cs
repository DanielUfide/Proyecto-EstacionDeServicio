using AutoFixProyectoWeb.ModelDB;
using AutoFixProyectoWeb.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoFixProyectoWeb.ViewModels.AdminView
{
    public class InventarioVM
    {
        public List<AutoFixProyectoWeb.Entities.CategoriaEnt> categorias { get; set; }
        public List<AutoFixProyectoWeb.Entities.InventarioEnt> inventario { get; set; }
    }
}