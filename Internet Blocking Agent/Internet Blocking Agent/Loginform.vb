Public Class Loginform


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        'Login In Code
        If usernamebox.Text = "admin" Then
            If passwordbox.Text = My.Settings.majdpassword Then
                My.Settings.Save()
                MsgBox("Logged In! Welcome", MsgBoxStyle.Information)
                Me.Close()
                Form1.loggedinname.Text = "Administrator"
                Form1.WindowState = FormWindowState.Normal
                Form1.Enabled = True
                'Permissions For ReLogging In
                Form1.Button2.Enabled = True
                Form1.Button4.Enabled = True
                settings.Button3.Enabled = True
                Me.Hide()
                settings.Button4.Enabled = True
                Form1.Enabled = True
                Form1.WindowState = FormWindowState.Normal

            Else
                MsgBox("Wrong Password or Username.", MsgBoxStyle.Critical)
            End If


        ElseIf usernamebox.Text = "user" Then
            If passwordbox.Text = My.Settings.zaedpassword Then
                My.Settings.Save()
                MsgBox("Logged In! Welcome", MsgBoxStyle.Information)
                Form1.loggedinname.Text = "Low Permission User"
                'Permissions
                Form1.Button2.Enabled = False
                Form1.Button4.Enabled = False
                settings.Button3.Enabled = False
                Me.Hide()
                settings.ComboBox1.Items.RemoveAt(0)
                settings.Button4.Enabled = False
                Form1.Enabled = True
                Form1.WindowState = FormWindowState.Normal
            Else
                MsgBox("Wrong Password or Username.", MsgBoxStyle.Critical)
            End If
        Else
            MsgBox("Wrong Password or Username.", MsgBoxStyle.Critical)
        End If
        'End of Login code

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Form1.Close()
    End Sub
End Class