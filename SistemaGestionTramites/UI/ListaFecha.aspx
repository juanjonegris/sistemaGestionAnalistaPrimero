<%@ Page Title="" Language="C#" MasterPageFile="~/app/Site1.Master" AutoEventWireup="true" CodeBehind="ListaFecha.aspx.cs" Inherits="UI.ListaFecha" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>&nbsp;</h1>
    <h1>Lista por fecha</h1>
    <p>
        <asp:Calendar ID="cldSeleccionarFecha" runat="server" BackColor="White" BorderColor="Black" DayNameFormat="Shortest" Font-Names="Times New Roman" Font-Size="10pt" ForeColor="Black" Height="220px" NextPrevFormat="FullMonth" TitleFormat="Month" Width="400px" OnSelectionChanged="cldSeleccionarFecha_SelectionChanged">
            <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="7pt" ForeColor="#333333" Height="10pt" />
            <DayStyle Width="14%" />
            <NextPrevStyle Font-Size="8pt" ForeColor="White" />
            <OtherMonthDayStyle ForeColor="#999999" />
            <SelectedDayStyle BackColor="#CC3333" ForeColor="White" />
            <SelectorStyle BackColor="#CCCCCC" Font-Bold="True" Font-Names="Verdana" Font-Size="8pt" ForeColor="#333333" Width="1%" />
            <TitleStyle BackColor="Black" Font-Bold="True" Font-Size="13pt" ForeColor="White" Height="14pt" />
            <TodayDayStyle BackColor="#CCCC99" />
        </asp:Calendar>
    </p>
    <p>&nbsp;</p>
    <p>&nbsp;</p>
                    <asp:GridView ID="grdSolicitudPorFechaYHora" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="grdSolicitudPorFechaYHora_SelectedIndexChanged">
                        <Columns>
                            <asp:BoundField DataField="Numero" HeaderText="Numero de Solicitud" />
                            <asp:BoundField DataField="tipoTramite.Nombre" HeaderText="Nombre del Trámite" />
                            <asp:BoundField DataField="FechaHora" HeaderText="Fecha y Hora" />
                            <asp:BoundField DataField="NombreSolicitante" HeaderText="Nombre del Solicitante" />
                            <asp:BoundField DataField="Estado" HeaderText="Estado" />
                            <asp:CommandField HeaderText="Seleccionar" ShowHeader="True" ShowSelectButton="True" />
                        </Columns>
                    </asp:GridView>
                <p>
                    <asp:Label ID="lblMostrarInfoSolEntYTramite" runat="server" Visible="False"></asp:Label>
    </p>
    <p>
        <asp:Label ID="lblMensaje" runat="server"></asp:Label>
    </p>
    <p>&nbsp;</p>
</asp:Content>
