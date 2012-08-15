<%@ Page Language="C#"  ValidateRequest="true" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Reporte_Genero.aspx.cs" Inherits="Reporte_Genero" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <link href="Styles/Teleton.css" rel="stylesheet" type="text/css" />
</asp:Content>


<asp:Content ID="content2" ContentPlaceHolderID="MainContent" runat="server">
<div id="content">
    <div id="content3">
            <div id = "titulo">
                <h1>Reporte de pacientes por Género</h1>
            </div>
        </div>
    
    <div id="navcenter">
    
    <fieldset id="Seguimiento">
    <legend>Opciones</legend>

    <ul class="list">
    <li class="field">
    <div class="fieldIzquierdo">
        <asp:RadioButtonList ID="RadioButtonList1" runat="server" 
            onselectedindexchanged="RadioButtonList1_SelectedIndexChanged">
            <asp:ListItem Value="0" Selected="True">Masculino</asp:ListItem>
            <asp:ListItem Value="1">Femenino</asp:ListItem>
        </asp:RadioButtonList>
    <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="Ejecutar" CssClass="boton"/>
    </div>
    <div class="fieldDerecho"> 
    <asp:Label runat="server" ID="lblFechaInicio">Fecha Inicio:</asp:Label>
                            <asp:TextBox runat="server" ID="txtFechaInicio" CssClass="requerido"></asp:TextBox>
                            <asp:CalendarExtender ID="ceFechaInicio" runat="server" 
                                TargetControlID="txtFechaInicio" Format="dd/MM/yyyy"
                                PopupButtonID="imgFechaInicio">
                            </asp:CalendarExtender>
                            <img alt="icon" src="images/calendar_icon.jpg" class="calendar" id="imgFechaInicio" />
                             
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Fecha inicial requerida."
                                ValidationGroup="TodoError" ControlToValidate="txtFechaInicio" 
                                ForeColor="Red">*
                            </asp:RequiredFieldValidator>
    
        <br />
        <br />
    <asp:Label runat="server" ID="lblFechaFinal">Fecha Final:</asp:Label>
                            <asp:TextBox runat="server" ID="txtFechaFinal" CssClass="requerido"></asp:TextBox>
                            <asp:CalendarExtender ID="ceFechaFinal" runat="server" 
                                TargetControlID="txtFechaFinal" Format="dd/MM/yyyy"
                                PopupButtonID="imgFechaFinal">
                            </asp:CalendarExtender>
                            <img alt="icon" src="images/calendar_icon.jpg" class="calendar" id="imgFechaFinal" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                ControlToValidate="txtFechaFinal" ErrorMessage="Fecha final requerida" 
                                ForeColor="Red" ValidationGroup="TodoError">*</asp:RequiredFieldValidator>
    </div>
    </li>
        </ul> 
        </fieldset>

        </div>
       <div>

        <fieldset id="Resultado">
        <legend>Resultado</legend>

        
            <asp:Button ID="Button2" runat="server" onclick="Button2_Click" Text="Exportar a Excel" CssClass="boton"/>
        
        <asp:Panel runat="server" ID="gridPanel" ScrollBars="Auto" CssClass="panel">
        <asp:GridView ID="gvreportegenero" runat="server" CssClass="Grid" EmptyDataText="----Su busqueda no genero resultados intente con otra fecha.----"
                        AutoGenerateColumns="false" ShowHeaderWhenEmpty="true" >
                        
                    
                        <PagerSettings Mode="Numeric" Position="Bottom" Visible="true" />
                        <PagerStyle BackColor="ControlLight" />

                        <Columns>
                            <asp:BoundField HeaderText="Fecha" DataField="fecha" DataFormatString="{0:d}" />
                            <asp:BoundField HeaderText="Expediente" DataField="expediente" />
                            <asp:BoundField HeaderText="Clasificación Paciente" DataField="clasificacion" />
                            <asp:BoundField HeaderText="Nombre Paciente" DataField="nombres" />
                            <asp:BoundField HeaderText="Primer Apellido" DataField="primer_apellido" />
                            <asp:BoundField HeaderText="Segundo Apellido" DataField="segundo_apellido" />
                            <asp:BoundField HeaderText="Sexo" DataField="genero" />
                            <asp:BoundField HeaderText="Nombre Doc" DataField="nombreDoc" />
                            <asp:BoundField HeaderText="Primer Apellido Doc" DataField="apeDoc" />
                            <asp:BoundField HeaderText="Segundo Apellido Doc" DataField="ape2Doc" />
                            <asp:BoundField HeaderText="Condición" DataField="condicion1" />
                            <asp:BoundField HeaderText="Identidad" DataField="cedula" />
                            <asp:BoundField HeaderText="Observación" DataField="notas" />
                            <asp:BoundField HeaderText="Codigo Int. Diag." DataField="codigoInternacional" />
                            <asp:BoundField HeaderText="Diagnóstico" DataField="diagnostico1" />
                            <asp:BoundField HeaderText="Tipo De Daño" DataField="tipo" />
                            <asp:BoundField HeaderText="Procedencia" DataField="procedencia1" />
                            <asp:BoundField HeaderText="Función Y Estructura" 
                                DataField="funcion_estructura" />
                            <asp:BoundField HeaderText="Grado De Instrucción" DataField="Grado" />
                            <asp:BoundField HeaderText="Ayudas Técnicas Ind." DataField="ayuda" />
                            <asp:BoundField HeaderText="Ocupación Actual" DataField="ocupacion" />
                            <asp:BoundField HeaderText="Años Discapacidad" 
                                DataField="años_tiempo_discapacidad" />
                            <asp:BoundField HeaderText="Meses Discapacidad" 
                                DataField="meses_tiempo_discapacidad" />
                            <asp:BoundField HeaderText="Dias Discapacidad" 
                                DataField="dias_tiempo_discapacidad" />
                            <asp:BoundField HeaderText="Años T.S.T.D.L." DataField="años_TSTDL" />
                            <asp:BoundField HeaderText="Meses T.S.T.D.L." DataField="meses_TSTDL" />
                            <asp:BoundField HeaderText="Dias T.S.T.D.L." DataField="dias_TSTDL" />
                            <asp:BoundField HeaderText="Etiología" DataField="eteologia" />

                        </Columns>
                    </asp:GridView>
                    </asp:Panel>
        
        
        </fieldset>

       </div>


        
        </div>
</asp:Content>