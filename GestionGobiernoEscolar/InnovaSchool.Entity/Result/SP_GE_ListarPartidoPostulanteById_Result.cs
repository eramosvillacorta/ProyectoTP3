﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnovaSchool.Entity.Result
{
    public class SP_GE_ListarPartidoPostulanteById_Result
    {
        public int IdPartido { get; set; }
        public string Nombre { get; set; }
        public string Estado { get; set; }
        public byte[] Logo { get; set; }
    }
}
