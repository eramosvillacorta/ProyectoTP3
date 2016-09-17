<%@ Page Title="" Language="C#" MasterPageFile="~/MaterPage/SiteInnovaSchool.Master" AutoEventWireup="true" CodeBehind="frmCalendarioExtracurricular.aspx.cs" Inherits="InnovaSchool.UserLayer.Interfaces.frmCalendarioExtracurricular" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div class="row-fluid sortable ui-sortable">
        <div class="box span12">
            <div class="box-header" data-original-title="">
                <h2><i class="halflings-icon white edit"></i><span class="break"></span>Calendario Académico</h2>
            </div>
            <div class="box-content">
                <div class="form-horizontal">
                    <fieldset>
                        <div class="control-group">
                            <label class="control-label" for="ddlAnio">Año escolar</label>
                            <div class="controls">
                                <asp:DropDownList ID="ddlAnio" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlAnio_SelectedIndexChanged"></asp:DropDownList>
                            </div>
                        </div>
                        <div class="control-group">
                            <asp:GridView ID="gvCalendario" runat="server"
                                CssClass="table table-striped table-bordered bootstrap-datatable datatable dataTable"
                                Caption="<div>Lista de Calendarios Extracurriculares</div>"
                                DataKeyNames="IdCalendario, IdAgenda"
                                AutoGenerateColumns="False" OnRowDataBound="gvCalendario_RowDataBound" OnRowCommand="gvCalendario_RowCommand">
                                <Columns>
                                    <asp:BoundField DataField="IdCalendario" HeaderText="IdCalendario" Visible="false" />
                                    <asp:BoundField DataField="IdAgenda" HeaderText="Año Escolar" ItemStyle-CssClass="align-cen" HeaderStyle-Width="15%" />
                                    <asp:BoundField DataField="FecCreacion" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Fecha de Creación" ItemStyle-CssClass="align-cen" HeaderStyle-Width="15%" />
                                    <asp:BoundField DataField="FecModificacion" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Fecha de Cierre" ItemStyle-CssClass="align-cen" HeaderStyle-Width="15%" />
                                    <asp:BoundField DataField="UsuCreacion" HeaderText="Responsable" HeaderStyle-Width="20%" ItemStyle-CssClass="align-cen" />
                                    <asp:BoundField DataField="Estado" HeaderText="Estado" ItemStyle-CssClass="align-cen" HeaderStyle-Width="15%" />
                                    <asp:TemplateField HeaderText ="Opciones" HeaderStyle-Width="20%"> 
                                        <ItemTemplate> 
                                        <asp:LinkButton ID="lbtActividad" CommandName="Actividad" CssClass="btn btn-primary btn-gv" runat="server" ToolTip="Actividades" >
                                            <i class="halflings-icon white list"></i>
                                        </asp:LinkButton> 
                                        </ItemTemplate> 
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField> 
                                </Columns>
                            </asp:GridView>
                        </div>
                        <div class="form-actions">
                            <a href="../Index.aspx" class="btn btn-success">Cancelar</a>
                        </div>
                    </fieldset>
                </div>
            </div>
        </div>
    </div>
    <%-- Mensaje de Confirmación Apertura de Calendario --%>
    <div class="modal hide fade in" id="myModalApertura">
        <div class="modal-header">
            <button type="button" class="close" data-dismiss="modal">×</button>
            <h2>Aperturar Calendario</h2>
        </div>
        <div class="modal-body">
            <p>¿Está seguro de aperturar un calendario académico para el año escolar vigente?</p>
        </div>
        <div class="modal-footer">
            <a href="#" class="btn btn-success" data-dismiss="modal">No</a>
        </div>
    </div>
</asp:Content>
