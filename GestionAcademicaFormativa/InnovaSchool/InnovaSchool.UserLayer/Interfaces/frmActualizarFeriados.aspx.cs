using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using InnovaSchool.Entity;
using InnovaSchool.BL;
using InnovaSchool.UserLayer.Common;
using System.Globalization;

namespace InnovaSchool.UserLayer.Interfaces
{
    public partial class frmActualizarFeriados : System.Web.UI.Page
    {
        BAgenda BAgenda = new BAgenda();
        BFeriado bFeriado = new BFeriado();
        BParametro BParametro = new BParametro();
        Resources.Resources objResources = new Resources.Resources();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                CargarAniosAgenda();
                IniciarValidacion();
            }
        }
        private void CargarAniosAgenda()
        {
            List<EAgenda> ListEagenda;
            ListEagenda = BAgenda.AniosAgenda();
            ddlAnio.DataSource = ListEagenda;
            ddlAnio.DataTextField = "IdAgenda";
            ddlAnio.DataValueField = "IdAgenda";
            ddlAnio.DataBind();
            ddlAnio.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Años", "0"));
        }

        private void IniciarValidacion()
        {
            txtAnioEscolarVigente.Text = DateTime.Today.Year.ToString();

            var FecIniAnio = "01/01/" + DateTime.Today.Year.ToString();
            var FecFinAnio = "31/12/" + DateTime.Today.Year.ToString();
            var FecActual = DateTime.Today.ToShortDateString();
            cvFechaInicio.ValueToCompare = FecActual.ToString();
            /* rvApertura.MinimumValue = FecIniAnio.ToString();
             rvApertura.MaximumValue = FecFinAnio.ToString();
             rvCierre.MinimumValue = FecIniAnio.ToString();
             rvCierre.MaximumValue = FecFinAnio.ToString();
             rvInicio.MinimumValue = FecIniAnio.ToString();
             rvInicio.MaximumValue = FecFinAnio.ToString();
             rvTermino.MinimumValue = FecIniAnio.ToString();
             rvTermino.MaximumValue = FecFinAnio.ToString();
             cvApertura.ValueToCompare = FecActual.ToString();*/
        }

        protected void ddlAnio_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<EFeriado> ListECalendario;
            if (ddlAnio.SelectedValue != "0")
            {
                EFeriado eFeriado = new EFeriado();
                eFeriado.IdAgenda = ddlAnio.SelectedValue;            
                ListECalendario = bFeriado.ConsultarFeriadoLista(eFeriado);
                gvConsultaFeriados.DataSource = ListECalendario;
            }
            gvConsultaFeriados.DataBind();
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                EUsuario EUsuario = (EUsuario)Session["Usuario"];

                int IdFeriado = 0;
                if (!hfIdFeriado.Value.Equals(string.Empty))
                    IdFeriado = int.Parse(hfIdFeriado.Value);

                txtFechaFin.Text = (txtFechaFin.Text.Length == 0 ? txtFechaInicio.Text : txtFechaFin.Text);
                EFeriado eFeriado = new EFeriado
                {
                    IdFeriado = IdFeriado,
                    IdAgenda = txtAnioEscolarVigente.Text,
                    Motivo = txtDescripcion.Text,
                    FechaInicio = objResources.GetDateFromTextBox(txtFechaInicio),
                    FechaTermino = objResources.GetDateFromTextBox(txtFechaFin),
                    Repetitivo = (chkRepiteCadaAnio.Checked ? 1 : 0)
                };

                DateTime dtIni = DateTime.ParseExact(txtFechaInicio.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                DateTime dtFin = DateTime.ParseExact(txtFechaFin.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                TimeSpan ts = dtFin - dtIni;
                int diferenciaenDias = ts.Days;

                List<EFeriado> ListaExistenciaFeriado;
                ListaExistenciaFeriado = bFeriado.ValidarExistenciaFeriado(eFeriado);
                if (ListaExistenciaFeriado.Count > 0)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "Show", "<script>$('#myModalExisteFeriado').modal('show');</script>");
                }
                else if (diferenciaenDias > 3)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "Show", "<script>$('#myModalExcedeFeriado').modal('show');</script>");
                }
                else
                {
                    int result = 0;
                    result = bFeriado.RegistrarFeriado(eFeriado, EUsuario);
                    if (result != 0)
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "Show", "<script>$('#mensaje').modal('show');</script>");

                        objResources.LimpiarControles(this.Controls);
                        hfIdFeriado.Value = string.Empty;
                        txtAnioEscolarVigente.Text = DateTime.Today.Year.ToString();
                        CargarAniosAgenda();

                        ddlAnio.SelectedValue = txtAnioEscolarVigente.Text;
                        eFeriado.IdAgenda = ddlAnio.SelectedValue;
                        List<EFeriado> ListECalendario;
                        ListECalendario = bFeriado.ConsultarFeriadoLista(eFeriado);
                        gvConsultaFeriados.DataSource = ListECalendario;
                        gvConsultaFeriados.DataBind();

                    }
                    else
                    {
                        //ClientScript.RegisterStartupScript(this.GetType(), "Mensaje", "<script>$('#mensaje').html(GenerarMensaje('" + Constant.TituloErrorFeriado + "','" + Constant.MensajeErrorRegistrarFeriado + "'))</script>");
                        //ClientScript.RegisterStartupScript(this.GetType(), "Show", "<script>myModalShow();</script>");
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Redirect("../Error/NoAccess.html");
            }
        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarControles();
        }

        private void LimpiarControles()
        {
            txtAnioEscolarVigente.Text = DateTime.Today.Year.ToString();
            txtDescripcion.Text = "";
            txtFechaFin.Text = "";
            txtFechaInicio.Text = "";
            chkRepiteCadaAnio.Checked = false;
            hfIdFeriado.Value = "";
        }

        protected void gvConsultaFeriados_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            int rowIndex;
            EFeriado eFeriado = new EFeriado();
            ESolicitudActividad ESolicitudActividad = new ESolicitudActividad();

            switch (e.CommandName)
            {
                case "Editar":
                    //btnEnviar.Visible = true;
                    rowIndex = (((GridViewRow)((TableCell)((LinkButton)e.CommandSource).Parent).Parent)).RowIndex;
                    GridViewRow gvr = (((GridViewRow)((TableCell)((LinkButton)e.CommandSource).Parent).Parent));

                    //eFeriado.IdFeriado = int.Parse(gvConsultaFeriados.DataKeys[rowIndex][0].ToString());
                    //string id = ((Label)gvr.FindControl("lblIdFeriado")).Text;
                    eFeriado.IdFeriado = int.Parse(((Label)gvr.FindControl("lblIdFeriado")).Text);
                    eFeriado.IdAgenda = txtAnioEscolarVigente.Text;
                    hfIdFeriado.Value = eFeriado.IdFeriado.ToString();
                    txtDescripcion.Text = ((Label)gvr.FindControl("lblDescripcion")).Text;

                    bool repiteCadaAnio = (((Label)gvr.FindControl("lblReptitivo")).Text == "1" ? true : false);
                    chkRepiteCadaAnio.Checked = repiteCadaAnio;
                    txtFechaInicio.Text = string.Format("{0:dd/MM/yyyy}", gvConsultaFeriados.Rows[rowIndex].Cells[5].Text);
                    txtFechaFin.Text = string.Format("{0:dd/MM/yyyy}", gvConsultaFeriados.Rows[rowIndex].Cells[6].Text);

                    gvConsultaFeriados.DataSource = bFeriado.ConsultarFeriadoLista(eFeriado); ;
                    gvConsultaFeriados.DataBind();
                    break;
                case "Eliminar":
                    rowIndex = (((GridViewRow)((TableCell)((LinkButton)e.CommandSource).Parent).Parent)).RowIndex;
                    eFeriado.IdFeriado = (int)gvConsultaFeriados.DataKeys[rowIndex][0];
                    hfIdFeriado.Value = eFeriado.IdFeriado.ToString();
                    ClientScript.RegisterStartupScript(this.GetType(), "Show", "<script>$('#myModalEliminar').modal('show');</script>");
                    break;
            }
        }

        protected void gvConsultaFeriados_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType != DataControlRowType.DataRow) return;

            LinkButton lnkEditar = ((LinkButton)e.Row.FindControl("lbtEditar"));
            LinkButton lbtEliminar = ((LinkButton)e.Row.FindControl("lbtEliminar"));
            if (ddlAnio.SelectedValue == txtAnioEscolarVigente.Text)
            {
                lnkEditar.Visible = true;
                lbtEliminar.Visible = true;
            }
            var FecActual = DateTime.Today;
            DateTime FecInicio = DateTime.ParseExact(e.Row.Cells[5].Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            DateTime FecFin = DateTime.ParseExact(e.Row.Cells[6].Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            if (FecInicio <= FecActual || FecFin <= FecActual)
            {
                lnkEditar.Visible = false;
                lbtEliminar.Visible = false;
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                EFeriado eFeriado = new EFeriado()
                {
                    IdFeriado = int.Parse(hfIdFeriado.Value),
                    IdAgenda = txtAnioEscolarVigente.Text
                };
                int result = 0;
                result = bFeriado.EliminarFeriado(eFeriado);
                if (result != 0)
                {
                    gvConsultaFeriados.DataSource = bFeriado.ConsultarFeriadoLista(eFeriado); ;
                    gvConsultaFeriados.DataBind();
                    LimpiarControles();
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "Mensaje", "<script>$('#mensaje').html(GenerarMensaje('" + Constant.TituloEliminarActividad + "','" + Constant.MensajeErrorEliminarActividadAcademica + "'))</script>");
                    ClientScript.RegisterStartupScript(this.GetType(), "Show", "<script>myModalShow();</script>");
                }
            }
            catch (Exception ex)
            {
                Response.Redirect("../Error/NoAccess.html");
            }
        }

        protected void btnCargarFeriado_Click(object sender, EventArgs e)
        {
            try
            {
                EUsuario EUsuario = (EUsuario)Session["Usuario"];

                List<EFeriado> ListaFeriadoRepetitivos;
                ListaFeriadoRepetitivos = bFeriado.CargarFeriadoRepetitivos(EUsuario);
                gvConsultaFeriados.DataSource = ListaFeriadoRepetitivos;
                gvConsultaFeriados.DataBind();

                LimpiarControles();

                /*if (ListaFeriadoRepetitivos.Count != 0)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "Show", "<script>$('#mensaje').modal('show');</script>");
                    CargarAniosAgenda();
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "Mensaje", "<script>$('#mensaje').html(GenerarMensaje('" + Constant.TituloErrorFeriado + "','" + Constant.MensajeErrorRegistrarFeriado + "'))</script>");
                    ClientScript.RegisterStartupScript(this.GetType(), "Show", "<script>myModalShow();</script>");
                }*/
            }
            catch (Exception ex)
            {
                Response.Redirect("../Error/NoAccess.html");
            }
        }

        protected void btnRegistrarExceso_Click(object sender, EventArgs e)
        {
            try
            {
                EUsuario EUsuario = (EUsuario)Session["Usuario"];

                int IdFeriado = 0;
                if (!hfIdFeriado.Value.Equals(string.Empty))
                    IdFeriado = int.Parse(hfIdFeriado.Value);

                txtFechaFin.Text = (txtFechaFin.Text.Length == 0 ? txtFechaInicio.Text : txtFechaFin.Text);
                EFeriado eFeriado = new EFeriado
                {
                    IdFeriado = IdFeriado,
                    IdAgenda = txtAnioEscolarVigente.Text,
                    Motivo = txtDescripcion.Text,
                    FechaInicio = objResources.GetDateFromTextBox(txtFechaInicio),
                    FechaTermino = objResources.GetDateFromTextBox(txtFechaFin),
                    Repetitivo = (chkRepiteCadaAnio.Checked ? 1 : 0)
                };

                int result = 0;
                result = bFeriado.RegistrarFeriado(eFeriado, EUsuario);
                if (result != 0)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "Show", "<script>$('#mensaje').modal('show');</script>");

                    objResources.LimpiarControles(this.Controls);
                    txtAnioEscolarVigente.Text = DateTime.Today.Year.ToString();
                    CargarAniosAgenda();
                    //(VerificarAperturaAgenda();
                }
                else
                {
                    //ClientScript.RegisterStartupScript(this.GetType(), "Mensaje", "<script>$('#mensaje').html(GenerarMensaje('" + Constant.TituloErrorFeriado + "','" + Constant.MensajeErrorRegistrarFeriado + "'))</script>");
                    //ClientScript.RegisterStartupScript(this.GetType(), "Show", "<script>myModalShow();</script>");
                }
            }
            catch (Exception ex)
            {
                Response.Redirect("../Error/NoAccess.html");
            }
        }
    }
}