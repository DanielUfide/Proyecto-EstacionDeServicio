using AutoFixProyectoWeb.Entities;
using AutoFixProyectoWeb.ModelDB;
using AutoFixProyectoWeb.Utils;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity.Core.Objects.DataClasses;
using System.Linq;
using System.Web;

namespace AutoFixProyectoWeb.Models
{
    public class ProyectoModel
    {
        public void guardarProyecto(ProyectoEnt proyectoEnt, UsuarioEnt usuarioActual)
        {

            int idEstadoProyecto = (int) GlobalAccess.EstadoProyecto.InicioDelProyecto; //Inicio del Proyecto

            using (var conexion = new El_Cruce_Entities())
            {
                PROYECTO newProyect = new PROYECTO
                {
                    ID_VEHICULO = proyectoEnt.idVehiculo,
                    ID_ESTADO_PROYECTO = idEstadoProyecto,
                    ID_SERVICIO = proyectoEnt.idServicio,
                    ID_MECANICO = proyectoEnt.idMecanico

                };

                newProyect = conexion.PROYECTO.Add(newProyect);

                //Agregar Historial de estado

                HISTORIAL_ESTADOS histEstado = new HISTORIAL_ESTADOS
                {
                    ID_PROYECTO = newProyect.ID_PROYECTO,
                    ID_ESTADO = idEstadoProyecto,
                    FECHA = DateTime.Now,
                };

                conexion.HISTORIAL_ESTADOS.Add(histEstado);

                //Agregar Comentario
                COMENTARIOS_PROYECTO comentario = new COMENTARIOS_PROYECTO
                {
                    ID_USUARIO = usuarioActual.id_usuario,
                    ID_PROYECTO = newProyect.ID_PROYECTO,
                    COMENTARIO = proyectoEnt.comentario,
                    FECHA = DateTime.Now,
                };

                conexion.COMENTARIOS_PROYECTO.Add(comentario);

                conexion.SaveChanges();
            }
        }

        public List<ESTADOS_PROYECTO_DE_CLIENTE_Result> getEstadosProyectoDeCliente(int idProyecto)
        {
            using (var conexion = new El_Cruce_Entities())
            {
                List<ESTADOS_PROYECTO_DE_CLIENTE_Result> estados = conexion.ESTADOS_PROYECTO_DE_CLIENTE(idProyecto).ToList();

                return estados;
            }
        }

        public List<COMENTARIOS_DE_PROYECTO_Result> getComentariosProyecto(int idProyecto)
        {
            using (var conexion = new El_Cruce_Entities())
            {
                List<COMENTARIOS_DE_PROYECTO_Result> comentarios = conexion.COMENTARIOS_DE_PROYECTO(idProyecto).ToList();

                return comentarios;
            }
        }

        public List<PROYECTO> getProyectos()
        {
            using (var conexion = new El_Cruce_Entities())
            {
                List<PROYECTO> proyecto = conexion.PROYECTO.ToList();

                return proyecto;
            }
        }

        public PROYECTO_PIEZAS getSolicitudByIDController(Proyecto_PiezasEnt proyectoPiezasP)
        {
            using (var conexion = new El_Cruce_Entities())
            {

                var datos = (from proyectoPiezas in conexion.PROYECTO_PIEZAS
                             join proyecto in conexion.PROYECTO on proyectoPiezas.ID_PROYECTO equals proyecto.ID_PROYECTO
                             join inventario in conexion.INVENTARIO on proyectoPiezas.ID_INVENTARIO equals inventario.ID_INVENTARIO
                             join estado in conexion.ESTADO_PROYECTO_PIEZAS on proyectoPiezas.ESTADO equals estado.ID_ESTADO
                             where proyectoPiezasP.idSolicitud == proyectoPiezas.ID_SOLICITUD
                             select new
                             {
                                 ID_VEHICULO = proyecto.ID_VEHICULO,
                                 NOMBRE_INVENTARIO = inventario.NOMBRE,
                                 CANTIDAD = proyectoPiezas.CANTIDAD,
                                 ID_SOLICITUD = proyectoPiezas.ID_SOLICITUD,
                                 ESTADO_DESCRIPCION = estado.ESTADO

                             });

                if (datos == null) return null;


                List<PROYECTO_PIEZAS> inventarioList = new List<PROYECTO_PIEZAS>();

                foreach (var inventarioDB in datos)
                {
                    PROYECTO_PIEZAS INVENTARIO = new PROYECTO_PIEZAS
                    {
                        ID_VEHICULO = inventarioDB.ID_VEHICULO,
                        NOMBRE_INVENTARIO = inventarioDB.NOMBRE_INVENTARIO,
                        CANTIDAD = inventarioDB.CANTIDAD,
                        ID_SOLICITUD = inventarioDB.ID_SOLICITUD,
                        ESTADO_DESCRIPCION = inventarioDB.ESTADO_DESCRIPCION
                    };

                    inventarioList.Add(INVENTARIO);
                }

                return inventarioList[0];
                
            }

        }

        public Proyecto_PiezasEnt actualizarEstadoProyectoPiezas(Proyecto_PiezasEnt proyecto)
        {
            using (var conexion = new El_Cruce_Entities())
            {

                PROYECTO_PIEZAS proyectoPiezasDB = (from x in conexion.PROYECTO_PIEZAS
                                       where x.ID_SOLICITUD == proyecto.idSolicitud
                                       select x).FirstOrDefault();

                if (proyectoPiezasDB != null)
                {
                    proyectoPiezasDB.ESTADO = proyecto.estado;
                    conexion.SaveChanges();
                }


                return proyecto;
            }

        }

    }
}