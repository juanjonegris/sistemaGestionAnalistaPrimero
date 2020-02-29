<%@ Page Title="" Language="C#" MasterPageFile="~/app/Site1.Master" AutoEventWireup="true" CodeBehind="GestionTramites.aspx.cs" Inherits="UI.GestionTramites" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 107px;
        }
        .auto-style2 {
            width: 189px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Gestión de Trámites</h1>
    <p>&nbsp;</p>
    <p>
        <table style="width:100%;">
            <tr>
                <td class="auto-style1">
                    <asp:Label ID="lblNumeroTramite" runat="server" Text="Numero"></asp:Label>
                </td>
                <td class="auto-style2">
                    <asp:TextBox ID="txtNumeroTramite" runat="server"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style1">
                    <asp:Label ID="lblNombreEntidad" runat="server" Text="Entidad Pública"></asp:Label>
                </td>
                <td class="auto-style2">
                    <asp:TextBox ID="txtNombreEntidad" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:Button ID="btnBuscarTramite" runat="server" OnClick="btnBuscarTramite_Click" Text="Buscar" />
                </td>
            </tr>
            <tr>
                <td class="auto-style1">
                    <asp:Label ID="lblTramite" runat="server" Text="Trámite"></asp:Label>
                </td>
                <td class="auto-style2">
                    <asp:TextBox ID="txtNombreTramite" runat="server"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style1">
                    <asp:Label ID="Label1" runat="server" Text="Descripción"></asp:Label>
                </td>
                <td class="auto-style2">
                    <asp:TextBox ID="txtDescripcionTramite" runat="server"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style1">&nbsp;</td>
                <td class="auto-style2">
                    <asp:Button ID="btnAgregar" runat="server" Text="Agregar" OnClick="btnAgregar_Click" />
                    <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" OnClick="btnEliminar_Click" />
                    <asp:Button ID="btnModificar" runat="server" Text="Modificar" OnClick="btnModificar_Click" />
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style1">&nbsp;</td>
                <td class="auto-style2">
                    <asp:Label ID="lblMensaje" runat="server"></asp:Label>
                </td>
                <td>&nbsp;</td>
            </tr>
        </table>
    </p>
    <p>&nbsp;</p>
    <p>&nbsp;</p>
    <p>&nbsp;</p>
    <p>&nbsp;</p>
</asp:Content>
