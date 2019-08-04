Imports System.Net
Imports System.IO
Imports System.Text

Public Class Form1
    Dim logincookie As CookieContainer
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim email As String = TextBox1.Text
        Dim password As String = TextBox2.Text

        login(email, password)
    End Sub

    Sub login(ByVal email As String, ByVal password As String)
        Dim postData As String = "email=" & email & "&pass=" & password & ""
        Dim tempcookies As New CookieContainer
        Dim encoding As New UTF8Encoding
        Dim byteData As Byte() = encoding.GetBytes(postData)
        Dim postreq As HttpWebRequest = DirectCast(HttpWebRequest.Create("https://www.facebook.com"), HttpWebRequest)
        postreq.Method = "POST"
        postreq.KeepAlive = True
        postreq.CookieContainer = tempcookies
        postreq.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64; rv:2.0b6pre) Gecko/20100903 Firefox/4.0b6pre"
        postreq.ContentType = "application/x-www-form-urlencoded"
        postreq.Referer = "www.facebook.com"
        postreq.ContentLength = byteData.Length

        Dim postreqstream As Stream = postreq.GetRequestStream()
        postreqstream.Write(byteData, 0, byteData.Length)
        postreqstream.Close()

        Dim postresponse As HttpWebResponse
        postresponse = DirectCast(postreq.GetResponse, HttpWebResponse)
        tempcookies.Add(postresponse.Cookies)
        logincookie = tempcookies

        Dim postreqreader As New StreamReader(postresponse.GetResponseStream())
        Dim thepage As String = postreqreader.ReadToEnd

        If thepage.Contains("Please re-enter your password") = True Then
            MsgBox("Incorrect email/password combination", 0, "Login error!")
        Else
            MsgBox("Logged in", 0, "Success!")
        End If
        If thepage.Contains("You have exceeded the number of invalid login attempts that we allow for your account") = True Then
            MsgBox("You have exceeded the number of invalid login attempts", 0, "Max number of wrong logins")
        End If
    End Sub
End Class
