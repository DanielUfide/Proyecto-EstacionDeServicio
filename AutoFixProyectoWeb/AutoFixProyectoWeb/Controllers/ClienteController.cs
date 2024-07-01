using AutoFixProyectoWeb.Entities;
using AutoFixProyectoWeb.ModelDB;
using AutoFixProyectoWeb.Models;
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

        // GET: Main
        public ActionResult Index()
        {
            UsuarioEnt usuarioActual = (UsuarioEnt)Session["UsuarioActual"];

            List<VEHICULOS_DE_CLIENTE_Result> vehiculosCliente = clienteModel.getVehiculosCliente(usuarioActual.id_usuario);

            string placaVehiculos = string.Join(",", vehiculosCliente.Select(v => v.PLACA));
            List<PROYECTOS_DE_CLIENTE_Result> proyectosCliente = clienteModel.getProyectosCliente(placaVehiculos);

            List<SERVICIO> servicios = servicioModel.getServicios();
            List<USUARIO> mecanicos = mecanicoModel.getMecanicos();

            var vm = new ClienteProfileVM() 
            { 
                perfil = usuarioActual, 
                vehiculos = vehiculosCliente, 
                proyectos = proyectosCliente,
                proyectoCreateVM = new ProyectoCreateVM()
                {
                    vehiculos = vehiculosCliente,
                    servicios = servicios,
                    mecanicos = mecanicos
                }
            };

            return View(vm);
        }
    }
}