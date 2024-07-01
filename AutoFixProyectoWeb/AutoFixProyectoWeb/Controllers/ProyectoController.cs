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

            var vm = new ProyectoClienteVM()
            {
                idProyecto = idProyecto,
                perfil = usuarioActual,
                estados = estados,
                comentarios = comentarios
            };

            return View(vm);
        }

    }
}