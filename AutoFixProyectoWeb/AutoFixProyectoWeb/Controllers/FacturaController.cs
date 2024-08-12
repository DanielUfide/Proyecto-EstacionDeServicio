using AutoFixProyectoWeb.Models;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AutoFixProyectoWeb.Controllers
{

    public class FacturaController : Controller
    {
        ServicioModel servicioModel = new ServicioModel();
        ProyectoModel proyectoModel = new ProyectoModel();
        FacturaModel facturaModel = new FacturaModel();
        public ActionResult GenerarFactura(int idProyecto)
        {
            var servicios = servicioModel.getServiciosDeProyecto(idProyecto);
            var cliente = proyectoModel.getClienteDeProyecto(idProyecto);
            var mecanico = proyectoModel.getMecanicoDeProyecto(idProyecto);

            facturaModel.CrearFactura(servicios, cliente, mecanico, idProyecto);

            // Lógica para generar la factura

            return RedirectToAction("Facturacion", "Mecanico");
        }

        [HttpGet]

        public ActionResult AprobarFactura(int idFactura, int idProyecto)
        {
            facturaModel.AprobarFactura(idFactura, idProyecto);

            return RedirectToAction("SolicitudesFacturas", "Admin");
        }
   
        public ActionResult DescargarFactura(int idFactura)
        {
            // Configurar el contexto de la licencia
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            string plantillaPath = Server.MapPath("~/Plantillas/plantilla_factura.xlsx");
            string tempPath = Path.GetTempFileName() + ".xlsx";
            System.IO.File.Copy(plantillaPath, tempPath, true);

            using (var package = new ExcelPackage(new FileInfo(tempPath)))
            {
                var workbook = package.Workbook;
                workbook = facturaModel.GenerarFacturaParaDescargar(workbook, idFactura);

                // Guardar los cambios en el archivo temporal
                package.Save();
            }

            // Descargar el archivo clonado
            byte[] fileBytes = System.IO.File.ReadAllBytes(tempPath);
            string fileName = "Factura_" + idFactura + ".xlsx";

            // Eliminar el archivo temporal
            System.IO.File.Delete(tempPath);

            return File(fileBytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", fileName);
        }
    }
}