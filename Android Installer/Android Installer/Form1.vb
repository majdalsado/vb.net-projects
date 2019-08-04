Public Class Form1

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim ExecuteBatch
        Dim FullValue

        ExecuteBatch = My.Resources.installexecute
        FullValue = "adb install " & ListBox1.SelectedItem

        My.Computer.FileSystem.WriteAllText(ExecuteBatch, FullValue, False)

    End Sub
End Class
