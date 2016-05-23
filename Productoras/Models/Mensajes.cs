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
    
    public partial class Mensajes
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Mensajes()
        {
            this.MensajesProyecto = new HashSet<MensajesProyecto>();
            this.MensajesProyectoLeido = new HashSet<MensajesProyectoLeido>();
            this.MensajesUsuario = new HashSet<MensajesUsuario>();
        }
    
        public int id { get; set; }
        public int autor_xref { get; set; }
        public string mensaje_txt { get; set; }
        public System.DateTime fechaFirst_dt { get; set; }
    
        public virtual Usuarios Usuarios { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MensajesProyecto> MensajesProyecto { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MensajesProyectoLeido> MensajesProyectoLeido { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MensajesUsuario> MensajesUsuario { get; set; }
    }
}
