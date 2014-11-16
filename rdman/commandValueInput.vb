Imports System.Windows.Forms

Public Class commandValueInput
    Dim combination As Boolean = False

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub commandValueInput_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        ElseIf Me.TextBox1.Multiline = True Then
            If e.KeyCode = Keys.ShiftKey Then
                If combination = True Then
                    combination = False
                Else
                    combination = True
                End If
            ElseIf e.KeyCode = Keys.Enter And combination = True Then
                OK_Button_Click(sender, New System.EventArgs())
            End If
        End If
    End Sub

    Private Sub TextBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox1.KeyDown
        commandValueInput_KeyDown(sender, e)
    End Sub
End Class
