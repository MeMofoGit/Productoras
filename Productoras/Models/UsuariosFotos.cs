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
    
    public partial class UsuariosFotos
    {
        public int id { get; set; }
        public string nombre_c { get; set; }
        public string descripcion_c { get; set; }
        public string enlace_c { get; set; }
        public System.DateTime fechaIni_dt { get; set; }
        public Nullable<System.DateTime> fechaLast_dt { get; set; }
        public int usuario_xref { get; set; }
        public Nullable<int> galeria_xref { get; set; }
        public bool principal_b { get; set; }
    
        public virtual Usuarios Usuarios { get; set; }
        public virtual UsuariosGaleria UsuariosGaleria { get; set; }
    }
}