﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GDirectiva.Core.Entities;
using GDirectiva.Infraestructure.Data.Sql;

namespace GDirectiva.Infraestructure.Data.Sql
{
    public class DA_PlanAsignatura_Actividad
    {
        public List<PA_ACTIVIDAD_PLAN_ASIGNATURA_LISTA_Result> ListarActividadPlanAsignatura(int planAsignaturaId, int pAGINA_INICIO, int tAMANIO_PAGINA)
        {
            using (DB_INNOVASCHOOLSEntities contexto = new DB_INNOVASCHOOLSEntities())
            {
                List<PA_ACTIVIDAD_PLAN_ASIGNATURA_LISTA_Result> objeto = new List<PA_ACTIVIDAD_PLAN_ASIGNATURA_LISTA_Result>();
                objeto = contexto.PA_ACTIVIDAD_PLAN_ASIGNATURA_LISTA(planAsignaturaId, pAGINA_INICIO, tAMANIO_PAGINA).ToList();
                return objeto;
            }
        }
        public List<PA_REPORTE_ACTIVIDAD_PLAN_ASIGNATURA_LISTA_Result> ReporteListarActividadPlanAsignatura(int planAsignaturaId)
        {
            using (DB_INNOVASCHOOLSEntities contexto = new DB_INNOVASCHOOLSEntities())
            {
                List<PA_REPORTE_ACTIVIDAD_PLAN_ASIGNATURA_LISTA_Result> objeto = new List<PA_REPORTE_ACTIVIDAD_PLAN_ASIGNATURA_LISTA_Result>();
                objeto = contexto.PA_REPORTE_ACTIVIDAD_PLAN_ASIGNATURA_LISTA(planAsignaturaId).ToList();
                return objeto;
            }
        }

        public PA_REPORTE_RESUMEN_ACTIVIDAD_PLAN_ASIGNATURA_Result ReporteResumenActividadPlanAsignatura(int planAsignaturaId)
        {
            using (DB_INNOVASCHOOLSEntities contexto = new DB_INNOVASCHOOLSEntities())
            {
                PA_REPORTE_RESUMEN_ACTIVIDAD_PLAN_ASIGNATURA_Result objeto = new PA_REPORTE_RESUMEN_ACTIVIDAD_PLAN_ASIGNATURA_Result();
                objeto = contexto.PA_REPORTE_RESUMEN_ACTIVIDAD_PLAN_ASIGNATURA(planAsignaturaId).FirstOrDefault();
                return objeto;
            }
        }
    }
}