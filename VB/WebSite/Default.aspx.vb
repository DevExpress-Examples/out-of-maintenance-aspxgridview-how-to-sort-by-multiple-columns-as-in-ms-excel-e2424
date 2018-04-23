Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports DevExpress.Web.ASPxGridView


Partial Public Class _Default
	Inherits System.Web.UI.Page
	Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
		For i As Integer = 0 To ASPxGridView1.Columns.Count - 1
		   If TypeOf ASPxGridView1.Columns(i) Is GridViewDataColumn Then
			  Dim c As SortUnit = TryCast(LoadControl("SortUnit.ascx"), SortUnit)
			  Dim col As GridViewDataColumn = TryCast(ASPxGridView1.Columns(i), GridViewDataColumn)
			  c.ID = "unit" & col.FieldName
			  c.Grid = ASPxGridView1
			  If i = 0 Then
				  c.Header = "Sort By"
			  Else
				  c.Header = "Then By"
			  End If

			  ASPxPanel1.Controls.Add(c)
		   End If


		Next i
	End Sub
	Protected Sub ASPxGridView1_CustomCallback(ByVal sender As Object, ByVal e As ASPxGridViewCustomCallbackEventArgs)
		For i As Integer = 0 To (CType(sender, ASPxGridView)).Columns.Count - 1
			If TypeOf (CType(sender, ASPxGridView)).Columns(i) Is GridViewDataColumn Then
				Dim col As GridViewDataColumn = TryCast((CType(sender, ASPxGridView)).Columns(i), GridViewDataColumn)
				If ASPxHiddenField1.Contains(col.FieldName) Then
					Dim sortOrder As String = ASPxHiddenField1.Get(col.FieldName).ToString()
					If sortOrder = "A" Then
						col.SortAscending()
					Else
						col.SortDescending()
					End If
				End If
			End If
		Next i
	End Sub
End Class
