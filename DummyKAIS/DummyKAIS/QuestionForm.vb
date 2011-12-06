Public Class QuestionForm

    Private vId As Integer
    Private vName As String
    Private vFieldList As List(Of Field)

    Public Sub New(ByVal vId As Integer, ByVal vName As String)
        Me.vId = vId
        Me.vName = vName
    End Sub

    Public Property Id() As Integer
        Get
            Return vId
        End Get
        Set(ByVal value As Integer)
            vId = value
        End Set
    End Property

    Public Property Name() As String
        Get
            Return vName
        End Get
        Set(ByVal value As String)
            vName = value
        End Set
    End Property

    Public Property FieldList() As List(Of Field)
        Get
            Return vFieldList
        End Get
        Set(ByVal value As List(Of Field))
            vFieldList = value
        End Set
    End Property

End Class
