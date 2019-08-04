Public Class loginform

    Private Sub WebBrowser1_DocumentCompleted(sender As Object, e As WebBrowserDocumentCompletedEventArgs) Handles WebBrowser1.DocumentCompleted

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        WebBrowser1.Document.GetElementById("user").SetAttribute("value", TextBox1.Text)
        WebBrowser1.Document.GetElementById("passwd").SetAttribute("value", TextBox2.Text)

        Dim allelements As HtmlElementCollection = WebBrowser1.Document.All

        For Each webpageelement As HtmlElement In allelements
            If webpageelement.InnerText = "login" Then

                webpageelement.InvokeMember("click")

            End If

        Next
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        Dim allelements As HtmlElementCollection = WebBrowser1.Document.All
        For Each webpageelement As HtmlElement In allelements
            If webpageelement.GetAttribute("class") = "userkarma" Then

                Label7.Text = webpageelement.InnerText.ToString

            End If

        Next
    End Sub
End Class