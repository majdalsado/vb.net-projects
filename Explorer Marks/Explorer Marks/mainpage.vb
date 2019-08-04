Public Class Form1

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        addnew.ShowDialog()
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        My.Settings.Reload()
        Button1.Text = My.Settings.shortcut1title
        Button2.Text = My.Settings.shortcut2title
        Button3.Text = My.Settings.shortcut3title
        Button4.Text = My.Settings.shortcut4title
        Button5.Text = My.Settings.shortcut5title
        Button6.Text = My.Settings.shortcut6title

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Process.Start("explorer.exe", My.Settings.shortcut1value.ToString)
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Process.Start("explorer.exe", My.Settings.shortcut2value.ToString)
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Process.Start("explorer.exe", My.Settings.shortcut3value)
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Process.Start("explorer.exe", My.Settings.shortcut4value)
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Process.Start("explorer.exe", My.Settings.shortcut5value)
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Process.Start("explorer.exe", My.Settings.shortcut6value)
    End Sub
End Class
