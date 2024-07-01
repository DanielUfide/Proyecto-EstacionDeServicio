using AutoFixProyectoWeb.ModelDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoFixProyectoWeb.Models
{
    public class ServicioModel
    {
        public List<SERVICIO> getServicios()
        {
            using (var coneccion = new El_Cruce_Entities())
            {
                List<SERVICIO> servicios = coneccion.SERVICIO.ToList();

                return servicios;
            }
        }
    }
}