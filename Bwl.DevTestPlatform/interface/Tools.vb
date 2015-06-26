Public Class Tools
    Public Shared Property Logger As Logger
    Public Delegate Sub Sub0()
    Public Delegate Sub Sub1(parameter As Object)

    Public Shared Sub Output(ParamArray objs() As Object)
        Dim result As String = ""
        For i = 0 To objs.Length - 1
            result += objs(i).ToString + " "
        Next
        Logger.AddMessage(result)
    End Sub

    Public Shared Sub Wait(ms As Integer)
        Dim t = Now
        Do
            Application.DoEvents()
            Threading.Thread.Sleep(1)
        Loop While (Now - t).TotalMilliseconds < ms
    End Sub

    Public Property Message1Delegate As Sub1

    Public Sub Message1(text As String, Optional waitAfter As Integer = 0)
        Message1Delegate.Invoke(text)
        If waitAfter > 0 Then Tools.Wait(waitAfter)
    End Sub
End Class
