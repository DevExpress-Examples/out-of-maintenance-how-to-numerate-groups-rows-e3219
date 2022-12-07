Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports DevExpress.Web
Imports System.Data

Partial Public Class _Default
	Inherits System.Web.UI.Page
	Private groupIndexes As List(Of Integer) = New List(Of Integer)()
	Private rowInGroupNumber As Integer = 1
	Private isFirstDisplayedRow As Boolean = True
	Private checkedIndex As Integer

	Private ReadOnly Property IsGridUngrouped() As Boolean
		Get
			Return groupIndexes.Count = 0
		End Get
	End Property

	Protected Sub grid_CustomColumnDisplayText(ByVal sender As Object, ByVal e As DevExpress.Web.ASPxGridViewColumnDisplayTextEventArgs)
		If e.Column.Name <> "RowNumber" Then
			Return
		End If

		Dim g As ASPxGridView = TryCast(sender, ASPxGridView)

		If IsGridUngrouped Then
			rowInGroupNumber = e.VisibleRowIndex + 1
		Else
			If isFirstDisplayedRow Then
				rowInGroupNumber = e.VisibleRowIndex - GetParentGroupIndex(e.VisibleRowIndex)
				isFirstDisplayedRow = False
			Else
				If IsRowIsFirstGroup(e.VisibleRowIndex) Then
					rowInGroupNumber = 1
				Else
					rowInGroupNumber += 1
				End If
			End If
		End If
		e.Value = rowInGroupNumber
		e.DisplayText = rowInGroupNumber.ToString()
	End Sub
	Protected Sub grid_BeforeGetCallbackResult(ByVal sender As Object, ByVal e As EventArgs)
		CollectGroupIndexes()
	End Sub

	Private Sub CollectGroupIndexes()
		groupIndexes.Clear()
		For i As Integer = 0 To grid.VisibleRowCount - 1
			If grid.IsGroupRow(i) Then
				groupIndexes.Add(i)
			End If
		Next i
	End Sub
	Private Function GetParentGroupIndex(ByVal index As Integer) As Integer
		checkedIndex = index
		Return groupIndexes.FindLast(AddressOf CompareIndexex)
	End Function
	Private Function CompareIndexex(ByVal i As Integer) As Boolean
		Return i < checkedIndex
	End Function
	Private Function IsRowIsFirstGroup(ByVal index As Integer) As Boolean
		Return grid.IsGroupRow(index - 1)
	End Function
End Class