using AutoFixProyectoWeb.Models;
using AutoFixProyectoWeb.ViewModels.AdminView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AutoFixProyectoWeb.Controllers
{
    public class AdminController : Controller
    {
        AdminModel adminModel = new AdminModel();
        VehiculoModel vehiculoModel = new VehiculoModel();

        // GET: Admin

        [HttpGet]
      
        public ActionResult Index()
        {

            var vm = new AdminHistoryVM { };

            return View("Historial", vm);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult GetHistorial(string placa = null)
        {

            var vehiculo = vehiculoModel.getVehiculoPorPlacaModel(new Entities.VehiculoEnt { placa = placa }); 

            var historial = adminModel.getHistorialVehiculo(placa);

            var vm = new AdminHistoryVM
            {
                notFound = vehiculo == null ? true : false,
                historial = historial
            };

            return View("Historial", vm);
        }

    }
}