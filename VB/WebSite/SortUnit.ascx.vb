' Developer Express Code Central Example:
' ASPxGridView - how to sort by multiple columns (as in MS Excel)
' 
' This sample illustrates how to sort the ASPxGridView by multiple columns using a
' custom sort popup.
' 
' You can find sample updates and versions for different programming languages here:
' http://www.devexpress.com/example=E2424

Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports DevExpress.Web

Partial Public Class SortUnit
    Inherits System.Web.UI.UserControl


    Private grid_Renamed As ASPxGridView

    Private header_Renamed As String

    Public Property Grid() As ASPxGridView

        Set(ByVal value As ASPxGridView)
            grid_Renamed = value
        End Set
        Get
            Return grid_Renamed
        End Get
    End Property


    Public Property Header() As String

        Set(ByVal value As String)
            header_Renamed = value
        End Set
        Get
            Return header_Renamed
        End Get
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)

        columnNames.ClientInstanceName = "clientColumnNames" & Me.ID
        columnNames.ClientSideEvents.Init = String.Format("function(s,e){{OnInit(s,e,'{0}');}}",columnNames.ClientInstanceName)
        columnNames.ClientSideEvents.SelectedIndexChanged = String.Format("function(s,e){{SetSortingUnit({0},{1},'{2}');}}", columnNames.ClientInstanceName, sortOrder.ClientID, columnNames.ClientInstanceName)
        sortOrder.ClientSideEvents.SelectedIndexChanged = String.Format("function(s,e){{SetSortingUnit({0},{1},'{2}');}}", columnNames.ClientInstanceName, sortOrder.ClientID,columnNames.ClientInstanceName)
        FillCombo()
        unitHeader.Text = header_Renamed


    End Sub

    Protected Sub FillCombo()
        columnNames.Items.Add("", "")
        For i As Integer = 0 To grid_Renamed.Columns.Count - 1
            If TypeOf grid_Renamed.Columns(i) Is GridViewDataColumn Then
                Dim fName As String = (TryCast(grid_Renamed.Columns(i), GridViewDataColumn)).FieldName
                columnNames.Items.Add(fName, fName)
            End If
        Next i
    End Sub


End Class
