﻿using GDirectiva.Core.Entities;
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
using System.Web.Mvc;

namespace GDirectiva.Presentacion.Core.Controllers.General
{
    public class PlanAsignaturaController : GenericController
    {

        #region Vistas
        /// <summary>
        /// Muestra la vista principal
        /// </summary>
        /// <returns>Vista principal de la opción</returns>
        public ActionResult Index()
        {
            var model = new PlanAsignaturaBusquedaModel();
            var bl_PeriodoAcademico = new BL_PeriodoAcademico();

            model.ListaPeriodoAcademico = bl_PeriodoAcademico.ListarPeriodosAcademicos();

            return View(model);
        }
        #endregion

        #region Vistas parciales
        public ActionResult FormularioRegistro(int pId_Plan_Asignatura)
        {
            var model = new PlanAsignaturaRegistroModel();

            return PartialView(model);
        }
        #endregion

        #region JsonResult

        public JsonResult BuscarPlanArea(int pId_Periodo)
        {
            ProcessResult<List<SelectListItem>> resultado = new ProcessResult<List<SelectListItem>>();
            resultado.Result = new List<SelectListItem>();
            var bl_PlanArea = new BL_PlanArea();
            var proceso = bl_PlanArea.ListarPlanAreaVigente(pId_Periodo);
            if (proceso != null)
            {
                proceso.Result.ForEach(delegate(PA_PLAN_AREA_LISTA_VIGENTE_Result plan)
                {
                    resultado.Result.Add(new SelectListItem() { Value = plan.ID_PLANAREA.ToString(), Text = plan.NOMBRE });
                });
            }
            else
            {
                resultado.Result = null;
            }
            return Json(resultado);
        }

        #endregion
    }
}
