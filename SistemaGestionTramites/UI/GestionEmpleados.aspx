<%@ Page Title="" Language="C#" MasterPageFile="~/app/Site1.Master" AutoEventWireup="true" CodeBehind="GestionEmpleados.aspx.cs" Inherits="UI.GestionEmpleados" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 37%;
            height: 147px;
        }
        .auto-style2 {
            width: 216px;
        }
        .auto-style3 {
            width: 97px;
        }
        .auto-style4 {
            margin-bottom: 0px;
        }
        .auto-style5 {
            margin-left: 9px;
        }
        .auto-style6 {
            height: 39px;
        }
        .auto-style7 {
            width: 216px;
            height: 39px;
        }
        .auto-style8 {
            width: 97px;
            height: 39px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>&nbsp;</h1>
    <h1>Gestión de Empleados</h1>
        <table class="auto-style1">
            <tr>
                <td>Cedula</td>
                <td class="auto-style2">
                    <asp:TextBox ID="txtCedula" runat="server" Width="190px"></asp:TextBox>
                </td>
                <td class="auto-style3">&nbsp;</td>
            </tr>
            <tr>
                <td>Nombre</td>
                <td class="auto-style2">
                    <asp:TextBox ID="txtNombre" runat="server" Width="195px"></asp:TextBox>
                </td>
                <td class="auto-style3">&nbsp;</td>
            </tr>
            <tr>
                <td>Contrasena</td>
                <td class="auto-style2">
                    <asp:TextBox ID="txtContrasena" runat="server" Width="191px"></asp:TextBox>
                </td>
                <td class="auto-style3">
                    <asp:Button ID="btnBuscarEmpleado" runat="server" CssClass="auto-style5" Height="28px" Text="Buscar" Width="83px" OnClick="btnBuscarEmpleado_Click1" />
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style3">&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td class="auto-style2">
                    <asp:Button ID="btnAgregar" runat="server" Text="Agregar" OnClick="btnAgregar_Click" />
                    <asp:Button ID="btnModificar" runat="server" Text="Modificar" OnClick="btnModificar_Click" />
                    <asp:Button ID="btnEliminar" runat="server" CssClass="auto-style4" Text="Eliminar" OnClick="btnEliminar_Click" />
                </td>
                <td class="auto-style3">
                    <asp:Button ID="btnLimpiar" runat="server" OnClick="btnLimpiar_Click" Text="Limpiar" />
                </td>
            </tr>
            <tr>
                <td class="auto-style6"></td>
                <td class="auto-style7"></td>
                <td class="auto-style8">
                    <asp:Label ID="lblMensaje" runat="server" ForeColor="Black" Text="[lblMensaje]"></asp:Label>
                </td>
            </tr>
        </table>
    
    <p>&nbsp;</p>
</asp:Content>
