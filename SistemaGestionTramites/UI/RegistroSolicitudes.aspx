<%@ Page Title="" Language="C#" MasterPageFile="~/app/Site1.Master" AutoEventWireup="true" CodeBehind="RegistroSolicitudes.aspx.cs" Inherits="UI.RegistroSolicitudes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 275px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>&nbsp;</h1>
    <h1>Registro de solicitudes</h1>
    <table style="width:100%;">
        <tr>
            <td class="auto-style1">
        <asp:GridView ID="grdListaTramites" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="grdListaTramites_SelectedIndexChanged">
            <Columns>
                <asp:BoundField DataField="Codigo" HeaderText="Código " />
                <asp:BoundField DataField="entidad.Nombre" HeaderText="Nombre Entidad" />
                <asp:BoundField DataField="Nombre" HeaderText="Nombre Trámite" />
                <asp:CommandField HeaderText="Seleccionar" ShowSelectButton="True" />
            </Columns>
        </asp:GridView>
            </td>
            <td>
        <asp:Label ID="lblMensaje" runat="server"></asp:Label>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style1">
                <asp:Label ID="lblNombreSolicitante" runat="server" Text="Nombre Solicitante" Visible="False"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="txtNombreSolicitante" runat="server" Visible="False"></asp:TextBox>
            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style1">
                <asp:Calendar ID="cldFechaHora" runat="server" BackColor="White" BorderColor="Black" DayNameFormat="Shortest" Font-Names="Times New Roman" Font-Size="10pt" ForeColor="Black" Height="220px" NextPrevFormat="FullMonth" OnSelectionChanged="cldFechaHora_SelectionChanged" TitleFormat="Month" Visible="False" Width="400px">
                    <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="7pt" ForeColor="#333333" Height="10pt" />
                    <DayStyle Width="14%" />
                    <NextPrevStyle Font-Size="8pt" ForeColor="White" />
                    <OtherMonthDayStyle ForeColor="#999999" />
                    <SelectedDayStyle BackColor="#CC3333" ForeColor="White" />
                    <SelectorStyle BackColor="#CCCCCC" Font-Bold="True" Font-Names="Verdana" Font-Size="8pt" ForeColor="#333333" Width="1%" />
                    <TitleStyle BackColor="Black" Font-Bold="True" Font-Size="13pt" ForeColor="White" Height="14pt" />
                    <TodayDayStyle BackColor="#CCCC99" />
                </asp:Calendar>
            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style1">
                <asp:TextBox ID="txtHora" runat="server" Visible="False" Width="20px"></asp:TextBox>
&nbsp;
                <asp:TextBox ID="txtMinuto" runat="server" Visible="False" Width="20px"></asp:TextBox>
&nbsp;
                &nbsp;<asp:Label ID="lblExplicacionHora" runat="server" Text="La franja horaria permitida es entre las 9 am y las 17 horas. Ingrese la hora, luego los minutos, dos numeros para cada uno. " Visible="False"></asp:Label>
            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style1">
                <asp:Button ID="btnAltaSolicitud" runat="server" OnClick="btnAltaSolicitud_Click" Text="Crear Solicitud" Visible="False" />
            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>
    <p>
        &nbsp;</p>
    <p>&nbsp;</p>
    <p>&nbsp;</p>
    <p>
        &nbsp;</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
</asp:Content>
