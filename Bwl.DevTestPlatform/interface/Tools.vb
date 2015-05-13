Public Class Tools
    Public Shared Property Logger As Logger

    Public Shared Sub Pause(secs As Single)
        For i = 1 To 100 * secs
            Application.DoEvents()
            Threading.Thread.Sleep(10)
        Next
    End Sub

    Public Shared Sub Output(ParamArray objs() As Object)
        Dim result As String = ""
        For i = 0 To objs.Length - 1
            result += objs(i).ToString + " "
        Next
        Logger.AddMessage(result)
    End Sub
End Class
