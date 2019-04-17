﻿Imports System.Security.Permissions
Imports System.Windows.Forms.ListView
Imports System.IO
Imports rdman.processWindowState
Imports System.Threading

Public Class mainForm
#Region "Global variables"
    Dim sourcesDb As String = My.Application.Info.DirectoryPath + "\sources.rdman"
    Dim _loggerPath As String = My.Application.Info.DirectoryPath + "\rdman.log"
    Dim command As String = ""
    Dim consoleFont As Font = New Font("Lucida Console", 8, FontStyle.Regular, GraphicsUnit.Point)
    Dim allahToConsole As String = ""
    Dim hasPutty As Boolean = False
    Dim hasFTP As Boolean = False
    Dim hasCsved As Boolean = False
    Dim hasFighter As Boolean = False
    Dim hasGreenshot As Boolean = False
    Public Declare Function ShowWindow Lib "user32" (ByVal hWnd As System.IntPtr, ByVal nCmdShow As Long) As Long
    Private Const SW_RESTORE = 9
#End Region

#Region "Form handle"
    Private Sub mainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Console.ForegroundColor = ConsoleColor.Green

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
        If My.Settings.lastDb <> "" Then
            sourcesDb = My.Settings.lastDb
        ElseIf My.Application.CommandLineArgs.Count > 0 Then
            sourcesDb = My.Application.CommandLineArgs.Item(0)
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
        End If

        If My.Settings.consoleTextColor <> Nothing Then
            Me.boxStatistics.ForeColor = My.Settings.consoleTextColor
        End If

        If My.Settings.consoleFontSize <> Nothing Then
            colorStatistics.fontSize.Value = My.Settings.consoleFontSize
            consoleFont = New Font("Lucida Console", My.Settings.consoleFontSize, FontStyle.Regular, GraphicsUnit.Point)
        End If

        Me.boxStatistics.Font = consoleFont


        'Set statistics default file name
        Me.saveStatistics.FileName = Today.ToString("yyyyMMdd")

        'Write to console
        allahToConsole += My.Application.Info.Title + " stats [Version " + Me.ProductVersion + "]"
        allahToConsole += vbNewLine
        allahToConsole += "Published under " + My.Application.Info.Copyright
        allahToConsole += vbNewLine
        allahToConsole += My.Application.Info.CompanyName + ", 2014-2019 [http://krtkovo.eu/]"
        allahToConsole += vbNewLine + vbNewLine
        allahToConsole += """boy> And can I kiss you?
girl> Yeah.
boy> And that's a surcharge, isn't it?
girl> Like what?
boy> I thought kissing was the most expensive?
girl> I do not know anything about that.
boy> Oh, that's probably just in Bangkok."""
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

        'If Fighter is included, change control variable
        If IO.File.Exists(My.Application.Info.DirectoryPath + "\modules\fighter\fighter.exe") Then
            hasFighter = True
        End If

        'If Greenshot is included, enable menu item
        If IO.File.Exists(My.Application.Info.DirectoryPath + "\modules\greenshot\Greenshot.exe") Then
            GreenshotToolStripMenuItem.Visible = True
            hasGreenshot = True
        End If

        'Compact mode
        If My.Settings.compactMode = True Then
            CompactModeToolStripMenuItem_Click(sender, New System.EventArgs)
        End If

        'Check parameters for db path and load db
        If sourcesDb = "" Or IO.File.Exists(sourcesDb) = False Then
            NewEmptySourcesDatabaseToolStripMenuItem_Click(sender, New System.EventArgs)
        Else
            LoadSources(sourcesDb)
        End If

        'load empty node template
        loadSourceData("EMPTY")

        'monitor timer
        monitorTimer.Start()

        'Autoconnect
        dataControl.autoconnect()

        'Hide "Additional settings" tab
        groupAdditionalInformations.Height = 25
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

        statistics("Exiting...")

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

        statistics("Good Bye ;-)")
    End Sub
#End Region

