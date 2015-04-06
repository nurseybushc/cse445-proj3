<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="ServiceTests.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        Web Service Test Page2<br />
    Enter Freebase Search here:
        <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
        <asp:Button ID="Button4" runat="server" OnClick="Button4_Click" Text="Google Freebase API Test" />
        <br />
        <br />
        Output:<br />
        <asp:TextBox ID="TextBox3" runat="server" Height="156px" TextMode="MultiLine" Width="535px"></asp:TextBox>
        <br />
        <br />
        <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" Height="16px" Width="171px">
            <asp:ListItem>Select specific item:</asp:ListItem>
        </asp:DropDownList>
        <br />
        <br />
        <asp:LinkButton ID="LinkButton1" runat="server" PostBackUrl="~/WebForm1.aspx">Go to Page 1</asp:LinkButton>
        <br />
        <br />
    </div>
    </form>
</body>
</html>
