using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Resources;

namespace Productoras.Models
{
    public class Validaciones
    {
        [MetadataType(typeof(Usuarios_validacion))]
        public partial class Usuarios { }
        public string prueba_joder { get; set; }
        public class Usuarios_validacion
        {
            /* Username */
            [Required(ErrorMessageResourceName = "error_vacio", ErrorMessageResourceType = typeof(ProductorasResources))]
            [MinLength(3, ErrorMessageResourceName = "user_error_minmax", ErrorMessageResourceType = typeof(ProductorasResources))]
            [MaxLength(20, ErrorMessageResourceName = "email_error_minmax", ErrorMessageResourceType = typeof(ProductorasResources))]
            [Display(Name = "user_lbl", ResourceType = typeof(ProductorasResources))]
            public string username_c { get; set; }
            /* Password */
            [Required(ErrorMessageResourceName = "error_vacio", ErrorMessageResourceType = typeof(ProductorasResources))]
            [MinLength(8, ErrorMessageResourceName = "pwd_error_minmax", ErrorMessageResourceType = typeof(ProductorasResources))]
            [MaxLength(20, ErrorMessageResourceName = "email_error_minmax", ErrorMessageResourceType = typeof(ProductorasResources))]
            [DataType(DataType.Password)]
            [Display(Name = "password_lbl", ResourceType = typeof(ProductorasResources))]
            public string password { get; set; }
        }

        [MetadataType(typeof(UsuariosTecnico_validacion))]
        public partial class UsuariosTecnico
        {
            public int subcategoria_xref { get; set; }
        }

        public class UsuariosTecnico_validacion
        {
            /* Nombre */
            [Required(ErrorMessageResourceName = "error_vacio", ErrorMessageResourceType = typeof(ProductorasResources))]
            [MinLength(3, ErrorMessageResourceName = "nombre_error_minmax", ErrorMessageResourceType = typeof(ProductorasResources))]
            [MaxLength(20, ErrorMessageResourceName = "nombre_error_minmax", ErrorMessageResourceType = typeof(ProductorasResources))]
            [Display(Name = "nombre_lbl", ResourceType = typeof(ProductorasResources))]
            public string nombre_c { get; set; }
            /* Apellidos */
            [Required(ErrorMessageResourceName = "error_vacio", ErrorMessageResourceType = typeof(ProductorasResources))]
            [MinLength(3, ErrorMessageResourceName = "apellido_error_minmax", ErrorMessageResourceType = typeof(ProductorasResources))]
            [MaxLength(20, ErrorMessageResourceName = "apellido_error_minmax", ErrorMessageResourceType = typeof(ProductorasResources))]
            [Display(Name = "apellido_lbl", ResourceType = typeof(ProductorasResources))]
            public string apellidos_c { get; set; }
            /* DNI */
            [Required(ErrorMessageResourceName = "error_vacio", ErrorMessageResourceType = typeof(ProductorasResources))]
            [MinLength(8, ErrorMessageResourceName = "dni_error_minmax", ErrorMessageResourceType = typeof(ProductorasResources))]
            [MaxLength(8, ErrorMessageResourceName = "dni_error_minmax", ErrorMessageResourceType = typeof(ProductorasResources))]
            //[RegularExpression(@"(([X-Z]{1})([-]?)(\d{7})([-]?)([A-Z]{1}))|((\d{8})([-]?)([A-Z]{1}))", ErrorMessageResourceName = "dni_noValido", ErrorMessageResourceType = typeof(ProyectoResources))]
            [Display(Name = "dni_lbl", ResourceType = typeof(ProductorasResources))]
            public string dni_c { get; set; }
            /* Telefono */
            [Required(ErrorMessageResourceName = "error_vacio", ErrorMessageResourceType = typeof(ProductorasResources))]
            [MinLength(5, ErrorMessageResourceName = "tlf_error_minmax", ErrorMessageResourceType = typeof(ProductorasResources))]
            [MaxLength(20, ErrorMessageResourceName = "tlf_error_minmax", ErrorMessageResourceType = typeof(ProductorasResources))]
            [Display(Name = "tlf_lbl", ResourceType = typeof(ProductorasResources))]
            public string telefono_c { get; set; }

            public int categoria { get; set; }
            
        }
    }
}