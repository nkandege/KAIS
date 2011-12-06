Public Class MultipleResponseFieldControl
    Implements FieldControl


    Public Function GetFieldData() As Object Implements FieldControl.GetFieldData
        Dim lookipList As List(Of Lookup) = New List(Of Lookup)
        lookipList.Add(New Lookup(1))
        lookipList.Add(New Lookup(2))
        lookipList.Add(New Lookup(3))
        lookipList.Add(New Lookup(4))
        lookipList.Add(New Lookup(5))
        Return lookipList
    End Function
End Class
