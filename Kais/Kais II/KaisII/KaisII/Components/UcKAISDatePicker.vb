Public Class UcKAISDatePicker

    Public ReadOnly Property DayNUD() As NumericUpDown
        Get
            Return Me.vDayNUD
        End Get
    End Property

    Public ReadOnly Property MonthNUD() As NumericUpDown
        Get
            Return Me.vMonthNUD
        End Get
    End Property

    Public ReadOnly Property YearNUD() As NumericUpDown
        Get
            Return Me.vYearNUD
        End Get
    End Property

    Public ReadOnly Property DayLabel() As Label
        Get
            Return Me.vDayLabel
        End Get
    End Property

    Public ReadOnly Property MonthLabel() As Label
        Get
            Return Me.vMonthLabel
        End Get
    End Property

    Public ReadOnly Property YearLabel() As Label
        Get
            Return Me.vYearLabel
        End Get
    End Property

    Private Sub vDayNUD_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles vDayNUD.ValueChanged
        Dim day As Integer = vDayNUD.Value
        If day > 31 And day <> 888 Then
            vDayNUD.Value = 31
        End If
    End Sub
End Class
