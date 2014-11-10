Public Class mainForm
    Dim consoleTicker As Integer
    Dim level As Integer = 0
    Dim sourcesDb As String = My.Application.Info.DirectoryPath + "\sources.csv"

    Private Sub mainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim username As String = My.User.Name
        username = username.ToUpper()
        username = username.Replace(My.Computer.Name.ToUpper + "\", "")

        statistics("HELLO " + username + "! Have a nice day with " + Me.Text + " " + Me.ProductVersion + ". So let's play the Game! I hope, You will enjoy it ;-)")
        statistics(statisticsEnvironment())
        Me.Text = Me.Text + " v" + Me.ProductVersion

        LoadSources(sourcesDb)
        loadSourceData("EMPTY")
    End Sub

    Private Sub buttonConnect_Click(sender As Object, e As EventArgs) Handles buttonConnect.Click
        Dim processPid As Integer = runRemote(boxIP.Text, boxPort.Text, boxFullscreen.Checked, boxWidth.Text, boxHeight.Text)
        If processPid > 1 Then
            statistics("Remote session started on " + Me.boxIP.Text + ":" + Me.boxPort.Text + " with PID=" + processPid.ToString)
        ElseIf processPid = 1 Then

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
        saveSource(boxName.Text, sourcesDb)
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub AddNodeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddNodeToolStripMenuItem.Click
        loadSourceData("EMPTY")
    End Sub

    Private Sub LoadSourcesDatabaseToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LoadSourcesDatabaseToolStripMenuItem.Click
        If openSourceDb.ShowDialog() = Windows.Forms.DialogResult.OK Then
            sourcesDb = openSourceDb.FileName
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

    Private Sub sourcesList_DoubleClick(sender As Object, e As EventArgs) Handles sourcesList.DoubleClick
        buttonConnect_Click(sender, New System.EventArgs())
    End Sub

    Private Sub buttonDelNode_Click(sender As Object, e As EventArgs) Handles buttonNewNode.Click
        AddNodeToolStripMenuItem_Click(sender, New System.EventArgs())
    End Sub

    Private Sub sourcesList_Click(sender As Object, e As EventArgs) Handles sourcesList.Click
        Dim nodeName As String = "Add New Node"

        For Each item As ListViewItem In sourcesList.SelectedItems()
            nodeName = item.Text
        Next

        If nodeName = "Add New Node" Then
            AddNodeToolStripMenuItem_Click(sender, New System.EventArgs())
        Else
            loadSourceData(nodeName)
        End If
    End Sub

    Private Sub ViewHelpToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ViewHelpToolStripMenuItem.Click
        Process.Start("https://github.com/KRtkovo-eu/rdman/wiki")
    End Sub
End Class
