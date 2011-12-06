Public Class FormSelectionForm

    Private questionForm As QuestionForm

    Public Sub New(ByVal questionForm As QuestionForm)
        InitializeComponent()
        Me.questionForm = questionForm

    End Sub

    Private Sub okButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles okButton.Click
        Dim selectedQuestionForm As QuestionForm = CType(formComboBox.SelectedItem, QuestionForm)
        If selectedQuestionForm IsNot Nothing Then
            questionForm.Id = selectedQuestionForm.Id
            questionForm.Name = selectedQuestionForm.Name
            Dispose()
        End If
    End Sub

    Private Sub FormSelectionForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim formList As List(Of QuestionForm) = CommandFactory.LoadForms()
        formComboBox.DataSource = formList
        formComboBox.DisplayMember = "Name"
    End Sub

    Private Sub cancelButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cancelMeButton.Click
        Dispose()
    End Sub
End Class