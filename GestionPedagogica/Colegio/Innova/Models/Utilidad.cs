using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Xml;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using System.Xml.Linq;
using System.Text;

namespace Innova.Models
{
    public class Utilidad
    {
        public static string conexionBDInnova()
        {
            return ConfigurationManager.ConnectionStrings["InnovaSchool"].ConnectionString;
        }
        public static string CursoTematoXML(List<CursoTema> lista)
        {

            XElement xml = new XElement("CursoTemas", from ct in lista
                                                      select new XElement("CursoTema",
                                                          new XAttribute("IdCursoTema", ct.IdCursoTema),
                                                          new XAttribute("IdCurso", ct.IdCurso),
                                                          new XAttribute("Temario", ct.Temario == null ? string.Empty : ct.Temario),
                                                          new XAttribute("EstTemario", ct.EstTemario == null ? string.Empty : ct.EstTemario)
                                                          ));

            return xml.ToString();
        }

        public static string DetalleCurriculatoXML(List<DetalleCurricula> lista)
        {

            XElement xml = new XElement("DetalleCurriculas",
                from ct in lista
                select new XElement("DetalleCurricula",
                    new XAttribute("IdCurricula", ct.IdCurricula),
                    new XAttribute("IdDetalleCurricula", ct.IdDetalleCurricula == null ? 0 : ct.IdDetalleCurricula),
                    new XAttribute("IdCurso", ct.IdCurso),
                    new XAttribute("IdCoordinador", ct.IdCoordinador),
                    new XAttribute("Item", ct.Item == null ? string.Empty : ct.Item),
                    new XAttribute("HrsAsignadas", ct.HrsAsignadas)
                ));

            return xml.ToString();
        }

        public static string DetalleCurriculaTematoXML(List<DetalleCurriculaTema> lista)
        {

            XElement xml = new XElement("DetalleCurriculaTemas",
                from ct in lista
                select new XElement("DetalleCurriculaTema",
                    new XAttribute("IdCurso", ct.DetalleCurricula == null ? 0 : ct.DetalleCurricula.IdCurso),
                    new XAttribute("IdDetalleCurricula", ct.IdDetalleCurricula == null ? 0 : ct.IdDetalleCurricula),
                    new XAttribute("IdUnidad", ct.IdUnidad),
                    new XAttribute("IdCursoTema", ct.IdCursoTema),
                    new XAttribute("Temario", string.IsNullOrWhiteSpace(ct.NoCursoTema) ? string.Empty : ct.NoCursoTema),
                    new XAttribute("IdCompetencia", ct.IdCompetencia)
                ));

            return xml.ToString();
        }

        public static string DetalleCurriculaProfesortoXML(List<DetalleCurriculaProfesor> lista)
        {

            XElement xml = new XElement("DetalleCurriculaProfesors",
                from ct in lista
                select new XElement("DetalleCurriculaProfesor",
                    new XAttribute("IdCurso", ct.DetalleCurricula == null ? 0 : ct.DetalleCurricula.IdCurso),
                    new XAttribute("IdDetalleCurricula", ct.IdDetalleCurricula == null ? 0 : ct.IdDetalleCurricula),
                    new XAttribute("IdProfesor", ct.IdProfesor)
                ));

            return xml.ToString();
        }

        public static string DetalleCurriculaCalificaciontoXML(List<DetalleCurriculaCalificacion> lista)
        {

            XElement xml = new XElement("DetalleCurriculaCalificacions",
                from ct in lista
                select new XElement("DetalleCurriculaCalificacion",
                    new XAttribute("IdCurso", ct.DetalleCurricula == null ? 0 : ct.DetalleCurricula.IdCurso),
                    new XAttribute("IdDetalleCurricula", ct.IdDetalleCurricula == null ? 0 : ct.IdDetalleCurricula),
                    new XAttribute("IdTipoCalificacion", ct.IdTipoCalificacion),
                    new XAttribute("ValorCalificacion", ct.ValorCalificacion)
                ));

            return xml.ToString();
        }


        public static bool EnviarCorreo(string para, string asunto, string mensaje)
        {
            try
            {
                string RemitenteNombre = "InnovaSchool";
                string RemitenteCorreo = "cuenta@gmail.com";
                string RemitenteClave = "contraseña";
                string RemitenteHost = "smtp.gmail.com";
                int RemitentePuerto = 587;
                bool RemitenteSSL = true;


                System.Net.Mail.MailMessage Mail = new System.Net.Mail.MailMessage();
                System.Net.Mail.SmtpClient ObjectSmtp = new System.Net.Mail.SmtpClient();

                Mail.From = new System.Net.Mail.MailAddress(RemitenteCorreo, RemitenteNombre);

                /*Agregamos los correos a enviar To*/
                if (!string.IsNullOrEmpty(para))
                    foreach (string item in para.Split(','))
                        if (item.Contains("@"))
                            Mail.To.Add(item);

                Mail.Subject = asunto;
                Mail.Body = mensaje;
                Mail.BodyEncoding = Encoding.GetEncoding("UTF-8");
                Mail.IsBodyHtml = true;
                Mail.Priority = System.Net.Mail.MailPriority.High;

                ObjectSmtp.Host = RemitenteHost;
                ObjectSmtp.Port = RemitentePuerto;
                ObjectSmtp.EnableSsl = RemitenteSSL;
                ObjectSmtp.Credentials = new System.Net.NetworkCredential(RemitenteCorreo, RemitenteClave);


                ObjectSmtp.Send(Mail);

                Mail.Dispose();
                ObjectSmtp.Dispose();

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}