<%@ Page Title="" Language="C#" MasterPageFile="~/MaterPage/SiteInnovaSchool.Master" AutoEventWireup="true" CodeBehind="frmAprobarCalendarioExtracurricular.aspx.cs" Inherits="InnovaSchool.UserLayer.Interfaces.frmAprobarCalendarioExtracurricular" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
<div class="row-fluid sortable ui-sortable">
            <div class="box span12" id="divConsultaSolicitudes" runat="server">
                <div class="box-header" data-original-title="">
                    <h2><i class="halflings-icon white search"></i><span class="break"></span>Aprobación de Calendario Extracurricular <asp:Label ID="lblanio" runat="server" Text="..."></asp:Label></h2>
                    <div class="box-icon">
                        <a href="#" class="btn-minimize"><i class="halflings-icon white chevron-down"></i></a>
                    </div>
                </div>
                <div class="box-content">           
                    <div class="form-horizontal">
                        <fieldset>
                        
                            <div class="control-group">
                            <asp:GridView ID="gvListaAprobCalen" runat="server"
                                CssClass="table table-striped table-bordered bootstrap-datatable datatable dataTable"                                                                                             
                                AutoGenerateColumns="False" ShowHeaderWhenEmpty="True"
                                
                                DataKeyNames="idMes" OnRowCommand="gvListaAprobCalen_RowCommand">
                                <Columns>                                    
                                    <asp:BoundField DataField="idMes" HeaderText="idMes" Visible="false" >
                                    <HeaderStyle Width="10%" />
                                    <ItemStyle CssClass="align-cen" />
                                    </asp:BoundField>
<asp:TemplateField Visible="False"><ItemTemplate>
                                            <asp:Label id="lblidMes" runat ="server" text='<%# Eval("idMes")%>' />
                                        
</ItemTemplate>
</asp:TemplateField>
                                    <asp:TemplateField Visible="false">
                                        <ItemTemplate>
                                            <asp:Label id="lblDescripcion" runat ="server" text='<%# Eval("TotalActividades")%>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField Visible="false">
                                        <ItemTemplate>
                                            <asp:Label id="lblReptitivo" runat ="server" text='<%# Eval("ActRecreativas")%>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="Mes" HeaderText="Mes" ItemStyle-CssClass="align-cen" HeaderStyle-Width="10%" >
<HeaderStyle Width="25%"></HeaderStyle>

<ItemStyle CssClass="align-izq" HorizontalAlign="Left"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="ActCulturales" HeaderText="Act. Culturales" ItemStyle-CssClass="align-cen" HeaderStyle-Width="10%" >
<HeaderStyle Width="10%"></HeaderStyle>

<ItemStyle CssClass="align-cen"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="HorasCulturales" HeaderText="Horas Culturales" ItemStyle-CssClass="align-cen" HeaderStyle-Width="10%" >                                                                                                          
<HeaderStyle Width="10%"></HeaderStyle>

<ItemStyle CssClass="align-cen"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="ActDeportivas" HeaderText="Act. Deportivas" />
                                    <asp:BoundField DataField="HorasDeportivas" HeaderText="Horas Deportivas" />
                                    <asp:BoundField DataField="ActRecreativas" HeaderText="Act. Recreativas" />
                                    <asp:BoundField DataField="HorasRecreativas" HeaderText="Horas Recreativas" />
                                    <asp:BoundField DataField="TotalActividades" HeaderText="Total de Actividades" />
                                    <asp:BoundField DataField="TotalHoras" HeaderText="Total de Horas" />
                                    <asp:TemplateField Visible="false">
                                        <ItemTemplate>
                                            <asp:Label id="lblMotivo" runat ="server" text='<%# Eval("TotalHoras")%>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText ="Opciones" HeaderStyle-Width="15%"> 
                                        <ItemTemplate> 
                                        <asp:LinkButton ID="lbtMostrarAct" CommandName="Buscar" CssClass="btn green search" runat="server" ToolTip="Mostrar Actividad" >
                                            <i class="halflings-icon white search"></i>
                                        </asp:LinkButton>                                         
                                        </ItemTemplate> 

<HeaderStyle Width="15%"></HeaderStyle>

                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>                                                                         
                                </Columns>
                            </asp:GridView>
                        </div>  
                        <div class="form-actions">
                            
                            <input type="button" value="Abrobar Calendario" onclick="$('#myModalAprobarCal').modal('show');" id="btnaprobar" class="btn btn-primary">
                            <a href="../Index.aspx" class="btn btn-success">Cancelar</a>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        </div>  
                        </fieldset>
                    </div>
                </div>
            </div>
        </div>
            

