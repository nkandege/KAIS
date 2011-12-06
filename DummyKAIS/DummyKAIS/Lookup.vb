
Public Class Lookup
    Private vId As Integer

    Public Sub New(ByVal vId As Integer)
        Me.vId = vId
    End Sub

    Public Property Id As Integer
        Get
            Return vId
        End Get
        Set(ByVal value As Integer)
            Me.vId = value
        End Set
    End Property
End Class
