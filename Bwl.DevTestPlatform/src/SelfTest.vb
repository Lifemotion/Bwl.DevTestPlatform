Imports Bwl.Hardware.SimplSerial.SimplSerialBus

Public Class SelfTest
    '  Private _ss As SimplSerialBus
    Private _logger As Logger

    Private ReadOnly Property _ss As SimplSerialBus
        Get
            Return DevTest._sserial
        End Get
    End Property

    Public Sub New(logger As Logger, ss As SimplSerialBus)
        '  _ss = ss
        _logger = logger
        InitializeComponent()
        _logger.ConnectWriter(DatagridLogWriter1)
    End Sub

    Private Sub SelfTest_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        RunTest(sender, Sub()
                            If _ss.RequestDeviceInfo(0).DeviceName.Contains("BwlBoot") = True Then Throw New Exception("Bootloader mode: upload main firmware!")
                            If _ss.RequestDeviceInfo(0).DeviceName.Contains("DevTestPlatform") = False Then Throw New Exception("Bad SS DeviceName")
                        End Sub)
    End Sub

    Private Delegate Sub RunTestFunction()
    Private Sub RunTest(control As Control, dlg As RunTestFunction)
        Try
            dlg.Invoke()
            _logger.AddMessage("RunTest: " + control.Text + " - ok")
            control.BackColor = Drawing.Color.LightGreen
        Catch ex As Exception
            _logger.AddError("RunTest: " + control.Text + " - " + ex.Message)
            Me.Invoke(Sub() control.BackColor = Drawing.Color.Pink)
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        RunTest(sender, Sub()
                            If DevTest._portMCU Is Nothing OrElse DevTest._portMCU.Length < 3 Then Throw New Exception("Bad Core Port")
                            If DevTest._port232 Is Nothing OrElse DevTest._port232.Length < 3 Then Throw New Exception("Bad 232 Port")
                            If DevTest._port485 Is Nothing OrElse DevTest._port485.Length < 3 Then Throw New Exception("Bad 485 Port")
                            If DevTest._portUART Is Nothing OrElse DevTest._portUART.Length < 3 Then Throw New Exception("Bad UART Port")

                        End Sub)
    End Sub


    Private Sub TestPort(port As IO.Ports.SerialPort, connected As Boolean)
        TestPort(port, port, connected)
    End Sub
    Private Sub TestPort(portTX As IO.Ports.SerialPort, portRX As IO.Ports.SerialPort, connected As Boolean)
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

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        RunTest(sender, Sub()
                            MsgBox("Connect UART TX with RX")
                            TestPort(New IO.Ports.SerialPort(DevTest._portUART, 9600), True)
                            TestPort(New IO.Ports.SerialPort(DevTest._portUART, 115200), True)
                            MsgBox("Disconnect UART TX and RX")
                            TestPort(New IO.Ports.SerialPort(DevTest._portUART, 9600), False)
                        End Sub)
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        RunTest(sender, Sub()
                            MsgBox("Connect RS-232 TX with RX")
                            TestPort(New IO.Ports.SerialPort(DevTest._port232, 9600), True)
                            TestPort(New IO.Ports.SerialPort(DevTest._port232, 115200), True)
                            MsgBox("Disconnect RS-232 TX and RX")
                            TestPort(New IO.Ports.SerialPort(DevTest._port232, 9600), False)
                        End Sub)
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        RunTest(sender, Sub()
                            MsgBox("Connect RS-485 B with UART TX")
                            TestPort(New IO.Ports.SerialPort(DevTest._portUART, 9600), New IO.Ports.SerialPort(DevTest._port485, 9600), True)
                            MsgBox("Connect RS-485 B with UART RX")
                            TestPort(New IO.Ports.SerialPort(DevTest._port485, 9600), New IO.Ports.SerialPort(DevTest._portUART, 9600), True)
                            MsgBox("Connect RS-485 A with RS-232 RX")
                            TestPort(New IO.Ports.SerialPort(DevTest._port485, 9600), New IO.Ports.SerialPort(DevTest._port232, 9600), True)

                            ' TestPort(New IO.Ports.SerialPort(DevTest._port232, 115200), True)
                            '    MsgBox("Disconnect RS-232 TX and RX")
                            '  TestPort(New IO.Ports.SerialPort(DevTest._port232, 9600), False)
                        End Sub)
    End Sub

    Private Sub TestVoltage(expected As Integer, range As Integer, real As Integer)
        If real <= expected - range Then Throw New Exception("Expected: >" + (expected - range).ToString + ", real: " + real.ToString)
        If real >= expected + range Then Throw New Exception("Expected: <" + (expected + range).ToString + ", real: " + real.ToString)
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        RunTest(sender, Sub()
                            MsgBox("Connect Voltage 1 - 15V with POWER 3.3V")
                            TestVoltage(205, 10, Pin.Voltage(1).Raw)
                        End Sub)
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        RunTest(sender, Sub()
                            MsgBox("Connect Voltage 1 - 5V with POWER 3.3V")
                            TestVoltage(630, 20, Pin.Voltage(1).Raw)
                        End Sub)
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        RunTest(sender, Sub()
                            MsgBox("Connect Voltage 1 - 5V with POWER 3.3V")
                            TestVoltage(1023, 1, Pin.Voltage(1).Raw)
                        End Sub)
    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        RunTest(sender, Sub()
                            MsgBox("Connect Voltage 2 - 15V with POWER 3.3V")
                            TestVoltage(205, 10, Pin.Voltage(2).Raw)
                        End Sub)
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        RunTest(sender, Sub()
                            MsgBox("Connect Voltage 2 - 5V with POWER 3.3V")
                            TestVoltage(630, 20, Pin.Voltage(2).Raw)
                        End Sub)
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        RunTest(sender, Sub()
                            MsgBox("Connect Voltage 2 - 5V with POWER 3.3V")
                            TestVoltage(1023, 1, Pin.Voltage(2).Raw)
                        End Sub)
    End Sub

    Private Sub Button14_Click(sender As Object, e As EventArgs) Handles Button14.Click
        RunTest(sender, Sub()
                            MsgBox("Connect Current 1 - 3A to external 200mA source")
                            TestVoltage(70, 20, Pin.Current(1).Raw)
                        End Sub)
    End Sub

    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click
        RunTest(sender, Sub()
                            MsgBox("Connect Current 1 - 500mA to external 200mA source")
                            TestVoltage(410, 50, Pin.Current(1).Raw)
                        End Sub)
    End Sub

    Private Sub Button13_Click(sender As Object, e As EventArgs) Handles Button13.Click
        RunTest(sender, Sub()
                            MsgBox("Connect Voltage1-15V to Relay1-C and Power-3.3V with Relay1-NO ")
                            Pin.Relay(1) = False
                            Tools.Pause(1)
                            If Pin.Voltage(1).Value > 10 Then Throw New Exception("Voltage >0 while must be not connected")
                            Pin.Relay(1) = True
                            Tools.Pause(1)
                            If Pin.Voltage(1).Value < 200 Then Throw New Exception("Voltage <3V while must be connected")
                            MsgBox("Connect Voltage1-15V to Relay1-C and Power-3.3V with Relay1-NC ")
                            If Pin.Voltage(1).Value > 10 Then Throw New Exception("Voltage >0 while must be not connected")
                            Pin.Relay(1) = False
                            Tools.Pause(1)
                            If Pin.Voltage(1).Value < 200 Then Throw New Exception("Voltage <3V while must be connected")
                        End Sub)
    End Sub

    Private Sub Button26_Click(sender As Object, e As EventArgs) Handles Button26.Click, Button25.Click, Button24.Click, Button23.Click, Button22.Click, Button21.Click, Button20.Click, Button19.Click, Button18.Click, Button17.Click, Button16.Click, Button15.Click
        Dim dgt = CInt(Val(sender.text))
        If dgt = 0 Then dgt = 1
        RunTest(sender, Sub()

                            If dgt = 1 Then MsgBox("Connect Voltage 1 - 15V with Digital " + dgt.ToString)
                            Pin.Digital(dgt).SetHigh()
                            Tools.Pause(1)
                            TestVoltage(315, 40, Pin.Voltage(1).Raw)
                            Pin.Digital(dgt).SetLow()
                            Tools.Pause(1)
                            TestVoltage(0, 5, Pin.Voltage(1).Raw)
                        End Sub)
    End Sub
End Class