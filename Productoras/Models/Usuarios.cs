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
    
    public partial class Usuarios
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Usuarios()
        {
            this.Comentarios = new HashSet<Comentarios>();
            this.ComentariosUsuario = new HashSet<ComentariosUsuario>();
            this.Mensajes = new HashSet<Mensajes>();
            this.MensajesProyectoLeido = new HashSet<MensajesProyectoLeido>();
            this.MensajesUsuario = new HashSet<MensajesUsuario>();
            this.ProyectoParticipantes = new HashSet<ProyectoParticipantes>();
            this.Proyectos = new HashSet<Proyectos>();
            this.ProyectoSolicitud = new HashSet<ProyectoSolicitud>();
            this.UsuarioActorCategoria = new HashSet<UsuarioActorCategoria>();
            this.UsuarioProductoraCategoria = new HashSet<UsuarioProductoraCategoria>();
            this.UsuariosActor = new HashSet<UsuariosActor>();
            this.UsuariosFotos = new HashSet<UsuariosFotos>();
            this.UsuariosGaleria = new HashSet<UsuariosGaleria>();
            this.UsuariosLocation = new HashSet<UsuariosLocation>();
            this.UsuariosProductora = new HashSet<UsuariosProductora>();
            this.UsuariosTecnico = new HashSet<UsuariosTecnico>();
            this.UsuariosVideos = new HashSet<UsuariosVideos>();
        }
    
        public int id { get; set; }
        public string username_c { get; set; }
        public string email_c { get; set; }
        public string password { get; set; }
        public string fotoPerfil_c { get; set; }
        public string salt_c { get; set; }
        public string ip_c { get; set; }
        public string ipLast_c { get; set; }
        public System.DateTime fechaIni_dt { get; set; }
        public Nullable<System.DateTime> fechaLast_dt { get; set; }
        public bool activo_b { get; set; }
        public Nullable<int> ciudad_xref { get; set; }
        public Nullable<int> tipo_xref { get; set; }
        public bool definido_b { get; set; }
    
        public virtual Ciudades Ciudades { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Comentarios> Comentarios { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ComentariosUsuario> ComentariosUsuario { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Mensajes> Mensajes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MensajesProyectoLeido> MensajesProyectoLeido { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MensajesUsuario> MensajesUsuario { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProyectoParticipantes> ProyectoParticipantes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Proyectos> Proyectos { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProyectoSolicitud> ProyectoSolicitud { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UsuarioActorCategoria> UsuarioActorCategoria { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UsuarioProductoraCategoria> UsuarioProductoraCategoria { get; set; }
        public virtual UsuariosTipos UsuariosTipos { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UsuariosActor> UsuariosActor { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UsuariosFotos> UsuariosFotos { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UsuariosGaleria> UsuariosGaleria { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UsuariosLocation> UsuariosLocation { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UsuariosProductora> UsuariosProductora { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UsuariosTecnico> UsuariosTecnico { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UsuariosVideos> UsuariosVideos { get; set; }
    }
}