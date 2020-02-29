<%@ Page Title="" Language="C#" MasterPageFile="~/app/Site1.Master" AutoEventWireup="true" CodeBehind="CambioEstadoSolicitud.aspx.cs" Inherits="UI.CambioEstadoSolicitud" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1> &nbsp;</h1>
    <h1> Cambio de Estado de Solicitud</h1>
     
        <table style="width:100%;">
            <tr>
                <td>
                    <asp:GridView ID="grdEstadoSolicitud" runat="server" AutoGenerateColumns="False" OnRowCommand="grdEstadoSolicitud_RowCommand" >
                        <Columns>
                            <asp:BoundField DataField="Numero" HeaderText="Numero de Solicitud" />
                            <asp:BoundField DataField="tipoTramite.Nombre" HeaderText="Nombre del Trámite" />
                            <asp:BoundField DataField="FechaHora" HeaderText="Fecha y Hora" />
                            <asp:BoundField DataField="NombreSolicitante" HeaderText="Nombre del Solicitante" />
                            <asp:BoundField DataField="Estado" HeaderText="Estado" />
                            <asp:ButtonField CommandName="Ejecutada" Text="Ejecutada" />
                            <asp:ButtonField CommandName="Anulada" Text="Anulada" />
                        </Columns>
                    </asp:GridView>
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>
                    <br />
                    <asp:Label ID="lblMensaje" runat="server"></asp:Label>
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>
   
</asp:Content>
