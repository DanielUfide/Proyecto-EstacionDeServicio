using AutoFixProyectoWeb.Entities;
using AutoFixProyectoWeb.ModelDB;
using AutoFixProyectoWeb.Models.Response;
using AutoFixProyectoWeb.ViewModels.ClienteView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoFixProyectoWeb.ViewModels
{
    public class ClienteProfileVM
    {        
        public UsuarioEnt perfil { get; set; }
        public List<VEHICULOS_DE_CLIENTE_Result> vehiculos { get; set; }
        public List<Proyecto_Cliente> proyectos{ get; set; }
        public ProyectoCreateVM proyectoCreateVM { get; set; }
        public List<PROYECTO_PIEZAS> solicitudesPendientes { get; set; }
    }
}