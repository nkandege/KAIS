Public Class NumericFieldControl
    Implements FieldControl

    Public Function GetFieldData() As Object Implements FieldControl.GetFieldData
        Dim returnValue As Integer = 10
        Return returnValue
    End Function
End Class
