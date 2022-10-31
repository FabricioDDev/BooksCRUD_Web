<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="BooksCRUD.Views.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <!-- Filtro Buscador(x Nombre, Autor) -->
            <asp:TextBox ID="TxtSearch" runat="server"></asp:TextBox>
            <asp:Button ID="BtnSearch" OnClick="BtnSearch_Click" runat="server" Text="Search" />
            <!-- Filtro DropDown(x Categoria) -->
            <asp:DropDownList ID="DdlCategory" runat="server"></asp:DropDownList>
            <!-- Filtro DropDown(x Genero) -->
            <asp:DropDownList ID="DdlGenre" runat="server"></asp:DropDownList>
            <!-- Filtro DropDown(x Publico) -->
            <asp:DropDownList ID="DdlPublic" runat="server"></asp:DropDownList>
            <!-- Filtro DropDown(x Año) -->
            <asp:DropDownList ID="DdlYear" runat="server"></asp:DropDownList>
            <!-- btn ADD -->
            <asp:Button ID="BtnAddBook" runat="server" Text="Button" />
            <!-- GridView(con btn delete, uodate) -->
            <asp:GridView ID="GvBook" AutoGenerateColumns="false" runat="server">
                <Columns>
                    <asp:BoundField DataField="Title" HeaderText="Title" />
                    <asp:BoundField DataField="Description" HeaderText="Description" />
                    <asp:BoundField DataField="Author" HeaderText="Author" />
                    <asp:BoundField DataField="Year" HeaderText="Year" />
                    <asp:BoundField DataField="Url" HeaderText="Url" />
                    <asp:BoundField DataField="Cover" HeaderText="Cover" />
                    <asp:BoundField DataField="Category.Name"  HeaderText="Category" />
                    <asp:BoundField DataField="Genre.Name" HeaderText="Genre" />
                    <asp:BoundField DataField="Public.Name" HeaderText="Public" />
                </Columns>
            </asp:GridView>

        </div>
    </form>
</body>
</html>
