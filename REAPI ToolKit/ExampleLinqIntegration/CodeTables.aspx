<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CodeTables.aspx.cs" Inherits="ExampleLinqIntegration.CodeTables" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" 
            DataSourceID="ObjectDataSource1" DataTextField="Name" DataValueField="Name">
        </asp:DropDownList>
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
            SelectMethod="GetCodeTables" 
            TypeName="ExampleLinqIntegration.CodeTableService.CodeTablesServiceClient"></asp:ObjectDataSource>
        
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
            DataSourceID="ObjectDataSource2" AutoGenerateColumns="False" 
            CellPadding="4" ForeColor="#333333" GridLines="None">
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <Columns>
                <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
                <asp:CheckBoxField DataField="IsActive" HeaderText="IsActive" 
                    SortExpression="IsActive" />
                <asp:BoundField DataField="CodeTablesID" HeaderText="CodeTablesID" 
                    SortExpression="CodeTablesID" />
                <asp:BoundField DataField="TableEntriesID" HeaderText="TableEntriesID" 
                    SortExpression="TableEntriesID" />
                <asp:BoundField DataField="LongDescription" HeaderText="LongDescription" 
                    SortExpression="LongDescription" />
                <asp:BoundField DataField="ShortDescription" HeaderText="ShortDescription" 
                    SortExpression="ShortDescription" />
                <asp:BoundField DataField="DateLastChanged" HeaderText="DateLastChanged" 
                    SortExpression="DateLastChanged" />
                <asp:BoundField DataField="LastChangedByID" HeaderText="LastChangedByID" 
                    SortExpression="LastChangedByID" />
            </Columns>
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <EditRowStyle BackColor="#999999" />
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        </asp:GridView>
        <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" 
            DataObjectTypeName="RaisersEdge.API.ToolKit.Web.DataContracts.BaseTableEntry" 
            SelectMethod="GetCodeTableEntriesByTableName" 
            TypeName="ExampleLinqIntegration.CodeTableService.CodeTablesServiceClient" 
            UpdateMethod="UpdateCodeTableEntry" DeleteMethod="DeleteCodeTableEntry">
            <SelectParameters>
                <asp:ControlParameter ControlID="DropDownList1" Name="tableName" 
                    PropertyName="SelectedValue" Type="String" />
            </SelectParameters>
        </asp:ObjectDataSource>
        <br />
        
    </div>
    </form>
</body>
</html>
