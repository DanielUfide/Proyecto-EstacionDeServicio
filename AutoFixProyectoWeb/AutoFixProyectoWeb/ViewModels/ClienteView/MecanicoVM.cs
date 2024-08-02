using AutoFixProyectoWeb.Entities;
using AutoFixProyectoWeb.ModelDB;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;

namespace AutoFixProyectoWeb.ViewModels
{
    public class MecanicoVM
    {
        public UsuarioEnt perfil { get; set; }
        public List<VEHICULOS_DE_CLIENTE_Result> vehiculos { get; set; }
        //public List<PROYECTOS_DE_CLIENTE_Result> proyectos { get; set; }
        public List<PROYECTO_PIEZAS> proyectos { get; set; }
        //public List<PROYECTO> proyectos { get; set; }

        public List<PROYECTO> proyecto { get; set; }

        public List<PROYECTO_PIEZAS> solicitudesAprobadas { get; set; }
        public List<PROYECTO_PIEZAS> solicitudesRechazadas { get; set; }
        public List<PROYECTO_PIEZAS> solicitudesPendientes { get; set; }
        public MecanicoVM mecanicoVM { get; set; }
        public List<INVENTARIO> inventario { get; set; }

        public string test {  get; set; }
        //public ProyectoCreateVM proyectoCreateVM { get; set; }
    }
}