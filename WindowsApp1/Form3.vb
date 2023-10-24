Public Class Form3

    Private Sub Form_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles Me.KeyDown
        'F1キーが押されたか調べる
        If e.KeyData = Keys.Escape Then
            Me.Visible = False
        End If
    End Sub
    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged
        Form1.hLeft = Form1.Base_hLeft
        Form1.hTop = Form1.Base_hTop
        Form1.Activate()
    End Sub
    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged
        Form1.hLeft = Form1.Base_hLeft + 960
        Form1.hTop = Form1.Base_hTop
        Form1.Activate()
    End Sub

    Private Sub RadioButton3_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton3.CheckedChanged
        Form1.hLeft = Form1.Base_hLeft + 960
        Form1.hTop = Form1.Base_hTop + 540
        Form1.Activate()
    End Sub

    Private Sub RadioButton4_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton4.CheckedChanged
        Form1.hLeft = Form1.Base_hLeft
        Form1.hTop = Form1.Base_hTop + 540
        Form1.Activate()
    End Sub

    Private Sub Exit_Click(sender As Object, e As EventArgs) Handles Exit0.Click
        Dim result As DialogResult = MessageBox.Show("Do you want to close the application?",
                                             "",
                                             MessageBoxButtons.OKCancel,
                                             MessageBoxIcon.Exclamation,
                                             MessageBoxDefaultButton.Button2)
        If result = DialogResult.OK Then
            Me.Close()
            Form1.Close()
        ElseIf result = DialogResult.Cancel Then
            Form1.Activate()
        End If
    End Sub

    Private mousePoint As Point
    Private Sub Form1_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseDown
        If (e.Button And MouseButtons.Left) = MouseButtons.Left Then
            '位置を記憶する
            mousePoint = New Point(e.X, e.Y)
        End If
    End Sub

    'マウスが動いたとき
    Private Sub Form1_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseMove
        If (e.Button And MouseButtons.Left) = MouseButtons.Left Then
            Me.Left += e.X - mousePoint.X
            Me.Top += e.Y - mousePoint.Y
        End If
        Form1.Activate()
    End Sub

    Private Sub FPS_F_Click(sender As Object, e As EventArgs) Handles FPS_F.Click
        If Form1.FPS_Timer.Enabled = True Then
            Form1.FPS_Timer.Enabled = False
            Form1.FPS_Label.Visible = False
            FPS_F.ForeColor = Color.Red
            FPS_F.Text = "FPS OFF"
        Else
            Form1.FPS_Timer.Enabled = True
            Form1.FPS_Label.Visible = True
            FPS_F.ForeColor = Color.Green
            FPS_F.Text = "FPS ON"
        End If
    End Sub

    Private Sub Setting_Click(sender As Object, e As EventArgs) Handles Setting.Click
        Form1.Task.Enabled = False
        Me.Visible = False
        Form2.Show()
    End Sub
End Class