Imports System.Windows.Forms

Public Class addnew

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        If ComboBox2.SelectedIndex = 1 Then
            My.Settings.shortcut1title = TextBox1.Text
            My.Settings.shortcut1value = TextBox2.Text
            My.Settings.Save()
            Me.Close()

        ElseIf ComboBox2.SelectedIndex = 2 Then
            My.Settings.shortcut2title = TextBox1.Text
            My.Settings.shortcut2value = TextBox2.Text
            My.Settings.Save()
            Me.Close()

        ElseIf ComboBox2.SelectedIndex = 3 Then
            My.Settings.shortcut3title = TextBox1.Text
            My.Settings.shortcut3value = TextBox2.Text
            My.Settings.Save()
            Me.Close()

        ElseIf ComboBox2.SelectedIndex = 4 Then
            My.Settings.shortcut4title = TextBox1.Text
            My.Settings.shortcut4value = TextBox2.Text
            My.Settings.Save()
            Me.Close()

        ElseIf ComboBox2.SelectedIndex = 5 Then
            My.Settings.shortcut5title = TextBox1.Text
            My.Settings.shortcut5value = TextBox2.Text
            My.Settings.Save()
            Me.Close()

        ElseIf ComboBox2.SelectedIndex = 6 Then
            My.Settings.shortcut6title = TextBox1.Text
            My.Settings.shortcut6value = TextBox2.Text
            My.Settings.Save()
            Me.Close()
        Else
            MsgBox("SELECT USER BRO!", MsgBoxStyle.Critical)
            

        End If
        Form1.Button1.Text = My.Settings.shortcut1title
        Form1.Button2.Text = My.Settings.shortcut2title
        Form1.Button3.Text = My.Settings.shortcut3title
        Form1.Button4.Text = My.Settings.shortcut4title
        Form1.Button5.Text = My.Settings.shortcut5title
        Form1.Button6.Text = My.Settings.shortcut6title
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox2.SelectedIndexChanged
        TextBox1.Text = ""
        TextBox2.Text = ""

    End Sub
End Class
