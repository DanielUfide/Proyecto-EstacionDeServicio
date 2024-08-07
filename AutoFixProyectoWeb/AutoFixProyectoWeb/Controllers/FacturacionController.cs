﻿using AutoFixProyectoWeb.Entities;
using AutoFixProyectoWeb.ModelDB;
using AutoFixProyectoWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;

namespace AutoFixProyectoWeb.Controllers
{
    public class FacturacionController : Controller
    {

        FacturacionModel facturaModel = new FacturacionModel();

        public ActionResult ConsultaFactura()
        {
            var result = facturaModel.getFacturacionModel();
            return View(result);
        }

        [HttpPost]
        public JsonResult guardarController(int id_factura, int id_usuario, string detalle, double monto)
        {
            FacturaEnt factura = new FacturaEnt
            {
                id_factura = id_factura,
                id_usuario = id_usuario,
                detalle = detalle,
                monto = (float)monto
            };

            var result = facturaModel.addFacturacionModel(factura);

            return Json(result);
        }


        [HttpPost]
        public JsonResult actualizarFacturaController(int id_factura, int id_usuario, string detalle, double monto)
        {
             FacturaEnt factura = new FacturaEnt
            {
                id_factura = id_factura,
                id_usuario = id_usuario,
                detalle = detalle,
                monto = (float)monto
            };
            var result = facturaModel.actualizarFacturacionModel(factura);

            return Json(result);
        }
        [HttpPost]
        public JsonResult getFacturaPorIDModel(int id_factura)
        {
            FacturaEnt factura = new FacturaEnt
            {
                id_factura = id_factura
            };

            var result = facturaModel.addFacturacionModel(factura);
            return Json(result);
        }
        [HttpGet]
        public JsonResult getFacturaController()
        {
            var result = facturaModel.getFacturacionModel();
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult eliminarFacturaController(int id_factura)
        {
         
            var result = facturaModel.eliminarFacturacionModel(id_factura);

            return Json(result);
        }

    }
}