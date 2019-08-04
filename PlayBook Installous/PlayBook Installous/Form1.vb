Public Class Form1
    Dim bar
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        On Error Resume Next
        If TextBox2.Text = "IP:Password" Then
            MsgBox("IP Address and Password not entered!", MsgBoxStyle.Critical, "Error!")
        Else
            If ComboBox1.Text = "Angry Birds Rio" Then
                MsgBox("Please Note, the application might freeze during download. Please leave the app alone as it is downloading and installing. Thank you!")
                My.Computer.Network.DownloadFile(bar, "C:\BARs\angrybirds.bar", "", "", True, 1000, True)
                Form2.Show()
                Shell("ping " & TextBox2.Text)
                MsgBox("Downloaded " & ComboBox1.Text & " Playbook Error! VS2008-21-3A Stored file to C:\BARs\)", MsgBoxStyle.Critical)
                ProgressBar1.Value = 100
            Else
                MsgBox("Please select a BAR to install!", MsgBoxStyle.Critical, "Error!")
            End If

        End If

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        AboutBox1.Show()
    End Sub

    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged

    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        bar = "https://dl.dropbox.com/s/piqny11tc2nax5w/Angry%20Birds%20Rio.bar?dl=1"
    End Sub

    Private Sub TextBox2_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles TextBox2.MouseClick
        MsgBox("Please Note: The IP Address and Password should be written in the following format ***.***.*.**:PASS Example: 192.168.1.75:1234")
    End Sub

    Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        System.Diagnostics.Process.Start("www.playbookassister.tk")
    End Sub
End Class
