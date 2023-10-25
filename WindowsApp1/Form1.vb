Option Strict On
Imports System.Runtime.InteropServices

Public Class Form1
    Dim FPS As Integer = 0
    Public hWidth As Integer
    Public hHeight As Integer
    Public hTop As Integer
    Public hLeft As Integer
    Public Base_hTop As Integer
    Public Base_hLeft As Integer
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Form2.Show()
    End Sub

    Private Sub Task_Tick(sender As Object, e As EventArgs) Handles Task.Tick
        If FPS_Timer.Enabled = True Then
            FPS += 1
        End If

        If PictureBox.Image IsNot Nothing Then
            PictureBox.Image.Dispose()
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
        PictureBox.Image = bmp
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

    Private mousePoint As Point

    Private Sub Form1_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseDown, PictureBox.MouseDown
        If (e.Button And MouseButtons.Left) = MouseButtons.Left Then
            '位置を記憶する
            mousePoint = New Point(e.X, e.Y)
        End If
    End Sub

    'マウスが動いたとき
    Private Sub Form1_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseMove, PictureBox.MouseMove
        If (e.Button And MouseButtons.Left) = MouseButtons.Left Then
            Me.Left += e.X - mousePoint.X
            Me.Top += e.Y - mousePoint.Y
        End If
    End Sub

    Dim mode As Integer = 1

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox.DoubleClick
        If mode = 3 Then
            Me.WindowState = FormWindowState.Maximized
            PictureBox.Top = 0
            PictureBox.Left = 0
            PictureBox.Width = Me.Width
            PictureBox.Height = Me.Height
            PictureBox.Top = 0
            Try
                AppActivate("Parsec")
            Catch ex As Exception
            End Try
            mode = 0
        ElseIf mode = 2 Then
            Me.WindowState = FormWindowState.Normal
            Me.Width = 1600
            Me.Height = 900
            Me.Top = Me.Top - 90
            Me.Left = Me.Left - 160
            PictureBox.Top = 0
            PictureBox.Left = 0
            PictureBox.Width = Me.Width
            PictureBox.Height = Me.Height
            PictureBox.Top = 0
            Try
                AppActivate("Parsec")
            Catch ex As Exception
            End Try
            mode = 3
        ElseIf mode = 1 Then
            Me.WindowState = FormWindowState.Normal
            Me.Width = 1280
            Me.Height = 720
            PictureBox.Top = 0
            PictureBox.Left = 0
            PictureBox.Width = Me.Width
            PictureBox.Height = Me.Height
            PictureBox.Top = 0
            Me.Top = Me.Top - 90
            Me.Left = Me.Left - 160
            Try
                AppActivate("Parsec")
            Catch ex As Exception
            End Try
            mode = 2
        ElseIf mode = 0 Then
            Me.WindowState = FormWindowState.Normal
            Me.Width = 960
            Me.Height = 540
            PictureBox.Top = 0
            PictureBox.Left = 0
            PictureBox.Width = Me.Width
            PictureBox.Height = Me.Height
            PictureBox.Top = 0
            Me.Top = Me.Top + 180
            Me.Left = Me.Left + 320
            Try
                AppActivate("Parsec")
            Catch ex As Exception
            End Try
            mode = 1
        Else
        End If
    End Sub

    Private Sub FPS_Timer_Tick(sender As Object, e As EventArgs) Handles FPS_Timer.Tick
        FPS_Label.Text = CStr(FPS)
        FPS = 0
    End Sub

    Private Sub FPS_Click(sender As Object, e As EventArgs) Handles FPS_Label.Click
        If FPS_Timer.Enabled = True Then
            FPS_Timer.Enabled = False
            FPS_Label.Text = "0"
        Else
            FPS_Timer.Enabled = True
        End If
    End Sub

    Private Sub PictureBox_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles Me.KeyDown
        'F1キーが押されたか調べる
        If e.KeyData = Keys.Escape Then
            If Form3.Visible = False Then
                Form3.Show()
                Me.Activate()
            Else
                Form3.Visible = False
            End If

        End If
    End Sub

End Class
