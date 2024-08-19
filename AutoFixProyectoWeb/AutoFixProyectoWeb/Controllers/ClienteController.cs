﻿using AutoFixProyectoWeb.Entities;
using AutoFixProyectoWeb.ModelDB;
using AutoFixProyectoWeb.Models;
using AutoFixProyectoWeb.Models.Response;
using AutoFixProyectoWeb.Utils;
using AutoFixProyectoWeb.ViewModels;
using AutoFixProyectoWeb.ViewModels.ClienteView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AutoFixProyectoWeb.Controllers
{
    [CustomAuthorize]
    public class ClienteController : Controller
    {
        ClienteModel clienteModel = new ClienteModel();
        ServicioModel servicioModel = new ServicioModel();
        MecanicoModel mecanicoModel = new MecanicoModel();
        FacturaModel facturaModel = new FacturaModel();
        VehiculoModel vehiculoModel = new VehiculoModel();

        // GET: Main
        public ActionResult Index()
        {
            UsuarioEnt usuarioActual = (UsuarioEnt)Session["UsuarioActual"];

            List<VEHICULOS_DE_CLIENTE_Result> vehiculosCliente = clienteModel.getVehiculosCliente(usuarioActual.id_usuario);
            vehiculosCliente = vehiculosCliente.Where(v => v.ESTADO).ToList();

            string placaVehiculos = string.Join(",", vehiculosCliente.Select(v => v.PLACA));
            List<Proyecto_Cliente> proyectosCliente = clienteModel.getProyectosCliente(usuarioActual.id_usuario);

            List<PROYECTO_PIEZAS> solicitudesPendientes = mecanicoModel.getProyectoPiezasUsuarioPendientes(usuarioActual.id_usuario);
            List<SERVICIO> servicios = servicioModel.getServicios();
            List<USUARIO> mecanicos = mecanicoModel.getMecanicos();

            var vm = new ClienteProfileVM() 
            { 
                perfil = usuarioActual, 
                vehiculos = vehiculosCliente, 
                proyectos = proyectosCliente,
                solicitudesPendientes = solicitudesPendientes,
                proyectoCreateVM = new ProyectoCreateVM()
                {
                    vehiculos = vehiculosCliente,
                    servicios = servicios,
                    mecanicos = mecanicos
                }
            };

            return View(vm);
        }

        public ActionResult MisFacturas()
        {
            UsuarioEnt usuarioActual = (UsuarioEnt)Session["UsuarioActual"];
       
            var facturas = facturaModel.ObtenerFacturasDeCliente(usuarioActual.id_usuario);

            facturas = facturas.Where(f => f.APROBADO).ToList();

            return View(facturas);
        }

        public ActionResult MisVehiculos()
        {
            UsuarioEnt usuarioActual = (UsuarioEnt)Session["UsuarioActual"];

            var vehiculos = clienteModel.getVehiculosCliente(usuarioActual.id_usuario);

            //Solo vehiculos activos
            vehiculos = vehiculos.Where(v => v.ESTADO).ToList();

            var vm = new VehiculoCreateMV
            {
                vehiculos = vehiculos,
                addVehicleModel = new VehiculoEnt
                {
                    id_usuario = usuarioActual.id_usuario,
                    estado = true,
                }

            };

            return View(vm);
        }


        [HttpPost]
        public ActionResult guardarVehiculoController_void(string placa, string modelo, string chasis, string marca, int id_usuario, bool estado)
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

            return RedirectToAction("MisVehiculos");
        }


        [HttpPost]
        public ActionResult actualizarVehiculoController(string placa, string modelo, string chasis, string marca, int id_usuario)
        {
            VehiculoEnt vehiculo = new VehiculoEnt
            {
                placa = placa,
                modelo = modelo,
                chasis = chasis,
                marca = marca,
                id_usuario = id_usuario,
                estado = true

            };

            var result = vehiculoModel.actualizarVehiculoModel(vehiculo);

            return RedirectToAction("MisVehiculos");
        }

        [HttpPost]
        public ActionResult actualizarEstadoVehiculoController(string placa, string modelo)
        {
            VehiculoEnt vehiculo = new VehiculoEnt
            {
                placa = placa,
                modelo = modelo
            };

            var result = vehiculoModel.actualizarEstadoVehiculoModel(vehiculo);
            return RedirectToAction("MisVehiculos");
        }
    }
}