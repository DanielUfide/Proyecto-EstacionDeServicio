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
    
    public partial class PROYECTO_PIEZAS
    {
        public int ID_SOLICITUD { get; set; }
        public int ID_PROYECTO { get; set; }
        public int ID_INVENTARIO { get; set; }
        public int ID_COSTO { get; set; }
        public int CANTIDAD { get; set; }
        public int ESTADO { get; set; }
    
        public virtual COSTO COSTO { get; set; }
        public virtual INVENTARIO INVENTARIO { get; set; }
        public virtual PROYECTO PROYECTO { get; set; }
    }
}
