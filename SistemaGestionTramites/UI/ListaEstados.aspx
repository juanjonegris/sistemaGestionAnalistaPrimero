<%@ Page Title="" Language="C#" MasterPageFile="~/app/Site1.Master" AutoEventWireup="true" CodeBehind="ListaEstados.aspx.cs" Inherits="UI.ListaEstados" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   
    <h1>&nbsp;</h1>
    <h1>Lista de estados</h1>
    
    <p>
        <asp:GridView ID="grdListaEntidades" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="grdListaEntidades_SelectedIndexChanged">
            <Columns>
                <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                <asp:CommandField HeaderText="Seleccionar" ShowSelectButton="True" />
            </Columns>
        </asp:GridView>
    </p>
    <p>
        
        <asp:Label ID="lblTituloTramite" runat="server" Text="Listado de Tramites" Visible="False"></asp:Label>
    </p>
    <p>
        
        <asp:Label ID="lblErrorTramite" runat="server" Visible="False"></asp:Label>
    </p>
    <p>
        
        <asp:GridView ID="grdListaTramites" runat="server" Visible="False" AutoGenerateColumns="False" OnSelectedIndexChanged="grdListaTramites_SelectedIndexChanged">
            <Columns>
                <asp:BoundField DataField="Nombre" HeaderText="Trámites" />
                <asp:CommandField HeaderText="Seleccionar" ShowHeader="True" ShowSelectButton="True" />
            </Columns>
        </asp:GridView>
    </p>
    <p>
        
        <asp:DropDownList ID="cmbFiltro" runat="server" Visible="False">
            <asp:ListItem>Todos</asp:ListItem>
            <asp:ListItem>Ejecutadas</asp:ListItem>
            <asp:ListItem>Anuladas</asp:ListItem>
        </asp:DropDownList>
&nbsp;<asp:Button ID="btnFiltrar" runat="server" OnClick="btnFiltrar_Click" Text="Filtrar" Visible="False" />
    </p>
                    <asp:GridView ID="grdSolicitud" runat="server" AutoGenerateColumns="False">
                        <Columns>
                            <asp:BoundField DataField="Numero" HeaderText="Numero de Solicitud" />
                            <asp:BoundField DataField="tipoTramite.Nombre" HeaderText="Nombre del Trámite" />
                            <asp:BoundField DataField="FechaHora" HeaderText="Fecha y Hora" />
                            <asp:BoundField DataField="NombreSolicitante" HeaderText="Nombre del Solicitante" />
                            <asp:BoundField DataField="Estado" HeaderText="Estado" />
                        </Columns>
                    </asp:GridView>
                <p>
        
                    <asp:Label ID="lblMensaje" runat="server"></asp:Label>
    </p>
</asp:Content>
