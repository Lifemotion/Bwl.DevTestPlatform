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
            Return _logger
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
        Tools.Logger = _logger.CreateChildLogger("TestApp")
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
                        Pin.Current(2).Raw = result.Data(2) * 256 + result.Data(3)
                        Pin.Current(1).Raw = result.Data(0) * 256 + result.Data(1)
                        Pin.Voltage(1).Raw = result.Data(4) * 256 + result.Data(5)
                        Pin.Voltage(2).Raw = result.Data(6) * 256 + result.Data(7)
                    End If

                    Dim result2 = IntSSerial.RequestPinsRead(0)

                    Me.Invoke(Sub() coreGroupbox.Enabled = True)

                    Pin.Digital(1).FromPort(result2.Port2, 3)
                    Pin.Digital(2).FromPort(result2.Port2, 2)
                    Pin.Digital(3).FromPort(result2.Port2, 1)
                    Pin.Digital(4).FromPort(result2.Port2, 0)
                    Pin.Digital(5).FromPort(result2.Port4, 7)
                    Pin.Digital(6).FromPort(result2.Port4, 6)
                    Pin.Digital(7).FromPort(result2.Port4, 5)
                    Pin.Digital(8).FromPort(result2.Port4, 4)
                    Pin.Digital(9).FromPort(result2.Port4, 3)
                    Pin.Digital(10).FromPort(result2.Port4, 2)
                    Pin.Digital(11).FromPort(result2.Port3, 5)
                    Pin.Digital(12).FromPort(result2.Port3, 4)
                    Pin.RefreshMark()

                    Dim pins As New SimplSerialBus.Pins
                    Dim changed As Boolean = False
                    changed = changed Or Pin.Digital(1).ChangeAndToPort(pins.Port2, 3)
                    changed = changed Or Pin.Digital(2).ChangeAndToPort(pins.Port2, 2)
                    changed = changed Or Pin.Digital(3).ChangeAndToPort(pins.Port2, 1)
                    changed = changed Or Pin.Digital(4).ChangeAndToPort(pins.Port2, 0)
                    changed = changed Or Pin.Digital(5).ChangeAndToPort(pins.Port4, 7)
                    changed = changed Or Pin.Digital(6).ChangeAndToPort(pins.Port4, 6)
                    changed = changed Or Pin.Digital(7).ChangeAndToPort(pins.Port4, 5)
                    changed = changed Or Pin.Digital(8).ChangeAndToPort(pins.Port4, 4)
                    changed = changed Or Pin.Digital(9).ChangeAndToPort(pins.Port4, 3)
                    changed = changed Or Pin.Digital(10).ChangeAndToPort(pins.Port4, 2)
                    changed = changed Or Pin.Digital(11).ChangeAndToPort(pins.Port3, 5)
                    changed = changed Or Pin.Digital(12).ChangeAndToPort(pins.Port3, 4)

                    If ((result2.Port3.PinDirection And 2) = 0) Or ((result2.Port3.PinOutput And 2) <> Pin.Relay(1)) Then
                        pins.Port3.PinDirection = pins.Port3.PinDirection Or 2
                        pins.Port3.PinSetMask = pins.Port3.PinSetMask Or 2
                        If Pin.Relay(1) Then pins.Port3.PinOutput = pins.Port3.PinOutput Or 2
                        changed = True
                    End If

                    If changed Then
                        IntSSerial.RequestPinsChange(0, pins)
                    End If

                    Me.Invoke(Sub()
                                  SyncLock statesList
                                      Do While statesList.Items.Count < 17
                                          statesList.Items.Add("")
                                      Loop
                                      statesList.Items(0) = "Current2 (USB) = " + Pin.Current(2).ToString
                                      statesList.Items(1) = "Current1   = " + Pin.Current(1).ToString
                                      statesList.Items(2) = "Voltage1   = " + Pin.Voltage(1).ToString
                                      statesList.Items(3) = "Voltage2   = " + Pin.Voltage(2).ToString

                                      statesList.Items(4) = "Digital1 = " + Pin.Digital(1).ToString
                                      statesList.Items(5) = "Digital2 = " + Pin.Digital(2).ToString
                                      statesList.Items(6) = "Digital3 = " + Pin.Digital(3).ToString
                                      statesList.Items(7) = "Digital4 = " + Pin.Digital(4).ToString

                                      statesList.Items(8) = "Digital5 = " + Pin.Digital(5).ToString
                                      statesList.Items(9) = "Digital6 = " + Pin.Digital(6).ToString
                                      statesList.Items(10) = "Digital7 = " + Pin.Digital(7).ToString
                                      statesList.Items(11) = "Digital8 = " + Pin.Digital(8).ToString

                                      statesList.Items(12) = "Digital9 = " + Pin.Digital(9).ToString
                                      statesList.Items(13) = "Digital10 = " + Pin.Digital(10).ToString
                                      statesList.Items(14) = "Digital11 = " + Pin.Digital(11).ToString
                                      statesList.Items(15) = "Digital12 = " + Pin.Digital(12).ToString

                                      statesList.Items(16) = "Relay1 = " + If(Pin.Relay(1).ToString, "on", "off")
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
        Dim tool = New SimplSerialTool(Bus.RS485_SS, New SettingsStorageRoot, New Logger)
        tool.Show()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim tool = New SimplSerialTool(IntSSerial, New SettingsStorageRoot, New Logger)
        tool.Show()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim tool = New SimplSerialTool(Nothing, New SettingsStorageRoot, New Logger)
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
        Dim tool = New SimplSerialTool(Bus.UART_SS, New SettingsStorageRoot, New Logger)
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
        If statesList.Text.Contains("Relay1 ") Then Pin.Relay(1) = Not Pin.Relay(1)
    End Sub

    Public Sub New()

        ' Этот вызов является обязательным для конструктора.
        InitializeComponent()

        ' Добавьте все инициализирующие действия после вызова InitializeComponent().

    End Sub
End Class
