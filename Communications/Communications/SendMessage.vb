Imports System.Windows.Forms

Public Class SendMessage

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        'ComboBox1 Index Vals       0 = Error/Urgent     1 = Information         2 = warning
        Dim type

        If ComboBox1.SelectedIndex = 0 Then
            type = "err"
        ElseIf ComboBox1.SelectedIndex = 1 Then
            type = "inf"
        ElseIf ComboBox1.SelectedIndex = 2 Then
            type = "warn"
        End If

        If type = "" Or TextBox1.Text = "" Then
            MessageBox.Show("Please Complete all fields!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Else
            SendMessageNow(type, TextBox1.Text)
            Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Me.Close()
            MsgBox("Message Sent!", MsgBoxStyle.Information, "Success!")
        End If

    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
        MsgBox("Message Canceled!", MsgBoxStyle.Exclamation, "Canceled!")
    End Sub


    Sub SendMessageNow(ByVal msgtype As String, ByVal msg As String)
        If Not My.Computer.FileSystem.DirectoryExists("C:\COM\toFTP") Then
            My.Computer.FileSystem.CreateDirectory("C:\COM\toFTP\")
        End If
        Try
            Dim objWriter As New System.IO.StreamWriter("C:\COM\toFTP\msg.txt", False)
            objWriter.WriteLine(msg)
            objWriter.Close()
        Catch ex As Exception
            MsgBox("Error! " + ex.Message, MsgBoxStyle.Critical, "Error!")
        End Try

        Try
            Dim request As System.Net.FtpWebRequest = DirectCast(System.Net.WebRequest.Create("ftp://majdpersonal.comxa.com/public_html/vb_projects/com/msg/msg.txt"), System.Net.FtpWebRequest)
            request.Credentials = New System.Net.NetworkCredential("a6549961", "vili11291")
            request.Method = System.Net.WebRequestMethods.Ftp.UploadFile

            Dim file() As Byte = System.IO.File.ReadAllBytes("C:\COM\toFTP\msg.txt")

            Dim strz As System.IO.Stream = request.GetRequestStream()
            strz.Write(file, 0, file.Length)
            strz.Close()
            strz.Dispose()
        Catch ex As Exception
            MsgBox("Error! " + ex.Message(), MsgBoxStyle.Critical, "Error!")
        End Try



        'Now Send MsgType too

        Try
            Dim objWriter As New System.IO.StreamWriter("C:\COM\toFTP\msgType.txt", False)
            objWriter.WriteLine(msgtype)
            objWriter.Close()
        Catch ex As Exception
            MsgBox("Error! " + ex.Message, MsgBoxStyle.Critical, "Error!")
        End Try

        Try
            Dim request As System.Net.FtpWebRequest = DirectCast(System.Net.WebRequest.Create("ftp://majdpersonal.comxa.com/public_html/vb_projects/com/msg/msgType.txt"), System.Net.FtpWebRequest)
            request.Credentials = New System.Net.NetworkCredential("a6549961", "vili11291")
            request.Method = System.Net.WebRequestMethods.Ftp.UploadFile

            Dim file() As Byte = System.IO.File.ReadAllBytes("C:\COM\toFTP\msgType.txt")

            Dim strz As System.IO.Stream = request.GetRequestStream()
            strz.Write(file, 0, file.Length)
            strz.Close()
            strz.Dispose()
        Catch ex As Exception
            MsgBox("Error! " + ex.Message(), MsgBoxStyle.Critical, "Error!")
        End Try
    End Sub
End Class
