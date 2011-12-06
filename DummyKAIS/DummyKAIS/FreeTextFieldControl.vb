Public Class FreeTextFieldControl
    Implements FieldControl

    Public Function GetFieldData() As Object Implements FieldControl.GetFieldData
        Return "Some dummy free text data"
    End Function
End Class
