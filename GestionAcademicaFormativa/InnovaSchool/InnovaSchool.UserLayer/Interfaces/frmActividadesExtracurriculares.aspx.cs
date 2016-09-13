using InnovaSchool.BL;
using InnovaSchool.Entity;
using InnovaSchool.UserLayer.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InnovaSchool.UserLayer.Interfaces
{
    public partial class frmActividadesExtracurriculares : System.Web.UI.Page
    {
        BActividad BActividad = new BActividad();
        BEmpleado BEmpleado = new BEmpleado();
        BFeriado BFeriado = new BFeriado();
        BAgenda BAgenda = new BAgenda();
        BParametro BParametro = new BParametro();
        BAmbiente BAmbiente = new BAmbiente();
        Resources.Resources objResources = new Resources.Resources();
        static int IdCalendario;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {                
                IniciarValidacion();                
            }
        }

        protected void gvActividades_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType != DataControlRowType.DataRow) return;

            e.Row.Cells[2].Text = BParametro.ConsultarParametro(int.Parse(Constant.ParametroTipoActividadExtracurricular), int.Parse(e.Row.Cells[2].Text), null);

            LinkButton lnkEditar = ((LinkButton)e.Row.FindControl("lbtEditar"));
            LinkButton lnkEliminar = ((LinkButton)e.Row.FindControl("lbtEliminar"));

            if (e.Row.Cells[9].Text == "1")
            {
                e.Row.Cells[9].Text = "Borrador";
                e.Row.Cells[9].CssClass = "label label-warning estado";
                lnkEditar.Visible = true;
                lnkEliminar.Visible = true;
            }
            else if (e.Row.Cells[9].Text == "2")
            {
                e.Row.Cells[9].Text = "Programada";
                e.Row.Cells[9].CssClass = "label label-warning estado";
                lnkEditar.Visible = true;
                lnkEliminar.Visible = true;
            }
            else if (e.Row.Cells[9].Text == "3")
            {
                e.Row.Cells[9].Text = "Rechazada";
                e.Row.Cells[9].CssClass = "label label-important estado";
                lnkEditar.Visible = true;
                lnkEliminar.Visible = true;
            }
            else if (e.Row.Cells[9].Text == "4")
            {
                e.Row.Cells[9].Text = "Activa";
                e.Row.Cells[9].CssClass = "label label-important estado";
                lnkEditar.Visible = true;
                lnkEliminar.Visible = false;
            }
        }

        protected void ddlAlcance_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarResponsable();
        }

        protected void gvDetalleActividad_RowDataBound(object sender, GridViewRowEventArgs e)
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
                if (!hfIdActividad.Value.Equals(string.Empty) && !dtHoraInicial.Equals(DateTime.MinValue))
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

        private void CargarTipoActividadExtracurricular()
        {
            ddlTipoActividad.DataSource = BParametro.ConsultarParametrosLista(Convert.ToInt32(Constant.ParametroTipoActividadExtracurricular));
            ddlTipoActividad.DataValueField = "ValNumerico";
            ddlTipoActividad.DataTextField = "Descripcion";
            ddlTipoActividad.DataBind();
            ddlTipoActividad.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Seleccionar", "0"));
        }

        private void CargarAlcance()
        {
            ddlAlcance.DataSource = BParametro.ConsultarParametrosLista(Convert.ToInt32(Constant.ParametroAlcance));
            ddlAlcance.DataValueField = "ValNumerico";
            ddlAlcance.DataTextField = "Descripcion";
            ddlAlcance.DataBind();
            ddlAlcance.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Seleccionar", "0"));
            ddlResponsable.Enabled = false;
        }

        protected void btnIngresarHoras_Click(object sender, EventArgs e)
        {
            EFeriado EFeriado;
            EActividad EActividad = new EActividad()
            {
                FecInicio = objResources.GetDateFromTextBox(txtFechaInicio),
                FecTermino = objResources.GetDateFromTextBox(txtFechaFin)
            };
            EFeriado = BFeriado.VerificarFeriado(EActividad);
            if (EFeriado != null)
            {
                string Feriado = " " + string.Format("{0:dd/MM/yyyy}", EFeriado.FechaInicio) + " - " + EFeriado.Motivo.ToString();
                lblTituloMensaje.Text = Constant.TituloActividadFeriado;
                lblDescripcionMensaje.Text = string.Format(Constant.MensajeActividadFeriado, EFeriado.Motivo);
                ClientScript.RegisterStartupScript(this.GetType(), "Show", "<script>$('#myModalMensaje').modal('show');</script>");
                gvDetalleActividad.DataSource = new List<EDetalleActividad>();
                gvDetalleActividad.DataBind();
            }
            else
            {
                List<EDetalleActividad> lstDetalleActividad = new List<EDetalleActividad>();
                DateTime dtFechaFin = Convert.ToDateTime(txtFechaFin.Text);
                DateTime dtFechaInicio = Convert.ToDateTime(txtFechaInicio.Text);

                for (DateTime dt = dtFechaInicio; dt <= dtFechaFin; dt = dt.AddDays(1))
                {
                    EDetalleActividad EDetalleActividad = new EDetalleActividad();
                    EDetalleActividad.Fecha = dt;
                    lstDetalleActividad.Add(EDetalleActividad);
                }

                gvDetalleActividad.DataSource = lstDetalleActividad;
                gvDetalleActividad.DataBind();
            }            
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
                ddlResponsable.Enabled = true;
            }
            else
            {
                ddlResponsable.Enabled = false;
                ddlResponsable.Items.Clear();
                ddlResponsable.DataBind();
            }

        }

        private void CargarResponsableBusqueda()
        {
            List<EEmpleado> ListEEmpleado;
            EEmpleado EEmpleado = new EEmpleado();
            EEmpleado.IdPuesto = 1;

            ListEEmpleado = BEmpleado.ListarResponsable(EEmpleado);
            ddlResponsableB.DataSource = ListEEmpleado;
            ddlResponsableB.DataTextField = "Nombre";
            ddlResponsableB.DataValueField = "IdEmpleado";
            ddlResponsableB.DataBind();
            ddlResponsableB.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Selecionar", "0"));
        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Interfaces/frmCalendarioExtracurricular.aspx");
        }

        protected void btnCancelar2_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Interfaces/frmCalendarioExtracurricular.aspx");
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                BuscarActividad();
            }
            catch (Exception ex)
            {
                Response.Redirect("../Error/NoAccess.html");
            }
        }

        private void BuscarActividad()
        {
            ECalendario ECalendario = (ECalendario)Session["Calendario"];
            EActividad EActividad = new EActividad()
            {
                IdCalendario = ECalendario.IdCalendario,
                Nombre = txtNomActividadB.Text,
                FecInicio = objResources.GetDateFromTextBox(txtFInicioB),
                FecTermino = objResources.GetDateFromTextBox(txtFTerminoB),
                IdEmpleado = int.Parse(ddlResponsableB.SelectedValue)
            };
            List<EActividad> ListEActividad;
            ListEActividad = BActividad.ConsultarActividadCalendarioFiltro(EActividad);
            gvActividades.DataSource = ListEActividad;
            gvActividades.DataBind();
            if (ListEActividad.Count == 0)
            {
                lblTituloMensaje.Text = Constant.TituloNoActividad;
                lblDescripcionMensaje.Text = Constant.MensajeNoActividad;
                ClientScript.RegisterStartupScript(this.GetType(), "Show", "<script>$('#myModalMensaje').modal('show');</script>");
            }
        }

        private void Limpiar()
        {
            objResources.LimpiarControles(this.Controls);
            ddlResponsable.Items.Clear();
            ddlResponsable.DataBind();
            ddlResponsable.Enabled = false;
            hdfActividad.Value = string.Empty;
            ListarActividades();
        }

        private void ListarActividades()
        {
            ECalendario ECalendario = (ECalendario)Session["Calendario"];
            EActividad EActividad = new EActividad();
            IdCalendario = ECalendario.IdCalendario;
            EActividad.IdCalendario = IdCalendario;
            lblAnio.Text = ECalendario.IdAgenda;
            List<EActividad> ListEActividad;
            ListEActividad = BActividad.ListarActividadesCalendario(EActividad);
            if (ListEActividad.Count != 0)
            {
                gvActividades.DataSource = ListEActividad;
                gvActividades.DataBind();
                divConsultaActividad.Visible = true;
            }
            else
            {
                divConsultaActividad.Visible = false;
            }
        }

        protected void gvActividades_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                int rowIndex;
                EActividad EActividad = new EActividad();
                switch (e.CommandName)
                {
                    case "Editar":
                        rowIndex = (((GridViewRow)((TableCell)((LinkButton)e.CommandSource).Parent).Parent)).RowIndex;
                        GridViewRow gvr = (((GridViewRow)((TableCell)((LinkButton)e.CommandSource).Parent).Parent));

                        EActividad.IdActividad = int.Parse(gvActividades.DataKeys[rowIndex][0].ToString());
                        hfIdActividad.Value = EActividad.IdActividad.ToString();
                        //EActividad.IdActividad = int.Parse(((Label)gvr.FindControl("lblIdActividad")).Text);
                        txtNombreActividad.Text = gvActividades.Rows[rowIndex].Cells[1].Text;
                        ddlTipoActividad.SelectedIndex = ddlTipoActividad.Items.IndexOf(ddlTipoActividad.Items.FindByText(gvActividades.Rows[rowIndex].Cells[2].Text));
                        txtDescripcion.Text = ((Label)gvr.FindControl("lblDescripcion")).Text;                                                                            
                        ddlAlcance.SelectedIndex = ddlAlcance.Items.IndexOf(ddlAlcance.Items.FindByValue(((Label)gvr.FindControl("lblAlcance")).Text));
                        CargarResponsable();
                        ddlResponsable.SelectedIndex = ddlResponsable.Items.IndexOf(ddlResponsable.Items.FindByText(gvActividades.Rows[rowIndex].Cells[6].Text));
                        txtFechaInicio.Text = string.Format("{0:dd/MM/yyyy}", gvActividades.Rows[rowIndex].Cells[7].Text);
                        txtFechaFin.Text = string.Format("{0:dd/MM/yyyy}", gvActividades.Rows[rowIndex].Cells[8].Text);

                        gvDetalleActividad.DataSource = BActividad.ConsultarDetalleActividad(EActividad);                    
                        gvDetalleActividad.DataBind();                 
                        break;
                    case "Eliminar":
                        rowIndex = (((GridViewRow)((TableCell)((LinkButton)e.CommandSource).Parent).Parent)).RowIndex;
                        EActividad.IdActividad = (int)gvActividades.DataKeys[rowIndex][0];
                        hdfActividad.Value = EActividad.IdActividad.ToString();
                        ClientScript.RegisterStartupScript(this.GetType(), "Show", "<script>$('#myModalEliminar').modal('show');</script>");
                        break;
                }
            }
            catch (Exception ex)
            {
                Response.Redirect("../Error/NoAccess.html");
            }
        }

        private void IniciarValidacion()
        {
            ListarActividades();
            CargarResponsableBusqueda();

            if (!lblAnio.Text.Equals(DateTime.Today.Year.ToString()))
            {
                gvActividades.Columns[7].Visible = false;
                divRegistroActividad.Visible = false;
                divCancelar.Visible = true;
            }
            else
            {
                EAgenda EAgenda = new EAgenda();
                EAgenda.IdAgenda = DateTime.Now.Year.ToString();
                var FecIniAnio = string.Empty;
                var FecFinAnio = string.Empty;

                EAgenda = BAgenda.ConsultarAgenda(EAgenda);
                if (EAgenda != null)
                {
                    FecIniAnio = string.Format("{0:dd/MM/yyyy}", EAgenda.FecIniEscolar);
                    FecFinAnio = string.Format("{0:dd/MM/yyyy}", EAgenda.FecFinEscolar);

                    if (EAgenda.Estado == int.Parse(Constant.ParametroAgendaEstadoVigente))
                    {
                        CargarAlcance();                        
                        CargarTipoActividadExtracurricular();
                    }
                    else
                    {
                        lblTituloMensaje.Text = Constant.TituloNoAgendaAprobada;
                        lblDescripcionMensaje.Text = Constant.MensajeNoAgendaAprobada;
                        ClientScript.RegisterStartupScript(this.GetType(), "Show", "<script>$('#myModalMensaje').modal('show');</script>");
                        divRegistroActividad.Visible = false;
                    }
                }
                else
                {
                    FecIniAnio = string.Format("{0:dd/MM/yyyy}", DateTime.Now);
                    FecFinAnio = string.Format("{0:dd/MM/yyyy}", DateTime.Now);

                    lblTituloMensaje.Text = Constant.TituloNoAgendaAperturada;
                    lblDescripcionMensaje.Text = Constant.MensajeNoAgendaAperturada;
                    ClientScript.RegisterStartupScript(this.GetType(), "Show", "<script>$('#myModalMensaje').modal('show');</script>");
                    divRegistroActividad.Visible = false;
                }

                rvFechaInicio.MinimumValue = string.Format("{0:dd/MM/yyyy}", DateTime.Now);
                rvFechaInicio.MaximumValue = FecFinAnio.ToString();
                rvFechaFin.MinimumValue = string.Format("{0:dd/MM/yyyy}", DateTime.Now);
                rvFechaFin.MaximumValue = FecFinAnio.ToString();
            }            
        }

        protected void gvActividades_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                objResources.ControlPageGridView(gvActividades, e);
                BuscarActividad();
            }
            catch (Exception) { }
        }

        protected void btnOperGuardar_Click(object sender, EventArgs e)
        {
            lblMensajeConfirmacionGuardar.Text = Constant.MensajeConfirmarRegistroActividadExtracurricular;
            ClientScript.RegisterStartupScript(this.GetType(), "Show", "<script>$('#myModalConfirmarGuardar').modal('show');</script>");          
        }

        protected void btnConfirmarGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                EActividad EActividad = new EActividad
                {
                    Nombre = txtNombreActividad.Text,
                    Descripcion = txtDescripcion.Text,
                    IdEmpleado = int.Parse(ddlResponsable.SelectedValue),
                    Alcance = ddlAlcance.SelectedValue,
                    FecInicio = objResources.GetDateFromTextBox(txtFechaInicio),
                    Tipo = int.Parse(ddlTipoActividad.SelectedValue),
                    FecTermino = objResources.GetDateFromTextBox(txtFechaFin)
                };

                EFeriado EFeriado = new EFeriado();
                EFeriado = BFeriado.VerificarFeriado(EActividad);
                if (EFeriado != null)
                {
                    string Feriado = " " + string.Format("{0:dd/MM/yyyy}", EFeriado.FechaInicio) + " - " + EFeriado.Motivo.ToString();
                    lblTituloMensaje.Text = Constant.TituloActividadFeriado;
                    lblDescripcionMensaje.Text = string.Format(Constant.MensajeActividadFeriado, EFeriado.Motivo);
                    ClientScript.RegisterStartupScript(this.GetType(), "Show", "<script>$('#myModalMensaje').modal('show');</script>");
                    gvDetalleActividad.DataSource = new List<EDetalleActividad>();
                    gvDetalleActividad.DataBind();
                }
                else
                {
                    int IdActividad = 0;
                    if (!hfIdActividad.Value.Equals(string.Empty))
                        IdActividad = int.Parse(hfIdActividad.Value);

                    EActividad.IdActividad = IdActividad;
                    EUsuario EUsuario = (EUsuario)Session["Usuario"];

                    ECalendario ECalendario = new ECalendario
                    {
                        IdAgenda = DateTime.Today.Year.ToString(),
                        Tipo = Constant.ParametroTipoCalendarioExtracurricular
                    };

                    List<EDetalleActividad> lstDetalleActividad = new List<EDetalleActividad>();
                    foreach (GridViewRow gvr in gvDetalleActividad.Rows)
                    {
                        DateTime dtFecha = Convert.ToDateTime(gvr.Cells[0].Text);
                        DropDownList ddlHoraInicio = (gvr.FindControl("ddlHoraInicio") as DropDownList);
                        DropDownList ddlMinutoInicio = (gvr.FindControl("ddlMinutoInicio") as DropDownList);
                        DropDownList ddlHoraFin = (gvr.FindControl("ddlHoraFin") as DropDownList);
                        DropDownList ddlMinutoFin = (gvr.FindControl("ddlMinutoFin") as DropDownList);
                        DropDownList ddlUbicacion = gvr.FindControl("ddlUbicacion") as DropDownList;
                        DropDownList ddlAlmbiente = gvr.FindControl("ddlAmbiente") as DropDownList;
                        string strIdDetalleActividad = (gvr.FindControl("lblIdDetalleActividad") as Label).Text;
                        int IdDetalleActividad = 0;
                        if (!strIdDetalleActividad.Equals(string.Empty))
                            IdDetalleActividad = int.Parse(strIdDetalleActividad);
                        EDetalleActividad EDetalleActividad = new EDetalleActividad
                        {
                            IdDetalleActividad = IdDetalleActividad,
                            Fecha = dtFecha,
                            HoraInicial = new DateTime(dtFecha.Year, dtFecha.Month, dtFecha.Day, int.Parse(ddlHoraInicio.SelectedValue), int.Parse(ddlMinutoInicio.SelectedValue), 0),
                            HoraTermino = new DateTime(dtFecha.Year, dtFecha.Month, dtFecha.Day, int.Parse(ddlHoraFin.SelectedValue), int.Parse(ddlMinutoFin.SelectedValue), 0),
                            IdAmbiente = (ddlUbicacion.SelectedIndex == 1 ? int.Parse(ddlAlmbiente.SelectedValue) : 0),
                            Direccion = (ddlUbicacion.SelectedIndex == 2 ? ((gvr.FindControl("txtDireccion") as TextBox).Text) : string.Empty),
                        };

                        lstDetalleActividad.Add(EDetalleActividad);
                    }

                    EActividad.ListaDetalleActividad = lstDetalleActividad;

                    int retval = 0;
                    retval = BActividad.VerificarCruceActividad(EActividad);
                    if (retval == 0)
                    {
                        retval = BActividad.RegistrarActividad(EActividad, EUsuario, ECalendario);

                        if (retval == 0)
                        {
                            lblTituloMensaje.Text = Constant.TituloRegistroActividad;
                            lblDescripcionMensaje.Text = Constant.MensajeErrorGuardarActividad;
                            ClientScript.RegisterStartupScript(this.GetType(), "Show", "<script>$('#myModalMensaje').modal('show');</script>");
                        }
                        else
                        {
                            if (hfIdActividad.Value.ToString().Equals(string.Empty))
                                hfIdActividad.Value = EActividad.IdActividad.ToString();
                            lblTituloMensaje.Text = Constant.TituloRegistroActividad;
                            lblDescripcionMensaje.Text = Constant.MensajeGuardarActividadExtracurricular;
                            ClientScript.RegisterStartupScript(this.GetType(), "Show", "<script>$('#myModalMensaje').modal('show');</script>");
                            //ddlAnio.SelectedIndex = 0;
                            gvDetalleActividad.DataSource = BActividad.ConsultarDetalleActividad(EActividad);
                            gvDetalleActividad.DataBind();
                            gvActividades.DataSource = new List<EActividad>();
                            gvActividades.DataBind();
                        }
                    }
                    else if (retval == 1)
                    {
                        lblTituloMensaje.Text = Constant.TituloRegistroActividad;
                        lblDescripcionMensaje.Text = Constant.MensajeCruceAlcanceGuardarActividad;
                        ClientScript.RegisterStartupScript(this.GetType(), "Show", "<script>$('#myModalMensaje').modal('show');</script>");
                    }
                    else if (retval == 2)
                    {
                        lblTituloMensaje.Text = Constant.TituloRegistroActividad;
                        lblDescripcionMensaje.Text = Constant.MensajeCruceAmbienteGuardarActividad;
                        ClientScript.RegisterStartupScript(this.GetType(), "Show", "<script>$('#myModalMensaje').modal('show');</script>");
                    }
                }
                
            }
            catch (Exception ex)
            {
                Response.Redirect("../Error/NoAccess.html");
            }
        }       

        protected void ddlUbicacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList ddlUbicacion = (DropDownList)sender;
            string strUbicacion = ddlUbicacion.SelectedValue;

            GridViewRow gvrUbicacion = ((GridViewRow)ddlUbicacion.Parent.Parent);
            DropDownList ddlAmbiente = (DropDownList)gvrUbicacion.FindControl("ddlAmbiente");
            TextBox txtDireccion = (TextBox)gvrUbicacion.FindControl("txtDireccion");

            if (strUbicacion.Equals(Constant.ParametroUbicacionInterna))
            {
                ddlAmbiente.DataSource = BAmbiente.ListarAmbientes();
                ddlAmbiente.DataValueField = "IDAmbiente";
                ddlAmbiente.DataTextField = "Nombre";
                ddlAmbiente.DataBind();
                ddlAmbiente.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Seleccionar", "0"));
                ddlAmbiente.Visible = true;
                txtDireccion.Visible = false;
            }
            else if (strUbicacion.Equals(Constant.ParametroUbicacionExterna))
            {
                ddlAmbiente.Visible = false;
                txtDireccion.Visible = true;
                txtDireccion.Text = string.Empty;
            }
            else
            {
                ddlAmbiente.Visible = false;
                txtDireccion.Visible = false;
            }
        }
    }
}