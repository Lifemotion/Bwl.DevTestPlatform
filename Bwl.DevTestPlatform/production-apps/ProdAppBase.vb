Imports Bwl.Hardware.SimplSerial.SimplSerialBus
Imports System.Net
Imports Bwl.Hardware.SimplSerial

Public Class ProdAppBase
    Protected _logger As Logger
    Protected _devTest As DevTestPlatform
    Protected _runTestAbort As Boolean = False
    Protected _runTestOk As Boolean = False

    Public Sub CreateTestButtons(tests As ProdTest(), Optional numerate As Boolean = True)
        Dim btop As Integer = 30
        Dim index = 1
        For Each test In tests
            Dim button As New Button
            operationsGroup.Controls.Add(button)
            button.Left = 10
            button.Width = button.Parent.Width - button.Left * 2
            button.Top = btop
            button.Font = cycleNewDeviceButton.Font
            button.Height = 30
            btop += button.Height + 10
            If numerate Then button.Text = index.ToString + ". "
            button.Text += test.name
            button.TabIndex = index
            index += 1
            AddHandler button.Click, Sub(sender As Object, e As EventArgs)
                                         RunTest(sender, Sub()
                                                             test.testDelegate.Invoke()
                                                         End Sub)
                                     End Sub
        Next
    End Sub

    Public Event CreateTestsRequest(sender As ProdAppBase, tests As List(Of ProdTest))

    Public Sub New(logger As Logger, devtest As DevTestPlatform)
        InitializeComponent()
        _devTest = devtest
        _logger = logger
        _logger.ConnectWriter(DatagridLogWriter1)
    End Sub

    Public Sub New(devtest As DevTestPlatform)
        Me.New(New Logger, devtest)
    End Sub

    Public Sub New(hostname As String)
        Me.New(DevTestPlatform.Create(hostname))
    End Sub

    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub testCancel_Click(sender As Object, e As EventArgs) Handles testCancel.Click
        _runTestAbort = True
        _runTestOk = False
    End Sub

    Public Sub Message(text As String, Optional waitAfter As Integer = 0)
        Me.Invoke(Sub() testMsg.Text = text)
        Beep()
        If waitAfter > 0 Then Tools.Wait(waitAfter)
    End Sub

    Public Sub WaitUntilNoError(delegate0 As Tools.Sub0, Optional delayMs As Integer = 100)
        Do
            Try
                delegate0.Invoke()
                Return
            Catch ex As Exception
                _logger.AddWarning(ex.Message)
                Tools.Wait(10)
            End Try
            Application.DoEvents()
            If _runTestAbort Then Throw New Exception("Операция прервана")
        Loop
    End Sub

    Public Sub WaitUntilTrue(delegate0 As Tools.Function0Bool, Optional delayMs As Integer = 100)
        Do
            Try
                If delegate0.Invoke() Then Return
            Catch ex As Exception
                _logger.AddWarning(ex.Message)
            End Try
            Tools.Wait(10)
            Application.DoEvents()
            If _runTestAbort Then Throw New Exception("Операция прервана")
        Loop
    End Sub

    Public Sub RunTest(control As Control, testSub As Tools.Sub0)
        RunOperation(control, testSub)
    End Sub

    Public Property AutoRestartTest As Boolean = False

    Public Sub RunOperation(control As Control, testSub As Tools.Sub0)
        _runTestAbort = False
        selectedOperaionGroup.Visible = True
        selectedOperaionGroup.Text = "Операция: " + control.Text
        control.BackColor = Drawing.Color.FromArgb(255, 255, 150)
        Do While _runTestAbort = False
            Me.Invoke(Sub()
                          testMsg.Text = "Выполнение операции " + control.Text
                          testMsg.ForeColor = Color.DarkGreen
                      End Sub)
            Try
                testSub.Invoke()
                '   _logger.AddMessage("Операция выполнена: " + control.Text)
                _runTestOk = True
                _runTestAbort = True
            Catch ex As Exception
                _logger.AddError("Операция прервана: " + control.Text + " - " + ex.Message)
                _runTestOk = False
                Me.Invoke(Sub()
                              testMsg.ForeColor = Color.DarkRed
                              If testMsg.Text > "" Then testMsg.Text += vbCrLf + vbCrLf
                              testMsg.Text += ex.Message
                          End Sub)
                If AutoRestartTest Then
                    Tools.Wait(500)
                Else
                    _runTestAbort = True
                End If
            End Try
            Tools.Wait(1)
        Loop

        Me.Invoke(Sub()
                      If _runTestOk Then
                          _logger.AddMessage("Операция: " + control.Text + " - ok")
                          control.BackColor = Drawing.Color.LightGreen
                          selectedOperaionGroup.Visible = False
                          Tools.Wait(500)
                          Application.DoEvents()

                          Dim index = control.TabIndex + 1
                          For Each ctr As Control In operationsGroup.Controls
                              If TypeOf ctr Is Button AndAlso ctr.TabIndex = index Then
                                  Dim btn As Button = ctr
                                  btn.PerformClick()
                              End If
                          Next
                      Else
                          control.BackColor = Drawing.Color.Pink
                          ' selectedOperaionGroup.Visible = False
                      End If
                  End Sub)
    End Sub

    Private Sub checkPreparation_Tick(sender As Object, e As EventArgs) Handles checkPreparation.Tick
        If DesignMode Then Return
        If _devTest.Started Then
            checkPreparation.Stop()
            CheckPrepareStatus()
        End If
    End Sub

    Protected Event CheckPrepareRequest()

    Private Sub CheckPrepareStatus() Handles prepRestart.Click
        If DesignMode Then Return
        Try
            RaiseEvent CheckPrepareRequest()
            prepMsg.Text = "Все готово к работе"
            prepMsg.ForeColor = Drawing.Color.DarkGreen
            prepRestart.Visible = False
            operationsGroup.Enabled = True
            cycleGroup.Enabled = True
            ShowCurrentImage()
        Catch ex As Exception
            prepMsg.Text = ex.Message
            prepMsg.ForeColor = Drawing.Color.Red
            prepRestart.Visible = True
            cycleGroup.Enabled = False
            operationsGroup.Enabled = False
        End Try
    End Sub

    Protected Sub FlashOperation(ss As SimplSerialBus, file As String)
        Message("Загрузка программы через загрузчик", 100)
        Dim uploader As New FirmwareUploader(ss, _logger)
        Try
            ss.RequestGoToBootloader(0)
        Catch ex As Exception
        End Try
        uploader.RequestBootInfo(0)
        uploader.EraseAndFlashAll(0, FirmwareUploader.LoadFirmwareFromFile(file))
        Message("Прошивка завершена", 1000)
    End Sub

    Protected Sub RestartByRelayOperation(ss As SimplSerialBus, waitNoBoot As Boolean)
        Message("Отключение питания с помощью реле. Ожидание отключения...", 100)
        _runTestAbort = False
        Pin.Relay(1) = True
        Do While _runTestAbort = False
            Application.DoEvents()
            Dim result = ss.RequestWithRetries(New SSRequest(0, 254, {1, 2, 3}), 3)
            If result.ResponseState = ResponseState.errorTimeout Then Exit Do
        Loop
        Message("Включение питания с помощью реле. Ожидание включения...", 100)
        Pin.Relay(1) = False
        Do While _runTestAbort = False
            Application.DoEvents()
            Dim result = ss.RequestWithRetries(New SSRequest(0, 254, {1, 2, 3}), 3)
            If result.ResponseState = ResponseState.ok Then Exit Do
        Loop
        Message("Перезагрузка завершена", 500)

        If waitNoBoot Then WaitExitBootloader(ss)
    End Sub

    Public Sub WaitExitBootloader(ss As SimplSerialBus)
        Message("Ожидание выхода из загрузчика", 500)
        Do While _runTestAbort = False
            Application.DoEvents()
            Dim result = ss.RequestDeviceInfo(0)
            If result.Response.ResponseState = ResponseState.ok Then
                If result.DeviceName.ToLower.Contains("bwlboot") = False Then Return
            End If
        Loop
        Throw New Exception("Устройство все еще в режиме загрузчика и не перешло к исполнениею программы")
    End Sub

    Protected Sub RestartByUserPowerOperation(ss As SimplSerialBus)
        Message("Временно отключите питание. Ожидание отключения...", 100)
        _runTestAbort = False
        Do While _runTestAbort = False
            Application.DoEvents()
            Dim result = ss.RequestWithRetries(New SSRequest(0, 254, {1, 2, 3}), 3)
            If result.ResponseState = ResponseState.errorTimeout Then Exit Do
        Loop
        Message("Включите питание. Ожидание включение...", 100)
        Do While _runTestAbort = False
            Application.DoEvents()
            Dim result = ss.RequestWithRetries(New SSRequest(0, 254, {1, 2, 3}), 3)
            If result.ResponseState = ResponseState.ok Then Exit Do
        Loop
        Message("Перезагрузка завершена, устройство отвечает на запросы", 1000)
    End Sub

    Public Property DownloadFileMinimumSize = 1024

    Public Function DownloadFile(url As String, ext As String) As String
        Dim webClient = New WebClient
        Dim filename = Now.Ticks.ToString + ext
        webClient.DownloadFile(url, filename)
        Dim fi As New IO.FileInfo(filename)
        If fi.Length > DownloadFileMinimumSize Then Return fi.FullName
        Throw New Exception("Too short firmware (DownloadFileMinimumSize)")
    End Function

    Public Function DownloadFileFromBuildServer(repository As String, config As String, ext As String, Optional server As String = "http://dev.cleverflow.ru:8010/getbinary.ashx?id=#repository&conf=#config")
        Return DownloadFile(server.Replace("#repository", repository).Replace("#config", config), ext)
    End Function

    Public Sub CheckSimpleSerialDeviceNameOperation(ss As SimplSerialBus, name As String)
        Message("Запрос имени устройства у загрузчика", 100)
        Dim info = ss.RequestDeviceInfo(0)
        If info.Response.ResponseState <> Bwl.Hardware.SimplSerial.ResponseState.ok Then Throw New Exception("Устройство не отвечает (загрузчик)")
        If info.DeviceName.Contains(name) = False Then Throw New Exception("Устройство имеет неверное имя: " + info.DeviceName)
    End Sub
    Public Sub FinalizeOperation()
        Message("Устройство проверено и готово. Промаркируйте его как прошедшее тест.")
        WaitForNextButton()
    End Sub

    Private Sub infoPicture_Click(sender As Object, e As EventArgs) Handles infoPicture.Click
        _pics.CurrentIndex += 1
        ShowCurrentImage()
    End Sub

    Private Sub ShowCurrentImage()
        If DesignMode Then Return
        Try
            If _pics.CurrentIndex >= _pics.Count Then _pics.CurrentIndex = 0
            infoPicture.Image = _pics(_pics.CurrentIndex)
            infoPicture.Refresh()
            infoImageName.Text = _pics(_pics.CurrentIndex).Tag + " (" + (_pics.CurrentIndex + 1).ToString + " из " + (_pics.Count).ToString + ")"
            imageGroup.Visible = True
        Catch ex As Exception
            imageGroup.Visible = False
        End Try
    End Sub

    Private Sub infoPicture_DoubleClick(sender As Object, e As EventArgs) Handles infoPicture.DoubleClick
    End Sub

    Private Sub ProdAppBase_DoubleClick(sender As Object, e As EventArgs) Handles Me.DoubleClick
        If My.Computer.Keyboard.ShiftKeyDown Then _devTest.Show()
    End Sub

    Private Sub ProdAppBase_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim tests As New List(Of ProdTest)
        If DesignMode Then Return
        RaiseEvent CreateTestsRequest(Me, tests)
        CreateTestButtons(tests.ToArray)
    End Sub

    Private Sub ProdAppBase_MouseClick(sender As Object, e As MouseEventArgs) Handles Me.MouseClick
        If My.Computer.Keyboard.ShiftKeyDown Then _devTest.Show()
    End Sub

    Protected _pics As New Pics

    Public Class Pics
        Inherits List(Of Bitmap)
        Public Property CurrentIndex As Integer = 0
        Public Sub Load(path As String)
            Me.Clear()
            Dim files = IO.Directory.GetFiles(path)
            For Each file In files
                Select Case IO.Path.GetExtension(file)
                    Case ".jpg", ".gif", ".png", ".bmp"
                        Try
                            Dim bmp As New Bitmap(file)
                            bmp.Tag = IO.Path.GetFileNameWithoutExtension(file)
                            If bmp.Width > 0 Then Add(bmp)
                        Catch ex As Exception
                        End Try
                End Select
            Next
        End Sub
    End Class

    Private Sub infoImageLabel_Click(sender As Object, e As EventArgs) Handles infoImageLabel.Click
        ShowImage.Create(infoPicture.Image).Show()
    End Sub

    Private Sub cycleNewDeviceButton_Click(sender As Object, e As EventArgs) Handles cycleNewDeviceButton.Click
        For Each ctr As Control In operationsGroup.Controls
            If TypeOf ctr Is Button Then
                ctr.BackColor = SystemColors.Control
            End If
        Next
    End Sub

    Private _nextPressed As Boolean

    Public Sub WaitForNextButton(Optional msg As String = "")
        testNext.Visible = True
        _nextPressed = False
        buttonCorrect.Visible = False
        buttonUncorrect.Visible = False
        If msg > "" Then Message(msg)

        Do While _nextPressed = False
            Application.DoEvents()
            If _runTestAbort Then
                testNext.Visible = False
                buttonCorrect.Visible = False
                buttonUncorrect.Visible = False
                Throw New Exception("Ожидание прервано")
            End If
        Loop
        testNext.Visible = False
        buttonCorrect.Visible = False
        buttonUncorrect.Visible = False
    End Sub

    Public Function WaitForCorrectIncorrect(msg As String, Optional exceptionText As String = "") As Boolean
        If msg > "" Then Message(msg)
        testNext.Visible = False
        buttonCorrect.Visible = True
        buttonUncorrect.Visible = True
        _correctMark = 0
        Do
            Application.DoEvents()
            If _correctMark > 0 Then
                testNext.Visible = False
                buttonCorrect.Visible = False
                buttonUncorrect.Visible = False
                Return True
            End If
            If _correctMark < 0 And exceptionText > "" Then
                testNext.Visible = False
                buttonCorrect.Visible = False
                buttonUncorrect.Visible = False
                Throw New Exception(exceptionText)
            End If
            If _correctMark < 0 Then
                testNext.Visible = False
                buttonCorrect.Visible = False
                buttonUncorrect.Visible = False
                Return False
            End If
            If _runTestAbort Then
                testNext.Visible = False
                buttonCorrect.Visible = False
                buttonUncorrect.Visible = False
                Throw New Exception("Ожидание прервано")
            End If
        Loop
        testNext.Visible = False
        buttonCorrect.Visible = False
        buttonUncorrect.Visible = False
    End Function

    Private _correctMark As Integer = 0
    Private Sub testNext_Click(sender As Object, e As EventArgs) Handles testNext.Click
        _nextPressed = True
    End Sub

    Private Sub buttonCorrect_Click(sender As Object, e As EventArgs) Handles buttonCorrect.Click
        _correctMark = 1
    End Sub

    Private Sub buttonUncorrect_Click(sender As Object, e As EventArgs) Handles buttonUncorrect.Click
        _correctMark = -1
    End Sub
End Class