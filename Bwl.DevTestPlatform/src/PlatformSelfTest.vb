Imports Bwl.Hardware.SimplSerial.SimplSerialBus
Imports Bwl.Hardware.SimplSerial

Public Class PlatformSelfTest
    Inherits ProdAppBase

    Public Sub New(logger As Logger, ss As SimplSerialBus, devtest As DevTestPlatform)
        MyBase.New(logger, devtest)
        InitializeComponent()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        RunTest(sender, Sub()
                            If _devTest.IntSSerial.RequestDeviceInfo(0).DeviceName.Contains("BwlBoot") = True Then Throw New Exception("Bootloader mode: upload main firmware!")
                            If _devTest.IntSSerial.RequestDeviceInfo(0).DeviceName.Contains("DevTestPlatform") = False Then Throw New Exception("Bad SS DeviceName")
                        End Sub)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        RunTest(sender, Sub()
                            Message("Проверка наличия всех портов")
                            If _devTest.PortMCU Is Nothing OrElse _devTest.PortMCU.Length < 3 Then Throw New Exception("Bad Core Port")
                            If _devTest.Port232 Is Nothing OrElse _devTest.Port232.Length < 3 Then Throw New Exception("Bad 232 Port")
                            If _devTest.Port485 Is Nothing OrElse _devTest.Port485.Length < 3 Then Throw New Exception("Bad 485 Port")
                            If _devTest.PortUART Is Nothing OrElse _devTest.PortUART.Length < 3 Then Throw New Exception("Bad UART Port")
                        End Sub)
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        RunTest(sender, Sub()
                            Message("Close UART port before. Connect UART TX with RX")
                            Tools.Wait(2000)
                            WaitUntilNoError(Sub() Tests.TestPort(New IO.Ports.SerialPort(_devTest.PortUART, 9600), True))
                            WaitUntilNoError(Sub() Tests.TestPort(New IO.Ports.SerialPort(_devTest.PortUART, 115200), True))
                            Message("Disconnect UART TX and RX")
                            Tools.Wait(2000)
                            WaitUntilNoError(Sub() Tests.TestPort(New IO.Ports.SerialPort(_devTest.PortUART, 9600), False))
                        End Sub)
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        RunTest(sender, Sub()
                            Message("Close RS-232 port before. Connect RS-232 TX with RX")
                            Tools.Wait(2000)
                            WaitUntilNoError(Sub() Tests.TestPort(New IO.Ports.SerialPort(_devTest.Port232, 9600), True))
                            WaitUntilNoError(Sub() Tests.TestPort(New IO.Ports.SerialPort(_devTest.Port232, 115200), True))
                            Message("Disconnect RS-232 TX and RX")
                            Tools.Wait(2000)
                            WaitUntilNoError(Sub() Tests.TestPort(New IO.Ports.SerialPort(_devTest.Port232, 9600), False))
                        End Sub)
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        RunTest(sender, Sub()
                            Message("Close RS-485 and UART and RS-232 port before. Connect RS-485 B with UART TX")
                            Tools.Wait(2000)
                            WaitUntilNoError(Sub() Tests.TestPort(New IO.Ports.SerialPort(_devTest.PortUART, 9600), New IO.Ports.SerialPort(_devTest.Port485, 9600), True))
                            Message("Connect RS-485 B with UART RX")
                            Tools.Wait(2000)
                            WaitUntilNoError(Sub() Tests.TestPort(New IO.Ports.SerialPort(_devTest.Port485, 9600), New IO.Ports.SerialPort(_devTest.PortUART, 9600), True))
                            Message("Connect RS-485 A with RS-232 RX")
                            Tools.Wait(2000)
                            WaitUntilNoError(Sub() Tests.TestPort(New IO.Ports.SerialPort(_devTest.Port485, 9600), New IO.Ports.SerialPort(_devTest.Port232, 9600), True))
                            'TestPort(New IO.Ports.SerialPort(DevTest._port232, 115200), True)
                            'MsgBox("Disconnect RS-232 TX and RX")
                            'TestPort(New IO.Ports.SerialPort(DevTest._port232, 9600), False)
                        End Sub)
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        RunTest(sender, Sub()
                            Message("Connect Voltage 1 - 15V with POWER 3.3V", 3000)
                            WaitUntilNoError(Sub() Tests.TestVoltage(205, 10, Pin.Voltage(1).Raw))
                        End Sub)
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        RunTest(sender, Sub()
                            Message("Connect Voltage 1 - 5V with POWER 3.3V", 3000)
                            WaitUntilNoError(Sub() Tests.TestVoltage(630, 20, Pin.Voltage(1).Raw))
                        End Sub)
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        RunTest(sender, Sub()
                            Message("Connect Voltage 1 - 1V with POWER 3.3V", 3000)
                            WaitUntilNoError(Sub() Tests.TestVoltage(1023, 1, Pin.Voltage(1).Raw))
                        End Sub)
    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        RunTest(sender, Sub()
                            Message("Connect Voltage 2 - 15V with POWER 3.3V", 3000)
                            WaitUntilNoError(Sub() Tests.TestVoltage(205, 10, Pin.Voltage(2).Raw))
                        End Sub)
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        RunTest(sender, Sub()
                            Message("Connect Voltage 2 - 5V with POWER 3.3V", 3000)
                            WaitUntilNoError(Sub() Tests.TestVoltage(630, 20, Pin.Voltage(2).Raw))
                        End Sub)
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        RunTest(sender, Sub()
                            Message("Connect Voltage 2 - 1V with POWER 3.3V", 3000)
                            WaitUntilNoError(Sub() Tests.TestVoltage(1023, 1, Pin.Voltage(2).Raw))
                        End Sub)
    End Sub

    Private Sub Button14_Click(sender As Object, e As EventArgs) Handles Button14.Click
        RunTest(sender, Sub()
                            Message("Connect Current 1 - 3A to external 200mA source", 3000)
                            WaitUntilNoError(Sub() Tests.TestVoltage(70, 20, Pin.Current(1).Raw))
                        End Sub)
    End Sub

    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click
        RunTest(sender, Sub()
                            Message("Connect Current 1 - 300mA to external 200mA source", 3000)
                            WaitUntilNoError(Sub() Tests.TestVoltage(410, 50, Pin.Current(1).Raw))
                        End Sub)
    End Sub

    Private Sub Button13_Click(sender As Object, e As EventArgs) Handles Button13.Click
        RunTest(sender, Sub()
                            Message("Connect Voltage1-15V to Relay1-C and Power-3.3V with Relay1-NO ", 2000)
                            WaitUntilNoError(Sub()
                                              Pin.Relay(1) = False
                                              Tools.Wait(1000)
                                              If Pin.Voltage(1).Value > 10 Then Throw New Exception("Voltage >0 while must be not connected")

                                              Pin.Relay(1) = True
                                              Tools.Wait(1000)
                                              If Pin.Voltage(1).Value < 200 Then Throw New Exception("Voltage <3V while must be connected")
                                          End Sub)
                            Message("Connect Voltage1-15V to Relay1-C and Power-3.3V with Relay1-NC ", 2000)
                            WaitUntilNoError(Sub()
                                              If Pin.Voltage(1).Value > 10 Then Throw New Exception("Voltage >0 while must be not connected")
                                              Pin.Relay(1) = False
                                              Tools.Wait(1000)
                                              If Pin.Voltage(1).Value < 200 Then Throw New Exception("Voltage <3V while must be connected")
                                          End Sub)
                        End Sub)
    End Sub

    Private Sub Button26_Click(sender As Object, e As EventArgs) Handles Button26.Click, Button25.Click, Button24.Click, Button23.Click, Button22.Click, Button21.Click, Button20.Click, Button19.Click, Button18.Click, Button17.Click, Button16.Click, Button15.Click
        Dim dgt = CInt(Val(sender.text))
        If dgt = 0 Then dgt = 1
        RunTest(sender, Sub()
                            Message("Connect Voltage 1 - 15V with Digital " + dgt.ToString)
                            WaitUntilNoError(Sub()
                                              Pin.Digital(dgt).SetHigh()
                                              Tools.Wait(500)
                                              Tests.TestVoltage(315, 40, Pin.Voltage(1).Raw)
                                              Pin.Digital(dgt).SetLow()
                                              Tools.Wait(500)
                                              Tests.TestVoltage(0, 5, Pin.Voltage(1).Raw)
                                          End Sub)
                        End Sub)
    End Sub

    Private Sub SelfTest1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class