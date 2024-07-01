using AutoFixProyectoWeb.Entities;
using AutoFixProyectoWeb.ModelDB;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
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
                        id_usuario = usuarioDB.ID_USUARIO,
                        nombre = usuarioDB.NOMBRE,
                        correo = usuarioDB.CORREO,
                        telefono = usuarioDB.TELEFONO,
                        role = new RoleUsuarioEnt
                        {
                            id_role = roleDB.ID_ROLE,
                            role = roleDB.ROLE,
                        }
                    };

                    HttpContext.Current.Session["UserName"] = UsuarioFinal.nombre;
                    HttpContext.Current.Session["UserRole"] = UsuarioFinal.role.id_role;
                    HttpContext.Current.Session["correo"] = UsuarioFinal.correo;

                    HttpContext.Current.Session["UsuarioActual"] = UsuarioFinal;

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
                    TELEFONO = usuario.telefono,
                    ESTADO_CONTRASEÑA = true
                };

                conexion.USUARIO.Add(usuarioDB);
                var result = conexion.SaveChanges();
                
                if (result == 1)
                {
                    HttpContext.Current.Session["UserName"] = usuario.nombre;
                    HttpContext.Current.Session["UserRole"] = usuario.role.id_role;
                    HttpContext.Current.Session["correo"] = usuario.correo;
                    return usuario;

                } else
                {
                    return null;
                }
            }
        }

        public int restaurarContraseña(UsuarioEnt usuario)
        {
            using (var conexion = new El_Cruce_Entities())
            {
                Random rnd = new Random();
                USUARIO usuarioModificar = (from x in conexion.USUARIO where x.CORREO == usuario.correo select x).FirstOrDefault();

                if (usuarioModificar == null)
                {
                    return 0;
                }
                else
                {
                    usuarioModificar.ESTADO_CONTRASEÑA = false;
                    usuarioModificar.CONTRASEÑA = usuario.correo.Substring(0,3) + rnd.Next(1,500).ToString();

                    return conexion.SaveChanges(); 

                }

            }
        }

        public void correoRestaurarContraseña(UsuarioEnt entidad)
        {

            MailMessage msg = new MailMessage();

            msg.To.Add(new MailAddress(entidad.correo, entidad.correo));
            msg.From = new MailAddress("cmorales40146@ufide.ac.cr", "Cambio Contraseña");
            msg.Subject = "Recuoperación de Contraseña";
            msg.Body = "Our system detected a request to change the password of your user, to log in again, proceed to change your password" + entidad.contraseña; 
            msg.IsBodyHtml = true;

            SmtpClient client = new SmtpClient();
            client.UseDefaultCredentials = false;
            client.Credentials = new System.Net.NetworkCredential("cmorales40146@ufide.ac.cr", "contraseña");
            client.Port = 587;
            client.Host = "smtp.office365.com";
            client.DeliveryMethod = SmtpDeliveryMethod.Network; 
            client.EnableSsl= true;
            client.Send(msg);

        }

    }
}