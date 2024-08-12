//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AutoFixProyectoWeb.ModelDB
{
    using System;
    using System.Collections.Generic;
    
    public partial class PROYECTO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PROYECTO()
        {
            this.COMENTARIOS_PROYECTO = new HashSet<COMENTARIOS_PROYECTO>();
            this.HISTORIAL_ESTADOS = new HashSet<HISTORIAL_ESTADOS>();
            this.PROYECTO_PIEZAS = new HashSet<PROYECTO_PIEZAS>();
        }
    
        public int ID_PROYECTO { get; set; }
        public string ID_VEHICULO { get; set; }
        public int ID_ESTADO_PROYECTO { get; set; }
        public int ID_SERVICIO { get; set; }
        public int ID_MECANICO { get; set; }
        public Nullable<System.DateTime> FECHA { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<COMENTARIOS_PROYECTO> COMENTARIOS_PROYECTO { get; set; }
        public virtual ESTADO_PROYECTO ESTADO_PROYECTO { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HISTORIAL_ESTADOS> HISTORIAL_ESTADOS { get; set; }
        public virtual USUARIO USUARIO { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PROYECTO_PIEZAS> PROYECTO_PIEZAS { get; set; }
        public virtual VEHICULO VEHICULO { get; set; }
        public virtual SERVICIO SERVICIO { get; set; }
    }
}
