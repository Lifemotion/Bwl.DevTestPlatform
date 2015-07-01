Public Class Tools
    Public Shared Property Logger As Logger
    Public Delegate Function Function0Bool() As Boolean
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

    Public Shared Property Message1Delegate As Sub1

    Public Shared Sub Message1(text As String, Optional waitAfter As Integer = 0)
        Message1Delegate.Invoke(text)
        If waitAfter > 0 Then Tools.Wait(waitAfter)
    End Sub

    Public Shared Function RunShell(path As String, Optional args As String = "") As String
        Dim prc As New Process
        prc.StartInfo.UseShellExecute = False
        prc.StartInfo.RedirectStandardOutput = True
        prc.StartInfo.RedirectStandardError = True
        prc.StartInfo.Arguments = args
        prc.StartInfo.FileName = path
        prc.StartInfo.WorkingDirectory = IO.Path.GetDirectoryName(path)
        prc.StartInfo.WindowStyle = ProcessWindowStyle.Minimized
        prc.StartInfo.CreateNoWindow = True
        prc.Start()
        Dim result1 = ""
        Dim result2 = ""
        result1 = prc.StandardOutput.ReadToEnd()
        result2 = prc.StandardError.ReadToEnd()
        prc.WaitForExit()
        Return result1 + result2
    End Function

    Public Shared Function RunShellFindLine(path As String, args As String, find As String) As String
        Dim result = RunShell(path, args)
        Dim lines = result.Split({vbCr, vbLf}, StringSplitOptions.RemoveEmptyEntries)
        For Each line In lines
            If line.ToLower.Contains(find.ToLower) Then Return line
        Next
        Return ""
    End Function

    Public Shared Sub CheckShellCommand(path As String, args As String, findLine As String, Optional findOk As String = "OK!", Optional errorText As String = "Ошибка")
        Dim result = RunShellFindLine(path, args, findLine)
        If result.Contains(findOk) Then Return
        If result = "" Then Throw New Exception("Ошибка запуска утилиты " + IO.Path.GetFileName(path))
        Throw New Exception(errorText + " (" + result + ")")
    End Sub
End Class
