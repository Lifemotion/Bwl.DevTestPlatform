Public Class Tests
    Public Shared Sub TestVoltage(expected As Integer, range As Integer, real As Integer)
        If real <= expected - range Then Throw New Exception("Expected: >" + (expected - range).ToString + ", real: " + real.ToString)
        If real >= expected + range Then Throw New Exception("Expected: <" + (expected + range).ToString + ", real: " + real.ToString)
    End Sub

    Public Shared Sub TestPort(port As IO.Ports.SerialPort, connected As Boolean)
        TestPort(port, port, connected)
    End Sub

    Public Shared Sub TestPort(portTX As IO.Ports.SerialPort, portRX As IO.Ports.SerialPort, connected As Boolean)
        portTX.Close()
        portRX.Close()
        Dim str = "67df!!@"
        portRX.ReadBufferSize = 128 : portTX.ReadBufferSize = 128
        portRX.WriteBufferSize = 128 : portTX.WriteBufferSize = 128
        portRX.Open()
        If portRX.PortName <> portTX.PortName Then portTX.Open()
        Try
            portRX.DiscardInBuffer() : portTX.DiscardInBuffer()
            portTX.DiscardOutBuffer() : portRX.DiscardOutBuffer()
            portTX.Write(str)
            Threading.Thread.Sleep(100)
            Dim recv = portRX.ReadExisting
            If recv <> str And connected Then Throw New Exception("Sent " + portRX.BaudRate.ToString + ": " + str + ", received: " + recv)
            If recv > "" And Not connected Then Throw New Exception("Received with no connection: " + portRX.BaudRate.ToString + " " + recv)
            Try : portRX.Close() : Catch : End Try
            Try : portTX.Close() : Catch : End Try
            Return
        Catch ex As Exception
            Try : portRX.Close() : Catch : End Try
            Try : portTX.Close() : Catch : End Try
            Throw ex
        End Try
    End Sub

End Class
