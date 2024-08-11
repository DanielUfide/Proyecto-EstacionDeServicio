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

        public ActionResult administrarUsuarios()
        {
            var usuarios = usuariosModel.listaUsuarios();
            var roles = usuariosModel.listaRoles();

            UserRolesEnt listaUsuariosRoles = new UserRolesEnt
            {
                Users = usuarios,
                Roles = roles
            };

            return View(listaUsuariosRoles);
        }

        [HttpGet]
        public JsonResult optenerUsuario(int idUsuario)
        {
            UsuarioEnt usuario = new UsuarioEnt
            {
                id_usuario = idUsuario,
            };

            usuario = usuariosModel.optenerUsuario(usuario);
            return Json(usuario, JsonRequestBehavior.AllowGet);
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

        [HttpPost]
        public JsonResult editarUsuario(int idUsuario, int roleUsuario, string nombre, string correo, string telefono)
        {
            UsuarioEnt usuarioEditar = new UsuarioEnt
            {
                id_usuario = idUsuario,
                nombre = nombre,
                correo = correo,
                telefono = telefono,
                role = new RoleUsuarioEnt
                {
                    id_role = roleUsuario,
                }
            };

            return Json(usuariosModel.editarUsuario(usuarioEditar));


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