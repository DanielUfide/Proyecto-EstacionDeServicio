﻿using AutoFixProyectoWeb.Entities;
using AutoFixProyectoWeb.ModelDB;
using AutoFixProyectoWeb.Models;
using AutoFixProyectoWeb.Utils;
using AutoFixProyectoWeb.ViewModels.AdminView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AutoFixProyectoWeb.Controllers
{
    [CustomAuthorize]
    public class AdminController : Controller
    {
        AdminModel adminModel = new AdminModel();
        VehiculoModel vehiculoModel = new VehiculoModel();
        FacturaModel facturaModel = new FacturaModel();
        InventarioModel inventarioModel = new InventarioModel();
        UsuarioModel usuariosModel = new UsuarioModel();

        public ActionResult ConsultaInventario()
        {
            var result = inventarioModel.getInventarioModel();
            return View(result);
        }

        public ActionResult AdministrarUsuarios()
        {
            var usuarios = usuariosModel.listaUsuarios();
            var roles = usuariosModel.listaRoles();

            UserRolesEnt listaUsuariosRoles = new UserRolesEnt
            {
                Users = usuarios,
                Roles = roles
            };

            return View(listaUsuariosRoles);
        }



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
        [HttpGet]

        public ActionResult SolicitudesFacturas()
        {

            var facturasPendientes = facturaModel.ObtenerFacturasPendienes();

            return View(facturasPendientes);
        }       

    }
}