﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AutoFixProyectoWeb.ModelDB
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class El_Cruce_Entities : DbContext
    {
        public El_Cruce_Entities()
            : base("name=El_Cruce_Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<CATEGORIA> CATEGORIA { get; set; }
        public virtual DbSet<COMENTARIOS_PROYECTO> COMENTARIOS_PROYECTO { get; set; }
        public virtual DbSet<COSTO> COSTO { get; set; }
        public virtual DbSet<ESTADO_COSTO> ESTADO_COSTO { get; set; }
        public virtual DbSet<ESTADO_PROYECTO> ESTADO_PROYECTO { get; set; }
        public virtual DbSet<ESTADO_SERVICIO> ESTADO_SERVICIO { get; set; }
        public virtual DbSet<HISTORIAL_ESTADOS> HISTORIAL_ESTADOS { get; set; }
        public virtual DbSet<INVENTARIO> INVENTARIO { get; set; }
        public virtual DbSet<PROVEEDOR> PROVEEDOR { get; set; }
        public virtual DbSet<PROYECTO> PROYECTO { get; set; }
        public virtual DbSet<PROYECTO_PIEZAS> PROYECTO_PIEZAS { get; set; }
        public virtual DbSet<ROLE_USUARIO> ROLE_USUARIO { get; set; }
        public virtual DbSet<SERVICIO> SERVICIO { get; set; }
        public virtual DbSet<TIPO_COSTO> TIPO_COSTO { get; set; }
        public virtual DbSet<USUARIO> USUARIO { get; set; }
        public virtual DbSet<VEHICULO> VEHICULO { get; set; }
    
        public virtual int sp_alterdiagram(string diagramname, Nullable<int> owner_id, Nullable<int> version, byte[] definition)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var versionParameter = version.HasValue ?
                new ObjectParameter("version", version) :
                new ObjectParameter("version", typeof(int));
    
            var definitionParameter = definition != null ?
                new ObjectParameter("definition", definition) :
                new ObjectParameter("definition", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_alterdiagram", diagramnameParameter, owner_idParameter, versionParameter, definitionParameter);
        }
    
        public virtual int sp_creatediagram(string diagramname, Nullable<int> owner_id, Nullable<int> version, byte[] definition)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var versionParameter = version.HasValue ?
                new ObjectParameter("version", version) :
                new ObjectParameter("version", typeof(int));
    
            var definitionParameter = definition != null ?
                new ObjectParameter("definition", definition) :
                new ObjectParameter("definition", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_creatediagram", diagramnameParameter, owner_idParameter, versionParameter, definitionParameter);
        }
    
        public virtual int sp_dropdiagram(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_dropdiagram", diagramnameParameter, owner_idParameter);
        }
    
        public virtual ObjectResult<sp_helpdiagramdefinition_Result> sp_helpdiagramdefinition(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_helpdiagramdefinition_Result>("sp_helpdiagramdefinition", diagramnameParameter, owner_idParameter);
        }
    
        public virtual ObjectResult<sp_helpdiagrams_Result> sp_helpdiagrams(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_helpdiagrams_Result>("sp_helpdiagrams", diagramnameParameter, owner_idParameter);
        }
    
        public virtual int sp_renamediagram(string diagramname, Nullable<int> owner_id, string new_diagramname)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var new_diagramnameParameter = new_diagramname != null ?
                new ObjectParameter("new_diagramname", new_diagramname) :
                new ObjectParameter("new_diagramname", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_renamediagram", diagramnameParameter, owner_idParameter, new_diagramnameParameter);
        }
    
        public virtual int sp_upgraddiagrams()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_upgraddiagrams");
        }
    
        public virtual ObjectResult<COMENTARIOS_DE_PROYECTO_Result> COMENTARIOS_DE_PROYECTO(Nullable<int> iD_PROYECTO)
        {
            var iD_PROYECTOParameter = iD_PROYECTO.HasValue ?
                new ObjectParameter("ID_PROYECTO", iD_PROYECTO) :
                new ObjectParameter("ID_PROYECTO", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<COMENTARIOS_DE_PROYECTO_Result>("COMENTARIOS_DE_PROYECTO", iD_PROYECTOParameter);
        }
    
        public virtual ObjectResult<ESTADOS_PROYECTO_DE_CLIENTE_Result> ESTADOS_PROYECTO_DE_CLIENTE(Nullable<int> iD_PROYECTO)
        {
            var iD_PROYECTOParameter = iD_PROYECTO.HasValue ?
                new ObjectParameter("ID_PROYECTO", iD_PROYECTO) :
                new ObjectParameter("ID_PROYECTO", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<ESTADOS_PROYECTO_DE_CLIENTE_Result>("ESTADOS_PROYECTO_DE_CLIENTE", iD_PROYECTOParameter);
        }
    
        public virtual ObjectResult<PROYECTOS_DE_CLIENTE_Result> PROYECTOS_DE_CLIENTE(string pLACAS_VEHICULOS)
        {
            var pLACAS_VEHICULOSParameter = pLACAS_VEHICULOS != null ?
                new ObjectParameter("PLACAS_VEHICULOS", pLACAS_VEHICULOS) :
                new ObjectParameter("PLACAS_VEHICULOS", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<PROYECTOS_DE_CLIENTE_Result>("PROYECTOS_DE_CLIENTE", pLACAS_VEHICULOSParameter);
        }
    
        public virtual ObjectResult<VEHICULOS_DE_CLIENTE_Result> VEHICULOS_DE_CLIENTE(Nullable<int> iD_USUARIO)
        {
            var iD_USUARIOParameter = iD_USUARIO.HasValue ?
                new ObjectParameter("ID_USUARIO", iD_USUARIO) :
                new ObjectParameter("ID_USUARIO", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<VEHICULOS_DE_CLIENTE_Result>("VEHICULOS_DE_CLIENTE", iD_USUARIOParameter);
        }
    
        public virtual ObjectResult<PROYECTOS_DE_MECANICO_Result> PROYECTOS_DE_MECANICO(Nullable<int> iD_MECANICO)
        {
            var iD_MECANICOParameter = iD_MECANICO.HasValue ?
                new ObjectParameter("ID_MECANICO", iD_MECANICO) :
                new ObjectParameter("ID_MECANICO", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<PROYECTOS_DE_MECANICO_Result>("PROYECTOS_DE_MECANICO", iD_MECANICOParameter);
        }
    
        public virtual ObjectResult<PROYECTOS_DE_VEHICULO_Result> PROYECTOS_DE_VEHICULO(string pLACA)
        {
            var pLACAParameter = pLACA != null ?
                new ObjectParameter("PLACA", pLACA) :
                new ObjectParameter("PLACA", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<PROYECTOS_DE_VEHICULO_Result>("PROYECTOS_DE_VEHICULO", pLACAParameter);
        }
    
        public virtual ObjectResult<HISTORIAL_DE_VEHICULO_Result> HISTORIAL_DE_VEHICULO(string pLACA)
        {
            var pLACAParameter = pLACA != null ?
                new ObjectParameter("PLACA", pLACA) :
                new ObjectParameter("PLACA", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<HISTORIAL_DE_VEHICULO_Result>("HISTORIAL_DE_VEHICULO", pLACAParameter);
        }
    }
}
