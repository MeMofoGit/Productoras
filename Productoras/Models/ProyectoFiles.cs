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
    
    public partial class ProyectoFiles
    {
        public int id { get; set; }
        public string nombre_c { get; set; }
        public string descripcion_c { get; set; }
        public string enlace_c { get; set; }
        public int proyecto_xref { get; set; }
        public string tipo_c { get; set; }
        public System.DateTime fechaIni_dt { get; set; }
    
        public virtual Proyectos Proyectos { get; set; }
    }
}
