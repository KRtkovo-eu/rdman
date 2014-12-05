Imports System.Security.Permissions
Imports System.Windows.Forms.ListView
Imports System.IO
Imports rdman.processWindowState

Public Class mainForm
#Region "Global variables"
    Dim sourcesDb As String = My.Application.Info.DirectoryPath + "\sources.rdman"
    Dim command As String = ""
    Dim consoleFont As Font = New Font("Lucida Console", 8, FontStyle.Regular, GraphicsUnit.Point)
    Dim allahToConsole As String = ""
    Dim hasPutty As Boolean = False
    Dim hasFTP As Boolean = False
    Dim hasCsved As Boolean = False
#End Region

#Region "Form handle"
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

        If My.Settings.showPreview <> Nothing Then
            Me.ShowpreviewToolStripMenuItem.Checked = My.Settings.showPreview
        End If

        If My.Settings.closeChilds <> Nothing Then
            Me.KillChildProcessesOnCloseToolStripMenuItem.Checked = My.Settings.closeChilds
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

        If My.Settings.compactMode = True Then
            CompactModeToolStripMenuItem_Click(sender, New System.EventArgs)
        End If

        Me.boxStatistics.Font = consoleFont

        'Focus command line
        Me.statisticsCommandLine.Focus()

        'Set statistics default file name
        Me.saveStatistics.FileName = Today.ToString("yyyyMMdd")

        'Write to console
        allahToConsole += My.Application.Info.Title + " shell [Version " + Me.ProductVersion + "]"
        allahToConsole += vbNewLine
        allahToConsole += "Published under " + My.Application.Info.Copyright
        allahToConsole += vbNewLine
        allahToConsole += My.Application.Info.CompanyName + ", 2014 [http://krtkovo.eu/]"
        allahToConsole += vbNewLine + vbNewLine

        boxStatistics.Text = allahToConsole
        statisticsEnvironment()

        'If csved is included, change control variable
        If IO.File.Exists(My.Application.Info.DirectoryPath + "\modules\csved\uniCSVed.exe") = True Then
            hasCsved = True
        End If

        'If MikroFTP is included, enable menu item
        If IO.File.Exists(My.Application.Info.DirectoryPath + "\modules\mikroftp\mikroftp.exe") = True Then
            FTPServerToolStripMenuItem.Visible = True
            hasFTP = True
        End If

        'If PuTTY is included, enable "Use PuTTY" link
        If IO.File.Exists(My.Application.Info.DirectoryPath + "\modules\putty\putty.exe") = True Then
            lblUsePutty.Visible = True
            hasPutty = True
        End If

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
        My.Settings.showPreview = Me.ShowpreviewToolStripMenuItem.Checked
        My.Settings.closeChilds = Me.KillChildProcessesOnCloseToolStripMenuItem.Checked
        My.Settings.compactMode = Me.CompactModeToolStripMenuItem.Checked
        My.Settings.Save()

        If My.Settings.saveStats = True Then
            SaveStatisticsToolStripMenuItem_Click(sender, New System.EventArgs())
        End If

        If My.Settings.closeChilds = True Then
            For Each element In monitorNodes
                If element(2) = "(connected)" Or element(2) = "(module)" Or element(2) = "(running)" Then
                    Process.GetProcessById(Convert.ToInt32(element(3))).Kill()
                End If
            Next
        End If
    End Sub
#End Region

#Region "UI Buttons handle"
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

    Private Sub buttonSave_Click(sender As Object, e As EventArgs) Handles buttonSave.Click
        SaveNodeToolStripMenuItem_Click(sender, New System.EventArgs)
    End Sub

    Private Sub buttonNewNode_Click(sender As Object, e As EventArgs) Handles buttonNewNode.Click
        AddNodeToolStripMenuItem_Click(sender, New System.EventArgs())
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

    Private Sub boxSourcesPath_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles boxSourcesPath.LinkClicked
        LoadSources(sourcesDb)
    End Sub
#End Region

#Region "System picture box handle"
    Private Sub boxSystem_SelectedIndexChanged(sender As Object, e As EventArgs) Handles boxSystem.SelectedIndexChanged
        boxPicture.Image = operatingSystemsImages.Images.Item(boxSystem.SelectedIndex)
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
#End Region

