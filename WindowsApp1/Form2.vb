Imports System.IO
Imports System.Net.WebRequestMethods
Imports System.Text
Imports System.Threading
Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Public Class Form2
    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.TopMost = True

        Dim line As String = ""
        Dim al As New ArrayList
        Using sr As StreamReader = New StreamReader(
          "config.cfg", Encoding.GetEncoding("Shift_JIS"))
            line = sr.ReadLine()
            Do Until line Is Nothing
                al.Add(line)
                line = sr.ReadLine()
            Loop
        End Using
        hW.Text = al(1).ToString
        hH.Text = al(3).ToString
        hT.Text = al(5).ToString
        hL.Text = al(7).ToString
    End Sub

    Private Sub Start_Click(sender As Object, e As EventArgs) Handles Start.Click
        If Integer.Parse(hW.Text) <= 0 Or
            Integer.Parse(hH.Text) <= 0 Or
            hW.Text = "" Or
            hH.Text = "" Or
            hT.Text = "" Or
            hL.Text = "" Then
        Else
            Form1.hWidth = Integer.Parse(hW.Text)
            Form1.hHeight = Integer.Parse(hH.Text)
            Form1.Base_hTop = Integer.Parse(hT.Text)
            Form1.Base_hLeft = Integer.Parse(hL.Text)
            Form1.hTop = Integer.Parse(hT.Text)
            Form1.hLeft = Integer.Parse(hL.Text)
            Form1.FPS_Timer.Enabled = False
            Form1.Task.Enabled = True

            Dim textFile As System.IO.StreamWriter
            textFile = New System.IO.StreamWriter("config.cfg", False, System.Text.Encoding.Default)
            textFile.WriteLine("#Width")
            textFile.WriteLine(hW.Text)
            textFile.WriteLine("#Height")
            textFile.WriteLine(hH.Text)
            textFile.WriteLine("#Top")
            textFile.WriteLine(hT.Text)
            textFile.WriteLine("#Left")
            textFile.WriteLine(hL.Text)
            textFile.Close()
            Timer1.Enabled = False
            Me.Close()
        End If
    End Sub
    Private Sub TextBox_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles hW.KeyPress, hH.KeyPress, hL.KeyPress, hT.KeyPress
        If (e.KeyChar < "0"c OrElse "9"c < e.KeyChar) AndAlso e.KeyChar <> ControlChars.Back Then
            e.Handled = True
        End If
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Me.Text = "X: " & Me.Left & " , Y: " & Me.Top
    End Sub
End Class