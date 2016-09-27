using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using Innova.Models;

namespace Innova.Controllers
{
    public class RegistroCurriculaController : Controller
    {
        //
        // GET: /CurriculaInnova/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Registro()
        {
            return PartialView("_Registro");
        }

        public ActionResult RegistroCurso()
        {
            return PartialView("_RegistroCurso");
        }

        public object ListarGradoProfesor(int nivel)
        {
            string htmlOptionGrado = "<option value=\"0\">Seleccione</option>";
            string htmlOptionProfesor = "<option value=\"0\">Seleccione</option>";
            string htmlOptionCurso = "<option value=\"0\">Seleccione</option>";

            if (nivel >= 0)
            {
                List<Grado> objListaGrado = GestionPedagogica.ListarGrado(nivel);

                foreach (Grado item in objListaGrado)
                {
                    htmlOptionGrado += "<option value=\"" + item.IdGrado + "\">" + item.Nombre + "</option>";
                }

                List<Empleado> objLista = GestionPedagogica.ListarProfesor(nivel);

                foreach (Empleado item in objLista)
                {
                    htmlOptionProfesor += "<option value=\"" + item.idEmpleado + "\">" + item.Persona.nombre + "</option>";
                }
            }

            return new JavaScriptSerializer().Serialize(new
            {
                htmlOptionGrado = htmlOptionGrado,
                htmlOptionProfesor = htmlOptionProfesor,
                htmlOptionCurso = htmlOptionCurso
            });
        }

        public object ListarCurso(int grado, int area)
        {
            string htmlOption = "<option value=\"0\">Seleccione</option>";
            decimal horaBase = 0;

            if (grado != 0 && area != 0)
            {
                Curso cursoFiltro = new Curso()
                {
                    IdAreaCurricular = area,
                    IdGrado = grado,
                    Estado = true
                };

                List<Curso> objLista = GestionPedagogica.BuscarCurso(cursoFiltro);
                PlanEstudiosBase objPlanEstudioBase = GestionPedagogica.ObtenerPlanEstudioBase(grado, area);

                foreach (Curso item in objLista)
                {
                    htmlOption += "<option value=\"" + item.IdCurso + "\">" + item.Nombre + "</option>";
                }

                horaBase = objPlanEstudioBase == null ? 0 : objPlanEstudioBase.Horas;
            }

            return new JavaScriptSerializer().Serialize(new
            {
                htmlOptionCurso = htmlOption,
                horaBase = horaBase
            });
        }

        public object ListarCursoTema(int curriculaBase, int curso)
        {
            List<CursoTema> objListaTema = new List<CursoTema>();
            List<Competencia> objListaCompentecia = new List<Competencia>();
            List<Unidad> objListaUnidad = new List<Unidad>();

            if (curso != 0)
            {
                objListaTema = GestionPedagogica.ObtenerCurso(curso).CursoTema.ToList();
            }

            if (curriculaBase != 0)
            {
                objListaCompentecia = GestionPedagogica.ListarCompetenciaCurriculaBase(curriculaBase);
            }

            objListaUnidad = GestionPedagogica.ListarUnidad();

            return new JavaScriptSerializer().Serialize(new
            {
                competencia = objListaCompentecia,
                unidad = objListaUnidad,
                tema = objListaTema
            });
        }

        public object AgregarCursoTema(int curriculaBase)
        {
            List<Competencia> objListaCompentecia = new List<Competencia>();
            List<Unidad> objListaUnidad = new List<Unidad>();

            if (curriculaBase != 0)
            {
                objListaCompentecia = GestionPedagogica.ListarCompetenciaCurriculaBase(curriculaBase);
            }

            objListaUnidad = GestionPedagogica.ListarUnidad();

            return new JavaScriptSerializer().Serialize(new
            {
                competencia = objListaCompentecia,
                unidad = objListaUnidad
            });
        }