#Region "UI Buttons handle"
    Public Sub buttonConnect_Click(sender As Object, e As EventArgs) Handles buttonConnect.Click
        SaveNodeToolStripMenuItem_Click(Nothing, New System.EventArgs())
        Dim isApp As Boolean = False

        If boxSystem.Text = "Application" Then
            isApp = True
        End If

        Dim processPid As Integer = runRemote(boxIP.Text, boxPort.Text, boxFullscreen.Checked, boxWidth.Text, boxHeight.Text, boxMultimon.Checked, boxConnectOver.Checked, boxViewerPath.Text, boxName.Text, isApp, textboxUsername.Text, textboxPassword.Text)

        Select Case processPid
            Case 0
                statistics("[ERROR] Unable to open remote session.")
            Case 1
                statistics("[ERROR] Unable to connect to localhost.")
            Case 2
            Case Else
                statistics("Remote session started on " + Me.boxIP.Text + ":" + Me.boxPort.Text + " with PID=" + processPid.ToString)
        End Select
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnAutoconnect.Click
        If btnAutoconnect.BackColor = Color.GreenYellow Then
            btnAutoconnect.BackColor = SystemColors.Control
        Else
            btnAutoconnect.BackColor = Color.GreenYellow
        End If
    End Sub

    Private Sub buttonSave_Click(sender As Object, e As EventArgs) Handles buttonSave.Click
        SaveNodeToolStripMenuItem_Click(sender, New System.EventArgs)
    End Sub

    Private Sub buttonNewNode_Click(sender As Object, e As EventArgs) Handles buttonNewNode.Click
        AddNodeToolStripMenuItem_Click(sender, New System.EventArgs())
    End Sub

    Private Sub buttonImport_Click(sender As Object, e As EventArgs) Handles buttonImport.Click
        openSourceDb.Title = "Import source settings"

        If openSourceDb.ShowDialog() = Windows.Forms.DialogResult.OK Then
            If IO.File.Exists(openSourceDb.FileName) Then
                Try
                    Dim importedNode As String() = csvArray(openSourceDb.FileName).Item(0)

                    If importedNode(0) <> "" And importedNode(1) <> "" Then
                        boxName.Text = importedNode(0)
                        boxIP.Text = importedNode(1)
                        boxPort.Text = importedNode(2)
                        boxSystem.Text = importedNode(7)
                        boxSystemVersion.Text = importedNode(8)
                        boxDescription.Text = importedNode(9).Replace("\n", Environment.NewLine)
                        boxFullscreen.Checked = Convert.ToBoolean(importedNode(3))
                        boxWidth.Text = importedNode(5)
                        boxHeight.Text = importedNode(6)

                        Dim nodeSystemNum As Integer = systemToIndexNum(importedNode(7))

                        If nodeSystemNum > 4 Then
                            nodeSystemNum = 4
                        End If

                        boxPicture.Image = operatingSystemsImages.Images.Item(nodeSystemNum)
                        boxMultimon.Checked = Convert.ToBoolean(importedNode(4))
                        boxConnectOver.Checked = Convert.ToBoolean(importedNode(10))
                        boxViewerPath.Text = importedNode(11)

                        If Convert.ToBoolean(importedNode(12)) Then
                            btnAutoconnect.BackColor = Color.GreenYellow
                        Else
                            btnAutoconnect.BackColor = SystemColors.Control
                        End If

                        textboxUsername.Text = importedNode(13)
                        textboxPassword.Text = importedNode(14)

                        statistics("Imported source [" + boxName.Text + "]")
                    End If
                Catch ex As Exception
                    statistics("Importing of source [" + boxName.Text + "] failed. Cause: " + ex.Message)
                End Try
            End If
        End If

        openSourceDb.Title = "Open Sources Database file"
    End Sub

    Private Sub buttonExport_Click(sender As Object, e As EventArgs) Handles buttonExport.Click
        Try
            Dim exportNode As String = ""
            Dim exportedFolderPath As String = My.Application.Info.DirectoryPath + "\exported\"

            If System.IO.Directory.Exists(exportedFolderPath) = False Then
                System.IO.Directory.CreateDirectory(exportedFolderPath)
            End If

            Dim exportedNodeFilePath As String = exportedFolderPath + boxName.Text + ".rdman"
            Dim objWriter As New System.IO.StreamWriter(exportedNodeFilePath, False)

            exportNode += boxName.Text + ";"
            exportNode += boxIP.Text + ";"
            exportNode += boxPort.Text + ";"
            exportNode += boxFullscreen.Checked.ToString + ";"
            exportNode += boxMultimon.Checked.ToString + ";"
            exportNode += boxWidth.Text + ";"
            exportNode += boxHeight.Text + ";"
            exportNode += boxSystem.Text + ";"
            exportNode += boxSystemVersion.Text + ";"
            exportNode += boxDescription.Text + ";"
            exportNode += boxConnectOver.Checked.ToString + ";"
            exportNode += boxViewerPath.Text + ";"

            If btnAutoconnect.BackColor = Color.GreenYellow Then
                exportNode += "True;"
            Else
                exportNode += "False;"
            End If

            exportNode += textboxUsername.Text + ";"
            exportNode += textboxPassword.Text

            objWriter.Write(exportNode)
            objWriter.Close()
            statistics("Source [" + boxName.Text + "] successfully exported to file://" + exportedNodeFilePath)
            statistics(vbNewLine + boxName.Text + ".rdman:" + vbNewLine + vbTab + exportNode)
        Catch ex As Exception
            statistics("Exporting of source [" + boxName.Text + "] failed. Cause: " + ex.Message)
        End Try
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

    Private Sub lblPassword_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lblPassword.LinkClicked
        If textboxPassword.UseSystemPasswordChar = False Then
            textboxPassword.UseSystemPasswordChar = True
        Else
            textboxPassword.UseSystemPasswordChar = False
        End If

        showPasswordTimer.Start()
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

    Private Sub sourcesList_SelectedIndexChanged(sender As Object, e As EventArgs) Handles sourcesList.SelectedIndexChanged
        Dim nodeName As String = "(Add New Node)"

        For Each item As ListViewItem In sourcesList.SelectedItems()
            If item.Text.Contains("[") And item.Text.Contains("]") Then
                nodeName = item.Text.Remove(item.Text.LastIndexOf("[") - 1)
            Else
                nodeName = item.Text
            End If

            If nodeName = "(Add New Node)" Then
                AddNodeToolStripMenuItem_Click(sender, New System.EventArgs())
            Else
                loadSourceData(nodeName)
            End If
        Next
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

    Private Sub pingAll_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles pingAll.LinkClicked
        pingNodes()
    End Sub

    Private Sub sourcesList_ItemChecked(sender As Object, e As ItemCheckedEventArgs) Handles sourcesList.ItemChecked
        If e.Item.Text = "(Add New Node)" Then
            If e.Item.Checked = True Then
                For Each item As ListViewItem In sourcesList.Items
                    item.Checked = True
                Next
            Else
                For Each item As ListViewItem In sourcesList.Items
                    item.Checked = False
                Next
            End If
        End If
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
        Dim boxDescriptionWidth As Integer

        If boxConnectOver.Checked = True Then
            Me.groupResolutionSettings.Visible = False
            Me.groupConnectOver.Visible = True
            Me.boxCredentials.Visible = False
            Me.boxDescription.Width = groupAdditionalInformations.Width - 12
        Else
            Me.groupResolutionSettings.Visible = True
            Me.groupConnectOver.Visible = False
            Me.boxCredentials.Visible = True
            Me.boxDescription.Width = groupAdditionalInformations.Width - boxCredentials.Width - 28
        End If
    End Sub

    Private Sub lblUsePutty_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lblUsePutty.LinkClicked
        If hasPutty = True Then
            boxViewerPath.Text = My.Application.Info.DirectoryPath + "\modules\putty\putty.exe"
            boxIP.Text = "-ssh " + boxIP.Text
            statistics("!! NOTE !! - If you use PuTTY, you should specify which protocol you want to use. You can do this by writing IP address or hostname in this format:" + vbNewLine + "-ssh | -telnet | -rlogin | -raw " + boxIP.Text)
        End If
    End Sub

    Private Sub boxDescription_KeyDown(sender As Object, e As KeyEventArgs) Handles boxDescription.KeyDown
        If e.Control = True Then
            If e.KeyCode = Keys.A Then
                boxDescription.SelectAll()
            End If
        End If
    End Sub

    Private Sub showPasswordTimer_Tick(sender As Object, e As EventArgs) Handles showPasswordTimer.Tick
        textboxPassword.UseSystemPasswordChar = True
        showPasswordTimer.Stop()
    End Sub
