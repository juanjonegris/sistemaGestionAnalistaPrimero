<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Logueo.aspx.cs" Inherits="UI.Logueo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Login</h1>

            <h3>Ingrese nombre de usuario (Cédula)</h3>



            <asp:TextBox ID="txtUsuario" runat="server"></asp:TextBox>



            <asp:RequiredFieldValidator ID="rfvNombreUsuario" runat="server" ControlToValidate="txtUsuario" Display="Dynamic" ErrorMessage="Ingresar Nombre de Usuario" ForeColor="#FF3399" SetFocusOnError="True">*</asp:RequiredFieldValidator>
            <asp:CompareValidator ID="fvNombreUsuario" runat="server" Operator="DataTypeCheck" ControlToValidate="txtUsuario" CultureInvariantValues="True" Display="Dynamic" ErrorMessage="Ingrese solo los números de la cédula, sin puntos ni guiones" Type="Integer"></asp:CompareValidator>
&nbsp;<h3>Ingrese contraseña</h3>
            <p>
                <asp:TextBox ID="txtContrasena" runat="server"  TextMode="Password"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvContraseña" runat="server" ControlToValidate="txtContrasena" Display="Dynamic" ErrorMessage="Ingresar Contraseña" ForeColor="#FF3399" SetFocusOnError="True">*</asp:RequiredFieldValidator>
            </p>
            <p>
                <asp:Button ID="btnIngresar" runat="server" OnClick="btnIngresar_Click" Text="Ingresar" />
            </p>
        </div>
        <asp:Label ID="lblMensaje" runat="server"></asp:Label>
    </form>
</body>
</html>
