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
    
    public partial class ESTADO_PROYECTO_PIEZAS
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ESTADO_PROYECTO_PIEZAS()
        {
            this.PROYECTO_PIEZAS = new HashSet<PROYECTO_PIEZAS>();
        }
    
        public int ID_ESTADO { get; set; }
        public string ESTADO { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PROYECTO_PIEZAS> PROYECTO_PIEZAS { get; set; }
    }
}
