<%@ Page Title="" Language="C#" MasterPageFile="~/MaterPage/SiteInnovaSchool.Master" AutoEventWireup="true" CodeBehind="frmActividadesExtracurriculares.aspx.cs" Inherits="InnovaSchool.UserLayer.Interfaces.frmActividadesExtracurriculares" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div class="row-fluid sortable ui-sortable">
        <div class="box span12" id="divApertura" runat="server">
            <div class="box-header" data-original-title="">
                <h2><i class="halflings-icon white edit"></i><span class="break"></span>Actividades Extracurriculares del calendario <asp:Label ID="lblAnio" runat="server" Text="lblAnio"></asp:Label></h2>
            </div>
            <div class="box-content">
                <div class="form-horizontal">
                    <fieldset>
                        <div id="divRegistroActividad" runat="server">
                            <div class="control-group">
                                <label class="control-label" for="txtNomActividad">Nombre Actividad</label>
                                <div class="controls">
                                    <asp:HiddenField ID="hdfActividad" runat="server" Value="0" />
                                    <asp:TextBox ID="txtNombreActividad" runat="server" type="text" class="input-xxlarge"
                                        title="Se necesita un nombre para la actividad"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfNombreActividad" runat="server"
                                        ValidationGroup="ActividadValid"
                                        ControlToValidate="txtNombreActividad"
                                        ForeColor="Red"
                                        Font-Size="Small"
                                        Display="Dynamic"
                                        ErrorMessage="<div><i>*Se necesita un nombre</i></div>">
                                    </asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="control-group">
                                <label class="control-label" for="ddlTipoActividad">Tipo de Actividad</label>
                                <div class="controls">
                                    <asp:DropDownList ID="ddlTipoActividad" runat="server"></asp:DropDownList>
                                    <asp:CompareValidator ID="cvTipoActividad" runat="server" 
                                        ValidationGroup="ActividadValid"
                                        ControlToValidate="ddlTipoActividad"
                                        Operator="GreaterThan"
                                        ValueToCompare="0"
                                        ForeColor="Red"
                                        Font-Size="Small"
                                        Display="Dynamic"
                                        ErrorMessage="<div><i>*Se necesita un tipo de actividad</i></div>">
                                    </asp:CompareValidator>
                                </div>
                            </div>
                            <div class="control-group">
                                <label class="control-label" for="txtDescripcion">Descripción</label>
                                <div class="controls">
                                    <asp:TextBox ID="txtDescripcion" runat="server" type="text" class="input-xxlarge" style="resize:none;" 
                                        MaxLength="500" TextMode="MultiLine" Rows="4" title="Se necesita una descripción"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rvDescripcion" runat="server"
                                        ValidationGroup="ActividadValid"
                                        ControlToValidate="txtDescripcion"
                                        ForeColor="Red"
                                        Font-Size="Small"
                                        Display="Dynamic"
                                        ErrorMessage="<div><i>*Se necesita una descripción</i></div>">
                                    </asp:RequiredFieldValidator>
                                </div>
                            </div>     
                            <div class="control-group">
                            <label class="control-label" for="ddlAlcance">Alcance</label>
                                <div class="controls">
                                    <asp:DropDownList ID="ddlAlcance" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlAlcance_SelectedIndexChanged"></asp:DropDownList>
                                    <asp:CompareValidator ID="cvAlcance" runat="server" 
                                        ValidationGroup="ActividadValid"
                                        ControlToValidate="ddlAlcance"
                                        Operator="GreaterThan"
                                        ValueToCompare="0"
                                        ForeColor="Red"
                                        Font-Size="Small"
                                        Display="Dynamic"
                                        ErrorMessage="<div><i>*Se necesita un alcance</i></div>">
                                    </asp:CompareValidator>   
                                </div>
                            </div>
                            <div class="control-group">
                                <label class="control-label" for="ddlResponsable">Responsable</label>
                                <div class="controls">
                                    <asp:DropDownList ID="ddlResponsable" runat="server"></asp:DropDownList>
                                    <asp:CompareValidator ID="cvResponsable" runat="server" 
                                        ValidationGroup="ActividadValid"
                                        ControlToValidate="ddlResponsable"
                                        Operator="GreaterThan"
                                        ValueToCompare="0"
                                        ForeColor="Red"
                                        Font-Size="Small"
                                        Display="Dynamic"
                                        ErrorMessage="<div><i>*Se necesita un responsable</i></div>">
                                    </asp:CompareValidator>   
                                </div>
                            </div>  
                            <div class="control-group">
                                <label class="control-label" for="txtFechaInicio">Fecha de Inicio</label>
                                <div class="controls">
                                    <asp:TextBox ID="txtFechaInicio" runat="server" type="text" class="input-medium datepicker"
                                        title="Se necesita una fecha de inicio"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvFechaInicio" runat="server"
                                        ValidationGroup="FechaValid"
                                        ControlToValidate="txtFechaInicio"
                                        ForeColor="Red"
                                        Font-Size="Small"
                                        Display="Dynamic"
                                        ErrorMessage="<div><i>*Se necesita una fecha de inicio</i></div>">
                                    </asp:RequiredFieldValidator>
                                    <asp:RangeValidator ID="rvFechaInicio" runat="server" 
                                        ValidationGroup="FechaValid"
                                        ControlToValidate="txtFechaInicio"
                                        Type="Date"
                                        ForeColor="Red"
                                        Font-Size="Small"
                                        Display="Dynamic"
                                        ErrorMessage="<div><i>*La fecha de la actividad se encuentra fuera del rango del año escolar vigente o es menor a la actual.</i></div>">
                                    </asp:RangeValidator>
                                </div>
                            </div>
                            <div class="control-group">
                                <label class="control-label" for="txtFechaFin">Fecha de Fin</label>
                                <div class="controls">
                                    <asp:TextBox ID="txtFechaFin" runat="server" type="text" class="input-medium datepicker"
                                        title="Se necesita una fecha de fin"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvFechaFin" runat="server"
                                        ValidationGroup="FechaValid"
                                        ControlToValidate="txtFechaFin"
                                        ForeColor="Red"
                                        Font-Size="Small"
                                        Display="Dynamic"
                                        ErrorMessage="<div><i>*Se necesita una fecha de fin</i></div>">
                                    </asp:RequiredFieldValidator>
                                    <asp:RangeValidator ID="rvFechaFin" runat="server" 
                                        ValidationGroup="FechaValid"
                                        ControlToValidate="txtFechaFin"
                                        Type="Date"
                                        ForeColor="Red"
                                        Font-Size="Small"
                                        Display="Dynamic"
                                        ErrorMessage="<div><i>*La fecha de la actividad se encuentra fuera del rango del año escolar vigente o es menor a la actual.</i></div>">
                                    </asp:RangeValidator>
                                    <asp:CompareValidator ID="cvFechaFin" runat="server"  
                                        ValidationGroup="FechaValid"
                                        ControlToValidate="txtFechaFin"
                                        ControlToCompare="txtFechaInicio"
                                        Operator="GreaterThanEqual"
                                        Type="Date"
                                        ForeColor="Red"
                                        Font-Size="Small"
                                        Display="Dynamic"
                                        ErrorMessage="<div><i>*La fecha de fin debe ser mayor o igual a la fecha actual y a la fecha de inicio.</i></div>">
                                    </asp:CompareValidator>
                                
                                    <asp:Button ID="btnIngresarHoras" runat="server" Text="Registar Horas" class="btn btn-primary" ValidationGroup="FechaValid"
                                        OnClick="btnIngresarHoras_Click" style="margin-left: 10px;" />
                                </div>                                                        
                            </div>                               
                            <div class="control-group">
                                <asp:GridView ID="gvDetalleActividad" runat="server"
                                CssClass="table table-striped table-bordered bootstrap-datatable datatable dataTable"                                                                                             
                                AutoGenerateColumns="False"
                                OnRowDataBound="gvDetalleActividad_RowDataBound">
                                    <Columns>                                    
                                        <asp:BoundField DataField="Fecha" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Fecha" ItemStyle-CssClass="align-cen" HeaderStyle-Width="10%" />
                                        <asp:TemplateField HeaderText ="Hora Inicio" HeaderStyle-Width="20%"> 
                                            <ItemTemplate> 
                                                <asp:DropDownList ID="ddlHoraInicio" runat="server" class="input-mini"></asp:DropDownList>                                            
                                                <asp:RequiredFieldValidator ID="rfvHoraInicio" runat="server" 
                                                    ValidationGroup="ActividadValid"
                                                    ControlToValidate="ddlHoraInicio"
                                                    InitialValue="0"
                                                    ForeColor="Red"
                                                    Font-Size="Small"
                                                    Display="Dynamic"
                                                    ErrorMessage="<div><i>*Ingresar Hora Inicio</i></div>">
                                                </asp:RequiredFieldValidator> &nbsp;:&nbsp;   
                                                <asp:DropDownList ID="ddlMinutoInicio" runat="server" class="input-mini"></asp:DropDownList>                                            
                                                <asp:RequiredFieldValidator ID="rfvMinutoInicio" runat="server" 
                                                    ValidationGroup="ActividadValid"
                                                    ControlToValidate="ddlMinutoInicio"
                                                    InitialValue="-1"
                                                    ForeColor="Red"
                                                    Font-Size="Small"
                                                    Display="Dynamic"
                                                    ErrorMessage="<div><i>*Ingresar Minuto Inicio</i></div>">
                                                </asp:RequiredFieldValidator>  
                                            </ItemTemplate> 
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField> 
                                        <asp:TemplateField HeaderText ="Hora Fin" HeaderStyle-Width="20%"> 
                                            <ItemTemplate>                                             
                                                <asp:DropDownList ID="ddlHoraFin" runat="server" class="input-mini"></asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="rfvHoraFin" runat="server" 
                                                    ValidationGroup="ActividadValid"
                                                    ControlToValidate="ddlHoraFin"
                                                    InitialValue="0"
                                                    ForeColor="Red"
                                                    Font-Size="Small"
                                                    Display="Dynamic"
                                                    ErrorMessage="<div><i>*Ingresar Hora Fin</i></div>">
                                                </asp:RequiredFieldValidator>&nbsp;:&nbsp;  
                                                <asp:DropDownList ID="ddlMinutoFin" runat="server" class="input-mini"></asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="rfvMinutoFin" runat="server" 
                                                    ValidationGroup="ActividadValid"
                                                    ControlToValidate="ddlMinutoFin"
                                                    InitialValue="-1"
                                                    ForeColor="Red"
                                                    Font-Size="Small"
                                                    Display="Dynamic"
                                                    ErrorMessage="<div><i>*Ingresar Minuto Fin</i></div>">
                                                </asp:RequiredFieldValidator>  
                                            </ItemTemplate> 
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField> 
                                        <asp:TemplateField HeaderText ="Ubicación" HeaderStyle-Width="15%"> 
                                            <ItemTemplate> 
                                                <asp:DropDownList ID="ddlUbicacion" runat="server" AutoPostBack="True" class="input-medium" OnSelectedIndexChanged="ddlUbicacion_SelectedIndexChanged"></asp:DropDownList>                                           
                                                <asp:CompareValidator ID="cvUbicacion" runat="server" 
                                                    ValidationGroup="ActividadValid"
                                                    ControlToValidate="ddlUbicacion"
                                                    Operator="GreaterThan"
                                                    ValueToCompare="0"
                                                    ForeColor="Red"
                                                    Font-Size="Small"
                                                    Display="Dynamic"
                                                    ErrorMessage="<div><i>*Seleccionar ubicación</i></div>">
                                                </asp:CompareValidator>  
                                            </ItemTemplate> 
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField> 
                                        <asp:TemplateField HeaderText ="Ambiente / Dirección" HeaderStyle-Width="45%"> 
                                            <ItemTemplate> 
                                                <asp:DropDownList ID="ddlAmbiente" runat="server" class="input-xlarge" Visible="false"></asp:DropDownList>
                                                <asp:TextBox ID="txtDireccion" runat="server" type="text" class="input-xlarge editable-input" Visible="false" MaxLength="100"></asp:TextBox>
                                            </ItemTemplate> 
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField> 
                                        <asp:TemplateField Visible="false">
                                            <ItemTemplate>
                                                <asp:Label id="lblHoraInicial" runat ="server" text='<%# Eval("HoraInicial")%>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField Visible="false">
                                            <ItemTemplate>
                                                <asp:Label id="lblHoraTermino" runat ="server" text='<%# Eval("HoraTermino")%>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField Visible="false">
                                            <ItemTemplate>
                                                <asp:Label id="lblIdAmbiente" runat ="server" text='<%# Eval("IdAmbiente")%>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField Visible="false">
                                            <ItemTemplate>
                                                <asp:Label id="lblDireccion" runat ="server" text='<%# Eval("Direccion")%>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField Visible="false">
                                            <ItemTemplate>
                                                <asp:Label id="lblIdDetalleActividad" runat ="server" text='<%# Eval("IdDetalleActividad")%>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </div>
                            <div class="form-actions">
                                <asp:Button ID="btnOperGuardar" runat="server" type="submit" Text="Guardar" class="btn btn-primary" ValidationGroup="ActividadValid" OnClick="btnOperGuardar_Click" />
                                <asp:Button ID="btnLimpiar" runat="server" Text="Limpiar" type="reset" class="btn btn-warning" UseSubmitBehavior="False" OnClick="btnLimpiar_Click"/>
                                <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" type="reset" class="btn btn-success" UseSubmitBehavior="False" OnClick="btnCancelar_Click"/>
                            </div>                            
                        </div>
                        <div id="divConsultaActividad" runat="server">
                            <div class="box-header" data-original-title="">
                                <h2><i class="halflings-icon white search"></i><span class="break"></span>Consulta Actividades Extracurriculares</h2>
                            </div>
                            <div class="control-group">
                            </div>
                            <%-- Busqueda --%>
                            <div class="control-group">
                                <label class="control-label" for="txtNomActividadB">Nombre de la actividad</label>
                                <div class="controls">
                                    <asp:HiddenField ID="HiddenField1" runat="server" Value="0" />
                                    <asp:TextBox ID="txtNomActividadB" runat="server" type="text" class="input-xlarge"></asp:TextBox>
                                </div>
                            </div>
                            <div class="control-group">
                                <label class="control-label" for="txtFInicioB">Fecha Inicio</label>
                                <div class="controls">
                                    <asp:TextBox ID="txtFInicioB" runat="server" type="text" class="input-medium datepicker"></asp:TextBox>
                                </div>
                            </div>
                            <div class="control-group">
                                <label class="control-label" for="txtFTerminoB">Fecha Fin</label>
                                <div class="controls">
                                    <asp:TextBox ID="txtFTerminoB" runat="server" type="text" class="input-medium datepicker"></asp:TextBox>
                                </div>
                            </div>
                            <div class="control-group">
                                <label class="control-label" for="ddlResponsable">Responsable</label>
                                <div class="controls">
                                    <asp:DropDownList ID="ddlResponsableB" runat="server"></asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-actions">
                                <asp:Button ID="btnBuscar" runat="server" type="submit" Text="Buscar" class="btn btn-info" UseSubmitBehavior="False" OnClick="btnBuscar_Click" />
                            </div>
                            <div class="control-group">                                
                            </div>
                        </div>
                        <%-- Lista --%>
                        <div class="control-group">
                            <asp:GridView ID="gvActividades" runat="server"
                                CssClass="table table-striped table-bordered bootstrap-datatable datatable dataTable"
                                AllowPaging="True" PageSize="8"
                                DataKeyNames="IdActividad"
                                AutoGenerateColumns="False" 
                                OnPageIndexChanging="gvActividades_PageIndexChanging" OnRowCommand="gvActividades_RowCommand" OnRowDataBound="gvActividades_RowDataBound">
                                <PagerStyle CssClass="pagination pagination-centered" />
                                <Columns>
                                    <asp:BoundField DataField="IdActividad" HeaderText="IdActividad" Visible="false" />
                                    <asp:BoundField DataField="Nombre" HeaderText="Nombre" HeaderStyle-Width="20%" ItemStyle-CssClass="align-cen" />                                    
                                    <asp:BoundField DataField="Tipo" HeaderText="Tipo de Actividad" HeaderStyle-Width="15%" ItemStyle-CssClass="align-cen"/>
                                    <asp:TemplateField Visible="false">
                                        <ItemTemplate>
                                            <asp:Label id="lblDescripcion" runat ="server" text='<%# Eval("Descripcion")%>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField Visible="false">
                                        <ItemTemplate>
                                            <asp:Label id="lblAlcance" runat ="server" text='<%# Eval("Alcance")%>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="IdPersona" HeaderText="IdPersona" Visible="false" />
                                    <asp:BoundField DataField="UsuCreacion" HeaderText="Responsable" HeaderStyle-Width="15%" ItemStyle-CssClass="align-cen"/>
                                    <asp:BoundField DataField="FecInicio" DataFormatString="{0:dd/MM/yyyy}"  HeaderText="Fecha de Inicio" ItemStyle-CssClass="align-cen" HeaderStyle-Width="10%" />
                                    <asp:BoundField DataField="FecTermino" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Fecha de Término" ItemStyle-CssClass="align-cen" HeaderStyle-Width="10%" />
                                    <asp:BoundField DataField="Estado" HeaderText="Estado" HeaderStyle-Width="10%" />
                                    <asp:TemplateField HeaderText ="Opciones" HeaderStyle-Width="15%"> 
                                        <ItemTemplate> 
                                        <asp:LinkButton ID="lbtEditar" CommandName="Editar" CssClass="btn btn-primary btn-gv" runat="server" ToolTip="Editar" >
                                            <i class="halflings-icon white edit"></i>
                                        </asp:LinkButton> 
                                        <asp:LinkButton ID="lbtEliminar" CommandName="Eliminar" CssClass="btn btn-danger btn-gv" runat="server" ToolTip="Eliiminar" >
                                            <i class="halflings-icon white trash"></i>
                                        </asp:LinkButton>
                                        </ItemTemplate> 
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField> 
                                </Columns>
                            </asp:GridView>
                        </div>
                        <div class="form-actions" id="divCancelar" runat="server" visible="false">
                            <asp:Button ID="btnCancelar2" runat="server" Text="Cancelar" type="reset" class="btn btn-success" UseSubmitBehavior="False" OnClick="btnCancelar2_Click"/>
                        </div>
                    </fieldset>
                </div>
            </div>
        </div>
    </div>
    <div class="modal hide fade in" id="myModalMensaje">
        <div class="modal-header">
            <button type="button" class="close" data-dismiss="modal">×</button>
            <h2><asp:Label ID="lblTituloMensaje" runat="server" Text=""></asp:Label></h2>
        </div>
        <div class="modal-body">
            <p><asp:Label ID="lblDescripcionMensaje" runat="server" Text=""></asp:Label></p>
        </div>
        <div class="modal-footer">            
            <a href="#" class="btn btn-success" data-dismiss="modal">Aceptar</a>
        </div>
    </div>    
    <div class="modal hide fade in" id="myModalConfirmarGuardar">
        <div class="modal-header">
            <button type="button" class="close" data-dismiss="modal">×</button>
            <h2>Guardar Actividad</h2>
        </div>
        <div class="modal-body">
            <p><asp:Label ID="lblMensajeConfirmacionGuardar" runat="server" Text=""></asp:Label></p>
        </div>
        <div class="modal-footer">            
            <asp:Button ID="btnConfirmarGuardar" runat="server" type="submit" Text="Sí" class="btn btn-primary" OnClick="btnConfirmarGuardar_Click" />
            <a href="#" class="btn btn-success" data-dismiss="modal">No</a>
        </div>
    </div>    
    <asp:HiddenField runat="server" ID="hfIdActividad" />
</asp:Content>
