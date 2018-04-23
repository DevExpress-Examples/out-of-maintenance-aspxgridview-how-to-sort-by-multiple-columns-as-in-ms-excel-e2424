Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports DevExpress.Web.ASPxGridView
Imports DevExpress.Web.ASPxHiddenField

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
		sortOrder.ClientSideEvents.SelectedIndexChanged = "function(s,e){SetSortingUnit(" & columnNames.ClientInstanceName & ".GetValue(),s.GetValue());}"
		FillCombo()
		unitHeader.Text = header_Renamed


	End Sub

	Protected Sub FillCombo()

		For i As Integer = 0 To grid_Renamed.Columns.Count - 1
			If TypeOf grid_Renamed.Columns(i) Is GridViewDataColumn Then
				Dim fName As String = (TryCast(grid_Renamed.Columns(i), GridViewDataColumn)).FieldName
				columnNames.Items.Add(fName, fName)
			End If
		Next i
	End Sub


End Class
