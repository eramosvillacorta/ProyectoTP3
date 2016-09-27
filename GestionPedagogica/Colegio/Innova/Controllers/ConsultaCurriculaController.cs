using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Innova.Models;

namespace Innova.Controllers
{
    public class ConsultaCurriculaController : Controller
    {
        //
        // GET: /ConsultaCurricula/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Consultar()
        {
            return PartialView("_Consulta");
        }

        public ActionResult Listar(string codigo, int inicio, int fin, int estado)
        {
            Curricula curriculaFiltro = new Curricula()
            {
                Codigo = codigo,
                Estado = estado
            };

            List<Curricula> objLista = GestionPedagogica.BuscarCurricula(curriculaFiltro, inicio, fin);

            return PartialView("_Lista", objLista);
        }
    }
}
