using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoFixProyectoWeb.Entities
{
    public class UserRolesEnt
    {
        public IEnumerable<UsuarioEnt> Users { get; set; }
        public IEnumerable<RoleUsuarioEnt> Roles { get; set; }
    }
}