Public Class AnalogInput
    Public Property Raw As Integer
    Public ReadOnly Property Value As Single
        Get
            Return (Raw - Offset) * Ratio
        End Get
    End Property

    Public Property Ratio As Single = 1.0
    Public Property Offset As Integer = 0.0
    Public Property Symbol As String = ""

    Public Overrides Function ToString() As String
        Return Value.ToString + Symbol
    End Function


End Class
