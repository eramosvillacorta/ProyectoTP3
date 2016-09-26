/// <summar4y>
/// Script de controlador de formulario de registro.
/// </summary>
/// <remarks>
/// Creacion: 	JPC 30/08/2016
/// </remarks>
ns('GDirectiva.Presentacion.General.ReportePlanAsignatura.ReporteCumplimiento');
GDirectiva.Presentacion.General.ReportePlanAsignatura.ReporteCumplimiento.Controller = function (opts) {
    var base = this;

    base.Ini = function () {
        
        base.Event.GrabarSuccess = (opts.GrabarSuccess != null && opts.GrabarSuccess) ? opts.GrabarSuccess : null;
        base.Control.BtnCancelar().click(base.Event.BtnCancelarClick);
        base.Function.ObtenerResumenActividades();
        base.Function.ObtenerActividades();
    };
    base.Mostrar = function (pId_Plan_Asignatura) {
        pId_Plan_Asignatura = (pId_Plan_Asignatura == undefined) ? 0 : pId_Plan_Asignatura;
        base.Control.DlgFormulario.getAjaxContent(
            {
                action: GDirectiva.Presentacion.General.ReportePlanAsignatura.Actions.ReporteCumplimiento,
                data: { pId_Plan_Asignatura: pId_Plan_Asignatura },
                onSuccess: function () {
                    base.Ini();
                }
            }
        );
    };
    base.Function = {
        ObtenerResumenActividades: function () {
            base.Ajax.AjaxResumenPlanAsignatura.data = {
                pId_Plan_Asignatura: base.Control.HdnCodigo().val()
            };
            base.Ajax.AjaxResumenPlanAsignatura.submit();
        },
        ObtenerActividades: function () {
            base.Ajax.AjaxBuscarCronogramaPlanAsignatura.data = {
                pId_Plan_Asignatura: base.Control.HdnCodigo().val()
            };
            base.Ajax.AjaxBuscarCronogramaPlanAsignatura.submit();
        }
    };
    base.Control = {
        Mensaje: new GDirectiva.Presentacion.Web.Components.Message(),
        DlgFormulario: new GDirectiva.Presentacion.Web.Components.Dialog({
            title: GDirectiva.Presentacion.General.ReportePlanAsignatura.Resource.EtiquetaTituloFormulario,
            width: '60%',
            maxHeight: 700
        }),
        FormRegistro: function () { return $('#frmRegistrarPlanArea'); },
        BtnCancelar: function () { return $('#btnFrmCancelar'); },
        HdnCodigo: function () { return $('#hdnFormularioRegistroCodigo'); },
        VwReport: function () { return $('#results'); },
        VwReportResumen: function () { return $('#resultsResumen'); }
    };
    base.Configurations = {
        search: {
            parameters: null
        }
    };
    base.Event = {
        AjaxBuscarCronogramaPlanAsignaturaSuccess: function (data) {
            var cadena = '<table border=1 width=100%>';
            if (data.Result != null) {
                $.each(data.Result, function (i, item) {
                    cadena += '<tr><th colspan=7>' + item.META + '</th></tr>';
                    cadena += '<tr>';
                    cadena += '<td></td>' +
                              '<td>Actividad</td>' +
                              '<td>Fecha Inicio</td>' +
                              '<td>Fecha Fin</td>' +
                              '<td>Porcentaje</td>' +
                              '<td>Responsable</td>' +
                              '<td>Comentarios</td>';
                    cadena += '</tr>';
                    $.each(item.ACTIVIDADES, function (i, actividad) {
                        cadena += '<tr>';
                        cadena += '<td></td>';
                        cadena += '<td>' + actividad.ACTIVIDAD + '</td>' +
                                  '<td>' + GDirectiva.Presentacion.Web.Components.Util.ConvertirFechaACadena(actividad.FECHAINICIO) + '</td>' +
                                  '<td>' + GDirectiva.Presentacion.Web.Components.Util.ConvertirFechaACadena(actividad.FECHAFIN) + '</td>' +
                                  '<td><div id="circleGreen" data-toggle="tooltip" title="' + actividad.PORCENTAJE + ' %" ></div></td>' +
                                  '<td>' + actividad.NOMBRE_EMPLEADO + '</td>'+
                                  '<td><a href=#>Observaciones</a></td>';
                        cadena += '</tr>';
                    });
                });
            }
            cadena += '</table>';
            base.Control.VwReport().html(cadena);
        },
        AjaxResumenPlanAsignaturaSuccess: function (data) {
            var cadena = '<table border=1 width=100%>';
            if (data.Result != null) {
                cadena += '<tr><td>FECHA INICIO</td><td>' + GDirectiva.Presentacion.Web.Components.Util.ConvertirFechaACadena(data.Result.FECHAINICIO) + '</td></tr>';
                cadena += '<tr><td>FECHA FIN</td><td>' + GDirectiva.Presentacion.Web.Components.Util.ConvertirFechaACadena(data.Result.FECHAFIN) + '</td></tr>';
                cadena += '<tr><td>PORCENTAJE CRONOGRAMA</td><td>' + data.Result.PORCENTAJE + '</td></tr>';
            }
            cadena += '</table>';
            base.Control.VwReportResumen().html(cadena);
        },
        BtnCancelarClick: function () {
            base.Control.DlgFormulario.close();
        }
    };
    base.Ajax = {
        AjaxBuscarCronogramaPlanAsignatura: new GDirectiva.Presentacion.Web.Components.Ajax(
        {
            action: GDirectiva.Presentacion.General.ReportePlanAsignatura.Actions.BuscarActividades,
            autoSubmit: false,
            onSuccess: base.Event.AjaxBuscarCronogramaPlanAsignaturaSuccess
        }),
        AjaxResumenPlanAsignatura: new GDirectiva.Presentacion.Web.Components.Ajax(
        {
            action: GDirectiva.Presentacion.General.ReportePlanAsignatura.Actions.ObtenerResumenPlanAsignatura,
            autoSubmit: false,
            onSuccess: base.Event.AjaxResumenPlanAsignaturaSuccess
        })
    };
};