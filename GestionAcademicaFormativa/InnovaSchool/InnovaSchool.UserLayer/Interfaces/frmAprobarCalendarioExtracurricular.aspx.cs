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
            CalendarioActual();
            CargarListaAprobarCalendarioExtra();
        }
        private void CargarListaAprobarCalendarioExtra()
        {
            ECalendario eCalendario = new ECalendario();
            EAprobarCalendario eApCalendario = new EAprobarCalendario();
            eCalendario.IdAgenda = lblanio.Text;            
            List<EAprobarCalendario> ListAprobCalen;
            ListAprobCalen = bApCalendario.ListaAprobarCalendarioExtra(eCalendario);
            gvListaAprobCalen.DataSource = ListAprobCalen;
            gvListaAprobCalen.DataBind();

            VerificarAprobarCalendario();
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
                    hfIdMes.Value = eAprobarCalendario.idMes.ToString();

                    CargarListadoActividades(eAprobarCalendario.idMes);

                    break;
            }
        }


        private void VerificarAprobarCalendario()
        {
            EAprobarCalendario eAprobarCalendario = new EAprobarCalendario();
            eAprobarCalendario.idagenda = lblanio.Text;
            List<EAprobarCalendario> listValidarCalen;
            listValidarCalen = bApCalendario.VerificarAprobarCalendario(eAprobarCalendario);
            if (listValidarCalen.Count > 0)
            {
                if (listValidarCalen[0].TotalActividades == 0)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "Show222", "<script>$('#btnaprobar').show('slow');</script>");
                }
            }
        }
        private void CargarListadoActividades(int idmes)
        {
            EAprobarCalendario eAprobarCalendario = new EAprobarCalendario();
            eAprobarCalendario.idMes = idmes;
            eAprobarCalendario.idagenda = lblanio.Text;
            gvListaActividades.DataSource = bApCalendario.ListadoActividades(eAprobarCalendario);
            gvListaActividades.DataBind();            
        }

        private void CalendarioActual()
        {
            List<EAprobarCalendario> listCalendarioActual;
            listCalendarioActual = bApCalendario.CalendarioActual();
            if (listCalendarioActual.Count >0)
            {
                lblanio.Text = listCalendarioActual[0].idagenda;
            }
        }
        protected void btnAprobarCalen_Click(object sender, EventArgs e)
        {
            try {
                EAprobarCalendario eAprobarCalendario = new EAprobarCalendario();
                
                eAprobarCalendario.Estado = "3";
                eAprobarCalendario.idcalendario = lblanio.Text;
                int val = bApCalendario.ActualizarEstadoCalendario(eAprobarCalendario);

                ClientScript.RegisterStartupScript(this.GetType(), "Hide3", "<script>$('#btnaprobar').hide('slow');</script>");
                CargarListaAprobarCalendarioExtra();

                gvDetalleAct.DataSource = null;
                gvListaActividades.DataSource = null;
                gvListaAprobCalen.DataSource = null;
                txtAlcance.Text = "";
                txtDescripcion.Text = "";
                txtFechaFin.Text = "";
                txtFechaInicio.Text = "";
                txtNombre.Text = "";
                txtResponsable.Text = "";
                txtTipo.Text = "";
                lblanio.Text = "";
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

                        hfIdActividad.Value = eAprobarCalendario.IdActividad.ToString();
                        List<EAprobarCalendario> DetalleAprobCalen;
                        DetalleAprobCalen = bApCalendario.ActividadPrincipal(eAprobarCalendario);
                        if (DetalleAprobCalen.Count() > 0)
                        {
                            txtNombre.Text = DetalleAprobCalen[0].Nombre;
                            txtAlcance.Text = DetalleAprobCalen[0].Alcance;
                            txtTipo.Text = DetalleAprobCalen[0].Tipo;
                            txtDescripcion.Text = DetalleAprobCalen[0].Descripcion;
                            txtResponsable.Text = DetalleAprobCalen[0].Responsable;
                            txtFechaInicio.Text = DetalleAprobCalen[0].FechaInicio.ToString().Substring(0,10);
                            txtFechaFin.Text = DetalleAprobCalen[0].FechaTermino.ToString().Substring(0, 10);
                        }

                        gvDetalleAct.DataSource = bApCalendario.DetalleActividad(eAprobarCalendario);
                        gvDetalleAct.DataBind();
                        break;
                    case "Aprobar":
                        rowIndex = (((GridViewRow)((TableCell)((LinkButton)e.CommandSource).Parent).Parent)).RowIndex;
                        GridViewRow gvr2 = (((GridViewRow)((TableCell)((LinkButton)e.CommandSource).Parent).Parent));
                        eAprobarCalendario.IdActividad = int.Parse(((Label)gvr2.FindControl("lblIdActividad")).Text);
                        hfIdActividad.Value = eAprobarCalendario.IdActividad.ToString();
                        eAprobarCalendario.Estado = "4";
                        int val = bApCalendario.ActualizarEstadoActividad(eAprobarCalendario);

                        ((LinkButton)gvr2.FindControl("lbtAprobar")).Enabled = false;
                        ((LinkButton)gvr2.FindControl("lbtRechazar")).Enabled = false;

                        ClientScript.RegisterStartupScript(this.GetType(), "Show", "<script>$('#myModalAprobar').modal('show');</script>");

                        CargarListadoActividades(int.Parse(hfIdMes.Value));
                        VerificarAprobarCalendario();
                        break;
                    case "Rechazar":
                        rowIndex = (((GridViewRow)((TableCell)((LinkButton)e.CommandSource).Parent).Parent)).RowIndex;
                        GridViewRow gvr3 = (((GridViewRow)((TableCell)((LinkButton)e.CommandSource).Parent).Parent));
                        eAprobarCalendario.IdActividad = int.Parse(((Label)gvr3.FindControl("lblIdActividad")).Text);
                        hfIdActividad.Value = eAprobarCalendario.IdActividad.ToString();
                        eAprobarCalendario.Estado = "3";
                        int valor = bApCalendario.ActualizarEstadoActividad(eAprobarCalendario);

                        ((LinkButton)gvr3.FindControl("lbtAprobar")).Enabled = false;
                        ((LinkButton)gvr3.FindControl("lbtRechazar")).Enabled = false;

                        ClientScript.RegisterStartupScript(this.GetType(), "Show", "<script>$('#myModalRechazar').modal('show');</script>");

                        CargarListadoActividades(int.Parse(hfIdMes.Value));
                        VerificarAprobarCalendario();
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