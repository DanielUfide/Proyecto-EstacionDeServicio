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
    
    public partial class INVENTARIO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public INVENTARIO()
        {
            this.PROYECTO_PIEZAS = new HashSet<PROYECTO_PIEZAS>();
        }
    
        public int ID_INVENTARIO { get; set; }
        public int ID_CATEGORIA { get; set; }
        public int CANTIDAD { get; set; }
        public Nullable<double> PRECIO_COMPRA { get; set; }
        public Nullable<double> PRECIO_VENTA { get; set; }
    
        public virtual CATEGORIA CATEGORIA { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PROYECTO_PIEZAS> PROYECTO_PIEZAS { get; set; }
    }
}
