using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDirectiva.Core.Entities.General
{
    public class EN_ReporteActividades
    {
        public int ID_META { get; set; }
        public string META { get; set; }
        public List<PA_REPORTE_ACTIVIDAD_PLAN_ASIGNATURA_LISTA_Result> ACTIVIDADES { get; set; }
    }
}
