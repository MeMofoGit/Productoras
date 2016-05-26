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
    using Microsoft.ApplicationInsights.Extensibility.Implementation.Tracing;
    using Newtonsoft.Json.Linq;
    using Newtonsoft.Json.Schema;
    using Resources;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Web;
    public partial class frmUsuariosRegistroModel : Usuarios
    {

        /* Id */
        public new int id { get; set; }
        /* Username */
        [Required(ErrorMessageResourceName = "error_vacio", ErrorMessageResourceType = typeof(ProductorasResources))]
        [MinLength(3, ErrorMessageResourceName = "user_error_minmax", ErrorMessageResourceType = typeof(ProductorasResources))]
        [MaxLength(20, ErrorMessageResourceName = "email_error_minmax", ErrorMessageResourceType = typeof(ProductorasResources))]
        [Display(Name = "user_lbl", ResourceType = typeof(ProductorasResources))]
        public new string username_c { get; set; }
        /* Password */
        [Required(ErrorMessageResourceName = "error_vacio", ErrorMessageResourceType = typeof(ProductorasResources))]
        [MinLength(8, ErrorMessageResourceName = "pwd_error_minmax", ErrorMessageResourceType = typeof(ProductorasResources))]
        [MaxLength(20, ErrorMessageResourceName = "email_error_minmax", ErrorMessageResourceType = typeof(ProductorasResources))]
        [DataType(DataType.Password)]
        [Display(Name = "password_lbl", ResourceType = typeof(ProductorasResources))]
        public new string password { get; set; }
        /* Ciudad */
        [Required(ErrorMessageResourceName = "error_vacio", ErrorMessageResourceType = typeof(ProductorasResources))]
        [Display(Name = "ciudad_lbl", ResourceType = typeof(ProductorasResources))]
        public new int ciudad_xref { get; set; }
        /* Salt */
        public new string salt_c { get; set; }
        
        [Required(ErrorMessageResourceName = "error_vacio", ErrorMessageResourceType = typeof(ProductorasResources))]
        [MinLength(10, ErrorMessageResourceName = "email_error_minmax", ErrorMessageResourceType = typeof(ProductorasResources))]
        [DataType(DataType.EmailAddress)]
        [MaxLength(120, ErrorMessageResourceName = "email_error_minmax", ErrorMessageResourceType = typeof(ProductorasResources))]
        [Display(Name = "email_lbl", ResourceType = typeof(ProductorasResources))]
        [EmailAddress]
        /* Email */
        public new string email_c { get; set; }
        /* Ip */
        public new string ip_c { get; set; }
        /* ipLast */
        public new string ipLast_c { get; set; }
        /* fechaIni */
        public new System.DateTime fechaIni_dt { get; set; }
        /* fechaLast */
        public new Nullable<System.DateTime> fechaLast_dt { get; set; }
        /* activo */
        public new bool activo_b { get; set; }
        /* fotoPerfil */
        [Required, FileExtensions(Extensions = "jpg,jpeg,png", ErrorMessageResourceName = "foto_error_extension", ErrorMessageResourceType = typeof(ProductorasResources))]
        [Display(Name = "fotoPerfil_lbl", ResourceType = typeof(ProductorasResources))]
        public HttpPostedFileBase Foto { get; set; }
    }
}