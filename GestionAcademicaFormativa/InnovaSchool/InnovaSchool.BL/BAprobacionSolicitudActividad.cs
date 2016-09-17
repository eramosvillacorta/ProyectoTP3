using InnovaSchool.DAL;
using InnovaSchool.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnovaSchool.BL
{
    public class BAprobacionSolicitudActividad
    {
        DAprobacionSolicitudActividad DAprobacionSolicitudActividad = new DAprobacionSolicitudActividad();

        public int RegistrarAprobacionSolicitudActividad(EAprobacionSolicitudActividad EAprobacionSolicitudActividad, EUsuario EUsuario, int IdEmpleado)
        {
            return DAprobacionSolicitudActividad.RegistrarAprobacionSolicitudActividad(EAprobacionSolicitudActividad, EUsuario, IdEmpleado);
        }
    }
}
