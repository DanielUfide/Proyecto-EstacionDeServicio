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

        public ActionResult perfil() {
            return View();
        }

        public ActionResult restablecerContraseña()
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

        [HttpPost]
        public JsonResult crearUsuarioController(int roleUsuario, string nombre, string correo, string contraseña, string telefono)
        {
            UsuarioEnt usuario = new UsuarioEnt
            {
                nombre = nombre,
                correo = correo,
                contraseña = contraseña,
                telefono = telefono,
                role = new RoleUsuarioEnt
                {
                    id_role = roleUsuario,
                }
            };

            var result = usuariosModel.crearUsuario(usuario);

            return Json(result);

        }

        [HttpPost]
        public JsonResult restaurarContraseñaController(string correo)
        {
            UsuarioEnt usuario = new UsuarioEnt
            {
                correo = correo,
            }; 

            var result  = usuariosModel.restaurarContraseña(usuario);

            return Json(result);
        }

        [HttpGet]
        public ActionResult cerrarSession()
        {
            Session.Clear();
            Session.Abandon();

            return RedirectToAction("Index", "Home");
        }
    }
}