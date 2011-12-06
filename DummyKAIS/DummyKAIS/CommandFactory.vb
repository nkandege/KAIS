Imports System.Data.SqlClient

Public Class CommandFactory

    Private Shared connection As SqlConnection

    Private Shared Sub Connect()
        If connection Is Nothing Then
            connection = New SqlConnection("Data Source=.;Initial Catalog=dummy_kais;Persist Security Info=True;User ID=sa;Password=Maun2806;MultipleActiveResultSets=True")
            connection.Open()
        End If
    End Sub

    Public Shared Function GetCommand() As SqlCommand
        Connect()
        Dim command As SqlCommand = New SqlCommand()
        command.Connection = connection
        Return command
    End Function


    Public Shared Function LoadForms() As List(Of QuestionForm)
        Dim formList As List(Of QuestionForm) = New List(Of QuestionForm)
        Dim command As SqlCommand = CommandFactory.GetCommand()
        command.CommandText = "SELECT id, name FROM form"
        command.CommandType = CommandType.Text
        Dim reader As SqlDataReader = command.ExecuteReader()
        While reader.Read()
            Dim form As New QuestionForm(CType(reader("id"), Integer), CType(reader("name"), String))
            formList.Add(form)
        End While
        reader.Close()
        command.Dispose()
        Return formList
    End Function

    Public Shared Function LoadFields(ByVal questionForm As QuestionForm) As List(Of Field)
        Dim fieldList As List(Of Field) = New List(Of Field)
        Dim command As SqlCommand = CommandFactory.GetCommand()
        command.CommandText = "SELECT [id],[name],[own_table_name],[own_column_name],[referenced_table_name],[referenced_column_name],[parent_field_id],[ordinal],[has_children],[field_type],[lookup_id],[form_id] FROM [dummy_kais].[dbo].[field] WHERE parent_field_id IS NULL"
        'command.CommandText = "SELECT [id],[name],[own_table_name],[own_column_name],[referenced_table_name],[referenced_column_name],[parent_field_id],[ordinal],[has_children],[field_type],[lookup_id],[form_id] FROM [dummy_kais].[dbo].[field]"
        command.CommandType = CommandType.Text
        Dim reader As SqlDataReader = command.ExecuteReader()
        While reader.Read()
            Dim field As New Field()
            field.Id = CType(reader("id"), Integer)
            field.Name = TryCast(reader("name"), String)
            field.OwnTableName = TryCast(reader("own_table_name"), String)
            field.OwnColumnName = TryCast(reader("own_column_name"), String)
            field.ReferencedTableName = TryCast(reader("referenced_table_name"), String)
            field.ReferencedColumnName = TryCast(reader("referenced_column_name"), String)
            field.Ordinal = CType(reader("ordinal"), Integer)
            field.HasChildren = CType(reader("has_children"), Boolean)
            field.FieldType = TryCast(reader("field_type"), String)
            field.ChildFieldList = LoadFieldChildren(field)
            field.QuestionForm = questionForm
            fieldList.Add(field)
        End While
        reader.Close()
        command.Dispose()
        Return fieldList
    End Function

    Private Shared Function LoadFieldChildren(ByVal field As Field) As List(Of Field)
        Dim childFieldList As List(Of Field) = Nothing
        Dim command As SqlCommand = CommandFactory.GetCommand()
        command.CommandText = "SELECT [id],[name],[own_table_name],[own_column_name],[referenced_table_name],[referenced_column_name],[parent_field_id],[ordinal],[has_children],[field_type],[lookup_id],[form_id] FROM [dummy_kais].[dbo].[field] WHERE parent_field_id = " & field.Id
        command.CommandType = CommandType.Text
        Dim reader As SqlDataReader = command.ExecuteReader()
        While reader.Read()
            If childFieldList Is Nothing Then
                childFieldList = New List(Of Field)
            End If
            Dim f As New Field()
            f.Id = CType(reader("id"), Integer)
            f.Name = TryCast(reader("name"), String)
            f.OwnTableName = TryCast(reader("own_table_name"), String)
            f.OwnColumnName = TryCast(reader("own_column_name"), String)
            f.ReferencedTableName = TryCast(reader("referenced_table_name"), String)
            f.ReferencedColumnName = TryCast(reader("referenced_column_name"), String)
            f.Ordinal = CType(reader("ordinal"), Integer)
            f.HasChildren = CType(reader("has_children"), Boolean)
            f.FieldType = TryCast(reader("field_type"), String)
            f.ChildFieldList = LoadFieldChildren(f)
            f.QuestionForm = field.QuestionForm
            f.ParentField = field
            childFieldList.Add(f)
        End While
        reader.Close()
        command.Dispose()
        Return childFieldList
    End Function
End Class
