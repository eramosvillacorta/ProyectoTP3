using System.Linq;
using System.Configuration;

namespace InnovaSchool.UserLayer.Common
{
    public static class Constant
    {
        /* ---------- MENSAJES ---------- */
        //Login
        public static string TituloErrorLogin = ConfigurationManager.AppSettings["TituloErrorLogin"].Trim();
        public static string MensajeErrorLogin = ConfigurationManager.AppSettings["MensajeErrorLogin"].Trim();
        //Inicio
        public static string TituloInicio = ConfigurationManager.AppSettings["TituloInicio"].Trim();
        public static string SubtituloTituloInicio = ConfigurationManager.AppSettings["SubtituloTituloInicio"].Trim();
        //Apertura General
        public static string TituloApertura = ConfigurationManager.AppSettings["TituloApertura"].Trim();
        public static string TituloErrorApertura = ConfigurationManager.AppSettings["TituloErrorApertura"].Trim();
        //Apertura Agenda
        public static string MensajeAperturaAgenda = ConfigurationManager.AppSettings["MensajeAperturaAgenda"].Trim();
        public static string MensajeErrorAperturaAgenda = ConfigurationManager.AppSettings["MensajeErrorAperturaAgenda"].Trim();
        //Generar Agenda
        public static string TituloGenerarAgenda = ConfigurationManager.AppSettings["TituloGenerarAgenda"].Trim();
        public static string MensajeGenerarAgenda = ConfigurationManager.AppSettings["MensajeGenerarAgenda"].Trim();
        public static string MensajeErrorGenerarAgenda = ConfigurationManager.AppSettings["MensajeErrorGenerarAgenda"].Trim();
        //Calendario Agenda
        public static string TituloCalendarioAgenda = ConfigurationManager.AppSettings["TituloCalendarioAgenda"].Trim();
        public static string MensajeCalendarioAgenda = ConfigurationManager.AppSettings["MensajeCalendarioAgenda"].Trim();
        //Apertura Calendario
        public static string MensajeAperturaCalendarioAcademico = ConfigurationManager.AppSettings["MensajeAperturaCalendarioAcademico"].Trim();
        public static string MensajeErrorAperturaCalendarioAcademico = ConfigurationManager.AppSettings["MensajeErrorAperturaCalendarioAcademico"].Trim();
        public static string MensajeErrorAperturaCalendarioAcademicoAgenda = ConfigurationManager.AppSettings["MensajeErrorAperturaCalendarioAcademicoAgenda"].Trim();
        //Guardar Actividad
        public static string TituloRegistroActividad = ConfigurationManager.AppSettings["TituloRegistroActividad"].Trim();
        public static string MensajeConfirmarRegistroActividadExtracurricular = ConfigurationManager.AppSettings["MensajeConfirmarRegistroActividadExtracurricular"].Trim();        
        public static string MensajeRegistroActividadAcademica = ConfigurationManager.AppSettings["MensajeRegistroActividadAcademica"].Trim();
        public static string MensajeErrorRegistroActividadAcademica = ConfigurationManager.AppSettings["MensajeErrorRegistroActividadAcademica"].Trim();
        public static string MensajeEdicionActividadAcademica = ConfigurationManager.AppSettings["MensajeEdicionActividadAcademica"].Trim();
        public static string MensajeErrorEdicionActividadAcademica = ConfigurationManager.AppSettings["MensajeErrorEdicionActividadAcademica"].Trim();
        //Eliminar Actividad
        public static string TituloEliminarActividad = ConfigurationManager.AppSettings["TituloEliminarActividad"].Trim();
        public static string MensajeEliminarActividadAcademica = ConfigurationManager.AppSettings["MensajeEliminarActividadAcademica"].Trim();
        public static string MensajeErrorEliminarActividadAcademica = ConfigurationManager.AppSettings["MensajeErrorEliminarActividadAcademica"].Trim(); 

        public static string MensajeConfirmarEliminarActividadExtracurricular = ConfigurationManager.AppSettings["MensajeConfirmarEliminarActividadExtracurricular"].Trim();
        public static string MensajeEliminarActividadExtracurricular = ConfigurationManager.AppSettings["MensajeEliminarActividadExtracurricular"].Trim();
        public static string MensajeErrorEliminarActividad = ConfigurationManager.AppSettings["MensajeErrorEliminarActividad"].Trim();        
        
            
        //Actividad Feriado
        public static string TituloActividadFeriado = ConfigurationManager.AppSettings["TituloActividadFeriado"].Trim();
        public static string MensajeActividadFeriado = ConfigurationManager.AppSettings["MensajeActividadFeriado"].Trim();
        //Actividad Académica
        public static string TituloNoActividad = ConfigurationManager.AppSettings["TituloNoActividad"].Trim();
        public static string MensajeNoActividad = ConfigurationManager.AppSettings["MensajeNoActividad"].Trim();

