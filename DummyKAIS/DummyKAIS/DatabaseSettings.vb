Public Class DatabaseSettings
    Implements Settings

    Private vUser As String
    Private vPassword As String
    Private vMaxConnections As Integer

    Public Property User() As String
        Get
            Return vUser
        End Get
        Set(ByVal value As String)
            If value <> vUser Then
                vUser = value
            End If
        End Set
    End Property

    Public Property Password() As String
        Get
            Return vPassword
        End Get
        Set(ByVal value As String)
            If value <> vPassword Then
                vPassword = value
            End If
        End Set
    End Property

    Public Property MaxConnections() As Integer
        Get
            Return vMaxConnections
        End Get
        Set(ByVal value As Integer)
            If value <> vMaxConnections Then
                vMaxConnections = value
            End If
        End Set
    End Property
End Class
