<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="UI.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Gestion de Trámites Montevideo</title>
    <link href="./app/style/styles.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div>
                <h1>Sistema de Gestión de Trámites Montevideo </h1>
                <p>
                    <asp:HyperLink ID="hplLogin" runat="server" NavigateUrl="~/Logueo.aspx">Ingresar</asp:HyperLink>
                    &nbsp;&nbsp;&nbsp;
                <asp:HyperLink ID="hplEstado" runat="server" NavigateUrl="~/ConsultaEstadoSolicitud.aspx">Consultar estado de solicitud</asp:HyperLink>
                </p>

            </div>
            <div>
                <asp:Label ID="lblListaEntidades" runat="server" Text="Listado de Entidades  "></asp:Label>
                <asp:GridView ID="grdListaEntidades" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="grdListaEntidades_SelectedIndexChanged">
                    <Columns>
                        <asp:BoundField ApplyFormatInEditMode="True" DataField="Nombre" HeaderText="Entidad" />
                        <asp:CommandField SelectText="Listar" ShowSelectButton="True" />
                    </Columns>
                </asp:GridView>
                <asp:Button ID="btnLimpiarTramite" runat="server" OnClick="Button1_Click" Text="Limpiar" />
                <br />
                <asp:Label ID="lblTramite" runat="server" Text="Listado de Trámites" Visible="False"></asp:Label>
            </div>

            <div>
                <asp:GridView ID="grdListaTramites" runat="server" AutoGenerateColumns="False">
                    <Columns>
                        <asp:BoundField DataField="Nombre" HeaderText="Trámite" />
                    </Columns>
                </asp:GridView>
                <asp:Label ID="lblMensaje" runat="server"></asp:Label>
            </div>
        </div>
    </form>
</body>
</html>
