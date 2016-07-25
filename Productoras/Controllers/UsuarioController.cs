using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web.Security;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using Productoras.Models;
using System.Web.Mvc.Ajax;
using System.IO;
using System.Drawing;

//using System.Device.Location;
using System.Net;
using System.Threading.Tasks;

namespace Proyecto.Controllers
{
    public class UsuarioController : Controller
    {
        ProyectoEntities db = new ProyectoEntities();
        // GET: Usuario
        public ActionResult Index()
        {

            if (Session["id_usuario"] == null)
            {
                return RedirectToAction("Login", "Usuario");
            }
            else
            {
                var idUsuario = (int)Session["id_usuario"];
                var usuario = db.Usuarios.Where(u => u.id == idUsuario).FirstOrDefault();
                if (usuario.definido_b == false)
                {
                    return RedirectToAction("DefineUsuario", "Usuario");
                }
                else
                {
                    return View();
                }
            }
        }
        // Registro de un nuevo usuario
        [HttpGet]
        [Route("Registrarme")]
        public ActionResult Registro()
        {
            if (Session["id_usuario"] != null)
            {
                return RedirectToAction("Index");
            }
            var lstCiudades = db.Ciudades.Where(s => s.activo_b).ToList();

            // Subcategorias para enviar por ViewBag a la vista
            IEnumerable<SelectListItem> ciudades =
                   from c in lstCiudades
                   select new SelectListItem
                   {
                       Text = c.nombre_c,
                       Value = c.id.ToString()
                   };

            ViewBag.lstCiudades = ciudades;

            return View();
        }

