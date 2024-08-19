using AutoFixProyectoWeb.ModelDB;
using AutoFixProyectoWeb.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoFixProyectoWeb.Models
{
    public class CategoriaModel

    {

        public CategoriaEnt getCategoriaPorIDModel(CategoriaEnt categoria)
        { 
            using (var conexion = new El_Cruce_Entities())
            {

                CATEGORIA categoriaDB = (from x in conexion.CATEGORIA
                                         where x.ID_CATEGORIA == categoria.id_categoria
                                       select x).FirstOrDefault();

                CategoriaEnt Categoria = new CategoriaEnt
                {
                   
                    id_categoria = categoriaDB.ID_CATEGORIA,
                    id_proveedor = categoriaDB.ID_CATEGORIA,
                    categoria = categoriaDB.CATEGORIA1,
                    descripcion = categoriaDB.DESCRIPCION
                };

                return Categoria;
            }

        }
        public List<CategoriaEnt> getCategoriaModel()
        {
            using (var conexion = new El_Cruce_Entities())
            {

                var datos = (from x in conexion.CATEGORIA
                             select x);

                List<CategoriaEnt> categoriaList = new List<CategoriaEnt>();

                foreach (var categoriaDB in datos)
                {
                    CategoriaEnt Categoria = new CategoriaEnt
                    {

                        id_categoria = categoriaDB.ID_CATEGORIA,
                        id_proveedor = categoriaDB.ID_CATEGORIA,
                        categoria = categoriaDB.CATEGORIA1,
                        descripcion = categoriaDB.DESCRIPCION
                    };

                    categoriaList.Add(Categoria);
                }

                return categoriaList;
            }

        }

    }
}
    
   
