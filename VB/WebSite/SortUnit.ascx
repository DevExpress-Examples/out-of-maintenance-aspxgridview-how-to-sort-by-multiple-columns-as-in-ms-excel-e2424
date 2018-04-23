<%@ Control Language="vb" AutoEventWireup="true" CodeFile="SortUnit.ascx.vb" Inherits="SortUnit" %>
<%@ register Assembly="DevExpress.Web.ASPxGridView.v10.1, Version=10.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
	Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>
<%@ Register assembly="DevExpress.Web.ASPxEditors.v10.1, Version=10.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dx" %>


  <%@ Register assembly="DevExpress.Web.v10.1, Version=10.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxCallback" tagprefix="dx" %>


  <%@ Register assembly="DevExpress.Web.v10.1, Version=10.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxCallbackPanel" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.v10.1, Version=10.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxPanel" tagprefix="dx" %>


 <script type="text/javascript">
	 function SetSortingUnit(unitFieldName, unitSortOrder) {
		 if (clientHiddenField.Contains(unitFieldName)) {
			 clientHiddenField.Set(unitFieldName, unitSortOrder);
		 }
		 else {
			 clientHiddenField.Add(unitFieldName, unitSortOrder);
		 }
	 }
 </script>
  <table style="border:solid 1px gray">
  <thead>
	<dx:aspxlabel ID="unitHeader" runat="server">
	</dx:aspxlabel>
  </thead>
  <tr>
  <td>
  <dx:aspxcombobox ID="columnNames" runat="server" ClientInstanceName="clientUnitCombo" ValueType="System.String">
  </dx:aspxcombobox>
  </td>
  <td>
  <dx:aspxradiobuttonlist ID="sortOrder" runat="server">
	<items>
	  <dx:listedititem Text="Ascending" Value="A" />
	   <dx:listedititem Text="Descending" Value="D" />
	</items>

  </dx:aspxradiobuttonlist>
  </td>
  </tr>
  </table>