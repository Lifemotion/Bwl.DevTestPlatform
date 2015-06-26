Imports Bwl.Hardware.SimplSerial.SimplSerialBus

Public Class ProdAppBase
    Protected _logger As Logger
    Protected _devTest As DevTestPlatform
    Protected _runTestAbort As Boolean = False
    Protected _runTestOk As Boolean = False

    Public Sub New(logger As Logger, devtest As DevTestPlatform)
        InitializeComponent()
        _devTest = devtest
        _logger = logger
        _logger.ConnectWriter(DatagridLogWriter1)
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
        If waitAfter > 0 Then Tools.Wait(waitAfter)
    End Sub

    Public Sub WaitUntilTrue(delegate0 As Tools.Sub0, Optional delayMs As Integer = 100)
        Do
            Try
                delegate0.Invoke()
                Return
            Catch ex As Exception
                _logger.AddWarning(ex.Message)
                Tools.Wait(100)
            End Try
            If _runTestAbort Then Throw New Exception("Операция прервана")
        Loop
    End Sub

    Public Sub RunTest(control As Control, testSub As Tools.Sub0)
        RunOperation(control, testSub)
    End Sub

    Public Sub RunOperation(control As Control, testSub As Tools.Sub0)
        _runTestAbort = False
        selectedOperaionGroup.Visible = True
        selectedOperaionGroup.Text = "Операция: " + control.Text
        control.BackColor = Drawing.Color.Yellow
        Do While _runTestAbort = False
            Try
                testSub.Invoke()
                _runTestOk = True
                _runTestAbort = True
            Catch ex As Exception
                _logger.AddError("Операция: " + control.Text + " - " + ex.Message)
                _runTestOk = False
                Tools.Wait(500)
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
                          selectedOperaionGroup.Visible = False
                      End If
                  End Sub)
    End Sub

    Private Sub ProdAppBase_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class