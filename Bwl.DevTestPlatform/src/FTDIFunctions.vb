Imports FTD2XX_NET

Public Class FTDIFunctions
    Public Shared Function GetComPortByName(name As String) As String
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
        Return ""
    End Function
End Class
