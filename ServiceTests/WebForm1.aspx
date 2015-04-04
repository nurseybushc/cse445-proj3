<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="ServiceTests.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        #TextArea1 {
            width: 373px;
            height: 126px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
        Web Service Test Page<br />
        Enter string to be filtered here:
        <asp:TextBox ID="TextBox1" runat="server" OnTextChanged="TextBox1_TextChanged"></asp:TextBox>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="WordFilter" />
        <br />
        Enter website address here:
        <asp:TextBox ID="TextBox2" runat="server">http://</asp:TextBox>
        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="TopTenWords" />
        <br />
        Enter location here:
        <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
        <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="Google Places API Test" />
&nbsp;<hr />
        <br />
        Output:<br />
        <asp:TextBox ID="TextBox3" runat="server" Height="156px" TextMode="MultiLine" Width="413px"></asp:TextBox>
    </form>
</body>
</html>
