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
        ASPxGridView1.ClearSort()
        For i As Integer = 0 To (DirectCast(sender, ASPxGridView).Columns.Count) - 1
            If TypeOf DirectCast(sender, ASPxGridView).Columns(i) Is GridViewDataColumn Then
                Dim col As GridViewDataColumn = TryCast(DirectCast(sender, ASPxGridView).Columns(i), GridViewDataColumn)
                If ASPxHiddenField1.Contains("clientColumnNamesunit" & col.FieldName) Then
                    Dim dict As Dictionary(Of String, Object) = TryCast(ASPxHiddenField1.Get("clientColumnNamesunit" & col.FieldName), Dictionary(Of String, Object))
                    Dim sortOrder As String = TryCast(dict("Order"), String)
                    Dim FieldName As String = TryCast(dict("FieldName"), String)

                    If sortOrder Is Nothing OrElse FieldName Is Nothing Then
                        Dim previousField As Object = Nothing
                        If dict.TryGetValue("ClearSort", previousField) Then
                            CType(DirectCast(sender, ASPxGridView).Columns(DirectCast(previousField, String)), GridViewDataColumn).UnSort()
                        End If
                        Continue For
                    End If

                    If sortOrder = "A" Then
                        CType(DirectCast(sender, ASPxGridView).Columns(FieldName), GridViewDataColumn).SortAscending()
                    Else
                        CType(DirectCast(sender, ASPxGridView).Columns(FieldName), GridViewDataColumn).SortDescending()
                    End If
                End If
            End If
        Next i
    End Sub
End Class
