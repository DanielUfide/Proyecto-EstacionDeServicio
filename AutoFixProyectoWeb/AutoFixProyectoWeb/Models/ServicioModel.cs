using AutoFixProyectoWeb.Entities;
using AutoFixProyectoWeb.ModelDB;
using AutoFixProyectoWeb.Models.Request;
using AutoFixProyectoWeb.Utils;
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

        public List<SERVICIOS_DE_PROYECTO_Result> getServiciosDeProyecto(int idProyecto)
        {
            using (var coneccion = new El_Cruce_Entities())
            {
                List<SERVICIOS_DE_PROYECTO_Result> servicios = coneccion.SERVICIOS_DE_PROYECTO(idProyecto).ToList();

                return servicios;
            }
        }

        public void addServicioAProyecto(int idServicio, int idProyecto)
        {
            using (var coneccion = new El_Cruce_Entities())
            {
                SERVICIO_PROYECTO servicio_proyecto = new SERVICIO_PROYECTO
                {
                    ID_SERVICIO = idServicio,
                    ID_PROYECTO = idProyecto,
                    FECHA = DateTime.Now,                    
                };
                var servicios = coneccion.SERVICIO_PROYECTO.Add(servicio_proyecto);

                coneccion.SaveChanges();
            }
        }

        public SERVICIO guardarServicio(SERVICIO servicio)
        {
            using (var conexion = new El_Cruce_Entities())
            {        

                var newServicio = conexion.SERVICIO.Add(servicio);                                

                conexion.SaveChanges();

                return newServicio;
            }
        }

    }
}