Imports System.Net

Public Class serverside

    Private Sub serverside_Load(sender As Object, e As EventArgs) Handles MyBase.Load



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

    Private Sub F1ON()
        If Not My.Computer.FileSystem.DirectoryExists("C:\COM\toFTP") Then
            My.Computer.FileSystem.CreateDirectory("C:\COM\toFTP\")
        End If

        Try
            Dim objWriter As New System.IO.StreamWriter("C:\COM\toFTP\f1.txt", False)
            objWriter.WriteLine("1")
            objWriter.Close()
            MsgBox("Sent Request!")
        Catch ex As Exception
            MsgBox("Error! " + ex.Message, MsgBoxStyle.Critical, "Error!")
        End Try

        Try
            Dim request As System.Net.FtpWebRequest = DirectCast(System.Net.WebRequest.Create("ftp://majdpersonal.comxa.com/public_html/vb_projects/com/f1.txt"), System.Net.FtpWebRequest)
            request.Credentials = New System.Net.NetworkCredential("a6549961", "vili11291")
            request.Method = System.Net.WebRequestMethods.Ftp.UploadFile

            Dim file() As Byte = System.IO.File.ReadAllBytes("C:\COM\toFTP\f1.txt")

            Dim strz As System.IO.Stream = request.GetRequestStream()
            strz.Write(file, 0, file.Length)
            strz.Close()
            strz.Dispose()

        Catch ex As Exception
            MsgBox("Error! " + ex.Message(), MsgBoxStyle.Critical, "Error!")
        End Try


    End Sub

    Private Sub F1OFF()
        If Not My.Computer.FileSystem.DirectoryExists("C:\COM\toFTP") Then
            My.Computer.FileSystem.CreateDirectory("C:\COM\toFTP\")
        End If

        Try
            Dim objWriter As New System.IO.StreamWriter("C:\COM\toFTP\f1.txt", False)
            objWriter.WriteLine("0")
            objWriter.Close()
            MsgBox("Sent Request!")
        Catch ex As Exception
            MsgBox("Error! " + ex.Message, MsgBoxStyle.Critical, "Error!")
        End Try

        Try
            Dim request As System.Net.FtpWebRequest = DirectCast(System.Net.WebRequest.Create("ftp://majdpersonal.comxa.com/public_html/vb_projects/com/f1.txt"), System.Net.FtpWebRequest)
            request.Credentials = New System.Net.NetworkCredential("a6549961", "vili11291")
            request.Method = System.Net.WebRequestMethods.Ftp.UploadFile

            Dim file() As Byte = System.IO.File.ReadAllBytes("C:\COM\toFTP\f1.txt")

            Dim strz As System.IO.Stream = request.GetRequestStream()
            strz.Write(file, 0, file.Length)
            strz.Close()
            strz.Dispose()

        Catch ex As Exception
            MsgBox("Error! " + ex.Message(), MsgBoxStyle.Critical, "Error!")
        End Try

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Form1.Show()
        Me.Close()
    End Sub

    Private Sub F2ON()
        If Not My.Computer.FileSystem.DirectoryExists("C:\COM\toFTP") Then
            My.Computer.FileSystem.CreateDirectory("C:\COM\toFTP\")
        End If

        Try
            Dim objWriter As New System.IO.StreamWriter("C:\COM\toFTP\f2.txt", False)
            objWriter.WriteLine("1")
            objWriter.Close()
            MsgBox("Sent Request!")
        Catch ex As Exception
            MsgBox("Error! " + ex.Message, MsgBoxStyle.Critical, "Error!")
        End Try

        Try
            Dim request As System.Net.FtpWebRequest = DirectCast(System.Net.WebRequest.Create("ftp://majdpersonal.comxa.com/public_html/vb_projects/com/f2.txt"), System.Net.FtpWebRequest)
            request.Credentials = New System.Net.NetworkCredential("a6549961", "vili11291")
            request.Method = System.Net.WebRequestMethods.Ftp.UploadFile

            Dim file() As Byte = System.IO.File.ReadAllBytes("C:\COM\toFTP\f2.txt")

            Dim strz As System.IO.Stream = request.GetRequestStream()
            strz.Write(file, 0, file.Length)
            strz.Close()
            strz.Dispose()

        Catch ex As Exception
            MsgBox("Error! " + ex.Message(), MsgBoxStyle.Critical, "Error!")
        End Try
    End Sub

    Private Sub F2OFF()
        If Not My.Computer.FileSystem.DirectoryExists("C:\COM\toFTP") Then
            My.Computer.FileSystem.CreateDirectory("C:\COM\toFTP\")
        End If

        Try
            Dim objWriter As New System.IO.StreamWriter("C:\COM\toFTP\f2.txt", False)
            objWriter.WriteLine("0")
            objWriter.Close()
            MsgBox("Sent Request!")
        Catch ex As Exception
            MsgBox("Error! " + ex.Message, MsgBoxStyle.Critical, "Error!")
        End Try

        Try
            Dim request As System.Net.FtpWebRequest = DirectCast(System.Net.WebRequest.Create("ftp://majdpersonal.comxa.com/public_html/vb_projects/com/f2.txt"), System.Net.FtpWebRequest)
            request.Credentials = New System.Net.NetworkCredential("a6549961", "vili11291")
            request.Method = System.Net.WebRequestMethods.Ftp.UploadFile

            Dim file() As Byte = System.IO.File.ReadAllBytes("C:\COM\toFTP\f2.txt")

            Dim strz As System.IO.Stream = request.GetRequestStream()
            strz.Write(file, 0, file.Length)
            strz.Close()
            strz.Dispose()
        Catch ex As Exception
            MsgBox("Error! " + ex.Message(), MsgBoxStyle.Critical, "Error!")
        End Try
    End Sub

    Private Sub TrackBar1_Scroll(sender As Object, e As EventArgs) Handles TrackBar1.Scroll
        If TrackBar1.Value = 0 Then
            F1OFF()
        ElseIf TrackBar1.Value = 1 Then
            F1ON()
        End If
    End Sub

    Private Sub TrackBar2_Scroll(sender As Object, e As EventArgs) Handles TrackBar2.Scroll
        If TrackBar2.Value = 0 Then
            F1OFF()
        ElseIf TrackBar2.Value = 1 Then
            F1ON()
        End If
    End Sub

    Private Sub Label7_Click(sender As Object, e As EventArgs) Handles Label7.Click

    End Sub

    Private Sub Label6_Click(sender As Object, e As EventArgs) Handles Label6.Click
        TrackBar1.Value = 0
        F1OFF()

    End Sub

    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click
        TrackBar1.Value = 1
        F1ON()

    End Sub

    Private Sub Label9_Click(sender As Object, e As EventArgs) Handles Label9.Click
        TrackBar2.Value = 1
        F2ON()

    End Sub

    Private Sub Label8_Click(sender As Object, e As EventArgs) Handles Label8.Click
        TrackBar2.Value = 0
        F2OFF()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        SendMessage.ShowDialog()
    End Sub
End Class