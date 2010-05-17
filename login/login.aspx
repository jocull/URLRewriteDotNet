<%@ Page Language="C#" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="login_login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login now!</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h1>You're not logged in. Please login now.</h1>
        <% if(UsingOpenSite){ %>
        <h2>Whoa now! You're even on the open site. What are you, some kind of hacker?</h2>
        <% } %>
        <strong><asp:Label ID="Label1" runat="server" Text="Username"></asp:Label></strong> (any will work)
        <br />
        <asp:TextBox ID="txtUsername" runat="server" Width="200" Text="Mr./Mrs./Ms. Fancy Person"></asp:TextBox>
        <br /><br />
        <asp:Button ID="btnLogin" runat="server" Text="Login" onclick="btnLogin_Click" />
    </div>
    </form>
</body>
</html>
