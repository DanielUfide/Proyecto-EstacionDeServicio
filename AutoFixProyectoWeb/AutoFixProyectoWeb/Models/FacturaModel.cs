using AutoFixProyectoWeb.ModelDB;
using AutoFixProyectoWeb.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OfficeOpenXml;
using System.IO;
using System.Web.Mvc;

namespace AutoFixProyectoWeb.Models
{
    public class FacturaModel
    {
        public void CrearFactura(List<SERVICIOS_DE_PROYECTO_Result> servicios, List<PRODUCTO_PROYECTO> productos, USUARIO cliente, USUARIO mecanico, int idProyecto)
        {
            using (var conexion = new El_Cruce_Entities())
            {
                var newFactura = conexion.FACTURA_CABECERA.Add(new FACTURA_CABECERA
                {
                    NOMBRE = GlobalAccess.FacturacionData.Nombre,
                    DIRECCION = GlobalAccess.FacturacionData.Direccion,
                    NUMERO = GenerationCode.GenerarCodigoDe8Digitos(),
                    FECHA = DateTime.Now,
                    ID_CLIENTE = cliente.ID_USUARIO,
                    NOMBRE_CLIENTE = cliente.NOMBRE,
                    NOMBRE_MECANICO = mecanico.NOMBRE,
                    ID_PROYECTO = idProyecto,
                    TOTAL = 0
                });

                decimal total = 0;

                foreach (var servicio in servicios)
                {
                    var fact_detalle_servicio = new FACTURA_DETALLE
                    {
                        TIPO = "Servicio",
                        DESCRIPCION = servicio.DESCRIPCION,
                        CANTIDAD = 1,
                        PRECIO = (decimal)servicio.PRECIO * 1,
                        ID_FACTURA_CABECERA = newFactura.ID_FACTURA_CABECERA
                    };

                    conexion.FACTURA_DETALLE.Add(fact_detalle_servicio);

                    total += (decimal)fact_detalle_servicio.PRECIO;
                }

                foreach (var producto in productos)
                {
                    var fact_detalle_producto = new FACTURA_DETALLE
                    {
                        TIPO = "Producto / Pieza",
                        DESCRIPCION = producto.INVENTARIO.NOMBRE,
                        CANTIDAD = (int) producto.CANTIDAD,
                        PRECIO = (decimal) producto.INVENTARIO.PRECIO_VENTA * (int) producto.CANTIDAD,
                        ID_FACTURA_CABECERA = newFactura.ID_FACTURA_CABECERA
                    };

                    conexion.FACTURA_DETALLE.Add(fact_detalle_producto);

                    total += (decimal)fact_detalle_producto.PRECIO;
                }

                newFactura.TOTAL = total;


                var proyecto = conexion.PROYECTO.FirstOrDefault(p => p.ID_PROYECTO == idProyecto);

                proyecto.ESTADO_FACTURA = (int) GlobalAccess.EstadoFactura.Pendiente;

                conexion.SaveChanges();
            }
        }
        public List<FACTURA_CABECERA> ObtenerFacturasPendienes()
        {
            using (var conexion = new El_Cruce_Entities())
            {
                return conexion.FACTURA_CABECERA.Where(f => !f.APROBADO).ToList();
            }
        }

        public void AprobarFactura(int idFactura, int idProyecto)
        {
            using (var conexion = new El_Cruce_Entities())
            {
                var factura = conexion.FACTURA_CABECERA.FirstOrDefault(f => f.ID_FACTURA_CABECERA == idFactura);
                factura.APROBADO = true;

                var proyecto = conexion.PROYECTO.FirstOrDefault(f => f.ID_PROYECTO== idProyecto);
                proyecto.ESTADO_FACTURA = (int) GlobalAccess.EstadoFactura.Aprobada;

                conexion.SaveChanges();
            }
        }

        public List<FACTURA_CABECERA> ObtenerFacturasDeCliente(int idCliente)
        {
            using (var conexion = new El_Cruce_Entities())
            {
                return conexion.FACTURA_CABECERA.Where(f => f.ID_CLIENTE == idCliente).ToList();
            }
        }


        public ExcelWorkbook GenerarFacturaParaDescargar(ExcelWorkbook workbook, int idFactura)
        {
            using (var conexion = new El_Cruce_Entities())
            {                
                var factura = conexion.FACTURA_CABECERA.FirstOrDefault(f => f.ID_FACTURA_CABECERA == idFactura);
                var detalle = conexion.FACTURA_DETALLE.Where(f => f.ID_FACTURA_CABECERA == factura.ID_FACTURA_CABECERA).ToList();


                var worksheet = workbook.Worksheets[0]; // Obtén la primera hoja

                // Datos de empresa
                worksheet.Cells["C4"].Value = "Nombre: " + GlobalAccess.FacturacionData.Nombre;
                worksheet.Cells["C5"].Value = "Direccion: " + GlobalAccess.FacturacionData.Direccion;

                worksheet.Cells["F4"].Value = factura.NOMBRE_CLIENTE;
                worksheet.Cells["F5"].Value = factura.FECHA;
                worksheet.Cells["F6"].Value = factura.NUMERO;
                worksheet.Cells["F7"].Value = "S./ " + detalle.Sum(d => d.PRECIO).ToString();

                int row = 12;
                foreach (var det in detalle)
                {
                    worksheet.Cells["C" + row].Value = det.TIPO.ToString();
                    worksheet.Cells["D" + row].Value = det.DESCRIPCION.ToString();
                    worksheet.Cells["E" + row].Value = det.CANTIDAD.ToString();
                    worksheet.Cells["F" + row].Value = "S./ " + det.PRECIO.ToString();

                    row++;
                }

                return workbook;
            }
        }
    }
}