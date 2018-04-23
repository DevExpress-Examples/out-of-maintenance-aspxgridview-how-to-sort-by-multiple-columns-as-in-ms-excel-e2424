<%@ Page Language="vb" AutoEventWireup="true"  CodeFile="Default.aspx.vb" Inherits="_Default" %>

<%@ register Assembly="DevExpress.Web.v10.1, Version=10.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
	Namespace="DevExpress.Web.ASPxPanel" TagPrefix="dx" %>

<%@ register Assembly="DevExpress.Web.ASPxGridView.v10.1, Version=10.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
	Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>

<%@ Register assembly="DevExpress.Web.ASPxEditors.v10.1, Version=10.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dx" %>

<%@ Register assembly="DevExpress.Web.v10.1, Version=10.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxPopupControl" tagprefix="dx" %>

<%@ Register src="SortUnit.ascx" tagname="SortUnit" tagprefix="uc1" %>

<%@ Register assembly="DevExpress.Web.v10.1, Version=10.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxHiddenField" tagprefix="dx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<title></title>
	<script type="text/javascript">
		var isCustomSortingProcessing = false;
	 </script>
</head>
<body>
	<form id="form1" runat="server">

	<dx:aspxpopupcontrol ID="ASPxPopupControl1" runat="server"  
		ClientInstanceName="popup" HeaderText="Sort">
		<ContentCollection>
<dx:PopupControlContentControl runat="server">
	<dx:aspxpanel ID="ASPxPanel1" runat="server">
		<PanelCollection>
<dx:PanelContent runat="server"></dx:PanelContent>
</PanelCollection>
	</dx:aspxpanel>
	<table>
	  <tr>
		<td>
		  <dx:aspxbutton ID="okButton" runat="server" Text="Ok" AutoPostBack="False">
		  <clientsideevents Click="function(s,e){grid.PerformCallback();popup.Hide();}" />
		  </dx:aspxbutton>
		  </td>
		  <td>
		  <dx:aspxbutton ID="cancelButton" runat="server" Text="Cancel" AutoPostBack="False">
			  <clientsideevents Click="function(s, e) {popup.Hide();}" />
		  </dx:aspxbutton>
		</td>
	  </tr>
	</table>
</dx:PopupControlContentControl>
</ContentCollection>
	</dx:aspxpopupcontrol>

	<dx:aspxgridview ID="ASPxGridView1" runat="server" AutoGenerateColumns="False" 
		DataSourceID="AccessDataSource1" KeyFieldName="CategoryID" 
		ClientInstanceName="grid" oncustomcallback="ASPxGridView1_CustomCallback">

		<clientsideevents ColumnSorting="function(s, e) {
	 e.cancel = !isCustomSortingProcessing;
	 popup.ShowAtElementByID(s.name);

}" />

		<columns>
			<dx:gridviewdatatextcolumn FieldName="CategoryID" ReadOnly="True" 
				VisibleIndex="0" Name="CategoryID">
				<editformsettings Visible="False" />
			</dx:gridviewdatatextcolumn>
			<dx:gridviewdatatextcolumn FieldName="CategoryName" VisibleIndex="1"  Name="CategoryName">
			</dx:gridviewdatatextcolumn>
			<dx:gridviewdatatextcolumn FieldName="Description" VisibleIndex="2" Name="Description">
			</dx:gridviewdatatextcolumn>
		</columns>
	</dx:aspxgridview>
	<asp:accessdatasource ID="AccessDataSource1" runat="server" 
		DataFile="~/App_Data/nwind.mdb" SelectCommand="SELECT * FROM [Categories]">
	</asp:accessdatasource>

	<dx:aspxhiddenfield ID="ASPxHiddenField1" runat="server" ClientInstanceName="clientHiddenField">
	</dx:aspxhiddenfield>

	</form>
</body>
</html>