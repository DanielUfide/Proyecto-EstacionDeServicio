using AutoFixProyectoWeb.ModelDB;
using AutoFixProyectoWeb.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoFixProyectoWeb.Models
{
    public class InventarioModel

    {
        public InventarioEnt addInventarioModel (InventarioEnt inventario)
        {
            using (var conexion = new El_Cruce_Entities())
            {
                INVENTARIO newInventario = new INVENTARIO
                {
                    ID_INVENTARIO = inventario.id_inventario,
                    ID_CATEGORIA = inventario.id_categoria,
                    NOMBRE = inventario.nombre,
                    CANTIDAD = inventario.cantidad,
                    PRECIO_COMPRA = inventario.precio_compra,
                    PRECIO_VENTA = inventario.precio_venta
                };

    conexion.INVENTARIO.Add(newInventario);

                conexion.SaveChanges();

                return inventario;
            }


        }

        public InventarioEnt getInventarioPorIDModel(InventarioEnt inventario)
        { 
            using (var conexion = new El_Cruce_Entities())
            {

                INVENTARIO inventarioDB = (from x in conexion.INVENTARIO
                                           where x.ID_INVENTARIO == inventario.id_inventario
                                       select x).FirstOrDefault();

                InventarioEnt Inventario = new InventarioEnt
                {
                    id_inventario = inventarioDB.ID_INVENTARIO,
                    id_categoria = inventarioDB.ID_CATEGORIA,
                    nombre = inventarioDB.NOMBRE,
                    cantidad = inventarioDB.CANTIDAD,
                    precio_compra = (float)inventarioDB.PRECIO_COMPRA,
                    precio_venta = (float)inventarioDB.PRECIO_VENTA,
                };

                return Inventario;
            }

        }
        public List<InventarioEnt> getInventarioModel()
        {
            using (var conexion = new El_Cruce_Entities())
            {

                var datos = (from x in conexion.INVENTARIO
                             select x);

                List<InventarioEnt> inventarioList = new List<InventarioEnt>();

                foreach (var inventarioDB in datos)
                {
                    InventarioEnt INVENTARIO = new InventarioEnt
                    {
                        id_inventario = inventarioDB.ID_INVENTARIO,
                        id_categoria = inventarioDB.ID_CATEGORIA,
                        nombre = inventarioDB.NOMBRE,
                        cantidad = inventarioDB.CANTIDAD,
                        precio_compra = (float)inventarioDB.PRECIO_COMPRA,
                        precio_venta = (float)inventarioDB.PRECIO_VENTA,
                    };

                    inventarioList.Add(INVENTARIO);
                }

                return inventarioList;
            }

        }

        public InventarioEnt actualizarInventarioModel(InventarioEnt inventario)
        {
            using (var conexion = new El_Cruce_Entities())
            {

                INVENTARIO inventarioDB = (from x in conexion.INVENTARIO
                                           where x.ID_INVENTARIO == inventario.id_inventario
                                       select x).FirstOrDefault();

                if (inventarioDB != null)
                {
                    inventarioDB.ID_INVENTARIO = inventario.id_inventario;
                    inventarioDB.ID_CATEGORIA = inventario.id_categoria;
                    inventarioDB.NOMBRE = inventario.nombre;
                    inventarioDB.CANTIDAD = inventario.cantidad;
                    inventarioDB.PRECIO_COMPRA = inventario.precio_compra;
                    inventarioDB.PRECIO_VENTA = inventario.precio_venta;
                    conexion.SaveChanges();
                }

                return inventario;
            }

        }

        public List<INVENTARIO> getInventario()
        {
            using (var coneccion = new El_Cruce_Entities())
            {
                List<INVENTARIO> inventario = coneccion.INVENTARIO.ToList();

                return inventario;
            }
        }

    }
}
