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
    
    public partial class UsuarioActorCategoria
    {
        public int id { get; set; }
        public int usuario_xref { get; set; }
        public int categoria_xref { get; set; }
        public Nullable<System.DateTime> fechaIni_dt { get; set; }
        public Nullable<System.DateTime> fechaFin_dt { get; set; }
        public Nullable<int> experiencia_i { get; set; }
    
        public virtual Usuarios Usuarios { get; set; }
        public virtual UsuariosTiposCategorias UsuariosTiposCategorias { get; set; }
    }
}
