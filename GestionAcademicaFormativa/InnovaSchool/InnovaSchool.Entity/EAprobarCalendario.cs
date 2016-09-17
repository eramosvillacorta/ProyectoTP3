using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnovaSchool.Entity
{
    public class EAprobarCalendario
    {
        public int idMes { get; set; }
        public string Mes { get; set; }
        public string Tipo { get; set; }
        public int ActCulturales { get; set; }
        public int HorasCulturales { get; set; }
        public int ActDeportivas { get; set; }
        public int HorasDeportivas { get; set; }
        public int ActRecreativas { get; set; }
        public int HorasRecreativas { get; set; }
        public int TotalActividades { get; set; }
        public int TotalHoras { get; set; }

        public int IdActividad { get; set; }
        public string TipoActividad { get; set; }
        public string Nombre { get; set; }
        public string Responsable { get; set; }
        public string Estado { get; set; }
        public DateTime? FechaInicio { get; set; }
        public DateTime? FechaTermino { get; set; }
        public string idagenda { get; set; }
        public string idcalendario { get; set; }

        public string Alcance { get; set; }
        public string Descripcion { get; set; }

        public DateTime? Fecha { get; set; }
        public DateTime? HoraInicial { get; set; }
        public DateTime? HoraTermino { get; set; }
        public string Ubicacion { get; set; }
        public string Direccion { get; set; }

    }
}
