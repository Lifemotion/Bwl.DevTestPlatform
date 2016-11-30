Imports System.CodeDom.Compiler
Imports Bwl.DevTestPlatform
Imports Bwl.Hardware.SimplSerial

Public Class DevTestPlatform
    Inherits FormAppBase
    Private _thread As New Threading.Thread(AddressOf ProcessThread)
    Private _platformInterface As New Pin
    Private _testBoxInfo As DeviceInfo

    Public Property IntSSerial As SimplSerialBus
    Public Property PortMCU As String = ""
    Public Property Port232 As String = ""
    Public Property Port485 As String = ""
    Public Property PortUART As String = ""
    Public Property Started As Boolean = False
    Public Event CoreReady(sender As DevTestPlatform)

    Public ReadOnly Property Logger As Logger
        Get
            'Return _logger
            Return Nothing
        End Get
    End Property

    Public ReadOnly Property Storage As SettingsStorageRoot
        Get
            Return _storage
        End Get
    End Property

    Public Shared Function Create(hostName As String) As DevTestPlatform
        Application.EnableVisualStyles()
        Dim form As New DevTestPlatform
        If hostName > "" Then form.Text = hostName + ": (embedded in external app)" + form.Text
        form.Show()
        Return form
    End Function

    Private Sub DevTest_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Try
            _thread.Abort()
            Application.Exit()
        Catch ex As Exception
        End Try
        End
    End Sub

    Private Sub DevTest_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Tools.Log = _logger.CreateChildLogger("TestApp")
        _thread.IsBackground = True
        _thread.Start()
        Me.Text += " SW:" + Application.ProductVersion + " FW:#"
    End Sub

    Public Sub CheckDevTestPlatformPresent()
        If Present = False Then Throw New Exception("Не обнаружена тестовая коробка (DevTestPlatform not found)")
    End Sub

    Sub ProcessThread()
        Dim ports As FTD2XX_NET.FTDI.FT_DEVICE_INFO_NODE() = {}
        Do
            If Port485 = "" Then
                Try
                    Port485 = FTDIFunctions.DetectFtdiSystemPortName(FTDIFunctions.GetFtdiPort(ports, "USB RS485"))
                    Me.Invoke(Sub() rs485portLabel.Text = Port485)
                    Bus.RS485.DeviceAddress = Port485
                    Bus.RS485.DeviceSpeed = 9600
                    If Port485 > "" Then
                        Bus.RS485.Connect()
                        _logger.AddMessage("TestBox RS-485: " + Port485)
                        Me.Invoke(Sub() rs485Groupbox.Enabled = True)
                    End If
                Catch ex As Exception
                    Port485 = ""
                    _logger.AddError("RS-485: " + ex.Message)
                End Try
            Else
                Me.Invoke(Sub() rs485CheckboxOpened.Checked = Bus.RS485.IsConnected)
            End If

            If Port232 = "" Then
                Try
                    Port232 = FTDIFunctions.DetectFtdiSystemPortName(FTDIFunctions.GetFtdiPort(ports, "USB RS232"))
                    Me.Invoke(Sub() rs232portLabel.Text = Port232)
                    Bus.UART.DeviceAddress = Port232
                    Bus.UART.DeviceSpeed = 9600
                    If Port232 > "" Then
                        Bus.UART.Connect()
                        _logger.AddMessage("TestBox RS232: " + Port232)
                        Me.Invoke(Sub() rs232Groupbox.Enabled = True)
                    End If
                Catch ex As Exception
                    Port232 = ""
                    _logger.AddError("RS232: " + ex.Message)
                End Try
            Else
                Me.Invoke(Sub() rs232CheckboxOpened.Checked = Bus.RS232.IsConnected)
            End If

            If PortUART = "" Then
                Try
                    PortUART = FTDIFunctions.DetectFtdiSystemPortName(FTDIFunctions.GetFtdiPort(ports, "USB TB-UART"))
                    '       If PortUART = "" Then PortUART = FTDIFunctions.DetectFtdiSystemPortName(FTDIFunctions.GetFtdiPort(ports, "USB UART"))
                    Me.Invoke(Sub() uartPortLabel.Text = PortUART)
                    Bus.UART.DeviceAddress = PortUART
                    Bus.UART.DeviceSpeed = 9600
                    If PortUART > "" Then
                        Bus.UART.Connect()
                        _logger.AddMessage("TestBox UART: " + PortUART)
                        Me.Invoke(Sub() uartGroupbox.Enabled = True)
                    End If
                Catch ex As Exception
                    PortUART = ""
                    _logger.AddError("UART: " + ex.Message)
                End Try
            Else
                Me.Invoke(Sub() uartCheckboxOpened.Checked = Bus.UART.IsConnected)
            End If

            If PortMCU = "" Then
                Try
                    ports = FTDIFunctions.GetFtdiPorts
                    PortMCU = FTDIFunctions.DetectFtdiSystemPortName(FTDIFunctions.GetFtdiPort(ports, "USB MCU"))
                    If PortMCU > "" Then
                        _logger.AddMessage("TestBox Core:   " + PortMCU)
                        IntSSerial = New SimplSerialBus(PortMCU)
                        IntSSerial.SerialDevice.Connect()
                        _testBoxInfo = IntSSerial.RequestDeviceInfo(0)
                        If _testBoxInfo.DeviceName.Contains("DevTestPlatform") Then
                            _logger.AddMessage("FW Name: " + _testBoxInfo.DeviceName.Trim)
                            _logger.AddMessage("FW Date: " + _testBoxInfo.DeviceDate.Trim)
                            Me.Invoke(Sub() Me.Text = Me.Text.Replace("#", _testBoxInfo.DeviceDate))
                            _logger.AddMessage("Started!")
                            Started = True
                            RaiseEvent CoreReady(Me)
                        Else
                            _testBoxInfo = Nothing
                            IntSSerial.Disconnect()
                            Throw New Exception("Bad device name, not testbox")
                        End If
                    End If
                Catch ex As Exception
                    PortMCU = ""
                    _logger.AddError("TestBox Core not found \ not open: " + PortMCU)
                    Threading.Thread.Sleep(5000)
                End Try
            Else

                Try
                    Dim result = IntSSerial.Request(New SSRequest(0, 11, {}))
                    If result.ResponseState = ResponseState.ok Then
                        Pin.Voltage(1).Raw = result.Data(0) * 256 + result.Data(1)
                        Pin.Voltage(2).Raw = result.Data(2) * 256 + result.Data(3)
                        Pin.Voltage(3).Raw = result.Data(4) * 256 + result.Data(5)
                        Pin.Voltage(4).Raw = result.Data(6) * 256 + result.Data(7)
                        Pin.Voltage(5).Raw = result.Data(8) * 256 + result.Data(9)
                        Pin.Voltage(6).Raw = result.Data(10) * 256 + result.Data(11)
                        Pin.Voltage(7).Raw = result.Data(12) * 256 + result.Data(13)
                        Pin.Voltage(8).Raw = result.Data(14) * 256 + result.Data(15)

                        Pin.Current(1).Raw = result.Data(16) * 256 + result.Data(17)
                        Pin.Current(2).Raw = result.Data(18) * 256 + result.Data(19)
                        Pin.Current(3).Raw = result.Data(20) * 256 + result.Data(21)
                        Pin.Current(4).Raw = result.Data(22) * 256 + result.Data(23)

                    End If

                    Dim result2 = IntSSerial.RequestPortsRead(0)

                    Me.Invoke(Sub() coreGroupbox.Enabled = True)

                    Pin.Digital(1).FromPort(result2.PortB, 0)
                    Pin.Digital(2).FromPort(result2.PortB, 1)
                    Pin.Digital(3).FromPort(result2.PortB, 2)
                    Pin.Digital(4).FromPort(result2.PortB, 3)
                    Pin.Digital(5).FromPort(result2.PortB, 4)
                    Pin.Digital(6).FromPort(result2.PortB, 5)
                    Pin.Digital(7).FromPort(result2.PortB, 6)
                    Pin.Digital(8).FromPort(result2.PortB, 7)

                    Pin.Digital(9).FromPort(result2.PortA, 0)
                    Pin.Digital(10).FromPort(result2.PortA, 1)
                    Pin.Digital(11).FromPort(result2.PortA, 2)
                    Pin.Digital(12).FromPort(result2.PortA, 3)
                    Pin.Digital(13).FromPort(result2.PortA, 4)
                    Pin.Digital(14).FromPort(result2.PortA, 5)
                    Pin.Digital(15).FromPort(result2.PortA, 6)
                    Pin.Digital(16).FromPort(result2.PortA, 7)

                    Pin.Digital(17).FromPort(result2.PortE, 2)
                    Pin.Digital(18).FromPort(result2.PortE, 3)
                    Pin.Digital(19).FromPort(result2.PortE, 4)
                    Pin.Digital(20).FromPort(result2.PortE, 5)
                    Pin.Digital(21).FromPort(result2.PortE, 6)
                    Pin.Digital(22).FromPort(result2.PortE, 7)
                    Pin.Digital(23).FromPort(result2.PortH, 4)
                    Pin.Digital(24).FromPort(result2.PortH, 5)

                    Pin.RefreshMark()

                    Dim pins As New SimplSerialBus.Ports
                    Dim changed As Boolean = False
                    changed = changed Or Pin.Digital(1).ChangeAndToPort(pins.PortB, 0)
                    changed = changed Or Pin.Digital(2).ChangeAndToPort(pins.PortB, 1)
                    changed = changed Or Pin.Digital(3).ChangeAndToPort(pins.PortB, 2)
                    changed = changed Or Pin.Digital(4).ChangeAndToPort(pins.PortB, 3)
                    changed = changed Or Pin.Digital(5).ChangeAndToPort(pins.PortB, 4)
                    changed = changed Or Pin.Digital(6).ChangeAndToPort(pins.PortB, 5)
                    changed = changed Or Pin.Digital(7).ChangeAndToPort(pins.PortB, 6)
                    changed = changed Or Pin.Digital(8).ChangeAndToPort(pins.PortB, 7)

                    changed = changed Or Pin.Digital(9).ChangeAndToPort(pins.PortA, 0)
                    changed = changed Or Pin.Digital(10).ChangeAndToPort(pins.PortA, 1)
                    changed = changed Or Pin.Digital(11).ChangeAndToPort(pins.PortA, 2)
                    changed = changed Or Pin.Digital(12).ChangeAndToPort(pins.PortA, 3)
                    changed = changed Or Pin.Digital(13).ChangeAndToPort(pins.PortA, 4)
                    changed = changed Or Pin.Digital(14).ChangeAndToPort(pins.PortA, 5)
                    changed = changed Or Pin.Digital(15).ChangeAndToPort(pins.PortA, 6)
                    changed = changed Or Pin.Digital(16).ChangeAndToPort(pins.PortA, 7)

                    changed = changed Or Pin.Digital(17).ChangeAndToPort(pins.PortE, 2)
                    changed = changed Or Pin.Digital(18).ChangeAndToPort(pins.PortE, 3)
                    changed = changed Or Pin.Digital(19).ChangeAndToPort(pins.PortE, 4)
                    changed = changed Or Pin.Digital(20).ChangeAndToPort(pins.PortE, 5)
                    changed = changed Or Pin.Digital(21).ChangeAndToPort(pins.PortE, 6)
                    changed = changed Or Pin.Digital(22).ChangeAndToPort(pins.PortE, 7)
                    changed = changed Or Pin.Digital(23).ChangeAndToPort(pins.PortH, 4)
                    changed = changed Or Pin.Digital(24).ChangeAndToPort(pins.PortH, 5)

                    If ((result2.PortC.PinDirection And 2) = 0) Or ((result2.PortC.PinOutput And 2) <> Pin.Relay(1)) Then
                        pins.PortC.PinDirection = pins.PortC.PinDirection Or 2
                        pins.PortC.PinSetMask = pins.PortC.PinSetMask Or 2
                        If Pin.Relay(1) Then pins.PortC.PinOutput = pins.PortC.PinOutput Or 2
                        changed = True
                    End If

                    If changed Then
                        IntSSerial.RequestPortsChange(0, pins)
                    End If

                    Me.Invoke(Sub()
                                  SyncLock statesList
                                      Do While statesList.Items.Count < 36
                                          statesList.Items.Add("")
                                      Loop
                                      statesList.Items(0) = "Current1_1 = " + Pin.Current(1).ToString
                                      statesList.Items(1) = "Current1_2   = " + Pin.Current(2).ToString
                                      statesList.Items(2) = "Current2_1 = " + Pin.Current(3).ToString
                                      statesList.Items(3) = "Current2_2   = " + Pin.Current(4).ToString
                                      statesList.Items(4) = "Voltage1   = " + Pin.Voltage(1).ToString
                                      statesList.Items(5) = "Voltage2   = " + Pin.Voltage(2).ToString
                                      statesList.Items(6) = "Voltage3   = " + Pin.Voltage(3).ToString
                                      statesList.Items(7) = "Voltage4   = " + Pin.Voltage(4).ToString
                                      statesList.Items(8) = "Voltage5   = " + Pin.Voltage(5).ToString
                                      statesList.Items(9) = "Voltage6   = " + Pin.Voltage(6).ToString
                                      statesList.Items(10) = "Voltage7   = " + Pin.Voltage(7).ToString
                                      statesList.Items(11) = "Voltage8   = " + Pin.Voltage(8).ToString

                                      statesList.Items(12) = "Digital1 = " + Pin.Digital(1).ToString
                                      statesList.Items(13) = "Digital2 = " + Pin.Digital(2).ToString
                                      statesList.Items(14) = "Digital3 = " + Pin.Digital(3).ToString
                                      statesList.Items(15) = "Digital4 = " + Pin.Digital(4).ToString

                                      statesList.Items(16) = "Digital5 = " + Pin.Digital(5).ToString
                                      statesList.Items(17) = "Digital6 = " + Pin.Digital(6).ToString
                                      statesList.Items(18) = "Digital7 = " + Pin.Digital(7).ToString
                                      statesList.Items(19) = "Digital8 = " + Pin.Digital(8).ToString

                                      statesList.Items(20) = "Digital9 = " + Pin.Digital(9).ToString
                                      statesList.Items(21) = "Digital10 = " + Pin.Digital(10).ToString
                                      statesList.Items(22) = "Digital11 = " + Pin.Digital(11).ToString
                                      statesList.Items(23) = "Digital12 = " + Pin.Digital(12).ToString

                                      statesList.Items(24) = "Digital13 = " + Pin.Digital(13).ToString
                                      statesList.Items(25) = "Digital14 = " + Pin.Digital(14).ToString
                                      statesList.Items(26) = "Digital15 = " + Pin.Digital(15).ToString
                                      statesList.Items(27) = "Digital16 = " + Pin.Digital(16).ToString

                                      statesList.Items(28) = "Digital17 = " + Pin.Digital(17).ToString
                                      statesList.Items(29) = "Digital18 = " + Pin.Digital(18).ToString
                                      statesList.Items(30) = "Digital9 = " + Pin.Digital(19).ToString
                                      statesList.Items(31) = "Digital20 = " + Pin.Digital(20).ToString

                                      statesList.Items(32) = "Digital21 = " + Pin.Digital(21).ToString
                                      statesList.Items(33) = "Digital22 = " + Pin.Digital(22).ToString
                                      statesList.Items(34) = "Digital23 = " + Pin.Digital(23).ToString

                                      statesList.Items(35) = "Digital24 = " + Pin.Digital(24).ToString

                                  End SyncLock
                              End Sub)
                Catch ex As InvalidOperationException
                    _testBoxInfo = Nothing
                    PortMCU = ""
                Catch ex As Exception

                End Try
            End If
            Threading.Thread.Sleep(100)
        Loop
    End Sub

    Public Function GetSerialPortsExceptTestbox() As String()
        Dim ports As New List(Of String)(IO.Ports.SerialPort.GetPortNames)
        ports.Remove(Port232)
        ports.Remove(Port485)
        ports.Remove(PortMCU)
        ports.Remove(PortUART)
        Return ports.ToArray
    End Function

    Public ReadOnly Property Present As Boolean
        Get
            Return _testBoxInfo IsNot Nothing
        End Get
    End Property

    Public ReadOnly Property TestBoxInfo As DeviceInfo
        Get
            Return _testBoxInfo
        End Get
    End Property

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim tool = New SimplSerialTool(Bus.RS485_SS)
        tool.Show()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim tool = New SimplSerialTool(IntSSerial)
        tool.Show()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim tool = New SimplSerialTool(Nothing)
        tool.Show()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim f As New PlatformSelfTest(New Logger, IntSSerial, Me)
        f.Show()
    End Sub

    Private Sub CheckBox1_Click(sender As Object, e As EventArgs) Handles rs485CheckboxOpened.Click
        Try
            If rs485CheckboxOpened.Checked Then Bus.RS485.Connect() Else Bus.RS485.Disconnect()
        Catch ex As Exception
            _logger.AddError(ex.Message)
        End Try
    End Sub

    Private Sub CheckBox2_CheckedChanged(sender As Object, e As EventArgs) Handles uartCheckboxOpened.CheckedChanged
        Try
            If uartCheckboxOpened.Checked Then Bus.UART.Connect() Else Bus.UART.Disconnect()
        Catch ex As Exception
            _logger.AddError(ex.Message)
        End Try
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Dim tool = New SimplSerialTool(Bus.UART_SS)
        tool.Show()
    End Sub

    Private Sub statesList_DoubleClick(sender As Object, e As EventArgs) Handles statesList.DoubleClick
        If statesList.Text.Contains("Digital1 ") Then PinState.Request(Pin.Digital(1))
        If statesList.Text.Contains("Digital2 ") Then PinState.Request(Pin.Digital(2))
        If statesList.Text.Contains("Digital3 ") Then PinState.Request(Pin.Digital(3))
        If statesList.Text.Contains("Digital4 ") Then PinState.Request(Pin.Digital(4))
        If statesList.Text.Contains("Digital5 ") Then PinState.Request(Pin.Digital(5))
        If statesList.Text.Contains("Digital6 ") Then PinState.Request(Pin.Digital(6))
        If statesList.Text.Contains("Digital7 ") Then PinState.Request(Pin.Digital(7))
        If statesList.Text.Contains("Digital8 ") Then PinState.Request(Pin.Digital(8))
        If statesList.Text.Contains("Digital9 ") Then PinState.Request(Pin.Digital(9))
        If statesList.Text.Contains("Digital10 ") Then PinState.Request(Pin.Digital(10))
        If statesList.Text.Contains("Digital11 ") Then PinState.Request(Pin.Digital(11))
        If statesList.Text.Contains("Digital12 ") Then PinState.Request(Pin.Digital(12))
        If statesList.Text.Contains("Digital13 ") Then PinState.Request(Pin.Digital(13))
        If statesList.Text.Contains("Digital14 ") Then PinState.Request(Pin.Digital(14))
        If statesList.Text.Contains("Digital15 ") Then PinState.Request(Pin.Digital(15))
        If statesList.Text.Contains("Digital16 ") Then PinState.Request(Pin.Digital(16))
        If statesList.Text.Contains("Digital17 ") Then PinState.Request(Pin.Digital(17))
        If statesList.Text.Contains("Digital18 ") Then PinState.Request(Pin.Digital(18))
        If statesList.Text.Contains("Digital19 ") Then PinState.Request(Pin.Digital(19))
        If statesList.Text.Contains("Digital20 ") Then PinState.Request(Pin.Digital(20))
        If statesList.Text.Contains("Digital21 ") Then PinState.Request(Pin.Digital(21))
        If statesList.Text.Contains("Digital22 ") Then PinState.Request(Pin.Digital(22))
        If statesList.Text.Contains("Digital23 ") Then PinState.Request(Pin.Digital(23))
        If statesList.Text.Contains("Digital24 ") Then PinState.Request(Pin.Digital(24))
    End Sub

    Public Sub New()

        ' Этот вызов является обязательным для конструктора.
        InitializeComponent()

        ' Добавьте все инициализирующие действия после вызова InitializeComponent().

    End Sub
End Class
