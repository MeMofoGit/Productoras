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
    
    public partial class ComentariosProyecto
    {
        public int id { get; set; }
        public int comentario_xref { get; set; }
        public int proyecto_xref { get; set; }
    
        public virtual Comentarios Comentarios { get; set; }
        public virtual Proyectos Proyectos { get; set; }
    }
}