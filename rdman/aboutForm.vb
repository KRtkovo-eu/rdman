Public Class aboutForm
    Private Function getSourcesString() As String
        Dim sources As String

        sources = "Double-J Design - Super Mono 3D Icons (CC Attribution 4.0) [http://doublejdesign.co.uk/]"
        sources += vbNewLine
        sources += vbNewLine
        sources += "dAKirby309 - Windows 8 Metro Icons (CC Attribution-Noncommercial 4.0) [http://dakirby309.deviantart.com/]"

        Return sources
    End Function


    Private Sub closeButton_Click(sender As Object, e As EventArgs) Handles closeButton.Click
        Me.Close()
    End Sub

    Private Sub aboutForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Label1.Text = mainForm.Text
        Me.LinkLabel1.Text = My.Application.Info.Copyright
        Me.LinkLabel2.Text = My.Application.Info.CompanyName
        Me.sourcesTextBox.Text = getSourcesString()
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Process.Start("http://www.gnu.org/licenses/gpl-3.0-standalone.html")
    End Sub

    Private Sub LinkLabel2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        Process.Start("http://krtkovo.eu/")
    End Sub

    Private Sub LinkLabel3_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel3.LinkClicked
        Process.Start("https://github.com/KRtkovo-eu/rdman")
    End Sub
End Class