Public Class SingleResponseFieldControl
    Implements FieldControl


    Public Function GetFieldData() As Object Implements FieldControl.GetFieldData
        Return New Lookup(1)
    End Function
End Class
