﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnovaSchool.Entity
{
    public class EAgenda
    {
        public string IdAgenda { get; set; }
        public string Descripcion { get; set; }
        public DateTime? fechaApertura { get; set; }
        public DateTime? fechaCierre { get; set; }
        public DateTime? fechaInicioEscolar { get; set; }
        public DateTime? FechaTerminoEscolar { get; set; }
        public int Estado { get; set; }
        public string UsuCreacion { get; set; }
        public DateTime? FecCreacion { get; set; }
        public string UsuModificación { get; set; }
        public DateTime? FecModificacion { get; set; }
    }
}
