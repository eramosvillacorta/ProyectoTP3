using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Innova.Models;
using System.Web.Script.Serialization;

namespace Innova.Controllers
{
    public class CursoController : Controller
    {
        //
        // GET: /Curso/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Consultar()
        {
            return PartialView("_Consulta");
        }

        public PartialViewResult Listar(string codigo, string nombre, int area, int nivel, int grado, bool estado)
        {
            Curso cursoFiltro = new Curso()
            {
                Codigo = codigo,
                Nombre = nombre,
                IdAreaCurricular = area,
                Grado = new Grado() { IdNivel = nivel },
                IdGrado = grado,
                Estado = estado
            };

            List<Curso> objLista = GestionPedagogica.BuscarCurso(cursoFiltro);

            return PartialView("_Lista", objLista);
        }

        public PartialViewResult Obtener(int v)
        {
            Curso objCurso = new Curso() { Grado = new Grado() };

            if (v == 0)
                ViewBag.TituloCurso = "Nuevo Curso";
            else
            {
                ViewBag.TituloCurso = "Actualizar Curso";
                objCurso = GestionPedagogica.ObtenerCurso(v);
            }

            return PartialView("_Registro", objCurso);
        }


        public string ObtenerCodigo(int area)
        {
            return GestionPedagogica.ObtenerCodigoCurso(area);
        }

        public string ListarGrado(int nivel)
        {
            string htmlOption = "<option value=\"0\">Seleccione</option>";

            if (nivel >= 0)
            {
                List<Grado> objLista = GestionPedagogica.ListarGrado(nivel);

                foreach (Grado item in objLista)
                {
                    htmlOption += "<option value=\"" + item.IdGrado + "\">" + item.Nombre + "</option>";
                }
            }

            return htmlOption;
        }

        public object Guardar(int id, string codigo, string nombre, int area, string sumilla,
            int grado, int coordinador, bool estado, string tema)
        {
            object objRespuesta = new { Exito = "Curso registrado exitosamente" };

            try
            {
                List<CursoTema> cursoTema = new List<CursoTema>();

                if (tema.Length > 0)
                {
                    foreach (string fila in tema.Split('~'))
                    {
                        string[] item = fila.Split('|');

                        if (item.Length > 1)
                        {
                            cursoTema.Add(new CursoTema()
                            {
                                IdCursoTema = int.Parse(item[0]),
                                IdCurso = id,
                                Temario = item[1],
                                EstTemario = "1"
                            });
                        }
                    }
                }

                Curso curso = new Curso()
                {
                    IdCurso = id,
                    Codigo = codigo,
                    Nombre = nombre,
                    IdAreaCurricular = area,
                    Sumilla = sumilla,
                    IdGrado = grado,
                    IdEmpleado = coordinador,
                    Estado = estado,
                    CursoTema = cursoTema
                };

                GestionPedagogica.RegistrarCurso(curso);
            }
            catch (Exception ex)
            {
                objRespuesta = new { Error = ex.Message };
            }

            return new JavaScriptSerializer().Serialize(objRespuesta);
        }
    }
}
