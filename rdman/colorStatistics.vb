Imports System.Windows.Forms

Public Class colorStatistics

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub btnTextColor_Click(sender As Object, e As EventArgs) Handles btnTextColor.Click
        Me.ColorDialog1.Color = Me.btnTextColor.BackColor
        If Me.ColorDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Me.btnTextColor.BackColor = Me.ColorDialog1.Color
        End If
    End Sub

    Private Sub btnBgColor_Click(sender As Object, e As EventArgs) Handles btnBgColor.Click
        Me.ColorDialog1.Color = Me.btnBgColor.BackColor
        If Me.ColorDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Me.btnBgColor.BackColor = Me.ColorDialog1.Color
        End If
    End Sub
End Class
