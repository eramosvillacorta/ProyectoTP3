using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnovaSchool.Entity
{
    public class EEmpleado
    {
        public int IdEmpleado { get; set; }
        public string Nombre { get; set; }

        public int IdPuesto { get; set; }

        public int HorasAsignadas { get; set; }
    }
}
