<%@ Page Title="" Language="C#" MasterPageFile="~/MaterPage/SiteInnovaSchool.Master" AutoEventWireup="true" CodeBehind="frmActualizarFeriados.aspx.cs" Inherits="InnovaSchool.UserLayer.Interfaces.frmActualizarFeriados" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        function limpiarControles() {
            document.getElementById("ContentPlaceHolder2_txtDescripcion").value = "";
            document.getElementById("ContentPlaceHolder2_txtFechaInicio").value = "";
            document.getElementById("ContentPlaceHolder2_txtFechaFin").value = "";
            document.getElementById("ContentPlaceHolder2_chkRepiteCadaAnio").checked = false;
            $('#ContentPlaceHolder2_chkRepiteCadaAnio').attr('checked', false)
            alert(document.getElementById("ContentPlaceHolder2_chkRepiteCadaAnio").checked);

        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div class="row-fluid sortable ui-sortable">
        <div class="box span12" id="divSolicitudActividades" runat="server">
            <div class="box-header" data-original-title="">
                <h2><i class="halflings-icon white edit"></i><span class="break"></span>Actualizar Feriados</h2>
                <div class="box-icon">
                    <a href="#" class="btn-minimize"><i class="halflings-icon white chevron-down"></i></a>                    
                </div>                
            </div>                        
            <div class="box-content">           
                <div class="form-horizontal">
                    <fieldset>
                        <div class="control-group">
                            <label class="control-label" for="txtAnioEscolarVigente">Año escolar vigente:</label>
                            <div class="controls">
                                <asp:TextBox ID="txtAnioEscolarVigente" runat="server" type="text" class="input-xlarge editable-input"
                                 title="Se necesita un nombre" MaxLength="4" Enabled="false"></asp:TextBox>
                                
                            </div>
                        </div>
                        
                        <div class="control-group">
                            <label class="control-label" for="txtDescripcion">Descripción:</label>
                            <div class="controls">
                                <asp:TextBox ID="txtDescripcion" runat="server" type="text" TextMode="MultiLine" class="input-xlarge editable-input"
                                title="Se necesita una descripción" ValidationGroup="SolicitudValid" MaxLength="100"></asp:TextBox>
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
                                    title="Se necesita una fecha de inicio"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvFechaInicio" runat="server"
                                    ValidationGroup="FechaValid"
                                    ControlToValidate="txtFechaInicio"
                                    ForeColor="Red"
                                    Font-Size="Small"
                                    Display="Dynamic"
                                    ErrorMessage="<div><i>*Se necesita una fecha de inicio</i></div>"> </asp:RequiredFieldValidator>
                                <asp:RangeValidator ID="rvFechaInicio" runat="server" 
                                    ValidationGroup="FechaValid"
                                    ControlToValidate="txtFechaInicio"
                                    
                                    ForeColor="Red"
                                    Font-Size="Small"
                                    Display="Dynamic"
                                    MaximumValue="01/01/2100"
                                    ErrorMessage="<div><i>*La fecha de la actividad se encuentra fuera del rango del año escolar vigente o es menor a la actual.</i></div>" MinimumValue="01/01/2000"></asp:RangeValidator>
                            </div>
                        </div>
                        <div class="control-group">
                            <label class="control-label" for="txtFechaFin">Fecha de Termino:</label>
                            <div class="controls">
                                <asp:TextBox ID="txtFechaFin" runat="server" type="text" class="input-medium datepicker"
                                    title="Se necesita una fecha de fin"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvFechaFin" runat="server"
                                    ValidationGroup="FechaValid"
                                    ControlToValidate="txtFechaFin"
                                    ForeColor="Red"
                                    Font-Size="Small"
                                    Display="Dynamic"
                                    ErrorMessage="<div><i>*Se necesita una fecha de fin</i></div>"> </asp:RequiredFieldValidator>
                                <asp:RangeValidator ID="rvFechaFin" runat="server" 
                                    ValidationGroup="FechaValid"
                                    ControlToValidate="txtFechaFin"
                                    
                                    ForeColor="Red"
                                    Font-Size="Small"
                                    Display="Dynamic"
                                    ErrorMessage="<div><i>*La fecha de la actividad se encuentra fuera del rango del año escolar vigente o es menor a la actual.</i></div>"> </asp:RangeValidator>
                                <asp:CompareValidator ID="cvFechaFin" runat="server"  
                                    ValidationGroup="FechaValid"
                                    ControlToValidate="txtFechaFin"
                                    ControlToCompare="txtFechaInicio"
                                    Operator="GreaterThanEqual"
                                    Type="Date"
                                    ForeColor="Red"
                                    Font-Size="Small"
                                    Display="Dynamic"
                                    ErrorMessage="<div><i>*La fecha de fin debe ser mayor o igual a la fecha actual.</i></div>"> </asp:CompareValidator>
                                
                            </div>                                                        
                        </div>
                        <div class="control-group">
                            <div class="controls">
                                <asp:HiddenField ID="HiddenField1" runat="server" Value="0" />
                                <asp:CheckBox ID="chkRepiteCadaAnio" runat="server" Text="Repite cada año" style="margin-left: 10px;" Width="300px" />
                            </div>
                        </div>
                        <div class="form-actions">
                            <asp:Button ID="btnGuardar" runat="server" type="submit" Text="Guardar" class="btn btn-primary"  ValidationGroup="SolicitudValid" OnClick="btnGuardar_Click"  />
                             <asp:Button ID="btnLimpiar" runat="server" type="submit" Text="Limpiar" class="btn btn-warning" OnClick="btnLimpiar_Click"  /> 
                            <!--<input type="button" value="Limpiar" onclick="limpiarControles();" id="btnLimpiar" class="btn btn-warning">-->
                            <a href="../Index.aspx" class="btn btn-success">Cancelar</a>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;                            
                            <input type="button" value="Cargar Feriados" onclick="$('#myModalRepetitivo').modal('show');" id="btnCargar" class="btn btn-primary">
                        </div>                      
                    </fieldset>
                </div>                 
            </div>                       
        </div>
        <div class="row-fluid sortable ui-sortable">
            <div class="box span12" id="divConsultaSolicitudes" runat="server">
                <div class="box-header" data-original-title="">
                    <h2><i class="halflings-icon white search"></i><span class="break"></span>Consulta Feriados</h2>
                    <div class="box-icon">
                        <a href="#" class="btn-minimize"><i class="halflings-icon white chevron-down"></i></a>
                    </div>
                </div>
                <div class="box-content">           
                    <div class="form-horizontal">
                        <fieldset>
                            <div class="control-group">
                                <label class="control-label" for="ddlAnio">Año Escolar</label>
                                <div class="controls">
                                    <asp:DropDownList ID="ddlAnio" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlAnio_SelectedIndexChanged" ></asp:DropDownList>
                                </div>
                            </div>
                            <div class="control-group">
                            <asp:GridView ID="gvConsultaFeriados" runat="server"
                                CssClass="table table-striped table-bordered bootstrap-datatable datatable dataTable"                                                                                             
                                AutoGenerateColumns="False" ShowHeaderWhenEmpty="True"
                                
                                DataKeyNames="IdFeriado,Motivo" OnRowCommand="gvConsultaFeriados_RowCommand" OnRowDataBound="gvConsultaFeriados_RowDataBound">
                                <Columns>                                    
                                    <asp:BoundField DataField="IdFeriado" HeaderText="IdFeriado" Visible="false" >
                                    <HeaderStyle Width="10%" />
                                    <ItemStyle CssClass="align-cen" />
                                    </asp:BoundField>
<asp:TemplateField Visible="False"><ItemTemplate>
                                            <asp:Label id="lblIdFeriado" runat ="server" text='<%# Eval("IdFeriado")%>' />
                                        
</ItemTemplate>
</asp:TemplateField>
                                    <asp:TemplateField Visible="false">
                                        <ItemTemplate>
                                            <asp:Label id="lblDescripcion" runat ="server" text='<%# Eval("Motivo")%>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField Visible="false">
                                        <ItemTemplate>
                                            <asp:Label id="lblReptitivo" runat ="server" text='<%# Eval("Repetitivo")%>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="Motivo" HeaderText="Descripción" ItemStyle-CssClass="align-cen" HeaderStyle-Width="10%" >
<HeaderStyle Width="25%"></HeaderStyle>

<ItemStyle CssClass="align-izq" HorizontalAlign="Left"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="FechaInicio" HeaderText="Fecha Inicio" ItemStyle-CssClass="align-cen"  DataFormatString="{0:dd/MM/yyyy}" HeaderStyle-Width="10%" >
<HeaderStyle Width="10%"></HeaderStyle>

<ItemStyle CssClass="align-cen"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="FechaTermino" HeaderText="Fecha Termino" ItemStyle-CssClass="align-cen"  DataFormatString="{0:dd/MM/yyyy}" HeaderStyle-Width="10%" >                                                                                                          
<HeaderStyle Width="10%"></HeaderStyle>

<ItemStyle CssClass="align-cen"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="Se repite cada año">
                                            <ItemTemplate><%# (Eval("Repetitivo").ToString() == "1") ? "Si" : "No" %></ItemTemplate>
                                            <ControlStyle Width="50px" />
                                            <FooterStyle Width="50px" />
                                            <HeaderStyle Width="10%" CssClass="align-cen" />
                                            <ItemStyle Width="10%" CssClass="align-cen" />
                                    </asp:TemplateField>
                                    <asp:TemplateField Visible="false">
                                        <ItemTemplate>
                                            <asp:Label id="lblMotivo" runat ="server" text='<%# Eval("Motivo")%>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText ="Opciones" HeaderStyle-Width="15%"> 
                                        <ItemTemplate> 
                                        <asp:LinkButton ID="lbtEditar" CommandName="Editar" CssClass="btn btn-primary btn-gv" runat="server" ToolTip="Editar" >
                                            <i class="halflings-icon white edit"></i>
                                        </asp:LinkButton> 
                                        <asp:LinkButton ID="lbtEliminar" CommandName="Eliminar" CssClass="btn btn-danger btn-gv" runat="server" ToolTip="Eliminar">
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
<%-- Mensaje de Confirmación Apertura de Agenda --%>
    <div class="modal hide fade in" id="myModalApertura">
        <div class="modal-header">
            <button type="button" class="close" data-dismiss="modal">×</button>
            <h2>Aperturar Agenda</h2>
        </div>
        <div class="modal-body">
            <p>¿Está seguro de aperturar la agenda escolar para el año escolar vigente?</p>
        </div>
        <div class="modal-footer">
            <asp:Button ID="Button1" runat="server" type="submit" Text="Si" class="btn btn-primary" OnClick="btnGuardar_Click" />
            <a href="#" class="btn btn-success" data-dismiss="modal">No</a>
        </div>
    </div>
    <%-- Mensaje de Confirmación de Registro Feriado --%>
    <div class="modal hide fade in" id="mensaje">
        <div class="modal-header">
            <button type="button" class="close" data-dismiss="modal">×</button>
            <!-- <h2>Registro Feriado</h2> -->
        </div>
        <div class="modal-body">
            <p>El feriado se guardó con éxito.</p>
        </div>
        <div class="modal-footer">
            <a href="#" class="btn btn-success" data-dismiss="modal">Aceptar</a>
        </div>
    </div>
    <asp:HiddenField runat="server" ID="hfIdFeriado" />

    <%-- Mensaje de Confirmación de Eliminación de Feriado --%>
    <div class="modal hide fade in" id="myModalRepetitivo">
        <div class="modal-header">
            <button type="button" class="close" data-dismiss="modal">×</button>
          <!--  <h2>Eliminar Feriado</h2> -->
        </div>
        <div class="modal-body">
            <p>¿Está seguro de cargar los feriados repetitivos del año escolar?</p>
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
          <!--  <h2>Eliminar Feriado</h2> -->
        </div>
        <div class="modal-body">
            <p>¿Está seguro de eliminar este feriado?</p>
        </div>
        <div class="modal-footer">
            <asp:Button ID="Button2" runat="server" type="submit" Text="Si" class="btn btn-primary" UseSubmitBehavior="False" OnClick="btnEliminar_Click"  />
            <a href="#" class="btn btn-success" data-dismiss="modal">No</a>
        </div>
    </div>
</asp:Content>
