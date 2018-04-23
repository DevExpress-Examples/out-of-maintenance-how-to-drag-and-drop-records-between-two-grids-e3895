Imports Microsoft.VisualBasic
Imports System
Imports DevExpress.XtraVerticalGrid
Imports DevExpress.XtraGrid
Namespace DXSample
	Partial Public Class Form1
		''' <summary>
		''' Required designer variable.
		''' </summary>
		Private components As System.ComponentModel.IContainer = Nothing

		''' <summary>
		''' Clean up any resources being used.
		''' </summary>
		''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		Protected Overrides Sub Dispose(ByVal disposing As Boolean)
			If disposing AndAlso (components IsNot Nothing) Then
				components.Dispose()
			End If
			MyBase.Dispose(disposing)
		End Sub

		#Region "Windows Form Designer generated code"

		''' <summary>
		''' Required method for Designer support - do not modify
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.vGridControl1 = New DevExpress.XtraVerticalGrid.VGridControl()
			Me.vGridControl2 = New DevExpress.XtraVerticalGrid.VGridControl()
			CType(Me.vGridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.vGridControl2, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			' 
			' vGridControl1
			' 
			Me.vGridControl1.AllowDrop = True
			Me.vGridControl1.Dock = System.Windows.Forms.DockStyle.Left
			Me.vGridControl1.Location = New System.Drawing.Point(0, 0)
			Me.vGridControl1.Name = "vGridControl1"
			Me.vGridControl1.OptionsView.MinRowAutoHeight = 30
			Me.vGridControl1.Size = New System.Drawing.Size(386, 279)
			Me.vGridControl1.TabIndex = 0
			' 
			' vGridControl2
			' 
			Me.vGridControl2.AllowDrop = True
			Me.vGridControl2.Dock = System.Windows.Forms.DockStyle.Fill
			Me.vGridControl2.Location = New System.Drawing.Point(386, 0)
			Me.vGridControl2.Name = "vGridControl2"
			Me.vGridControl2.OptionsView.MinRowAutoHeight = 30
			Me.vGridControl2.Size = New System.Drawing.Size(369, 279)
			Me.vGridControl2.TabIndex = 1
			' 
			' Form1
			' 
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.ClientSize = New System.Drawing.Size(755, 279)
			Me.Controls.Add(Me.vGridControl2)
			Me.Controls.Add(Me.vGridControl1)
			Me.Name = "Form1"
			Me.Text = "Form1"
			CType(Me.vGridControl1, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.vGridControl2, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)

		End Sub

		#End Region

		Private vGridControl1 As VGridControl
		Private vGridControl2 As VGridControl
	End Class
End Namespace

