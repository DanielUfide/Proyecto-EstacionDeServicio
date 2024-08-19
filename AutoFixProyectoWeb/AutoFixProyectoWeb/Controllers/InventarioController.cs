 using AutoFixProyectoWeb.Entities;
using AutoFixProyectoWeb.ModelDB;
using AutoFixProyectoWeb.Models;
using AutoFixProyectoWeb.ViewModels.AdminView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;

namespace AutoFixProyectoWeb.Controllers
{
    public class InventarioController : Controller
    {

        InventarioModel inventarioModel = new InventarioModel();
        CategoriaModel categoriaModel = new CategoriaModel();
        public ActionResult ConsultaInventario()
        {
            var result = new InventarioVM { 
              categorias = categoriaModel.getCategoriaModel(),
              inventario = inventarioModel.getInventarioModel()
            };
          //  var result = inventarioModel.getInventarioModel();
            return View(result);
        }

        [HttpPost]
        public JsonResult guardarInventarioController(int id_inventario, int id_categoria, string nombre, int cantidad, double precio_compra, double precio_venta)
        {
            InventarioEnt inventario = new InventarioEnt 
            {
                id_inventario = id_inventario,
                id_categoria = id_categoria,
                nombre = nombre,
                cantidad = cantidad,
                precio_compra = (float)precio_compra,
                precio_venta = (float)precio_venta
            };

            var result = inventarioModel.addInventarioModel(inventario);

            return Json(result);
        }


        [HttpPost]
        public JsonResult actualizarInventarioController(int id_inventario, int id_categoria, string nombre, int cantidad, double precio_compra, double precio_venta)
        {
            InventarioEnt inventario = new InventarioEnt
            {
                id_inventario = id_inventario,
                id_categoria = id_categoria,
                nombre = nombre,
                cantidad = cantidad,
                precio_compra = (float)precio_compra,
                precio_venta = (float)precio_venta
            };

            var result = inventarioModel.actualizarInventarioModel(inventario);

            return Json(result);
        }
        [HttpPost]
        public JsonResult getInventarioPorIDModel(int id_inventario)
        {
            InventarioEnt inventario = new InventarioEnt
            {
                id_inventario = id_inventario
            };

            var result = inventarioModel.getInventarioPorIDModel(inventario);
            return Json(result);
        }
        [HttpGet]
        public JsonResult getInventarioController()
        {
            var result = inventarioModel.getInventarioModel();
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult eliminarInventarioController(int id_inventario)
        {
         
            var result = inventarioModel.eliminarInventarioModel(id_inventario);

            return Json(result);
        }

    }
}