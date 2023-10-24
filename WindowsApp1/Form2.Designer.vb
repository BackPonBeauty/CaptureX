<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form2
    Inherits System.Windows.Forms.Form

    'フォームがコンポーネントの一覧をクリーンアップするために dispose をオーバーライドします。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows フォーム デザイナーで必要です。
    Private components As System.ComponentModel.IContainer

    'メモ: 以下のプロシージャは Windows フォーム デザイナーで必要です。
    'Windows フォーム デザイナーを使用して変更できます。  
    'コード エディターを使って変更しないでください。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.Start = New System.Windows.Forms.Label()
        Me.hW = New System.Windows.Forms.TextBox()
        Me.hH = New System.Windows.Forms.TextBox()
        Me.hT = New System.Windows.Forms.TextBox()
        Me.hL = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.SuspendLayout()
        '
        'Start
        '
        Me.Start.AutoSize = True
        Me.Start.Location = New System.Drawing.Point(48, 151)
        Me.Start.Name = "Start"
        Me.Start.Size = New System.Drawing.Size(37, 15)
        Me.Start.TabIndex = 0
        Me.Start.Text = "Start"
        '
        'hW
        '
        Me.hW.BackColor = System.Drawing.Color.Black
        Me.hW.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.hW.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.hW.ForeColor = System.Drawing.Color.LightGray
        Me.hW.Location = New System.Drawing.Point(79, 11)
        Me.hW.Name = "hW"
        Me.hW.Size = New System.Drawing.Size(45, 24)
        Me.hW.TabIndex = 1
        Me.hW.Text = "960"
        Me.hW.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'hH
        '
        Me.hH.BackColor = System.Drawing.Color.Black
        Me.hH.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.hH.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.hH.ForeColor = System.Drawing.Color.LightGray
        Me.hH.Location = New System.Drawing.Point(79, 41)
        Me.hH.Name = "hH"
        Me.hH.Size = New System.Drawing.Size(45, 24)
        Me.hH.TabIndex = 2
        Me.hH.Text = "540"
        Me.hH.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'hT
        '
        Me.hT.BackColor = System.Drawing.Color.Black
        Me.hT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.hT.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.hT.ForeColor = System.Drawing.Color.LightGray
        Me.hT.Location = New System.Drawing.Point(79, 71)
        Me.hT.Name = "hT"
        Me.hT.Size = New System.Drawing.Size(45, 24)
        Me.hT.TabIndex = 3
        Me.hT.Text = "1080"
        Me.hT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'hL
        '
        Me.hL.BackColor = System.Drawing.Color.Black
        Me.hL.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.hL.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.hL.ForeColor = System.Drawing.Color.LightGray
        Me.hL.Location = New System.Drawing.Point(79, 101)
        Me.hL.Name = "hL"
        Me.hL.Size = New System.Drawing.Size(45, 24)
        Me.hL.TabIndex = 4
        Me.hL.Text = "0"
        Me.hL.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label2.Location = New System.Drawing.Point(12, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(61, 24)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Width"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label3.Location = New System.Drawing.Point(12, 39)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(61, 24)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Height"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label4.Location = New System.Drawing.Point(12, 69)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(61, 24)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Top"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label5.Location = New System.Drawing.Point(12, 99)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(61, 24)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Left"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        '
        'Form2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(148, 179)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.hL)
        Me.Controls.Add(Me.hT)
        Me.Controls.Add(Me.hH)
        Me.Controls.Add(Me.hW)
        Me.Controls.Add(Me.Start)
        Me.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.ForeColor = System.Drawing.Color.DarkGray
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Form2"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "X:0000 , Y:0000"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Start As Label
    Friend WithEvents hW As TextBox
    Friend WithEvents hH As TextBox
    Friend WithEvents hT As TextBox
    Friend WithEvents hL As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Timer1 As Timer
End Class
