using AutoFixProyectoWeb.Entities;
using AutoFixProyectoWeb.ModelDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoFixProyectoWeb.Models.Request
{
    public class Producto_Proyecto : PRODUCTO_PROYECTO
    {
        public List<InventarioEnt> inventarios { get; set; }
    }
}