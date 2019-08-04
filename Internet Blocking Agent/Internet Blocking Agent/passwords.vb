Public Class passwords

    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        If ComboBox1.SelectedItem = "Admin" Then
            TextBox1.Text = My.Settings.majdpassword
        End If
        If ComboBox1.SelectedItem = "User" Then
            TextBox1.Text = My.Settings.zaedpassword
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        My.Computer.Clipboard.SetText(TextBox1.Text)
        MsgBox("Copied to Clipboard!", MsgBoxStyle.Information)
    End Sub

End Class