<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebApplication2.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1"  runat="server">
    <div>
        <h1> Login Page</h1>
        <label>Username :</label>
        <%--<INPUT type="Text" id="username" />--%>
        <asp:TextBox runat="server" id="txtUsername"></asp:TextBox>
        <label>Password:</label>
        <%--<INPUT type="Text" id="Password" />--%>
        <asp:TextBox ID="txtpassword" runat="server" TextMode="Password"></asp:TextBox>
        <%--<input type="button" id="btnsubmit" Name="Submit" value="Login" />--%>
        <asp:Button runat="server" id="btnLogin" Text="Login" OnClick="btnLogin_Click"/>
    </div>
    </form>
</body>
</html>
