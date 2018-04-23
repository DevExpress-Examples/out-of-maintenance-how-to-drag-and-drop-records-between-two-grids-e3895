Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Linq
Imports System.Text
Imports System.Windows.Forms
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid.Views.Grid.ViewInfo
Imports DevExpress.XtraVerticalGrid

Namespace DXSample
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
			InitializeData()
			InitializeDragDrop()
		End Sub

		Private Sub InitializeDragDrop()
			Me.vGridControl1.OptionsBehavior.Editable = False
			Me.vGridControl2.OptionsBehavior.Editable = False

			AddHandler Me.vGridControl1.MouseDown, AddressOf vGridControl_MouseDown
			AddHandler Me.vGridControl1.MouseMove, AddressOf vGridControl_MouseMove
			AddHandler Me.vGridControl1.DragOver, AddressOf vGridControl_DragOver
			AddHandler Me.vGridControl1.DragDrop, AddressOf vGridControl_DragDrop

			AddHandler Me.vGridControl2.MouseDown, AddressOf vGridControl_MouseDown
			AddHandler Me.vGridControl2.MouseMove, AddressOf vGridControl_MouseMove
			AddHandler Me.vGridControl2.DragOver, AddressOf vGridControl_DragOver
			AddHandler Me.vGridControl2.DragDrop, AddressOf vGridControl_DragDrop
		End Sub
		Private Sub InitializeData()
			Dim list1 As New List(Of DataItem)()
			list1.Add(New DataItem() With {.Id = 0, .Name = "a"})
			list1.Add(New DataItem() With {.Id = 1, .Name = "b"})
			list1.Add(New DataItem() With {.Id = 4, .Name = "e"})
			list1.Add(New DataItem() With {.Id = 5, .Name = "f"})
			list1.Add(New DataItem() With {.Id = 6, .Name = "g"})
			list1.Add(New DataItem() With {.Id = 7, .Name = "h"})
			list1.Add(New DataItem() With {.Id = 8, .Name = "i"})
			list1.Add(New DataItem() With {.Id = 9, .Name = "j"})
			Me.vGridControl1.DataSource = list1

			Dim list2 As New List(Of DataItem)()
			list2.Add(New DataItem() With {.Id = 2, .Name = "c"})
			list2.Add(New DataItem() With {.Id = 3, .Name = "d"})
			Me.vGridControl2.DataSource = list2
		End Sub

		Private Sub vGridControl_MouseMove(ByVal sender As Object, ByVal e As MouseEventArgs)
			ProcessMouseMove(TryCast(sender, VGridControl), e)
		End Sub
		Private Sub vGridControl_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs)
			ProcessMouseDown(TryCast(sender, VGridControl), e)
		End Sub
		Private Sub vGridControl_DragDrop(ByVal sender As Object, ByVal e As DragEventArgs)
			ProcessDragDrop(TryCast(sender, VGridControl), e)
		End Sub
		Private Sub vGridControl_DragOver(ByVal sender As Object, ByVal e As DragEventArgs)
			ProcessDragOver(TryCast(sender, VGridControl), e)
		End Sub

		Private captureHitInfo As VGridHitInfo = Nothing
		Private Sub ProcessMouseMove(ByVal vGrid As VGridControl, ByVal e As MouseEventArgs)
			If vGrid Is Nothing OrElse captureHitInfo Is Nothing Then
				Return
			End If
			If e.Button <> MouseButtons.Left Then
				Return
			End If
			System.Diagnostics.Debug.WriteLine(e.Location)
			Dim dragRect As New Rectangle(New Point(captureHitInfo.PtMouse.X - SystemInformation.DragSize.Width \ 2, captureHitInfo.PtMouse.Y - SystemInformation.DragSize.Height \ 2), SystemInformation.DragSize)
			If (Not dragRect.Contains(New Point(e.X, e.Y))) Then
				If captureHitInfo.HitInfoType = HitInfoTypeEnum.ValueCell Then
					vGrid.DoDragDrop(New DragInfo() With {.Grid = vGrid, .Data = vGrid.GetRecordObject(captureHitInfo.RecordIndex)}, DragDropEffects.Copy)
				End If
			End If
		End Sub
		Private Sub ProcessMouseDown(ByVal vGrid As VGridControl, ByVal e As MouseEventArgs)
			If vGrid Is Nothing Then
				Return
			End If
			captureHitInfo = vGrid.CalcHitInfo(New Point(e.X, e.Y))
		End Sub
		Private Sub ProcessDragDrop(ByVal target As VGridControl, ByVal e As DragEventArgs)
			Dim dragInfo As DragInfo = CType(e.Data.GetData(GetType(DragInfo)), DragInfo)
			Dim source As VGridControl = dragInfo.Grid
			Dim item As DataItem = CType(dragInfo.Data, DataItem)
			If item Is Nothing OrElse source Is Nothing OrElse target Is Nothing Then
				Return
			End If
			Dim dropHitInfo As VGridHitInfo = target.CalcHitInfo(target.PointToClient(New Point(e.X, e.Y)))
			Dim targetRecordIndex As Integer = GetRecordIndex(dropHitInfo)
			RemoveRecord(source, item)
			AddRecord(target, item, targetRecordIndex)
			source.RefreshDataSource()
			target.RefreshDataSource()
		End Sub

		Private Sub AddRecord(ByVal target As VGridControl, ByVal item As DataItem, ByVal targetRecordIndex As Integer)
			CType(target.DataSource, List(Of DataItem)).Insert(If(targetRecordIndex = -1, target.RecordCount, targetRecordIndex), item)
		End Sub
		Private Sub RemoveRecord(ByVal source As VGridControl, ByVal item As DataItem)
			CType(source.DataSource, List(Of DataItem)).Remove(item)
		End Sub
		Private Sub ProcessDragOver(ByVal vGrid As VGridControl, ByVal e As DragEventArgs)
			e.Effect = DragDropEffects.Copy
		End Sub
		Private Function GetRecordIndex(ByVal dropHitInfo As VGridHitInfo) As Integer
			If dropHitInfo.HitInfoType = HitInfoTypeEnum.ValueCell Then
				Return dropHitInfo.RecordIndex
			End If
			Return -1
		End Function

		Private Class DragInfo
			Private privateGrid As VGridControl
			Public Property Grid() As VGridControl
				Get
					Return privateGrid
				End Get
				Set(ByVal value As VGridControl)
					privateGrid = value
				End Set
			End Property
			Private privateData As Object
			Public Property Data() As Object
				Get
					Return privateData
				End Get
				Set(ByVal value As Object)
					privateData = value
				End Set
			End Property
		End Class
	End Class

	Public Class DataItem
		Private privateId As Integer
		Public Property Id() As Integer
			Get
				Return privateId
			End Get
			Set(ByVal value As Integer)
				privateId = value
			End Set
		End Property
		Private privateName As String
		Public Property Name() As String
			Get
				Return privateName
			End Get
			Set(ByVal value As String)
				privateName = value
			End Set
		End Property
	End Class
End Namespace
