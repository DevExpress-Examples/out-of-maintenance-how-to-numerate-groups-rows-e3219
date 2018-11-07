<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<%@ Register Assembly="DevExpress.Web.v13.1, Version=13.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
	Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v13.1, Version=13.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
	Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<title></title>
</head>
<body>
	<form id="form1" runat="server">
	<div>
		<dx:ASPxGridView ID="grid" runat="server" AutoGenerateColumns="False" 
			DataSourceID="dsProducts" KeyFieldName="ProductID" OnCustomColumnDisplayText="grid_CustomColumnDisplayText"
			OnBeforeGetCallbackResult="grid_BeforeGetCallbackResult">
			<Columns>
				<dx:GridViewDataTextColumn Caption="#" Name="RowNumber" UnboundType="Integer" VisibleIndex="0">
				</dx:GridViewDataTextColumn>
				<dx:GridViewDataTextColumn FieldName="ProductID" ReadOnly="True" VisibleIndex="1">
					<EditFormSettings Visible="False" />
				</dx:GridViewDataTextColumn>
				<dx:GridViewDataTextColumn FieldName="ProductName" VisibleIndex="2">
				</dx:GridViewDataTextColumn>
				<dx:GridViewDataTextColumn FieldName="CategoryID" VisibleIndex="3">
				</dx:GridViewDataTextColumn>
				<dx:GridViewDataTextColumn FieldName="QuantityPerUnit" VisibleIndex="4">
				</dx:GridViewDataTextColumn>
				<dx:GridViewDataTextColumn FieldName="UnitPrice" VisibleIndex="5">
				</dx:GridViewDataTextColumn>
				<dx:GridViewDataTextColumn FieldName="UnitsInStock" VisibleIndex="6">
				</dx:GridViewDataTextColumn>
				<dx:GridViewDataTextColumn FieldName="UnitsOnOrder" VisibleIndex="7">
				</dx:GridViewDataTextColumn>
			</Columns>
			<Settings ShowGroupPanel="True" />
		</dx:ASPxGridView>
		<asp:SqlDataSource ID="dsProducts" runat="server" ConnectionString="<%$ ConnectionStrings:NorthwindConnectionString %>"
			SelectCommand="SELECT [ProductID], [ProductName], [CategoryID], [QuantityPerUnit], [UnitPrice], [UnitsInStock], [UnitsOnOrder] FROM [Alphabetical list of products]">
		</asp:SqlDataSource>
	</div>
	</form>
</body>
</html>
