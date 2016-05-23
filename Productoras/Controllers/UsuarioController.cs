using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web.Security;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using Productoras.Models;

//using System.Device.Location;
using System.Net;

namespace Proyecto.Controllers
{
    public class UsuarioController : Controller
    {
        ProyectoEntities db = new ProyectoEntities();
        // GET: Usuario
        public ActionResult Index()
        {

            return View();
        }
        // Registro de un nuevo usuario
        [HttpGet]
        [Route("Registrarme")]
        public ActionResult Registro()
        {

            //    var ciudades = db.Ciudades.ToList();
            //    IEnumerable<SelectListItem> lstCiudades =
            //        from c in ciudades
            //        select new SelectListItem
            //        {
            //            Text = c.nombre_c,
            //            Value = c.id.ToString()
            //        };

            //    ViewBag.lstCiudades = lstCiudades;
            return View();
        }

        [HttpPost]
        public ActionResult Registro(frmUsuariosRegistroModel argUsuario)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Usuarios usr = new Usuarios();

                    string strHostName = System.Net.Dns.GetHostName();
                    IPHostEntry ipEntry = System.Net.Dns.GetHostEntry(strHostName);
                    IPAddress ip = ipEntry.AddressList.FirstOrDefault(a => a.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork);

                    usr.fechaIni_dt = DateTime.Now;
                    //var usr = db.Usuarios.Create();
                    usr.username_c = argUsuario.username_c;
                    usr.email_c = argUsuario.email_c;
                    usr.salt_c = generarSalt(4);
                    usr.password = encriptarSHA512(argUsuario.password, usr.salt_c);
                    usr.ip_c = ip.ToString();
                    usr.activo_b = true;

                    //UsuariosLocation usrLocation = getUsuarioLocation();
                    //usrLocation.usuario_xref = usr.id;
                    //usr.UsuariosLocation.Add(usrLocation);

