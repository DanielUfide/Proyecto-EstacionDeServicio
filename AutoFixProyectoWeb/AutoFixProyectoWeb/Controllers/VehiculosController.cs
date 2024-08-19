using AutoFixProyectoWeb.Entities;
using AutoFixProyectoWeb.ModelDB;
using AutoFixProyectoWeb.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace AutoFixProyectoWeb.Controllers
{
    public class VehiculosController : Controller
    {
        VehiculoModel vehiculoModel = new VehiculoModel();

        // GET: Usuarios
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult guardarVehiculoController(string placa, string modelo, string chasis, string marca, int id_usuario, bool estado)
        {
            VehiculoEnt vehiculo = new VehiculoEnt
            {
                placa = placa,
                modelo = modelo,
                chasis = chasis,
                marca = marca,
                id_usuario = id_usuario,
                estado = estado
            };

            var result = vehiculoModel.guardarVehiculoModel(vehiculo);

            return Json(result);
        }


        [HttpPost]
        public JsonResult actualizarVehiculoController(string placa, string modelo, string chasis, string marca, int id_usuario)
        {
            VehiculoEnt vehiculo = new VehiculoEnt
            {
                placa = placa,
                modelo = modelo,
                chasis = chasis,
                marca = marca,
                id_usuario= id_usuario,
                estado = true
                
            };

            var result = vehiculoModel.actualizarVehiculoModel(vehiculo);

            return Json(result);
        }

        [HttpPost]
        public JsonResult actualizarEstadoVehiculoController(string placa, string modelo)
        {
            VehiculoEnt vehiculo = new VehiculoEnt
            {
                placa = placa,
                modelo = modelo
            };

            var result = vehiculoModel.actualizarEstadoVehiculoModel(vehiculo);

            return Json(result);
        }

        [HttpGet]
        public JsonResult getTodosVehiculoController()
        {
            var result = vehiculoModel.getTodosVehiculoModel();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult getVehiculoPorPlacaController(string placa)
        {
            VehiculoEnt vehiculo = new VehiculoEnt
            {
                placa = placa
            };

            var result = vehiculoModel.getVehiculoPorPlacaModel(vehiculo);
            return Json(result);
        }

    }
}
