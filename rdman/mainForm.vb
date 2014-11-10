Public Class mainForm
    Dim consoleTicker As Integer
    Dim level As Integer = 0
    Dim sourcesDb As String = My.Application.Info.DirectoryPath + "\sources.csv"

    Function SetBytes(ByVal number As ULong) As String
        Select Case number
            Case Is >= 1073741824
                Return (number / 1024 / 1024 / 1024).ToString("F2") + " GB"
            Case Is >= 1048576
                Return (number / 1024 / 1024).ToString("F2") + " MB"
            Case Is >= 1024
                Return (number / 1024).ToString("F2") + " KB"
            Case Else
                Return number.ToString + " Bytes"
        End Select
    End Function

    Private Function statisticsEnvironment() As String
        Dim compTitle As String

        compTitle = "Environment: "
        compTitle += My.Computer.Name
        compTitle += " (system: "
        compTitle += My.Computer.Info.OSFullName
        compTitle += "| locale: "
        compTitle += My.Computer.Info.InstalledUICulture.EnglishName
        compTitle += "| memory: "
        compTitle += SetBytes(My.Computer.Info.AvailablePhysicalMemory)
        compTitle += "/"
        compTitle += SetBytes(My.Computer.Info.TotalPhysicalMemory)
        compTitle += ")"

        If My.Computer.Network.IsAvailable = True Then
            compTitle += " is connected to network. Ready to work!"

        Else
            compTitle += "is not connected to network."
        End If

        Return compTitle
    End Function

    Private Sub mainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim username As String = My.User.Name
        username = username.ToUpper()
        username = username.Replace(My.Computer.Name.ToUpper + "\", "")

        statistics("HELLO " + username + "! Have a nice day with " + Me.Text + " " + Me.ProductVersion + ". So let's play the Game! I hope, You will enjoy it ;-)")
        statistics(statisticsEnvironment())
        Me.Text = Me.Text + " " + Me.ProductVersion

        LoadSources(sourcesDb)
        loadSourceData("EMPTY")
    End Sub

    Private Sub buttonConnect_Click(sender As Object, e As EventArgs) Handles buttonConnect.Click
        Dim processPid As Integer = runRemote(boxIP.Text, boxPort.Text, boxFullscreen.Checked, boxWidth.Text, boxHeight.Text)
        If processPid > 0 Then
            statistics("Remote session started on " + Me.boxIP.Text + ":" + Me.boxPort.Text + " with PID=" + processPid.ToString)
        Else
            statistics("[ERROR] Unable to open remote session.")
        End If
    End Sub

    Private Sub boxFullscreen_CheckedChanged(sender As Object, e As EventArgs) Handles boxFullscreen.CheckedChanged
        If boxFullscreen.Checked = False Then
            Me.boxHeight.ReadOnly = False
            Me.boxWidth.ReadOnly = False
        Else
            Me.boxHeight.ReadOnly = True
            Me.boxWidth.ReadOnly = True
        End If
    End Sub

    Private Sub boxSystem_SelectedIndexChanged(sender As Object, e As EventArgs) Handles boxSystem.SelectedIndexChanged
        boxPicture.Image = operatingSystemsImages.Images.Item(boxSystem.SelectedIndex)
    End Sub

    Private Sub boxStatistics_TextChanged(sender As Object, e As EventArgs) Handles boxStatistics.TextChanged
        boxStatistics.SelectionStart = boxStatistics.TextLength
        boxStatistics.ScrollToCaret()
    End Sub

    Private Sub boxPicture_DoubleClick(sender As Object, e As EventArgs) Handles boxPicture.DoubleClick
        Dim asciiFile As String = My.Application.Info.DirectoryPath + "\asciiGraphics\" + Me.boxSystem.SelectedIndex.ToString + ".txt"
        Dim reader As IO.StreamReader = New IO.StreamReader(asciiFile)
        statistics("")
        statistics("")
        statistics("Output > " + asciiFile)
        statistics("")
        Do While reader.EndOfStream = False
            statistics(reader.ReadLine)
        Loop
        reader.Close()
        statistics("")
        statistics("")
    End Sub

    Private Sub buttonSave_Click(sender As Object, e As EventArgs) Handles buttonSave.Click
        saveSource(boxIP.Text, boxPort.Text, boxName.Text, boxWidth.Text, boxHeight.Text, boxSystem.SelectedText, boxSystemVersion.Text, boxDescription.Text, boxFullscreen.Checked)
    End Sub

    Private Sub buttonNewNode_Click(sender As Object, e As EventArgs) Handles buttonNewNode.Click
        loadSourceData("EMPTY")
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub AddNodeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddNodeToolStripMenuItem.Click
        buttonNewNode_Click(sender, New System.EventArgs())
    End Sub

    Private Sub LoadSourcesDatabaseToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LoadSourcesDatabaseToolStripMenuItem.Click
        If openSourceDb.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Dim sourcesDb As String = openSourceDb.FileName
            LoadSources(sourcesDb)
        End If
    End Sub

    Private Sub SaveStatisticsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveStatisticsToolStripMenuItem.Click
        If saveStatistics.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Dim statisticsFile As String = saveStatistics.FileName
            Dim objWriter As New System.IO.StreamWriter(statisticsFile)

            objWriter.Write(boxStatistics.Text)
            objWriter.Close()
            MessageBox.Show("Statistics was successfully saved.", "Statistics saved", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub SaveNodeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveNodeToolStripMenuItem.Click
        buttonSave_Click(sender, New System.EventArgs())
    End Sub

    Private Sub AboutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem.Click
        aboutForm.ShowDialog()
    End Sub

    Private Sub sourcesList_SelectedIndexChanged(sender As Object, e As EventArgs) Handles sourcesList.SelectedIndexChanged

    End Sub
End Class
