<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.master" CodeFile="ParametersForm_Con.aspx.cs" Inherits="ParametersForm_Con" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <link href="Styles/Teleton.css" rel="stylesheet" type="text/css" />
    
       
    
</asp:Content>


<asp:Content runat="server" ContentPlaceHolderID="MainContent">

    <script type="text/javascript">
        function validateForm() {
        //var x = document.getElementById("MainContent_txtCedula");
        //var pattx = new RegExp("[0-9][0-9][0-9][0-9]-[0-9][0-9][0-9][0-9]-[0-9][0-9][0-9][0-9][0-9]");
        //var boolx = pattx.test(x.value);

            var w = document.getElementById("MainContent_txtInicio");

            alert(w.value);

        var patty = new RegExp("(0[1-9]|[12][0-9]|3[01])/(0[1-9]|1[012])/[1-9][0-9][0-9][0-9]");
        var booly = patty.test(y.value);

        var z = document.getElementById("MainContent_txtFinal");
        var boolz = patty.test(z.value);        

        /*if (!boolx) {
        alert("Numero de cedula invalido");
        }*/

        if (!booly) {
            alert("Fecha de Inicio Válida");
        }

        if (!boolz) {
            alert("Fecha de Final Inválida");
        }
        
        return booly && boolz;
    }
    </script> 

        <div class="navcenter">
            <fieldset>
                <legend>Rango de Fechas</legend>

                <div class="centrar">
                    <ul class = "list">
                        <li class="field">
                            <asp:Label ID="Label1" CssClass="label" runat="server" Text="Fecha Inicial:"></asp:Label>
                            &nbsp;<asp:TextBox runat="server" ID="txtFechaInicio" CssClass="requerido"></asp:TextBox>
                            <asp:CalendarExtender ID="ceFechaInicio" runat="server" 
                                TargetControlID="txtFechaInicio" Format="dd/MM/yyyy"
                                PopupButtonID="imgFechaInicio">
                            </asp:CalendarExtender>
                            <img alt="icon" src="images/calendar_icon.jpg" class="calendar" id="imgFechaInicio" /><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                ErrorMessage="*Fecha Inicio Requerida" ForeColor="Red" 
                                ControlToValidate="txtFechaInicio" ValidationGroup="TodoError"></asp:RequiredFieldValidator>

                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" ValidationGroup="TodoError"
                                runat="server" ControlToValidate="txtFechaInicio" ForeColor="Red" ErrorMessage="*Formato valido es dd-MM-yyyy"
                                ValidationExpression="(0[1-9]|[12][0-9]|3[01])/(0[1-9]|1[012])/[1-9][0-9][0-9][0-9]"
                                />

                            
                        </li>
                        <li class="field">
                            <asp:Label ID="Label10" CssClass="label" runat="server" Text="Fecha Final:"></asp:Label>
                            <asp:TextBox runat="server" ID="txtFechaInicio0" CssClass="requerido"></asp:TextBox>
                            <asp:CalendarExtender ID="txtFechaInicio0_CalendarExtender" runat="server" 
                                TargetControlID="txtFechaInicio0" Format="dd/MM/yyyy"
                                PopupButtonID="imgFechaInicio0">
                            </asp:CalendarExtender>
                            <img alt="icon" src="images/calendar_icon.jpg" class="calendar" 
                                id="imgFechaInicio0" />
                             
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" 
                                ErrorMessage="*Fecha Final Requerida" ForeColor="Red" 
                                ControlToValidate="txtFechaInicio0" ValidationGroup="TodoError"></asp:RequiredFieldValidator>

                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ValidationGroup="TodoError"
                                runat="server" ControlToValidate="txtFechaInicio0" ForeColor="Red" ErrorMessage="*Formato valido es dd-MM-yyyy"
                                ValidationExpression="(0[1-9]|[12][0-9]|3[01])/(0[1-9]|1[012])/[1-9][0-9][0-9][0-9]"
                                />

                            
                        </li>
                    </ul>
                </div>
                <div id="navBotones">
                    <asp:Button ID="btnGenerar" runat="server" CssClass="boton" Text="Buscar" OnClientClick="return validateForm();" 
                        onclick="btnGenerar_Click" CausesValidation="False" />                    
                    <asp:Button ID="btnCleanPage" runat="server" CssClass="boton" Text="Limpiar" 
                        onclick="btnCleanPage_Click" CausesValidation="False" Enabled="true" 
                        Visible="true" />
                </div>
            </fieldset>
        </div>
</asp:Content>