Public Class PinState
    Private _pin As DigitalPin

    Public Shared Sub Request(pin As DigitalPin)
        Dim form As New PinState
        form._pin = pin
        form.ShowDialog()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        _pin.SetState(False, False)
        Me.Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        _pin.SetState(False, True)
        Me.Close()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        _pin.SetState(True, False)
        Me.Close()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        _pin.SetState(True, True)
        Me.Close()
    End Sub

    Private Sub PinState_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class