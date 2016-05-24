using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Productoras.Models;
namespace Productoras.Controllers
{
    public class ProyectosController : Controller
    {
        ProyectoEntities db = new ProyectoEntities();
        // GET: Proyectos
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult NuevoProyecto()
        {
            /* !ATENCION¡ Comprobar en la vista que existen ciudades y tipos, pese a que deberian existir. */
            var ciudades = db.Ciudades.Where(idm_ciudades => idm_ciudades.activo_b == true).ToList();
            var proyectosTipos = db.ProyectosTipo.Where(idm_activo => idm_activo.activo_b == true).ToList();

            IEnumerable<SelectListItem> lstCiudades =
                from c in ciudades
                select new SelectListItem
                {
                    Text = c.nombre_c,
                    Value = c.id.ToString()
                };

            ViewBag.lstCiudades = lstCiudades;

            IEnumerable<SelectListItem> lstProyectosTipos =
                from c in proyectosTipos
                select new SelectListItem
                {
                    Text = c.nombre_c,
                    Value = c.id.ToString()
                };

            ViewBag.lstProyectosTipos = lstProyectosTipos;

            return View();
        }
        [HttpPost]
        public ActionResult NuevoProyecto(frmProyectosNuevoModel argProyecto)
        {
            if (ModelState.IsValid)
            {

                try
                {

                    Proyectos clsProyecto = new Proyectos();
                    clsProyecto.nombre_c = argProyecto.nombre_c;
                    clsProyecto.descripcion_c = argProyecto.descripcion_c;
                    clsProyecto.fechaIni_dt = DateTime.Now;
                    clsProyecto.ciudad_xref = argProyecto.ciudad_xref;
                    // Posibilidad de dejar el proyecto inactivo hasta que un administrador lo apruebe
                    clsProyecto.activo_b = true;
                    clsProyecto.tipo_xref = argProyecto.tipo_xref;
                    clsProyecto.creador_xref = 31;

                    db.Proyectos.Add(clsProyecto);
                    db.SaveChanges();
                    return RedirectToAction("VerProyecto", "Proyectos", new { id = clsProyecto.id });
                } catch(System.Data.Entity.Validation.DbEntityValidationException e)
                {
                    Console.WriteLine("Error en la validacion: " + e);
                    return View();
                }
            }
            else
            {
                ModelState.AddModelError("", "Error en la creación del proyecto, datos incorrectos");

                var ciudades = db.Ciudades.Where(idm_ciudades => idm_ciudades.activo_b == true).ToList();
                var proyectosTipos = db.ProyectosTipo.Where(idm_activo => idm_activo.activo_b == true).ToList();

                IEnumerable<SelectListItem> lstCiudades =
                    from c in ciudades
                    select new SelectListItem
                    {
                        Text = c.nombre_c,
                        Value = c.id.ToString()
                    };

                ViewBag.lstCiudades = lstCiudades;

                IEnumerable<SelectListItem> lstProyectosTipos =
                    from c in proyectosTipos
                    select new SelectListItem
                    {
                        Text = c.nombre_c,
                        Value = c.id.ToString()
                    };

                ViewBag.lstProyectosTipos = lstProyectosTipos;

                return View(argProyecto);
            }
            return View();
        }
        public ActionResult VerProyecto(int? id)
        {

            var proyecto = db.Proyectos.Where(p => p.id == id).FirstOrDefault();
            ViewBag.totalProyectos = db.Proyectos.Count(p => p.id == id);
            return View(proyecto);
        }
    }
}