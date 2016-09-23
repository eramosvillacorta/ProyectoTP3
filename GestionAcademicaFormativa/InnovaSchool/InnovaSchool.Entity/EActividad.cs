﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnovaSchool.Entity
{
    public class EActividad
    {
        public int IdActividad { get; set; }
        public int IdCalendario { get; set; }
        public string Nombre { get; set; }
        public DateTime? FechaInicio { get; set; }
        public DateTime? FechaTermino { get; set; }
        public string Descripcion { get; set; }
        public int IdEmpleado { get; set; }
        public string UsuCreacion { get; set; }
        public DateTime? FecCreacion { get; set; }
        public string UsuModificación { get; set; }
        public string Alcance { get; set; }
        public int Tipo { get; set; }
        public DateTime? FecModificacion { get; set; }
        public int Estado { get; set; }

        public string Solicitante { get; set; }

        public List<EDetalleActividad> ListaDetalleActividad { get; set; }
    }
}
