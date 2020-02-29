<%@ Page Title="" Language="C#" MasterPageFile="~/app/Site1.Master" AutoEventWireup="true" CodeBehind="GestionEntidades.aspx.cs" Inherits="UI.GestionEntidades" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style2 {
            margin-left: 200px;
        }
        .auto-style3 {
            width: 85px;
        }
        .auto-style4 {
            width: 187px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1> Gestion de Entidades</h1>
    <p> 
        &nbsp;</p>
    <p> 
&nbsp; </p>
    <table style="width:100%;">
        <tr>
            <td class="auto-style3"> 
        <asp:Label ID="lblNombre" runat="server" Text="Nombre"></asp:Label>
            </td>
            <td class="auto-style4"> 
        <asp:TextBox ID="txtNombreEntidad" runat="server"></asp:TextBox>
            </td>
            <td>
        <asp:Button ID="btnBuscar" runat="server" Text="Buscar" OnClick="btnBuscar_Click" />
            </td>
        </tr>
        <tr>
            <td class="auto-style3"> 
        <asp:Label ID="lblDireccion" runat="server" Text="Dirección"></asp:Label>
            </td>
            <td class="auto-style4"> 
        <asp:TextBox ID="txtDireccion" runat="server"></asp:TextBox>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style3">
                <asp:Label ID="Label1" runat="server" Text="Telefonos"></asp:Label>
            </td>
            <td class="auto-style4">
                <asp:ListBox ID="lbTelefonos" runat="server"></asp:ListBox>
            </td>
            <td>
                <asp:Button ID="btnEliminarTel" runat="server" OnClick="btnEliminarTel_Click" Text="Eliminar" />
            </td>
        </tr>
        <tr>
            <td class="auto-style3">&nbsp;</td>
            <td class="auto-style4">
                <asp:TextBox ID="txtTelefonos" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:Button ID="btnAltatel" runat="server" OnClick="btnAltatel_Click" Text="Alta" />
            </td>
        </tr>
        <tr>
            <td class="auto-style3">&nbsp;</td>
            <td class="auto-style4">
                <asp:Button ID="btnAgregar" runat="server" OnClick="btnAgregar_Click" Text="Agrear!" />
        <asp:Button ID="btnModificar" runat="server" Height="27px"  Text="Modificar" OnClick="btnModificar_Click" />
        <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" OnClick="btnEliminar_Click" />
            </td>
            <td>
                <asp:Button ID="btnLimpiar" runat="server" OnClick="btnLimpiar_Click" Text="Limpiar" />
            </td>
        </tr>
        <tr>
            <td class="auto-style3">&nbsp;</td>
            <td class="auto-style4">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>
    <p class="auto-style2"> 
        &nbsp;</p>
    <p> 
        &nbsp;</p>
    <p> 
        &nbsp;</p>
    <p> &nbsp;</p>
    <p> 
        <asp:Label ID="lblMensaje" runat="server"></asp:Label>
    </p>
    <p> &nbsp;</p>
    <p> &nbsp;</p>
</asp:Content>
