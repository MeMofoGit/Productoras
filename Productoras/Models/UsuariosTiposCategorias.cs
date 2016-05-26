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
    
    public partial class UsuariosTiposCategorias
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public UsuariosTiposCategorias()
        {
            this.UsuarioActorCategoria = new HashSet<UsuarioActorCategoria>();
            this.UsuarioProductoraCategoria = new HashSet<UsuarioProductoraCategoria>();
            this.UsuariosTiposSubcategorias = new HashSet<UsuariosTiposSubcategorias>();
        }
    
        public int id { get; set; }
        public string nombre_c { get; set; }
        public string descripcion_c { get; set; }
        public bool activo_b { get; set; }
        public int tipoUsuario_xref { get; set; }
        public string icono_c { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UsuarioActorCategoria> UsuarioActorCategoria { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UsuarioProductoraCategoria> UsuarioProductoraCategoria { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UsuariosTiposSubcategorias> UsuariosTiposSubcategorias { get; set; }
    }
}