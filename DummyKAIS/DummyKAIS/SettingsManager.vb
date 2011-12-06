Imports System.IO
Imports System.Xml.Serialization

Public Class SettingsManager

    Public Shared Sub Save(ByVal settings As Settings, ByVal type As Type)
        Dim myWriter As StreamWriter = Nothing
        Dim mySerializer As XmlSerializer = Nothing
        Try
            mySerializer = New XmlSerializer(type)
            myWriter = New StreamWriter(Application.LocalUserAppDataPath + "\settings.xml", False)
            mySerializer.Serialize(myWriter, settings)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            If Not (myWriter Is Nothing) Then
                myWriter.Close()
            End If
        End Try
    End Sub

    Public Shared Function Load(ByVal type As Type) As Settings
        Dim settings As Settings = Nothing
        Dim mySerializer As XmlSerializer = Nothing
        Dim myFileStream As FileStream = Nothing
        Dim fileExists As Boolean = False
        Try
            mySerializer = New XmlSerializer(type)
            Dim fi As New FileInfo(Application.LocalUserAppDataPath + "\settings.xml")
            If fi.Exists Then
                myFileStream = fi.OpenRead()
                settings = CType(mySerializer.Deserialize(myFileStream), Settings)
                fileExists = True
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            If Not (myFileStream Is Nothing) Then
                myFileStream.Close()
            End If
        End Try
        Return settings
    End Function

End Class
