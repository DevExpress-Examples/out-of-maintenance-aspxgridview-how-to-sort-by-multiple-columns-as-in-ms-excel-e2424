<%@ Page Language="vb" AutoEventWireup="true" CodeFile="Default.aspx.vb" Inherits="_Default" %>

<%@ Register Assembly="DevExpress.Web.v13.1, Version=13.1.14.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxPanel" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v13.1, Version=13.1.14.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v13.1, Version=13.1.14.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v13.1, Version=13.1.14.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxPopupControl" TagPrefix="dx" %>

<%@ Register Src="SortUnit.ascx" TagName="SortUnit" TagPrefix="uc1" %>

<%@ Register Assembly="DevExpress.Web.v13.1, Version=13.1.14.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxHiddenField" TagPrefix="dx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="PopupSortLogic.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <dx:ASPxHiddenField ID="ASPxHiddenField1" runat="server" ClientInstanceName="clientHiddenField">
        </dx:ASPxHiddenField>
        <dx:ASPxPopupControl ID="ASPxPopupControl1" runat="server"
            ClientInstanceName="popup" HeaderText="Sort">
            <ContentCollection>
                <dx:PopupControlContentControl runat="server">
                    <dx:ASPxPanel ID="ASPxPanel1" runat="server">
                        <PanelCollection>
                            <dx:PanelContent runat="server"></dx:PanelContent>
                        </PanelCollection>
                    </dx:ASPxPanel>
                    <table>
                        <tr>
                            <td>
                                <dx:ASPxButton ID="okButton" runat="server" Text="Ok" AutoPostBack="False">
                                    <ClientSideEvents Click="function(s,e){grid.PerformCallback();popup.Hide();}" />
                                </dx:ASPxButton>
                            </td>
                            <td>
                                <dx:ASPxButton ID="cancelButton" runat="server" Text="Cancel" AutoPostBack="False">
                                    <ClientSideEvents Click="function(s, e) {popup.Hide();}" />
                                </dx:ASPxButton>
                            </td>
                        </tr>
                    </table>
                </dx:PopupControlContentControl>
            </ContentCollection>
        </dx:ASPxPopupControl>

        <dx:ASPxGridView ID="ASPxGridView1" runat="server" AutoGenerateColumns="False"
            DataSourceID="AccessDataSource1" KeyFieldName="CategoryID"
            ClientInstanceName="grid" OnCustomCallback="ASPxGridView1_CustomCallback">

            <ClientSideEvents ColumnSorting="function(s, e) {
     e.cancel = !isCustomSortingProcessing;
     popup.ShowAtElementByID(s.name);

}" />

            <Columns>
                <dx:GridViewDataTextColumn FieldName="CategoryID" ReadOnly="True"
                    VisibleIndex="0" Name="CategoryID">
                    <EditFormSettings Visible="False" />
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="CategoryName" VisibleIndex="1" Name="CategoryName">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="Description" VisibleIndex="2" Name="Description">
                </dx:GridViewDataTextColumn>
            </Columns>
            <Settings ShowFooter="true" ShowFilterBar="Visible" />
        </dx:ASPxGridView>
        <asp:AccessDataSource ID="AccessDataSource1" runat="server"
            DataFile="~/App_Data/nwind.mdb" SelectCommand="SELECT * FROM [Categories]"></asp:AccessDataSource>



    </form>
</body>
</html>