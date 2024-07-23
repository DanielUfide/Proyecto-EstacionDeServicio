using AutoFixProyectoWeb.Entities;
using AutoFixProyectoWeb.ModelDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoFixProyectoWeb.Models
{
    public class MecanicoModel
    {
        public List<USUARIO> getMecanicos()
        {
            using (var coneccion = new El_Cruce_Entities())
            {
                List<USUARIO> mecanicos = coneccion.USUARIO.Where(u => u.ID_ROLE == 2).ToList();

                return mecanicos;
            }
        }

        public List<PROYECTO_PIEZAS> getProyectoPiezas()
        {
            using (var coneccion = new El_Cruce_Entities())
            {
                //List<PROYECTO_PIEZAS> proyectosPiezas = coneccion.PROYECTO_PIEZAS.ToList();
                //List<PROYECTO_PIEZAS> proyectosPiezas = from proyectoPiezas in coneccion.PROYECTO_PIEZAS
                //                                        join proyecto in coneccion.PROYECTO on proyectoPiezas.ID_PROYECTO equals proyecto.ID_PROYECTO
                //                                        join inventario in coneccion.INVENTARIO on proyectoPiezas.ID_INVENTARIO equals inventario.ID_INVENTARIO
                //                                        select new
                //                                        {
                //                                            ID_VEHICULO = proyecto.ID_VEHICULO,
                //                                            NOMBRE_INVENTARIO = inventario.NOMBRE,
                //                                            CANTIDAD = proyectoPiezas.CANTIDAD
                //                                        };
                //where x.ID_INVENTARIO == inventario.id_inventario
                //select x).FirstOrDefault();

                var datos = (from proyectoPiezas in coneccion.PROYECTO_PIEZAS
                             join proyecto in coneccion.PROYECTO on proyectoPiezas.ID_PROYECTO equals proyecto.ID_PROYECTO
                             join inventario in coneccion.INVENTARIO on proyectoPiezas.ID_INVENTARIO equals inventario.ID_INVENTARIO
                             select new
                             {
                                 ID_VEHICULO = proyecto.ID_VEHICULO,
                                 NOMBRE_INVENTARIO = inventario.NOMBRE,
                                 CANTIDAD = proyectoPiezas.CANTIDAD
                             });

                List<PROYECTO_PIEZAS> inventarioList = new List<PROYECTO_PIEZAS>();

                foreach (var inventarioDB in datos)
                {
                    PROYECTO_PIEZAS INVENTARIO = new PROYECTO_PIEZAS
                    {
                        ID_VEHICULO = inventarioDB.ID_VEHICULO,
                        NOMBRE_INVENTARIO = inventarioDB.NOMBRE_INVENTARIO,
                        CANTIDAD = inventarioDB.CANTIDAD
                    };

                    inventarioList.Add(INVENTARIO);
                }

                return inventarioList;
            }
        }

        public Proyecto_PiezasEnt guardarProyectoPiezasModel(Proyecto_PiezasEnt proyectosPiezas)
        {
            using (var conexion = new El_Cruce_Entities())
            {
                PROYECTO_PIEZAS newProyectPiezas = new PROYECTO_PIEZAS
                {
                    ID_PROYECTO = proyectosPiezas.idProyecto,
                    ID_INVENTARIO = proyectosPiezas.idInventario,
                    CANTIDAD = proyectosPiezas.cantidad,
                    ID_COSTO = proyectosPiezas.idCosto,
                    ESTADO = proyectosPiezas.estado
                };
                

                conexion.PROYECTO_PIEZAS.Add(newProyectPiezas);

                conexion.SaveChanges();

                return proyectosPiezas;
            }
        }
    }
}