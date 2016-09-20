﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InnovaSchool.Entity;
using InnovaSchool.DAL;

namespace InnovaSchool.BL
{
    public class BActividad
    {
        DActividad DActividad = new DActividad();

        public List<EActividad> ListarActividadesCalendario(EActividad EActividad)
        {
            return DActividad.ListarActividadesCalendario(EActividad);
        }

        public List<EActividad> ConsultarActividadCalendarioFiltro(EActividad EActividad)
        {
            return DActividad.ConsultarActividadCalendarioFiltro(EActividad);
        }

        public int RegistrarActividad(EActividad EActividad, EUsuario EUsuario, ECalendario ECalendario)
        {
            return DActividad.RegistrarActividad(EActividad, EUsuario, ECalendario);
        }

        public EActividad ConsultarActividadCalendario(EActividad EActividad)
        {
            return DActividad.ConsultarActividadCalendario(EActividad);
        }

        public int EliminarActividad(EActividad EActividad)
        {
            return DActividad.EliminarActividad(EActividad);
        }

        public List<EDetalleActividad> ConsultarDetalleActividad(EActividad EActividad)
        {
            return DActividad.ConsultarDetalleActividad(EActividad);
        }

        public int VerificarCruceActividad(EActividad EActividad)
        {
            return DActividad.VerificarCruceActividad(EActividad);
        }

        public List<EActividad> ConsultarActividadesAfectadas(EActividad EActividad)
        {
            return DActividad.ConsultarActividadesAfectadas(EActividad);
        }
    }
}
