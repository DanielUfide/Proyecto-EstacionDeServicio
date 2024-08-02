using AutoFixProyectoWeb.Entities;
using AutoFixProyectoWeb.ModelDB;
using AutoFixProyectoWeb.Models;
using AutoFixProyectoWeb.Utils;
using AutoFixProyectoWeb.ViewModels.ProyectoView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace AutoFixProyectoWeb.Controllers
{
    [CustomAuthorize]
    public class ProyectoController : Controller
    {
        ProyectoModel proyectoModel = new ProyectoModel();
        MecanicoModel mecanicoModel = new MecanicoModel();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ProyectoEnt proyecto)
        {
            UsuarioEnt usuarioActual = (UsuarioEnt)Session["UsuarioActual"];

            proyectoModel.guardarProyecto(proyecto, usuarioActual);
            
            return RedirectToAction("Index", "Cliente");
        }

        public ActionResult ProyectoCliente(int idProyecto)
        {
            UsuarioEnt usuarioActual = (UsuarioEnt)Session["UsuarioActual"];
            var estados = proyectoModel.getEstadosProyectoDeCliente(idProyecto);

            var comentarios = proyectoModel.getComentariosProyecto(idProyecto);

            List<PROYECTO_PIEZAS> solicitudesPendientes = mecanicoModel.getProyectoPiezasUsuarioPendientes(usuarioActual.id_usuario);

            List<PROYECTO_PIEZAS> solicitudesHistorial = mecanicoModel.getProyectoPiezasUsuarioTodos(usuarioActual.id_usuario);

            var vm = new ProyectoClienteVM()
            {
                idProyecto = idProyecto,
                perfil = usuarioActual,
                estados = estados,
                comentarios = comentarios,
                solicitudesPendientes = solicitudesPendientes,
                solicitudesHistorial = solicitudesHistorial
            };

            return View(vm);
        }

        [HttpPost]
        public JsonResult getSolicitudByIDController(int id)
        {
            Proyecto_PiezasEnt proyectoPiezas = new Proyecto_PiezasEnt 
            {
                idSolicitud = id
            };

            var result = proyectoModel.getSolicitudByIDController(proyectoPiezas); 
            return Json(result);
        }

        [HttpPost]
        public JsonResult actualizarEstadoSolicitudController(int id, int estadoSolicitud)
        {
            Proyecto_PiezasEnt proyectoPiezas = new Proyecto_PiezasEnt
            {
                idSolicitud = id,
                estado = estadoSolicitud
            };

            var result = proyectoModel.actualizarEstadoProyectoPiezas(proyectoPiezas);

            return Json(result);
        }

    }
}