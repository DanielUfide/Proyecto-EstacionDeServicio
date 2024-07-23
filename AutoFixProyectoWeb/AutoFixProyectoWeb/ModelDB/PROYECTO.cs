//------------------------------------------------------------------------------
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
