using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Innova.Models
{
    public class GestionPedagogica
    {

        public static List<Nivel> ListarNivel()
        {
            using (var cn = new InnovaEntities())
            {
                var lista = (from a in cn.Nivel
                             select a).ToList();

                return lista;
            }
        }

        public static List<Grado> ListarGrado(int idNivel)
        {
            using (var cn = new InnovaEntities())
            {
                var lista = (from a in cn.Grado
                             where a.IdNivel == idNivel
                             select a).ToList();

                return lista;
            }
        }

        public static List<Empleado> ListarCoordinador()
        {
            List<Empleado> lista = new List<Empleado>();

            using (var cn = new InnovaEntities())
            {
                var contrato = (from a in cn.Contrato
                                where a.idPuesto == 1
                                select a).ToList();

               
                lista = (from a in contrato
                         select new Empleado()
                             {
                                 idEmpleado = a.idEmpleado,
                                 Persona = new Persona() 
                                 { 
                                        nombre = a.Empleado.Persona.nombre + " " + a.Empleado.Persona.apellidoPaterno + " " + a.Empleado.Persona.apellidoMaterno 
                                 }
                             }).ToList();

               
            }

            return lista;
        }

        public static List<Unidad> ListarUnidad()
        {
            using (var cn = new InnovaEntities())
            {
                var lista = (from a in cn.Unidad
                             select a).ToList();

                return lista;
            }
        }


        public static List<AreaCurricular> ListarAreaCurricular()
        {

            using (var cn = new InnovaEntities())
            {
                var lista = (from a in cn.AreaCurricular
                             select a).ToList();

                return lista;
            }

        }

        public static List<Competencia> ListarCompetencia()
        {

            using (var cn = new InnovaEntities())
            {
                var lista = (from c in cn.Competencia
                             select c).ToList();

                return lista;
            }
        }

        public static bool RegistrarCurriculaBase(CurriculaBase Base)
        {
            using (var cn = new InnovaEntities())
            {
                try
                {
                    if (Base.IdCurriculaBase > 0)
                    {
                        var baseEdit = cn.CurriculaBase.FirstOrDefault(b => b.IdCurriculaBase == Base.IdCurriculaBase);
                        if (baseEdit != null)
                        {
                            baseEdit.Año = Base.Año;
                            baseEdit.NumeroResolucion = Base.NumeroResolucion;
                            baseEdit.Descripcion = Base.Descripcion;
                            baseEdit.Vigencia = Base.Vigencia;
                            cn.SaveChanges();
                        }
                    }
                    else
                    {
                        cn.CurriculaBase.Add(Base);
                        cn.SaveChanges();
                    }
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }

            }
        }


        public static List<CurriculaBase> ListarBase()
        {

            using (var cn = new InnovaEntities())
            {
                var lista = (from c in cn.CurriculaBase
                             select c).ToList();
                return lista;
            }
        }

        public static List<CurriculaBase> BuscarListaBase(string inicio, string fin, string resolucion)
        {
            using (var cn = new InnovaEntities())
            {
                List<CurriculaBase> lista = null;

                if (inicio != "" && fin == "" && resolucion == "")
                {
                    int iInicio = Convert.ToInt32(inicio);
                    lista = (from c in cn.CurriculaBase
                             where c.Año >= iInicio
                             select c).ToList();

                }

                if (inicio == "" && fin != "" && resolucion == "")
                {
                    int iFin = Convert.ToInt32(fin);
                    lista = (from c in cn.CurriculaBase
                             where c.Año <= iFin
                             select c).ToList();

                }

                if (inicio == "" && fin == "" && resolucion != "")
                {
                    lista = (from c in cn.CurriculaBase
                             where c.NumeroResolucion.Contains(resolucion)
                             select c).ToList();

                }

                if (inicio != "" && fin != "" && resolucion == "")
                {

                    int iInicio = Convert.ToInt32(inicio);
                    int iFin = Convert.ToInt32(fin);
                    lista = (from c in cn.CurriculaBase
                             where c.Año >= iInicio && c.Año <= iFin
                             select c).ToList();

                }

                return lista;

            }
        }

        public static CurriculaBase ObtenerBase(int idCurriculaBase)
        {
            using (var cn = new InnovaEntities())
            {
                return cn.CurriculaBase.FirstOrDefault(b => b.IdCurriculaBase == idCurriculaBase);
            }
        }

        public static bool RegistrarCompetenciaArea(CurriculaBaseCompetencia BaseCompetencia)
        {
            using (var cn = new InnovaEntities())
            {
                try
                {
                    cn.CurriculaBaseCompetencia.Add(BaseCompetencia);
                    cn.SaveChanges();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }

            }
        }


        public static List<ListaCompetenciaCapadidadArea> ListarCompetenciaCapadidadArea(int idCurriculaBase)
        {

            using (var cn = new InnovaEntities())
            {

                var listaRetorno = new List<ListaCompetenciaCapadidadArea>();

                listaRetorno = (from c in cn.CurriculaBaseCompetencia
                                join a in cn.AreaCurricular on c.IdAreaCurricular equals a.IdAreaCurricular
                                join comp in cn.Competencia on c.IdCompetencia equals comp.IdCompetencia
                                join cap in cn.Capacidad on comp.IdCompetencia equals cap.IdCompetencia into x
                                from lj in x.DefaultIfEmpty()
                                where c.IdCurriculaBase == idCurriculaBase
                                select new ListaCompetenciaCapadidadArea
                                {
                                    idCurriculaBaseCompetencia = c.IdCurriculaBaseCompetencia,
                                    idCurriculaBase = idCurriculaBase,
                                    areaCurricular = a.Nombre,
                                    competencia = comp.Nombre,
                                    capacidad = lj.Nombre
                                }).ToList();
                return listaRetorno;

            }
        }

        public static bool EliminarCompetenciaCapadidadArea(int idCurriculaBaseCompetencia)
        {

            using (var cn = new InnovaEntities())
            {
                try
                {
                    var baseCompetencia = cn.CurriculaBaseCompetencia.FirstOrDefault(c => c.IdCurriculaBaseCompetencia == idCurriculaBaseCompetencia);
                    if (baseCompetencia != null)
                    {
                        cn.CurriculaBaseCompetencia.Remove(baseCompetencia);
                        cn.SaveChanges();
                    }

                    return true;
                }
                catch (Exception)
                {
                    return false;
                }

            }

        }

        public class ListaCompetenciaCapadidadArea
        {
            public int idCurriculaBaseCompetencia { get; set; }
            public int idCurriculaBase { get; set; }
            public string areaCurricular { get; set; }
            public string competencia { get; set; }
            public string capacidad { get; set; }
        }

        #region "GESTIONAR CURSO"
        public static bool RegistrarCurso(Curso BaseCurso)
        {
            try
            {
                using (var cn = new InnovaEntities())
                {
                    if (BaseCurso.IdCurso == 0)
                    {
                        cn.Curso.Add(BaseCurso);
                        cn.SaveChanges();
                    }
                    else
                    {
                        var baseEdit = cn.Curso.FirstOrDefault(b => b.IdCurso == BaseCurso.IdCurso);
                        if (baseEdit != null)
                        {
                            baseEdit.Codigo = BaseCurso.Codigo;
                            baseEdit.Nombre = BaseCurso.Nombre;
                            baseEdit.IdAreaCurricular = BaseCurso.IdAreaCurricular;
                            baseEdit.Sumilla = BaseCurso.Sumilla;
                            baseEdit.IdGrado = BaseCurso.IdGrado;
                            baseEdit.IdEmpleado = baseEdit.IdEmpleado;
                            baseEdit.Estado = BaseCurso.Estado;
                            if (BaseCurso.CursoTema.Count > 0) baseEdit.CursoTema = BaseCurso.CursoTema;
                            cn.SaveChanges();
                        }
                    }
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static List<Curso> BuscarCurso(Curso BaseCurso)
        {
            List<Curso> lista = new List<Curso>();

            using (var cn = new InnovaEntities())
            {
                lista = cn.Curso.Where(x => x.Estado == BaseCurso.Estado).ToList();

                if (!string.IsNullOrWhiteSpace(BaseCurso.Codigo))
                {
                    lista = lista.Where(x => x.Codigo.ToLower().Contains(BaseCurso.Codigo.ToLower())).ToList();
                }

                if (!string.IsNullOrWhiteSpace(BaseCurso.Nombre))
                {
                    lista = lista.Where(x => x.Nombre.ToLower().Contains(BaseCurso.Nombre.ToLower())).ToList();
                }

                if (BaseCurso.IdAreaCurricular != 0)
                {
                    lista = lista.Where(x => x.IdAreaCurricular == BaseCurso.IdAreaCurricular).ToList();
                }

                if (BaseCurso.Grado.IdNivel >= 0)
                {
                    lista = lista.Where(x => x.Grado.IdNivel == BaseCurso.Grado.IdNivel).ToList();
                }

                if (BaseCurso.IdGrado != 0)
                {
                    lista = lista.Where(x => x.IdGrado == BaseCurso.IdGrado).ToList();
                }

                lista = (from j in lista
                         select new Curso
                         {
                             IdCurso = j.IdCurso,
                             Codigo = j.Codigo,
                             Nombre = j.Nombre,
                             IdAreaCurricular = j.IdAreaCurricular,
                             IdGrado = j.IdGrado,
                             Grado = new Grado()
                             {
                                 IdGrado = j.Grado.IdGrado,
                                 Nombre = j.Grado.Nombre,
                                 Nivel = new Nivel()
                                 {
                                     IdNivel = j.Grado.Nivel.IdNivel,
                                     Nombre = j.Grado.Nivel.Nombre
                                 }
                             },
                             Estado = j.Estado
                         }).ToList();
            }

            return lista;

        }

        public static Curso ObtenerCurso(int IdCurso)
        {
            Curso curso = null;

            using (var cn = new InnovaEntities())
            {
                curso = cn.Curso.Where(x => x.IdCurso == IdCurso).FirstOrDefault();

                curso = new Curso
                         {
                             IdCurso = curso.IdCurso,
                             Codigo = curso.Codigo,
                             Nombre = curso.Nombre,
                             Sumilla = curso.Sumilla,
                             IdAreaCurricular = curso.IdAreaCurricular,
                             IdGrado = curso.IdGrado,
                             Grado = new Grado()
                             {
                                 IdNivel = curso.Grado.IdNivel,
                                 IdGrado = curso.Grado.IdGrado,
                                 Nombre = curso.Grado.Nombre,
                                 Nivel = new Nivel()
                                 {
                                     IdNivel = curso.Grado.Nivel.IdNivel,
                                     Nombre = curso.Grado.Nivel.Nombre
                                 }
                             },
                             IdEmpleado = curso.IdEmpleado,
                             Estado = curso.Estado,
                             CursoTema = curso.CursoTema.Select(x => new CursoTema()
                             {
                                 IdUnidad = x.IdUnidad,
                                 Temario = x.Temario,
                                 Unidad = new Unidad()
                                 {
                                     Nombre = x.Unidad.Nombre
                                 }
                             }).ToList()
                         };
            }

            return curso;
        }
        #endregion

    }
}