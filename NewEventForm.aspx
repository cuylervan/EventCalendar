<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NewEventForm.aspx.cs" Inherits="EventCalendar.NewEventForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="margin-left: 150px; margin-right: 98px">
        <asp:Label ID="Label1" runat="server" Text="Add an Event to your Calendar" Font-Bold="True" Font-Size="X-Large"></asp:Label><br />
        <asp:Button ID="Button3" runat="server" Text="Return to Event Calendar" BackColor="#99CCFF" OnClick="Button3_Click" Width="228px" style="margin-left: 527px; margin-right: 4px" /><br />
        <asp:Button ID="Button1" runat="server" Text="Select Event Date" OnClick="Button1_Click" BackColor="White" Font-Italic="True" />
        <asp:TextBox ID="TextBox1" runat="server" Height="25px" BorderColor="White" BorderWidth="9px"></asp:TextBox><br /><br />
        <asp:Calendar ID="Calendar1" runat="server" OnSelectionChanged="Calendar1_SelectionChanged" Visible="False" style="margin-right: 2px" Width="760px"></asp:Calendar><br />
        <asp:Label ID="Label2" runat="server" Text="Add a Description" Font-Italic="True"></asp:Label><br />
        <asp:TextBox ID="TextBox2" runat="server" Height="61px" Width="760px" style="margin-bottom: 22px" TextMode="MultiLine"></asp:TextBox><br />
        <asp:Button ID="Button2" runat="server" Text="Save Event" OnClick="Button2_Click" />
        <asp:Label ID="Label3" runat="server" Text="" BorderColor="White" BorderWidth="10px" ForeColor="Red"></asp:Label>
    </div>
    </form>
</body>
</html>
