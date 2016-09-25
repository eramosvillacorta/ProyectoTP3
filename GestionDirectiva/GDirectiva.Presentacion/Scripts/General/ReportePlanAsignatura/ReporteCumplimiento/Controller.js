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
            maxHeight: 800
        }),
        FormRegistro: function () { return $('#frmRegistrarPlanArea'); },
        BtnCancelar: function () { return $('#btnFrmCancelar'); },
        HdnCodigo: function () { return $('#hdnFormularioRegistroCodigo'); },
        VwReport: function () { return $('#results'); }
    };
    base.Configurations = {
        search: {
            parameters: null
        }
    };
    base.Event = {
        AjaxBuscarCronogramaPlanAsignaturaSuccess: function (data) {
            var cadena = '<table>';
            cadena += '<tr><th>Actividad</th><th>Estado</th></tr>';
            if (data.Result != null) {
                $.each(data.Result, function (i, item) {
                    cadena += '<tr>';

                    cadena += '<td>' + item.ACTIVIDAD + '</td>' +
                              '<td><div id="circleGreen" data-toggle="tooltip" title="' + item.PORCENTAJE + ' %" ></div></td>';

                    cadena += '</tr>';
                });
            }
            cadena += '</table>';
            base.Control.VwReport().html(cadena);
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
        })
    };
};