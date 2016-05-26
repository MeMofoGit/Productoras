using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Productoras.Models;

namespace Productoras.Controllers
{
    public class HomeController : Controller
    {
        ProyectoEntities db = new ProyectoEntities();
        public ActionResult Index()
        {
            if (Session["id_usuario"] == null)
            {
                return View();
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

        public ActionResult navTop()
        {
            return PartialView("Partials/nav_top");
        }
    }
}