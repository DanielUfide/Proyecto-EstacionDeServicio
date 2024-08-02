using AutoFixProyectoWeb.Entities;
using AutoFixProyectoWeb.ModelDB;
using AutoFixProyectoWeb.Models;
using AutoFixProyectoWeb.ViewModels;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace AutoFixProyectoWeb.Controllers
{
    public class MecanicoController : Controller
    {
        MecanicoModel mecanicoModel = new MecanicoModel();
        ClienteModel clienteModel = new ClienteModel();
        ServicioModel servicioModel = new ServicioModel();
        InventarioModel inventarioModel = new InventarioModel();
        ProyectoModel proyectoModel = new ProyectoModel();


        // GET: Mecanico
        public ActionResult Index()
        {
            return View("Calendario");
        }

        [HttpGet]
        public JsonResult GetEvents()
        {
            UsuarioEnt usuarioActual = (UsuarioEnt)Session["UsuarioActual"];

            //var events = new List<object>
            //{
            //    new { title = "Evento 1", start = "2024-07-20T10:00:00" },
            //    new { title = "Evento 2", start = "2024-07-22T14:00:00" },
            //    new { title = "Evento 3", start = "2024-07-25T09:00:00" }
            //};

            var proyectos = mecanicoModel.getProyectosMecanico(usuarioActual.id_usuario);

            proyectos = proyectos.Where(p => p.FECHA.HasValue).ToList();

            var events = proyectos.Select(p => new 
            {
                title=p.SERVICIO, 
                start = DateTime.Parse(p.FECHA.ToString()).ToString("yyyy-MM-ddTHH:mm:ss"),
                vehicle =p.ID_VEHICULO,
                description = p.DESCRIPCION,
                client = p.NOMBRE_CLIENTE

            }).ToList();

            return Json(events, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Proyecto_PiezasEnt proyectoPiezas)
        {
            UsuarioEnt usuarioActual = (UsuarioEnt)Session["UsuarioActual"];

            proyectoPiezas.idCosto = 1;
            proyectoPiezas.estado = 3;
            mecanicoModel.guardarProyectoPiezasModel(proyectoPiezas);

            return RedirectToAction("Index", "Mecanico");
        }

        // GET: Main
        public ActionResult Piezas()
        {
            UsuarioEnt usuarioActual = (UsuarioEnt)Session["UsuarioActual"];

            List<VEHICULOS_DE_CLIENTE_Result> vehiculosCliente = clienteModel.getVehiculosCliente(usuarioActual.id_usuario);

            string placaVehiculos = string.Join(",", vehiculosCliente.Select(v => v.PLACA));
            List<PROYECTOS_DE_CLIENTE_Result> proyectosCliente = clienteModel.getProyectosCliente(placaVehiculos);
            List<PROYECTO_PIEZAS> proyectos = mecanicoModel.getProyectoPiezas();

            List<PROYECTO_PIEZAS> solicitudesAprobadas = mecanicoModel.getProyectoPiezasUsuarioAprobadasM(usuarioActual.id_usuario);
            List<PROYECTO_PIEZAS> solicitudesRehazadas = mecanicoModel.getProyectoPiezasUsuarioRechazadasM(usuarioActual.id_usuario);
            List<PROYECTO_PIEZAS> solicitudesPendientes = mecanicoModel.getProyectoPiezasUsuarioPendientesM(usuarioActual.id_usuario);

            List<SERVICIO> servicios = servicioModel.getServicios();
            List<USUARIO> mecanicos = mecanicoModel.getMecanicos();
            List<INVENTARIO> inventario = inventarioModel.getInventario();
            List<PROYECTO> proyecto = proyectoModel.getProyectos();

            for (int i = 0; i < proyecto.Count; i++)
            {
                for (int j = 0; j < servicios.Count; j++)
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
                proyecto = proyecto,
                solicitudesAprobadas = solicitudesAprobadas,
                solicitudesRechazadas = solicitudesRehazadas,
                solicitudesPendientes = solicitudesPendientes,
                test = "prueba123"
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
 