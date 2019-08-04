Imports System.Windows.Forms

Public Class Dialog1

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        On Error GoTo errormessage
        Form1.Label4.Text = ListBox1.SelectedItem.ToString
        Form1.Button2.Enabled = True
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
        GoTo keepitup

errormessage:
        MsgBox("Please Select a Sub-Reddit", MsgBoxStyle.Critical)
keepitup:
    End Sub
    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        ListBox1.Items.Add(TextBox1.Text)
    End Sub
End Class
