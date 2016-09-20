using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InnovaSchool.Entity;
using InnovaSchool.DAL;

namespace InnovaSchool.BL
{
    public class BFeriado
    {
        DFeriado DFeriado = new DFeriado();

        public EFeriado VerificarFeriado(EActividad EActividad)
        {
            return DFeriado.VerificarFeriado(EActividad);
        }

        public EFeriado ConsultarFeriado(EFeriado EFeriado)
        {
            return DFeriado.ConsultarFeriado(EFeriado);
        }

        public List<EFeriado> ConsultarFeriadoLista(EFeriado EFeriado)
        {
            return DFeriado.ConsultarFeriadoLista(EFeriado);
        }

        public List<EFeriado> ConsultarCargaFeriados()
        {
            return DFeriado.ConsultarCargaFeriados();
        }

        public int RegistrarFeriado(EFeriado EFeriado, EUsuario EUsuario)
        {
            return DFeriado.RegistrarFeriado(EFeriado, EUsuario);
        }
        public int EliminarFeriado(EFeriado EFeriado)
        {
            return DFeriado.EliminarFeriado(EFeriado);
        }
        public int CargarFeriadoRepetitivos(EUsuario EUsuario)
        {
            return DFeriado.CargarFeriadoRepetitivos(EUsuario);
        }
        public List<EFeriado> ValidarExistenciaFeriado(EFeriado EFeriado)
        {
            return DFeriado.ValidarExistenciaFeriado(EFeriado);
        }
    }
}