        [HttpPost]
        public ActionResult Registro(frmUsuariosRegistroModel argUsuario)
        {
            if (Session["id_usuario"] != null)
            {
                RedirectToAction("Index");
            }

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

                    return RedirectToAction("DefineUsuario", "Usuario");
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
                var lstCiudades = db.Ciudades.Where(s => s.activo_b).ToList();

                // Subcategorias para enviar por ViewBag a la vista
                IEnumerable<SelectListItem> ciudades =
                       from c in lstCiudades
                       select new SelectListItem
                       {
                           Text = c.nombre_c,
                           Value = c.id.ToString()
                       };

                ViewBag.lstCiudades = ciudades;

                return View(argUsuario);
            }
            return View();
        }
        public ActionResult DefineUsuario()
        {
            if (Session["id_usuario"] == null)
            {
                return RedirectToAction("Login", "Usuario");
            }

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
        [HttpPost]
        public ActionResult Login(frmUsuariosLoginModel argUsuario)
        {
            if (Session["id_usuario"] != null)
            {
                return RedirectToAction("Index", "Home");
            }
            if (ModelState.IsValid)
            {
                var usuario = db.Usuarios.Where(u => u.email_c == argUsuario.username_c || u.username_c == argUsuario.username_c && u.activo_b == true).FirstOrDefault();

                if (validLogin(argUsuario.username_c, argUsuario.password, usuario))
                {
                    if (usuario.definido_b)
                    {
                        //FormsAuthentication.SetAuthCookie(argUsuario.email_c, false);
                        return RedirectToAction("Perfil", "Usuario");
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
        //public PartialViewResult getLogin()
        //{
        //    return PartialView("Partials/formLogin");
        //}
        //[HttpPost]
        //public ActionResult getLogin(frmUsuariosLoginModel argUsuario)
        //{
        //    if (Session["id_usuario"] != null)
        //    {
        //        return RedirectToAction("Index", "Home");
        //    }
        //    if (ModelState.IsValid)
        //    {
        //        var usuario = db.Usuarios.Where(u => u.email_c == argUsuario.username_c || u.username_c == argUsuario.username_c).FirstOrDefault();

        //        // COMPROBAR QUE EL USUIARIO ESTA ACTIVO_B !!!!!!!!!!!
        //        if (validLogin(argUsuario.username_c, argUsuario.password, usuario))
        //        {
        //            if (usuario.definido_b)
        //            {
        //                //FormsAuthentication.SetAuthCookie(argUsuario.email_c, false);
        //                return RedirectToAction("Perfil", "Usuario");
        //            }
        //            else
        //            {
        //                return RedirectToAction("DefineUsuario", "Usuario");
        //            }
        //        }
        //        else
        //        {
        //            ModelState.AddModelError("", "Fallo en el login");
        //            return PartialView("Partials/formLogin", argUsuario);
        //        }
        //    }
        //    //System.Web.HttpContext.Current.Request.Url.AbsolutePath
        //    return PartialView("Partials/formLogin", argUsuario);
        //}
        // Logout de la sesion
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }
        public PartialViewResult DefineProductora()
        {
            return PartialView("Partials/defineProductora");
        }
        [HttpGet]
        public ActionResult DefineTecnico()
        {
            if (Session["id_usuario"] == null)
            {
                return RedirectToAction("Login");
            }

            var idUsuario = (int)Session["id_usuario"];
            var definido = db.Usuarios.Where(u => u.id == idUsuario).Select(u => u.definido_b).FirstOrDefault();

            if (definido == true)
            {
                return RedirectToAction("Index", "Home");
            }
            else {
                return PartialView("Partials/defineTecnico");
            }
        }
        [HttpPost]
        public ActionResult DefineTecnico(frmUsuariosDefineTecnico argTecnico)
        {
            var idUsuario = (int)Session["id_usuario"];
            var definido = db.Usuarios.Where(u => u.id == idUsuario).Select(u => u.definido_b).FirstOrDefault();

            if (definido == true)
            {
                return RedirectToAction("Index", "Home");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    UsuariosTecnico clsUsuarioTecnico = new UsuariosTecnico();
                    Usuarios clsUsuario = new Usuarios();
                    clsUsuario = db.Usuarios.Where(u => u.id == idUsuario).FirstOrDefault();
                    clsUsuario.definido_b = true;

                    clsUsuarioTecnico.Usuarios = clsUsuario;
                    clsUsuarioTecnico.nombre_c = argTecnico.nombre_c;
                    clsUsuarioTecnico.apellidos_c = argTecnico.apellidos_c;
                    clsUsuarioTecnico.dni_c = argTecnico.dni_c;
                    clsUsuarioTecnico.telefono_c = argTecnico.telefono_c;
                    //clsUsuarioTecnico.usuario_xref = (int)Session["id_usuario"];

                    //Defino la subcategoría del usuario
                    UsuariosTecnicosSubcategorias clsTecnicoSubcategoria = new UsuariosTecnicosSubcategorias();
                    clsTecnicoSubcategoria.experiencia_i = argTecnico.experiencia;
                    clsTecnicoSubcategoria.UsuariosTiposSubcategorias = db.UsuariosTiposSubcategorias.Where(s => s.id == argTecnico.subcategoria).FirstOrDefault();

                    clsUsuarioTecnico.UsuariosTecnicosSubcategorias.Add(clsTecnicoSubcategoria);

                    db.UsuariosTecnico.Add(clsUsuarioTecnico);
                    //ATENCION !!! FALTAN DEFINIR LAS SUBCATEGORIAS DEL TECNICO, QUE PUEDEN SER MÁS DE UNA DESDE LA VISTA
                    //clsUsuarioTecnico.Usuarios.UsuariosTecnicosSubcategorias = argTecnico.tipoProfesional_xref;

                    db.SaveChanges();
                    return Redirect("Index");
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
                TempData["ModelState"] = ModelState;
                return Redirect("DefineUsuario");
            }
            return PartialView();
        }
        public PartialViewResult GetCategorias(int id)
        {
            var lstCategorias = db.UsuariosTiposCategorias.Where(c => c.activo_b == true && c.tipoUsuario_xref == id).ToList();
            var lstSubcategorias = db.UsuariosTiposSubcategorias.Where(s => s.activo_b == true && s.UsuariosTiposCategorias.tipoUsuario_xref == id).ToList();

            ViewBag.lstCategorias = lstCategorias;

            if (id == 1)
            {
                return PartialView("Partials/listaCategoriasTecnico");
            }
            if (id == 2)
            {
                // Categorias para enviar por ViewBag a la vista
                IEnumerable<SelectListItem> categorias =
                       from c in lstCategorias
                       select new SelectListItem
                       {
                           Text = c.nombre_c,
                           Value = c.id.ToString()
                       };
                ViewBag.lstCategorias = categorias;
                return PartialView("Partials/listaCategoriasActor");
            }
            if (id == 3)
            {
                // Categorias para enviar por ViewBag a la vista
                IEnumerable<SelectListItem> categorias =
                       from c in lstCategorias
                       select new SelectListItem
                       {
                           Text = c.nombre_c,
                           Value = c.id.ToString()
                       };
                ViewBag.lstCategorias = categorias;
                return PartialView("Partials/listaCategoriasProductora");
            }
            return PartialView();
        }
        public PartialViewResult GetSubcategorias(int id)
        {
            var lstSubcategorias = db.UsuariosTiposSubcategorias.Where(s => s.activo_b == true && s.categoria_xref == id).ToList();

            // Subcategorias para enviar por ViewBag a la vista
            IEnumerable<SelectListItem> subcategorias =
                   from c in lstSubcategorias
                   select new SelectListItem
                   {
                       Text = c.nombre_c,
                       Value = c.id.ToString()
                   };

            ViewBag.lstSubcategorias = subcategorias;

            return PartialView("Partials/listaSubcategorias");
        }
        [HttpGet]
        public PartialViewResult DefineActor()
        {
            var lstCategorias = db.UsuariosTiposCategorias.Where(c => c.activo_b == true).ToList();
            var lstSubcategorias = db.UsuariosTiposSubcategorias.Where(s => s.activo_b == true).ToList();

            // Categorias para enviar por ViewBag a la vista
            IEnumerable<SelectListItem> categorias =
                   from c in lstCategorias
                   select new SelectListItem
                   {
                       Text = c.nombre_c,
                       Value = c.id.ToString()
                   };

            ViewBag.lstCategorias = categorias;
            // Subcategorias para enviar por ViewBag a la vista
            IEnumerable<SelectListItem> subcategorias =
                   from c in lstSubcategorias
                   select new SelectListItem
                   {
                       Text = c.nombre_c,
                       Value = c.id.ToString()
                   };

            ViewBag.lstCategorias = subcategorias;
            return PartialView("Partials/defineActor");
        }
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

        [HttpGet]
        public ActionResult Perfil(int? id = null)
        {
            if (id == null)
            {
                if (Session["id_usuario"] != null)
                {
                    var idUsuario = (int)Session["id_usuario"];
                    var usuario = db.Usuarios.Where(u => u.id == idUsuario).FirstOrDefault();
                    return View("miPerfil", usuario);
                }
                else
                {
                    return RedirectToAction("Login", "Usuario");
                }

            }
            Usuarios clsUsuario = new Usuarios();

            clsUsuario = db.Usuarios.Where(u => u.id == id).FirstOrDefault();
            //clsUsuario.UsuariosGaleria = db.UsuariosGaleria.Where(g => g.usuario_xref == id).ToList();
            clsUsuario.ComentariosUsuario = db.ComentariosUsuario.Where(c => c.destinatario_xref == id).ToList();
            clsUsuario.ProyectoParticipantes = db.ProyectoParticipantes.Where(p => p.participante_xref == id).ToList();
            clsUsuario.UsuariosFotos = db.UsuariosFotos.Where(f => f.usuario_xref == id).ToList();
            clsUsuario.UsuariosVideos = db.UsuariosVideos.Where(v => v.usuario_xref == id).ToList();

            return View(clsUsuario);
        }
        [HttpPost]
        public ActionResult PerfilActualizar(int? id, string argDescripcion)
        {
            var idUsuario = (int)Session["id_usuario"];

            var usuario = db.Usuarios.Where(u => u.id == idUsuario).FirstOrDefault();
            if(usuario.tipo_xref == 1)
            {
                usuario.UsuariosTecnico.First().descripcion_c = argDescripcion;
                db.SaveChanges();
            }
            else
            {
                //usuario.UsuariosProductora.First().telefono_c = argTelefono;
            }
            return Json("Actualizado");
        }
        [HttpGet]
        public PartialViewResult PerfilAddCategoria()
        {
            int idUsuario = (int)Session["id_usuario"];
            var usuario = db.Usuarios.Where(u => u.id == idUsuario).FirstOrDefault();

            var clsTipo = db.UsuariosTipos.Where(t => t.id == usuario.tipo_xref).FirstOrDefault();

            return PartialView("Partials/lstCompetencias", clsTipo);
        }
        [HttpPost]
        public PartialViewResult PerfilAddCategoria(int idSubcategoria, DateTime categoriaFechaIni, DateTime categoriaFechaFin)
        {
            int idUsuario = (int)Session["id_usuario"];
            var usuario = db.Usuarios.Where(u => u.id == idUsuario).FirstOrDefault();

            var clsSubcategoria = db.UsuariosTiposSubcategorias.Where(s => s.id == idSubcategoria).First();
            UsuariosTecnicosSubcategorias clsTecnicoSubcategoria = new UsuariosTecnicosSubcategorias();
            //Diferencia entre la fecha de inicio y la fecha de fin en dias
            TimeSpan diferenciaFechas = categoriaFechaFin - categoriaFechaIni;

            clsTecnicoSubcategoria.subcategoria_xref = clsSubcategoria.id;
            clsTecnicoSubcategoria.usuarioTecnico_xref = usuario.UsuariosTecnico.First().id;
            clsTecnicoSubcategoria.fechaIni_dt = categoriaFechaIni;
            clsTecnicoSubcategoria.fechaFin_dt = categoriaFechaFin;
            clsTecnicoSubcategoria.experiencia_i = diferenciaFechas.Days;

            usuario.UsuariosTecnico.First().UsuariosTecnicosSubcategorias.Add(clsTecnicoSubcategoria);
            db.SaveChanges();

            var clsTipo = db.UsuariosTipos.Where(t => t.id == usuario.tipo_xref).FirstOrDefault();

            return PartialView("Partials/lstCompetencias", clsTipo);
        }
        public ActionResult PerfilBorrarSubcategoria(int idSubcategoria)
        {
            int idUsuario = (int)Session["id_usuario"];
            var tipoPerfil = Session["tipoPerfil"];

            Usuarios usuario = db.Usuarios.Where(u => u.id == idUsuario).FirstOrDefault();
            int idUsuarioTecnico = usuario.UsuariosTecnico.First().id;
            if (usuario.tipo_xref == 1) {
                var clsSubcategoria = db.UsuariosTecnicosSubcategorias.SingleOrDefault(s => s.subcategoria_xref == idSubcategoria && s.usuarioTecnico_xref == idUsuarioTecnico);
                db.UsuariosTecnicosSubcategorias.Remove(clsSubcategoria);
            }

            db.SaveChanges();

            return Content("Ok");
        }
        public PartialViewResult NuevoVideo()
        {
            return PartialView("Partials/formNuevoVideo");
        }
        [HttpPost]
        public PartialViewResult NuevoVideo(UsuariosVideos argVideo)
        {
            return PartialView("Partials/formNuevoVideo");
        }
        public PartialViewResult NuevaFoto()
        {
            return PartialView("Partials/formNuevaFoto");
        }
        [HttpPost]
        public ActionResult getNuevaFoto()
        {
            var idUsuario = (int)Session["id_usuario"];
            // Checking no of files injected in Request object  
            if (Request.Files.Count > 0)
            {
                try
                {
                    //  Get all files from Request object  
                    HttpFileCollectionBase files = Request.Files;
                    for (int i = 0; i < files.Count; i++)
                    {
                        //string path = AppDomain.CurrentDomain.BaseDirectory + "Uploads/";  
                        //string filename = Path.GetFileName(Request.Files[i].FileName);  

                        HttpPostedFileBase file = files[i];
                        string fname;

                        // Checking for Internet Explorer  
                        if (Request.Browser.Browser.ToUpper() == "IE" || Request.Browser.Browser.ToUpper() == "INTERNETEXPLORER")
                        {
                            string[] testfiles = file.FileName.Split(new char[] { '\\' });
                            fname = testfiles[testfiles.Length - 1];
                        }
                        else
                        {
                            fname = file.FileName;
                        }
                        var extension = Path.GetExtension(file.FileName);
                        var fnameEnc = idUsuario + "_" + Path.GetFileNameWithoutExtension(file.FileName);
                        var fnameCompleto = fnameEnc + extension;

                        // Get the complete folder path and store the file inside it.  
                        fname = Path.Combine(Server.MapPath("~/Fotos/"), fnameCompleto);

                        file.SaveAs(fname);

                        UsuariosFotos foto = new UsuariosFotos();

                        foto.enlace_c = fnameCompleto;
                        foto.fechaIni_dt = DateTime.Now;
                        foto.nombre_c = System.Web.HttpContext.Current.Request.Form["nombre_c"];
                        foto.descripcion_c = System.Web.HttpContext.Current.Request.Form["descripcion_c"];
                        var usuario = db.Usuarios.Where(u => u.id == idUsuario).First();

                        usuario.UsuariosFotos.Add(foto);

                        db.SaveChanges();

                    }
                    // Returns message that successfully uploaded  
                    return Json("File Uploaded Successfully!");
                }
                catch (Exception ex)
                {
                    return Json("Error occurred. Error details: " + ex.Message);
                }
            }
            else
            {
                return Json("No files selected.");
            }
        }
        public PartialViewResult ActualizarFotoPerfil()
        {

            return PartialView("Partials/formFotoPerfil");
        }
        [HttpPost]
        public ActionResult sendFotoPerfil()
        {

            var idUsuario = (int)Session["id_usuario"];
            var fotoPerfil_c = "";
            if (Request.Files.Count > 0)
            {
                try
                {

                    HttpFileCollectionBase files = Request.Files;
                    for (int i = 0; i < files.Count; i++)
                    {

                        HttpPostedFileBase file = files[i];
                        string fname;

                        if (Request.Browser.Browser.ToUpper() == "IE" || Request.Browser.Browser.ToUpper() == "INTERNETEXPLORER")
                        {
                            string[] testfiles = file.FileName.Split(new char[] { '\\' });
                            fname = testfiles[testfiles.Length - 1];
                        }
                        else
                        {
                            fname = file.FileName;
                        }


                        fname = Path.Combine(Server.MapPath("~/Fotos/"), fname);
                        //Bitmap img1 = new Bitmap(fname);
                        //Bitmap img2 = new Bitmap(fname);
                        //var diferencia = compararImagenes(img1, img2);
                        file.SaveAs(fname);

                        var usuario = db.Usuarios.Where(u => u.id == idUsuario).First();

                        usuario.fotoPerfil_c = file.FileName;
                        fotoPerfil_c = file.FileName;
                        db.SaveChanges();

                    }
                    // Returns message that successfully uploaded  
                    return Json(fotoPerfil_c);
                }
                catch (Exception ex)
                {
                    return Json("Error occurred. Error details: " + ex.Message);
                }
            }
            else
            {
                return Json("No files selected.");
            }

        }
        private float compararImagenes(Bitmap argImg1, Bitmap argImg2)
        {
            //Bitmap img1 = new Bitmap("Lenna50.jpg");
            //Bitmap img2 = new Bitmap("Lenna100.jpg");

            if (argImg1.Size != argImg2.Size)
            {
                Console.Error.WriteLine("Images are of different sizes");
                return 0;
            }

            float diff = 0;

            for (int y = 0; y < argImg1.Height; y++)
            {
                for (int x = 0; x < argImg1.Width; x++)
                {
                    diff += (float)Math.Abs(argImg1.GetPixel(x, y).R - argImg2.GetPixel(x, y).R) / 255;
                    diff += (float)Math.Abs(argImg1.GetPixel(x, y).G - argImg2.GetPixel(x, y).G) / 255;
                    diff += (float)Math.Abs(argImg1.GetPixel(x, y).B - argImg2.GetPixel(x, y).B) / 255;
                }
            }

            return 100 * diff / (argImg1.Width * argImg1.Height * 3);

        }


        //[HttpPost]
        //public async Task<JsonResult> UploadHomeReport()
        //{
        //    try
        //    {
        //        foreach (string file in Request.Files)
        //        {
        //            var fileContent = Request.Files[file];
        //            if (fileContent != null && fileContent.ContentLength > 0)
        //            {
        //                // get a stream
        //                var stream = fileContent.InputStream;
        //                // and optionally write the file to disk
        //                var fileName = Path.GetFileName(file);
        //                var path = Path.Combine(Server.MapPath("~/App_Data/Images"), fileName);
        //                using (var fileStream = System.IO.File.Create(path))
        //                {
        //                    stream.CopyTo(fileStream);
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        Response.StatusCode = (int)HttpStatusCode.BadRequest;
        //        return Json("Upload failed");
        //    }

        //    return Json("File uploaded successfully");
        //}

        //[HttpPost]
        //public void sendNuevaFoto()
        //{
        //    if(System.Web.HttpContext.Current.Request.Files.AllKeys.Any())
        //    {
        //        var archivoPost = System.Web.HttpContext.Current.Request.Files["imagenPost"];

        //        if(archivoPost != null)
        //        {
        //            var directorioPost = Path.Combine(System.Web.HttpContext.Current.Server.MapPath("~/Fotos"), archivoPost.FileName);
        //            archivoPost.SaveAs(directorioPost);
        //        }
        //    }
        //}
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
                    Session["tipo_usuario"] = argUsuario.tipo_xref;
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