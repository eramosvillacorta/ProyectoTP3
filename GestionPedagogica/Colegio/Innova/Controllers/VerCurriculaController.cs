using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Innova.Models;

namespace Innova.Controllers
{
    public class VerCurriculaController : Controller
    {
        //
        // GET: /VerCurricula/

        public ActionResult Index(string key)
        {
            Curricula curricula = null;

            if (!string.IsNullOrWhiteSpace(key))
            {
                curricula = GestionPedagogica.ObtenerCurricula(int.Parse(key));
            }

            return View("Index", curricula);
        }

    }
}
