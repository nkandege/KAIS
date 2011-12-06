Option Compare Binary
Option Explicit On
Option Infer On
Option Strict On

Public Class XMLConfigTestForm

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Dim settings As New DatabaseSettings()
        settings.User = "QWE"
        settings.Password = "rty"
        settings.MaxConnections = 15
        Try
            SettingsManager.Save(settings, settings.GetType())
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Dim settings As DatabaseSettings = New DatabaseSettings()
        Try
            settings = CType(SettingsManager.Load(settings.GetType()), DatabaseSettings)
            Debug.WriteLine("User = " & settings.User)
            Debug.WriteLine("Password = " & settings.Password)
            Debug.WriteLine("Max Connections = " & settings.MaxConnections)
        Catch ex As Exception
            Debug.WriteLine(ex.Message & " *** " & ex.ToString())
        End Try
    End Sub
End Class
