Public NotInheritable Class AboutBox1
    Private Sub AboutBox1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LabelVersion.Text = ProductVersion.ToString
    End Sub

    Private Sub OKButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OKButton.Click
        Me.Close()
    End Sub

    Private Sub TextBoxDescription_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBoxDescription.TextChanged

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim request As System.Net.HttpWebRequest = System.Net.HttpWebRequest.Create("https://dl.dropbox.com/s/xyic34wo8vxbqyj/currentversion.txt?dl=1")
        Dim response As System.Net.HttpWebResponse = request.GetResponse()

        Dim sr As System.IO.StreamReader = New System.IO.StreamReader(response.GetResponseStream())

        Dim newestversion As String = sr.ReadToEnd()
        Dim currentversion As String = Application.ProductVersion

        If newestversion.Contains(currentversion) Then
            MessageBox.Show("You have the current version")
        Else
            MessageBox.Show("Newer version available, please check Playbook assister.tk for update")
            System.Diagnostics.Process.Start("www.playbookassister.tk")
        End If
    End Sub

    Private Sub LabelVersion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LabelVersion.Click

    End Sub
End Class
