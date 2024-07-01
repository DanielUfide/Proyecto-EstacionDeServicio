using AutoFixProyectoWeb.Entities;
using AutoFixProyectoWeb.ModelDB;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;

namespace AutoFixProyectoWeb.Models
{
    public class UsuarioModel
    {
        public UsuarioEnt validarUsuarioModel(UsuarioEnt usuario)
        {
            using (var conexion = new El_Cruce_Entities())
            {
                USUARIO usuarioDB = (from x in conexion.USUARIO
                                     where x.CORREO == usuario.correo && x.CONTRASEÑA == usuario.contraseña select x).FirstOrDefault();

                if (usuarioDB != null)
                {

                    ROLE_USUARIO roleDB = (from x in conexion.ROLE_USUARIO
                                           where x.ID_ROLE == usuarioDB.ID_ROLE
                                           select x).FirstOrDefault();

                    UsuarioEnt UsuarioFinal = new UsuarioEnt
                    {
                        nombre = usuarioDB.NOMBRE,
                        correo = usuarioDB.CORREO,
                        telefono = usuarioDB.TELEFONO,
                        role = new RoleUsuarioEnt
                        {
                            id_role = roleDB.ID_ROLE,
                            role = roleDB.ROLE,
                        }
                    };

                    return UsuarioFinal;
                } else
                {
                    return null;    
                }

            }
        }

        public UsuarioEnt crearUsuario (UsuarioEnt usuario)
        {
            using(var conexion = new El_Cruce_Entities())
            {
                USUARIO usuarioDB = new USUARIO
                {
                    ID_ROLE = usuario.role.id_role,
                    NOMBRE = usuario.nombre,
                    CORREO = usuario.correo,
                    CONTRASEÑA = usuario.contraseña,
                    TELEFONO = usuario.telefono
                };

                conexion.USUARIO.Add(usuarioDB);
                var result = conexion.SaveChanges();
                
                if (result == 1)
                {
                    return usuario;

                } else
                {
                    return null;
                }
            }
        }
    }
}