#Region "Sources list handle"
    Private Sub sourcesList_DoubleClick(sender As Object, e As EventArgs) Handles sourcesList.DoubleClick
        buttonConnect_Click(sender, New System.EventArgs())
    End Sub

    Private Sub sourcesList_Click(sender As Object, e As EventArgs) Handles sourcesList.Click
        Dim nodeName As String = "(Add New Node)"

        For Each item As ListViewItem In sourcesList.SelectedItems()
            If item.Text.Contains("[") And item.Text.Contains("]") Then
                nodeName = item.Text.Remove(item.Text.LastIndexOf("[") - 1)
            Else
                nodeName = item.Text
            End If
        Next

        If nodeName = "(Add New Node)" Then
            AddNodeToolStripMenuItem_Click(sender, New System.EventArgs())
        Else
            loadSourceData(nodeName)
        End If
    End Sub

    Private Sub sourcesList_ItemDrag(sender As Object, e As ItemDragEventArgs) Handles sourcesList.ItemDrag
        For Each node As ListViewItem In sourcesList.SelectedItems()
            If node.SubItems(0).Text IsNot "(Add New Node)" Then
                If MessageBox.Show("Do you really want to delete " + node.SubItems(0).Text + "?", "Delete " + node.SubItems(0).Text + "?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    If node.SubItems(0).Text.Contains("[") And node.SubItems(0).Text.Contains("]") Then
                        saveSource(node.SubItems(0).Text.Remove(node.SubItems(0).Text.LastIndexOf("[") - 1), sourcesDb, True)
                    Else
                        saveSource(node.SubItems(0).Text, sourcesDb, True)
                    End If
                End If
            End If
        Next
    End Sub
#End Region

#Region "Node details checkboxes handle"
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

    Private Sub boxConnectOver_CheckedChanged(sender As Object, e As EventArgs) Handles boxConnectOver.CheckedChanged
        If boxConnectOver.Checked = True Then
            Me.groupResolutionSettings.Visible = False
            Me.groupConnectOver.Visible = True
        Else
            Me.groupResolutionSettings.Visible = True
            Me.groupConnectOver.Visible = False
        End If
    End Sub

    Private Sub lblUsePutty_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lblUsePutty.LinkClicked
        If hasPutty = True Then
            boxViewerPath.Text = My.Application.Info.DirectoryPath + "\modules\putty\putty.exe"
            boxIP.Text = "-ssh " + boxIP.Text
            statistics("!! NOTE !! - If you use PuTTY, you should specify which protocol you want to use. You can do this by writing IP address or hostname in this format:" + vbNewLine + "-ssh | -telnet | -rlogin | -raw 127.0.0.1")
        End If
    End Sub
#End Region

#Region "RDMan Shell"

    Private Sub commandFromLine(ByVal command As String)
        statistics(command, True)

        Select Case command.ToLower
            Case ""
            Case "about"
                AboutToolStripMenuItem_Click(Nothing, New System.EventArgs())
            Case "clear"
                boxStatistics.Text = allahToConsole
                statistics("", True) 'True because statistics was cleared by user.
            Case "connect"
                buttonConnect_Click(Nothing, New System.EventArgs())
            Case "editsources"
                EditSourcesDatabaseToolStripMenuItem_Click(Nothing, New System.EventArgs())
            Case "environment"
                statisticsEnvironment()
            Case "exit"
                Me.Close()
            Case "ftpserver", "ftp"
                FTPServerToolStripMenuItem_Click(Nothing, New System.EventArgs)
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
                help += vbTab + "cmd | Opens Windows shell."
                help += vbNewLine
                help += vbTab + "connect | Connects to currently loaded node."
                help += vbNewLine
                help += vbTab + "editsources | Opens loaded csv database with sources in default program."
                help += vbNewLine
                help += vbTab + "environment | Writes information about your machine."
                help += vbNewLine
                help += vbTab + "exit | Closes this program."
                help += vbNewLine
                help += vbTab + "ftpserver, ftp | Run FTP server module."
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
                help += vbTab + "putty | Use PuTTY module as viewer."
                help += vbNewLine
                help += vbTab + "reloadsources | Reloads nodes database."
                help += vbNewLine
                help += vbTab + "run | Runs chosen external process. Add character & just before path to run process without window (ex. &cmd)."
                help += vbNewLine
                help += vbTab + "savenode | Saves node to csv database file."
                help += vbNewLine
                help += vbTab + "savestats | Saves statistics log file."
                help += vbNewLine

                statistics(help)
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
            Case "putty"
                lblUsePutty_LinkClicked(Nothing, Nothing)
            Case "reloadsources"
                LoadSources(sourcesDb)
            Case "run", "cmd"
                Dim run As String
                Dim processProperties As ProcessStartInfo = New ProcessStartInfo

                If command <> "cmd" Then
                    run = commandGetValue("Enter path", False, "")
                Else
                    run = "cmd"
                End If

                If run(0) = "&" Then
                    run = run.Remove(0, 1)
                    processProperties.WindowStyle = ProcessWindowStyle.Hidden
                End If
                processProperties.FileName = run

                runModule(processProperties, False)
            Case "savenode"
                SaveNodeToolStripMenuItem_Click(Nothing, New System.EventArgs())
            Case "savestats"
                SaveStatisticsToolStripMenuItem_Click(Nothing, New System.EventArgs())
            Case Else
                statistics("Command not found")
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

    Private Sub boxStatistics_TextChanged(sender As Object, e As EventArgs) Handles boxStatistics.TextChanged
        boxStatistics.SelectionStart = boxStatistics.TextLength
        boxStatistics.ScrollToCaret()

        If boxStatistics.TextLength = boxStatistics.MaxLength Then
            SaveStatisticsToolStripMenuItem_Click(Nothing, New System.EventArgs())
            boxStatistics.Text = ""
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
#End Region

#Region "Tools and Help menu toolbars"

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
        saveSource(boxName.Text, sourcesDb)
    End Sub

    Private Sub AboutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem.Click
        aboutForm.ShowDialog()
    End Sub

    Private Sub ViewHelpToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ViewHelpToolStripMenuItem.Click
        Process.Start("https://github.com/KRtkovo-eu/rdman/wiki")
    End Sub

    Private Sub ReportAnIssueToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReportAnIssueToolStripMenuItem.Click
        Process.Start("https://github.com/KRtkovo-eu/rdman/issues/new")
    End Sub

    Private Sub EditSourcesDatabaseToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditSourcesDatabaseToolStripMenuItem.Click
        Dim ProcessProperties As New ProcessStartInfo
        If hasCsved = True Then
            ProcessProperties.FileName = My.Application.Info.DirectoryPath + "\modules\csved\uniCSVed.exe"
        Else
            ProcessProperties.FileName = "notepad.exe"
        End If

        ProcessProperties.Arguments = Chr(34) + sourcesDb + Chr(34)

        statistics("Database editing started.")
        runModule(ProcessProperties, True)
    End Sub

    Private Sub FTPServerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FTPServerToolStripMenuItem.Click
        If hasFTP = True Then
            ftpPath.SelectedPath = My.Application.Info.DirectoryPath + "\modules\mikroftp\share"
            If (ftpPath.ShowDialog = Windows.Forms.DialogResult.OK) Then
                Dim ProcessProperties As New ProcessStartInfo

                ProcessProperties.FileName = My.Application.Info.DirectoryPath + "\modules\mikroftp\mikroftp.exe"
                ProcessProperties.Arguments = Chr(34) + ftpPath.SelectedPath + Chr(34)

                statistics("Starting FTP Server module.")
                runModule(ProcessProperties, True)
            End If
        End If
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
#End Region

#Region "Setting menu toolbar"

    Private Sub AskBeforeCloseToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AskBeforeCloseToolStripMenuItem.Click
        If AskBeforeCloseToolStripMenuItem.Checked = True Then
            My.Settings.askOnClose = False
            AskBeforeCloseToolStripMenuItem.Checked = False
        Else
            My.Settings.askOnClose = True
            AskBeforeCloseToolStripMenuItem.Checked = True
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

    Private Sub SaveStatisticsOnCloseToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveStatisticsOnCloseToolStripMenuItem.Click
        If SaveStatisticsOnCloseToolStripMenuItem.Checked = True Then
            My.Settings.saveStats = False
            SaveStatisticsOnCloseToolStripMenuItem.Checked = False
        Else
            My.Settings.saveStats = True
            SaveStatisticsOnCloseToolStripMenuItem.Checked = True
        End If
    End Sub

    Private Sub ShowpreviewToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ShowpreviewToolStripMenuItem.Click
        If ShowpreviewToolStripMenuItem.Checked = True Then
            My.Settings.showPreview = False
            ShowpreviewToolStripMenuItem.Checked = False
        Else
            My.Settings.showPreview = True
            ShowpreviewToolStripMenuItem.Checked = True
        End If
    End Sub

    Private Sub KillChildProcessesOnCloseToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles KillChildProcessesOnCloseToolStripMenuItem.Click
        If KillChildProcessesOnCloseToolStripMenuItem.Checked = True Then
            My.Settings.closeChilds = False
            KillChildProcessesOnCloseToolStripMenuItem.Checked = False
        Else
            My.Settings.closeChilds = True
            KillChildProcessesOnCloseToolStripMenuItem.Checked = True
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

    Dim lastWindowState As FormWindowState
    Dim lastWidth, lastHeight As Integer

    Private Sub CompactModeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CompactModeToolStripMenuItem.Click
        If CompactModeToolStripMenuItem.Checked = True Then
            CompactModeToolStripMenuItem.Checked = False

            boxSourcesPath.Visible = True
            groupAdditionalInformations.Visible = True
            groupButtons.Visible = True
            groupConnectionSettings.Visible = True

            If boxConnectOver.Checked = True Then
                groupConnectOver.Visible = True
            Else
                groupResolutionSettings.Visible = True
            End If

            groupImage.Visible = True
            groupSourcesList.Visible = True
            groupStatistics.Visible = True
            mainContainer.Panel2Collapsed = False
            containerSourcesMonitor.Panel1Collapsed = False

            If lastWindowState <> Nothing Then
                Me.WindowState = lastWindowState
            Else
                Me.WindowState = FormWindowState.Normal
            End If

            Me.MinimumSize = New Size(800, 500)

            If lastWidth > 0 Then
                Me.Width = lastWidth
            Else
                Me.Width = 850
            End If

            If lastHeight > 0 Then
                Me.Height = lastHeight
            Else
                Me.Height = 450
            End If

            Me.TopMost = False

            Me.Text = Me.Text.Replace(" [compact mode]", "")
        Else
            CompactModeToolStripMenuItem.Checked = True

            boxSourcesPath.Visible = False
            groupAdditionalInformations.Visible = False
            groupButtons.Visible = False
            groupConnectionSettings.Visible = False
            groupConnectOver.Visible = False
            groupImage.Visible = False
            groupResolutionSettings.Visible = False
            groupSourcesList.Visible = False
            groupStatistics.Visible = False
            mainContainer.Panel2Collapsed = True
            containerSourcesMonitor.Panel1Collapsed = True

            lastWindowState = Me.WindowState
            Me.WindowState = FormWindowState.Normal

            Me.MinimumSize = New Size(100, 100)

            lastWidth = Me.Width
            Me.Width = 400

            lastHeight = Me.Height
            Me.Height = 300

            Me.TopMost = True

            Me.Text = Me.Text + " [compact mode]"
        End If
    End Sub
#End Region

#Region "monitorHandle"

    Private Sub monitorTimer_Tick(sender As Object, e As EventArgs) Handles monitorTimer.Tick
        monitorCheckStates()
    End Sub

    Private Sub monitor_DoubleClick(sender As Object, e As EventArgs) Handles monitor.DoubleClick
        Dim haveFirst As Boolean = False

        For Each node As ListViewItem In monitor.SelectedItems()

            Select Case node.SubItems(2).Text
                Case "(connected)", "(module)", "(running)"
                    If haveFirst = False Then
                        Dim extProcess As Process
                        Dim PID As Integer

                        PID = Convert.ToInt32(node.SubItems(3).Text)
                        extProcess = Process.GetProcessById(PID)

                        If GetProcessWindowState(extProcess.MainWindowHandle) = FormWindowState.Minimized Then
                            processAPI.ShowWindow(extProcess.MainWindowHandle)
                        End If

                        AppActivate(Convert.ToInt32(node.SubItems(3).Text))
                        haveFirst = True
                    End If
                Case "(disconnected)", "(closed)"
                    monitorDelNode(node.SubItems(0).Text, node.SubItems(3).Text)
                Case "(failed)"
                    monitorDelNode(node.SubItems(0).Text, "0")
            End Select
        Next
    End Sub

    Private Sub monitor_ItemDrag(sender As Object, e As ItemDragEventArgs) Handles monitor.ItemDrag
        For Each node As ListViewItem In monitor.SelectedItems()

            Select Case node.SubItems(2).Text
                Case "(connected)", "(module)", "(running)"
                    If MessageBox.Show("Do you really want to kill " + node.SubItems(0).Text + " (pid: " + node.SubItems(3).Text + ")?", "Kill " + node.SubItems(0).Text + " (pid: " + node.SubItems(3).Text + ")?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                        Process.GetProcessById(node.SubItems(3).Text).Kill()
                    End If
                Case "(disconnected)", "(closed)"
                    monitorDelNode(node.SubItems(0).Text, node.SubItems(3).Text)
                Case "(failed)"
                    monitorDelNode(node.SubItems(0).Text, "0")
            End Select
        Next
    End Sub

    Private Sub monitor_ProcessPreview(ByVal monitorElement As ListViewItem)
        Dim p As Point = Me.PointToClient(MousePosition)

        If My.Settings.showPreview = True Then
            If monitorElement IsNot Nothing Or monitorElement.Text <> "" Then
                If DateDiff(DateInterval.Second, Convert.ToDateTime(monitorElement.SubItems(5).Text), Now) > 15 Then
                    Select Case monitorElement.SubItems(2).Text
                        Case "(connected)", "(module)", "(running)"
                            Dim PID As String = monitorElement.SubItems(3).Text
                            Dim processImage As Image = getWindowScreenshot(PID)
                            Dim xPos, yPos As Integer
                            Dim screenArea As Rectangle = Screen.GetWorkingArea(MousePosition)

                            If processImage IsNot Nothing Then
                                If (p.Y + processImage.Height + 23) > screenArea.Height Or (p.Y + 23) > screenArea.Height Then
                                    yPos = p.Y - processImage.Height
                                Else
                                    yPos = p.Y + 23
                                End If

                                If (p.X + processImage.Width + 23) > screenArea.Width Or p.X + 23 > screenArea.Width Then
                                    xPos = p.X - processImage.Width
                                Else
                                    xPos = p.X + 23
                                End If

                                processPreview.Location = Me.PointToScreen(New Point(xPos, yPos))
                                processPreview.Height = processImage.Height
                                processPreview.Width = processImage.Width
                                processPreview.BackgroundImage = processImage
                                processPreview.TopMost = True

                                If processPreview.Visible = True Then
                                    processPreview.Invalidate()
                                Else
                                    processPreview.Show()
                                End If
                            End If
                        Case Else
                            processPreview.Hide()
                            lastPid = 0
                    End Select
                End If
            Else
                processPreview.Hide()
                lastPid = 0
            End If
        End If
    End Sub

    Private Sub monitor_MouseLeave(sender As Object, e As EventArgs) Handles monitor.MouseLeave
        processPreview.Hide()
        processPreviewHover.Stop()
        lastPid = 0
    End Sub

    Dim tickerItem As ListViewItem
    Private Sub processPreviewHover_Tick(sender As Object, e As EventArgs) Handles processPreviewHover.Tick
        monitor_ProcessPreview(tickerItem)
    End Sub

    Private Sub monitor_ItemMouseHover(sender As Object, e As ListViewItemMouseHoverEventArgs) Handles monitor.ItemMouseHover
        tickerItem = e.Item
        processPreviewHover.Start()
    End Sub
#End Region
End Class
