Imports Ionic.Zip

Public Class Form1
    Dim modLocation As String

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        OpenFileDialog1.ShowDialog()
    End Sub

    Private Sub OpenFileDialog1_FileOk(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles OpenFileDialog1.FileOk
        TextBox1.Text = OpenFileDialog1.FileName.ToString()
        modLocation = TextBox1.Text

    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        OpenFileDialog1.Filter = "Minecraft Mod (*.zip)|*.zip|" _
     & "All Files(*.*)|"
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If TextBox1.Text = "" Then
            MsgBox("Please Enter a location.", MsgBoxStyle.Critical, "Error!")
        Else
            If RadioButton1.Checked = True Then
                ModUnpack()
                SubaddMod()
            End If
            If RadioButton2.Checked = True Then
                MoveMod()
            End If
            MsgBox("Done Installing Mod! Enjoy!", MsgBoxStyle.Information, "Finished")
        End If
    End Sub

    Sub ModUnpack()

        'Unpack Mod File to temp location 
        Dim ZipToUnpack As String = modLocation
        Dim UnpackDirectory As String = "C:\Temp\MineMod\TempMod\"
        Using zip1 As ZipFile = ZipFile.Read(ZipToUnpack)
            Dim e As ZipEntry
            ' here, we extract every entry, but we could extract conditionally,
            ' based on entry name, size, date, checkbox status, etc.   
            For Each e In zip1
                e.Extract(UnpackDirectory, ExtractExistingFileAction.OverwriteSilently)
            Next
        End Using
    End Sub

    Sub SubaddMod()
        Process.Start(Application.StartupPath + "/AddMod.bat")
    End Sub

    Sub MoveMod()
        Try
            If TextBox2.Text = "Please select a name for the mod" Or TextBox2.Text = "" Then
                MsgBox("Select a name for the mod!", MsgBoxStyle.Critical)
            Else
                My.Computer.FileSystem.CopyFile(modLocation, Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\.minecraft\mods\" + TextBox2.Text + ".zip")
            End If
        Catch ex As Exception
            My.Computer.Clipboard.SetText(ex.ToString)
            MsgBox("Error!" + Environment.NewLine + "Error Below, If this is a critical error, please report it. Error has been copied to your clipboard" + Environment.NewLine + Environment.NewLine + ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub


    Private Sub RadioButton2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If RadioButton2.Checked = True Then
            TextBox2.ReadOnly = False
        End If
    End Sub

    Private Sub TextBox2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        TextBox2.Text = ""
    End Sub

    Private Sub RadioButton1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If RadioButton1.Checked = True Then
            TextBox2.ReadOnly = True
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try


            Dim jardate As String = "C:\MCBackup\minecraft.jar"
            Dim minecraftLocation As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\.minecraft\bin\minecraft.jar"


            My.Computer.FileSystem.CopyFile(minecraftLocation, jardate, True)
        Catch ex As Exception
            MsgBox(ex.Message + Environment.NewLine + Environment.NewLine + "If this error is critical, please report it! It has been copied to your clipboard.", MsgBoxStyle.Critical)

            My.Computer.Clipboard.SetText(ex.ToString)
        End Try

        MsgBox("Done Backing Up!")
    End Sub


End Class
