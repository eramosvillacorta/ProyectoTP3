using GDirectiva.Core.Entities;
using GDirectiva.Core.Entities.Adapter;
using GDirectiva.Cross.Core.Exception;
using GDirectiva.Domain.Main;
using GDirectiva.Presentacion.Core.Controllers.Base;
using GDirectiva.Presentacion.Core.ViewModel.General;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;

namespace GDirectiva.Presentacion.Core.Controllers.General
{
    public class ReportePlanAsignaturaController : GenericController
    {

        #region Vistas
        /// <summary>
        /// Muestra la vista principal
        /// </summary>
        /// <returns>Vista principal de la opción</returns>
        public ActionResult Index()
        {
            var model = new ReportePlanAsignaturaBusquedaModel();
            var bl_PeriodoAcademico = new BL_PeriodoAcademico();
            
            model.ListaPeriodoAcademico = bl_PeriodoAcademico.ListarPeriodosAcademicos();

            return View(model);
        }

        public ActionResult ReporteCumplimiento(int pId_Plan_Asignatura)
        {
            var model = new ReporteCumplimientoModel();
            var bl_PlanAsignatura = new BL_PlanAsignatura();
            model.planAsignatura.ID_PLANASIGNATURA = pId_Plan_Asignatura;
            if (pId_Plan_Asignatura > 0)
            {
                model.planAsignatura = bl_PlanAsignatura.ObtenerPlanAsignatura(pId_Plan_Asignatura).Result;
            }
            return PartialView(model);
        }
        #endregion

        #region Vistas parciales
        
        #endregion

        #region JsonResult

        public JsonResult Buscar(int pId_Periodo, int pGD_Plan_Area_Id_Plan_Area, int pGD_Asignatura_Id_Asignatura)
        {
            var bl_PlanAsignatura = new BL_PlanAsignatura();
            var proceso = bl_PlanAsignatura.ListarPlanAsignatura(pId_Periodo, pGD_Plan_Area_Id_Plan_Area, pGD_Asignatura_Id_Asignatura, 0, 100);
            return Json(proceso);
        }

        public JsonResult ObtenerResumenPlanAsignatura(int pId_Plan_Asignatura)
        {
            var bl_PlanAsignatura_Actividad = new BL_PlanAsignatura_Actividad();
            var proceso = bl_PlanAsignatura_Actividad.ResumenActividadPlanAsignatura(pId_Plan_Asignatura);
            return Json(proceso);
        }

        public JsonResult BuscarActividades(int pId_Plan_Asignatura)
        {
            var bl_PlanAsignatura_Actividad = new BL_PlanAsignatura_Actividad();
            var proceso = bl_PlanAsignatura_Actividad.ListarActividadPlanAsignatura2(pId_Plan_Asignatura);
            return Json(proceso);
        }
        #endregion
    }
}