#End Region

#Region "Tools And Help menu toolbars"

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

    Private Sub GreenshotToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GreenshotToolStripMenuItem.Click
        If hasGreenshot = True Then
            Dim ProcessProperties As New ProcessStartInfo

            ProcessProperties.FileName = My.Application.Info.DirectoryPath + "\modules\greenshot\Greenshot.exe"

            statistics("Starting Greenshot module.")
            runModule(ProcessProperties, True)
        End If
    End Sub

    Public Sub NewEmptySourcesDatabaseToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NewEmptySourcesDatabaseToolStripMenuItem.Click
        saveStatistics.Filter = "Sources database *.rdman|*.rdman"
        saveStatistics.DefaultExt = "rdman"
        saveStatistics.FileName = "sources.rdman"
        saveStatistics.Title = "New sources database"

        Try
            If saveStatistics.ShowDialog() = Windows.Forms.DialogResult.OK Then
                Dim statisticsFile As String = saveStatistics.FileName
                My.Computer.FileSystem.WriteAllText(statisticsFile, "", False)
                sourcesDb = statisticsFile
                LoadSources(statisticsFile)
            End If
        Catch ex As Exception
            statistics(ex.Message)
        End Try

        saveStatistics.Filter = "Text files *.txt|*.txt"
        saveStatistics.DefaultExt = "txt"
        saveStatistics.FileName = Today.ToString("yyyyMMdd")
        saveStatistics.Title = "Save Statistics file"
    End Sub

    Private Sub notifyIconCompactMode_DoubleClick(sender As Object, e As EventArgs) Handles notifyIconCompactMode.DoubleClick
        If Me.WindowState = FormWindowState.Minimized Then
            Me.WindowState = FormWindowState.Maximized
        End If

        Me.Activate()
    End Sub

    Private Sub ImportSourceToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ImportSourceToolStripMenuItem.Click
        buttonImport_Click(Nothing, Nothing)
    End Sub

    Private Sub ExportSourceToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExportSourceToolStripMenuItem.Click
        buttonExport_Click(Nothing, Nothing)
    End Sub

    Private Sub AutoconnectToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AutoconnectToolStripMenuItem.Click
        dataControl.autoconnect()
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
            Me.boxStatistics.ForeColor = My.Settings.consoleTextColor

            consoleFont = New Font("Lucida Console", My.Settings.consoleFontSize, FontStyle.Regular, GraphicsUnit.Point)
            Me.boxStatistics.Font = consoleFont
        End If
    End Sub

    Dim lastWindowState As FormWindowState
    Dim lastNormalSize, lastCompactSize As Size

