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
        public string NOMBRE { get; set; }
    
        public virtual CATEGORIA CATEGORIA { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PROYECTO_PIEZAS> PROYECTO_PIEZAS { get; set; }
    }
}
