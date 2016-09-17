using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InnovaSchool.Entity;
using InnovaSchool.DAL;

namespace InnovaSchool.BL
{
    public class BAprobarCalendario
    {
        DAprobarCalendario DAprobarCalendario = new DAprobarCalendario();
        public List<EAprobarCalendario> ListaAprobarCalendarioExtra(ECalendario eCalendario)
        {
            return DAprobarCalendario.ListaAprobarCalendarioExtra(eCalendario);
        }

        public List<EAprobarCalendario> ListadoActividades(EAprobarCalendario eAprobarCalendario)
        {
            return DAprobarCalendario.ListadoActividades(eAprobarCalendario);
        }

        public int ActualizarEstadoActividad(EAprobarCalendario eAprobarCalendario)
        {
            return DAprobarCalendario.ActualizarEstadoActividad(eAprobarCalendario);
        }
        public int ActualizarEstadoCalendario(EAprobarCalendario eAprobarCalendario)
        {
            return DAprobarCalendario.ActualizarEstadoCalendario(eAprobarCalendario);
        }

        public List<EAprobarCalendario> ActividadPrincipal(EAprobarCalendario eAprobarCalendario)
        {
            return DAprobarCalendario.ActividadPrincipal(eAprobarCalendario);
        }
        public List<EAprobarCalendario> DetalleActividad(EAprobarCalendario eAprobarCalendario)
        {
            return DAprobarCalendario.DetalleActividad(eAprobarCalendario);
        }
        public List<EAprobarCalendario> VerificarAprobarCalendario(EAprobarCalendario eAprobarCalendario)
        {
            return DAprobarCalendario.VerificarAprobarCalendario(eAprobarCalendario);
        }
        public List<EAprobarCalendario> CalendarioActual()
        {
            return DAprobarCalendario.CalendarioActual();
        }
    }
}
