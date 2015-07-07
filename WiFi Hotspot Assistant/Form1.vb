Public Class Form1

    Private Sub btn_start_Click(sender As Object, e As EventArgs) Handles btn_start.Click
        My.Settings.Save()

        Dim name As String = My.Settings.name
        Dim pass As String = My.Settings.pass


        Dim pro = Process.Start("cmd", "/c netsh wlan set hostednetwork ssid=" & name & " key=" & pass & " mode=allow > log.txt")
        pro.WaitForExit()
        Dim result As String = System.IO.File.ReadAllText("log.txt")

        If Not result.Contains("invalid") Then
            Dim pro2 = Process.Start("cmd", "/c netsh wlan start hostednetwork > log.txt")
            pro2.WaitForExit()
            Dim result2 As String = System.IO.File.ReadAllText("log.txt")
        End If

        NotifyIcon1.ShowBalloonTip(1000, "Wifi Hotspot Assistant", result, ToolTipIcon.Info)

    End Sub

    Private Sub btn_stop_Click(sender As Object, e As EventArgs) Handles btn_stop.Click
        Dim pro2 = Process.Start("cmd", "/c netsh wlan stop hostednetwork > log.txt")
        Dim result As String = System.IO.File.ReadAllText("log.txt")
        NotifyIcon1.ShowBalloonTip(1000, "Wifi Hotspot Assistant", result, ToolTipIcon.Info)
    End Sub
End Class
