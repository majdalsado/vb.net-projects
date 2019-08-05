Imports System.Net

Public Class Form1
    Dim clicks As Integer
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        clientside.Show()
        Me.Hide()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        serverside.Show()
        Me.Hide()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim ans = MsgBox("Are you sure you want to exit?", MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation, "Exit ?")
        If ans = MsgBoxResult.Yes Then
            Me.Close()
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If clicks >= 2 And clicks < 10 Then
            MsgBox("Quit clicking these arrows! They do nothing!", MsgBoxStyle.Information, "STAHP!")
        ElseIf clicks >= 10 Then
            MsgBox("WOW! You really want to know what these do huh? Well, they do nothing, stop.", MsgBoxStyle.Information, "You wasted all that time for this.")
        Else
            MsgBox("Yup. You clicked up... Nothing to see here.", MsgBoxStyle.Information, "Up.")
        End If
        clicks += 1
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        If clicks >= 2 And clicks < 10 Then
            MsgBox("Quit clicking these arrows! They do nothing!", MsgBoxStyle.Information, "STAHP!")
        ElseIf clicks >= 10 Then
            MsgBox("WOW! You really want to know what these do huh? Well, they do nothing, stop.", MsgBoxStyle.Information, "You wasted all that time for this.")
        Else
            MsgBox("Yup. You clicked right... Nothing to see here.", MsgBoxStyle.Information, "Right.")
        End If
        clicks += 1
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        If clicks >= 2 And clicks < 10 Then
            MsgBox("Quit clicking these arrows! They do nothing!", MsgBoxStyle.Information, "STAHP!")
        ElseIf clicks >= 10 Then
            MsgBox("WOW! You really want to know what these do huh? Well, they do nothing, stop.", MsgBoxStyle.Information, "You wasted all that time for this.")
        Else
            MsgBox("Yup. You clicked down... Nothing to see here.", MsgBoxStyle.Information, "Down.")
        End If
        clicks += 1
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        If clicks >= 2 And clicks < 10 Then
            MsgBox("Quit clicking these arrows! They do nothing!", MsgBoxStyle.Information, "STAHP!")
        ElseIf clicks >= 10 Then
            MsgBox("WOW! You really want to know what these do huh? Well, they do nothing, stop.", MsgBoxStyle.Information, "You wasted all that time for this.")
        Else
            MsgBox("Yup. You clicked left... Nothing to see here.", MsgBoxStyle.Information, "Left.")
        End If
        clicks += 1
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        clicks = 0
        MsgBox("Reset Counter! Now, Go On! Click those arrows!", MsgBoxStyle.Information, "Reset!")
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim UpdateAvailable As Boolean
        ' CODE FOR UPDATER
        Dim currentversion = My.Application.Info.Version.ToString
        Try
            My.Computer.Network.DownloadFile("ftp://majdpersonal.comxa.com/public_html/vb_projects/com/latestversion.txt", "C:\COM\latestversion.txt", "a6549961", "vili11291", False, 8000, True)
            Dim objreader As New System.IO.StreamReader("C:\COM\latestversion.txt")
            Dim latestversion = objreader.ReadToEnd().ToString
            If Not currentversion = latestversion Then
                UpdateAvailable = True
                Dim updateprompt = MsgBox("There is a new version of this program released! " + vbCrLf + vbCrLf + vbCrLf + vbCrLf + "Current Version = " + currentversion + " Latest Version = " + latestversion, MsgBoxStyle.YesNo + MsgBoxStyle.Information, "Updater Info!")
                If updateprompt = MsgBoxResult.Yes Then
                    Dim p As New ProcessStartInfo
                    p.FileName = "C:\Users\Majd\Documents\Visual Studio 2012\Projects\COM Updater\COM Updater\bin\Debug\COM_Updater.exe"
                    p.Arguments = " "" " & My.Application.Info.DirectoryPath.ToString & " "" " & " " & latestversion & " " & My.Application.Info.Version.ToString
                    Process.Start(p)
                    Me.Close()
                Else
                    MsgBox("Please consider updating! Updates are rare and are often VERY critical!", MsgBoxStyle.Information, "Updater Info!")
                End If
            Else
                UpdateAvailable = False
                MsgBox("You're running the latest version of this program!", MsgBoxStyle.Information, "Updater Info!")
            End If


        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Updater Error!")
        End Try

        'END OF CODE FOR UPDATER

        If UpdateAvailable Then
            lbUpdate.Text = "Update Available!"
            lbUpdate.ForeColor = Color.Red
            Dim Point1 As New System.Drawing.Point
            Point1.X = 416
            Point1.Y = 144
            lbUpdate.Location = Point1
        Else
            Dim Point1 As New System.Drawing.Point
            Point1.X = 444
            Point1.Y = 144
            lbUpdate.Location = Point1
            lbUpdate.Text = "Up to date!"
            lbUpdate.ForeColor = Color.Green

        End If
        Label2.Text = "Current Version: " + currentversion
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        MsgBox("These are pointless arrows. They seriously do nothing. The button in the middle however exits this program!", MsgBoxStyle.Information, "Help Prompt")
    End Sub
End Class