        //Solicitud Actividad
        public static string TituloNoAgendaAprobada = ConfigurationManager.AppSettings["TituloNoAgendaAprobada"].Trim();
        public static string MensajeNoAgendaAprobada = ConfigurationManager.AppSettings["MensajeNoAgendaAprobada"].Trim();
        public static string TituloNoAgendaAperturada = ConfigurationManager.AppSettings["TituloNoAgendaAperturada"].Trim();

        public static string TituloCalendarioAprobado = ConfigurationManager.AppSettings["TituloCalendarioAprobado"].Trim();
        public static string MensajeCalendarioAprobado = ConfigurationManager.AppSettings["MensajeCalendarioAprobado"].Trim();

        public static string MensajeNoAgendaAperturada = ConfigurationManager.AppSettings["MensajeNoAgendaAperturada"].Trim();
        public static string TituloGuardarSolicitud = ConfigurationManager.AppSettings["TituloGuardarSolicitud"].Trim();
        public static string MensajeGuardarSolicitud = ConfigurationManager.AppSettings["MensajeGuardarSolicitud"].Trim();        
        public static string MensajeErrorGuardarSolicitud = ConfigurationManager.AppSettings["MensajeErrorGuardarSolicitud"].Trim();
        public static string TituloEnviarSolicitud = ConfigurationManager.AppSettings["TituloEnviarSolicitud"].Trim();
        public static string MensajeEnviarSolicitud = ConfigurationManager.AppSettings["MensajeEnviarSolicitud"].Trim();
        public static string MensajeConfirmarEnviarSolicitud = ConfigurationManager.AppSettings["MensajeConfirmarEnviarSolicitud"].Trim();
        public static string MensajeErrorEnviarSolicitud = ConfigurationManager.AppSettings["MensajeErrorEnviarSolicitud"].Trim();
        public static string MensajeCruceAlcanceGuardarSolicitud = ConfigurationManager.AppSettings["MensajeCruceAlcanceGuardarSolicitud"].Trim();
        public static string MensajeCruceAmbienteSolicitud = ConfigurationManager.AppSettings["MensajeCruceAmbienteSolicitud"].Trim();

        public static string TituloAprobarSolicitud = ConfigurationManager.AppSettings["TituloAprobarSolicitud"].Trim();
        public static string MensajeConfirmarAprobarSolicitud = ConfigurationManager.AppSettings["MensajeConfirmarAprobarSolicitud"].Trim();
        public static string MensajeAprobarSolicitud = ConfigurationManager.AppSettings["MensajeAprobarSolicitud"].Trim();
        public static string TituloRechazarSolicitud = ConfigurationManager.AppSettings["TituloRechazarSolicitud"].Trim();
        public static string MensajeConfirmarRechazarSolicitud = ConfigurationManager.AppSettings["MensajeConfirmarRechazarSolicitud"].Trim();
        public static string MensajeRechazarSolicitud = ConfigurationManager.AppSettings["MensajeRechazarSolicitud"].Trim();
            
        //Actualizar Feriado
        public static string TituloRegistroFeriado = ConfigurationManager.AppSettings["TituloRegistroFeriado"].Trim();
        public static string MensajeRegistroFeriado = ConfigurationManager.AppSettings["MensajeRegistroFeriado"].Trim();
        public static string TituloRegistroFeriadoExsistente = ConfigurationManager.AppSettings["TituloRegistroFeriadoExsistente"].Trim();
        public static string MensajeErrorRegistrarFeriado = ConfigurationManager.AppSettings["MensajeErrorRegistrarFeriado"].Trim();
        public static string MensajeRegistroFeriadoExistente = ConfigurationManager.AppSettings["MensajeRegistroFeriadoExistente"].Trim();
        public static string TituloEliminarFeriado = ConfigurationManager.AppSettings["TituloEliminarFeriado"].Trim();
        public static string MensajeEliminarFeriado = ConfigurationManager.AppSettings["MensajeEliminarFeriado"].Trim();
        public static string MensajeErrorEliminarFeriado = ConfigurationManager.AppSettings["MensajeErrorEliminarFeriado"].Trim();
        public static string TituloCargaFeriado = ConfigurationManager.AppSettings["TituloCargaFeriado"].Trim();
        public static string MensajeCargaFeriado = ConfigurationManager.AppSettings["MensajeCargaFeriado"].Trim();
        public static string MensajeErrorCargaFeriado = ConfigurationManager.AppSettings["MensajeErrorCargaFeriado"].Trim();


