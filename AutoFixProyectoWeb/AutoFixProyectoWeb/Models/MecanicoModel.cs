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
    }
}