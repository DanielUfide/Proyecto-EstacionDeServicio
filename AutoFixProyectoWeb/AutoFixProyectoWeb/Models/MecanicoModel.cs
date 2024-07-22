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

        public List<PROYECTOS_DE_MECANICO_Result> getProyectosMecanico(int idMecanico)
        {
            using (var coneccion = new El_Cruce_Entities())
            {
                List<PROYECTOS_DE_MECANICO_Result> proyectos = coneccion.PROYECTOS_DE_MECANICO(idMecanico).ToList();

                return proyectos;
            }
        }
    }
}