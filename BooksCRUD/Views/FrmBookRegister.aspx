<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FrmBookRegister.aspx.cs" Inherits="BooksCRUD.Views.FrmBookRegister" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:TextBox ID="TxtId" runat="server"></asp:TextBox>
            <asp:TextBox ID="TxtTitle" runat="server"></asp:TextBox>
            <asp:TextBox ID="TxtDescription" runat="server"></asp:TextBox>
            <asp:TextBox ID="TxtAuthor" runat="server"></asp:TextBox>
            <asp:TextBox ID="TxtUrl" runat="server"></asp:TextBox>
            <asp:TextBox ID="TxtCover" runat="server"></asp:TextBox>
            <asp:TextBox ID="TxtYear" runat="server"></asp:TextBox>
            <asp:DropDownList ID="DdlCategory" runat="server"></asp:DropDownList>
            <asp:DropDownList ID="DdlGenre" runat="server"></asp:DropDownList>
            <asp:DropDownList ID="DdlPublic" runat="server"></asp:DropDownList>
            <asp:Button ID="BtnFinish" OnClick="BtnFinish_Click" runat="server" Text="Finish" />
        </div>

    </form>
</body>
</html>
