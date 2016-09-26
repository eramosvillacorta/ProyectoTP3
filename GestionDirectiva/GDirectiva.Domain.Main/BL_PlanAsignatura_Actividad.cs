using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GDirectiva.Core.Entities;
using GDirectiva.Infraestructure.Data.Sql;
using GDirectiva.Cross.Core.Exception;
using GDirectiva.Core.Entities.General;

namespace GDirectiva.Domain.Main
{
    public class BL_PlanAsignatura_Actividad
    {
        public ProcessResult<List<PA_ACTIVIDAD_PLAN_ASIGNATURA_LISTA_Result>> ListarActividadPlanAsignatura(int planAsignaturaId, int pAGINA_INICIO, int tAMANIO_PAGINA)
        {
            ProcessResult<List<PA_ACTIVIDAD_PLAN_ASIGNATURA_LISTA_Result>> resultado = new ProcessResult<List<PA_ACTIVIDAD_PLAN_ASIGNATURA_LISTA_Result>>();
            try
            {
                DA_PlanAsignatura_Actividad objeto = new DA_PlanAsignatura_Actividad();
                resultado.Result = objeto.ListarActividadPlanAsignatura(planAsignaturaId, pAGINA_INICIO, tAMANIO_PAGINA);
            }
            catch (Exception e)
            {
                resultado.IsSuccess = false;
                resultado.Exception = new ApplicationLayerException<BL_PlanAsignatura_Actividad>(e);
            }
            return resultado;
        }

        public ProcessResult<List<EN_ReporteActividades>> ListarActividadPlanAsignatura2(int planAsignaturaId)
        {
            ProcessResult<List<EN_ReporteActividades>> resultado = new ProcessResult<List<EN_ReporteActividades>>();
            try
            {
                DA_PlanAsignatura_Actividad objeto = new DA_PlanAsignatura_Actividad();
                var listaActividades = objeto.ReporteListarActividadPlanAsignatura(planAsignaturaId);

                List<EN_ReporteActividades> ListaActividades = new List<EN_ReporteActividades>();

                foreach (var item in listaActividades.GroupBy(g => g.ID_PLANASIGNATURAMETA).ToList())
                {
                    EN_ReporteActividades reporte = new EN_ReporteActividades();
                    reporte.ID_META = item.Key;
                    reporte.META = listaActividades.FirstOrDefault(x => x.ID_PLANASIGNATURAMETA == item.Key).META;
                    reporte.ACTIVIDADES = listaActividades.Where(x => x.ID_PLANASIGNATURAMETA == item.Key).ToList();

                    ListaActividades.Add(reporte);
                }
                resultado.Result = ListaActividades;
                return resultado;
            }
            catch (Exception e)
            {
                resultado.IsSuccess = false;
                resultado.Exception = new ApplicationLayerException<BL_PlanAsignatura_Actividad>(e);
            }
            return resultado;
        }

        public ProcessResult<PA_REPORTE_RESUMEN_ACTIVIDAD_PLAN_ASIGNATURA_Result> ResumenActividadPlanAsignatura(int planAsignaturaId)
        {
            ProcessResult<PA_REPORTE_RESUMEN_ACTIVIDAD_PLAN_ASIGNATURA_Result> resultado = new ProcessResult<PA_REPORTE_RESUMEN_ACTIVIDAD_PLAN_ASIGNATURA_Result>();
            try
            {
                DA_PlanAsignatura_Actividad objeto = new DA_PlanAsignatura_Actividad();
                resultado.Result = objeto.ReporteResumenActividadPlanAsignatura(planAsignaturaId);
                return resultado;
            }
            catch (Exception e)
            {
                resultado.IsSuccess = false;
                resultado.Exception = new ApplicationLayerException<BL_PlanAsignatura_Actividad>(e);
            }
            return resultado;
        }
    }
}
