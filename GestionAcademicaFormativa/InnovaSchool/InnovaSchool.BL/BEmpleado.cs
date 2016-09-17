using InnovaSchool.DAL;
using InnovaSchool.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnovaSchool.BL
{
    public class BEmpleado
    {
        DEmpleado DEmpleado = new DEmpleado();

        public List<EEmpleado> ListarResponsable(EEmpleado EEmpleado)
        {
            return DEmpleado.ListarResponsable(EEmpleado);
        }

        public List<EEmpleado> ListarResponsableSemana(EEmpleado EEmpleado, DateTime fechaInicio, DateTime fechaFin)
        {
            return DEmpleado.ListarResponsableSemana(EEmpleado, fechaInicio, fechaFin);
        }
    }
}