<div class="row-fluid sortable ui-sortable">
            <div class="box span12" id="div1" runat="server">
                <div class="box-header" data-original-title="">
                    <h2><i class="halflings-icon white search"></i><span class="break"></span>Listado de Actividades</h2>
                    <div class="box-icon">
                        <a href="#" class="btn-minimize"><i class="halflings-icon white chevron-down"></i></a>
                    </div>
                </div>
                <div class="box-content">           
                    <div class="form-horizontal">
                        <fieldset>
                          
                            <div class="control-group">
                            <asp:GridView ID="gvListaActividades" runat="server"
                                CssClass="table table-striped table-bordered bootstrap-datatable datatable dataTable"                                                                                             
                                AutoGenerateColumns="False" ShowHeaderWhenEmpty="True"
                                
                                DataKeyNames="IdActividad" OnRowCommand="gvListaActividades_RowCommand">
                                <Columns>                                    
                                    <asp:BoundField DataField="IdActividad" HeaderText="IdActividad" Visible="false" >
                                    <HeaderStyle Width="10%" />
                                    <ItemStyle CssClass="align-cen" />
                                    </asp:BoundField>
<asp:TemplateField Visible="False"><ItemTemplate>
                                            <asp:Label id="lblIdActividad" runat ="server" text='<%# Eval("IdActividad")%>' />
                                        
</ItemTemplate>
</asp:TemplateField>
                                    <asp:TemplateField Visible="false">
                                        <ItemTemplate>
                                            <asp:Label id="lblDescripcion" runat ="server" text='<%# Eval("Responsable")%>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField Visible="false">
                                        <ItemTemplate>
                                            <asp:Label id="lblReptitivo" runat ="server" text='<%# Eval("FechaInicio")%>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="Nombre" HeaderText="Nombre" ItemStyle-CssClass="align-cen" HeaderStyle-Width="10%" >
<HeaderStyle Width="25%"></HeaderStyle>

<ItemStyle CssClass="align-izq" HorizontalAlign="Left"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Responsable" HeaderText="Responsable" />
                                    <asp:BoundField DataField="FechaInicio" HeaderText="Fecha Inicio" ItemStyle-CssClass="align-cen"  DataFormatString="{0:dd/MM/yyyy}" HeaderStyle-Width="10%" >
<HeaderStyle Width="10%"></HeaderStyle>

<ItemStyle CssClass="align-cen"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="FechaTermino" HeaderText="Fecha Termino" ItemStyle-CssClass="align-cen"  DataFormatString="{0:dd/MM/yyyy}" HeaderStyle-Width="10%" >                                                                                                          
<HeaderStyle Width="10%"></HeaderStyle>

<ItemStyle CssClass="align-cen"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Estado" HeaderText="Estado" />
                                    <asp:TemplateField Visible="false">
                                        <ItemTemplate>
                                            <asp:Label id="lblMotivo" runat ="server" text='<%# Eval("Responsable")%>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText ="Opciones" HeaderStyle-Width="15%"> 
                                        <ItemTemplate> 
                                        <asp:LinkButton ID="lbtMostrarDeta" CommandName="Detalle" CssClass="btn green search" runat="server" ToolTip="Editar" >
                                            <i class="halflings-icon white search"></i>
                                        </asp:LinkButton> 
                                        <asp:LinkButton ID="lbtAprobar" CommandName="Aprobar" CssClass="btn btn-primary btn-gv" runat="server" ToolTip="Eliminar">
                                            <i class="halflings-icon white edit"></i>
                                        </asp:LinkButton>
                                        <asp:LinkButton ID="lbtRechazar" CommandName="Rechazar" CssClass="btn btn-danger btn-gv" runat="server" ToolTip="Mostrar">
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

    <div class="box span12" id="divSolicitudActividades" runat="server">
            <div class="box-header" data-original-title="">
                <h2><i class="halflings-icon white edit"></i><span class="break"></span>Detalle de Actividad</h2>
                <div class="box-icon">
                    <a href="#" class="btn-minimize"><i class="halflings-icon white chevron-down"></i></a>                    
                </div>                
            </div>                        
            <div class="box-content">           
                <div class="form-horizontal">
                    <fieldset>
                        <div class="control-group">
                            <label class="control-label" for="txtNombre">Nombre de Actividad:</label>
                            <div class="controls">
                                <asp:TextBox ID="txtNombre" runat="server" type="text" class="input-xlarge editable-input"
                                 Enabled="false"></asp:TextBox>
                                
                            </div>
                        </div>

                        <div class="control-group">
                            <label class="control-label" for="txtTipo">Tipo de Actividad:</label>
                            <div class="controls">
                                <asp:TextBox ID="txtTipo" runat="server" type="text" class="input-xlarge editable-input"
                                 Enabled="false"></asp:TextBox>                                
                            </div>
                        </div>                        
                        <div class="control-group">
                            <label class="control-label" for="txtDescripcion">Descripción:</label>
                            <div class="controls">
                                <asp:TextBox ID="txtDescripcion" runat="server" type="text" TextMode="MultiLine" class="input-xlarge editable-input"
                                Enabled="false"></asp:TextBox>                               
                            </div>
                        </div>
                                
                        <div class="control-group">
                            <label class="control-label" for="txtAlcance">Alcance:</label>
                            <div class="controls">
                                <asp:TextBox ID="txtAlcance" runat="server" type="text" class="input-xlarge editable-input"
                                 Enabled="false"></asp:TextBox>                                
                            </div>
                        </div>  
                                        
                        <div class="control-group">
                            <label class="control-label" for="txtResponsable">Responsable:</label>
                            <div class="controls">
                                <asp:TextBox ID="txtResponsable" runat="server" type="text" class="input-xlarge editable-input"
                                 Enabled="false"></asp:TextBox>                                
                            </div>
                        </div>  
                        
                        <div class="control-group">
                            <label class="control-label" for="txtFechaInicio">Fecha de Inicio:</label>
                            <div class="controls">
                                <asp:TextBox ID="txtFechaInicio" runat="server" type="text" class="input-medium datepicker"
                                     BackColor="White" Enabled="false"></asp:TextBox>

                            </div>
                        </div>
                        <div class="control-group">
                            <label class="control-label" for="txtFechaFin">Fecha de Termino:</label>
                            <div class="controls">
                                <asp:TextBox ID="txtFechaFin" runat="server" type="text" class="input-medium datepicker"
                                   Enabled="false" ></asp:TextBox>
                               
                            </div>                                                        
                        </div>
                      