                    db.Usuarios.Add(usr);
                    //db.UsuariosLocation.Add(usrLocation);
                    db.SaveChanges();
                    Session["id_usuario"] = usr.id;
                    return RedirectToAction("Index", "Home");
                }
                catch (System.Data.Entity.Validation.DbEntityValidationException e)
                {
                    Console.WriteLine("Error en la validacion: " + e);
                    return View();
                }
                catch (HttpException e)
                {
                    System.Console.Write(e);
                }
            }
            else
            {
                ModelState.AddModelError("", "Error en el registro, datos incorrectos");
                return View(argUsuario);
            }
            return View();
        }
        public ActionResult DefineUsuario()
        {
            return View();
        }
        // Login que redirecciona a formulario de login
        [HttpGet]
        public ActionResult Login()
        {
            if (Session["id_usuario"] != null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
        public PartialViewResult DefineProductora()
        {
            return PartialView("Partials/defineProductora");
        }
        //public ActionResult DefineTecnico()
        //{
        //    var lstTipoProfesional = db.TipoProfesional.Where(t => t.activo_b == true).ToList();
        //    IEnumerable<SelectListItem> tipoProfesional =
        //           from c in lstTipoProfesional
        //           select new SelectListItem
        //           {
        //               Text = c.nombre_c,
        //               Value = c.id.ToString()
        //           };

        //    ViewBag.lstTipoProfesional = tipoProfesional;

        //    return PartialView("Partials/defineTecnico");
        //}
        //[HttpPost]
        //public ActionResult DefineTecnicoEnviar(frmUsuariosDefineTecnico argTecnico)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            UsuariosTecnico clsUsuarioTecnico = new UsuariosTecnico();
        //            clsUsuarioTecnico.nombre_c = argTecnico.nombre_c;
        //            clsUsuarioTecnico.apellidos_c = argTecnico.apellidos_c;
        //            clsUsuarioTecnico.dni_c = argTecnico.dni_c;
        //            clsUsuarioTecnico.telefono_c = argTecnico.telefono_c;
        //            clsUsuarioTecnico.usuario_xref = (int)Session["id_usuario"];
        //            clsUsuarioTecnico.tipoProfesional_xref = argTecnico.tipoProfesional_xref;

        //            db.UsuariosTecnico.Add(clsUsuarioTecnico);
        //            db.SaveChanges();
        //            return Redirect("Index");
        //        }
        //        catch (System.Data.Entity.Validation.DbEntityValidationException e)
        //        {
        //            Console.WriteLine("Error en la validacion: " + e);
        //            return View();
        //        }
        //        catch (HttpException e)
        //        {
        //            System.Console.Write(e);
        //        }
        //    }
        //    else
        //    {
        //        ModelState.AddModelError("", "Error en el registro, datos incorrectos");
        //        TempData["ModelState"] = ModelState;
        //        return Redirect("DefineUsuario");
        //    }
        //    return PartialView();
        //}

        //[HttpPost]
        //public ActionResult DefineProductoraEnviar(frmUsuariosDefineProductora argProductora)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            UsuariosProductora clsUsuarioProductora = new UsuariosProductora();
        //            clsUsuarioProductora.nombre_c = argProductora.nombre_c;
        //            clsUsuarioProductora.telefono_c = argProductora.telefono_c;
        //            clsUsuarioProductora.usuario_xref = (int)Session["id_usuario"];

        //            db.UsuariosProductora.Add(clsUsuarioProductora);
        //            db.SaveChanges();
        //            return Redirect("Index");
        //        }
        //        catch (System.Data.Entity.Validation.DbEntityValidationException e)
        //        {
        //            Console.WriteLine("Error en la validacion: " + e);
        //            return View();
        //        }
        //        catch (HttpException e)
        //        {
        //            System.Console.Write(e);
        //        }
        //    }
        //    else
        //    {
        //        ModelState.AddModelError("", "Error en el registro, datos incorrectos");
        //        TempData["ModelState"] = ModelState;
        //        return Redirect("DefineUsuario");
        //    }
        //    return PartialView();
        //}

        // Login de usuario con comprobación con POST
        [HttpPost]
        public ActionResult Login(frmUsuariosLoginModel argUsuario)
        {
            if (Session["id_usuario"] != null)
            {
                return RedirectToAction("Index", "Home");
            }
            if (ModelState.IsValid)
            {
                var usuario = db.Usuarios.Where(u => u.email_c == argUsuario.username_c || u.username_c == argUsuario.username_c).FirstOrDefault();

                if (validLogin(argUsuario.username_c, argUsuario.password, usuario))
                {
                    if (usuario.activo_b)
                    {
                        //FormsAuthentication.SetAuthCookie(argUsuario.email_c, false);
                        return RedirectToAction("index", "Home");
                    }
                    else
                    {
                        return RedirectToAction("DefineUsuario", "Usuario");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Fallo en el login");
                    return View(argUsuario);
                }
            }
            //System.Web.HttpContext.Current.Request.Url.AbsolutePath
            return View(argUsuario);
        }
        // Logout de la sesion
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult Perfil(int? id)
        {
            Usuarios clsUsuario = new Usuarios();

            clsUsuario = db.Usuarios.Where(u => u.id == id).FirstOrDefault();
            clsUsuario.UsuariosGaleria = db.UsuariosGaleria.Where(g => g.usuario_xref == id).ToList();
            clsUsuario.ComentariosUsuario = db.ComentariosUsuario.Where(c => c.destinatario_xref == id).ToList();
            clsUsuario.ProyectoParticipantes = db.ProyectoParticipantes.Where(p => p.participante_xref == id).ToList();
            clsUsuario.UsuariosFotos = db.UsuariosFotos.Where(f => f.usuario_xref == id).ToList();
            clsUsuario.UsuariosVideos = db.UsuariosVideos.Where(v => v.usuario_xref == id).ToList();

            //var lstComentariosUsuario = db.ComentariosUsuario.Where(c => c.destinatario_xref == id).ToList();
            //List<Comentarios> lstComentarios = new List<Comentarios>();
            //foreach (var comentario in lstComentariosUsuario)
            //{
            //    lstComentarios.Add(comentario.Comentarios);
            //}
            //clsUsuario.comentarios = lstComentarios;

            //var lstProyectosParticipantes = db.ProyectoParticipantes.Where(p => p.participante_xref == id).ToList();
            //List<Proyectos> lstProyectos = new List<Proyectos>();
            //foreach (var proyecto in lstProyectosParticipantes)
            //{
            //    lstProyectos.Add(proyecto.Proyectos);
            //}
            //clsUsuario.proyectos = lstProyectos;

            //var fotos = db.UsuariosFotos.Where(f => f.usuario_xref == id).ToList();
            //var videos = db.UsuariosVideos.Where(v => v.usuario_xref == id).ToList();

            return View(clsUsuario);
        }

        // Obtener geolocalización
        //private UsuariosLocation getUsuarioLocation()
        //{
        //    GeoCoordinateWatcher watcher = new GeoCoordinateWatcher();
        //    UsuariosLocation usuarioLocation = new UsuariosLocation();

        //    usuarioLocation.lat_d = watcher.Position.Location.Latitude;
        //    usuarioLocation.long_d = watcher.Position.Location.Longitude;

        //    return usuarioLocation;
        //    //watcher.StatusChanged += (sender, e) =>
        //    //{
        //    //    Console.WriteLine("new Status : {0}", e.Status);
        //    //};

        //    //watcher.PositionChanged += (sender, e) =>
        //    //{
        //    //    Console.WriteLine("position changed. Location : {0}, Timestamp : {1}",
        //    //        e.Position.Location, e.Position.Timestamp);
        //    //};

        //    //if (!watcher.TryStart(false, TimeSpan.FromMilliseconds(5000)))
        //    //{
        //    //    throw new Exception("Can't access location");
        //    //}

        //    //Console.ReadLine();
        //}
        // Generar salt para encriptar
        private string generarSalt(int saltos)
        {

            var rng = new System.Security.Cryptography.RNGCryptoServiceProvider();
            var buff = new byte[saltos];
            rng.GetBytes(buff);
            var salt = Convert.ToBase64String(buff);

            return salt;
        }
        // Función que encripta la contraseña mediante SHA512(Se puede cambiar SHA256) utilizando un salt generado previamente.
        private string encriptarSHA512(String argPassword, string salt)
        {
            // Encriptando
            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(argPassword + salt);
            System.Security.Cryptography.SHA512Managed sha256hashstring =
                new System.Security.Cryptography.SHA512Managed();
            byte[] hash = sha256hashstring.ComputeHash(bytes);
            var passwordCryp = Convert.ToBase64String(hash);
            return passwordCryp;
        }
        // Validar si el usuario y el email son validos en el login
        private bool validLogin(string argLogin, string argPassword, Usuarios argUsuario)
        {
            bool valido = false;

            if (argUsuario != null)
            {
                var crypPassword = encriptarSHA512(argPassword, argUsuario.salt_c);
                if (argUsuario.password == crypPassword)
                {
                    Session["id_usuario"] = argUsuario.id;
                    Session["username"] = argUsuario.username_c;
                    valido = true;
                }
            }
            return valido;
        }
        // Para mantener el model state en las redirecciones
        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            if (TempData["ModelState"] != null && !ModelState.Equals(TempData["ModelState"]))
                ModelState.Merge((ModelStateDictionary)TempData["ModelState"]);

            base.OnActionExecuted(filterContext);
        }

    }
}