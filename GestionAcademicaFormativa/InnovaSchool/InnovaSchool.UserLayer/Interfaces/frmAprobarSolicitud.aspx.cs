using InnovaSchool.BL;
using InnovaSchool.Entity;
using InnovaSchool.UserLayer.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InnovaSchool.UserLayer.Interfaces
{
    public partial class frmAprobarSolicitud : System.Web.UI.Page
    {
        BSolicitudActividad BSolicitudActividad = new BSolicitudActividad();
        BParametro BParametro = new BParametro();
        BActividad BActividad = new BActividad();
        BEmpleado BEmpleado = new BEmpleado();
        BAmbiente BAmbiente = new BAmbiente();
        BAprobacionSolicitudActividad BAprobacionSolicitudActividad = new BAprobacionSolicitudActividad();

        protected void Page_Load(object sender, EventArgs e)
        {      
            if(!Page.IsPostBack)
            {
                IniciarCarga();
            }            
        }

        private void IniciarCarga()
        {
            CargarSolicitudes();
            CargarTipoActividad();
            CargarAlcance();
        }

        private void CargarSolicitudes()
        {
            EAgenda EAgenda = new EAgenda();
            EAgenda.IdAgenda = DateTime.Today.Year.ToString();
            gvSolicitudesPendientes.DataSource = BSolicitudActividad.ListarSolicitudesPendientesAgenda(EAgenda);
            gvSolicitudesPendientes.DataBind();
        }        

        private void CargarAlcance()
        {
            ddlAlcance.DataSource = BParametro.ConsultarParametrosLista(Convert.ToInt32(Constant.ParametroAlcance));
            ddlAlcance.DataValueField = "ValNumerico";
            ddlAlcance.DataTextField = "Descripcion";
            ddlAlcance.DataBind();
            ddlAlcance.Items.Insert(0, new System.Web.UI.WebControls.ListItem(string.Empty, "0"));
        }

        private void CargarTipoActividad()
        {
            ddlActividad.DataSource = BParametro.ConsultarParametrosLista(Convert.ToInt32(Constant.ParametroTipoActividad));
            ddlActividad.DataValueField = "ValTextual";
            ddlActividad.DataTextField = "Descripcion";
            ddlActividad.DataBind();
            ddlActividad.Items.Insert(0, new System.Web.UI.WebControls.ListItem(string.Empty, "0"));
        }

        private void CargarResponsable()
        {
            List<EEmpleado> ListEEmpleado;
            EEmpleado EEmpleado = new EEmpleado();
            int IdAlcance = int.Parse(ddlAlcance.SelectedValue);

            if (IdAlcance > 0)
            {
                EEmpleado.IdPuesto = IdAlcance;
                ListEEmpleado = BEmpleado.ListarResponsable(EEmpleado);
                ddlResponsable.DataSource = ListEEmpleado;
                ddlResponsable.DataTextField = "Nombre";
                ddlResponsable.DataValueField = "IdEmpleado";
                ddlResponsable.DataBind();
                ddlResponsable.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Seleccionar", "0"));
            }
            else
            {
                ddlResponsable.Items.Clear();
                ddlResponsable.DataBind();
            }

        }

        private void CargarTipoEspecificoActividad()
        {
            string strTipoActividad = ddlActividad.SelectedValue;
            if (strTipoActividad.Equals(Constant.ParametroTipoCalendarioAcademico))
            {
                CargarTipoActividadAcademica();
            }
            else if (strTipoActividad.Equals(Constant.ParametroTipoCalendarioExtracurricular))
            {
                CargarTipoActividadExtracurricular();
            }
            else
            {
                ddlTipoActividad.Items.Clear();
                ddlTipoActividad.DataBind();
            }
        }

        private void CargarTipoActividadAcademica()
        {
            ddlTipoActividad.DataSource = BParametro.ConsultarParametrosLista(Convert.ToInt32(Constant.ParametroTipoActividadAcademica));
            ddlTipoActividad.DataValueField = "ValNumerico";
            ddlTipoActividad.DataTextField = "Descripcion";
            ddlTipoActividad.DataBind();
            ddlTipoActividad.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Seleccionar", "0"));
        }

        private void CargarTipoActividadExtracurricular()
        {
            ddlTipoActividad.DataSource = BParametro.ConsultarParametrosLista(Convert.ToInt32(Constant.ParametroTipoActividadExtracurricular));
            ddlTipoActividad.DataValueField = "ValNumerico";
            ddlTipoActividad.DataTextField = "Descripcion";
            ddlTipoActividad.DataBind();
            ddlTipoActividad.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Seleccionar", "0"));
        }

        protected void gvResponsables_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlResponsable.SelectedValue = gvResponsables.SelectedDataKey.Value.ToString();
        }

        protected void gvSolicitudesPendientes_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int rowIndex;
            EActividad EActividad = new EActividad();
            ESolicitudActividad ESolicitudActividad = new ESolicitudActividad();
            divInformacionSolicitud.Visible = true;

            switch (e.CommandName)
            {
                case "Editar":
                    rowIndex = (((GridViewRow)((TableCell)((LinkButton)e.CommandSource).Parent).Parent)).RowIndex;
                    GridViewRow gvr = (((GridViewRow)((TableCell)((LinkButton)e.CommandSource).Parent).Parent));

                    ESolicitudActividad.IdSolicitudActividad = int.Parse(gvSolicitudesPendientes.DataKeys[rowIndex][0].ToString());
                    hfIdSolicitudActividad.Value = ESolicitudActividad.IdSolicitudActividad.ToString();
                    EActividad.IdActividad = int.Parse(((Label)gvr.FindControl("lblIdActividad")).Text);
                    txtNombreActividad.Text = gvSolicitudesPendientes.Rows[rowIndex].Cells[5].Text;
                    ddlActividad.SelectedIndex = ddlActividad.Items.IndexOf(ddlActividad.Items.FindByText(gvSolicitudesPendientes.Rows[rowIndex].Cells[6].Text));
                    CargarTipoEspecificoActividad();
                    ddlTipoActividad.SelectedIndex = ddlTipoActividad.Items.IndexOf(ddlTipoActividad.Items.FindByText(gvSolicitudesPendientes.Rows[rowIndex].Cells[7].Text));
                    txtDescripcion.Text = ((Label)gvr.FindControl("lblDescripcion")).Text;
                    txtMotivo.Text = gvSolicitudesPendientes.DataKeys[rowIndex][1].ToString();
                    ddlAlcance.SelectedIndex = ddlAlcance.Items.IndexOf(ddlAlcance.Items.FindByValue(((Label)gvr.FindControl("lblAlcance")).Text));
                    CargarResponsable();
                    ddlResponsable.SelectedIndex = ddlResponsable.Items.IndexOf(ddlResponsable.Items.FindByText(((Label)gvr.FindControl("lblUsuCreacion")).Text));
                    txtFechaInicio.Text = string.Format("{0:dd/MM/yyyy}", gvSolicitudesPendientes.Rows[rowIndex].Cells[10].Text);
                    txtFechaFin.Text = string.Format("{0:dd/MM/yyyy}", gvSolicitudesPendientes.Rows[rowIndex].Cells[11].Text);

                    gvDetalleSolicitudActividad.DataSource = BActividad.ConsultarDetalleActividad(EActividad);
                    gvDetalleSolicitudActividad.DataBind();
                    txtObservaciones.Text = string.Empty;
                    break;
                case "Eliminar":
                    break;
            }
        }

        protected void gvResponsables_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void gvSolicitudesPendientes_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType != DataControlRowType.DataRow) return;

            if (e.Row.Cells[6].Text == "A")
                e.Row.Cells[7].Text = BParametro.ConsultarParametro(int.Parse(Constant.ParametroTipoActividadAcademica), int.Parse(e.Row.Cells[7].Text), null);
            else if (e.Row.Cells[6].Text == "E")
                e.Row.Cells[7].Text = BParametro.ConsultarParametro(int.Parse(Constant.ParametroTipoActividadExtracurricular), int.Parse(e.Row.Cells[7].Text), null);

            e.Row.Cells[6].Text = BParametro.ConsultarParametro(int.Parse(Constant.ParametroTipoActividad), 0, e.Row.Cells[6].Text);
        }

        protected void gvDetalleSolicitudActividad_RowCommand(object sender, GridViewCommandEventArgs e)
        {
        }

        protected void gvResponsables_RowCommand(object sender, GridViewCommandEventArgs e)
        {
        }        

        protected void gvDetalleSolicitudActividad_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DropDownList ddlUbicacion = (e.Row.FindControl("ddlUbicacion") as DropDownList);
                ddlUbicacion.DataSource = BParametro.ConsultarParametrosLista(Convert.ToInt32(Constant.ParametroUbicacion));
                ddlUbicacion.DataValueField = "ValTextual";
                ddlUbicacion.DataTextField = "Descripcion";
                ddlUbicacion.DataBind();
                ddlUbicacion.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Seleccionar", "0"));

                List<EParametro> lstHora = BParametro.ConsultarParametrosLista(Convert.ToInt32(Constant.ParametroHora));
                List<EParametro> lstMinuto = BParametro.ConsultarParametrosLista(Convert.ToInt32(Constant.ParametroMinuto));

                DropDownList ddlHoraInicio = (e.Row.FindControl("ddlHoraInicio") as DropDownList);
                ddlHoraInicio.DataSource = lstHora;
                ddlHoraInicio.DataValueField = "ValNumerico";
                ddlHoraInicio.DataTextField = "Descripcion";
                ddlHoraInicio.DataBind();
                ddlHoraInicio.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--", "0"));

                DropDownList ddlMinutoInicio = (e.Row.FindControl("ddlMinutoInicio") as DropDownList);
                ddlMinutoInicio.DataSource = lstMinuto;
                ddlMinutoInicio.DataValueField = "ValNumerico";
                ddlMinutoInicio.DataTextField = "Descripcion";
                ddlMinutoInicio.DataBind();
                ddlMinutoInicio.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--", "-1"));

                DropDownList ddlHoraFin = (e.Row.FindControl("ddlHoraFin") as DropDownList);
                ddlHoraFin.DataSource = lstHora;
                ddlHoraFin.DataValueField = "ValNumerico";
                ddlHoraFin.DataTextField = "Descripcion";
                ddlHoraFin.DataBind();
                ddlHoraFin.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--", "0"));

                DropDownList ddlMinutoFin = (e.Row.FindControl("ddlMinutoFin") as DropDownList);
                ddlMinutoFin.DataSource = lstMinuto;
                ddlMinutoFin.DataValueField = "ValNumerico";
                ddlMinutoFin.DataTextField = "Descripcion";
                ddlMinutoFin.DataBind();
                ddlMinutoFin.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--", "-1"));

                DateTime dtHoraInicial = Convert.ToDateTime((e.Row.FindControl("lblHoraInicial") as Label).Text);
                if (!hfIdSolicitudActividad.Value.Equals(string.Empty) && !dtHoraInicial.Equals(DateTime.MinValue))
                {
                    string strHoraInicial = dtHoraInicial.ToString("HH:mm");
                    ddlHoraInicio.SelectedIndex = ddlHoraInicio.Items.IndexOf(ddlHoraInicio.Items.FindByText(strHoraInicial.Split(':')[0]));
                    ddlMinutoInicio.SelectedIndex = ddlMinutoInicio.Items.IndexOf(ddlMinutoInicio.Items.FindByText(strHoraInicial.Split(':')[1]));

                    DateTime dtHoraTermino = Convert.ToDateTime((e.Row.FindControl("lblHoraTermino") as Label).Text);
                    string strHoraTermino = dtHoraTermino.ToString("HH:mm");
                    ddlHoraFin.SelectedIndex = ddlHoraFin.Items.IndexOf(ddlHoraFin.Items.FindByText(strHoraTermino.Split(':')[0]));
                    ddlMinutoFin.SelectedIndex = ddlMinutoFin.Items.IndexOf(ddlMinutoFin.Items.FindByText(strHoraTermino.Split(':')[1]));

                    string strDireccion = (e.Row.FindControl("lblDireccion") as Label).Text;
                    string IdAmbiente = (e.Row.FindControl("lblIdAmbiente") as Label).Text;
                    DropDownList ddlAmbiente = (e.Row.FindControl("ddlAmbiente") as DropDownList);
                    TextBox txtDirecion = (e.Row.FindControl("txtDireccion") as TextBox);

                    if (!strDireccion.Equals(string.Empty))
                    {
                        ddlUbicacion.SelectedIndex = 2;
                        txtDirecion.Text = strDireccion;
                        txtDirecion.Visible = true;
                        ddlAmbiente.Visible = false;
                    }
                    else
                    {
                        ddlUbicacion.SelectedIndex = 1;
                        ddlAmbiente.DataSource = BAmbiente.ListarAmbientes();
                        ddlAmbiente.DataValueField = "IDAmbiente";
                        ddlAmbiente.DataTextField = "Nombre";
                        ddlAmbiente.DataBind();
                        ddlAmbiente.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Seleccionar", "0"));
                        ddlAmbiente.SelectedIndex = ddlAmbiente.Items.IndexOf(ddlAmbiente.Items.FindByValue(IdAmbiente));
                        txtDirecion.Visible = false;
                        ddlAmbiente.Visible = true;
                    }
                }
            }
        }        

        protected void btnConsultarDisponibilidad_Click(object sender, EventArgs e)
        {
            EEmpleado EEmpleado = new EEmpleado();
            int IdAlcance = int.Parse(ddlAlcance.SelectedValue);
            EEmpleado.IdPuesto = IdAlcance;

            DateTime fechaInicio = Convert.ToDateTime(txtFechaInicio.Text);            
            fechaInicio = fechaInicio.AddDays(DayOfWeek.Monday - fechaInicio.DayOfWeek);
            DateTime fechaFin = fechaInicio.AddDays(6);


            gvResponsables.DataSource = BEmpleado.ListarResponsableSemana(EEmpleado, fechaInicio, fechaFin);
            gvResponsables.DataBind();
            ClientScript.RegisterStartupScript(this.GetType(), "Show", "<script>$('#myModalDisponibilidad').modal('show');</script>"); 
        }      
  
        protected void btnAceptarResponsable_Click(object sender, EventArgs e)
        {

        }

        protected void btnAprobar_Click(object sender, EventArgs e)
        {
            lblTituloMensaje.Text = Constant.TituloAprobarSolicitud;
            lblDescripcionMensaje.Text = Constant.MensajeConfirmarAprobarSolicitud;
            btnConfirmarAprobar.Visible = true;
            btnConfirmarRechazar.Visible = false;
            btnAceptar.Visible = false;
            btnCancelar.Visible = true;
            ClientScript.RegisterStartupScript(this.GetType(), "Show", "<script>$('#myModalMensaje').modal('show');</script>"); 
        }

        protected void btnConfirmarAprobar_Click(object sender, EventArgs e)
        {
            EAprobacionSolicitudActividad EAprobacionSolicitudActividad = new EAprobacionSolicitudActividad();
            EAprobacionSolicitudActividad.IdSolicitudActividad = int.Parse(hfIdSolicitudActividad.Value);
            EAprobacionSolicitudActividad.Observacion = txtObservaciones.Text;
            EAprobacionSolicitudActividad.Estado = int.Parse(Constant.EstadoAprobacionAprobado);
            EUsuario EUsuario = (EUsuario)Session["Usuario"];

            BAprobacionSolicitudActividad.RegistrarAprobacionSolicitudActividad(EAprobacionSolicitudActividad, EUsuario, int.Parse(ddlResponsable.SelectedValue));
            
            CargarSolicitudes();
            divInformacionSolicitud.Visible = false;            

            lblTituloMensaje.Text = Constant.TituloAprobarSolicitud;
            lblDescripcionMensaje.Text = Constant.MensajeAprobarSolicitud;
            btnConfirmarAprobar.Visible = false;
            btnConfirmarRechazar.Visible = false;
            btnAceptar.Visible = true;
            btnCancelar.Visible = false;

            EnviarCorreo("Solicitud de actividad aprobada: ");
            ClientScript.RegisterStartupScript(this.GetType(), "Show", "<script>$('#myModalMensaje').modal('show');</script>");            
        }

        protected void btnRechazar_Click(object sender, EventArgs e)
        {
            lblTituloMensaje.Text = Constant.TituloRechazarSolicitud;
            lblDescripcionMensaje.Text = Constant.MensajeConfirmarRechazarSolicitud;
            btnConfirmarAprobar.Visible = false;
            btnConfirmarRechazar.Visible = true;
            btnAceptar.Visible = false;
            btnCancelar.Visible = true;
            
            ClientScript.RegisterStartupScript(this.GetType(), "Show", "<script>$('#myModalMensaje').modal('show');</script>");            
        }

        protected void btnConfirmarRechazar_Click(object sender, EventArgs e)
        {
            EAprobacionSolicitudActividad EAprobacionSolicitudActividad = new EAprobacionSolicitudActividad();
            EAprobacionSolicitudActividad.IdSolicitudActividad = int.Parse(hfIdSolicitudActividad.Value);            
            EAprobacionSolicitudActividad.Observacion = txtObservaciones.Text;
            EAprobacionSolicitudActividad.Estado = int.Parse(Constant.EstadoAprobacionRechazado);
            EUsuario EUsuario = (EUsuario)Session["Usuario"];

            BAprobacionSolicitudActividad.RegistrarAprobacionSolicitudActividad(EAprobacionSolicitudActividad, EUsuario, int.Parse(ddlResponsable.SelectedValue));

            CargarSolicitudes();
            divInformacionSolicitud.Visible = false;

            lblTituloMensaje.Text = Constant.TituloRechazarSolicitud;
            lblDescripcionMensaje.Text = Constant.MensajeRechazarSolicitud;
            btnConfirmarAprobar.Visible = false;
            btnConfirmarRechazar.Visible = false;
            btnAceptar.Visible = true;
            btnCancelar.Visible = false;

            EnviarCorreo("Solicitud de actividad rechazada: ");
            ClientScript.RegisterStartupScript(this.GetType(), "Show", "<script>$('#myModalMensaje').modal('show');</script>");                        
        }

        private void EnviarCorreo(string strTitulo)
        {
            if (Constant.FlagCorreo.Equals("1"))
            {
                var fromAddress = new MailAddress(Constant.CorreoAprobacion, "InnovaSchools");
                var toAddress = new MailAddress(Constant.CorreoAprobacion, "Coordinador Académico");
                string fromPassword = Constant.PasswordAprobacion;
                string subject = strTitulo + txtNombreActividad.Text;
                string body = txtObservaciones.Text;

                var smtp = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = true,
                    Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
                };
                using (var message = new MailMessage(fromAddress, toAddress)
                {
                    Subject = subject,
                    Body = body
                })
                {
                    smtp.Send(message);
                }
            }
        }
    }
}