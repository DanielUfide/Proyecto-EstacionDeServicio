using AutoFixProyectoWeb.Entities;
using AutoFixProyectoWeb.ModelDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoFixProyectoWeb.Models
{
    public class ClienteModel
    {
        public List<VEHICULOS_DE_CLIENTE_Result> getVehiculosCliente(int idUsuario)
        {
            using (var conexion = new El_Cruce_Entities())
            {
                List<VEHICULOS_DE_CLIENTE_Result> vehiculos = conexion.VEHICULOS_DE_CLIENTE(idUsuario).ToList();

                return vehiculos;
            }

        }
        public List<PROYECTOS_DE_CLIENTE_Result> getProyectosCliente(string vehiculosCliente)
        {
            using (var conexion = new El_Cruce_Entities())
            {
                List<PROYECTOS_DE_CLIENTE_Result> proyectos = conexion.PROYECTOS_DE_CLIENTE(vehiculosCliente).ToList();

                return proyectos;
            }
        }
    }
}