using AutoFixProyectoWeb.Entities;
using AutoFixProyectoWeb.ModelDB;
using AutoFixProyectoWeb.Models; 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace AutoFixProyectoWeb.Controllers
{
    public class UsuariosController : Controller
    {

        UsuarioModel usuariosModel = new UsuarioModel(); 

        // GET: Usuarios
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CrearUsuario()
        {
            return View(); 
        }

        [HttpPost]
        public JsonResult validarUsuarioController(string correo, string contraseña)
        {
            UsuarioEnt usuarioValidar = new UsuarioEnt
            {
                correo = correo,
                contraseña = contraseña
            };

            var result = usuariosModel.validarUsuarioModel(usuarioValidar);

            return Json(result); 
        }
    }
}