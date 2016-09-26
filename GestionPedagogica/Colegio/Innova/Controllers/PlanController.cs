using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Innova.Models;
using System.Web.Script.Serialization;

namespace Innova.Controllers
{
    public class PlanController : Controller
    {
        //
        // GET: /Plan/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult DatosPrincipales()
        {
            ViewBag.IdCurriculabase = Request.QueryString["vParam1"].ToString();
            ViewBag.Anio = Request.QueryString["vParam2"].ToString();
            return PartialView();
        }

        public ActionResult PlanPrimaria()
        {
            bool boCurriculaBaseAsignada = false;
            int IdCurricula = Convert.ToInt32(Request.QueryString["vParam1"].ToString());
            int Anio = Convert.ToInt32(Request.QueryString["vParam2"].ToString());

            if (GestionPedagogica.BuscarCurricula(new Curricula() { Estado = 4 }).Where(x => x.IdCurriculaBase == IdCurricula).Count() > 0)
            {
                boCurriculaBaseAsignada = true;
            }

            ViewBag.IdCurricula = IdCurricula;
            ViewBag.boCurriculaBaseAsignada = boCurriculaBaseAsignada;
            ViewBag.ListaPrimaria = Plan.ListarPlanPrimaria(IdCurricula);


            return PartialView();
        }

        public ActionResult PlanSecundaria()
        {
            bool boCurriculaBaseAsignada = false;

            int IdCurricula = Convert.ToInt32(Request.QueryString["vParam1"].ToString());
            int Anio = Convert.ToInt32(Request.QueryString["vParam2"].ToString());

            if (GestionPedagogica.BuscarCurricula(new Curricula() { Estado = 4 }).Where(x => x.IdCurriculaBase == IdCurricula).Count() > 0)
            {
                boCurriculaBaseAsignada = true;
            }

            ViewBag.IdCurricula = IdCurricula;
            ViewBag.boCurriculaBaseAsignada = boCurriculaBaseAsignada;
            ViewBag.ListaSecundaria = Plan.ListarPlanSecundaria(IdCurricula);

            return PartialView();
        }

        public ActionResult FormPlanPrimaria(int idAreaCurricular = 0)
        {
            int IdCurricula = Convert.ToInt32(Request.QueryString["vParam1"].ToString());
            ViewBag.IdCurricula = IdCurricula;
            PlanPrimariaModel plan = new PlanPrimariaModel();
            plan = Plan.ListarPlanPrimariaByIdArea(IdCurricula, idAreaCurricular);
            if (idAreaCurricular == 0)
            {
                ViewBag.listaArea = new SelectList(AreaModel1.ListarAreaCurricular(), "IdAreaCurricular", "Nombre");
            }
            else
            {
                ViewBag.listaArea = new SelectList(AreaModel1.ListarAreaCurricularById(idAreaCurricular), "IdAreaCurricular", "Nombre");
            }
            ViewBag.Plan = plan;
            return PartialView();
        }

