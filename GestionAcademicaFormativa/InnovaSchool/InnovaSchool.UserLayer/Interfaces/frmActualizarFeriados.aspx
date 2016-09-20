﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MaterPage/SiteInnovaSchool.Master" AutoEventWireup="true" CodeBehind="frmActualizarFeriados.aspx.cs" Inherits="InnovaSchool.UserLayer.Interfaces.frmActualizarFeriados" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div class="row-fluid sortable ui-sortable">
        <div class="box span12" id="divActualizarFeriado" runat="server">
            <div class="box-header" data-original-title="">
                <h2><i class="halflings-icon white edit"></i><span class="break"></span>Actualizar Feriados</h2>
            </div>
            <div class="box-content">
                <div class="form-horizontal">
                    <fieldset>
                        <div class="control-group">
                            <label class="control-label" for="txtAnioEscolarVigente">Año escolar vigente:</label>
                            <div class="controls">
                                <asp:TextBox ID="txtAnioEscolarVigente" runat="server" type="text" class="disabled input-medium" Enabled="false"></asp:TextBox>
                            </div>
                        </div>
                        <div class="control-group">
                            <label class="control-label" for="txtDescripcion">Descripción:</label>
                            <div class="controls">
                                <asp:TextBox ID="txtDescripcion" runat="server" type="text" TextMode="MultiLine" class="input-xlarge editable-input"
                                    title="Se necesita una descripción" ValidationGroup="SolicitudValid" MaxLength="100" Style="resize: none;" Rows="4"
                                    onkeyup="ismaxlength1(this,ContentPlaceHolder2_lblcontador,100)"></asp:TextBox>
                                <br />
                                <asp:Label ID="lblcontador" runat="server"></asp:Label>
                                <asp:RequiredFieldValidator ID="rvDescripcion" runat="server"
                                    ValidationGroup="SolicitudValid"
                                    ControlToValidate="txtDescripcion"
                                    ForeColor="Red"
                                    Font-Size="Small"
                                    Display="Dynamic"
                                    ErrorMessage="<div><i>*Se necesita una descripción</i></div>"> </asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="control-group">
                            <label class="control-label" for="txtFechaInicio">Fecha de Inicio:</label>
                            <div class="controls">
                                <asp:TextBox ID="txtFechaInicio" runat="server" type="text" class="input-medium datepicker"
                                    title="Se necesita una fecha de inicio" BackColor="White" MaxLength="10"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvFechaInicio" runat="server"
                                    ValidationGroup="SolicitudValid"
                                    ControlToValidate="txtFechaInicio"
                                    ForeColor="Red"
                                    Font-Size="Small"
                                    Display="Dynamic"
                                    ErrorMessage="<div><i>*Se necesita una fecha de inicio</i></div>"></asp:RequiredFieldValidator>
                                <asp:CompareValidator ID="cvFechaInicio" runat="server"
                                    ValidationGroup="SolicitudValid"
                                    ControlToValidate="txtFechaInicio"
                                    Operator="GreaterThan"
                                    Type="Date"
                                    ForeColor="Red"
                                    Font-Size="Small"
                                    Display="Dynamic"
                                    ErrorMessage="<div><i>*La fecha de inicio debe ser mayor a la fecha actual.</i></div>">
                                </asp:CompareValidator>
                            </div>
                        </div>
                        <div class="control-group">
                            <label class="control-label" for="txtFechaFin">Fecha de Término:</label>
                            <div class="controls">
                                <asp:TextBox ID="txtFechaFin" runat="server" type="text" class="input-medium datepicker"
                                    title="Se necesita una fecha de fin" MaxLength="10"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvFechaFin" runat="server"
                                    ValidationGroup="SolicitudValid"
                                    ControlToValidate="txtFechaFin"
                                    ForeColor="Red"
                                    Font-Size="Small"
                                    Display="Dynamic"
                                    ErrorMessage="<div><i>*Se necesita una fecha de término</i></div>"> </asp:RequiredFieldValidator>
                                <asp:CompareValidator ID="cvFechaFin" runat="server"
                                    ValidationGroup="SolicitudValid"
                                    ControlToValidate="txtFechaFin"
                                    ControlToCompare="txtFechaInicio"
                                    Operator="GreaterThanEqual"
                                    Type="Date"
                                    ForeColor="Red"
                                    Font-Size="Small"
                                    Display="Dynamic"
                                    ErrorMessage="<div><i>*La fecha de término debe ser mayor o igual a la fecha de inicio.</i></div>"> </asp:CompareValidator>
                            </div>
                        </div>
                        <div class="control-group">
                            <div class="controls">
                                <asp:CheckBox ID="chkRepiteCadaAnio" runat="server" Text="Repite cada año" />
                            </div>
                        </div>
                        <div class="form-actions">
                            <asp:Button ID="btnGuardar" runat="server" type="submit" Text="Guardar" class="btn btn-primary" ValidationGroup="SolicitudValid" OnClick="btnGuardar_Click" />
                            <asp:Button ID="btnOpenCarga" runat="server" type="submit" Text="Cargar Feriados" class="btn btn-primary" OnClick="btnOpenCarga_Click" />
                            <asp:Button ID="btnLimpiar" runat="server" type="submit" Text="Limpiar" class="btn btn-warning" OnClick="btnLimpiar_Click" />
                            <a href="../Index.aspx" class="btn btn-success">Cancelar</a>
                        </div>
                    </fieldset>
                </div>
            </div>
        </div>
        <div class="row-fluid sortable ui-sortable">
            <div class="box span12" id="divConsultaSolicitudes" runat="server">
                <div class="box-header" data-original-title="">
                    <h2><i class="halflings-icon white search"></i><span class="break"></span>Consulta Feriados</h2>
                    <%--                    <div class="box-icon">
                        <a href="#" class="btn-minimize"><i class="halflings-icon white chevron-down"></i></a>
                    </div>--%>
                </div>
                <div class="box-content">
                    <div class="form-horizontal">
                        <fieldset>
                            <div class="control-group">
                                <label class="control-label" for="ddlAnio">Año Escolar</label>
                                <div class="controls">
                                    <asp:DropDownList ID="ddlAnio" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlAnio_SelectedIndexChanged"></asp:DropDownList>
                                </div>
                            </div>
                            <div class="control-group">
                                <asp:GridView ID="gvConsultaFeriados" runat="server"
                                    CssClass="table table-striped table-bordered bootstrap-datatable datatable dataTable"
                                    AutoGenerateColumns="False" ShowHeaderWhenEmpty="True"
                                    DataKeyNames="IdFeriado,Motivo" OnRowCommand="gvConsultaFeriados_RowCommand" OnRowDataBound="gvConsultaFeriados_RowDataBound">
                                    <Columns>
                                        <asp:BoundField DataField="IdFeriado" HeaderText="IdFeriado" Visible="false">
                                            <HeaderStyle Width="10%" />
                                            <ItemStyle CssClass="align-cen" />
                                        </asp:BoundField>
                                        <asp:TemplateField Visible="False">
                                            <ItemTemplate>
                                                <asp:Label ID="lblIdFeriado" runat="server" Text='<%# Eval("IdFeriado")%>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblDescripcion" runat="server" Text='<%# Eval("Motivo")%>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblReptitivo" runat="server" Text='<%# Eval("Repetitivo")%>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="Motivo" HeaderText="Descripción" ItemStyle-CssClass="align-cen" HeaderStyle-Width="10%">
                                            <HeaderStyle Width="25%"></HeaderStyle>
                                            <ItemStyle CssClass="align-izq" HorizontalAlign="Left"></ItemStyle>
                                        </asp:BoundField>
                                        <asp:BoundField DataField="FechaInicio" HeaderText="Fecha de Inicio" ItemStyle-CssClass="align-cen" DataFormatString="{0:dd/MM/yyyy}" HeaderStyle-Width="10%">
                                            <HeaderStyle Width="10%"></HeaderStyle>
                                            <ItemStyle CssClass="align-cen"></ItemStyle>
                                        </asp:BoundField>
                                        <asp:BoundField DataField="FechaTermino" HeaderText="Fecha de Término" ItemStyle-CssClass="align-cen" DataFormatString="{0:dd/MM/yyyy}" HeaderStyle-Width="10%">
                                            <HeaderStyle Width="10%"></HeaderStyle>
                                            <ItemStyle CssClass="align-cen"></ItemStyle>
                                        </asp:BoundField>
                                        <asp:TemplateField HeaderText="Repite Cada Año">
                                            <ItemTemplate><%# (Eval("Repetitivo").ToString() == "1") ? "Si" : "No" %></ItemTemplate>
                                            <ControlStyle Width="50px" />
                                            <FooterStyle Width="50px" />
                                            <HeaderStyle Width="10%" CssClass="align-cen" />
                                            <ItemStyle Width="10%" CssClass="align-cen" />
                                        </asp:TemplateField>
                                        <asp:TemplateField Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblMotivo" runat="server" Text='<%# Eval("Motivo")%>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Opciones" HeaderStyle-Width="15%">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lbtEditar" CommandName="Editar" CssClass="btn btn-primary btn-gv" runat="server" ToolTip="Editar" Visible="false">
                                            <i class="halflings-icon white edit"></i>
                                                </asp:LinkButton>
                                                <asp:LinkButton ID="lbtEliminar" CommandName="Eliminar" CssClass="btn btn-danger btn-gv" runat="server" ToolTip="Eliminar" Visible="false">
                                            <i class="halflings-icon white trash"></i>
                                                </asp:LinkButton>
                                            </ItemTemplate>
                                            <HeaderStyle Width="15%"></HeaderStyle>
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </fieldset>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="modal hide fade in" id="myModalActividades">
        <div class="modal-header">
            <button type="button" class="close" data-dismiss="modal">×</button>
            <h2>Actividades Afectadas Por Feriado</h2>
        </div>
        <div class="modal-body">
            <p>Las siguientes actividades serán afectadas por el feriado registrado</p>
            <asp:GridView ID="gvActividad" runat="server"
                CssClass="table table-striped table-bordered bootstrap-datatable datatable dataTable"
                AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="IdCalendario" HeaderText="IdActividad" Visible="false" />
                    <asp:BoundField DataField="IdCalendario" HeaderText="Nombre"/>
                    <asp:BoundField DataField="IdAgenda" HeaderText="Actividad" ItemStyle-CssClass="align-cen" HeaderStyle-Width="10%" />
                    <asp:BoundField DataField="Tipo" HeaderText="Tipo de Actividad" ItemStyle-CssClass="align-cen" HeaderStyle-Width="15%"/>
                    <asp:BoundField DataField="Estado" HeaderText="Responsable"/>
                    <asp:BoundField DataField="Estado" HeaderText="Fecha de Inicio"/>
                    <asp:BoundField DataField="Estado" HeaderText="Fecha de Termino"/>
                </Columns>
            </asp:GridView>
            <p>¿Está seguro de registrar el feriado y suspender las actividades programadas?</p>
        </div>
        <div class="modal-footer">
            <asp:Button ID="Button1" runat="server" type="submit" Text="Aceptar" class="btn btn-primary" UseSubmitBehavior="False" />
            <a href="#" class="btn btn-success" data-dismiss="modal">Cancelar</a>
        </div>
    </div>
    <asp:HiddenField runat="server" ID="hfIdFeriado" />
    <%-- Mensaje de Confirmación de Eliminación de Feriado --%>
    <div class="modal hide fade in" id="myModalRepetitivo">
        <div class="modal-header">
            <button type="button" class="close" data-dismiss="modal">×</button>
            <h2>Cargar Feriado</h2>
        </div>
        <div class="modal-body">
            <p>¿Está seguro de cargar todos los feriados repetitivos del año escolar anterior?</p>
        </div>
        <div class="modal-footer">
            <asp:Button ID="btnCargarFeriado" runat="server" type="submit" Text="Si" class="btn btn-primary" OnClick="btnCargarFeriado_Click" />
            <a href="#" class="btn btn-success" data-dismiss="modal">No</a>
        </div>
    </div>
    <%-- Mensaje de Confirmación de Carga de Feriados Repetitivos--%>
    <div class="modal hide fade in" id="myModalEliminar">
        <div class="modal-header">
            <button type="button" class="close" data-dismiss="modal">×</button>
            <h2>Eliminar Feriado</h2>
        </div>
        <div class="modal-body">
            <p>¿Está seguro de eliminar este feriado?</p>
        </div>
        <div class="modal-footer">
            <asp:Button ID="Button2" runat="server" type="submit" Text="Si" class="btn btn-primary" UseSubmitBehavior="False" OnClick="btnEliminar_Click" />
            <a href="#" class="btn btn-success" data-dismiss="modal">No</a>
        </div>
    </div>
    <%-- Mensaje de Rango Feriados excede 3 dias--%>
    <div class="modal hide fade in" id="myModalExcedeFeriado">
        <div class="modal-header">
            <button type="button" class="close" data-dismiss="modal">×</button>
            <h2>Feriado Largo</h2>
        </div>
        <div class="modal-body">
            <p>El rango de feriados excede los 03 días. ¿Está seguro de registrarlo?</p>
        </div>
        <div class="modal-footer">
            <asp:Button ID="btnRegistrarExceso" runat="server" type="submit" Text="Si" class="btn btn-primary" UseSubmitBehavior="False" OnClick="btnRegistrarExceso_Click" />
            <a href="#" class="btn btn-success" data-dismiss="modal">No</a>
        </div>
    </div>
</asp:Content>
