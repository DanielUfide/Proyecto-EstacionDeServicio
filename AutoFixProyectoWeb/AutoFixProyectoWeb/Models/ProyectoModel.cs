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
    }
}