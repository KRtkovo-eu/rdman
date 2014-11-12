Public Class mainForm
    Dim consoleTicker As Integer
    Dim level As Integer = 0
    Dim sourcesDb As String = My.Application.Info.DirectoryPath + "\sources.csv"
    Dim command As String = ""

    Private Sub mainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If My.Settings.isMaximized = FormWindowState.Normal Then
            Me.Width = My.Settings.width
            Me.Height = My.Settings.height
            Me.Top = My.Settings.positionTop
            Me.Left = My.Settings.positionLeft
            Me.WindowState = My.Settings.isMaximized
        Else
            Me.WindowState = My.Settings.isMaximized
        End If

        Me.statisticsCommandLine.Focus()

        Dim username As String = My.User.Name

        username = username.ToUpper()
        username = username.Replace(My.Computer.Name.ToUpper + "\", "")

        Me.saveStatistics.FileName = Today.ToString("yyyyMMdd")

        statistics("HELLO " + username + "! Have a nice day with " + Me.Text + " (v" + Me.ProductVersion + "). So let's play the Game! I hope, You will enjoy it ;-)")
        statistics(statisticsEnvironment())
        'Me.Text = Me.Text + " v" + Me.ProductVersion

        If My.Application.CommandLineArgs.Count > 0 Then
            LoadSources(My.Application.CommandLineArgs.Item(0))
        Else
            LoadSources(sourcesDb)
        End If

        loadSourceData("EMPTY")
    End Sub

    Private Sub buttonConnect_Click(sender As Object, e As EventArgs) Handles buttonConnect.Click
        Dim processPid As Integer = runRemote(boxIP.Text, boxPort.Text, boxFullscreen.Checked, boxWidth.Text, boxHeight.Text, boxMultimon.Checked)
        If processPid > 1 Then
            statistics("Remote session started on " + Me.boxIP.Text + ":" + Me.boxPort.Text + " with PID=" + processPid.ToString)
        ElseIf processPid = 1 Then
            statistics("[ERROR] Unable to connect to localhost.")
        Else
            statistics("[ERROR] Unable to open remote session.")
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

    Private Sub EditSourcesDatabaseToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditSourcesDatabaseToolStripMenuItem.Click
        Process.Start(sourcesDb)
    End Sub

    Private Sub boxFullscreen_CheckedChanged(sender As Object, e As EventArgs) Handles boxFullscreen.CheckedChanged
        If boxFullscreen.Checked = False Then
            Me.boxHeight.ReadOnly = False
            Me.boxWidth.ReadOnly = False
            Me.boxMultimon.Enabled = False
        Else
            Me.boxHeight.ReadOnly = True
            Me.boxWidth.ReadOnly = True
            Me.boxMultimon.Enabled = True
        End If
    End Sub

    Private Sub commandFromLine(ByVal command As String)
        statistics(command, True)

        Select Case command.ToLower
            Case ""
                statistics("", True)
            Case "about"
                AboutToolStripMenuItem_Click(Nothing, New System.EventArgs())
            Case "connect"
                buttonConnect_Click(Nothing, New System.EventArgs())
            Case "editsources"
                EditSourcesDatabaseToolStripMenuItem_Click(Nothing, New System.EventArgs())
            Case "environment"
                statistics(statisticsEnvironment, True)
            Case "exit"
                Me.Close()
            Case "help"
                Dim help As String

                help = "HELP for Remote Desktop Manager"
                help += vbNewLine
                help += "-------------------------------"
                help += vbNewLine
                help += vbTab + "about | Show dialog with informations about this program."
                help += vbNewLine
                help += vbTab + "connect | Connects to currently loaded node."
                help += vbNewLine
                help += vbTab + "editsources | Opens loaded csv database with sources in default program."
                help += vbNewLine
                help += vbTab + "environment | Writes information about your machine."
                help += vbNewLine
                help += vbTab + "exit | Closes this program."
                help += vbNewLine
                help += vbTab + "help | Shows this page."
                help += vbNewLine
                help += vbTab + "loadsources | Opens dialog for selecting csv database file."
                help += vbNewLine
                help += vbTab + "newnode | Loads template of new node."
                help += vbNewLine
                help += vbTab + "nodedescription | Set node description."
                help += vbNewLine
                help += vbTab + "nodefullscreen | Set node fullscreen checkbox to opposite state."
                help += vbNewLine
                help += vbTab + "nodeheight | Set node height."
                help += vbNewLine
                help += vbTab + "nodeip | Set node IP or hostname."
                help += vbNewLine
                help += vbTab + "nodemultimon | Set node multimone (span remote desktop) checkbox to opposite state."
                help += vbNewLine
                help += vbTab + "nodename | Set node name."
                help += vbNewLine
                help += vbTab + "nodeport | Set node port."
                help += vbNewLine
                help += vbTab + "nodesystem | Set node system. Write value as 'Windows', 'Linux', 'Android', 'MacOS' or 'other'."
                help += vbNewLine
                help += vbTab + "nodesystemversion | Set node system version."
                help += vbNewLine
                help += vbTab + "nodewidth | Set node width."
                help += vbNewLine
                help += vbTab + "savenode | Saves node to csv database file."
                help += vbNewLine
                help += vbTab + "savestats | Saves statistics log file."
                help += vbNewLine

                statistics(help, True)
                statistics("", True)
            Case "loadsources"
                LoadSourcesDatabaseToolStripMenuItem_Click(Nothing, New System.EventArgs())
            Case "newnode"
                AddNodeToolStripMenuItem_Click(Nothing, New System.EventArgs())
            Case "nodedescription"
                commandSetValue(Me.boxDescription, command, True)
            Case "nodefullscreen"
                If Me.boxFullscreen.Checked = True Then
                    Me.boxFullscreen.Checked = False
                Else
                    Me.boxFullscreen.Checked = True
                End If
            Case "nodeheight"
                commandSetValue(Me.boxHeight, command)
            Case "nodeip"
                commandSetValue(Me.boxIP, command)
            Case "nodemultimon"
                If Me.boxMultimon.Checked = True Then
                    Me.boxMultimon.Checked = False
                Else
                    Me.boxMultimon.Checked = True
                End If
            Case "nodename"
                commandSetValue(Me.boxName, command)
            Case "nodeport"
                commandSetValue(Me.boxPort, command)
            Case "nodesystem"
                commandSetValue(Me.boxSystem, command)
            Case "nodesystemversion"
                commandSetValue(Me.boxSystemVersion, command)
            Case "nodewidth"
                commandSetValue(Me.boxWidth, command)
            Case "savenode"
                SaveNodeToolStripMenuItem_Click(Nothing, New System.EventArgs())
            Case "savestats"
                SaveStatisticsToolStripMenuItem_Click(Nothing, New System.EventArgs())
            Case Else
                statistics("Command not found", True)
        End Select
    End Sub

    Private Function commandGetValue(ByVal title As String, ByVal multiline As Boolean) As String
        If multiline = True Then
            commandValueInput.Height = 130
            commandValueInput.TextBox1.Multiline = multiline
            commandValueInput.TextBox1.Height = 50
        Else
            commandValueInput.Height = 100
            commandValueInput.TextBox1.Multiline = multiline
            commandValueInput.TextBox1.Height = 20
        End If

        commandValueInput.Text = title

        commandValueInput.ShowDialog()

        If commandValueInput.DialogResult = Windows.Forms.DialogResult.OK Then
            Return commandValueInput.TextBox1.Text
        Else
            Return ""
        End If
    End Function

    Private Sub commandSetValue(ByVal box As Object, ByVal command As String, ByVal multiline As Boolean)
        Dim item As String = commandGetValue("Set " + command + " of node", multiline)
        statistics(vbTab + "value {" + item + "}", True)
        box.text = item
    End Sub

    Private Sub commandSetValue(ByVal box As Object, ByVal command As String)
        commandSetValue(box, command, False)
    End Sub

    Private Sub statisticsCommandLine_KeyDown(sender As Object, e As KeyEventArgs) Handles statisticsCommandLine.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                command = Me.statisticsCommandLine.Text
                commandFromLine(command)
            Case Keys.Up
                Me.statisticsCommandLine.Text = command
            Case Keys.Down
                Me.statisticsCommandLine.Text = ""
        End Select
    End Sub

    Private Sub mainForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If Me.WindowState = FormWindowState.Normal Then
            My.Settings.width = Me.Width
            My.Settings.height = Me.Height
            My.Settings.positionTop = Me.Top
            My.Settings.positionLeft = Me.Left
            My.Settings.isMaximized = Me.WindowState
        Else
            My.Settings.isMaximized = Me.WindowState
        End If
        My.Settings.Save()
    End Sub

    Private Sub statisticsCommandLine_KeyUp(sender As Object, e As KeyEventArgs) Handles statisticsCommandLine.KeyUp
        If e.KeyCode = Keys.Enter Then
            Me.statisticsCommandLine.Text = ""
        End If
    End Sub

    Private Sub statisticsCommandLine_TextChanged(sender As Object, e As EventArgs) Handles statisticsCommandLine.TextChanged
        Dim font As Font

        If Me.statisticsCommandLine.Text = "" Or Me.statisticsCommandLine.Text = "Write command and launch it by pressing enter." Then
            If Me.statisticsCommandLine.Focused = False Then
                font = New Font("Lucida Console", 8, FontStyle.Italic, GraphicsUnit.Point)
                Me.statisticsCommandLine.Font = font
                Me.statisticsCommandLine.Text = "Write command and launch it by pressing enter."
            Else
                font = New Font("Lucida Console", 8, FontStyle.Bold, GraphicsUnit.Point)
                Me.statisticsCommandLine.Font = font
                Me.statisticsCommandLine.Text = ""
            End If
        End If
    End Sub

    Private Sub statisticsCommandLine_Leave(sender As Object, e As EventArgs) Handles statisticsCommandLine.Leave
        statisticsCommandLine_TextChanged(sender, New System.EventArgs())
    End Sub

    Private Sub statisticsCommandLine_Enter(sender As Object, e As EventArgs) Handles statisticsCommandLine.Enter
        statisticsCommandLine_TextChanged(sender, New System.EventArgs())
    End Sub
End Class