        public object Guardar(int anho, int idCurriculaBase, string descripcion, int estado, string detalle,
            string detalletema, string detalleprofesor, string detallecalificacion)
        {
            object objRespuesta = null;

            try
            {
                List<DetalleCurricula> detalleCurricula = new List<DetalleCurricula>();

                if (detalle.Length > 0)
                {
                    foreach (string fila in detalle.Split('~'))
                    {
                        string[] item = fila.Split('|');

                        if (item.Length > 1)
                        {
                            detalleCurricula.Add(new DetalleCurricula()
                            {
                                IdCurso = int.Parse(item[0]),
                                IdCoordinador = int.Parse(item[1]),
                                Item = item[2],
                                HrsAsignadas = decimal.Parse(item[3])
                            });
                        }
                    }
                }

                List<DetalleCurriculaTema> detalleCurriculaTema = new List<DetalleCurriculaTema>();

                if (detalletema.Length > 0)
                {
                    foreach (string fila in detalletema.Split('~'))
                    {
                        string[] item = fila.Split('|');

                        if (item.Length > 1)
                        {
                            detalleCurriculaTema.Add(new DetalleCurriculaTema()
                            {
                                DetalleCurricula = new DetalleCurricula()
                                {
                                    IdCurso = int.Parse(item[0])
                                },
                                IdUnidad = int.Parse(item[1]),
                                IdCursoTema = int.Parse(item[2]),
                                NoCursoTema = item[3],
                                IdCompetencia = int.Parse(item[4])
                            });
                        }
                    }
                }

                List<DetalleCurriculaProfesor> detalleCurriculaProfesor = new List<DetalleCurriculaProfesor>();

                if (detalleprofesor.Length > 0)
                {
                    foreach (string fila in detalleprofesor.Split('~'))
                    {
                        string[] item = fila.Split('|');

                        if (item.Length > 1)
                        {
                            detalleCurriculaProfesor.Add(new DetalleCurriculaProfesor()
                            {
                                DetalleCurricula = new DetalleCurricula()
                                {
                                    IdCurso = int.Parse(item[0])
                                },
                                IdProfesor = int.Parse(item[1])
                            });
                        }
                    }
                }

                List<DetalleCurriculaCalificacion> detalleCurriculaCalificacion = new List<DetalleCurriculaCalificacion>();

                if (detallecalificacion.Length > 0)
                {
                    foreach (string fila in detallecalificacion.Split('~'))
                    {
                        string[] item = fila.Split('|');

                        if (item.Length > 1)
                        {
                            detalleCurriculaCalificacion.Add(new DetalleCurriculaCalificacion()
                            {
                                DetalleCurricula = new DetalleCurricula()
                                {
                                    IdCurso = int.Parse(item[0])
                                },
                                IdTipoCalificacion = int.Parse(item[1]),
                                ValorCalificacion = decimal.Parse(item[2])
                            });
                        }
                    }
                }

                Curricula curricula = new Curricula()
                {
                    IdCurriculaBase = idCurriculaBase,
                    Año = anho,
                    Descripcion = descripcion,
                    Estado = estado
                };

                GestionPedagogica.RegistrarCurricula(curricula, detalleCurricula, detalleCurriculaTema,
                    detalleCurriculaProfesor, detalleCurriculaCalificacion);

                objRespuesta = new
                {
                    Exito = "Curricula registrado exitosamente.",
                    Curricula = curricula.IdCurricula,
                    Estado = curricula.Estado
                };
            }
            catch (Exception ex)
            {
                objRespuesta = new { Error = ex.Message };
            }

            return new JavaScriptSerializer().Serialize(objRespuesta);
        }

        public object GuardarAprobacion(int curricula)
        {
            object objRespuesta = null;

            try
            {
                Curricula curriculaEstado = new Curricula()
                {
                    IdCurricula = curricula,
                    Estado = 3,
                    MotivoRechazo = string.Empty
                };

                GestionPedagogica.RegistrarCurriculaEstado(curriculaEstado);

                /*ENVIO DE CORREO*/
                Persona director = GestionPedagogica.ListarPersonaPuesto(5).FirstOrDefault();

                bool boEnvioCorreo = false;
                if (director != null)
                {
                    if (!string.IsNullOrWhiteSpace(director.correoElectronico))
                    {
                        string para = "frank.jgp14@gmail.com";
                        string asunto = "Revision de Nueva Curricula";
                        string mensaje = "Correo informativo para la aprobación de un nueva Curricula";
                        boEnvioCorreo = Utilidad.EnviarCorreo(para, asunto, mensaje);
                    }
                }

                objRespuesta = new { Exito = "Curricula enviado para su aprobación exitosamente." + (!boEnvioCorreo ? "  No se pudo enviar correo" : "") };
            }
            catch (Exception ex)
            {
                objRespuesta = new { Error = ex.Message };
            }

            return new JavaScriptSerializer().Serialize(objRespuesta);
        }
    }
}
