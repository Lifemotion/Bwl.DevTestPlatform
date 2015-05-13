Public Class DigitalPin

    Private _directionOutput As Boolean = False
    Private _inputHigh As Boolean = False
    Private _outputHigh As Boolean = False

    Private _requestToChange As Boolean
    Private _requestedDirection As Boolean
    Private _requestedOutput As Boolean

    Public ReadOnly Property DirectionOutput As Boolean
        Get
            Return _directionOutput
        End Get
    End Property
    Public ReadOnly Property InputHigh As Boolean
        Get
            Return _InputHigh
        End Get
    End Property
    Public ReadOnly Property OutputHigh As Boolean
        Get
            Return _OutputHigh
        End Get
    End Property

    Public Sub SetDirection(state As Boolean)
        _requestedDirection = state
        _requestToChange = True
    End Sub

    Public Sub SetOutput(state As Boolean)
        _requestedOutput = state
        _requestToChange = True
    End Sub

    Public Sub SetState(direction As Boolean, output As Boolean)
        _requestedOutput = output
        _requestedDirection = direction
        _requestToChange = True
    End Sub

    Public Sub SetHigh()
        _requestedOutput = True
        _requestedDirection = True
        _requestToChange = True
    End Sub

    Public Sub SetLow()
        _requestedOutput = False
        _requestToChange = True
        _requestedDirection = True
    End Sub

    Public Sub SetInput()
        _requestedOutput = False
        _requestToChange = True
        _requestedDirection = False
    End Sub

    Public Sub SetPullup()
        _requestedOutput = True
        _requestToChange = True
        _requestedDirection = False
    End Sub
    Public Overrides Function ToString() As String
        If DirectionOutput Then
            Dim res = "Out, " + If(OutputHigh, "1", "0")
            If InputHigh <> OutputHigh Then res += " (" + If(InputHigh, "1", "0") + ")"
            Return res
        Else
            Dim res = "Inp, " + If(InputHigh, "1", "0")
            If OutputHigh = True Then res += " (PU)"
            Return res
        End If
    End Function

    Public Sub FromPort(port As SimplSerialBus.Port, pin As Integer)
        _directionOutput = port.PinDirection And (1 << pin)
        _inputHigh = port.PinInput And (1 << pin)
        _outputHigh = port.PinOutput And (1 << pin)
    End Sub

    Public Sub ToPort(port As SimplSerialBus.Port, pin As Integer)
        port.PinSetMask = port.PinSetMask Or (1 << pin)
        If _directionOutput Then port.PinDirection = port.PinDirection Or (1 << pin)
        If _outputHigh Then port.PinOutput = port.PinOutput Or (1 << pin)
    End Sub

    Public Function ChangeAndToPort(port As SimplSerialBus.Port, pin As Integer) As Boolean
        Dim changed As Boolean = False
        If _requestToChange Then
            _requestToChange = False
            _outputHigh = _requestedOutput
            _directionOutput = _requestedDirection
            ToPort(port, pin)
            changed = True
        End If
        Return changed
    End Function
End Class