        public ActionResult FormPlanSecundaria(int idAreaCurricular = 0)
        {
            int IdCurricula = Convert.ToInt32(Request.QueryString["vParam1"].ToString());
            ViewBag.IdCurricula = IdCurricula;
            PlanSecundariaModel plan = new PlanSecundariaModel();
            plan = Plan.ListarPlanSecundariaByIdArea(IdCurricula, idAreaCurricular);
            if (idAreaCurricular == 0)
            {
                ViewBag.listaArea = new SelectList(AreaModel1.ListarAreaCurricular(), "IdAreaCurricular", "Nombre");
            }
            else
            {
                ViewBag.listaArea = new SelectList(AreaModel1.ListarAreaCurricularById(idAreaCurricular), "IdAreaCurricular", "Nombre");
            }
            ViewBag.Plan = plan;
            return PartialView();
        }


        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult RegistrarPlanPrimaria(FormCollection form)
        {
            object objRespuesta = null;

            var operacion = form["hOperacion"].ToString();
            var idCurriculaBase = form["hIdCurriculaBase"].ToString() != string.Empty ? Convert.ToInt32(form["hIdCurriculaBase"].ToString()) : 0;
            var idAreaCurricular = Convert.ToInt32(form["ddlArea"]);

            if (operacion == "0")
            {
                if (Plan.ListarPlanPrimaria(idCurriculaBase).Where(x => x.idAreaCurricular == idAreaCurricular).Count() > 0)
                {
                    objRespuesta = new { exito = false, mensaje = "El área curricular ya tiene asignado horas para los grados de primaria." };
                }
            }

            if (objRespuesta == null)
            {
                var HoraGrado1 = form["txtGrado1"];
                var HoraGrado2 = form["txtGrado2"];
                var HoraGrado3 = form["txtGrado3"];
                var HoraGrado4 = form["txtGrado4"];
                var HoraGrado5 = form["txtGrado5"];
                var HoraGrado6 = form["txtGrado6"];

                var setPlan = new PlanPrimariaModel()
                {
                    idCurriculaBase = idCurriculaBase,
                    idAreaCurricular = idAreaCurricular,
                    HorasGrado1 = Convert.ToDecimal(HoraGrado1),
                    HorasGrado2 = Convert.ToDecimal(HoraGrado2),
                    HorasGrado3 = Convert.ToDecimal(HoraGrado3),
                    HorasGrado4 = Convert.ToDecimal(HoraGrado4),
                    HorasGrado5 = Convert.ToDecimal(HoraGrado5),
                    HorasGrado6 = Convert.ToDecimal(HoraGrado6)
                };

                bool exito = Plan.RegistrarPlanPrimaria(setPlan);

                objRespuesta = new { exito = exito, mensaje = "" };
            }

            var js = new JavaScriptSerializer();
            return Content(js.Serialize(objRespuesta));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult RegistrarPlanSecundaria(FormCollection form)
        {
            object objRespuesta = null;

            var operacion = form["hOperacion"].ToString();
            var idCurriculaBase = Convert.ToInt32(form["hIdCurriculaBase"]);
            var idAreaCurricular = Convert.ToInt32(form["ddlArea"]);

             if (operacion == "0")
            {
                if (Plan.ListarPlanSecundaria(idCurriculaBase).Where(x => x.idAreaCurricular == idAreaCurricular).Count() > 0)
                {
                    objRespuesta = new { exito = false, mensaje = "El área curricular ya tiene asignado horas para los grados de secundaria." };
                }
            }

             if (objRespuesta == null)
             {
                 var HoraGrado1 = form["txtGrado1"];
                 var HoraGrado2 = form["txtGrado2"];
                 var HoraGrado3 = form["txtGrado3"];
                 var HoraGrado4 = form["txtGrado4"];
                 var HoraGrado5 = form["txtGrado5"];

                 var setPlan = new PlanSecundariaModel()
                 {
                     idCurriculaBase = idCurriculaBase,
                     idAreaCurricular = idAreaCurricular,
                     HorasGrado1 = Convert.ToDecimal(HoraGrado1),
                     HorasGrado2 = Convert.ToDecimal(HoraGrado2),
                     HorasGrado3 = Convert.ToDecimal(HoraGrado3),
                     HorasGrado4 = Convert.ToDecimal(HoraGrado4),
                     HorasGrado5 = Convert.ToDecimal(HoraGrado5),
                 };

                 bool exito = Plan.RegistrarPlanSecundaria(setPlan);
                 
                 objRespuesta = new { exito = exito, mensaje = "" };
             }

            var js = new JavaScriptSerializer();
            return Content(js.Serialize(objRespuesta));
        }



        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult EliminarPlan(int idAreaCurricular = 0, int idNivel = 0)
        {
            int IdCurricula = Convert.ToInt32(Request.QueryString["vParam1"].ToString());

            GestionPedagogica.EliminarPlanEstudioBase(IdCurricula, idAreaCurricular, idNivel);

            var js = new JavaScriptSerializer();
            return Content(js.Serialize(true));
        }
    }
}
