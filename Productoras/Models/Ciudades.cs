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
    
    public partial class Ciudades
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Ciudades()
        {
            this.Proyectos = new HashSet<Proyectos>();
            this.Usuarios = new HashSet<Usuarios>();
        }
    
        public int id { get; set; }
        public string nombre_c { get; set; }
        public Nullable<decimal> long_d { get; set; }
        public Nullable<decimal> lat_d { get; set; }
        public bool activo_b { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Proyectos> Proyectos { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Usuarios> Usuarios { get; set; }
    }
}
