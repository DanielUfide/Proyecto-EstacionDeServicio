using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoFixProyectoWeb.Utils
{
    public class GlobalAccess
    {
        public enum EstadoProyecto
        {
            SolicitudACliente = 1,
            InicioDelProyecto,
            EvaluacionInicial,
            ReparacionEnProceso,
            EsperandoRepuesto,
            ListoParaEntrega,
            Entregado
        }

        public static class FacturacionData
        {
            public const string Nombre = "El Cruce";
            public const string Direccion = "San Marcos de Tarrazu";
        }

        public enum EstadoFactura
        {
            NoFacturada,
            Pendiente,
            Aprobada,
             
        }
    }
}