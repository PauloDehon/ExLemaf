<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="criaSala.aspx.cs" Inherits="ExLemaf.criaSala" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body style="height: 285px">
    <form id="form1" runat="server">
    <div>
    
    </div>
        <asp:Label ID="lblNomeSala" runat="server" Text="Nome da Sala:"></asp:Label>
        <asp:TextBox ID="txtNomeSala" runat="server"></asp:TextBox>
        <p>
            <asp:Label ID="lblLugar" runat="server" Text="Lugares disponíveis:"></asp:Label>
            <asp:TextBox ID="txtLugaresSala" runat="server"></asp:TextBox>
        </p>
        <asp:CheckBox ID="cbPC" runat="server" Text="Computador" />
        <br />
        <asp:CheckBox ID="cbTV" runat="server" Text="TV" />
        <br />
        <asp:CheckBox ID="cbWebcam" runat="server" Text="Webcam" />
        <br />
        <asp:CheckBox ID="cbWifi" runat="server" Text="Wifi" />
        <p>
            <asp:Button ID="btnCriaSala" runat="server" OnClick="btnCriaSala_Click" Text="Criar Sala" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnVerSalas" runat="server" OnClick="btnVerSalas_Click" Text="Verificar Salas" />
        </p>
        <asp:Label ID="lblMostraSalas" runat="server"></asp:Label>
    </form>
</body>
</html>
