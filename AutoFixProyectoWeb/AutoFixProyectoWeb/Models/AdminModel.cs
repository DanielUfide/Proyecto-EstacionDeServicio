using AutoFixProyectoWeb.ModelDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoFixProyectoWeb.Models
{
    public class AdminModel
    {
        public List<HISTORIAL_DE_VEHICULO_Result> getHistorialVehiculo(string placa)
        {
            using (var conexion = new El_Cruce_Entities())
            {
                List<HISTORIAL_DE_VEHICULO_Result> historial = conexion.HISTORIAL_DE_VEHICULO(placa).ToList();

                return historial;
            }
        }
    }
}