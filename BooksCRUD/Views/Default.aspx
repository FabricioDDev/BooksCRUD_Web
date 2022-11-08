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
            <asp:TextBox ID="TxtSearch" OnTextChanged="TxtSearch_TextChanged" AutoPostBack="true" runat="server"></asp:TextBox>
            <!-- Filtro Avanzado -->
                <!-- CheckBox-->
                <asp:CheckBox ID="CbxAdvancedFilter" AutoPostBack="true" OnCheckedChanged="CbxAdvancedFilter_CheckedChanged" runat="server" />
                <!--DropDownList -->
                <asp:Label ID="LblCamp"  Visible="false" runat="server" Text="Camp"></asp:Label>
                <asp:DropDownList ID="DdlCampo" AutoPostBack ="true" OnSelectedIndexChanged="DdlCampo_SelectedIndexChanged" Visible="false" runat="server"></asp:DropDownList>
                <!-- DropDownList-->
                <asp:Label ID="LblCriterion" Visible="false" runat="server" Text="Criterion"></asp:Label>
                <asp:DropDownList ID="DdlCriterion" Visible="false" runat="server"></asp:DropDownList>
                <!-- Buttons-->
                <asp:Button ID="btnApply" OnClick="btnApply_Click" Visible="false" runat="server" Text="Apply" />
                <asp:Button ID="BtnDeleteFilter" OnClick="BtnDeleteFilter_Click" Visible="false" runat="server" Text="X" />
            
            <!-- btn ADD -->
            <asp:Button ID="BtnAddBook" runat="server" Text="Add" />
            <!-- GridView(con btn delete, uodate) -->
            <asp:GridView ID="GvBook" OnSelectedIndexChanged="GvBook_SelectedIndexChanged" DataKeyNames="Id" AutoGenerateColumns="false" runat="server">
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
                    <asp:CommandField ShowSelectButton="true" />
                </Columns>
            </asp:GridView>

        </div>
    </form>
</body>
</html>
