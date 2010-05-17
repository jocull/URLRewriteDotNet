<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>URL Rewriting with .NET</title>
    <link id="MainStylesheet" type="text/css" rel="stylesheet" media="screen, tv, projection" href="/css/styles.css" runat="server" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h1>Looks like you're logged in now. I bet that was tough.</h1>
        <asp:Label ID="lblOutput" runat="server" Text="Label"></asp:Label>
        <br /><br />
        <a href="Content.aspx">This is a <strong>Local</strong> url to some content</a>
        <br />
        <a href="<%= ResolveUrl("~/Content.aspx") %>">This is an <strong>ASP.NET</strong> absolute url to the same content</a> (Issues with rewriting)
        <br />
        <a href="<%= SiteRoot %>Content.aspx">This is a <strong>SiteRoot</strong> absolute url to the same content</a> (Works in all cases)
        <br /><br />
        Well, that was fun. Maybe you should logout now.
        <br />
        <a href="<%= SiteRoot %>login/logout.aspx">Ok, I guess I'm done. Log me out.</a>
    </div>
    </form>
</body>
</html>