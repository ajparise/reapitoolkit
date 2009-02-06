<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Record.aspx.cs" Inherits="ExampleLinqIntegration.WebService" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        Constituent ID To Load: <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>&nbsp;<asp:Button ID="Button1"
            runat="server" Text="Load Constituent" onclick="Button1_Click" />
        <asp:DetailsView ID="DetailsView1" runat="server" Height="50px" Width="125px" 
            AutoGenerateRows="False" CellPadding="4" DataSourceID="ObjectDataSource1" 
            ForeColor="#333333" GridLines="None">
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <CommandRowStyle BackColor="#E2DED6" Font-Bold="True" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <FieldHeaderStyle BackColor="#E9ECF1" Font-Bold="True" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <Fields>
                <asp:BoundField DataField="ID" HeaderText="ID" SortExpression="ID" />
                <asp:BoundField DataField="ConstituentID" HeaderText="ConstituentID" 
                    SortExpression="ConstituentID" />
                <asp:BoundField DataField="FirstName" HeaderText="FirstName" 
                    SortExpression="FirstName" />
                <asp:BoundField DataField="LastName" HeaderText="LastName" 
                    SortExpression="LastName" />
                <asp:BoundField DataField="MartialStatus" HeaderText="MartialStatus" 
                    SortExpression="MartialStatus" />
                <asp:BoundField DataField="DateLastChanged" HeaderText="DateLastChanged" 
                    SortExpression="DateLastChanged" ReadOnly="true" />
                <asp:BoundField DataField="LastChangedBy" HeaderText="LastChangedBy" 
                    SortExpression="LastChangedBy" ReadOnly="true"/>
                <asp:CommandField ShowEditButton="True" />
            </Fields>
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <EditRowStyle BackColor="#999999" />
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        </asp:DetailsView>
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
            DataObjectTypeName="DataContracts.Record" SelectMethod="GetConstituent" 
            TypeName="ExampleLinqIntegration.ReAPI_WCFsvc" 
            UpdateMethod="UpdateConstituent">
            <SelectParameters>
                <asp:ControlParameter ControlID="TextBox1" Name="constituentID" 
                    PropertyName="Text" Type="String" />
            </SelectParameters>
        </asp:ObjectDataSource>
            
        <br />
            
    </div>
    </form>
</body>
</html>
