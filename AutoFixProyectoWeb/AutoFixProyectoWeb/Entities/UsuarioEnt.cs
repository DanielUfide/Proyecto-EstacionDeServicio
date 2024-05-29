using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoFixProyectoWeb.Entities
{
    public class UsuarioEnt
    {
        public int id_usuario { get; set; }
        public RoleUsuarioEnt role { get; set; }
        public string nombre { get; set; } 
        public string correo { get; set; }

        public string contraseña { get; set; }
        public string telefono { get; set; }

    }
}