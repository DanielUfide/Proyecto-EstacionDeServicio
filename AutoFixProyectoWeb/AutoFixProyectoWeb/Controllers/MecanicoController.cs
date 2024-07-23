using AutoFixProyectoWeb.Entities;
using AutoFixProyectoWeb.ModelDB;
using AutoFixProyectoWeb.Models;
using AutoFixProyectoWeb.Utils;
using AutoFixProyectoWeb.ViewModels;
using AutoFixProyectoWeb.ViewModels.ClienteView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace AutoFixProyectoWeb.Controllers
{
    [CustomAuthorize]
    public class MecanicoController : Controller
    {
        ClienteModel clienteModel = new ClienteModel();
        ServicioModel servicioModel = new ServicioModel();
        MecanicoModel mecanicoModel = new MecanicoModel();
        InventarioModel inventarioModel = new InventarioModel();
        ProyectoModel proyectoModel = new ProyectoModel();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Proyecto_PiezasEnt proyectoPiezas)
        {
            UsuarioEnt usuarioActual = (UsuarioEnt)Session["UsuarioActual"];

            proyectoPiezas.idCosto = 1;
            proyectoPiezas.estado = 1;
            mecanicoModel.guardarProyectoPiezasModel(proyectoPiezas);

            return RedirectToAction("Index", "Mecanico");
        }

        // GET: Main
        public ActionResult Index()
        {
            UsuarioEnt usuarioActual = (UsuarioEnt)Session["UsuarioActual"];

            List<VEHICULOS_DE_CLIENTE_Result> vehiculosCliente = clienteModel.getVehiculosCliente(usuarioActual.id_usuario);

            string placaVehiculos = string.Join(",", vehiculosCliente.Select(v => v.PLACA));
            List<PROYECTOS_DE_CLIENTE_Result> proyectosCliente = clienteModel.getProyectosCliente(placaVehiculos);
            List<PROYECTO_PIEZAS> proyectos = mecanicoModel.getProyectoPiezas();
            List<SERVICIO> servicios = servicioModel.getServicios();
            List<USUARIO> mecanicos = mecanicoModel.getMecanicos();
            List<INVENTARIO> inventario = inventarioModel.getInventario();
            List<PROYECTO> proyecto = proyectoModel.getProyectos();

            for (int i = 0; i < proyecto.Count; i++) 
            {
                for (int j = 0; j< servicios.Count; j++) 
                {
                    if (proyecto[i].ID_SERVICIO == servicios[j].ID_SERVICIO)
                    
                        proyecto[i].ID_VEHICULO = proyecto[i].ID_VEHICULO + " - " + servicios[j].DESCRIPCION;
                }
            }


            var vm = new MecanicoVM()
            {
                perfil = usuarioActual,
                vehiculos = vehiculosCliente,
                proyectos = proyectos,
                inventario = inventario,
                proyecto = proyecto
                /*mecanicoVM = new MecanicoVM()
                {
                    vehiculos = vehiculosCliente,
                    //servicios = servicios,
                    //mecanicos = mecanicos,
                    inventario = inventario,
                    proyectos = proyecto
                }*/
            };

            return View(vm);
        }
    }
}