<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CS_ASP_051_MegaChallangeWarGame_2nd_Try.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Play War!<br />
            <br />
            <asp:Button ID="playButton" runat="server" OnClick="playButton_Click" Text="Play!" />
            <br />
        </div>
        <asp:Label ID="resultLabel" runat="server"></asp:Label>
    </form>
</body>
</html>
