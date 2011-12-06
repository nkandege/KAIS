<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormSelectionForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.formComboBox = New System.Windows.Forms.ComboBox()
        Me.formLabel = New System.Windows.Forms.Label()
        Me.okButton = New System.Windows.Forms.Button()
        Me.cancelMeButton = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.formComboBox)
        Me.GroupBox1.Controls.Add(Me.formLabel)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(415, 50)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'formComboBox
        '
        Me.formComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.formComboBox.FormattingEnabled = True
        Me.formComboBox.Location = New System.Drawing.Point(51, 16)
        Me.formComboBox.Name = "formComboBox"
        Me.formComboBox.Size = New System.Drawing.Size(358, 21)
        Me.formComboBox.TabIndex = 1
        '
        'formLabel
        '
        Me.formLabel.AutoSize = True
        Me.formLabel.Location = New System.Drawing.Point(6, 19)
        Me.formLabel.Name = "formLabel"
        Me.formLabel.Size = New System.Drawing.Size(30, 13)
        Me.formLabel.TabIndex = 0
        Me.formLabel.Text = "Form"
        '
        'okButton
        '
        Me.okButton.Location = New System.Drawing.Point(271, 68)
        Me.okButton.Name = "okButton"
        Me.okButton.Size = New System.Drawing.Size(75, 23)
        Me.okButton.TabIndex = 1
        Me.okButton.Text = "OK"
        Me.okButton.UseVisualStyleBackColor = True
        '
        'cancelMeButton
        '
        Me.cancelMeButton.Location = New System.Drawing.Point(352, 68)
        Me.cancelMeButton.Name = "cancelMeButton"
        Me.cancelMeButton.Size = New System.Drawing.Size(75, 23)
        Me.cancelMeButton.TabIndex = 2
        Me.cancelMeButton.Text = "Cancel"
        Me.cancelMeButton.UseVisualStyleBackColor = True
        '
        'FormSelectionForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(439, 101)
        Me.Controls.Add(Me.cancelMeButton)
        Me.Controls.Add(Me.okButton)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormSelectionForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Form selection"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents formComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents formLabel As System.Windows.Forms.Label
    Friend WithEvents okButton As System.Windows.Forms.Button
    Friend WithEvents cancelMeButton As System.Windows.Forms.Button
End Class
