using AutoFixProyectoWeb.ModelDB;
using AutoFixProyectoWeb.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoFixProyectoWeb.Models
{
    public class AdminModel
    {
        public List<Historial_Vehiculo> getHistorialVehiculo(string placa)
        {
            List<Historial_Vehiculo> historial_vehiculos = new List<Historial_Vehiculo>();

            using (var conexion = new El_Cruce_Entities())
            {
                List<HISTORIAL_DE_VEHICULO_Result> historial = conexion.HISTORIAL_DE_VEHICULO(placa).ToList();

                foreach (var hist in historial)
                {
                    var servicios = conexion.SERVICIOS_DE_PROYECTO(hist.ID_PROYECTO).ToList();

                    Historial_Vehiculo historial_vehiculo = new Historial_Vehiculo();
                    historial_vehiculo.HISTORIAL = hist;
                    historial_vehiculo.SERVICIOS = servicios;

                    historial_vehiculos.Add(historial_vehiculo);
                }

                return historial_vehiculos;
            }
        }
    }
}