﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ProyectoEntities : DbContext
    {
        public ProyectoEntities()
            : base("name=ProyectoEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Ciudades> Ciudades { get; set; }
        public virtual DbSet<Comentarios> Comentarios { get; set; }
        public virtual DbSet<ComentariosProyecto> ComentariosProyecto { get; set; }
        public virtual DbSet<ComentariosUsuario> ComentariosUsuario { get; set; }
        public virtual DbSet<Mensajes> Mensajes { get; set; }
        public virtual DbSet<MensajesProyecto> MensajesProyecto { get; set; }
        public virtual DbSet<MensajesProyectoLeido> MensajesProyectoLeido { get; set; }
        public virtual DbSet<MensajesUsuario> MensajesUsuario { get; set; }
        public virtual DbSet<ProyectoDemandas> ProyectoDemandas { get; set; }
        public virtual DbSet<ProyectoFiles> ProyectoFiles { get; set; }
        public virtual DbSet<ProyectoParticipantes> ProyectoParticipantes { get; set; }
        public virtual DbSet<Proyectos> Proyectos { get; set; }
        public virtual DbSet<ProyectoSolicitud> ProyectoSolicitud { get; set; }
        public virtual DbSet<ProyectosTipo> ProyectosTipo { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<UsuarioActorCategoria> UsuarioActorCategoria { get; set; }
        public virtual DbSet<UsuarioProductoraCategoria> UsuarioProductoraCategoria { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }
        public virtual DbSet<UsuariosActor> UsuariosActor { get; set; }
        public virtual DbSet<UsuariosFotos> UsuariosFotos { get; set; }
        public virtual DbSet<UsuariosGaleria> UsuariosGaleria { get; set; }
        public virtual DbSet<UsuariosLocation> UsuariosLocation { get; set; }
        public virtual DbSet<UsuariosProductora> UsuariosProductora { get; set; }
        public virtual DbSet<UsuariosTecnico> UsuariosTecnico { get; set; }
        public virtual DbSet<UsuariosTecnicosSubcategorias> UsuariosTecnicosSubcategorias { get; set; }
        public virtual DbSet<UsuariosTipos> UsuariosTipos { get; set; }
        public virtual DbSet<UsuariosTiposCategorias> UsuariosTiposCategorias { get; set; }
        public virtual DbSet<UsuariosTiposSubcategorias> UsuariosTiposSubcategorias { get; set; }
        public virtual DbSet<UsuariosVideos> UsuariosVideos { get; set; }
    }
}
