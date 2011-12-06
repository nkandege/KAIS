Imports System.Windows.Forms

Public Class MainForm

    Private questionForm As QuestionForm
    Private currentField As Field
    Private currentFieldControl As FieldControl
    Private forwardStack As Stack(Of Field)
    Private backwardStack As Stack(Of Field)
    Private instances As Integer = 0

    Private Sub OpenFile(ByVal sender As Object, ByVal e As EventArgs) Handles OpenToolStripMenuItem.Click, OpenToolStripButton.Click
        Dim questionForm As QuestionForm = New QuestionForm(Nothing, Nothing)
        Dim formSelectionForm As New FormSelectionForm(questionForm)
        formSelectionForm.ShowDialog()
        If questionForm.Id <> Nothing Then
            Me.questionForm = questionForm
            Me.questionForm.FieldList = CommandFactory.LoadFields(questionForm)
            LoadFieldControl(questionForm.FieldList.ElementAt(0))
            forwardStack = New Stack(Of Field)
            backwardStack = New Stack(Of Field)
        End If
    End Sub


    Private Sub LoadFieldControl(ByVal field As Field)
        Select Case field.FieldType
            Case "FREE_TEXT"
                Debug.WriteLine("Loading free text control...")
                currentFieldControl = New FreeTextFieldControl()
            Case "NUMERIC"
                Debug.WriteLine("Loading numeric control...")
                currentFieldControl = New NumericFieldControl()
            Case "SINGLE_RESPONSE"
                Debug.WriteLine("Loading single response control...")
                currentFieldControl = New SingleResponseFieldControl()
            Case "MULTIPLE_RESPONSE"
                Debug.WriteLine("Loading multiple response control...")
                currentFieldControl = New MultipleResponseFieldControl()
        End Select
        Dim loadedControlText As String = "Loaded control for field '" & field.Name & "' of type '" & field.FieldType & "'"
        controlLabel.Text = loadedControlText
        Debug.WriteLine(loadedControlText)
        Me.currentField = field
    End Sub

    Public Function SaveField(ByVal field As Field, ByVal fieldControl As FieldControl) As Boolean
        Dim success As Boolean = False
        Select Case field.FieldType
            Case "FREE_TEXT"
                Dim sql As String = "INSERT INTO " & field.OwnTableName & "(" & field.OwnColumnName & ") VALUES('" & TryCast(fieldControl.GetFieldData(), String) & "')"
                Debug.WriteLine(sql)
            Case "NUMERIC"
                Dim ret As Object = fieldControl.GetFieldData()
                Dim i As Integer = CInt(fieldControl.GetFieldData())
                Dim sql As String = "UPDATE " & field.OwnTableName & " SET " & field.OwnColumnName & " = " & CInt(fieldControl.GetFieldData()) & " WHERE id = 2"
                Debug.WriteLine(sql)
            Case "SINGLE_RESPONSE"
                Dim sql As String = "UPDATE " & field.OwnTableName & " SET " & field.OwnColumnName & " = " & TryCast(fieldControl.GetFieldData(), Lookup).Id & " WHERE id = 2"
                Debug.WriteLine(sql)
            Case "MULTIPLE_RESPONSE"
                Dim lookupList As List(Of Lookup) = TryCast(fieldControl.GetFieldData(), List(Of Lookup))
                If lookupList IsNot Nothing Then
                    For Each lookup As Lookup In lookupList
                        Dim sql As String = "UPDATE " & field.OwnTableName & " SET " & field.OwnColumnName & " = " & lookup.Id & " WHERE id = 2"
                        Debug.WriteLine(sql)
                    Next
                End If
        End Select
        Debug.WriteLine("Saved '" & field.FieldType & "' data for field '" & field.Name & "'")
        Return success
    End Function

    Private Sub nextButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nextButton.Click
        If currentField IsNot Nothing Then
            If currentField.ParentField Is Nothing And Not currentField.HasChildren Then 'lone field - [no parent, no children]
                SaveField(currentField, currentFieldControl)
            End If
            If Not backwardStack.Contains(currentField) Then
                backwardStack.Push(currentField)
            End If
            Dim nextField As Field = GetNextField()
            If nextField IsNot Nothing Then
                LoadFieldControl(nextField)
            Else
                Debug.WriteLine("Reached the end of the form")
            End If
        Else
            controlLabel.Text = "Please select a form first before proceeding."
        End If
    End Sub

    Private Sub previousButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles previousButton.Click
        Dim previousField As Field = GetPreviousField()
        If previousField IsNot Nothing Then
            LoadFieldControl(previousField)
        Else
            Debug.WriteLine("Reached the beginning of the form.")
        End If
    End Sub

    Private Function GetNextField() As Field
        Dim nextField As Field = Nothing
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        If currentField.ParentField Is Nothing And Not currentField.HasChildren Then 'lone field - [no parent, no children]
            'determine next just like before - default
            If forwardStack.Count > 0 Then
                nextField = forwardStack.Pop()
                backwardStack.Push(nextField)
                If nextField.Equals(currentField) Then
                    nextField = GetNextField()
                End If
            Else
                Dim maxFieldIndex As Integer = questionForm.FieldList.Count() - 1
                Dim currentFieldIndex As Integer = questionForm.FieldList.IndexOf(currentField)
                If currentFieldIndex < maxFieldIndex Then
                    Dim nextFieldIndex = currentFieldIndex + 1
                    nextField = questionForm.FieldList.ElementAt(nextFieldIndex)
                    Return nextField
                End If
            End If
        ElseIf currentField.ParentField Is Nothing And currentField.HasChildren Then 'parent field - [no parent, has children]
            'next will be next unshown child
            Dim mxFieldIndex As Integer = currentField.ChildFieldList.Count() - 1
            Dim crrentFieldIndex As Integer = currentField.ChildFieldList.IndexOf(currentField)
            If crrentFieldIndex < mxFieldIndex Then
                Dim nextFieldIndex = crrentFieldIndex + 1
                nextField = currentField.ChildFieldList.ElementAt(nextFieldIndex)
            End If
            If instances > 0 Then
                If MessageBox.Show("Iterate one more time?") Then
                    Dim maxFieldIndex As Integer = questionForm.FieldList.Count() - 1
                    Dim currentFieldIndex As Integer = questionForm.FieldList.IndexOf(currentField)
                    If currentFieldIndex < maxFieldIndex Then
                        Dim nextFieldIndex = currentFieldIndex + 1
                        nextField = questionForm.FieldList.ElementAt(nextFieldIndex)
                    End If
                    Return nextField
                Else
                    instances = 0
                End If
            End If
            instances = instances + 1
            ElseIf currentField.ParentField IsNot Nothing And Not currentField.HasChildren Then 'child field - [has parent, no children]
                Dim shownAllChildren As Boolean = True
            For Each child As Field In currentField.ParentField.ChildFieldList
                If Not child.Shown Then
                    LoadFieldControl(child)
                    shownAllChildren = False
                    Exit For
                End If
            Next
                If shownAllChildren Then
                    Debug.WriteLine("What to do 1? Ahow question message?")
                Else
                    Debug.WriteLine("What to do 2? Nothing?")
                End If
                'if all siblings are yet to be shown
                'show next sibling
                'else
                'ask if we should iterate again
                'if we should iterate again
                'start over
                'else
                'get next 'non-child' question
            Else
                Debug.WriteLine("This just shouldn't happen!!!")
            End If
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        'If forwardStack.Count > 0 Then
        '    nextField = forwardStack.Pop()
        '    backwardStack.Push(nextField)
        '    If nextField.Equals(currentField) Then
        '        nextField = GetNextField()
        '    End If
        'Else
        '    Dim maxFieldIndex As Integer = questionForm.FieldList.Count() - 1
        '    Dim currentFieldIndex As Integer = questionForm.FieldList.IndexOf(currentField)
        '    If currentFieldIndex < maxFieldIndex Then
        '        Dim nextFieldIndex = currentFieldIndex + 1
        '        nextField = questionForm.FieldList.ElementAt(nextFieldIndex)
        '    End If
        'End If
        Return nextField
    End Function

    Private Function GetPreviousField() As Field
        Dim previousField As Field = Nothing
        If backwardStack.Count() > 0 Then
            previousField = backwardStack.Pop()
            forwardStack.Push(previousField)
            If previousField.Equals(currentField) Then
                previousField = GetPreviousField()
            End If
        End If
        Return previousField
    End Function

End Class
