<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ConsultaEstadoSolicitud.aspx.cs" Inherits="UI.ConsultaEstadoSolicitud" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Sistema Geston - Consulta Estado Solicitud</title>
    <link href="./app/style/styles.css" rel="stylesheet" />

</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
        <div>
            <h1>Consulta Estado de Solicitud</h1>
            <h2>Ingrese el numero de solicitud</h2>
        </div>
        <asp:TextBox ID="txtNumeroSolicitud" runat="server"></asp:TextBox>
        <asp:Label ID="lblEstadoSolicitud" runat="server"></asp:Label>
&nbsp;<asp:CompareValidator ID="fvNumeroSolicitud" runat="server" ControlToValidate="txtNumeroSolicitud" Display="Dynamic" ErrorMessage="Ingrese sólo valores numéricos" Operator="DataTypeCheck" Type="Integer" ValidationGroup="vgconestsol"></asp:CompareValidator>
            <asp:RequiredFieldValidator ID="rfvNumeroSolicitud" runat="server" ControlToValidate="txtNumeroSolicitud" ErrorMessage="Campo requerido" ForeColor="Red" ValidationGroup="vgconestsol">*</asp:RequiredFieldValidator>
            <p>
            <asp:Button ID="btnNumeroSolicitud" runat="server" OnClick="btnNumeroSolicitud_Click" Text="Buscar" ValidationGroup="vgconestsol" />
        </p>
        <p>
            <asp:Button ID="btnLimpiar" runat="server" OnClick="btnLimpiar_Click" Text="Limpiar" />
        </p>
        <asp:Label ID="lblMensaje" runat="server"></asp:Label>
        </div> <%--fin container--%>
    </form>
</body>
</html>
