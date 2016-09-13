<%@ Page Title="" Language="C#" MasterPageFile="~/MaterPage/SiteInnovaSchool.Master" AutoEventWireup="true" CodeBehind="frmAprobarSolicitud.aspx.cs" Inherits="InnovaSchool.UserLayer.Interfaces.frmAprobarSolicitud" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div class="row-fluid sortable ui-sortable">
        <div class="box span12" id="divSolicitudesPendientes" runat="server">
            <div class="box-header" data-original-title="">
                <h2><i class="halflings-icon white search"></i><span class="break"></span>Listado de Solicitudes Pendientes</h2>
                <div class="box-icon">
                    <a href="#" class="btn-minimize"><i class="halflings-icon white chevron-down"></i></a>
                </div>
            </div>
            <div class="box-content">           
                <div class="form-horizontal">
                    <fieldset>                      
                        <div class="control-group">
                        <asp:GridView ID="gvSolicitudesPendientes" runat="server"
                            CssClass="table table-striped table-bordered bootstrap-datatable datatable dataTable"                                                                                             
                            AutoGenerateColumns="False"
                            OnRowDataBound="gvSolicitudesPendientes_RowDataBound" OnRowCommand="gvSolicitudesPendientes_RowCommand"
                            DataKeyNames="IdSolicitudActividad, Motivo">
                            <Columns>                                    
                                <asp:BoundField DataField="IdSolicitudActividad" HeaderText="IdSolicitudActividad" Visible="false" />
                                <asp:TemplateField Visible="false">
                                    <ItemTemplate>
                                        <asp:Label id="lblIdActividad" runat ="server" text='<%# Eval("EActividad.IdActividad")%>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField Visible="false">
                                    <ItemTemplate>
                                        <asp:Label id="lblDescripcion" runat ="server" text='<%# Eval("EActividad.Descripcion")%>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="Motivo" HeaderText="Motivo" Visible="false" />
                                <asp:BoundField DataField="EActividad.IdPersona" HeaderText="IdPersona" ItemStyle-CssClass="align-cen" HeaderStyle-Width="10%" Visible="false"/>  
                                <asp:BoundField DataField="EActividad.Nombre" HeaderText="Nombre" ItemStyle-CssClass="align-cen" HeaderStyle-Width="10%" />
                                <asp:BoundField DataField="Tipo" HeaderText="Actividad" ItemStyle-CssClass="align-cen" HeaderStyle-Width="10%" />        
                                <asp:BoundField DataField="EActividad.Tipo" HeaderText="Tipo de Actividad" ItemStyle-CssClass="align-cen" HeaderStyle-Width="10%" />                                                                                             
                                <asp:TemplateField Visible="false">
                                    <ItemTemplate>
                                        <asp:Label id="lblUsuCreacion" runat ="server" text='<%# Eval("EActividad.UsuCreacion")%>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="EActividad.Solicitante" HeaderText="Solicitante" ItemStyle-CssClass="align-cen" HeaderStyle-Width="10%"/>                                   
                                <asp:BoundField DataField="EActividad.FecInicio" HeaderText="Fecha Inicio" ItemStyle-CssClass="align-cen"  DataFormatString="{0:dd/MM/yyyy}" HeaderStyle-Width="10%" />
                                <asp:BoundField DataField="EActividad.FecTermino" HeaderText="Fecha Fin" ItemStyle-CssClass="align-cen"  DataFormatString="{0:dd/MM/yyyy}" HeaderStyle-Width="10%" />                                                                                        
                                <asp:TemplateField Visible="false">
                                    <ItemTemplate>
                                        <asp:Label id="lblAlcance" runat ="server" text='<%# Eval("EActividad.Alcance")%>' />
                                    </ItemTemplate>
                                </asp:TemplateField>                      
                                <asp:TemplateField HeaderText ="Opciones" HeaderStyle-Width="15%"> 
                                    <ItemTemplate> 
                                    <asp:LinkButton ID="lbtEditar" CommandName="Editar" CssClass="btn btn-primary btn-gv" runat="server" ToolTip="Editar" >
                                        <i class="halflings-icon white edit"></i>
                                    </asp:LinkButton> 
                                    </ItemTemplate> 
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
    <div class="row-fluid sortable ui-sortable">
        <div class="box span12" id="divInformacionSolicitud" runat="server" visible="false">
            <div class="box-header" data-original-title="">
                <h2><i class="halflings-icon white search"></i><span class="break"></span>Información de Solicitud de Actividad</h2>
                <div class="box-icon">
                    <a href="#" class="btn-minimize"><i class="halflings-icon white chevron-down"></i></a>                    
                </div>                
            </div>                        
            <div class="box-content">           
                <div class="form-horizontal">
                    <fieldset>
                        <div class="control-group">
                            <label class="control-label" for="txtNombreActividad">Nombre Actividad</label>
                            <div class="controls">
                                <asp:TextBox ID="txtNombreActividad" runat="server" type="text" class="input-xlarge editable-input" MaxLength="100" Enabled="false"></asp:TextBox>
                            </div>
                        </div>
                        <div class="control-group">
                            <label class="control-label" for="ddlActividad">Actividad</label>
                            <div class="controls">
                                <asp:DropDownList ID="ddlActividad" runat="server" Enabled="false"></asp:DropDownList>                             
                            </div>
                        </div>
                        <div class="control-group">
                            <label class="control-label" for="ddlTipoActividad">Tipo de Actividad</label>
                            <div class="controls">
                                <asp:DropDownList ID="ddlTipoActividad" runat="server" Enabled="false"></asp:DropDownList>
                            </div>
                        </div>
                        <div class="control-group">
                            <label class="control-label" for="txtDescripcion">Descripción</label>
                            <div class="controls">
                                <asp:TextBox ID="txtDescripcion" runat="server" type="text" TextMode="MultiLine" class="input-xlarge editable-input" MaxLength="100" Enabled="false"></asp:TextBox>
                            </div>
                        </div>
                        <div class="control-group">
                            <label class="control-label" for="txtMotivo">Motivo</label>
                            <div class="controls">
                                <asp:TextBox ID="txtMotivo" runat="server" type="text" TextMode="MultiLine" class="input-xlarge editable-input" MaxLength="100" Enabled="false"></asp:TextBox>
                            </div>
                        </div>                        
                        <div class="control-group">
                            <label class="control-label" for="ddlAlcance">Alcance</label>
                            <div class="controls">
                                <asp:DropDownList ID="ddlAlcance" runat="server" Enabled="false"></asp:DropDownList>
                            </div>
                        </div>
                        <div class="control-group">
                            <label class="control-label" for="ddlResponsable">Responsable</label>
                            <div class="controls">
                                <asp:DropDownList ID="ddlResponsable" runat="server" Enabled="false"></asp:DropDownList>          
                                <asp:Button ID="btnConsultarDisponibilidad" runat="server" Text="Consultar disponibilidad" class="btn btn-primary"
                                    OnClick="btnConsultarDisponibilidad_Click" style="margin-left: 10px;" />                        
                            </div>
                        </div>
                        <div class="control-group">
                            <label class="control-label" for="txtFechaInicio">Fecha de Inicio</label>
                            <div class="controls">
                                <asp:TextBox ID="txtFechaInicio" runat="server" type="text" class="input-medium datepicker" Enabled="false"></asp:TextBox>                              
                            </div>
                        </div>
                        <div class="control-group">
                            <label class="control-label" for="txtFechaFin">Fecha de Fin</label>
                            <div class="controls">
                                <asp:TextBox ID="txtFechaFin" runat="server" type="text" class="input-medium datepicker" Enabled="false"></asp:TextBox>         
                            </div>                                                        
                        </div>
                        <div class="control-group">
                            <asp:GridView ID="gvDetalleSolicitudActividad" runat="server"
                                CssClass="table table-striped table-bordered bootstrap-datatable datatable dataTable"                                                                                             
                                AutoGenerateColumns="False"
                                OnRowDataBound="gvDetalleSolicitudActividad_RowDataBound" OnRowCommand="gvDetalleSolicitudActividad_RowCommand">
                                <Columns>                                    
                                    <asp:BoundField DataField="Fecha" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Fecha" ItemStyle-CssClass="align-cen" HeaderStyle-Width="10%" />
                                    <asp:TemplateField HeaderText ="Hora Inicio" HeaderStyle-Width="20%"> 
                                        <ItemTemplate> 
                                            <asp:DropDownList ID="ddlHoraInicio" runat="server" class="input-mini" style="width: 60px !important;" Enabled="false"></asp:DropDownList>    
                                            <asp:DropDownList ID="ddlMinutoInicio" runat="server" class="input-mini" style="width: 60px !important;" Enabled="false"></asp:DropDownList>                                                          
                                        </ItemTemplate> 
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField> 
                                    <asp:TemplateField HeaderText ="Hora Fin" HeaderStyle-Width="20%"> 
                                        <ItemTemplate>                                             
                                            <asp:DropDownList ID="ddlHoraFin" runat="server" class="input-mini" style="width: 60px !important;" Enabled="false"></asp:DropDownList>                            
                                            <asp:DropDownList ID="ddlMinutoFin" runat="server" class="input-mini" style="width: 60px !important;" Enabled="false"></asp:DropDownList>
                                        </ItemTemplate> 
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField> 
                                    <asp:TemplateField HeaderText ="Ubicación" HeaderStyle-Width="15%"> 
                                        <ItemTemplate> 
                                            <asp:DropDownList ID="ddlUbicacion" runat="server" AutoPostBack="True" class="input-medium" Enabled="false"></asp:DropDownList>                                                                                
                                        </ItemTemplate> 
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField> 
                                    <asp:TemplateField HeaderText ="Ambiente / Dirección" HeaderStyle-Width="45%"> 
                                        <ItemTemplate> 
                                            <asp:DropDownList ID="ddlAmbiente" runat="server" class="input-xlarge" Visible="false" Enabled="false"></asp:DropDownList>
                                            <asp:TextBox ID="txtDireccion" runat="server" type="text" class="input-xlarge editable-input" Visible="false" MaxLength="100" Enabled="false"></asp:TextBox>
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
                        <div class="control-group">
                            <label class="control-label" for="txtOObservaciones">Observaciones</label>
                            <div class="controls">
                                <asp:TextBox ID="txtObservaciones" runat="server" type="text" TextMode="MultiLine" class="input-xxlarge editable-input" style="height: 150px !important;" MaxLength="100"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-actions">
                            <asp:Button ID="btnAprobar" runat="server" type="submit" Text="Aprobar" class="btn btn-primary" OnClick="btnAprobar_Click" />
                            <asp:Button ID="btnRechazar" runat="server" type="submit" Text="Rechazar" class="btn btn-primary" OnClick="btnRechazar_Click" />                          
                            <a href="../Index.aspx" class="btn btn-success">Cancelar</a>
                        </div>                      
                    </fieldset>
                </div>                 
            </div>                       
        </div>
    </div>
    <%-- Mensaje de Confirmación de Registro --%>
    <div class="modal hide fade in" id="myModalMensaje">
        <div class="modal-header">
            <button type="button" class="close" data-dismiss="modal">×</button>
            <h2><asp:Label ID="lblTituloMensaje" runat="server" Text=""></asp:Label></h2>
        </div>
        <div class="modal-body">
            <p><asp:Label ID="lblDescripcionMensaje" runat="server" Text=""></asp:Label></p>
        </div>
        <div class="modal-footer">       
            <asp:Button ID="btnConfirmarAprobar" runat="server" type="submit" Text="Sí" class="btn btn-primary" OnClick="btnConfirmarAprobar_Click" />     
            <asp:Button ID="btnConfirmarRechazar" runat="server" type="submit" Text="Sí" class="btn btn-primary" OnClick="btnConfirmarRechazar_Click" />     
            <a href="#" runat="server" id="btnAceptar" class="btn btn-success" data-dismiss="modal">Aceptar</a>
            <a href="#" runat="server" id="btnCancelar" class="btn btn-success" data-dismiss="modal">No</a>            
        </div>
    </div>

    <div class="modal hide fade in" id="myModalDisponibilidad">
        <div class="modal-header">
            <button type="button" class="close" data-dismiss="modal">×</button>
            <h2><asp:Label ID="Label1" runat="server" Text="Disponibilidad de docentes durante semana"></asp:Label></h2>
        </div>
        <div class="modal-body">
            <p><asp:Label ID="Label2" runat="server" Text=""></asp:Label></p>
            <asp:GridView ID="gvResponsables" runat="server"
                CssClass="table table-striped table-bordered bootstrap-datatable datatable dataTable"                                                                                             
                AutoGenerateColumns="False" DataKeyNames="IdEmpleado" OnSelectedIndexChanged="gvResponsables_SelectedIndexChanged"
                OnRowDataBound="gvResponsables_RowDataBound" OnRowCommand="gvResponsables_RowCommand">
                <Columns>                                                        
                    <asp:BoundField DataField="IdEmpleado" HeaderText="IdEmpleado" ItemStyle-CssClass="align-cen" Visible="false"/>
                    <asp:BoundField DataField="Nombre" HeaderText="Responsable" ItemStyle-CssClass="align-cen"/>
                    <asp:BoundField DataField="HorasAsignadas" HeaderText="Horas asignadas" ItemStyle-CssClass="align-cen"/>                                                           
                    <asp:TemplateField HeaderText="Seleccionar" ItemStyle-CssClass="align-cen">
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkSeleccionar" CommandName="Select" CssClass="btn btn-primary btn-gv" runat="server" ToolTip="Seleccionar" >
                                <i class="halflings-icon white check"></i>
                            </asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns> 
            </asp:GridView>
        </div>
        <div class="modal-footer">       
            <!--<asp:Button ID="btnAceptarResponsable" runat="server" type="submit" Text="Aceptar" class="btn btn-primary" OnClick="btnAceptarResponsable_Click" />-->
            <!--<a href="#" class="btn btn-success" data-dismiss="modal">Cancelar</a>-->
        </div>
    </div>
    <asp:HiddenField runat="server" ID="hfIdSolicitudActividad" />    
</asp:Content>
