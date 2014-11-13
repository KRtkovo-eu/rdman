Public Class aboutForm
    Private Function getSourcesString() As String
        Dim sources As String

        sources = "Double-J Design - Super Mono 3D Icons (CC Attribution 4.0) [http://doublejdesign.co.uk/]"
        sources += vbNewLine
        sources += vbNewLine
        sources += "dAKirby309 - Windows 8 Metro Icons (CC Attribution-Noncommercial 4.0) [http://dakirby309.deviantart.com/]"

        Return sources
    End Function

    Private Sub checkUpdate()
        Dim latest As String = "https://github.com/KRtkovo-eu/rdman/releases/latest"


    End Sub

    Private Sub closeButton_Click(sender As Object, e As EventArgs) Handles closeButton.Click
        Me.Close()
    End Sub

    Private Sub aboutForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Label1.Text = My.Application.Info.Title + " v" + Me.ProductVersion
        Me.lblLicense.Text = My.Application.Info.Copyright
        Me.lblProducer.Text = My.Application.Info.CompanyName
        Me.sourcesTextBox.Text = getSourcesString()
        checkUpdate()
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lblLicense.LinkClicked
        Process.Start("http://www.gnu.org/licenses/gpl-3.0-standalone.html")
    End Sub

    Private Sub LinkLabel2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lblProducer.LinkClicked
        Process.Start("http://krtkovo.eu/")
    End Sub

    Private Sub LinkLabel3_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lblGitHub.LinkClicked
        Process.Start("https://github.com/KRtkovo-eu/rdman")
    End Sub
End Class