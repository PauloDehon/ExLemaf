<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="entrada.aspx.cs" Inherits="ExLemaf.entrada" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style3 {
            height: 184px;
        }
        .auto-style6 {
            height: 184px;
            width: 389px;
        }
        .auto-style7 {
            width: 389px;
        }
        .auto-style8 {
            height: 184px;
            width: 282px;
        }
        .auto-style9 {
            width: 282px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div style="height: 739px; width: 924px">
    
        <asp:Label ID="Label1" runat="server" Text="Data Início:"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        &nbsp;<asp:Label ID="Label2" runat="server" Text="Data Fim:"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnCriaSala" runat="server" OnClick="btnCriaSala_Click" Text="Criar Sala" style="margin-top: 0px" />
    
        &nbsp;<table style="width:100%;">
            <tr>
                <td class="auto-style6"><asp:Calendar ID="calDataInicio" runat="server" BackColor="White" BorderColor="#999999" CellPadding="4" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" Height="180px" Width="200px">
            <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="7pt" />
            <NextPrevStyle VerticalAlign="Bottom" />
            <OtherMonthDayStyle ForeColor="#808080" />
            <SelectedDayStyle BackColor="#666666" Font-Bold="True" ForeColor="White" />
            <SelectorStyle BackColor="#CCCCCC" />
            <TitleStyle BackColor="#999999" BorderColor="Black" Font-Bold="True" />
            <TodayDayStyle BackColor="#CCCCCC" ForeColor="Black" />
            <WeekendDayStyle BackColor="#FFFFCC" />
        </asp:Calendar>
                </td>
                <td class="auto-style8"><asp:Calendar ID="calDataFim" runat="server" BackColor="White" BorderColor="#999999" CellPadding="4" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" Height="180px" Width="200px">
            <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="7pt" />
            <NextPrevStyle VerticalAlign="Bottom" />
            <OtherMonthDayStyle ForeColor="#808080" />
            <SelectedDayStyle BackColor="#666666" Font-Bold="True" ForeColor="White" />
            <SelectorStyle BackColor="#CCCCCC" />
            <TitleStyle BackColor="#999999" BorderColor="Black" Font-Bold="True" />
            <TodayDayStyle BackColor="#CCCCCC" ForeColor="Black" />
            <WeekendDayStyle BackColor="#FFFFCC" />
        </asp:Calendar>
                </td>
                <td class="auto-style3">
                    <asp:Label ID="Label7" runat="server" Text="Entrada de Arquivo de texto"></asp:Label>
                    <asp:FileUpload ID="fuEntrada" runat="server" Width="239px" />
                </td>
            </tr>
            <tr>
                <td class="auto-style7">
        <asp:Label ID="lblHoraInicio" runat="server" Text="Hora de Início:"></asp:Label>
        <asp:TextBox ID="txtHoraInicio" runat="server" Width="30px"></asp:TextBox>
        <asp:Label ID="Label6" runat="server" Font-Names="Aharoni" Font-Size="20pt" Text=":"></asp:Label>
        <asp:TextBox ID="txtMinInicio" runat="server" Width="30px"></asp:TextBox>
                </td>
                <td class="auto-style9">
        <asp:Label ID="Label3" runat="server" Text="Hora Fim:"></asp:Label>
        <asp:TextBox ID="txtHoraFim" runat="server" Width="30px"></asp:TextBox>
        <asp:Label ID="Label5" runat="server" Font-Names="Aharoni" Font-Size="20pt" Text=":"></asp:Label>
        <asp:TextBox ID="txtMinFim" runat="server" Width="30px"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style7">
        <asp:Label ID="Label4" runat="server" Text="Número de Pessoas:"></asp:Label>
        <asp:TextBox ID="txtNumPessoas" runat="server" Width="34px"></asp:TextBox>
                    <br />
        <asp:CheckBox ID="cbComputador" runat="server" Text="Computador" />
                    <br />
        <asp:CheckBox ID="cbTV" runat="server" Text="TV" />
                    <br />
        <asp:CheckBox ID="cbWebcam" runat="server" Text="Webcam" />
                    <br />
        <asp:CheckBox ID="cbWifi" runat="server" Text="Wifi" />
                </td>
                <td class="auto-style9">
        <asp:Label ID="lblAviso" runat="server" BorderStyle="None"></asp:Label>
                    <br />
        <asp:Button ID="btnBuscar" runat="server" OnClick="btnBuscar_Click" Text="Buscar" />
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style7">
                    <asp:Label ID="lblSugest" runat="server" Visible="False">Sugestão de Data/Hora</asp:Label>
                    <br />
                    <asp:Label ID="lblDicas" runat="server"></asp:Label>
                </td>
                <td class="auto-style9">
        <asp:Button ID="btnVerReservas" runat="server" OnClick="btnVerReservas_Click" Text="Ver reservas" />
                    <br />
        <asp:Label ID="lblReservas" runat="server"></asp:Label>
                </td>
                <td>&nbsp;</td>
            </tr>
        </table>
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <br />
        <br />
        <br />
    
    </div>
    </form>
</body>
</html>