#End Region

#Region "monitorHandle"

    Private Sub monitorTimer_Tick(sender As Object, e As EventArgs) Handles monitorTimer.Tick
        monitorCheckStates()
    End Sub

    Public Sub monitor_DoubleClick(sender As Object, e As EventArgs) Handles monitor.DoubleClick
        For Each node As ListViewItem In monitor.SelectedItems()
            monitorFocusApplication(node)
        Next
    End Sub

    Private Sub monitor_ItemDrag(sender As Object, e As ItemDragEventArgs) Handles monitor.ItemDrag
        For Each node As ListViewItem In monitor.SelectedItems()

            Select Case node.SubItems(2).Text
                Case "(connected)", "(module)", "(running)"
                    If MessageBox.Show("Do you really want to kill " + node.SubItems(0).Text + " (pid: " + node.SubItems(3).Text + ")?", "Kill " + node.SubItems(0).Text + " (pid: " + node.SubItems(3).Text + ")?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                        Try
                            Process.GetProcessById(node.SubItems(3).Text).Kill()
                        Catch ex As Exception
                            statistics(ex.Message)
                        End Try
                    End If
                Case "(disconnected)", "(closed)"
                    monitorDelNode(node.SubItems(0).Text, node.SubItems(3).Text)
                Case "(failed)"
                    monitorDelNode(node.SubItems(0).Text, "0")
            End Select
        Next
    End Sub

    Private Sub cleanTerminated_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles cleanTerminated.LinkClicked
        For Each node As ListViewItem In monitor.Items()

            Select Case node.SubItems(2).Text
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
                If monitorElement.StateImageIndex = 0 Or monitorElement.StateImageIndex = 4 Then
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

    Public Sub monitorFocusApplication(node As ListViewItem)
        Select Case node.SubItems(2).Text
            Case "(connected)", "(module)", "(running)"
                Try
                    Dim extProcess As Process
                    Dim PID As Integer

                    PID = Convert.ToInt32(node.SubItems(3).Text)
                    extProcess = Process.GetProcessById(PID)

                    If GetProcessWindowState(extProcess.MainWindowHandle) = FormWindowState.Minimized Then
                        ShowWindow(extProcess.MainWindowHandle, SW_RESTORE)
                    Else
                        AppActivate(Convert.ToInt32(node.SubItems(3).Text))
                    End If
                Catch ex As Exception
                    statistics(ex.Message)
                End Try
            Case "(disconnected)"
                If MessageBox.Show("Do you want to reconnect to this remote session?", "Reconnect?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    loadSourceData(node.SubItems(0).Text)
                    monitorDelNode(node.SubItems(0).Text, node.SubItems(3).Text)
                    buttonConnect_Click(Nothing, Nothing)
                Else
                    monitorDelNode(node.SubItems(0).Text, node.SubItems(3).Text)
                End If
            Case "(closed)"
                monitorDelNode(node.SubItems(0).Text, node.SubItems(3).Text)
            Case "(failed)"
                monitorDelNode(node.SubItems(0).Text, "0")
        End Select
    End Sub
#End Region

#Region "monitorContextMenu"
    Private Sub MoveToNextScreenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MoveToNextScreenToolStripMenuItem.Click
        Dim process As Process = Process.GetProcessById(ReturnProcessPID(ReturnSelectedProcess))

        MoveToNextScreen(process.MainWindowHandle)
    End Sub

    Private Sub contextMenuMonitor_Opened(sender As Object, e As EventArgs) Handles contextMenuMonitor.Opened
        If monitorFunctions.ReturnSelectedProcess() Is Nothing Or monitorFunctions.IsSelectedProcessDead(monitorFunctions.ReturnSelectedProcess) Then
            MoveToNextScreenToolStripMenuItem.Enabled = False
        Else
            MoveToNextScreenToolStripMenuItem.Enabled = True
        End If
    End Sub

    Public Declare Auto Function MoveWindow Lib "user32.dll" (ByVal hWnd As IntPtr, ByVal X As Int32, ByVal Y As Int32, ByVal nWidth As Int32, ByVal nHeight As Int32, ByVal bRepaint As Boolean) As Boolean

    Private Sub AdditionalSettingsLabel_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles AdditionalSettingsLabel.LinkClicked
        If (groupAdditionalInformations.Height = 155) Then
            groupAdditionalInformations.Height = 25
        Else
            groupAdditionalInformations.Height = 155
        End If
    End Sub

    Private Sub QuickConnectToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles QuickConnectToolStripMenuItem.Click
        commandValueInput.Height = 110
        commandValueInput.TextBox1.Multiline = False
        commandValueInput.TextBox1.Height = 20

        commandValueInput.Text = "IP Address or hostname"
        commandValueInput.TextBox1.Text = ""

        commandValueInput.ShowDialog()

        If commandValueInput.DialogResult = Windows.Forms.DialogResult.OK Then
            Dim quickIP As String = commandValueInput.TextBox1.Text
            Dim quickPort As String = "3389"

            If quickIP.Contains(":") Then
                quickPort = quickIP.Split(":").GetValue(1)
                quickIP = quickIP.Split(":").GetValue(0)
            End If

            Dim processPid As Integer = runRemote(quickIP, quickPort, True, "1024", "768", False, False, "", quickIP, False, "", "")

            If processPid > 1 Then
                statistics("Remote session started on " + quickIP + ":" + quickPort + " with PID=" + processPid.ToString)
            ElseIf processPid = 1 Then
                statistics("[ERROR] Unable to connect to localhost.")
            Else
                statistics("[ERROR] Unable to open remote session.")
            End If
        End If

        commandValueInput.TextBox1.Text = ""
    End Sub

    Public Sub MoveToNextScreen(ByVal processWindow As IntPtr)
        Try
            ShowWindow(processWindow, 1)
            MoveWindow(processWindow, Screen.PrimaryScreen.Bounds.Right + 1, 0, 640, 480, True)
            ShowWindow(processWindow, 3)
        Catch ex As Exception
            statistics(ex.Message)
        End Try
    End Sub
#End Region
End Class
