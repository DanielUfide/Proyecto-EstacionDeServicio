using AutoFixProyectoWeb.Entities;
using AutoFixProyectoWeb.Models;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AutoFixProyectoWeb.Controllers
{
    public class MecanicoController : Controller
    {
        MecanicoModel mecanicoModel = new MecanicoModel();

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
    }
}
 