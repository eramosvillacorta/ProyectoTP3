using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace Innova.Models
{
    public class GestionPedagogica
    {
        #region "LISTAS"
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
                                select a.Empleado).ToList();


                lista = (from a in contrato
                         select new Empleado()
                             {
                                 idEmpleado = a.idEmpleado,
                                 Persona = new Persona()
                                 {
                                     nombre = a.Persona.nombre + " " + a.Persona.apellidoPaterno + " " + a.Persona.apellidoMaterno
                                 }
                             }).ToList();


            }

            return lista;
        }

        public static List<Empleado> ListarProfesor(int idNivel)
        {
            List<Empleado> lista = new List<Empleado>();

            int idPuesto = 2;

            switch (idNivel)
            {
                case 0: idPuesto = 2; break;
                case 1: idPuesto = 3; break;
                case 2: idPuesto = 4; break;
            }

            using (var cn = new InnovaEntities())
            {
                var contrato = (from a in cn.Contrato
                                where a.idPuesto == idPuesto
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

        public static List<Persona> ListarPersonaPuesto(int idPuesto)
        {
            List<Persona> lista = new List<Persona>();

            //idPuesto = 1  -->"Coordinador de Curso";
            //idPuesto = 5  -->"Director Academico";

            using (var cn = new InnovaEntities())
            {
                var contrato = (from a in cn.Contrato
                                where a.idPuesto == idPuesto
                                select a).ToList();


                lista = (from a in contrato
                         select new Persona()
                         {
                             nombre = a.Empleado.Persona.nombre + " " + a.Empleado.Persona.apellidoPaterno + " " + a.Empleado.Persona.apellidoMaterno,
                             correoElectronico = a.Empleado.Persona.correoElectronico
                         }).ToList();
            }

            return lista;
        }

        public static List<Unidad> ListarUnidad()
        {
            using (var cn = new InnovaEntities())
            {
                List<Unidad> lista = (from a in cn.Unidad
                                      select a).ToList();

                lista = (from j in lista
                         select new Unidad()
                         {
                             IdUnidad = j.IdUnidad,
                             Nombre = j.Nombre
                         }).ToList();

                return lista;
            }
        }

        public static List<TipoCalificación> ListarTipoCalificacion()
        {
            List<TipoCalificación> lista = new List<TipoCalificación>();

            using (var cn = new InnovaEntities())
            {
                lista = (from a in cn.TipoCalificación
                         select a).ToList();
            }

            return lista;
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

        public static List<CurriculaBase> ListarBase()
        {

            using (var cn = new InnovaEntities())
            {
                var lista = (from c in cn.CurriculaBase
                             select c).ToList();
                return lista;
            }
        }

        public static List<Competencia> ListarCompetenciaCurriculaBase(int IdCurriculaBase)
        {

            using (var cn = new InnovaEntities())
            {
                List<Competencia> lista = (from c in cn.CurriculaBaseCompetencia
                                           where c.IdCurriculaBase == IdCurriculaBase
                                           select c.Competencia).ToList();

                lista = (from j in lista
                         select new Competencia()
                         {
                             IdCompetencia = j.IdCompetencia,
                             Nombre = j.Nombre
                         }).ToList();

                return lista;
            }
        }

        public static PlanEstudiosBase ObtenerPlanEstudioBase(int idGrado, int idAreaCurricular)
        {
            PlanEstudiosBase planEstudioBase = null;

            using (var cn = new InnovaEntities())
            {
                planEstudioBase = (from a in cn.PlanEstudiosBase
                                   where a.IdGrado == idGrado && a.IdAreaCurricular == idAreaCurricular
                                   select a).FirstOrDefault();
            }

            return planEstudioBase;
        }

        public static List<Capacidad> ListarCapacidad()
        {
            using (var cn = new InnovaEntities())
            {
                var lista = cn.Capacidad.ToList();
                return lista;
            }
        }

        #endregion

        #region "GESTIONAR CURRICULA BASE"
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
                            if (Convert.ToBoolean(Base.Vigencia))
                            {
                                cn.CurriculaBase.ToList().ForEach(s => s.Vigencia = false);
                                baseEdit.Vigencia = Base.Vigencia;
                            }
                            else
                            {
                                baseEdit.Vigencia = Base.Vigencia;
                            }
                            cn.SaveChanges();
                        }
                    }
                    else
                    {
                        // se valida que una resolución no se registre dos veces.
                        var baseEdit = cn.CurriculaBase.FirstOrDefault(b => b.NumeroResolucion.Trim() == Base.NumeroResolucion.Trim());
                        if (baseEdit != null)
                        {
                            return false;
                        }
                        else
                        {
                            if (Convert.ToBoolean(Base.Vigencia))
                            {
                                cn.CurriculaBase.ToList().ForEach(s => s.Vigencia = false);
                            }
                            cn.CurriculaBase.Add(Base);
                            cn.SaveChanges();
                        }
                    }
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }

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


        public static void EliminarPlanEstudioBase(int idCurriculaBase, int idAreaCurricular, int idNivel)
        {
            using (SqlConnection cn = new SqlConnection(Utilidad.conexionBDInnova()))
            {
                SqlCommand cmd = new SqlCommand("dbo.usp_GP_PlanEstudioBase_Eliminar", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@IdCurriculaBase", SqlDbType.Int).Value = idCurriculaBase;
                cmd.Parameters.Add("@IdAreaCurricular", SqlDbType.Int).Value = idAreaCurricular;
                cmd.Parameters.Add("@IdNivel", SqlDbType.Int).Value = idNivel;

                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
            }
        }

        #endregion

        #region "GESTIONAR COMPETENCIA-AREA"
        public static bool RegistrarCompetenciaArea(CurriculaBaseCompetencia BaseCompetencia)
        {
            using (var cn = new InnovaEntities())
            {
                try
                {
                    var ragistroValidacion = cn.CurriculaBaseCompetencia.FirstOrDefault(
                        c => c.IdAreaCurricular == BaseCompetencia.IdAreaCurricular
                        && c.IdCompetencia == BaseCompetencia.IdCompetencia && c.IdCurriculaBase == BaseCompetencia.IdCurriculaBase);

                    if (ragistroValidacion != null)
                    {
                        return false;
                    }
                    else
                    {
                        cn.CurriculaBaseCompetencia.Add(BaseCompetencia);
                        cn.SaveChanges();
                        return true;
                    }
                }
                catch (Exception)
                {
                    return false;
                }

            }
        }


        public static List<ListaCompetenciaCapacidadArea> ListarCompetenciaCapadidadArea(int idCurriculaBase)
        {

            using (var cn = new InnovaEntities())
            {

                var listaRetorno = new List<ListaCompetenciaCapacidadArea>();

                listaRetorno = (from c in cn.CurriculaBaseCompetencia
                                join a in cn.AreaCurricular on c.IdAreaCurricular equals a.IdAreaCurricular
                                join comp in cn.Competencia on c.IdCompetencia equals comp.IdCompetencia
                                //join cap in cn.Capacidad on comp.IdCompetencia equals cap.IdCompetencia into x
                                //from lj in x.DefaultIfEmpty()
                                where c.IdCurriculaBase == idCurriculaBase
                                select new ListaCompetenciaCapacidadArea
                                {
                                    idCurriculaBaseCompetencia = c.IdCurriculaBaseCompetencia,
                                    idCurriculaBase = idCurriculaBase,
                                    areaCurricular = a.Nombre,
                                    competencia = comp.Nombre,
                                    idAreaCurricula = a.IdAreaCurricular,
                                    idCompetencia = comp.IdCompetencia
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

        public class ListaCompetenciaCapacidadArea
        {
            public int idCurriculaBaseCompetencia { get; set; }
            public int idCurriculaBase { get; set; }
            public string areaCurricular { get; set; }
            public string competencia { get; set; }
            public int idCompetencia { get; set; }
            public int idAreaCurricula { get; set; }
            //public string capacidad { get; set; }

        }

        #endregion

        #region "GESTIONAR CURSO"
        public static void RegistrarCurso(Curso BaseCurso)
        {
            using (SqlConnection cn = new SqlConnection(Utilidad.conexionBDInnova()))
            {
                SqlCommand cmd = new SqlCommand("dbo.usp_GP_Curso_Registrar", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@IdCurso", SqlDbType.Int).Value = BaseCurso.IdCurso;
                cmd.Parameters.Add("@Codigo", SqlDbType.VarChar).Value = BaseCurso.Codigo;
                cmd.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = BaseCurso.Nombre;
                cmd.Parameters.Add("@Sumilla", SqlDbType.VarChar).Value = BaseCurso.Sumilla;
                cmd.Parameters.Add("@Estado", SqlDbType.Bit).Value = BaseCurso.Estado;
                cmd.Parameters.Add("@IdGrado", SqlDbType.Int).Value = BaseCurso.IdGrado;
                cmd.Parameters.Add("@IdAreaCurricular", SqlDbType.Int).Value = BaseCurso.IdAreaCurricular;
                cmd.Parameters.Add("@IdEmpleado", SqlDbType.Int).Value = BaseCurso.IdEmpleado;
                cmd.Parameters.Add("@CursoTemaXML", SqlDbType.Xml).Value = Utilidad.CursoTematoXML(BaseCurso.CursoTema.ToList());

                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
            }
        }

        public static List<Curso> BuscarCurso(Curso BaseCurso)
        {
            List<Curso> lista = new List<Curso>();

            try
            {
                using (SqlConnection cn = new SqlConnection(Utilidad.conexionBDInnova()))
                {
                    SqlCommand cmd = new SqlCommand("dbo.usp_GP_Curso_Listar", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@IdCurso", SqlDbType.Int).Value = BaseCurso.IdCurso;
                    cmd.Parameters.Add("@Codigo", SqlDbType.VarChar).Value = BaseCurso.Codigo;
                    cmd.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = BaseCurso.Nombre;
                    cmd.Parameters.Add("@Estado", SqlDbType.Bit).Value = BaseCurso.Estado;
                    cmd.Parameters.Add("@IdGrado", SqlDbType.Int).Value = BaseCurso.IdGrado;
                    cmd.Parameters.Add("@IdNivel", SqlDbType.Int).Value = (BaseCurso.Grado == null ? -1 : BaseCurso.Grado.IdNivel);
                    cmd.Parameters.Add("@IdAreaCurricular", SqlDbType.Int).Value = BaseCurso.IdAreaCurricular;

                    cn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            Curso curso = new Curso
                             {
                                 IdCurso = dr.IsDBNull(dr.GetOrdinal("IdCurso")) ? 0 : dr.GetInt32(dr.GetOrdinal("IdCurso")),
                                 Codigo = dr.IsDBNull(dr.GetOrdinal("Codigo")) ? string.Empty : dr.GetString(dr.GetOrdinal("Codigo")),
                                 Nombre = dr.IsDBNull(dr.GetOrdinal("Nombre")) ? string.Empty : dr.GetString(dr.GetOrdinal("Nombre")),
                                 Estado = dr.IsDBNull(dr.GetOrdinal("Estado")) ? false : dr.GetBoolean(dr.GetOrdinal("Estado")),

                                 IdGrado = dr.IsDBNull(dr.GetOrdinal("IdGrado")) ? 0 : dr.GetInt32(dr.GetOrdinal("IdGrado")),
                                 Grado = new Grado()
                                 {
                                     IdGrado = dr.IsDBNull(dr.GetOrdinal("IdGrado")) ? 0 : dr.GetInt32(dr.GetOrdinal("IdGrado")),
                                     Nombre = dr.IsDBNull(dr.GetOrdinal("noGrado")) ? string.Empty : dr.GetString(dr.GetOrdinal("noGrado")),
                                     IdNivel = dr.IsDBNull(dr.GetOrdinal("IdNivel")) ? 0 : dr.GetInt32(dr.GetOrdinal("IdNivel")),
                                     Nivel = new Nivel()
                                     {
                                         IdNivel = dr.IsDBNull(dr.GetOrdinal("IdNivel")) ? 0 : dr.GetInt32(dr.GetOrdinal("IdNivel")),
                                         Nombre = dr.IsDBNull(dr.GetOrdinal("noNivel")) ? string.Empty : dr.GetString(dr.GetOrdinal("noNivel"))
                                     }
                                 },

                                 IdAreaCurricular = dr.IsDBNull(dr.GetOrdinal("IdAreaCurricular")) ? 0 : dr.GetInt32(dr.GetOrdinal("IdAreaCurricular")),
                                 AreaCurricular = new AreaCurricular()
                                     {
                                         IdAreaCurricular = dr.IsDBNull(dr.GetOrdinal("IdAreaCurricular")) ? 0 : dr.GetInt32(dr.GetOrdinal("IdAreaCurricular")),
                                         Nombre = dr.IsDBNull(dr.GetOrdinal("noAreaCurricular")) ? string.Empty : dr.GetString(dr.GetOrdinal("noAreaCurricular"))
                                     },

                                 IdEmpleado = dr.IsDBNull(dr.GetOrdinal("IdEmpleado")) ? 0 : dr.GetInt32(dr.GetOrdinal("IdEmpleado")),
                                 Empleado = new Empleado()
                                 {
                                     idEmpleado = dr.IsDBNull(dr.GetOrdinal("IdEmpleado")) ? 0 : dr.GetInt32(dr.GetOrdinal("IdEmpleado")),
                                     Persona = new Persona()
                                     {
                                         nombre = dr.IsDBNull(dr.GetOrdinal("noEmpleado")) ? string.Empty : dr.GetString(dr.GetOrdinal("noEmpleado"))
                                     }
                                 }
                             };

                            lista.Add(curso);
                        }

                        /*Se obtiene registro de CursoTema solo cuando se consulta por idCurso*/
                        if (dr.NextResult())
                        {
                            List<CursoTema> listaTema = new List<CursoTema>();
                            while (dr.Read())
                            {
                                CursoTema cursotema = new CursoTema
                                {
                                    IdCursoTema = dr.IsDBNull(dr.GetOrdinal("IdCursoTema")) ? 0 : dr.GetInt32(dr.GetOrdinal("IdCursoTema")),
                                    IdCurso = dr.IsDBNull(dr.GetOrdinal("IdCurso")) ? 0 : dr.GetInt32(dr.GetOrdinal("IdCurso")),
                                    Temario = dr.IsDBNull(dr.GetOrdinal("Temario")) ? string.Empty : dr.GetString(dr.GetOrdinal("Temario")),
                                    EstTemario = dr.IsDBNull(dr.GetOrdinal("EstTemario")) ? "0" : dr.GetString(dr.GetOrdinal("EstTemario")),
                                };

                                listaTema.Add(cursotema);
                            }

                            foreach (Curso curso in lista.Where(x => x.IdCurso == listaTema.FirstOrDefault().IdCurso))
                            {
                                curso.CursoTema = listaTema;
                            }
                        }
                    }

                    cn.Close();
                }
            }
            catch { }

            return lista;
        }

        public static string ObtenerCodigoCurso(int IdAreaCurricular)
        {
            string codigo = string.Empty;

            try
            {
                using (SqlConnection cn = new SqlConnection(Utilidad.conexionBDInnova()))
                {
                    SqlCommand cmd = new SqlCommand("dbo.usp_GP_Curso_ObtenerCodigo", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@IdAreaCurricular", SqlDbType.Int).Value = IdAreaCurricular;

                    cn.Open();
                    codigo = cmd.ExecuteScalar().ToString();
                    cn.Close();
                }
            }
            catch { }

            return codigo;
        }

        public static Curso ObtenerCurso(int IdCurso)
        {
            Curso curso = BuscarCurso(new Curso() { IdCurso = IdCurso }).FirstOrDefault();

            return curso;
        }
        #endregion


        #region "GESTIONAR CURRICULA"
        public static void RegistrarCurricula(Curricula BaseCurricula, List<DetalleCurricula> detalleCurricula,
            List<DetalleCurriculaTema> detalleCurriculaTema, List<DetalleCurriculaProfesor> detalleCurriculaProfesor,
            List<DetalleCurriculaCalificacion> detalleCurriculaCalificacion)
        {
            using (SqlConnection cn = new SqlConnection(Utilidad.conexionBDInnova()))
            {
                SqlCommand cmd = new SqlCommand("dbo.usp_GP_Curricula_Registrar", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@IdCurricula", SqlDbType.Int).Value = BaseCurricula.IdCurricula;
                cmd.Parameters.Add("@IdCurriculaBase", SqlDbType.Int).Value = BaseCurricula.IdCurriculaBase;
                cmd.Parameters.Add("@Año", SqlDbType.Int).Value = BaseCurricula.Año;
                cmd.Parameters.Add("@Codigo", SqlDbType.VarChar).Value = BaseCurricula.Codigo;
                cmd.Parameters.Add("@Descripcion", SqlDbType.VarChar).Value = BaseCurricula.Descripcion;
                cmd.Parameters.Add("@Estado", SqlDbType.Int).Value = BaseCurricula.Estado;
                cmd.Parameters.Add("@DetalleCurriculaXML", SqlDbType.Xml).Value = Utilidad.DetalleCurriculatoXML(detalleCurricula);
                cmd.Parameters.Add("@DetalleCurriculaTemaXML", SqlDbType.Xml).Value = Utilidad.DetalleCurriculaTematoXML(detalleCurriculaTema);
                cmd.Parameters.Add("@DetalleCurriculaProfesorXML", SqlDbType.Xml).Value = Utilidad.DetalleCurriculaProfesortoXML(detalleCurriculaProfesor);
                cmd.Parameters.Add("@DetalleCurriculaCalificacionXML", SqlDbType.Xml).Value = Utilidad.DetalleCurriculaCalificaciontoXML(detalleCurriculaCalificacion);

                cn.Open();
                BaseCurricula.IdCurricula = int.Parse(cmd.ExecuteScalar().ToString());
                cn.Close();
            }
        }

        public static void RegistrarCurriculaEstado(Curricula BaseCurricula)
        {
            using (SqlConnection cn = new SqlConnection(Utilidad.conexionBDInnova()))
            {
                SqlCommand cmd = new SqlCommand("dbo.usp_GP_Curricula_RegistrarEstado", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@IdCurricula", SqlDbType.Int).Value = BaseCurricula.IdCurricula;
                cmd.Parameters.Add("@Estado", SqlDbType.Int).Value = BaseCurricula.Estado;
                cmd.Parameters.Add("@MotivoRechazo", SqlDbType.VarChar).Value = BaseCurricula.MotivoRechazo;

                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
            }
        }


        public static List<Curricula> BuscarCurricula(Curricula BaseCurricula, int AñoInicio = 0, int AñoFin = 0)
        {
            List<Curricula> lista = new List<Curricula>();

            try
            {
                using (SqlConnection cn = new SqlConnection(Utilidad.conexionBDInnova()))
                {
                    SqlCommand cmd = new SqlCommand("dbo.usp_GP_Curricula_Listar", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@IdCurricula", SqlDbType.Int).Value = BaseCurricula.IdCurricula;
                    cmd.Parameters.Add("@Codigo", SqlDbType.VarChar).Value = BaseCurricula.Codigo;
                    cmd.Parameters.Add("@AñoInicio", SqlDbType.Int).Value = AñoInicio;
                    cmd.Parameters.Add("@AñoFin", SqlDbType.Int).Value = AñoFin;
                    cmd.Parameters.Add("@Estado", SqlDbType.Int).Value = BaseCurricula.Estado;

                    cn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            Curricula curricula = new Curricula
                            {
                                IdCurricula = dr.IsDBNull(dr.GetOrdinal("IdCurricula")) ? 0 : dr.GetInt32(dr.GetOrdinal("IdCurricula")),
                                Codigo = dr.IsDBNull(dr.GetOrdinal("Codigo")) ? string.Empty : dr.GetString(dr.GetOrdinal("Codigo")),
                                Año = dr.IsDBNull(dr.GetOrdinal("Año")) ? 0 : dr.GetInt32(dr.GetOrdinal("Año")),
                                Descripcion = dr.IsDBNull(dr.GetOrdinal("Descripcion")) ? string.Empty : dr.GetString(dr.GetOrdinal("Descripcion")),
                                Estado = dr.IsDBNull(dr.GetOrdinal("Estado")) ? 0 : dr.GetInt32(dr.GetOrdinal("Estado")),

                                IdCurriculaBase = dr.IsDBNull(dr.GetOrdinal("IdCurriculaBase")) ? 0 : dr.GetInt32(dr.GetOrdinal("IdCurriculaBase")),
                                CurriculaBase = new CurriculaBase()
                                {
                                    IdCurriculaBase = dr.IsDBNull(dr.GetOrdinal("IdCurriculaBase")) ? 0 : dr.GetInt32(dr.GetOrdinal("IdCurriculaBase")),
                                    NumeroResolucion = dr.IsDBNull(dr.GetOrdinal("NumeroResolucion")) ? string.Empty : dr.GetString(dr.GetOrdinal("NumeroResolucion"))
                                },

                                IdUsuarioCreacion = dr.IsDBNull(dr.GetOrdinal("IdUsuarioCreacion")) ? 0 : dr.GetInt32(dr.GetOrdinal("IdUsuarioCreacion")),
                                NoUsuarioCreacion = dr.IsDBNull(dr.GetOrdinal("NoUsuarioCreacion")) ? string.Empty : dr.GetString(dr.GetOrdinal("NoUsuarioCreacion")),
                                FechaAprobacion = dr.IsDBNull(dr.GetOrdinal("FechaAprobacion")) ? DateTime.MinValue : dr.GetDateTime(dr.GetOrdinal("FechaAprobacion")),
                                FechaRechazo = dr.IsDBNull(dr.GetOrdinal("FechaRechazo")) ? DateTime.MinValue : dr.GetDateTime(dr.GetOrdinal("FechaRechazo")),
                                MotivoRechazo = dr.IsDBNull(dr.GetOrdinal("MotivoRechazo")) ? string.Empty : dr.GetString(dr.GetOrdinal("MotivoRechazo"))
                            };

                            lista.Add(curricula);
                        }

                        /*Se obtiene registro de DetalleCurricula solo cuando se consulta por idCurricula*/
                        if (dr.NextResult())
                        {
                            List<DetalleCurricula> listaDetalle = new List<DetalleCurricula>();
                            while (dr.Read())
                            {
                                DetalleCurricula detalle = new DetalleCurricula
                                {
                                    IdDetalleCurricula = dr.IsDBNull(dr.GetOrdinal("IdDetalleCurricula")) ? 0 : dr.GetInt32(dr.GetOrdinal("IdDetalleCurricula")),
                                    IdCurricula = dr.IsDBNull(dr.GetOrdinal("IdCurricula")) ? 0 : dr.GetInt32(dr.GetOrdinal("IdCurricula")),
                                    Item = dr.IsDBNull(dr.GetOrdinal("Item")) ? string.Empty : dr.GetString(dr.GetOrdinal("Item")),
                                    IdCurso = dr.IsDBNull(dr.GetOrdinal("IdCurso")) ? 0 : dr.GetInt32(dr.GetOrdinal("IdCurso")),
                                    Curso = new Curso()
                                    {
                                        IdCurso = dr.IsDBNull(dr.GetOrdinal("IdCurso")) ? 0 : dr.GetInt32(dr.GetOrdinal("IdCurso")),
                                        Nombre = dr.IsDBNull(dr.GetOrdinal("noCurso")) ? string.Empty : dr.GetString(dr.GetOrdinal("noCurso")),

                                        Grado = new Grado()
                                        {
                                            IdGrado = dr.IsDBNull(dr.GetOrdinal("IdGrado")) ? 0 : dr.GetInt32(dr.GetOrdinal("IdGrado")),
                                            Nombre = dr.IsDBNull(dr.GetOrdinal("noGrado")) ? string.Empty : dr.GetString(dr.GetOrdinal("noGrado")),

                                            Nivel = new Nivel()
                                            {
                                                IdNivel = dr.IsDBNull(dr.GetOrdinal("IdNivel")) ? 0 : dr.GetInt32(dr.GetOrdinal("IdNivel")),
                                                Nombre = dr.IsDBNull(dr.GetOrdinal("noNivel")) ? string.Empty : dr.GetString(dr.GetOrdinal("noNivel"))
                                            }
                                        },

                                        AreaCurricular = new AreaCurricular()
                                        {
                                            IdAreaCurricular = dr.IsDBNull(dr.GetOrdinal("IdAreaCurricular")) ? 0 : dr.GetInt32(dr.GetOrdinal("IdAreaCurricular")),
                                            Nombre = dr.IsDBNull(dr.GetOrdinal("noAreaCurricular")) ? string.Empty : dr.GetString(dr.GetOrdinal("noAreaCurricular"))
                                        }
                                    },
                                    HrsAsignadas = dr.IsDBNull(dr.GetOrdinal("HrsAsignadas")) ? 0 : dr.GetDecimal(dr.GetOrdinal("HrsAsignadas")),
                                    IdCoordinador = dr.IsDBNull(dr.GetOrdinal("IdCoordinador")) ? 0 : dr.GetInt32(dr.GetOrdinal("IdCoordinador")),
                                    Empleado = new Empleado()
                                    {
                                        idEmpleado = dr.IsDBNull(dr.GetOrdinal("IdCoordinador")) ? 0 : dr.GetInt32(dr.GetOrdinal("IdCoordinador")),
                                        Persona = new Persona()
                                        {
                                            nombre = dr.IsDBNull(dr.GetOrdinal("noCoordinador")) ? string.Empty : dr.GetString(dr.GetOrdinal("noCoordinador"))
                                        }
                                    }
                                };

                                listaDetalle.Add(detalle);
                            }

                            foreach (Curricula curricula in lista.Where(x => x.IdCurricula == listaDetalle.FirstOrDefault().IdCurricula))
                            {
                                curricula.DetalleCurricula = listaDetalle;
                            }
                        }


                        List<DetalleCurriculaTema> listaDetalleTema = new List<DetalleCurriculaTema>();
                        List<DetalleCurriculaProfesor> listaDetalleProfesor = new List<DetalleCurriculaProfesor>();
                        List<DetalleCurriculaCalificacion> listaDetalleCalificacion = new List<DetalleCurriculaCalificacion>();

                        /*Se obtiene registro de DetalleCurriculaTema solo cuando se consulta por idCurricula*/
                        if (dr.NextResult())
                        {
                            while (dr.Read())
                            {
                                DetalleCurriculaTema detalleTema = new DetalleCurriculaTema
                                {
                                    IdDetalleCurriculaTema = dr.IsDBNull(dr.GetOrdinal("IdDetalleCurriculaTema")) ? 0 : dr.GetInt32(dr.GetOrdinal("IdDetalleCurriculaTema")),
                                    IdDetalleCurricula = dr.IsDBNull(dr.GetOrdinal("IdDetalleCurricula")) ? 0 : dr.GetInt32(dr.GetOrdinal("IdDetalleCurricula")),
                                    IdCursoTema = dr.IsDBNull(dr.GetOrdinal("IdCursoTema")) ? 0 : dr.GetInt32(dr.GetOrdinal("IdCursoTema")),
                                    NoCursoTema = dr.IsDBNull(dr.GetOrdinal("Temario")) ? string.Empty : dr.GetString(dr.GetOrdinal("Temario")),
                                    IdCompetencia = dr.IsDBNull(dr.GetOrdinal("IdCompetencia")) ? 0 : dr.GetInt32(dr.GetOrdinal("IdCompetencia")),
                                    NoCompetencia = dr.IsDBNull(dr.GetOrdinal("noCompetencia")) ? string.Empty : dr.GetString(dr.GetOrdinal("noCompetencia")),

                                    IdUnidad = dr.IsDBNull(dr.GetOrdinal("IdUnidad")) ? 0 : dr.GetInt32(dr.GetOrdinal("IdUnidad")),
                                    Unidad = new Unidad()
                                    {
                                        IdUnidad = dr.IsDBNull(dr.GetOrdinal("IdUnidad")) ? 0 : dr.GetInt32(dr.GetOrdinal("IdUnidad")),
                                        Nombre = dr.IsDBNull(dr.GetOrdinal("noUnidad")) ? string.Empty : dr.GetString(dr.GetOrdinal("noUnidad"))
                                    }
                                };

                                listaDetalleTema.Add(detalleTema);
                            }
                        }

                        /*Se obtiene registro de DetalleCurriculaProfesor solo cuando se consulta por idCurricula*/
                        if (dr.NextResult())
                        {
                            while (dr.Read())
                            {
                                DetalleCurriculaProfesor detalleProfesor = new DetalleCurriculaProfesor
                                {
                                    IdDetalleCurriculaProfesor = dr.IsDBNull(dr.GetOrdinal("IdDetalleCurriculaProfesor")) ? 0 : dr.GetInt32(dr.GetOrdinal("IdDetalleCurriculaProfesor")),
                                    IdDetalleCurricula = dr.IsDBNull(dr.GetOrdinal("IdDetalleCurricula")) ? 0 : dr.GetInt32(dr.GetOrdinal("IdDetalleCurricula")),
                                    IdProfesor = dr.IsDBNull(dr.GetOrdinal("IdProfesor")) ? 0 : dr.GetInt32(dr.GetOrdinal("IdProfesor")),
                                    Empleado = new Empleado()
                                    {
                                        idEmpleado = dr.IsDBNull(dr.GetOrdinal("IdProfesor")) ? 0 : dr.GetInt32(dr.GetOrdinal("IdProfesor")),
                                        Persona = new Persona()
                                        {
                                            nombre = dr.IsDBNull(dr.GetOrdinal("noProfesor")) ? string.Empty : dr.GetString(dr.GetOrdinal("noProfesor"))
                                        }
                                    }
                                };

                                listaDetalleProfesor.Add(detalleProfesor);
                            }
                        }

                        /*Se obtiene registro de DetalleCurriculaCalificacion solo cuando se consulta por idCurricula*/
                        if (dr.NextResult())
                        {
                            while (dr.Read())
                            {
                                DetalleCurriculaCalificacion detalleCalificacion = new DetalleCurriculaCalificacion
                                {
                                    IdDetalleCurriculaCalificacion = dr.IsDBNull(dr.GetOrdinal("IdDetalleCurriculaCalificacion")) ? 0 : dr.GetInt32(dr.GetOrdinal("IdDetalleCurriculaCalificacion")),
                                    IdDetalleCurricula = dr.IsDBNull(dr.GetOrdinal("IdDetalleCurricula")) ? 0 : dr.GetInt32(dr.GetOrdinal("IdDetalleCurricula")),
                                    IdTipoCalificacion = dr.IsDBNull(dr.GetOrdinal("IdTipoCalificacion")) ? 0 : dr.GetInt32(dr.GetOrdinal("IdTipoCalificacion")),
                                    TipoCalificación = new TipoCalificación()
                                    {
                                        IdTipoCalificación = dr.IsDBNull(dr.GetOrdinal("IdTipoCalificacion")) ? 0 : dr.GetInt32(dr.GetOrdinal("IdTipoCalificacion")),
                                        NomTipoCalificación = dr.IsDBNull(dr.GetOrdinal("NomTipoCalificación")) ? string.Empty : dr.GetString(dr.GetOrdinal("NomTipoCalificación"))
                                    },
                                    ValorCalificacion = dr.IsDBNull(dr.GetOrdinal("ValorCalificacion")) ? 0 : dr.GetDecimal(dr.GetOrdinal("ValorCalificacion")),
                                };

                                listaDetalleCalificacion.Add(detalleCalificacion);
                            }
                        }

                        foreach (DetalleCurricula detalle in lista.FirstOrDefault().DetalleCurricula.ToList())
                        {
                            detalle.DetalleCurriculaTema = listaDetalleTema.Where(x => x.IdDetalleCurricula == detalle.IdDetalleCurricula).ToList();
                            detalle.DetalleCurriculaProfesor = listaDetalleProfesor.Where(x => x.IdDetalleCurricula == detalle.IdDetalleCurricula).ToList();
                            detalle.DetalleCurriculaCalificacion = listaDetalleCalificacion.Where(x => x.IdDetalleCurricula == detalle.IdDetalleCurricula).ToList();
                        }
                    }

                    cn.Close();
                }
            }
            catch { }

            return lista;
        }

        public static Curricula ObtenerCurricula(int IdCurricula)
        {
            Curricula curricula = BuscarCurricula(new Curricula() { IdCurricula = IdCurricula }).FirstOrDefault();

            return curricula;
        }
        #endregion

    }
}