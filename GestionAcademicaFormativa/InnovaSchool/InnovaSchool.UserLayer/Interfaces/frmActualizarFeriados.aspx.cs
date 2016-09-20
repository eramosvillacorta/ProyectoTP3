﻿using System;
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
        BFeriado BFeriado = new BFeriado();
        BActividad BActividad = new BActividad();
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
            var FecActual = DateTime.Today.ToShortDateString();
            cvFechaInicio.ValueToCompare = FecActual.ToString();
            EAgenda EAgenda;
            EAgenda = BAgenda.VerificarAperturaAgenda();
            if (EAgenda == null)
            {
                divActualizarFeriado.Visible = false;
            }
            else
            {
                divActualizarFeriado.Visible = true;
            }
            List<EFeriado> ListEFeriado;
            ListEFeriado = BFeriado.ConsultarCargaFeriados();
            if (ListEFeriado.Count() == 0)
            {
                btnOpenCarga.Visible = false;
            }
            else
            {
                btnOpenCarga.Visible = true;
            }
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

        public void RegistrarFeriado()
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
            result = BFeriado.RegistrarFeriado(eFeriado, EUsuario);
            if (result != 0)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Mensaje", "<script>$('#mensaje').html(GenerarMensaje('" + Constant.TituloRegistroFeriado + "','" + Constant.MensajeRegistroFeriado + "'))</script>");
                ClientScript.RegisterStartupScript(this.GetType(), "Show", "<script>myModalShow();</script>");
                objResources.LimpiarControles(this.Controls);
                hfIdFeriado.Value = string.Empty;
                txtAnioEscolarVigente.Text = DateTime.Today.Year.ToString();
                CargarAniosAgenda();
                ddlAnio.SelectedValue = txtAnioEscolarVigente.Text;
                eFeriado.IdAgenda = ddlAnio.SelectedValue;
                List<EFeriado> ListECalendario;
                ListECalendario = BFeriado.ConsultarFeriadoLista(eFeriado);
                gvConsultaFeriados.DataSource = ListECalendario;
                gvConsultaFeriados.DataBind();
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Mensaje", "<script>$('#mensaje').html(GenerarMensaje('" + Constant.TituloRegistroFeriado + "','" + Constant.MensajeErrorRegistrarFeriado + "'))</script>");
                ClientScript.RegisterStartupScript(this.GetType(), "Show", "<script>myModalShow();</script>");
            }
        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarControles();
        }

        protected void ddlAnio_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<EFeriado> ListECalendario;
            if (ddlAnio.SelectedValue != "0")
            {
                EFeriado eFeriado = new EFeriado();
                eFeriado.IdAgenda = ddlAnio.SelectedValue;
                ListECalendario = BFeriado.ConsultarFeriadoLista(eFeriado);
                gvConsultaFeriados.DataSource = ListECalendario;
            }
            gvConsultaFeriados.DataBind();
        }

        protected void gvConsultaFeriados_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int rowIndex;
            EFeriado eFeriado = new EFeriado();
            ESolicitudActividad ESolicitudActividad = new ESolicitudActividad();
            switch (e.CommandName)
            {
                case "Editar":
                    rowIndex = (((GridViewRow)((TableCell)((LinkButton)e.CommandSource).Parent).Parent)).RowIndex;
                    GridViewRow gvr = (((GridViewRow)((TableCell)((LinkButton)e.CommandSource).Parent).Parent));
                    eFeriado.IdFeriado = int.Parse(((Label)gvr.FindControl("lblIdFeriado")).Text);
                    eFeriado.IdAgenda = txtAnioEscolarVigente.Text;
                    hfIdFeriado.Value = eFeriado.IdFeriado.ToString();
                    txtDescripcion.Text = ((Label)gvr.FindControl("lblDescripcion")).Text;
                    bool repiteCadaAnio = (((Label)gvr.FindControl("lblReptitivo")).Text == "1" ? true : false);
                    chkRepiteCadaAnio.Checked = repiteCadaAnio;
                    txtFechaInicio.Text = string.Format("{0:dd/MM/yyyy}", gvConsultaFeriados.Rows[rowIndex].Cells[5].Text);
                    txtFechaFin.Text = string.Format("{0:dd/MM/yyyy}", gvConsultaFeriados.Rows[rowIndex].Cells[6].Text);
                    gvConsultaFeriados.DataSource = BFeriado.ConsultarFeriadoLista(eFeriado); ;
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
                result = BFeriado.EliminarFeriado(eFeriado);
                if (result != 0)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "Mensaje", "<script>$('#mensaje').html(GenerarMensaje('" + Constant.TituloEliminarFeriado + "','" + Constant.MensajeEliminarFeriado + "'))</script>");
                    ClientScript.RegisterStartupScript(this.GetType(), "Show", "<script>myModalShow();</script>");
                    gvConsultaFeriados.DataSource = BFeriado.ConsultarFeriadoLista(eFeriado); ;
                    gvConsultaFeriados.DataBind();
                    hfIdFeriado.Value = "";
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "Mensaje", "<script>$('#mensaje').html(GenerarMensaje('" + Constant.TituloEliminarFeriado+ "','" + Constant.MensajeErrorEliminarFeriado + "'))</script>");
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
                int result = 0;
                result = BFeriado.CargarFeriadoRepetitivos(EUsuario);
                if (result != 0)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "Mensaje", "<script>$('#mensaje').html(GenerarMensaje('" + Constant.TituloCargaFeriado + "','" + Constant.MensajeCargaFeriado + "'))</script>");
                    ClientScript.RegisterStartupScript(this.GetType(), "Show", "<script>myModalShow();</script>");
                    objResources.LimpiarControles(this.Controls);
                    hfIdFeriado.Value = string.Empty;
                    txtAnioEscolarVigente.Text = DateTime.Today.Year.ToString();
                    CargarAniosAgenda();
                    ddlAnio.SelectedValue = txtAnioEscolarVigente.Text;
                    EFeriado eFeriado = new EFeriado();
                    eFeriado.IdAgenda = ddlAnio.SelectedValue;
                    List<EFeriado> ListECalendario;
                    ListECalendario = BFeriado.ConsultarFeriadoLista(eFeriado);
                    gvConsultaFeriados.DataSource = ListECalendario;
                    gvConsultaFeriados.DataBind();
                    btnOpenCarga.Visible = false;
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "Mensaje", "<script>$('#mensaje').html(GenerarMensaje('" + Constant.TituloCargaFeriado + "','" + Constant.MensajeErrorCargaFeriado + "'))</script>");
                    ClientScript.RegisterStartupScript(this.GetType(), "Show", "<script>myModalShow();</script>");
                }
            }
            catch (Exception ex)
            {
                Response.Redirect("../Error/NoAccess.html");
            }
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
                EFeriado EFeriado = new EFeriado
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
                ListaExistenciaFeriado = BFeriado.ValidarExistenciaFeriado(EFeriado);
                if (ListaExistenciaFeriado.Count > 0)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "Mensaje", "<script>$('#mensaje').html(GenerarMensaje('" + Constant.TituloRegistroFeriadoExsistente + "','" + Constant.MensajeRegistroFeriadoExistente + "'))</script>");
                    ClientScript.RegisterStartupScript(this.GetType(), "Show", "<script>myModalShow();</script>");
                }
                else if (diferenciaenDias > 3)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "Show", "<script>$('#myModalExcedeFeriado').modal('show');</script>");
                }
                else
                {
                    EActividad EActividad = new EActividad
                    {
                        FechaInicio = objResources.GetDateFromTextBox(txtFechaInicio),
                        FechaTermino = objResources.GetDateFromTextBox(txtFechaFin)
                    };
                    List<EActividad> ListaActividadesAfectadas;
                    ListaActividadesAfectadas = BActividad.ConsultarActividadesAfectadas(EActividad);
                    if(ListaActividadesAfectadas.Count > 0)
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "Show", "<script>$('#myModalActividades').modal('show');</script>");
                    }
                    else
                    {
                        RegistrarFeriado();
                    }
                }
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
                RegistrarFeriado();
            }
            catch (Exception ex)
            {
                Response.Redirect("../Error/NoAccess.html");
            }
        }

        protected void btnOpenCarga_Click(object sender, EventArgs e)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "Show", "<script>$('#myModalRepetitivo').modal('show');</script>");
        }
    }
}