<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Entradas.aspx.cs" Inherits="WebApplication1.WEB.Entradas" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Gestión de Entradas</title>
    <link href="../CSS/Entradas.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <ul>
                <li><a href="Persona.aspx">Registro Personas</a></li>
                <li><a class="active" href="Entradas.aspx">Entradas</a></li>
                <li><a href="Salidas.aspx">Salidas</a></li>
                <li><a href="LogIn.aspx">Salir</a></li>
            </ul>
            <h1>Gestión de Entradas</h1>
            <br />
            <div class="form-group">
                <asp:Label ID="lblPersona" runat="server" Text="Persona" CssClass="labels"></asp:Label>
                <asp:TextBox ID="txtPersona" runat="server" CssClass="texto"></asp:TextBox>
                <asp:Label ID="lblFecha" runat="server" Text="Fecha" CssClass="labels"></asp:Label>
                <asp:TextBox ID="txtFecha" runat="server" CssClass="texto"></asp:TextBox>
            </div>
            <br />
            <div class="form-group">
                <asp:Label ID="lblHora" runat="server" Text="Hora" CssClass="labels"></asp:Label>
                <asp:TextBox ID="txtHora" runat="server" CssClass="texto"></asp:TextBox>
            </div>
            <div class="group-btn">
                <asp:Button ID="btnLimpiar" runat="server" Text="Limpiar" CssClass="guardar" OnClick="btnLimpiar_Click" />
                <asp:Button ID="btnGuardar" runat="server" Text="Guardar" OnClick="btnGuardar_Click" CssClass="guardar" />
            </div>
            <br />
            <asp:GridView ID="GridEntradas" runat="server" AutoGenerateColumns="False" CssClass="gridview-style">
                <Columns>
                    <asp:BoundField DataField="Persona" HeaderText="Persona" ReadOnly="True" SortExpression="Persona" />
                    <asp:BoundField DataField="Fecha" HeaderText="Fecha" ReadOnly="True" SortExpression="Fecha" />
                    <asp:BoundField DataField="Hora" HeaderText="Hora" ReadOnly="True" SortExpression="Hora" />
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>