Imports System.Drawing

Public Class ShowImage
    Private Sub ShowImage_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Public Shared Function Create(img As Bitmap) As ShowImage
        Dim f As New ShowImage
        f.PictureBox1.Image = img
        Return f
    End Function
End Class