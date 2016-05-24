using Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Productoras.Models
{
    public class clsDefineUsuarioModel
    {
        public bool tipo { get; set; }

        // DATOS TIPO TECNICO

        /* Nombre */
        [Required(ErrorMessageResourceName = "error_vacio", ErrorMessageResourceType = typeof(ProductorasResources))]
        [MinLength(3, ErrorMessageResourceName = "nombre_error_minmax", ErrorMessageResourceType = typeof(ProductorasResources))]
        [MaxLength(20, ErrorMessageResourceName = "nombre_error_minmax", ErrorMessageResourceType = typeof(ProductorasResources))]
        [Display(Name = "nombre_lbl", ResourceType = typeof(ProductorasResources))]
        public string tecnico_nombre_c { get; set; }
        /* Apellidos */
        [Required(ErrorMessageResourceName = "error_vacio", ErrorMessageResourceType = typeof(ProductorasResources))]
        [MinLength(3, ErrorMessageResourceName = "apellido_error_minmax", ErrorMessageResourceType = typeof(ProductorasResources))]
        [MaxLength(20, ErrorMessageResourceName = "apellido_error_minmax", ErrorMessageResourceType = typeof(ProductorasResources))]
        [Display(Name = "apellido_lbl", ResourceType = typeof(ProductorasResources))]
        public string tecnico_apellidos_c { get; set; }
        /* DNI */
        [Required(ErrorMessageResourceName = "error_vacio", ErrorMessageResourceType = typeof(ProductorasResources))]
        [MinLength(8, ErrorMessageResourceName = "dni_error_minmax", ErrorMessageResourceType = typeof(ProductorasResources))]
        [MaxLength(8, ErrorMessageResourceName = "dni_error_minmax", ErrorMessageResourceType = typeof(ProductorasResources))]
        //[RegularExpression(@"(([X-Z]{1})([-]?)(\d{7})([-]?)([A-Z]{1}))|((\d{8})([-]?)([A-Z]{1}))", ErrorMessageResourceName = "dni_noValido", ErrorMessageResourceType = typeof(ProyectoResources))]
        [Display(Name = "dni_lbl", ResourceType = typeof(ProductorasResources))]
        public string tecnico_dni_c { get; set; }
        /* Telefono */
        [Required(ErrorMessageResourceName = "error_vacio", ErrorMessageResourceType = typeof(ProductorasResources))]
        [MinLength(5, ErrorMessageResourceName = "tlf_error_minmax", ErrorMessageResourceType = typeof(ProductorasResources))]
        [MaxLength(20, ErrorMessageResourceName = "tlf_error_minmax", ErrorMessageResourceType = typeof(ProductorasResources))]
        [Display(Name = "tlf_lbl", ResourceType = typeof(ProductorasResources))]
        public string tecnico_telefono_c { get; set; }
        /* TipoProfesional */
        [Required(ErrorMessageResourceName = "error_vacio", ErrorMessageResourceType = typeof(ProductorasResources))]
        [Display(Name = "tipoProfesional_lbl", ResourceType = typeof(ProductorasResources))]
        public int tecnico_tipoProfesional_xref { get; set; }

        // DATOS TIPO PRODUCTORA
         
        /* Nombre */
        [Required(ErrorMessageResourceName = "error_vacio", ErrorMessageResourceType = typeof(ProductorasResources))]
        [MinLength(3, ErrorMessageResourceName = "nombre_error_minmax", ErrorMessageResourceType = typeof(ProductorasResources))]
        [MaxLength(20, ErrorMessageResourceName = "nombre_error_minmax", ErrorMessageResourceType = typeof(ProductorasResources))]
        [Display(Name = "nombre_lbl", ResourceType = typeof(ProductorasResources))]
        public string productora_nombre_c { get; set; }
        /* Telefono */
        [Required(ErrorMessageResourceName = "error_vacio", ErrorMessageResourceType = typeof(ProductorasResources))]
        [MinLength(5, ErrorMessageResourceName = "tlf_error_minmax", ErrorMessageResourceType = typeof(ProductorasResources))]
        [MaxLength(20, ErrorMessageResourceName = "tlf_error_minmax", ErrorMessageResourceType = typeof(ProductorasResources))]
        [Display(Name = "tlf_lbl", ResourceType = typeof(ProductorasResources))]
        public string productora_telefono_c { get; set; }
    }
}