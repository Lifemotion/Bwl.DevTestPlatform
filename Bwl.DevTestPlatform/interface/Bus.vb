Public Class Bus
    Public Shared Property RS485 As New FastSerialPort
    Public Shared Property RS485_SS As New SimplSerialBus(RS485)

    Public Shared Property UART As New FastSerialPort
    Public Shared Property UART_SS As New SimplSerialBus(UART)
    Shared Sub New()

    End Sub
End Class
