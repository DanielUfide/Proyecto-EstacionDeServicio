using AutoFixProyectoWeb.Entities;
using AutoFixProyectoWeb.ModelDB;
using AutoFixProyectoWeb.Models;
using AutoFixProyectoWeb.Models.Request;
using AutoFixProyectoWeb.Models.Response;
using AutoFixProyectoWeb.Utils;
using AutoFixProyectoWeb.ViewModels;
using AutoFixProyectoWeb.ViewModels.Mecanico;
using Microsoft.Ajax.Utilities;
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

            proyectos = proyectos.Where(p => p.PROYECTO.FECHA.Date != null).ToList();

            
            var events = proyectos.Select(p => new 
            {
                title = p.PROYECTO.ID_VEHICULO,
                start = DateTime.Parse(p.PROYECTO.FECHA.ToString()).ToString("yyyy-MM-ddTHH:mm:ss"),
                description = p.SERVICIOS.Any() ?  String.Join(", ", p.SERVICIOS.Select(s => s.DESCRIPCION)) : "Sin servicios",
                client = p.PROYECTO.NOMBRE_CLIENTE

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
            List<Proyecto_Cliente> proyectosCliente = clienteModel.getProyectosCliente(usuarioActual.id_usuario);
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
                    //Version actualizada por Esteban
                    var serviciosDelProyecto = servicioModel.getServiciosDeProyecto(proyecto[i].ID_PROYECTO);
                    proyecto[i].ID_VEHICULO = proyecto[i].ID_VEHICULO + "-" + String.Join(", ", serviciosDelProyecto.Select(s => s.SERVICIO));                    

                    //Esto funcionaba cuando la relacion era 1 a 1 entre proyecto y servicio, pero ahora es muchos servicios para 1 proyecto
                    //if (proyecto[i].ID_SERVICIO == servicios[j].ID_SERVICIO)

                    //    proyecto[i].ID_VEHICULO = proyecto[i].ID_VEHICULO + " - " + servicios[j].DESCRIPCION;
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

        public ActionResult Citas()
        {
            UsuarioEnt usuarioActual = (UsuarioEnt)Session["UsuarioActual"];

            var proyectos = mecanicoModel.getProyectosMecanico(usuarioActual.id_usuario);

            proyectos = proyectos.Where(p => p.PROYECTO.FECHA != null && p.PROYECTO.FECHA.Date == DateTime.Today).ToList();

            return View(proyectos);
        }

        public ActionResult DetalleCita(int idProyecto)
        {
            var servicios = servicioModel.getServiciosDeProyecto(idProyecto);
            var productos = proyectoModel.productosDeProyecto(idProyecto);
            var inventario = inventarioModel.getInventarioModel();

            var vm = new MecanicoDetalleCitaVM
            {
                servicios = servicios,
                productos = productos,
                addServiceModel = new Servicio_Proyecto()
                {
                    idProyecto = idProyecto
                },
                
                addProductModal = new Producto_Proyecto()
                {
                    inventarios = inventario,
                    ID_PROYECTO = idProyecto
                },

            };

            return View(vm);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AddServiceToProject(Servicio_Proyecto servicio_proyecto)
        {

            SERVICIO servicio = new SERVICIO
            {
                SERVICIO1 = servicio_proyecto.SERVICIO,
                DESCRIPCION = servicio_proyecto.DESCRIPCION,
                PRECIO = servicio_proyecto.PRECIO,
                ID_ESTADO = 1                
            };
            SERVICIO newService = servicioModel.guardarServicio(servicio);

            servicioModel.addServicioAProyecto(newService.ID_SERVICIO, servicio_proyecto.idProyecto);


            return RedirectToAction("DetalleCita", "Mecanico", new { idProyecto = servicio_proyecto.idProyecto });
        }

        public ActionResult Facturacion()
        {

            UsuarioEnt usuarioActual = (UsuarioEnt)Session["UsuarioActual"];

            var proyectos = mecanicoModel.getProyectosMecanico(usuarioActual.id_usuario);

            proyectos = proyectos.Where(p => p.SERVICIOS.Count > 0 || p.PRODUCTOS.Count > 0).ToList();

            var vm = new MecanicoFacturacionVM
            {
                proyectos = proyectos,
            };

            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddProductToProject(Producto_Proyecto producto_proyecto)
        {

            PRODUCTO_PROYECTO new_producto_proyecto = new PRODUCTO_PROYECTO
            {
                ID_INVENTARIO = producto_proyecto.ID_INVENTARIO,
                ID_PROYECTO =  producto_proyecto.ID_PROYECTO,
                CANTIDAD = producto_proyecto.CANTIDAD,
                FECHA = DateTime.Now,
            };

            proyectoModel.addProductToProject(new_producto_proyecto);


            return RedirectToAction("DetalleCita", "Mecanico", new { idProyecto = producto_proyecto.ID_PROYECTO });
        }
    }
}
 