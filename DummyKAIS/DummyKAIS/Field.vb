Public Class Field

    Private vId As Integer
    Private vName As String
    Private vOwnTableName As String
    Private vOwnColumnName As String
    Private vReferencedTableName As String
    Private vReferencedColumnName As String
    Private vParentField As Field
    Private vOrdinal As Integer
    Private vHasChildren As Boolean
    Private vFieldType As String
    Private vLookup As Lookup
    Private vChildFieldList As List(Of Field)
    Private vQuestionForm As QuestionForm
    Private vShown As Boolean

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

    Public Property OwnTableName() As String
        Get
            Return vOwnTableName
        End Get
        Set(ByVal value As String)
            vOwnTableName = value
        End Set
    End Property

    Public Property OwnColumnName() As String
        Get
            Return vOwnColumnName
        End Get
        Set(ByVal value As String)
            vOwnColumnName = value
        End Set
    End Property

    Public Property ReferencedTableName() As String
        Get
            Return vReferencedTableName
        End Get
        Set(ByVal value As String)
            vReferencedTableName = value
        End Set
    End Property

    Public Property ReferencedColumnName() As String
        Get
            Return vReferencedColumnName
        End Get
        Set(ByVal value As String)
            vReferencedColumnName = value
        End Set
    End Property

    Public Property ParentField() As Field
        Get
            Return vParentField
        End Get
        Set(ByVal value As Field)
            vParentField = value
        End Set
    End Property

    Public Property Ordinal() As Integer
        Get
            Return vOrdinal
        End Get
        Set(ByVal value As Integer)
            vOrdinal = value
        End Set
    End Property

    Public Property HasChildren() As Boolean
        Get
            Return vHasChildren
        End Get
        Set(ByVal value As Boolean)
            vHasChildren = value
        End Set
    End Property

    Public Property FieldType() As String
        Get
            Return vFieldType
        End Get
        Set(ByVal value As String)
            vFieldType = value
        End Set
    End Property

    Public Property Lookup() As Lookup
        Get
            Return vLookup
        End Get
        Set(ByVal value As Lookup)
            vLookup = value
        End Set
    End Property

    Public Property ChildFieldList() As List(Of Field)
        Get
            Return vChildFieldList
        End Get
        Set(ByVal value As List(Of Field))
            vChildFieldList = value
        End Set
    End Property

    Public Property QuestionForm() As QuestionForm
        Get
            Return vQuestionForm
        End Get
        Set(ByVal value As QuestionForm)
            vQuestionForm = value
        End Set
    End Property

    Public Property Shown() As Boolean
        Get
            Return vShown
        End Get
        Set(ByVal value As Boolean)
            vShown = value
        End Set
    End Property

End Class
