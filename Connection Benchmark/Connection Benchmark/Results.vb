Imports System.Windows.Forms

Public Class Results

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub Results_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim AverageP As Integer = 0
        Dim AverageS As Integer = 0
        Dim numUsed As Integer = 0
        ListView1.Items.Clear()
        If Form1.useGoogle = True Then
            Dim i As ListViewItem = ListView1.Items.Add("Google")
            i.SubItems.Add(Form1.ResponseTime1.ToString & "ms")
            i.SubItems.Add(Form1.DeltaTime1.ToString & "ms")

            AverageP = AverageP + Form1.ResponseTime1
            AverageS = AverageS + Form1.DeltaTime1
            numUsed += 1
        End If

        If Form1.useoDNS = True Then
            Dim i As ListViewItem = ListView1.Items.Add("openDNS")
            i.SubItems.Add(Form1.ResponseTime2.ToString & "ms")
            i.SubItems.Add(Form1.DeltaTime2.ToString & "ms")

            AverageP = AverageP + Form1.ResponseTime2
            AverageS = AverageS + Form1.DeltaTime2
            numUsed += 1
        End If

        If Form1.useL3 = True Then
            Dim i As ListViewItem = ListView1.Items.Add("Level3")
            i.SubItems.Add(Form1.ResponseTime3.ToString & "ms")
            i.SubItems.Add(Form1.DeltaTime3.ToString & "ms")

            AverageP = AverageP + Form1.ResponseTime3
            AverageS = AverageS + Form1.DeltaTime3
            numUsed += 1
        End If

        If Form1.uselc = True Then
            Dim i As ListViewItem = ListView1.Items.Add("Local")
            i.SubItems.Add(Form1.ResponseTime4.ToString & "ms")
            i.SubItems.Add(Form1.DeltaTime4.ToString & "ms")

            AverageP = AverageP + Form1.ResponseTime4
            AverageS = AverageS + Form1.DeltaTime4
            numUsed += 1
        End If

        avgPing.Text = Math.Round(AverageP / numUsed, 1)
        avgStab.Text = Math.Round(AverageS / numUsed, 1)
        If Form1.uselc = True Then
            reliLabel.Text = "Local Used"
        ElseIf numUsed = 0
            reliLabel.Text = "D"
        ElseIf numUsed = 1
            reliLabel.Text = "C"
        ElseIf numUsed = 2
            reliLabel.Text = "B"
        ElseIf numUsed = 3
            reliLabel.Text = "A"
        End If
    End Sub

End Class