        /* ---------- PARAMETROS ---------- */
        public static int ParametroTipoCalendario = int.Parse(ConfigurationManager.AppSettings["ParametroTipoCalendario"]);
        public static int ParametroEstadoAgenda = int.Parse(ConfigurationManager.AppSettings["ParametroEstadoAgenda"]);
        public static int ParametroEstadosCalendario = int.Parse(ConfigurationManager.AppSettings["ParametroEstadosCalendario"]);
        public static string ParametroCalendarioAprobado = ConfigurationManager.AppSettings["ParametroCalendarioAprobado"].Trim();
        public static string ParametroTipoCalendarioAcademico = ConfigurationManager.AppSettings["ParametroTipoCalendarioAcademico"];
        public static string ParametroTipoCalendarioExtracurricular = ConfigurationManager.AppSettings["ParametroTipoCalendarioExtracurricular"];


        public static string ParametroTipoActividad = ConfigurationManager.AppSettings["ParametroTipoActividad"].Trim();
        
        public static string ParametroAlcance = ConfigurationManager.AppSettings["ParametroAlcance"].Trim();
        public static string ParametroUbicacion = ConfigurationManager.AppSettings["ParametroUbicacion"].Trim();

        public static string ParametroHora = ConfigurationManager.AppSettings["ParametroHora"].Trim();
        public static string ParametroMinuto = ConfigurationManager.AppSettings["ParametroMinuto"].Trim();

        public static string ParametroEstadoActividad = ConfigurationManager.AppSettings["ParametroEstadoActividad"].Trim();
        public static string ParametroEstadoSolicitudActividad = ConfigurationManager.AppSettings["ParametroEstadoSolicitudActividad"].Trim();

        public static string ParametroUbicacionInterna = ConfigurationManager.AppSettings["ParametroUbicacionInterna"].Trim();
        public static string ParametroUbicacionExterna = ConfigurationManager.AppSettings["ParametroUbicacionExterna"].Trim();


        public static string ParametroCalendarioEstadoAprobado = ConfigurationManager.AppSettings["ParametroCalendarioEstadoAprobado"].Trim();
        public static string ParametroAgendaEstadoVigente = ConfigurationManager.AppSettings["ParametroAgendaEstadoVigente"].Trim();
        public static string ParametroAgendaEstadoAperturada = ConfigurationManager.AppSettings["ParametroAgendaEstadoAperturada"].Trim();        

        public static string ParametroTipoActividadAcademica = ConfigurationManager.AppSettings["ParametroTipoActividadAcademica"].Trim();
        public static string ParametroTipoActividadExtracurricular = ConfigurationManager.AppSettings["ParametroTipoActividadExtracurricular"].Trim();

        //Correo
        public static string FlagCorreo = ConfigurationManager.AppSettings["FlagCorreo"].Trim();
        public static string CorreoAprobacion = ConfigurationManager.AppSettings["CorreoAprobacion"].Trim();
        public static string PasswordAprobacion = ConfigurationManager.AppSettings["PasswordAprobacion"].Trim();
        
        public static string EstadoAprobacionAprobado = ConfigurationManager.AppSettings["EstadoAprobacionAprobado"].Trim();
        public static string EstadoAprobacionRechazado = ConfigurationManager.AppSettings["EstadoAprobacionRechazado"].Trim();

        public static string MensajeCruceAlcanceGuardarActividad = ConfigurationManager.AppSettings["MensajeCruceAlcanceGuardarActividad"].Trim();
        public static string MensajeCruceAmbienteGuardarActividad = ConfigurationManager.AppSettings["MensajeCruceAmbienteGuardarActividad"].Trim();
        public static string MensajeGuardarActividadExtracurricular = ConfigurationManager.AppSettings["MensajeGuardarActividadExtracurricular"].Trim();
        public static string MensajeErrorGuardarActividad = ConfigurationManager.AppSettings["MensajeErrorGuardarActividad"].Trim();      
        
    }
}