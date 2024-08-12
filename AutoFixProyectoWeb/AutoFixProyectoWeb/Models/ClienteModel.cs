using AutoFixProyectoWeb.Controllers;
using AutoFixProyectoWeb.Entities;
using AutoFixProyectoWeb.ModelDB;
using AutoFixProyectoWeb.Models.Response;
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
        public List<Proyecto_Cliente> getProyectosCliente(int id_cliente)
        {
            List<Proyecto_Cliente> proyecto_clientes = new List<Proyecto_Cliente>();

            using (var conexion = new El_Cruce_Entities())
            {

                List<PROYECTOS_DE_CLIENTE_Result> proyectos = conexion.PROYECTOS_DE_CLIENTE(id_cliente).ToList();
                
                foreach (var proyecto in proyectos)
                {
                    var servicios = conexion.SERVICIOS_DE_PROYECTO(proyecto.ID_PROYECTO).ToList();

                    Proyecto_Cliente proyecto_cliente = new Proyecto_Cliente();
                    proyecto_cliente.PROYECTO = proyecto;
                    proyecto_cliente.SERVICIOS = servicios;

                    proyecto_clientes.Add(proyecto_cliente);
                }

                return proyecto_clientes;
            }
        }
    }
}