Imports Bwl.Hardware.SimplSerial

Public Class Bus
    Public Shared Property RS485 As New FastSerialPort
    Public Shared Property RS485_SS As New SimplSerialBus(RS485)

    Public Shared Property RS232 As New FastSerialPort
    Public Shared Property RS232_SS As New SimplSerialBus(RS232)

    Public Shared Property UART As New FastSerialPort
    Public Shared Property UART_SS As New SimplSerialBus(UART)

    Public Shared Property ExtPort As New FastSerialPort
    Public Shared Property ExtPort_SS As New SimplSerialBus(ExtPort)

    Public Shared Sub ExtPortClose()
        Try
            ExtPort.Disconnect()
        Catch ex As Exception
        End Try
    End Sub

    Public Shared Sub ExtPortOpen(portname As String, Optional speed As Integer = 9600)
        If ExtPort Is Nothing Then ExtPort = New FastSerialPort : ExtPort_SS = New SimplSerialBus(ExtPort)
        ExtPort.DeviceAddress = portname
        ExtPort.DeviceSpeed = speed
        ExtPort.Connect()
    End Sub

    Shared Sub New()

    End Sub
End Class
