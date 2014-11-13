﻿Imports System.Net
Imports System.Threading

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
        If My.Computer.Network.IsAvailable Then
            Me.lblGitHub.Text = "Checking new version..."
            Me.Refresh()

            Dim latest As String = "https://github.com/KRtkovo-eu/rdman/releases/latest"
            Dim req As HttpWebRequest = DirectCast(HttpWebRequest.Create(latest), HttpWebRequest)
            Dim response As HttpWebResponse
            Dim resUri As String

            response = req.GetResponse
            resUri = response.ResponseUri.AbsoluteUri

            latest = resUri.Substring(resUri.LastIndexOf("/") + 1)

            If latest > ("v" + Me.ProductVersion) Then
                Me.lblGitHub.Text = "Available new version (" + latest + ") on GitHub ;-)"
            Else
                Me.lblGitHub.Text = "Your version is up to date. Visit us on GitHub ;-)"
            End If
            Me.Refresh()
        End If
    End Sub

    Private Sub aboutForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Label1.Text = My.Application.Info.Title + " v" + Me.ProductVersion
        Me.lblLicense.Text = My.Application.Info.Copyright
        Me.lblProducer.Text = My.Application.Info.CompanyName
        Me.lblGitHub.Text = "Check for update"
        Me.sourcesTextBox.Text = getSourcesString()
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lblLicense.LinkClicked
        Process.Start("http://www.gnu.org/licenses/gpl-3.0-standalone.html")
    End Sub

    Private Sub LinkLabel2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lblProducer.LinkClicked
        Process.Start("http://krtkovo.eu/")
    End Sub

    Private Sub LinkLabel3_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lblGitHub.LinkClicked
        Select Case Me.lblGitHub.Text
            Case "Check for update"
                checkUpdate()
            Case "Your version is up to date. Visit us on GitHub ;-)"
                Process.Start("https://github.com/KRtkovo-eu/rdman/wiki/")
            Case Else
                Process.Start("https://github.com/KRtkovo-eu/rdman/releases/latest")
        End Select
    End Sub

    Private Sub clickKRtkovo_click(sender As Object, e As EventArgs) Handles clickKRtkovo.Click
        Process.Start("http://krtkovo.eu/")
    End Sub

    Private Sub clickClose_click(sender As Object, e As EventArgs) Handles clickClose.Click
        Me.Close()
    End Sub

    Private Sub clickRDMan_click(sender As Object, e As EventArgs) Handles clickRDMan.Click
        Process.Start("https://github.com/KRtkovo-eu/rdman/wiki/")
    End Sub
End Class