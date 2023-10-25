Imports System.IO
Imports System.Net.WebRequestMethods
Imports System.Text
Imports System.Threading
Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Public Class Form2
    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.TopMost = True
        Me.TransparencyKey = Color.Green
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
        Me.Top = Integer.Parse(hT.Text)
        Me.Left = Integer.Parse(hL.Text)
        Me.Width = Integer.Parse(hW.Text)
        Me.Height = Integer.Parse(hH.Text)
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
        If Me.Top < 32 And Me.Top > -32 Then
            Me.Top = 0
        End If
        If Me.Left < 32 And Me.Left > -32 Then
            Me.Left = 0
        End If
        If Me.Top < 1112 And Me.Top > 1048 Then
            Me.Top = 1080
        End If
        If Me.Left < 1952 And Me.Left > 1888 Then
            Me.Left = 1920
        End If
        If Me.Top < -1112 And Me.Top > -1048 Then
            Me.Top = -1080
        End If
        If Me.Left < -1888 And Me.Left > -1952 Then
            Me.Left = -1920
        End If
        If Me.Left < -2528 And Me.Left > -2592 Then
            Me.Left = -2560
        End If


        hT.Text = Me.Top
        hL.Text = Me.Left
        hW.Text = Me.Width
        hH.Text = Me.Height
        If Me.Height < 200 Or Me.Width < 200 Then
            Me.Height = 200
            Me.Width = 200
        End If

        PictureBox1.Width = Me.Width - 7
        PictureBox1.Height = Me.Height - 7

        Dim canvas As New Bitmap(PictureBox1.Width - 7, PictureBox1.Height - 7)
        Dim g As Graphics = Graphics.FromImage(canvas)
        g.FillRectangle(Brushes.Green, 3, 3, Me.Width - 7, Me.Height - 7)
        g.Dispose()
        PictureBox1.Image = canvas

    End Sub
    Private Const WS_EX_TOOLWINDOW As Integer = &H80
    Private Const WS_EX_CLIENTEDGE As Integer = &H200
    Private Const WS_EX_WINDOWEDGE As Integer = &H100
    Protected Overrides ReadOnly Property CreateParams() As CreateParams
        Get
            Dim cp As CreateParams = MyBase.CreateParams
            cp.ExStyle = cp.ExStyle Or WS_EX_TOOLWINDOW
            Return cp
        End Get
    End Property

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Text = String.Empty
        Me.ControlBox = False
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        Me.ShowInTaskbar = False
    End Sub

    Private mousePoint As Point

    Private Sub Form1_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Marker.MouseDown
        If (e.Button And MouseButtons.Left) = MouseButtons.Left Then
            '位置を記憶する
            mousePoint = New Point(e.X, e.Y)
        End If
    End Sub

    'マウスが動いたとき
    Private Sub Form1_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Marker.MouseMove
        If (e.Button And MouseButtons.Left) = MouseButtons.Left Then
            Me.Left += e.X - mousePoint.X
            Me.Top += e.Y - mousePoint.Y
        End If
    End Sub

#Region "フォームサイズ変更関連"
    ''www.atmarkit.co.jp/bbs/phpBB/viewtopic.php?topic=38887&forum=7&start=8

    Private Const WM_NCHITTEST As Integer = &H84
    Private Const HTERROR = (-2)
    Private Const HTTRANSPARENT = (-1)
    Private Const HTNOWHERE = 0
    Private Const HTCLIENT = 1
    Private Const HTCAPTION = 2
    Private Const HTSYSMENU = 3
    Private Const HTGROWBOX = 4
    Private Const HTSIZE = HTGROWBOX
    Private Const HTMENU = 5
    Private Const HTHSCROLL = 6
    Private Const HTVSCROLL = 7
    Private Const HTMINBUTTON = 8
    Private Const HTMAXBUTTON = 9
    Private Const HTLEFT = 10
    Private Const HTRIGHT = 11
    Private Const HTTOP = 12
    Private Const HTTOPLEFT = 13
    Private Const HTTOPRIGHT = 14
    Private Const HTBOTTOM = 15
    Private Const HTBOTTOMLEFT = 16
    Private Const HTBOTTOMRIGHT = 17
    Private Const HTBORDER = 18
    Private Const HTREDUCE = HTMINBUTTON
    Private Const HTZOOM = HTMAXBUTTON
    Private Const HTSIZEFIRST = HTLEFT
    Private Const HTSIZELAST = HTBOTTOMRIGHT

    Protected Overrides Sub WndProc(ByRef m As System.Windows.Forms.Message)
        Select Case m.Msg
            Case WM_NCHITTEST
                Dim p As Point
                p = Me.PointToClient(New Point(m.LParam.ToInt32 Mod 65536, m.LParam.ToInt32 \ 65536))

                If p.X > Me.ClientRectangle.Right Then Exit Select
                If p.X < Me.ClientRectangle.Left Then Exit Select
                If p.Y < Me.ClientRectangle.Top Then Exit Select
                If p.Y > Me.ClientRectangle.Bottom Then Exit Select

                If p.X < Me.ClientRectangle.Left + 5 Then
                    If p.Y < Me.ClientRectangle.Top + 5 Then
                        m.Result = HTTOPLEFT
                        Exit Sub
                    End If
                    If p.Y > Me.ClientRectangle.Bottom - 5 Then
                        m.Result = HTBOTTOMLEFT
                        Exit Sub
                    End If
                    m.Result = HTLEFT
                    Exit Sub
                End If
                If p.X > Me.ClientRectangle.Right - 5 Then
                    If p.Y < Me.ClientRectangle.Top + 5 Then
                        m.Result = HTTOPRIGHT
                        Exit Sub
                    End If
                    If p.Y > Me.ClientRectangle.Bottom - 5 Then
                        m.Result = HTBOTTOMRIGHT
                        Exit Sub
                    End If
                    m.Result = HTRIGHT
                    Exit Sub
                End If
                If p.Y < Me.ClientRectangle.Top + 5 Then
                    m.Result = HTTOP
                    Exit Sub
                End If
                If p.Y > Me.ClientRectangle.Bottom - 5 Then
                    m.Result = HTBOTTOM
                    Exit Sub
                End If
        End Select
        MyBase.WndProc(m)
    End Sub

#End Region

End Class