using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using InnovaSchool.Entity;
using InnovaSchool.BL;
using InnovaSchool.UserLayer.Common;

namespace InnovaSchool.UserLayer.Interfaces
{
    public partial class frmAprobarCalendarioExtracurricular : System.Web.UI.Page
    {
        BAgenda BAgenda = new BAgenda();
        BCalendario bCalendario = new BCalendario();
        BParametro BParametro = new BParametro();
        BAprobarCalendario bApCalendario = new BAprobarCalendario();
        protected void Page_Load(object sender, EventArgs e)
        {
           // if (!Page.IsPostBack)
           // {
                CargarListaAprobarCalendarioExtra();
                
           // }
        }
        private void CargarListaAprobarCalendarioExtra()
        {
            ECalendario eCalendario = new ECalendario();
            EAprobarCalendario eApCalendario = new EAprobarCalendario();
            eCalendario.IdAgenda = "2015";
            lblanio.Text = "2015";
            List<EAprobarCalendario> ListAprobCalen;
            ListAprobCalen = bApCalendario.ListaAprobarCalendarioExtra(eCalendario);
            gvListaAprobCalen.DataSource = ListAprobCalen;
            gvListaAprobCalen.DataBind();
        }

        protected void gvListaAprobCalen_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            int rowIndex;
            EAprobarCalendario eAprobarCalendario = new EAprobarCalendario();
            ESolicitudActividad ESolicitudActividad = new ESolicitudActividad();

            switch (e.CommandName)
            {
                case "Buscar":

                    rowIndex = (((GridViewRow)((TableCell)((LinkButton)e.CommandSource).Parent).Parent)).RowIndex;
                    GridViewRow gvr = (((GridViewRow)((TableCell)((LinkButton)e.CommandSource).Parent).Parent));

                    eAprobarCalendario.idMes = int.Parse(((Label)gvr.FindControl("lblidMes")).Text);
                    eAprobarCalendario.idagenda = lblanio.Text;
                    //hfIdFeriado.Value = eFeriado.IdFeriado.ToString();                    
                    
                    gvListaActividades.DataSource = bApCalendario.ListadoActividades(eAprobarCalendario);
                    gvListaActividades.DataBind();
                    break;
                case "Eliminar":
                    /*rowIndex = (((GridViewRow)((TableCell)((LinkButton)e.CommandSource).Parent).Parent)).RowIndex;
                    eFeriado.IdFeriado = (int)gvConsultaFeriados.DataKeys[rowIndex][0];
                    hfIdFeriado.Value = eFeriado.IdFeriado.ToString();
                    ClientScript.RegisterStartupScript(this.GetType(), "Show", "<script>$('#myModalEliminar').modal('show');</script>");*/
                    break;
            }
        }

        protected void btnAprobarCalen_Click(object sender, EventArgs e)
        {
            try {
                EAprobarCalendario eAprobarCalendario = new EAprobarCalendario();
                
                eAprobarCalendario.Estado = "3";
                eAprobarCalendario.idcalendario = lblanio.Text;
                int val = bApCalendario.ActualizarEstadoCalendario(eAprobarCalendario);

                btnAprobarCalen.Visible = false;
                gvDetalleAct.DataSource = null;
                gvListaActividades.DataSource = null;
                gvListaAprobCalen.DataSource = null;
            }
            catch (Exception ex)
            {
                Response.Redirect("../Error/NoAccess.html");
            }
        }

        protected void gvListaActividades_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try { 
                int rowIndex;
                EAprobarCalendario eAprobarCalendario = new EAprobarCalendario();
                ESolicitudActividad ESolicitudActividad = new ESolicitudActividad();

                switch (e.CommandName)
                {
                    case "Detalle":

                        rowIndex = (((GridViewRow)((TableCell)((LinkButton)e.CommandSource).Parent).Parent)).RowIndex;
                        GridViewRow gvr = (((GridViewRow)((TableCell)((LinkButton)e.CommandSource).Parent).Parent));

                        eAprobarCalendario.IdActividad = int.Parse(((Label)gvr.FindControl("lblIdActividad")).Text);

                        //hfIdFeriado.Value = eFeriado.IdFeriado.ToString();                    
                        List<EAprobarCalendario> DetalleAprobCalen;
                        DetalleAprobCalen = bApCalendario.ActividadPrincipal(eAprobarCalendario);
                        if (DetalleAprobCalen.Count() > 0)
                        {
                            txtNombre.Text = DetalleAprobCalen[0].Nombre;
                            txtAlcance.Text = DetalleAprobCalen[0].Alcance;
                            txtTipo.Text = DetalleAprobCalen[0].TipoActividad;
                            txtDescripcion.Text = DetalleAprobCalen[0].Descripcion;
                            txtResponsable.Text = DetalleAprobCalen[0].Responsable;
                            txtFechaInicio.Text = DetalleAprobCalen[0].FechaInicio.ToString();
                            txtFechaFin.Text = DetalleAprobCalen[0].FechaTermino.ToString();
                        }

                        gvDetalleAct.DataSource = bApCalendario.DetalleActividad(eAprobarCalendario);
                        gvDetalleAct.DataBind();
                        break;
                    case "Aprobar":
                        rowIndex = (((GridViewRow)((TableCell)((LinkButton)e.CommandSource).Parent).Parent)).RowIndex;
                        GridViewRow gvr2 = (((GridViewRow)((TableCell)((LinkButton)e.CommandSource).Parent).Parent));
                        eAprobarCalendario.IdActividad = int.Parse(((Label)gvr2.FindControl("lblIdActividad")).Text);
                        eAprobarCalendario.Estado = "4";
                        int val = bApCalendario.ActualizarEstadoActividad(eAprobarCalendario);

                        ((LinkButton)gvr2.FindControl("lbtAprobar")).Enabled = false;
                        ((LinkButton)gvr2.FindControl("lbtRechazar")).Enabled = false;

                        ClientScript.RegisterStartupScript(this.GetType(), "Show", "<script>$('#myModalAprobar').modal('show');</script>");
                        break;
                    case "Rechazar":
                        rowIndex = (((GridViewRow)((TableCell)((LinkButton)e.CommandSource).Parent).Parent)).RowIndex;
                        GridViewRow gvr3 = (((GridViewRow)((TableCell)((LinkButton)e.CommandSource).Parent).Parent));
                        eAprobarCalendario.IdActividad = int.Parse(((Label)gvr3.FindControl("lblIdActividad")).Text);
                        eAprobarCalendario.Estado = "3";
                        int valor = bApCalendario.ActualizarEstadoActividad(eAprobarCalendario);

                        ((LinkButton)gvr3.FindControl("lbtAprobar")).Enabled = false;
                        ((LinkButton)gvr3.FindControl("lbtRechazar")).Enabled = false;

                        ClientScript.RegisterStartupScript(this.GetType(), "Show", "<script>$('#myModalRechazar').modal('show');</script>");
                        break;
                    }
            }
            catch (Exception ex)
            {
                Response.Redirect("../Error/NoAccess.html");
            }            
        }
    }
}