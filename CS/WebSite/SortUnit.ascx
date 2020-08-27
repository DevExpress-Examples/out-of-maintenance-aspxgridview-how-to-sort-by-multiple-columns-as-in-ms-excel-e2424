<%@ Control Language="C#" AutoEventWireup="true" CodeFile="SortUnit.ascx.cs" Inherits="SortUnit" %>
<%@ Register Assembly="DevExpress.Web.v13.1, Version=13.1.14.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v13.1, Version=13.1.14.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>


<%@ Register Assembly="DevExpress.Web.v13.1, Version=13.1.14.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxCallback" TagPrefix="dx" %>


<%@ Register Assembly="DevExpress.Web.v13.1, Version=13.1.14.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxCallbackPanel" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v13.1, Version=13.1.14.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxPanel" TagPrefix="dx" %>


<script type="text/javascript">
    
</script>
<table style="border: solid 1px gray">
    <thead>
        <dx:ASPxLabel ID="unitHeader" runat="server">
        </dx:ASPxLabel>
    </thead>
    <tr>
        <td>
            <dx:ASPxComboBox ID="columnNames" runat="server" ClientInstanceName="clientUnitCombo" ValueType="System.String">
            </dx:ASPxComboBox>
        </td>
        <td>
            <dx:ASPxRadioButtonList ID="sortOrder" runat="server">
                <Items>
                    <dx:ListEditItem Text="Ascending" Value="A" />
                    <dx:ListEditItem Text="Descending" Value="D" />
                </Items>

            </dx:ASPxRadioButtonList>
        </td>
    </tr>
</table>




