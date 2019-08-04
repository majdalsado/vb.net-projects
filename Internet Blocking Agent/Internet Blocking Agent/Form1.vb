Imports System.IO

Public Class Form1


    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click

        If TextBox1.Text = "" Then
            MsgBox("Please enter a website URL.")
        Else
            My.Computer.FileSystem.WriteAllText("C:\Windows\system32\drivers\etc\HOSTS", vbCrLf + "127.0.0.1 " + TextBox1.Text, True)
            MsgBox("Successfully blocked " + TextBox1.Text, MsgBoxStyle.Information)
        End If

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        hostscontent.ShowDialog()
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        System.Diagnostics.Process.Start("Notepad.Exe", "C:\windows\system32\drivers\etc\hosts")
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load


        'Zaed's Permissons
        Loginform.Show()
        Me.Enabled = False
        Dim hosts
        hosts = My.Computer.FileSystem.FileExists("C:\hostsbackup\hosts")
        If hosts = False Then
            Button2.Enabled = False
            Button4.Enabled = False
            MsgBox("Please backup the HOSTS file before using this tool. You will only be able use this tool if you backup your HOSTS file.", MsgBoxStyle.Critical)
        End If

        'Checks if the User is in Admin
        If My.User.IsAuthenticated = False Then
            MsgBox("Please run this application in Administrator mode, the application will now turn off.", MsgBoxStyle.Critical)
            Me.Close()
        End If
    End Sub

    Private Sub LogoutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LogoutToolStripMenuItem.Click
        settings.ShowDialog()
    End Sub

    Private Sub LogoutToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LogoutToolStripMenuItem1.Click
        Me.Enabled = False
        Loginform.Show()
    End Sub

    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub AboutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AboutToolStripMenuItem.Click
        aboutpage.ShowDialog()
    End Sub

    Private Sub GuideToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GuideToolStripMenuItem.Click
        About.ShowDialog()
    End Sub

End Class
