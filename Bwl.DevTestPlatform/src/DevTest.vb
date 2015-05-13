﻿Imports System.CodeDom.Compiler
Imports Bwl.DevTestPlatform
Imports FTD2XX_NET
Public Class DevTest
    Inherits FormAppBase
    Public _sserial As SimplSerialBus
    Private _thread As New Threading.Thread(AddressOf ProcessThread)
    Private _platformInterface As New Pin
    Private _template As String
    Public _portMCU As String
    Public _port232 As String
    Public _port485 As String
    Public _portUART As String

    Private Function GetComPortByName(name As String) As String
        Dim ftdi As New FTDI
        Dim list(32) As FTDI.FT_DEVICE_INFO_NODE
        ftdi.GetDeviceList(list)
        For Each dev In list
            If dev IsNot Nothing Then
                If dev.Description.ToLower.Contains(name.ToLower) Then
                    Dim com As String = "COM000"
                    ftdi.OpenBySerialNumber(dev.SerialNumber)
                    ftdi.GetCOMPort(com)
                    ftdi.Close()
                    Return com
                End If
            End If
        Next
        ftdi.Close()
        Return "not found"
    End Function

    Private Sub DevTest_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        _thread.Abort()

    End Sub

    Private Sub DevTest_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Tools.Logger = _logger.CreateChildLogger("TestApp")
        _template = IO.File.ReadAllText("TestProgram.vb")
        Try
            '     TextBox1.Text = IO.File.ReadAllText("test.vb")
        Catch ex As Exception
        End Try
        _thread.IsBackground = True
        _thread.Start()
        CodeExecutor2.Logger = _logger
        CodeExecutor1.ImportsList.Add("Bwl.DevTestPlatform")
        CodeExecutor1.ImportsList.Add("Bwl.DevTestPlatform.Pin")
        CodeExecutor1.ImportsList.Add("Bwl.DevTestPlatform.Bus")
        CodeExecutor1.ImportsList.Add("Bwl.DevTestPlatform.Tools")
        Me.Text += " SW:" + Application.ProductVersion + " FW:#"
        CodeExecutor1.ReferencesList.Add(IO.Path.GetFileName(Application.ExecutablePath))
    End Sub

    Sub ProcessThread()
        Do
            If _port485 = "" Then
                Try
                    _port485 = GetComPortByName("USB RS485")
                    Me.Invoke(Sub() rs485portLabel.Text = _port485)
                    Bus.RS485.DeviceAddress = _port485
                    Bus.RS485.DeviceSpeed = 9600
                    Bus.RS485.Connect()
                    _logger.AddMessage("TestBox RS-485: " + _port485)
                    Me.Invoke(Sub() rs485Groupbox.Enabled = True)
                Catch ex As Exception
                    _port485 = ""
                    _logger.AddError("RS-485: " + ex.Message)
                End Try
            Else
                Me.Invoke(Sub() rs485CheckboxOpened.Checked = Bus.RS485.IsConnected)
            End If

            If _port232 = "" Then
                Try
                    _port232 = GetComPortByName("USB RS232")
                    Me.Invoke(Sub() uartPortLabel.Text = _port232)
                    Bus.UART.DeviceAddress = _port232
                    Bus.UART.DeviceSpeed = 9600
                    Bus.UART.Connect()
                    _logger.AddMessage("TestBox RS232: " + _port232)
                    Me.Invoke(Sub() uartGroupbox.Enabled = True)
                Catch ex As Exception
                    _port232 = ""
                    _logger.AddError("RS232: " + ex.Message)
                End Try
            Else
                Me.Invoke(Sub() uartCheckboxOpened.Checked = Bus.UART.IsConnected)
            End If

            If _portUART = "" Then
                Try
                    _portUART = GetComPortByName("USB UART")
                    Me.Invoke(Sub() uartPortLabel.Text = _portUART)
                    Bus.UART.DeviceAddress = _portUART
                    Bus.UART.DeviceSpeed = 9600
                    Bus.UART.Connect()
                    _logger.AddMessage("TestBox UART: " + _portUART)
                    Me.Invoke(Sub() uartGroupbox.Enabled = True)
                Catch ex As Exception
                    _portUART = ""
                    _logger.AddError("UART: " + ex.Message)
                End Try
            Else
                Me.Invoke(Sub() uartCheckboxOpened.Checked = Bus.UART.IsConnected)
            End If

            If _portMCU = "" Then
                Try
                    _portMCU = GetComPortByName("USB MCU")
                    _logger.AddMessage("TestBox Core:   " + _portMCU)
                    _sserial = New SimplSerialBus(_portMCU)
                    _sserial.SerialDevice.Connect()
                    Dim info = _sserial.RequestDeviceInfo(0)
                    _logger.AddMessage("FW Name: " + info.DeviceName.Trim)
                    _logger.AddMessage("FW Date: " + info.DeviceDate.Trim)
                    Me.Invoke(Sub() Me.Text = Me.Text.Replace("#", info.DeviceDate))
                    _logger.AddMessage("Started!")
                Catch ex As Exception
                    _portMCU = ""
                    _logger.AddError("TestBox Core not found \ not open: " + _portMCU)
                    Threading.Thread.Sleep(5000)
                End Try
            Else
                Try
                    Dim result = _sserial.Request(New SSRequest(0, 11, {}))
                    If result.ResponseState = ResponseState.ok Then
                        Pin.Current(2).Raw = result.Data(2) * 256 + result.Data(3)
                        Pin.Current(1).Raw = result.Data(0) * 256 + result.Data(1)
                        Pin.Voltage(1).Raw = result.Data(4) * 256 + result.Data(5)
                        Pin.Voltage(2).Raw = result.Data(6) * 256 + result.Data(7)
                    End If

                    Dim result2 = _sserial.RequestPinsRead(0)

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

                    If (result2.Port3.PinDirection And 2 = 0) Or (result2.Port3.PinOutput And 2 <> Pin.Relay(1)) Then
                        pins.Port3.PinDirection = pins.Port3.PinDirection Or 2
                        pins.Port3.PinSetMask = pins.Port3.PinSetMask Or 2
                        If Pin.Relay(1) Then pins.Port3.PinOutput = pins.Port3.PinOutput Or 2
                        changed = True
                    End If

                    If changed Then
                        _sserial.RequestPinsChange(0, pins)
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
                    _portMCU = ""
                Catch ex As Exception

                End Try
            End If
            Threading.Thread.Sleep(100)
        Loop
    End Sub


    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim tool = New SimplSerialTool(Bus.RS485_SS, New SettingsStorageRoot, New Logger)
        tool.Show()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim tool = New SimplSerialTool(_sserial, New SettingsStorageRoot, New Logger)
        tool.Show()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim tool = New SimplSerialTool(Nothing, New SettingsStorageRoot, New Logger)
        tool.Show()
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim f As New SelfTest(_logger, _sserial)
        f.Show()

    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles rs485CheckboxOpened.CheckedChanged

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

    Private Sub Button1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub CodeExecutor1_Load(sender As Object, e As EventArgs) Handles CodeExecutor1.Load

    End Sub
End Class
