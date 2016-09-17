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
    public partial class frmCalendarioExtracurricular : System.Web.UI.Page
    {
        BAgenda BAgenda = new BAgenda();
        BCalendario BCalendario = new BCalendario();
        BParametro BParametro = new BParametro();
        Resources.Resources objResources = new Resources.Resources();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                CargarAniosCalendario();
                ListarCalendarios();
            }
        }

        private void CargarAniosCalendario()
        {
            List<ECalendario> ListECalendario;
            ECalendario ECalendario = new ECalendario();
            ECalendario.Tipo = Constant.ParametroTipoCalendarioExtracurricular.ToString();
            ListECalendario = BCalendario.AniosCalendario(ECalendario);
            ddlAnio.DataSource = ListECalendario;
            ddlAnio.DataTextField = "IdAgenda";
            ddlAnio.DataValueField = "IdCalendario";
            ddlAnio.DataBind();
            ddlAnio.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Seleccionar", "0"));
        }

        private void ListarCalendarios()
        {
            List<ECalendario> ListECalendario;
            ECalendario ECalendario = new ECalendario();
            ECalendario.IdCalendario = int.Parse(ddlAnio.SelectedValue);
            ECalendario.Tipo = Constant.ParametroTipoCalendarioExtracurricular.ToString();
            ListECalendario = BCalendario.ConsultarCalendario(ECalendario);
            gvCalendario.DataSource = ListECalendario;
            gvCalendario.DataBind();
        }

        protected void ddlAnio_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListarCalendarios();
        }

        protected void gvCalendario_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType != DataControlRowType.DataRow) return;
            switch (e.Row.Cells[5].Text)
            {
                case "1":
                    e.Row.Cells[5].CssClass = "label label-warning estado";
                    break;
                case "2":
                    e.Row.Cells[5].CssClass = "label label-warning estado";
                    break;
                case "3":
                    e.Row.Cells[5].CssClass = "label label-success estado";
                    break;
                case "4":
                    e.Row.Cells[5].CssClass = "label label-success estado";
                    break;
                case "5":
                    e.Row.Cells[5].CssClass = "label label-important estado";
                    break;
            }
            e.Row.Cells[5].Text = BParametro.ConsultarParametro(Constant.ParametroEstadosCalendario, int.Parse(e.Row.Cells[5].Text), null);
        }

        protected void gvCalendario_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                int rowIndex;
                rowIndex = (((GridViewRow)((TableCell)((LinkButton)e.CommandSource).Parent).Parent)).RowIndex;
                switch (e.CommandName)
                {
                    case "Actividad":
                        ECalendario ECalendario = new ECalendario();
                        ECalendario.IdCalendario = (int)gvCalendario.DataKeys[rowIndex][0];
                        ECalendario.IdAgenda = (string)gvCalendario.DataKeys[rowIndex][1];
                        Session["Calendario"] = ECalendario;
                        Response.Redirect("frmActividadesExtracurriculares.aspx", false);
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