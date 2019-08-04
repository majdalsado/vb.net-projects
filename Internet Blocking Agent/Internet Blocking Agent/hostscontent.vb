Public Class hostscontent

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Reader_Help.ShowDialog()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub hostscontent_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim hostfile As String
        hostfile = My.Computer.FileSystem.ReadAllText("C:\Windows\system32\drivers\etc\hosts")
        TextBox1.Text = hostfile
    End Sub
End Class