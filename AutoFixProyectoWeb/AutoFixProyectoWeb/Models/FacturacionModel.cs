using AutoFixProyectoWeb.ModelDB;
using AutoFixProyectoWeb.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;

namespace AutoFixProyectoWeb.Models
{
    public class FacturacionModel

    {
        public FacturaEnt addFacturacionModel(FacturaEnt factura)
        {
            using (var conexion = new El_Cruce_Entities())
            {
                FACTURA newFACTURA = new FACTURA
                {
                    ID_FACTURA = factura.id_factura,
                    ID_USUARIO = factura.id_usuario,
                    DETALLE = factura.detalle,
                    MONTO = factura.monto
                };

                conexion.FACTURA.Add(newFACTURA);

                conexion.SaveChanges();

                return factura;
            }


        }
        public FacturaEnt getFacturaPorIDModel(FacturaEnt factura)
        {
            using (var conexion = new El_Cruce_Entities())
            {

                FACTURA facturaDB = (from x in conexion.FACTURA
                                     where x.ID_FACTURA == factura.id_factura
                                     select x).FirstOrDefault();

                FacturaEnt newFactura = new FacturaEnt
                {
                    id_factura = facturaDB.ID_FACTURA,
                    id_usuario = facturaDB.ID_USUARIO,
                    detalle = facturaDB.DETALLE,
                    monto = (float)facturaDB.MONTO
                };

                return newFactura;
            }

        }
        public List<FacturaEnt> getFacturacionModel()
        {
            using (var conexion = new El_Cruce_Entities())
            {

                var datos = (from x in conexion.FACTURA
                             select x);

                List<FacturaEnt> facturaList = new List<FacturaEnt>();

                foreach (var facturaDB in datos)
                {
                    FacturaEnt FACTURA = new FacturaEnt
                    {
                        id_factura = facturaDB.ID_FACTURA,
                        id_usuario = facturaDB.ID_USUARIO,
                        detalle = facturaDB.DETALLE,
                        monto = (float)facturaDB.MONTO
                    };

                    facturaList.Add(FACTURA);
                }

                return facturaList;
            }

        }

        public List<DetalleFacturas> getDetalleFacturasModel()
        {
            using (var conexion = new El_Cruce_Entities())
            {
                var datos = (from x in conexion.INFORMACION_FACTURAS select x).ToList();
                List<DetalleFacturas> facturasList = new List<DetalleFacturas>();

                foreach(var factura in datos)
                {
                    facturasList.Add(new DetalleFacturas
                    {
                        id_factura = factura.ID_FACTURA,
                        detalle = factura.DETALLE,
                        monto = factura.MONTO,
                        id_usuario = factura.ID_USUARIO,
                        nombre = factura.NOMBRE,
                        telefono = factura.TELEFONO
                    }); 
                }

                return facturasList;
            }
        }

        public FacturaEnt actualizarFacturacionModel(FacturaEnt factura)
        {
            using (var conexion = new El_Cruce_Entities())
            {

                FACTURA facturaDB = (from x in conexion.FACTURA
                                     where x.ID_FACTURA == factura.id_factura
                                     select x).FirstOrDefault();

                if (facturaDB != null)
                {

                    facturaDB.ID_FACTURA = factura.id_factura;
                    facturaDB.ID_USUARIO = factura.id_usuario;
                    facturaDB.DETALLE = factura.detalle;
                    facturaDB.MONTO = factura.monto;
                    conexion.SaveChanges();
                }

                return factura;
            }

        }

        public int actualizarFacturaAdminModel(FacturaEnt factura)
        {
            using(var conexion = new El_Cruce_Entities())
            {
                FACTURA facturaDB = (from x in conexion.FACTURA where x.ID_FACTURA == factura.id_factura select x).FirstOrDefault();

                if(facturaDB != null)
                {
                    facturaDB.METODO_PAGO = factura.metodo_pago;
                    return conexion.SaveChanges(); 
                } else
                {
                    return 0;
                }

            }
        }

        public bool eliminarFacturacionModel(int id_factura)
        {
            using (var conexion = new El_Cruce_Entities())
            {
                FACTURA facturaDB = (from x in conexion.FACTURA
                                     where x.ID_FACTURA == id_factura
                                     select x).FirstOrDefault();

                if (facturaDB != null)
                {
                    conexion.FACTURA.Remove(facturaDB);
                    conexion.SaveChanges();
                }

                return true;
            }

        }
        public List<FACTURA> getFactura()
        {
            using (var coneccion = new El_Cruce_Entities())
            {
                List<FACTURA> factura = coneccion.FACTURA.ToList();

                return factura;
            }
        }
    }
}
    
   
