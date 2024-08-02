using AutoFixProyectoWeb.Entities;
using AutoFixProyectoWeb.ModelDB;
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
        public List<PROYECTOS_DE_CLIENTE_Result> proyectos{ get; set; }
        public ProyectoCreateVM proyectoCreateVM { get; set; }
<<<<<<< Updated upstream
        public MecanicoVM mecanicoVM { get; set; }
=======
        public List<PROYECTO_PIEZAS> solicitudesPendientes { get; set; }
>>>>>>> Stashed changes
    }
}