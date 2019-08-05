Imports System.Net
Public Class clientside
    Dim functions(4) As Integer

    Private Sub clientside_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TrackBar1.Value = Timer1.Interval()
        Label5.Text = TrackBar1.Value.ToString + " ms"

        If My.Computer.Network.Ping("www.google.com") Then
            lbCon.Text = "ONLINE"
            lbCon.ForeColor = Color.Green
        Else
            lbCon.Text = "OFFLINE"
            lbCon.ForeColor = Color.Red
        End If
        If My.Computer.Network.Ping("majdpersonal.comxa.com", 1000) Then
            lbConServe.Text = "ONLINE"
            lbConServe.ForeColor = Color.Green
        Else
            lbConServe.Text = "OFFLINE"
            lbConServe.ForeColor = Color.Red
        End If
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Form1.Show()
        Me.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        NotifyIcon1.BalloonTipIcon = ToolTipIcon.Info
        NotifyIcon1.Visible = True
        NotifyIcon1.Text = "COM Client"
        Me.Hide()
        NotifyIcon1.ShowBalloonTip(1000)

        Timer1.Start()


    End Sub

    Private Sub ShowToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ShowToolStripMenuItem.Click
        Me.Show()
        Me.Focus()
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub NotifyIcon1_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles NotifyIcon1.MouseDoubleClick
        Me.Show()
        Me.Focus()
    End Sub

    Private Sub StartListening()

        If Not My.Computer.FileSystem.DirectoryExists("C:\COM\fromFTP") Then
            My.Computer.FileSystem.CreateDirectory("C:\COM\fromFTP\")
        End If
        Try
            My.Computer.Network.DownloadFile("ftp://majdpersonal.comxa.com/public_html/vb_projects/com/f1.txt", "C:\COM\fromFTP\f1.txt", "a6549961", "vili11291", False, 8000, True)
            Dim objreader As New System.IO.StreamReader("C:\COM\fromFTP\f1.txt")
            functions(1) = objreader.ReadToEnd
            objreader.Close()
            Dim ftp As Net.FtpWebRequest = DirectCast(System.Net.WebRequest.Create("ftp://majdpersonal.comxa.com/public_html/vb_projects/com/f1.txt"), System.Net.FtpWebRequest)
            Try
                ftp.Credentials = New System.Net.NetworkCredential("a6549961", "vili11291")
                ftp.Method = WebRequestMethods.Ftp.DeleteFile
                Dim ftpResponse As FtpWebResponse = CType(ftp.GetResponse(), FtpWebResponse)
                ftpResponse = ftp.GetResponse()
                ftpResponse.Close()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
            Function1(functions(1))
        Catch ex As WebException
        End Try

        Try
            My.Computer.Network.DownloadFile("ftp://majdpersonal.comxa.com/public_html/vb_projects/com/f2.txt", "C:\COM\fromFTP\f2.txt", "a6549961", "vili11291", False, 8000, True)
            Dim objreader As New System.IO.StreamReader("C:\COM\fromFTP\f2.txt")
            functions(2) = objreader.ReadToEnd
            objreader.Close()
            Dim ftp As Net.FtpWebRequest = DirectCast(System.Net.WebRequest.Create("ftp://majdpersonal.comxa.com/public_html/vb_projects/com/f2.txt"), System.Net.FtpWebRequest)
            Try
                ftp.Credentials = New System.Net.NetworkCredential("a6549961", "vili11291")
                ftp.Method = WebRequestMethods.Ftp.DeleteFile
                Dim ftpResponse As FtpWebResponse = CType(ftp.GetResponse(), FtpWebResponse)
                ftpResponse = ftp.GetResponse()
                ftpResponse.Close()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
            Function2(functions(2))
        Catch ex As WebException
            Dim quit = MsgBox(ex.Message + vbCrLf + vbCrLf + vbCrLf + "Would you like to abort all tasks and quit?", MsgBoxStyle.Critical + MsgBoxStyle.YesNo)
            If Not quit = MsgBoxResult.No Then
                Me.Close()
            End If
        End Try

        'Check for Messages

        Dim msg As String
        Dim msgType As String


        Try
            My.Computer.Network.DownloadFile("ftp://majdpersonal.comxa.com/public_html/vb_projects/com/msg/msg.txt", "C:\COM\fromFTP\msg.txt", "a6549961", "vili11291", False, 8000, True)
            Dim objreader As New System.IO.StreamReader("C:\COM\fromFTP\msg.txt")
            msg = objreader.ReadToEnd
            objreader.Close()
            Dim ftp As Net.FtpWebRequest = DirectCast(System.Net.WebRequest.Create("ftp://majdpersonal.comxa.com/public_html/vb_projects/com/msg/msg.txt"), System.Net.FtpWebRequest)
            Try
                ftp.Credentials = New System.Net.NetworkCredential("a6549961", "vili11291")
                ftp.Method = WebRequestMethods.Ftp.DeleteFile
                Dim ftpResponse As FtpWebResponse = CType(ftp.GetResponse(), FtpWebResponse)
                ftpResponse = ftp.GetResponse()
                ftpResponse.Close()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

        Catch ex As WebException
        End Try


        'Check for Message Type
        Try
            My.Computer.Network.DownloadFile("ftp://majdpersonal.comxa.com/public_html/vb_projects/com/msg/msgType.txt", "C:\COM\fromFTP\msgType.txt", "a6549961", "vili11291", False, 8000, True)
            Dim objreader As New System.IO.StreamReader("C:\COM\fromFTP\msgType.txt")
            msgType = objreader.ReadToEnd
            objreader.Close()

            Try
                Dim ftp As Net.FtpWebRequest = DirectCast(System.Net.WebRequest.Create("ftp://majdpersonal.comxa.com/public_html/vb_projects/com/msg/msgType.txt"), System.Net.FtpWebRequest)
                ftp.Credentials = New System.Net.NetworkCredential("a6549961", "vili11291")
                ftp.Method = WebRequestMethods.Ftp.DeleteFile
                Dim ftpResponse As FtpWebResponse = CType(ftp.GetResponse(), FtpWebResponse)
                ftpResponse = ftp.GetResponse()
                ftpResponse.Close()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        Catch ex As WebException
            Dim quit = MsgBox(ex.Message + vbCrLf + vbCrLf + vbCrLf + "Would you like to abort all tasks and quit?", MsgBoxStyle.Critical + MsgBoxStyle.YesNo)
            If Not quit = MsgBoxResult.No Then
                Me.Close()
            End If
        End Try
        If Not msg = "" Then
            GetMessage(msg, msgType)
        End If


    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        StartListening()
    End Sub

    Private Sub Function1(ByVal Value As String)
        If Value = 1 Then
            MsgBox("Function 1 Activated!")
        Else
            MsgBox("Function 1 Off!")
        End If
    End Sub

    Private Sub Function2(ByVal Value As Integer)
        If Value = 1 Then
            MsgBox("Function 2 Activated!")
        Else
            MsgBox("Function 2 Off!")
        End If
    End Sub


    Private Sub TrackBar1_Scroll(sender As Object, e As EventArgs) Handles TrackBar1.Scroll
        Timer1.Interval = TrackBar1.Value
        Label5.Text = TrackBar1.Value.ToString + " ms"
    End Sub

    Sub GetMessage(ByVal msg As String, ByVal msgType As String)
        Dim convMsgType As MsgBoxStyle
        If msgType = "inf" Then
            convMsgType = MsgBoxStyle.Information
        ElseIf msgType = "err" Then
            convMsgType = MsgBoxStyle.Critical
        ElseIf msgType = "warn" Then
            convMsgType = MsgBoxStyle.Exclamation
        End If

        MsgBox("New Message Received! " + vbCrLf + vbCrLf + vbCrLf + vbCrLf + msg, convMsgType, "Message Received")

    End Sub
End Class