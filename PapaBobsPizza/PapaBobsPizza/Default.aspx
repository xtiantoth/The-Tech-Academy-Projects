<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="PapaBobsPizza.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server" class="form-horizontal">
        <div class="container">
            <h1>Papa Bob's Pizza</h1>
            <h6>Pizza to Code By</h6>
            <p>&nbsp;</p>
            <div class="form-group">
                <label><strong>Size:</strong></label><br/>
                <asp:DropDownList runat="server" ID="SizeDropDownList" CssClass="form-control" autopostback="true" OnSelectedIndexChanged="SizeDropDownList_SelectedIndexChanged">
                    <asp:ListItem value="" Selected="True">Please select a size...</asp:ListItem>
                    <asp:ListItem value="Small">Small (12 inch - $12)</asp:ListItem>
                    <asp:ListItem value="Medium">Medium (14 inch - $14)</asp:ListItem>
                    <asp:ListItem value="Large">Large (16 inch - $16)</asp:ListItem>
                </asp:DropDownList>
             </div>
            <div class="form-group">
                <label><strong>Crust:</strong></label><br/>
                <asp:DropDownList runat="server" ID="CrustDropDownList" CssClass="form-control" autopostback="true" OnSelectedIndexChanged="CrustDropDownList_SelectedIndexChanged">
                    <asp:ListItem value="" Selected="True">Please select a size...</asp:ListItem>
                    <asp:ListItem value="Regular">Regular</asp:ListItem>
                    <asp:ListItem value="Thin">Thin</asp:ListItem>
                    <asp:ListItem value="Thick">Thick (+ $2)</asp:ListItem>
                </asp:DropDownList>
            </div>
            
            <div class="form-group">
                <label><asp:CheckBox runat="server" AutoPostBack="true" ID="SausageCheckBox" OnCheckedChanged="SausageCheckBox_CheckedChanged" /> Sausage (+ $2)</label><br />
                <label><asp:CheckBox runat="server" AutoPostBack="true" ID="PepperoniCheckBox" OnCheckedChanged="PepperoniCheckBox_CheckedChanged" /> Pepperoni (+ $1.50)</label><br />
                <label><asp:CheckBox runat="server" AutoPostBack="true" ID="OnionsCheckBox" OnCheckedChanged="OnionsCheckBox_CheckedChanged" /> Onions  (+ $1)</label><br />
                <label><asp:CheckBox runat="server" AutoPostBack="true" ID="GreenPeppersCheckBox" OnCheckedChanged="GreenPeppersCheckBox_CheckedChanged" /> Green Pepper  (+ $1)</label><br />
            </div>
               <div class="form-group">
                   <label><strong>Name:</strong></label><asp:TextBox runat="server" ID="NameTextBox" CssClass="form-control"></asp:TextBox>
               </div>
                <div class="form-group">
                   <label><strong>Address:</strong></label><asp:TextBox runat="server" ID="AddressTextBox" CssClass="form-control"></asp:TextBox>
               </div>
                <div class="form-group">
                   <label><strong>Zip:</strong></label><asp:TextBox runat="server" ID="ZipTextBox" CssClass="form-control"></asp:TextBox>
               </div>
                <div class="form-group">
                   <label><strong>Phone:</strong></label><asp:TextBox runat="server" ID="PhoneTextBox" CssClass="form-control"></asp:TextBox>
               </div>
                <h2>Payment:</h2>
               <div class="form-group">
                    <label><asp:RadioButton runat="server" ID="CashRadioButton" GroupName="PaymentType" Checked="true" />Cash</label><br />
                    <label><asp:RadioButton runat="server" ID="CreditRadioButton" GroupName="PaymentType" />Credit</label>
               </div>
            <asp:Button runat="server" ID="OrderButton" Text="Order" OnClick="OrderButton_Click" CssClass="btn btn-primary btn-lg"/><br />
            <h6><asp:Label runat="server" Text="" ID="WarningLabel" Visible="false" CssClass="alert-danger"></asp:Label></h6>
            <h2>Total Cost: <asp:Label runat="server" ID="resultLabel" Text="" /></h2>
            </div>
    </form>
    <script src="Scripts/jquery-3.3.1.min.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>
</body>
</html>
