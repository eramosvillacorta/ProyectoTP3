using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using Innova.Models;

namespace Innova.Controllers
{
    public class AprobarCurriculaController : Controller
    {
        //
        // GET: /AprobarCurricula/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Consultar()
        {
            return PartialView("_Consulta");
        }

        public ActionResult Listar(string codigo, int inicio, int fin)
        {
            Curricula curriculaFiltro = new Curricula()
            {
                Codigo = codigo,
                Estado = 3 //-->En Revision
            };

            List<Curricula> objLista = GestionPedagogica.BuscarCurricula(curriculaFiltro, inicio, fin);

            return PartialView("_Lista", objLista);
        }

        public object GuardarEstado(int curricula, string codigo, int estado, string motivo)
        {
            object objRespuesta = null;

            try
            {
                string estadoText = (estado == 4 ? "aprobada" : "rechazado");

                Curricula curriculaEstado = new Curricula()
                {
                    IdCurricula = curricula,
                    Estado = estado,
                    MotivoRechazo = motivo
                };

                GestionPedagogica.RegistrarCurriculaEstado(curriculaEstado);

                /*ENVIO DE CORREO*/
                Persona coordinador = GestionPedagogica.ListarPersonaPuesto(1).FirstOrDefault();

                bool boEnvioCorreo = false;
                if (coordinador != null)
                {
                    if (!string.IsNullOrWhiteSpace(coordinador.correoElectronico))
                    {
                        string para = "frank.jgp14@gmail.com";
                        string asunto = "Curricula con codigo [" + codigo + "] " + estadoText;
                        string mensaje = "Correo informativo indicando que la Curricula con Codigo: [" + codigo + "] fue " + estadoText +
                            (estado != 4 ? ("<br>Motivo: " + motivo) : "");
                        boEnvioCorreo = Utilidad.EnviarCorreo(para, asunto, mensaje);
                    }
                }

                objRespuesta = new { Exito = string.Format("Curricula {0} exitosamente. {1}", estadoText, (!boEnvioCorreo ? " No se pudo enviar correo" : "")) };
            }
            catch (Exception ex)
            {
                objRespuesta = new { Error = ex.Message };
            }

            return new JavaScriptSerializer().Serialize(objRespuesta);
        }
    }
}
