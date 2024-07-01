using AutoFixProyectoWeb.Entities;
using AutoFixProyectoWeb.ModelDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoFixProyectoWeb.ViewModels.ProyectoView
{
    public class ProyectoClienteVM
    {
        public int idProyecto{ get; set; }
        public UsuarioEnt perfil { get; set; }
        public List<ESTADOS_PROYECTO_DE_CLIENTE_Result> estados { get; set; }
        public List<COMENTARIOS_DE_PROYECTO_Result> comentarios { get; set; }
    }
}