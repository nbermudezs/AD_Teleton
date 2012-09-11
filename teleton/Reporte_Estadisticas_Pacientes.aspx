<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Reporte_Estadisticas_Pacientes.aspx.cs" Inherits="Reporte_Estadisticas_Pacientes" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
    <head id="Head1" runat="server">
        <title>Reporte Condensado</title>

        <meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
        <link href="Styles/Teleton.css" rel="stylesheet" type="text/css" />
        
        <style type="text/css">
            .style1
            {
                width: 100%;
            }
            .style3
            {
                height: 22px;
            }
            .style5
            {
                height: 22px;
                width: 425px;
            }
            .style7
            {
                width: 425px;
            }
            .style8
            {
                width: 427px;
            }
            .style9
            {
                width: 427px;
                height: 25px;
            }
            .style10
            {
                height: 25px;
            }
            .style11
            {
                width: 427px;
                height: 20px;
            }
            .style12
            {
                height: 20px;
            }
            .style14
            {
                height: 10px;
                width: 425px;
            }
            .style15
            {
                height: 10px;
            }
        </style>
    </head>
    <body>
        <form id="form1" runat="server">
        <div id = "content">
            <div id="vertical_center">
                <div id="titulo">
                    <asp:Image ID="Image1" runat="server" ImageUrl="~/images/ImagenTeleton.jpg" 
                        Height="66px" Width="138px" /><h1>
                        Reporte de Consolidado de Pacientes</h1>                
                </div>
                <div>            
                    <fieldset>
                        <ul class="list">
                            <li class="field">
                                <table class="style1">
                                    <tr>
                                        <td class="style14">
                    
                                             <h3 style="color:Gray; width: 291px;">&nbsp;Total Pacientes:</h3>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style14">
                                            <asp:Label ID="Label21" runat="server" Text="Total Pacientes :"></asp:Label>
                                        </td>
                                        <td class="style15">
                                            <asp:Label ID="totalP" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style7">
                    
                                             <h3 style="color:Gray; width: 291px;">&nbsp;Desglose por Sexo:</h3>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style5">
                                            <asp:Label ID="Label1" runat="server" Text="Total Masculino :"></asp:Label>
                                        </td>
                                        <td class="style3">
                                            <asp:Label ID="totMasc" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style7">
                                            <asp:Label ID="Label2" runat="server" Text="Total Femenino:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="totFem" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    </table>
                            </li>
                                
                            <li class="field">
                                <table class="style1">
                                    <tr>
                                        <td class="style9">
                    
                                             <h3 style="color:Gray; width: 291px;">&nbsp;Desglose por Edades:</h3>
                                        </td>
                                        <td class="style10">
                                            </td>
                                    </tr>
                                    <tr>
                                        <td class="style8">
                                                        <asp:Label ID="Label3" runat="server" Text="Bebés (0 - 1 año) :   "></asp:Label>
                                                    </td>
                                        <td>
                                                        <asp:Label ID="totBabies" runat="server"></asp:Label>
                                                    </td>
                                    </tr>
                                    <tr>
                                        <td class="style8">
                                                        <asp:Label ID="Label4" runat="server" Text="Niños (2 - 11 años) :"></asp:Label>
                                                    </td>
                                        <td>
                                                        <asp:Label ID="totChildren" runat="server"></asp:Label>
                                                    </td>
                                    </tr>
                                    <tr>
                                        <td class="style8">
                                                        <asp:Label ID="Label5" runat="server" 
                                                Text="Adolescentes (12 - 20 años) :"></asp:Label>
                                                    </td>
                                        <td>
                                                        <asp:Label ID="totTeens" runat="server"></asp:Label>
                                                    </td>
                                    </tr>
                                    <tr>
                                        <td class="style8">
                                                        <asp:Label ID="Label6" runat="server" 
                                                Text="Adultos (21 años o más) :"></asp:Label>
                                                    </td>
                                        <td>
                                                        <asp:Label ID="totAdults" runat="server"></asp:Label>
                                                    </td>
                                    </tr>
                                    <tr>
                                        <td class="style8">
                    
                                             <h3 style="color:Gray; width: 291px;">&nbsp;Desglose por Procedencia:</h3>
                                                    </td>
                                        <td>
                                                        &nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td class="style8">
                                                        <asp:Label ID="Label7" runat="server" Text="Urbano :   "></asp:Label>
                                                    </td>
                                        <td>
                                                        <asp:Label ID="totUrban" runat="server"></asp:Label>
                                                    </td>
                                    </tr>
                                    <tr>
                                        <td class="style8">
                                                        <asp:Label ID="Label8" runat="server" Text="Rural :   "></asp:Label>
                                                    </td>
                                        <td>
                                                        <asp:Label ID="totRural" runat="server"></asp:Label>
                                                    </td>
                                    </tr>
                                    <tr>
                                        <td class="style8">
                    
                                             <h3 style="color:Gray; width: 291px;">&nbsp;Desglose por Nivel de Educación:</h3>
                                                    </td>
                                        <td>
                                                        &nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td class="style8">
                                                        <asp:Label ID="Label9" runat="server" Text="Sin Educación :   "></asp:Label>
                                                    </td>
                                        <td>
                                                        <asp:Label ID="noEdu" runat="server"></asp:Label>
                                                    </td>
                                    </tr>
                                    <tr>
                                        <td class="style8">
                                                        <asp:Label ID="Label10" runat="server" Text="Prebásica Incompleta :   "></asp:Label>
                                                    </td>
                                        <td>
                                                        <asp:Label ID="preInc" runat="server"></asp:Label>
                                                    </td>
                                    </tr>
                                    <tr>
                                        <td class="style8">
                                                        <asp:Label ID="Label11" runat="server" Text="Prebásica Completa :   "></asp:Label>
                                                    </td>
                                        <td>
                                                        <asp:Label ID="preCom" runat="server"></asp:Label>
                                                    </td>
                                    </tr>
                                    <tr>
                                        <td class="style8">
                                                        <asp:Label ID="Label22" runat="server" Text="Básica Incompleta :   "></asp:Label>
                                                    </td>
                                        <td>
                                                        <asp:Label ID="basInc" runat="server"></asp:Label>
                                                    </td>
                                    </tr>
                                    <tr>
                                        <td class="style8">
                                                        <asp:Label ID="Label23" runat="server" Text="Básica Completa :   "></asp:Label>
                                                    </td>
                                        <td>
                                                        <asp:Label ID="basCom" runat="server"></asp:Label>
                                                    </td>
                                    </tr>
                                    <tr>
                                        <td class="style8">
                                                        <asp:Label ID="Label12" runat="server" Text="Media Incompleta : "></asp:Label>
                                                    </td>
                                        <td>
                                                        <asp:Label ID="medInc" runat="server"></asp:Label>
                                                    </td>
                                    </tr>
                                    <tr>
                                        <td class="style8">
                                                        <asp:Label ID="Label13" runat="server" Text="Media Completa :  "></asp:Label>
                                                    </td>
                                        <td>
                                                        <asp:Label ID="medCom" runat="server"></asp:Label>
                                                    </td>
                                    </tr>
                                    <tr>
                                        <td class="style8">
                                                        <asp:Label ID="Label14" runat="server" Text="Superior Incompleta : "></asp:Label>
                                                    </td>
                                        <td>
                                                        <asp:Label ID="supInc" runat="server"></asp:Label>
                                                    </td>
                                    </tr>
                                    <tr>
                                        <td class="style8">
                                                        <asp:Label ID="Label15" runat="server" Text="Superior Completa :  "></asp:Label>
                                                    </td>
                                        <td>
                                                        <asp:Label ID="supCom" runat="server"></asp:Label>
                                                    </td>
                                    </tr>
                                    <tr>
                                        <td class="style8">
                                                        <asp:Label ID="Label16" runat="server" 
                                                            Text="No Corresponde (Menores de 3 años) :  "></asp:Label>
                                                    </td>
                                        <td>
                                                        <asp:Label ID="noCorresp" runat="server"></asp:Label>
                                                    </td>
                                    </tr>
                                    <tr>
                                        <td class="style8">
                                                        <asp:Label ID="Label17" runat="server" Text="Sin Instrucción :  "></asp:Label>
                                                    </td>
                                        <td>
                                                        <asp:Label ID="noInst" runat="server"></asp:Label>
                                                    </td>
                                    </tr>
                                    <tr>
                                        <td class="style8">
                    
                                             <h3 style="color:Gray; width: 291px;">Nuevos o Subyacentes:</h3>
                                                    </td>
                                        <td>
                                                        &nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td class="style8">
                                                        <asp:Label ID="Label18" runat="server" Text="Nuevos :  "></asp:Label>
                                                    </td>
                                        <td>
                                                        <asp:Label ID="nuevos" runat="server"></asp:Label>
                                                    </td>
                                    </tr>
                                    <tr>
                                        <td class="style8">
                                                        <asp:Label ID="Label19" runat="server" Text="Subyacentes :  "></asp:Label>
                                                    </td>
                                        <td>
                                                        <asp:Label ID="totSubsecuentes" runat="server"></asp:Label>
                                                    </td>
                                    </tr>
                                    <tr>
                                        <td class="style8">
                    
                                             <h3 style="color:Gray; width: 291px;">Dados de Alta:</h3>
                                                    </td>
                                        <td>
                                                        &nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td class="style8">
                                                        <asp:Label ID="Label20" runat="server" Text="Dados de Alta :  "></asp:Label>
                                                    </td>
                                        <td>
                                                        <asp:Label ID="totAlta" runat="server"></asp:Label>
                                                    </td>
                                    </tr>
                                    </table>

                            </li>
                            <li class="field">
                                <br />

                            </li>
                            
                        </ul>
                    </fieldset>
                </div>

                
            </div>
        </div>
        </form>
    </body>
</html>