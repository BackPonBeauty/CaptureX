Option Strict On
Imports System.Runtime.InteropServices

Public Class Form1
    Dim FPS As Integer = 0
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Task.Enabled = True
        Timer1.Enabled = True
        'Form2.Show()
    End Sub

    Private Sub Task_Tick(sender As Object, e As EventArgs) Handles Task.Tick
        If Timer1.Enabled = True Then
            FPS += 1
        End If

        Dim hWidth = Integer.Parse(nW.Text)
        Dim hHeight = Integer.Parse(nH.Text)
        Dim hTop = Integer.Parse(nT.Text)
        Dim hLeft = Integer.Parse(nL.Text)

        If PictureBox1.Image IsNot Nothing Then
            PictureBox1.Image.Dispose()
        End If
        Dim disDC As IntPtr = GetDC(IntPtr.Zero)
        'Bitmapの作成
        Dim bmp As New Bitmap(hWidth, hHeight)
        'Graphicsの作成
        Dim g As Graphics = Graphics.FromImage(bmp)
        'Graphicsのデバイスコンテキストを取得
        Dim hDC As IntPtr = g.GetHdc()
        'Bitmapに画像をコピーする
        BitBlt(hDC, 0, 0, bmp.Width, bmp.Height, disDC, hLeft, hTop, SRCCOPY)
        '解放
        g.ReleaseHdc(hDC)
        g.Dispose()
        ReleaseDC(IntPtr.Zero, disDC)
        PictureBox1.Image = bmp
    End Sub

    Const SRCCOPY As Integer = 13369376

    <DllImport("user32.dll")>
    Private Shared Function GetDC(ByVal hwnd As IntPtr) As IntPtr
    End Function

    <DllImport("gdi32.dll")>
    Private Shared Function BitBlt(ByVal hDestDC As IntPtr,
        ByVal x As Integer, ByVal y As Integer,
        ByVal nWidth As Integer, ByVal nHeight As Integer,
        ByVal hSrcDC As IntPtr,
        ByVal xSrc As Integer, ByVal ySrc As Integer,
        ByVal dwRop As Integer) As Integer
    End Function

    <DllImport("user32.dll")>
    Private Shared Function ReleaseDC(ByVal hwnd As IntPtr, ByVal hdc As IntPtr) As IntPtr

    End Function


    Public Shared Function CaptureScreen() As Bitmap
        'プライマリモニタのデバイスコンテキストを取得
        Dim disDC As IntPtr = GetDC(IntPtr.Zero)
        'Bitmapの作成
        Dim bmp As New Bitmap(960, 540)
        'Graphicsの作成
        Dim g As Graphics = Graphics.FromImage(bmp)
        'Graphicsのデバイスコンテキストを取得
        Dim hDC As IntPtr = g.GetHdc()
        'Bitmapに画像をコピーする
        BitBlt(hDC, 0, 0, bmp.Width, bmp.Height, disDC, 0, 1080, SRCCOPY)
        '解放
        g.ReleaseHdc(hDC)
        g.Dispose()
        ReleaseDC(IntPtr.Zero, disDC)
        Return bmp
    End Function


    Private Sub Form1_Close(sender As Object, e As EventArgs) Handles MyBase.Closed

    End Sub



    Private mousePoint As Point

    Private Sub Form1_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseDown, PictureBox1.MouseDown
        If (e.Button And MouseButtons.Left) = MouseButtons.Left Then
            '位置を記憶する
            mousePoint = New Point(e.X, e.Y)
        End If
    End Sub

    'マウスが動いたとき
    Private Sub Form1_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseMove, PictureBox1.MouseMove
        If (e.Button And MouseButtons.Left) = MouseButtons.Left Then
            Me.Left += e.X - mousePoint.X
            Me.Top += e.Y - mousePoint.Y
        End If
    End Sub

    Dim mode As Integer = 0

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.DoubleClick, maxbox.Click
        If mode = 2 Then
            Me.WindowState = FormWindowState.Normal
            Me.Width = 1280
            Me.Height = 760
            PictureBox1.Width = 1280
            PictureBox1.Height = 720
            PictureBox1.Top = 40
            Closeing.Left = 1248
            maxbox.Left = 1216
            Version.Left = 1136
            Try
                AppActivate("Parsec")
            Catch ex As Exception
            End Try
            mode = 0
        ElseIf mode = 1 Then
            Me.WindowState = FormWindowState.Maximized
            PictureBox1.Width = Me.Width
            PictureBox1.Height = Me.Height
            PictureBox1.Top = 0
            Try
                AppActivate("Parsec")
            Catch ex As Exception
            End Try
            mode = 2
        ElseIf mode = 0 Then
            Me.WindowState = FormWindowState.Normal
            Me.Width = 1598
            Me.Height = 938
            PictureBox1.Width = 1600
            PictureBox1.Height = 900
            PictureBox1.Top = 40
            Closeing.Left = 1568
            maxbox.Left = 1536
            Version.Left = 1456
            Try
                AppActivate("Parsec")
            Catch ex As Exception
            End Try
            mode = 1
        End If

        '    If Me.WindowState = FormWindowState.Maximized Then
        '    'Me.FormBorderStyle = FormBorderStyle.None
        '    Me.WindowState = FormWindowState.Normal
        '    Me.Width = 1280
        '    Me.Height = 760
        '    PictureBox1.Width = 1280
        '    PictureBox1.Height = 720
        '    PictureBox1.Top = 40
        '    Me.TopMost = True
        '    Try
        '        AppActivate("Parsec")
        '    Catch ex As Exception

        '    End Try
        'Else
        '    Me.WindowState = FormWindowState.Maximized
        '    PictureBox1.Width = Me.Width
        '    PictureBox1.Height = Me.Height
        '    PictureBox1.Top = 0
        '    Me.TopMost = True
        '    Try
        '        AppActivate("Parsec")
        '    Catch ex As Exception

        '    End Try
        'End If
    End Sub

    Private Sub Close_Click(sender As Object, e As EventArgs) Handles Closeing.Click
        Me.Close()
    End Sub

    Private Sub PictureBox1_Click_1(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Try
            AppActivate("Parsec")
        Catch ex As Exception

        End Try
    End Sub

    'Private Sub TextBox_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles nW.KeyPress, nH.KeyPress, nL.KeyPress, nT.KeyPress
    '    If (e.KeyChar < "0"c OrElse "9"c < e.KeyChar) AndAlso e.KeyChar <> ControlChars.Back Then
    '        e.Handled = True
    '    End If
    'End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Label6.Text = CStr(FPS)
        FPS = 0
    End Sub

    Private Sub Label6_Click(sender As Object, e As EventArgs) Handles Label6.Click
        If Timer1.Enabled = True Then
            Timer1.Enabled = False
            Label6.Text = "0"
        Else
            Timer1.Enabled = True
        End If
    End Sub
End Class
