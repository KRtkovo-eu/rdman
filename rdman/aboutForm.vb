Public Class aboutForm

    Private Sub closeButton_Click(sender As Object, e As EventArgs) Handles closeButton.Click
        Me.Close()
    End Sub

    Private Sub aboutForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Label1.Text = mainForm.Text
    End Sub
End Class