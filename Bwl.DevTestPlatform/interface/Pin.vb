Public Class Pin
    Private Shared _digital As New List(Of DigitalPin)
    Private Shared _voltage As New List(Of AnalogInput)
    Private Shared _current As New List(Of AnalogInput)
    Private Shared _relay As New List(Of Boolean)

    Sub New()
        For i = 1 To 12
            _digital.Add(New DigitalPin)
        Next
        For i = 1 To 2
            _voltage.Add(New AnalogInput)
        Next
        For i = 1 To 2
            _current.Add(New AnalogInput)
        Next
        For i = 1 To 1
            _relay.Add(New Boolean)
        Next
    End Sub
    Public Shared ReadOnly Property Digital(index As Integer) As DigitalPin
        Get
            Return _digital(index - 1)
        End Get
    End Property

    Public Shared ReadOnly Property Voltage(index As Integer) As AnalogInput
        Get
            Return _voltage(index + -1)
        End Get
    End Property

    Public Shared ReadOnly Property Current(index As Integer) As AnalogInput
        Get
            Return _current(index + -1)
        End Get
    End Property

    Public Shared Property Relay(index As Integer) As Boolean
        Get
            Return _relay(index + -1)
        End Get
        Set(value As Boolean)
            _relay(index + -1) = value
        End Set
    End Property
End Class
