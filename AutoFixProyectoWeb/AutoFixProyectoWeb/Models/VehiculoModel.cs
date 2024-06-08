using AutoFixProyectoWeb.Entities;
using AutoFixProyectoWeb.ModelDB;
using Microsoft.Ajax.Utilities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Net.Http;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Contexts;
using System.Security.Cryptography;
using System.Web;
using System.Web.ModelBinding;
using System.Web.Mvc;

namespace AutoFixProyectoWeb.Models
{
    public class VehiculoModel
    {
        public VehiculoEnt guardarVehiculoModel(VehiculoEnt vehiculo)
        {
            using (var conexion = new El_Cruce_Entities())
            {
                VEHICULO newVehiculo = new VEHICULO
                {
                    PLACA = vehiculo.placa,
                    MARCA = vehiculo.marca,
                    MODELO = vehiculo.modelo,
                    CHASIS = vehiculo.chasis,
                    ID_USUARIO = vehiculo.id_usuario,
                    ESTADO = vehiculo.estado
                };

                conexion.VEHICULO.Add(newVehiculo);

                conexion.SaveChanges();

                return vehiculo;
            }
        }

        public VehiculoEnt getVehiculoPorPlacaModel(VehiculoEnt vehiculo)
        {
            using (var conexion = new El_Cruce_Entities())
            {

                VEHICULO vehiculoDB = (from x in conexion.VEHICULO
                                       where x.PLACA == vehiculo.placa
                                       select x).FirstOrDefault();

                VehiculoEnt Vehiculo = new VehiculoEnt
                {
                    placa = vehiculoDB.PLACA,
                    marca = vehiculoDB.MARCA,
                    modelo = vehiculoDB.MODELO,
                    chasis = vehiculoDB.CHASIS,
                    id_usuario = vehiculoDB.ID_USUARIO,
                    estado = vehiculoDB.ESTADO
                };

                return Vehiculo;
            }

        }

        public List<VehiculoEnt> getTodosVehiculoModel()
        {
            using (var conexion = new El_Cruce_Entities())
            {

                var datos = (from x in conexion.VEHICULO
                             select x);

                List<VehiculoEnt> vehiculosList = new List<VehiculoEnt>();

                foreach (var vehiculoDB in datos) 
                {
                    VehiculoEnt Vehiculo = new VehiculoEnt
                    {
                        placa = vehiculoDB.PLACA,
                        marca = vehiculoDB.MARCA,
                        modelo = vehiculoDB.MODELO,
                        chasis = vehiculoDB.CHASIS,
                        id_usuario = vehiculoDB.ID_USUARIO,
                        estado = vehiculoDB.ESTADO
                    };

                    vehiculosList.Add(Vehiculo);
                }
                
                return vehiculosList;
            }

        }

        public VehiculoEnt actualizarVehiculoModel(VehiculoEnt vehiculo) 
        {
            using (var conexion = new El_Cruce_Entities())
            {

                VEHICULO vehiculoDB = (from x in conexion.VEHICULO
                                     where x.PLACA == vehiculo.placa
                                     select x).FirstOrDefault();

                if(vehiculoDB != null) 
                {
                    vehiculoDB.PLACA = vehiculo.placa;
                    vehiculoDB.MARCA = vehiculo.marca;
                    vehiculoDB.MODELO = vehiculo.modelo;
                    vehiculoDB.CHASIS = vehiculo.chasis;
                    vehiculoDB.ID_USUARIO = vehiculo.id_usuario;
                    vehiculoDB.ESTADO = vehiculo.estado;
                    conexion.SaveChanges();
                }

                return vehiculo;
            }

        }

        public VehiculoEnt actualizarEstadoVehiculoModel(VehiculoEnt vehiculo)
        {
            using (var conexion = new El_Cruce_Entities())
            {

                VEHICULO vehiculoDB = (from x in conexion.VEHICULO
                                       where x.PLACA == vehiculo.placa
                                       select x).FirstOrDefault();

                if (vehiculoDB != null)
                {
                    vehiculoDB.ESTADO = vehiculo.estado;
                    conexion.SaveChanges();
                }


                return vehiculo;
            }

        }



    }
}
