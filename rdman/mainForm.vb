Imports System.Security.Permissions
Imports System.Windows.Forms.ListView
Imports System.IO

Public Class mainForm
    Dim sourcesDb As String = My.Application.Info.DirectoryPath + "\sources.rdman"
    Dim command As String = ""
    Dim consoleFont As Font = New Font("Lucida Console", 8, FontStyle.Regular, GraphicsUnit.Point)

    Private Sub mainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Get settings of windows state and position
        If My.Settings.isMaximized = FormWindowState.Normal Then
            If My.Settings.width <> Nothing Then
                Me.Width = My.Settings.width
            End If

            If My.Settings.height <> Nothing Then
                Me.Height = My.Settings.height
            End If

            If My.Settings.positionTop <> Nothing Then
                Me.Top = My.Settings.positionTop
            End If

            If My.Settings.positionLeft <> Nothing Then
                Me.Left = My.Settings.positionLeft
            End If

            Me.WindowState = My.Settings.isMaximized
        Else
            Me.WindowState = My.Settings.isMaximized
        End If

        'Get last opened db
        If My.Settings.lastDb <> Nothing And IO.File.Exists(My.Settings.lastDb) Then
            sourcesDb = My.Settings.lastDb
        End If

        'Other settings
        If My.Settings.askOnClose <> Nothing Then
            Me.AskBeforeCloseToolStripMenuItem.Checked = My.Settings.askOnClose
        End If

        If My.Settings.updateOnStart <> Nothing Then
            Me.CheckForupdateOnStartToolStripMenuItem.Checked = My.Settings.updateOnStart
        End If

        If My.Settings.saveStats <> Nothing Then
            Me.SaveStatisticsOnCloseToolStripMenuItem.Checked = My.Settings.saveStats
        End If

        If My.Settings.consoleBgColor <> Nothing Then
            Me.boxStatistics.BackColor = My.Settings.consoleBgColor
            Me.statisticsCommandLine.BackColor = My.Settings.consoleBgColor
        End If

        If My.Settings.consoleTextColor <> Nothing Then
            Me.boxStatistics.ForeColor = My.Settings.consoleTextColor
            Me.statisticsCommandLine.ForeColor = My.Settings.consoleTextColor
        End If

        If My.Settings.consoleFontSize <> Nothing Then
            colorStatistics.fontSize.Value = My.Settings.consoleFontSize
            consoleFont = New Font("Lucida Console", My.Settings.consoleFontSize, FontStyle.Regular, GraphicsUnit.Point)
        End If
        Me.boxStatistics.Font = consoleFont

        'Focus command line
        Me.statisticsCommandLine.Focus()

        'Set statistics default file name
        Me.saveStatistics.FileName = Today.ToString("yyyyMMdd")

        'Write to console
        Dim allahToConsole As String = ""

        allahToConsole += My.Application.Info.Title + " shell [Version " + Me.ProductVersion + "]"
        allahToConsole += vbNewLine
        allahToConsole += "Published under " + My.Application.Info.Copyright
        allahToConsole += vbNewLine
        allahToConsole += My.Application.Info.CompanyName + ", 2014 [http://krtkovo.eu/]"
        allahToConsole += vbNewLine + vbNewLine

        boxStatistics.Text = allahToConsole
        statisticsEnvironment()

        'Check parameters for db path and load db
        If IO.File.Exists(sourcesDb) = False Then
            NewEmptySourcesDatabaseToolStripMenuItem_Click(sender, New System.EventArgs)
        End If

        If My.Application.CommandLineArgs.Count > 0 Then
            If IO.File.Exists(My.Application.CommandLineArgs.Item(0)) Then
                LoadSources(My.Application.CommandLineArgs.Item(0))
            Else
                LoadSources(sourcesDb)
            End If
        Else
            LoadSources(sourcesDb)
        End If

        'load empty node template
        loadSourceData("EMPTY")

        'monitor timer
        monitorTimer.Start()
    End Sub

    Private Sub buttonConnect_Click(sender As Object, e As EventArgs) Handles buttonConnect.Click
        SaveNodeToolStripMenuItem_Click(Nothing, New System.EventArgs())

        Dim processPid As Integer = runRemote(boxIP.Text, boxPort.Text, boxFullscreen.Checked, boxWidth.Text, boxHeight.Text, boxMultimon.Checked, boxConnectOver.Checked, boxViewerPath.Text, boxName.Text)
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

        If boxStatistics.TextLength = boxStatistics.MaxLength Then
            SaveStatisticsToolStripMenuItem_Click(Nothing, New System.EventArgs())
            boxStatistics.Text = ""
        End If
    End Sub

    Private Sub boxPicture_DoubleClick(sender As Object, e As EventArgs) Handles boxPicture.DoubleClick
        Dim asciiFile As String = My.Application.Info.DirectoryPath + "\asciiGraphics\" + Me.boxSystem.SelectedIndex.ToString + ".txt"
        Dim reader As IO.StreamReader = New IO.StreamReader(asciiFile)
        Dim image As String

        statistics("Output > " + asciiFile)
        image = vbNewLine

        Do While reader.EndOfStream = False
            image += reader.ReadLine
            image += vbNewLine
        Loop
        reader.Close()

        image += vbNewLine

        statistics(image)
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
            If IO.File.Exists(openSourceDb.FileName) Then
                sourcesDb = openSourceDb.FileName
                LoadSources(sourcesDb)
            End If
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
        Dim nodeName As String = "(Add New Node)"

        For Each item As ListViewItem In sourcesList.SelectedItems()
            nodeName = item.Text
        Next

        If nodeName = "(Add New Node)" Then
            AddNodeToolStripMenuItem_Click(sender, New System.EventArgs())
        Else
            loadSourceData(nodeName)
        End If
    End Sub

    Private Sub ViewHelpToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ViewHelpToolStripMenuItem.Click
        Process.Start("https://github.com/KRtkovo-eu/rdman/wiki")
    End Sub

    Private Sub EditSourcesDatabaseToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditSourcesDatabaseToolStripMenuItem.Click
        Dim notepad As Process
        Dim ProcessProperties As New ProcessStartInfo
        Dim csved As String = My.Application.Info.DirectoryPath + "\csved\uniCSVed.exe"

        If IO.File.Exists(csved) = False Then
            ProcessProperties.FileName = "notepad.exe"
        Else
            ProcessProperties.FileName = csved
        End If

        ProcessProperties.Arguments = Chr(34) + sourcesDb + Chr(34)


        notepad = Process.Start(ProcessProperties)
        statistics("Database editing started with " + ProcessProperties.FileName.Substring(ProcessProperties.FileName.LastIndexOf("\") + 1))

        notepad.WaitForExit()

        If My.Computer.FileSystem.FileExists(sourcesDb) = True Then
            LoadSources(sourcesDb)
        End If

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
            Case "clear"
                boxStatistics.Text = ""
            Case "connect"
                buttonConnect_Click(Nothing, New System.EventArgs())
            Case "editsources"
                EditSourcesDatabaseToolStripMenuItem_Click(Nothing, New System.EventArgs())
            Case "environment"
                statisticsEnvironment()
            Case "exit"
                Me.Close()
            Case "help"
                Dim help As String

                help = vbNewLine
                help += "HELP for Remote Desktop Manager"
                help += vbNewLine
                help += "-------------------------------"
                help += vbNewLine
                help += vbTab + "about | Show dialog with informations about this program."
                help += vbNewLine
                help += vbTab + "clear | Cleans the statistics box."
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
                help += vbTab + "nodeconnectover, connectover | Set node connect over checkbox to opposite state."
                help += vbNewLine
                help += vbTab + "nodedescription, description | Set node description."
                help += vbNewLine
                help += vbTab + "nodefullscreen, fullscreen | Set node fullscreen checkbox to opposite state."
                help += vbNewLine
                help += vbTab + "nodeheight, height | Set node height."
                help += vbNewLine
                help += vbTab + "nodeip, ip | Set node IP or hostname."
                help += vbNewLine
                help += vbTab + "nodemultimon, multimon | Set node multimone (span remote desktop) checkbox to opposite state."
                help += vbNewLine
                help += vbTab + "nodename, name | Set node name."
                help += vbNewLine
                help += vbTab + "nodeport, port | Set node port."
                help += vbNewLine
                help += vbTab + "nodesystem, system | Set node system. Write value as 'Windows', 'Linux', 'Android', 'MacOS' or 'other'."
                help += vbNewLine
                help += vbTab + "nodesystemversion, version | Set node system version."
                help += vbNewLine
                help += vbTab + "nodeviewerpath, viewer | Set node viewer path."
                help += vbNewLine
                help += vbTab + "nodewidth, width | Set node width."
                help += vbNewLine
                help += vbTab + "savenode | Saves node to csv database file."
                help += vbNewLine
                help += vbTab + "savestats | Saves statistics log file."
                help += vbNewLine

                statistics(help, True)
            Case "loadsources"
                LoadSourcesDatabaseToolStripMenuItem_Click(Nothing, New System.EventArgs())
            Case "newnode"
                AddNodeToolStripMenuItem_Click(Nothing, New System.EventArgs())
            Case "nodeconnectover", "connectover"
                If Me.boxConnectOver.Checked = True Then
                    Me.boxConnectOver.Checked = False
                Else
                    Me.boxConnectOver.Checked = True
                End If
            Case "nodedescription", "description"
                commandSetValue(Me.boxDescription, command, True)
            Case "nodefullscreen", "fullscreen"
                If Me.boxFullscreen.Checked = True Then
                    Me.boxFullscreen.Checked = False
                Else
                    Me.boxFullscreen.Checked = True
                End If
            Case "nodeheight", "height"
                commandSetValue(Me.boxHeight, command)
            Case "nodeip", "ip"
                commandSetValue(Me.boxIP, command)
            Case "nodemultimon", "multimon"
                If Me.boxMultimon.Checked = True Then
                    Me.boxMultimon.Checked = False
                Else
                    Me.boxMultimon.Checked = True
                End If
            Case "nodename", "name"
                commandSetValue(Me.boxName, command)
            Case "nodeport", "port"
                commandSetValue(Me.boxPort, command)
            Case "nodesystem", "system"
                commandSetValue(Me.boxSystem, command)
            Case "nodesystemversion", "version"
                commandSetValue(Me.boxSystemVersion, command)
            Case "nodeviewerpath", "viewer"
                commandSetValue(Me.boxViewerPath, command)
            Case "nodewidth", "width"
                commandSetValue(Me.boxWidth, command)
            Case "savenode"
                SaveNodeToolStripMenuItem_Click(Nothing, New System.EventArgs())
            Case "savestats"
                SaveStatisticsToolStripMenuItem_Click(Nothing, New System.EventArgs())
            Case Else
                statistics("Command not found", True)
        End Select
    End Sub

    Private Function commandGetValue(ByVal title As String, ByVal multiline As Boolean, ByVal value As String) As String
        If multiline = True Then
            commandValueInput.Height = 140
            commandValueInput.TextBox1.Multiline = multiline
            commandValueInput.TextBox1.Height = 50
        Else
            commandValueInput.Height = 110
            commandValueInput.TextBox1.Multiline = multiline
            commandValueInput.TextBox1.Height = 20
        End If

        commandValueInput.Text = title
        commandValueInput.TextBox1.Text = value
        commandValueInput.TextBox1.SelectAll()

        commandValueInput.ShowDialog()

        If commandValueInput.DialogResult = Windows.Forms.DialogResult.OK Then
            value = commandValueInput.TextBox1.Text

            commandValueInput.TextBox1.Text = ""
        End If

        Return value
    End Function

    Private Sub commandSetValue(ByVal box As Object, ByVal command As String, ByVal multiline As Boolean)
        Dim item As String = commandGetValue("Set " + command + " of node", multiline, box.text)
        statistics(vbTab + "value {" + item + "}", True)

        If box.name = "boxSystem" Then
            Select Case item.ToLower
                Case "w", "windows", "microsoft"
                    item = "windows"
                Case "l", "linux"
                    item = "linux"
                Case "a", "android"
                    item = "android"
                Case "m", "macos", "mac", "apple", "macintosh"
                    item = "macos"
                Case Else
                    item = "other"
            End Select
        End If

        box.Text = item
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
        If My.Settings.askOnClose = True Then
            If MessageBox.Show("Do you really want to exit Remote Desktop Manager?", "Really exit?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then
                e.Cancel = True
                Exit Sub
            End If
        End If

        If Me.WindowState = FormWindowState.Normal Then
            My.Settings.width = Me.Width
            My.Settings.height = Me.Height
            My.Settings.positionTop = Me.Top
            My.Settings.positionLeft = Me.Left
            My.Settings.isMaximized = Me.WindowState
        Else
            My.Settings.isMaximized = Me.WindowState
        End If
        My.Settings.lastDb = sourcesDb
        My.Settings.askOnClose = Me.AskBeforeCloseToolStripMenuItem.Checked
        My.Settings.updateOnStart = Me.CheckForupdateOnStartToolStripMenuItem.Checked
        My.Settings.saveStats = Me.SaveStatisticsOnCloseToolStripMenuItem.Checked
        My.Settings.consoleBgColor = Me.boxStatistics.BackColor
        My.Settings.consoleTextColor = Me.boxStatistics.ForeColor
        My.Settings.consoleFontSize = colorStatistics.fontSize.Value
        My.Settings.Save()

        If My.Settings.saveStats = True Then
            SaveStatisticsToolStripMenuItem_Click(sender, New System.EventArgs())
        End If
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
                Me.statisticsCommandLine.Text = "Write command and launch it by pressing enter."
                font = New Font("Lucida Console", 8, FontStyle.Italic, GraphicsUnit.Point)
                Me.statisticsCommandLine.Font = font
            Else
                Me.statisticsCommandLine.Text = ""
                font = New Font("Lucida Console", 8, FontStyle.Bold, GraphicsUnit.Point)
                Me.statisticsCommandLine.Font = font
            End If
        Else
            font = New Font("Lucida Console", 8, FontStyle.Bold, GraphicsUnit.Point)
            Me.statisticsCommandLine.Font = font
        End If
    End Sub

    Private Sub statisticsCommandLine_Leave(sender As Object, e As EventArgs) Handles statisticsCommandLine.Leave
        statisticsCommandLine_TextChanged(sender, New System.EventArgs())
        Me.AcceptButton = buttonConnect
    End Sub

    Private Sub statisticsCommandLine_Enter(sender As Object, e As EventArgs) Handles statisticsCommandLine.Enter
        statisticsCommandLine_TextChanged(sender, New System.EventArgs())
        Me.AcceptButton = Nothing
    End Sub

    Public Sub NewEmptySourcesDatabaseToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NewEmptySourcesDatabaseToolStripMenuItem.Click
        saveStatistics.Filter = "Sources database *.rdman|*.rdman"
        saveStatistics.DefaultExt = "rdman"
        saveStatistics.FileName = "sources.rdman"
        saveStatistics.Title = "New sources database"

        If saveStatistics.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Dim statisticsFile As String = saveStatistics.FileName
            My.Computer.FileSystem.WriteAllText(statisticsFile, "", False)
            sourcesDb = statisticsFile
            LoadSources(statisticsFile)
        End If

        saveStatistics.Filter = "Text files *.txt|*.txt"
        saveStatistics.DefaultExt = "txt"
        saveStatistics.FileName = Today.ToString("yyyyMMdd")
        saveStatistics.Title = "Save Statistics file"
    End Sub

    Private Sub boxConnectOver_CheckedChanged(sender As Object, e As EventArgs) Handles boxConnectOver.CheckedChanged
        If boxConnectOver.Checked = True Then
            Me.groupResolutionSettings.Visible = False
            Me.groupConnectOver.Visible = True
        Else
            Me.groupResolutionSettings.Visible = True
            Me.groupConnectOver.Visible = False
        End If
    End Sub

    Private Sub buttonLocateViewer_Click(sender As Object, e As EventArgs) Handles buttonLocateViewer.Click
        openSourceDb.Filter = "Executable file *.exe|*.exe"
        openSourceDb.DefaultExt = "exe"
        openSourceDb.FileName = ""
        openSourceDb.Title = "Select viewer path"

        If openSourceDb.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Me.boxViewerPath.Text = openSourceDb.FileName
        End If

        openSourceDb.Filter = "Sources database *.rdman|*.rdman|CSV file (sep. by semicolon) *.csv|*.csv"
        openSourceDb.DefaultExt = "rdman"
        openSourceDb.FileName = "sources.rdman"
        openSourceDb.Title = "Open Sources Database file"
    End Sub

    Private Sub AskBeforeCloseToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AskBeforeCloseToolStripMenuItem.Click
        If AskBeforeCloseToolStripMenuItem.Checked = True Then
            My.Settings.askOnClose = False
            AskBeforeCloseToolStripMenuItem.Checked = False
        Else
            My.Settings.askOnClose = True
            AskBeforeCloseToolStripMenuItem.Checked = True
        End If
    End Sub

    Private Sub mainForm_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        If My.Settings.updateOnStart = True Then
            Dim latest As String = aboutForm.checkUpdate()

            If latest <> "latest" And latest > "v" + Me.ProductVersion Then
                If MessageBox.Show("Update to " + My.Application.Info.Title + " " + latest + " is available on GitHub!" + vbNewLine + "Do you want to download it now?", "Update available", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = Windows.Forms.DialogResult.Yes Then
                    Process.Start("https://github.com/KRtkovo-eu/rdman/releases/latest")
                End If
            End If
        End If
    End Sub

    Private Sub CheckForupdateOnStartToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CheckForupdateOnStartToolStripMenuItem.Click
        If CheckForupdateOnStartToolStripMenuItem.Checked = True Then
            My.Settings.updateOnStart = False
            CheckForupdateOnStartToolStripMenuItem.Checked = False
        Else
            My.Settings.updateOnStart = True
            CheckForupdateOnStartToolStripMenuItem.Checked = True
        End If
    End Sub

    Private Sub boxSourcesPath_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles boxSourcesPath.LinkClicked
        EditSourcesDatabaseToolStripMenuItem_Click(sender, New System.EventArgs())
    End Sub

    Private Sub SaveStatisticsOnCloseToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveStatisticsOnCloseToolStripMenuItem.Click
        If SaveStatisticsOnCloseToolStripMenuItem.Checked = True Then
            My.Settings.saveStats = False
            SaveStatisticsOnCloseToolStripMenuItem.Checked = False
        Else
            My.Settings.saveStats = True
            SaveStatisticsOnCloseToolStripMenuItem.Checked = True
        End If
    End Sub

    Private Sub ColorOfStatisticsConsoleToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ColorOfStatisticsConsoleToolStripMenuItem.Click
        colorStatistics.btnBgColor.BackColor = My.Settings.consoleBgColor
        colorStatistics.btnTextColor.BackColor = My.Settings.consoleTextColor
        colorStatistics.fontSize.Value = My.Settings.consoleFontSize

        If colorStatistics.ShowDialog() = Windows.Forms.DialogResult.OK Then
            My.Settings.consoleBgColor = colorStatistics.btnBgColor.BackColor
            My.Settings.consoleTextColor = colorStatistics.btnTextColor.BackColor
            My.Settings.consoleFontSize = colorStatistics.fontSize.Value
            Me.boxStatistics.BackColor = My.Settings.consoleBgColor
            Me.statisticsCommandLine.BackColor = My.Settings.consoleBgColor
            Me.boxStatistics.ForeColor = My.Settings.consoleTextColor
            Me.statisticsCommandLine.ForeColor = My.Settings.consoleTextColor

            consoleFont = New Font("Lucida Console", My.Settings.consoleFontSize, FontStyle.Regular, GraphicsUnit.Point)
            Me.boxStatistics.Font = consoleFont
        End If
    End Sub

    Private Sub monitorTimer_Tick(sender As Object, e As EventArgs) Handles monitorTimer.Tick
        monitorCheckStates()
    End Sub

    Private Sub monitor_DoubleClick(sender As Object, e As EventArgs) Handles monitor.DoubleClick
        For Each node As ListViewItem In monitor.SelectedItems()

            Select Case node.SubItems(2).Text
                Case "(connected)"
                    AppActivate(Convert.ToInt32(node.SubItems(3).Text))
                Case "(disconnected)"
                    monitorDelNode(node.SubItems(0).Text, node.SubItems(3).Text)
                Case "(failed)"
                    monitorDelNode(node.SubItems(0).Text, "0")
            End Select
        Next
    End Sub

    Private Sub monitor_ItemDrag(sender As Object, e As ItemDragEventArgs) Handles monitor.ItemDrag
        For Each node As ListViewItem In monitor.SelectedItems()

            Select Case node.SubItems(2).Text
                Case "(connected)"
                    If MessageBox.Show("Do you really want to kill " + node.SubItems(0).Text + " (pid: " + node.SubItems(3).Text + ")?", "Kill " + node.SubItems(0).Text + " (pid: " + node.SubItems(3).Text + ")?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                        Process.GetProcessById(node.SubItems(3).Text).Kill()
                    End If
                Case "(disconnected)"
                    monitorDelNode(node.SubItems(0).Text, node.SubItems(3).Text)
                Case "(failed)"
                    monitorDelNode(node.SubItems(0).Text, "0")
            End Select
        Next
    End Sub

    Private Sub sourcesList_KeyDown(sender As Object, e As KeyEventArgs) Handles sourcesList.KeyDown
        Select e.KeyCode
            Case Keys.Delete
                For Each node As ListViewItem In sourcesList.SelectedItems()
                    If node.SubItems(0).Text IsNot "(Add New Node)" Then
                        If MessageBox.Show("Do you really want to delete " + node.SubItems(0).Text + "?", "Delete " + node.SubItems(0).Text + "?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                            saveSource(node.SubItems(0).Text, sourcesDb, True)
                        End If
                    End If
                Next
        End Select
    End Sub
End Class
