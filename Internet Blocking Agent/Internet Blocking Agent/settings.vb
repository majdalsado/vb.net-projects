Public Class settings

    Private Sub Label3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Label2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Button2_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Hide()
    End Sub

    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If ComboBox1.SelectedItem = "Admin" Then
            If ComboBox1.SelectedItem = "" Then
                MsgBox("Please Select a User First!", MsgBoxStyle.Critical)
            ElseIf TextBox1.Text = "" Then
                MsgBox("Please input password!", MsgBoxStyle.Critical)
            Else
                My.Settings.majdpassword = TextBox1.Text
                MsgBox("Saved Admin's Password As " & TextBox1.Text, MsgBoxStyle.Information)
                My.Settings.Save()
            End If
        End If


        If ComboBox1.SelectedItem = "User" Then
            If ComboBox1.SelectedItem = "" Then
                MsgBox("Please Select a User First!", MsgBoxStyle.Critical)
            ElseIf TextBox1.Text = "" Then
                MsgBox("Please input password!", MsgBoxStyle.Critical)
            Else
                My.Settings.zaedpassword = TextBox1.Text
                MsgBox("Saved User's Password As " & TextBox1.Text)
                My.Settings.Save()
            End If
        End If
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        passwords.ShowDialog()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim Message As Integer

        If My.Computer.FileSystem.FileExists("C:\hostsbackup\hosts") = True Then
            Message = MsgBox("You already have a previous backup of your HOSTS file, would you like to overwrite it?", vbYesNo)
            If Message = vbYes Then
                My.Computer.FileSystem.CopyFile("C:\Windows\System32\drivers\etc\hosts", "C:\hostsbackup\hosts", True)
                MsgBox("Successfully backed up your file at C:\hostsbackup\")
            End If
            If Message = vbNo Then
                MsgBox("Ok! Aborted.")
            End If
        End If
        If My.Computer.FileSystem.FileExists("C:\hostsbackup\hosts") = False Then
            My.Computer.FileSystem.CopyFile("C:\Windows\System32\drivers\etc\hosts", "C:\hostsbackup\hosts", True)
            MsgBox("Successfully backed up your file at C:\hostsbackup\")
        End If
        Form1.Button2.Enabled = True
        Form1.Button4.Enabled = True
    End Sub
End Class