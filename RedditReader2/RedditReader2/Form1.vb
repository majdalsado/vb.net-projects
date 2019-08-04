Public Class Form1

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

    End Sub

    Private Sub WebBrowser1_DocumentCompleted(ByVal sender As System.Object, ByVal e As System.Windows.Forms.WebBrowserDocumentCompletedEventArgs) Handles WebBrowser1.DocumentCompleted
        Dim PageElements As HtmlElementCollection = WebBrowser1.Document.GetElementsByTagName("p")

        For Each CurElement As HtmlElement In PageElements

            ListBox1.Items.Add(CurElement.InnerText & Environment.NewLine)

        Next
    End Sub
End Class
