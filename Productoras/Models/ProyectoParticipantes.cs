//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Productoras.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class ProyectoParticipantes
    {
        public int id { get; set; }
        public int proyecto_xref { get; set; }
        public int participante_xref { get; set; }
        public bool activo_b { get; set; }
        public System.DateTime fechaIni_dt { get; set; }
        public Nullable<System.DateTime> fechaFin_dt { get; set; }
    
        public virtual Proyectos Proyectos { get; set; }
        public virtual Usuarios Usuarios { get; set; }
    }
}
