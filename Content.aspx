<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Content.aspx.cs" Inherits="Content" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>A Content Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h1>Now that's some fresh content!</h1>
        <p>Thanks for the compliment, buddy! I thought so too!</p>
        <asp:Button ID="btnGetMeOut" runat="server" Text="Actually, I lied. It's not fresh at all. Get me out of here quick!" onclick="btnGetMeOut_Click" />
    </div>
    </form>
</body>
</html>