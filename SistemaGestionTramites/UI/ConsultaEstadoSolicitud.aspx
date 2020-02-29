<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ConsultaEstadoSolicitud.aspx.cs" Inherits="UI.ConsultaEstadoSolicitud" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Consulta Estado de Solicitud</h1>
            <h2>Ingrese el numero de solicitud</h2>
        </div>
        <asp:TextBox ID="txtNumeroSolicitud" runat="server"></asp:TextBox>
        <asp:Label ID="lblEstadoSolicitud" runat="server"></asp:Label>
&nbsp;<p>
            <asp:Button ID="btnNumeroSolicitud" runat="server" OnClick="btnNumeroSolicitud_Click" Text="Buscar" />
        </p>
        <p>
            <asp:Button ID="btnLimpiar" runat="server" OnClick="btnLimpiar_Click" Text="Limpiar" />
        </p>
        <asp:Label ID="lblMensaje" runat="server"></asp:Label>
    </form>
</body>
</html>