<asp:GridView ID="gvDetalleAct" runat="server"
                                CssClass="table table-striped table-bordered bootstrap-datatable datatable dataTable"                                                                                             
                                AutoGenerateColumns="False" ShowHeaderWhenEmpty="True"
                                
                                >
                                <Columns>                                    
                                    <asp:BoundField DataField="Fecha" HeaderText="Fecha" ItemStyle-CssClass="align-cen"  DataFormatString="{0:dd/MM/yyyy}" HeaderStyle-Width="10%" >
                                    </asp:BoundField>
                                    <asp:BoundField DataField="HoraInicial" HeaderText="H. Inicio" ItemStyle-CssClass="align-cen"  DataFormatString="{0:hh:mm tt}" HeaderStyle-Width="10%" >                                                                                                          
                                    </asp:BoundField>
                                    <asp:BoundField DataField="HoraTermino" HeaderText="H. Fin" DataFormatString="{0:hh:mm tt}" >
                                    <HeaderStyle Width="10%" />
                                    <ItemStyle CssClass="align-cen" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Direccion" HeaderText="Dirección" >
                                    <HeaderStyle Width="10%" />
                                    <ItemStyle Width="10%" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Ubicacion" HeaderText="Ubicación" ItemStyle-CssClass="align-cen" HeaderStyle-Width="10%" >
<HeaderStyle Width="10%"></HeaderStyle>

<ItemStyle CssClass="align-cen"></ItemStyle>
                                    </asp:BoundField>
                                </Columns>
                            </asp:GridView>            
                    </fieldset>
                </div>                 
            </div>                       
        </div>

    <%-- Mensaje de Confirmación de Aprobar actividad--%>
    <div class="modal hide fade in" id="myModalAprobar">
        <div class="modal-header">
            <button type="button" class="close" data-dismiss="modal">×</button>
            <h2>Aprobación de la actividad</h2>
        </div>
        <div class="modal-body">
            <p>La actividad fue aprobada.</p>
        </div>
        <div class="modal-footer">
            <a href="#" class="btn btn-success" data-dismiss="modal">Aceptar</a>
        </div>
    </div>

    <%-- Mensaje de Confirmación de Rechazar actividad--%>
    <div class="modal hide fade in" id="myModalRechazar">
        <div class="modal-header">
            <button type="button" class="close" data-dismiss="modal">×</button>
            <h2>Rechazo de la actividad</h2>
        </div>
        <div class="modal-body">
            <p>La actividad fue rechazada.</p>
        </div>
        <div class="modal-footer">
            <a href="#" class="btn btn-success" data-dismiss="modal">Aceptar</a>
        </div>
    </div>

    <%-- Mensaje de Confirmación de aprobar calendario--%>
    <div class="modal hide fade in" id="myModalAprobarCal">
        <div class="modal-header">
            <button type="button" class="close" data-dismiss="modal">×</button>
            <h2>Confirmar aprobación del calendario</h2> 
        </div>
        <div class="modal-body">
            <p>¿Está seguro de aprobar el Calendario Extracurricular?</p>
        </div>
        <div class="modal-footer">
            <asp:Button ID="btnAprobarCalen" runat="server" type="submit" Text="Si" class="btn btn-primary" OnClick="btnAprobarCalen_Click"   />
            <a href="#" class="btn btn-success" data-dismiss="modal">No</a>
        </div>
    </div>
</asp:Content>
