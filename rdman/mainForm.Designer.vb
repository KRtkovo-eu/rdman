<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class mainForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim ListViewItem1 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("(Add New Node)", 6)
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(mainForm))
        Me.mainContainer = New System.Windows.Forms.SplitContainer()
        Me.containerSourcesMonitor = New System.Windows.Forms.SplitContainer()
        Me.groupSourcesList = New System.Windows.Forms.GroupBox()
        Me.pingProgressBar = New System.Windows.Forms.ProgressBar()
        Me.pingAll = New System.Windows.Forms.LinkLabel()
        Me.sourcesList = New System.Windows.Forms.ListView()
        Me.operatingSystemsIcons = New System.Windows.Forms.ImageList(Me.components)
        Me.groupMonitor = New System.Windows.Forms.GroupBox()
        Me.cleanTerminated = New System.Windows.Forms.LinkLabel()
        Me.monitor = New System.Windows.Forms.ListView()
        Me.columnName = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.columnIP = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.columnState = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.columnPID = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.columnArgs = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.columnTime = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.contextMenuMonitor = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.MoveToNextScreenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.monitorStates = New System.Windows.Forms.ImageList(Me.components)
        Me.boxSourcesPath = New System.Windows.Forms.LinkLabel()
        Me.groupStatistics = New System.Windows.Forms.GroupBox()
        Me.boxStatistics = New System.Windows.Forms.RichTextBox()
        Me.statisticsCommandLine = New System.Windows.Forms.ComboBox()
        Me.groupConnectOver = New System.Windows.Forms.GroupBox()
        Me.lblUsePutty = New System.Windows.Forms.LinkLabel()
        Me.buttonLocateViewer = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.boxViewerPath = New System.Windows.Forms.TextBox()
        Me.groupResolutionSettings = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.boxFullscreen = New System.Windows.Forms.CheckBox()
        Me.lblWindowSizePix = New System.Windows.Forms.Label()
        Me.lblWindowSizeX = New System.Windows.Forms.Label()
        Me.boxHeight = New System.Windows.Forms.TextBox()
        Me.boxMultimon = New System.Windows.Forms.CheckBox()
        Me.boxWidth = New System.Windows.Forms.TextBox()
        Me.groupAdditionalInformations = New System.Windows.Forms.GroupBox()
        Me.boxCredentials = New System.Windows.Forms.GroupBox()
        Me.lblPassword = New System.Windows.Forms.LinkLabel()
        Me.textboxPassword = New System.Windows.Forms.TextBox()
        Me.textboxUsername = New System.Windows.Forms.TextBox()
        Me.lblCredentialsUser = New System.Windows.Forms.Label()
        Me.boxDescription = New System.Windows.Forms.TextBox()
        Me.lblDescription = New System.Windows.Forms.Label()
        Me.boxSystemVersion = New System.Windows.Forms.TextBox()
        Me.lblVersion = New System.Windows.Forms.Label()
        Me.groupButtons = New System.Windows.Forms.GroupBox()
        Me.btnAutoconnect = New System.Windows.Forms.Button()
        Me.buttonExport = New System.Windows.Forms.Button()
        Me.buttonImport = New System.Windows.Forms.Button()
        Me.buttonNewNode = New System.Windows.Forms.Button()
        Me.buttonSave = New System.Windows.Forms.Button()
        Me.buttonConnect = New System.Windows.Forms.Button()
        Me.boxSystem = New System.Windows.Forms.ComboBox()
        Me.lblSystem = New System.Windows.Forms.Label()
        Me.groupConnectionSettings = New System.Windows.Forms.GroupBox()
        Me.lblQuickConnect = New System.Windows.Forms.LinkLabel()
        Me.boxConnectOver = New System.Windows.Forms.CheckBox()
        Me.boxPort = New System.Windows.Forms.TextBox()
        Me.lblPort = New System.Windows.Forms.Label()
        Me.boxIP = New System.Windows.Forms.TextBox()
        Me.lblIP = New System.Windows.Forms.Label()
        Me.boxName = New System.Windows.Forms.TextBox()
        Me.lblName = New System.Windows.Forms.Label()
        Me.groupImage = New System.Windows.Forms.GroupBox()
        Me.boxPicture = New System.Windows.Forms.PictureBox()
        Me.menuBar = New System.Windows.Forms.MenuStrip()
        Me.ToolsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LoadSourcesDatabaseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditSourcesDatabaseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NewEmptySourcesDatabaseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.AddNodeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ImportSourceToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExportSourceToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaveNodeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.SaveStatisticsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OptionsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ColorOfStatisticsConsoleToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ShowpreviewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.CheckForupdateOnStartToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.AskBeforeCloseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaveStatisticsOnCloseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.KillChildProcessesOnCloseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FTPServerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GreenshotToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HelpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ViewHelpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReportAnIssueToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.AboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CompactModeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AutoconnectToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.operatingSystemsImages = New System.Windows.Forms.ImageList(Me.components)
        Me.openSourceDb = New System.Windows.Forms.OpenFileDialog()
        Me.saveStatistics = New System.Windows.Forms.SaveFileDialog()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.monitorTimer = New System.Windows.Forms.Timer(Me.components)
        Me.ftpPath = New System.Windows.Forms.FolderBrowserDialog()
        Me.processPreviewHover = New System.Windows.Forms.Timer(Me.components)
        Me.notifyIconCompactMode = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.showPasswordTimer = New System.Windows.Forms.Timer(Me.components)
        CType(Me.mainContainer, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.mainContainer.Panel1.SuspendLayout()
        Me.mainContainer.Panel2.SuspendLayout()
        Me.mainContainer.SuspendLayout()
        CType(Me.containerSourcesMonitor, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.containerSourcesMonitor.Panel1.SuspendLayout()
        Me.containerSourcesMonitor.Panel2.SuspendLayout()
        Me.containerSourcesMonitor.SuspendLayout()
        Me.groupSourcesList.SuspendLayout()
        Me.groupMonitor.SuspendLayout()
        Me.contextMenuMonitor.SuspendLayout()
        Me.groupStatistics.SuspendLayout()
        Me.groupConnectOver.SuspendLayout()
        Me.groupResolutionSettings.SuspendLayout()
        Me.groupAdditionalInformations.SuspendLayout()
        Me.boxCredentials.SuspendLayout()
        Me.groupButtons.SuspendLayout()
        Me.groupConnectionSettings.SuspendLayout()
        Me.groupImage.SuspendLayout()
        CType(Me.boxPicture, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.menuBar.SuspendLayout()
        Me.SuspendLayout()
        '
        'mainContainer
        '
        Me.mainContainer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.mainContainer.Location = New System.Drawing.Point(0, 24)
        Me.mainContainer.Name = "mainContainer"
        '
        'mainContainer.Panel1
        '
        Me.mainContainer.Panel1.Controls.Add(Me.containerSourcesMonitor)
        Me.mainContainer.Panel1.Controls.Add(Me.boxSourcesPath)
        '
        'mainContainer.Panel2
        '
        Me.mainContainer.Panel2.Controls.Add(Me.groupStatistics)
        Me.mainContainer.Panel2.Controls.Add(Me.groupConnectOver)
        Me.mainContainer.Panel2.Controls.Add(Me.groupResolutionSettings)
        Me.mainContainer.Panel2.Controls.Add(Me.groupAdditionalInformations)
        Me.mainContainer.Panel2.Controls.Add(Me.groupConnectionSettings)
        Me.mainContainer.Size = New System.Drawing.Size(892, 499)
        Me.mainContainer.SplitterDistance = 250
        Me.mainContainer.TabIndex = 1
        '
        'containerSourcesMonitor
        '
        Me.containerSourcesMonitor.Dock = System.Windows.Forms.DockStyle.Fill
        Me.containerSourcesMonitor.Location = New System.Drawing.Point(0, 0)
        Me.containerSourcesMonitor.Name = "containerSourcesMonitor"
        Me.containerSourcesMonitor.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'containerSourcesMonitor.Panel1
        '
        Me.containerSourcesMonitor.Panel1.Controls.Add(Me.groupSourcesList)
        '
        'containerSourcesMonitor.Panel2
        '
        Me.containerSourcesMonitor.Panel2.Controls.Add(Me.groupMonitor)
        Me.containerSourcesMonitor.Size = New System.Drawing.Size(250, 477)
        Me.containerSourcesMonitor.SplitterDistance = 318
        Me.containerSourcesMonitor.TabIndex = 3
        '
        'groupSourcesList
        '
        Me.groupSourcesList.Controls.Add(Me.pingProgressBar)
        Me.groupSourcesList.Controls.Add(Me.pingAll)
        Me.groupSourcesList.Controls.Add(Me.sourcesList)
        Me.groupSourcesList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.groupSourcesList.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.groupSourcesList.Location = New System.Drawing.Point(0, 0)
        Me.groupSourcesList.Name = "groupSourcesList"
        Me.groupSourcesList.Size = New System.Drawing.Size(250, 318)
        Me.groupSourcesList.TabIndex = 0
        Me.groupSourcesList.TabStop = False
        Me.groupSourcesList.Text = "Sources list"
        '
        'pingProgressBar
        '
        Me.pingProgressBar.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pingProgressBar.Location = New System.Drawing.Point(3, 297)
        Me.pingProgressBar.Name = "pingProgressBar"
        Me.pingProgressBar.Size = New System.Drawing.Size(244, 18)
        Me.pingProgressBar.TabIndex = 2
        Me.pingProgressBar.Visible = False
        '
        'pingAll
        '
        Me.pingAll.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pingAll.AutoSize = True
        Me.pingAll.Font = New System.Drawing.Font("Segoe UI", 7.5!)
        Me.pingAll.LinkColor = System.Drawing.Color.DodgerBlue
        Me.pingAll.Location = New System.Drawing.Point(142, 0)
        Me.pingAll.Name = "pingAll"
        Me.pingAll.Size = New System.Drawing.Size(102, 12)
        Me.pingAll.TabIndex = 0
        Me.pingAll.TabStop = True
        Me.pingAll.Text = "PING selected sources"
        Me.pingAll.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.pingAll.VisitedLinkColor = System.Drawing.Color.DodgerBlue
        '
        'sourcesList
        '
        Me.sourcesList.Activation = System.Windows.Forms.ItemActivation.OneClick
        Me.sourcesList.Alignment = System.Windows.Forms.ListViewAlignment.Left
        Me.sourcesList.AutoArrange = False
        Me.sourcesList.CheckBoxes = True
        Me.sourcesList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.sourcesList.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.sourcesList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
        Me.sourcesList.HideSelection = False
        ListViewItem1.StateImageIndex = 0
        ListViewItem1.Tag = ""
        Me.sourcesList.Items.AddRange(New System.Windows.Forms.ListViewItem() {ListViewItem1})
        Me.sourcesList.LabelWrap = False
        Me.sourcesList.Location = New System.Drawing.Point(3, 18)
        Me.sourcesList.MultiSelect = False
        Me.sourcesList.Name = "sourcesList"
        Me.sourcesList.ShowGroups = False
        Me.sourcesList.Size = New System.Drawing.Size(244, 297)
        Me.sourcesList.SmallImageList = Me.operatingSystemsIcons
        Me.sourcesList.Sorting = System.Windows.Forms.SortOrder.Ascending
        Me.sourcesList.TabIndex = 1
        Me.sourcesList.TileSize = New System.Drawing.Size(150, 24)
        Me.sourcesList.UseCompatibleStateImageBehavior = False
        Me.sourcesList.View = System.Windows.Forms.View.List
        '
        'operatingSystemsIcons
        '
        Me.operatingSystemsIcons.ImageStream = CType(resources.GetObject("operatingSystemsIcons.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.operatingSystemsIcons.TransparentColor = System.Drawing.Color.Transparent
        Me.operatingSystemsIcons.Images.SetKeyName(0, "windows.ico")
        Me.operatingSystemsIcons.Images.SetKeyName(1, "linux.ico")
        Me.operatingSystemsIcons.Images.SetKeyName(2, "android.ico")
        Me.operatingSystemsIcons.Images.SetKeyName(3, "apple.ico")
        Me.operatingSystemsIcons.Images.SetKeyName(4, "unknown.ico")
        Me.operatingSystemsIcons.Images.SetKeyName(5, "terminal.ico")
        Me.operatingSystemsIcons.Images.SetKeyName(6, "add.ico")
        '
        'groupMonitor
        '
        Me.groupMonitor.AutoSize = True
        Me.groupMonitor.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.groupMonitor.Controls.Add(Me.cleanTerminated)
        Me.groupMonitor.Controls.Add(Me.monitor)
        Me.groupMonitor.Dock = System.Windows.Forms.DockStyle.Fill
        Me.groupMonitor.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.groupMonitor.Location = New System.Drawing.Point(0, 0)
        Me.groupMonitor.Name = "groupMonitor"
        Me.groupMonitor.Size = New System.Drawing.Size(250, 155)
        Me.groupMonitor.TabIndex = 0
        Me.groupMonitor.TabStop = False
        Me.groupMonitor.Text = "Processes monitor"
        '
        'cleanTerminated
        '
        Me.cleanTerminated.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cleanTerminated.AutoSize = True
        Me.cleanTerminated.Font = New System.Drawing.Font("Segoe UI", 7.5!)
        Me.cleanTerminated.LinkColor = System.Drawing.Color.DodgerBlue
        Me.cleanTerminated.Location = New System.Drawing.Point(165, 0)
        Me.cleanTerminated.Name = "cleanTerminated"
        Me.cleanTerminated.Size = New System.Drawing.Size(79, 12)
        Me.cleanTerminated.TabIndex = 0
        Me.cleanTerminated.TabStop = True
        Me.cleanTerminated.Text = "Clean terminated"
        Me.cleanTerminated.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.cleanTerminated.VisitedLinkColor = System.Drawing.Color.DodgerBlue
        '
        'monitor
        '
        Me.monitor.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.columnName, Me.columnIP, Me.columnState, Me.columnPID, Me.columnArgs, Me.columnTime})
        Me.monitor.ContextMenuStrip = Me.contextMenuMonitor
        Me.monitor.Dock = System.Windows.Forms.DockStyle.Fill
        Me.monitor.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.monitor.FullRowSelect = True
        Me.monitor.GridLines = True
        Me.monitor.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.monitor.Location = New System.Drawing.Point(3, 18)
        Me.monitor.Name = "monitor"
        Me.monitor.ShowGroups = False
        Me.monitor.Size = New System.Drawing.Size(244, 134)
        Me.monitor.StateImageList = Me.monitorStates
        Me.monitor.TabIndex = 1
        Me.monitor.UseCompatibleStateImageBehavior = False
        Me.monitor.View = System.Windows.Forms.View.Details
        '
        'columnName
        '
        Me.columnName.Text = "Process session"
        Me.columnName.Width = 150
        '
        'columnIP
        '
        Me.columnIP.Text = "Connection on"
        Me.columnIP.Width = 110
        '
        'columnState
        '
        Me.columnState.Text = "Status"
        Me.columnState.Width = 90
        '
        'columnPID
        '
        Me.columnPID.Text = "PID"
        '
        'columnArgs
        '
        Me.columnArgs.Text = "Runs"
        Me.columnArgs.Width = 150
        '
        'columnTime
        '
        Me.columnTime.Text = "Started on"
        Me.columnTime.Width = 150
        '
        'contextMenuMonitor
        '
        Me.contextMenuMonitor.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MoveToNextScreenToolStripMenuItem})
        Me.contextMenuMonitor.Name = "contextMenuMonitor"
        Me.contextMenuMonitor.Size = New System.Drawing.Size(181, 48)
        '
        'MoveToNextScreenToolStripMenuItem
        '
        Me.MoveToNextScreenToolStripMenuItem.Name = "MoveToNextScreenToolStripMenuItem"
        Me.MoveToNextScreenToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.MoveToNextScreenToolStripMenuItem.Text = "Move to next screen"
        '
        'monitorStates
        '
        Me.monitorStates.ImageStream = CType(resources.GetObject("monitorStates.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.monitorStates.TransparentColor = System.Drawing.Color.Transparent
        Me.monitorStates.Images.SetKeyName(0, "conn.png")
        Me.monitorStates.Images.SetKeyName(1, "off.png")
        Me.monitorStates.Images.SetKeyName(2, "err.png")
        Me.monitorStates.Images.SetKeyName(3, "prep.png")
        Me.monitorStates.Images.SetKeyName(4, "app.png")
        '
        'boxSourcesPath
        '
        Me.boxSourcesPath.ActiveLinkColor = System.Drawing.Color.Red
        Me.boxSourcesPath.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.boxSourcesPath.Font = New System.Drawing.Font("Lucida Console", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.boxSourcesPath.LinkArea = New System.Windows.Forms.LinkArea(8, 32000)
        Me.boxSourcesPath.LinkColor = System.Drawing.Color.DodgerBlue
        Me.boxSourcesPath.Location = New System.Drawing.Point(0, 477)
        Me.boxSourcesPath.Name = "boxSourcesPath"
        Me.boxSourcesPath.Padding = New System.Windows.Forms.Padding(2)
        Me.boxSourcesPath.Size = New System.Drawing.Size(250, 22)
        Me.boxSourcesPath.TabIndex = 0
        Me.boxSourcesPath.Text = "Loaded: "
        Me.boxSourcesPath.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        Me.ToolTip1.SetToolTip(Me.boxSourcesPath, "Reload sources database")
        Me.boxSourcesPath.UseCompatibleTextRendering = True
        Me.boxSourcesPath.VisitedLinkColor = System.Drawing.Color.DodgerBlue
        '
        'groupStatistics
        '
        Me.groupStatistics.Controls.Add(Me.boxStatistics)
        Me.groupStatistics.Controls.Add(Me.statisticsCommandLine)
        Me.groupStatistics.Dock = System.Windows.Forms.DockStyle.Fill
        Me.groupStatistics.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.groupStatistics.Location = New System.Drawing.Point(0, 342)
        Me.groupStatistics.Name = "groupStatistics"
        Me.groupStatistics.Size = New System.Drawing.Size(638, 157)
        Me.groupStatistics.TabIndex = 0
        Me.groupStatistics.TabStop = False
        Me.groupStatistics.Text = "Statistics"
        '
        'boxStatistics
        '
        Me.boxStatistics.BackColor = System.Drawing.Color.Black
        Me.boxStatistics.Dock = System.Windows.Forms.DockStyle.Fill
        Me.boxStatistics.Font = New System.Drawing.Font("Lucida Console", 8.0!)
        Me.boxStatistics.ForeColor = System.Drawing.Color.LawnGreen
        Me.boxStatistics.Location = New System.Drawing.Point(3, 18)
        Me.boxStatistics.Name = "boxStatistics"
        Me.boxStatistics.ReadOnly = True
        Me.boxStatistics.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical
        Me.boxStatistics.ShowSelectionMargin = True
        Me.boxStatistics.Size = New System.Drawing.Size(632, 117)
        Me.boxStatistics.TabIndex = 0
        Me.boxStatistics.Text = ""
        '
        'statisticsCommandLine
        '
        Me.statisticsCommandLine.AutoCompleteCustomSource.AddRange(New String() {"about", "autoconnect", "clear", "cmd", "connect", "connectover", "description", "editsources", "environment", "exit", "exportsource", "ftp", "ftpserver", "fullscreen", "height", "help", "importsource", "ip", "loadsources", "monitorpid", "multimon", "name", "newnode", "nodeconnectover", "nodedescription", "nodefullscreen", "nodeheight", "nodeip", "nodemultimon", "nodename", "nodeport", "nodesystem", "nodesystemversion", "nodeviewerpath", "nodewidth", "password", "port", "putty", "quickconnect", "reloadsources", "run", "savenode", "savestats", "system", "username", "version", "viewer", "width"})
        Me.statisticsCommandLine.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.statisticsCommandLine.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.statisticsCommandLine.BackColor = System.Drawing.Color.Black
        Me.statisticsCommandLine.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.statisticsCommandLine.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.statisticsCommandLine.Font = New System.Drawing.Font("Lucida Console", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.statisticsCommandLine.ForeColor = System.Drawing.Color.LawnGreen
        Me.statisticsCommandLine.FormattingEnabled = True
        Me.statisticsCommandLine.ItemHeight = 11
        Me.statisticsCommandLine.Items.AddRange(New Object() {"about", "autoconnect", "clear", "cmd", "connect", "connectover", "description", "editsources", "environment", "exit", "exportsource", "ftp", "ftpserver", "fullscreen", "height", "help", "importsource", "ip", "loadsources", "monitorpid", "multimon", "name", "newnode", "nodeconnectover", "nodedescription", "nodefullscreen", "nodeheight", "nodeip", "nodemultimon", "nodename", "nodeport", "nodesystem", "nodesystemversion", "nodeviewerpath", "nodewidth", "password", "port", "putty", "quickconnect", "reloadsources", "run", "savenode", "savestats", "system", "username", "version", "viewer", "width"})
        Me.statisticsCommandLine.Location = New System.Drawing.Point(3, 135)
        Me.statisticsCommandLine.MaxDropDownItems = 5
        Me.statisticsCommandLine.Name = "statisticsCommandLine"
        Me.statisticsCommandLine.Size = New System.Drawing.Size(632, 19)
        Me.statisticsCommandLine.Sorted = True
        Me.statisticsCommandLine.TabIndex = 1
        Me.statisticsCommandLine.Text = "Write command and launch it by pressing enter."
        '
        'groupConnectOver
        '
        Me.groupConnectOver.Controls.Add(Me.lblUsePutty)
        Me.groupConnectOver.Controls.Add(Me.buttonLocateViewer)
        Me.groupConnectOver.Controls.Add(Me.Label2)
        Me.groupConnectOver.Controls.Add(Me.boxViewerPath)
        Me.groupConnectOver.Dock = System.Windows.Forms.DockStyle.Top
        Me.groupConnectOver.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.groupConnectOver.Location = New System.Drawing.Point(0, 292)
        Me.groupConnectOver.Name = "groupConnectOver"
        Me.groupConnectOver.Size = New System.Drawing.Size(638, 50)
        Me.groupConnectOver.TabIndex = 4
        Me.groupConnectOver.TabStop = False
        Me.groupConnectOver.Text = "Connect over"
        Me.groupConnectOver.Visible = False
        '
        'lblUsePutty
        '
        Me.lblUsePutty.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblUsePutty.AutoSize = True
        Me.lblUsePutty.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.lblUsePutty.LinkColor = System.Drawing.Color.DodgerBlue
        Me.lblUsePutty.Location = New System.Drawing.Point(570, 24)
        Me.lblUsePutty.Name = "lblUsePutty"
        Me.lblUsePutty.Size = New System.Drawing.Size(57, 13)
        Me.lblUsePutty.TabIndex = 3
        Me.lblUsePutty.TabStop = True
        Me.lblUsePutty.Text = "Use PuTTY"
        Me.lblUsePutty.Visible = False
        Me.lblUsePutty.VisitedLinkColor = System.Drawing.Color.DodgerBlue
        '
        'buttonLocateViewer
        '
        Me.buttonLocateViewer.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.buttonLocateViewer.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.buttonLocateViewer.Location = New System.Drawing.Point(539, 19)
        Me.buttonLocateViewer.Name = "buttonLocateViewer"
        Me.buttonLocateViewer.Size = New System.Drawing.Size(25, 23)
        Me.buttonLocateViewer.TabIndex = 2
        Me.buttonLocateViewer.Text = "..."
        Me.buttonLocateViewer.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label2.Location = New System.Drawing.Point(7, 24)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(79, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Locate viewer:"
        '
        'boxViewerPath
        '
        Me.boxViewerPath.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.boxViewerPath.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.boxViewerPath.Location = New System.Drawing.Point(115, 20)
        Me.boxViewerPath.Name = "boxViewerPath"
        Me.boxViewerPath.Size = New System.Drawing.Size(418, 22)
        Me.boxViewerPath.TabIndex = 1
        '
        'groupResolutionSettings
        '
        Me.groupResolutionSettings.Controls.Add(Me.Label1)
        Me.groupResolutionSettings.Controls.Add(Me.boxFullscreen)
        Me.groupResolutionSettings.Controls.Add(Me.lblWindowSizePix)
        Me.groupResolutionSettings.Controls.Add(Me.lblWindowSizeX)
        Me.groupResolutionSettings.Controls.Add(Me.boxHeight)
        Me.groupResolutionSettings.Controls.Add(Me.boxMultimon)
        Me.groupResolutionSettings.Controls.Add(Me.boxWidth)
        Me.groupResolutionSettings.Dock = System.Windows.Forms.DockStyle.Top
        Me.groupResolutionSettings.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.groupResolutionSettings.Location = New System.Drawing.Point(0, 242)
        Me.groupResolutionSettings.Name = "groupResolutionSettings"
        Me.groupResolutionSettings.Size = New System.Drawing.Size(638, 50)
        Me.groupResolutionSettings.TabIndex = 2
        Me.groupResolutionSettings.TabStop = False
        Me.groupResolutionSettings.Text = "Resolution settings"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label1.Location = New System.Drawing.Point(335, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(76, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Window size:"
        '
        'boxFullscreen
        '
        Me.boxFullscreen.AutoSize = True
        Me.boxFullscreen.Checked = True
        Me.boxFullscreen.CheckState = System.Windows.Forms.CheckState.Checked
        Me.boxFullscreen.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.boxFullscreen.Location = New System.Drawing.Point(10, 22)
        Me.boxFullscreen.Name = "boxFullscreen"
        Me.boxFullscreen.Size = New System.Drawing.Size(78, 17)
        Me.boxFullscreen.TabIndex = 0
        Me.boxFullscreen.Text = "Fullscreen"
        Me.boxFullscreen.UseVisualStyleBackColor = True
        '
        'lblWindowSizePix
        '
        Me.lblWindowSizePix.AutoSize = True
        Me.lblWindowSizePix.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.lblWindowSizePix.Location = New System.Drawing.Point(537, 24)
        Me.lblWindowSizePix.Name = "lblWindowSizePix"
        Me.lblWindowSizePix.Size = New System.Drawing.Size(36, 13)
        Me.lblWindowSizePix.TabIndex = 6
        Me.lblWindowSizePix.Text = "pixels"
        '
        'lblWindowSizeX
        '
        Me.lblWindowSizeX.AutoSize = True
        Me.lblWindowSizeX.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.lblWindowSizeX.Location = New System.Drawing.Point(470, 24)
        Me.lblWindowSizeX.Name = "lblWindowSizeX"
        Me.lblWindowSizeX.Size = New System.Drawing.Size(12, 13)
        Me.lblWindowSizeX.TabIndex = 4
        Me.lblWindowSizeX.Text = "x"
        '
        'boxHeight
        '
        Me.boxHeight.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.boxHeight.Location = New System.Drawing.Point(485, 20)
        Me.boxHeight.Name = "boxHeight"
        Me.boxHeight.ReadOnly = True
        Me.boxHeight.Size = New System.Drawing.Size(48, 22)
        Me.boxHeight.TabIndex = 5
        '
        'boxMultimon
        '
        Me.boxMultimon.AutoSize = True
        Me.boxMultimon.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.boxMultimon.Location = New System.Drawing.Point(115, 22)
        Me.boxMultimon.Name = "boxMultimon"
        Me.boxMultimon.Size = New System.Drawing.Size(194, 17)
        Me.boxMultimon.TabIndex = 1
        Me.boxMultimon.Text = "Span remote desktop (multimon)"
        Me.boxMultimon.UseVisualStyleBackColor = True
        '
        'boxWidth
        '
        Me.boxWidth.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.boxWidth.Location = New System.Drawing.Point(417, 20)
        Me.boxWidth.Name = "boxWidth"
        Me.boxWidth.ReadOnly = True
        Me.boxWidth.Size = New System.Drawing.Size(48, 22)
        Me.boxWidth.TabIndex = 3
        '
        'groupAdditionalInformations
        '
        Me.groupAdditionalInformations.Controls.Add(Me.boxCredentials)
        Me.groupAdditionalInformations.Controls.Add(Me.boxDescription)
        Me.groupAdditionalInformations.Controls.Add(Me.lblDescription)
        Me.groupAdditionalInformations.Controls.Add(Me.boxSystemVersion)
        Me.groupAdditionalInformations.Controls.Add(Me.lblVersion)
        Me.groupAdditionalInformations.Controls.Add(Me.groupButtons)
        Me.groupAdditionalInformations.Controls.Add(Me.boxSystem)
        Me.groupAdditionalInformations.Controls.Add(Me.lblSystem)
        Me.groupAdditionalInformations.Dock = System.Windows.Forms.DockStyle.Top
        Me.groupAdditionalInformations.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.groupAdditionalInformations.Location = New System.Drawing.Point(0, 95)
        Me.groupAdditionalInformations.Name = "groupAdditionalInformations"
        Me.groupAdditionalInformations.Size = New System.Drawing.Size(638, 147)
        Me.groupAdditionalInformations.TabIndex = 1
        Me.groupAdditionalInformations.TabStop = False
        Me.groupAdditionalInformations.Text = "Additional settings"
        '
        'boxCredentials
        '
        Me.boxCredentials.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.boxCredentials.Controls.Add(Me.lblPassword)
        Me.boxCredentials.Controls.Add(Me.textboxPassword)
        Me.boxCredentials.Controls.Add(Me.textboxUsername)
        Me.boxCredentials.Controls.Add(Me.lblCredentialsUser)
        Me.boxCredentials.Location = New System.Drawing.Point(367, 91)
        Me.boxCredentials.Name = "boxCredentials"
        Me.boxCredentials.Size = New System.Drawing.Size(268, 56)
        Me.boxCredentials.TabIndex = 7
        Me.boxCredentials.TabStop = False
        Me.boxCredentials.Text = "Credentials"
        '
        'lblPassword
        '
        Me.lblPassword.AutoSize = True
        Me.lblPassword.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.lblPassword.LinkColor = System.Drawing.Color.DodgerBlue
        Me.lblPassword.Location = New System.Drawing.Point(143, 15)
        Me.lblPassword.Name = "lblPassword"
        Me.lblPassword.Size = New System.Drawing.Size(59, 13)
        Me.lblPassword.TabIndex = 2
        Me.lblPassword.TabStop = True
        Me.lblPassword.Text = "Password:"
        Me.ToolTip1.SetToolTip(Me.lblPassword, "Show password for 5 sec.")
        '
        'textboxPassword
        '
        Me.textboxPassword.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.textboxPassword.Location = New System.Drawing.Point(141, 31)
        Me.textboxPassword.Name = "textboxPassword"
        Me.textboxPassword.Size = New System.Drawing.Size(124, 22)
        Me.textboxPassword.TabIndex = 3
        Me.textboxPassword.UseSystemPasswordChar = True
        '
        'textboxUsername
        '
        Me.textboxUsername.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.textboxUsername.Location = New System.Drawing.Point(6, 31)
        Me.textboxUsername.Name = "textboxUsername"
        Me.textboxUsername.Size = New System.Drawing.Size(129, 22)
        Me.textboxUsername.TabIndex = 1
        '
        'lblCredentialsUser
        '
        Me.lblCredentialsUser.AutoSize = True
        Me.lblCredentialsUser.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.lblCredentialsUser.Location = New System.Drawing.Point(6, 15)
        Me.lblCredentialsUser.Name = "lblCredentialsUser"
        Me.lblCredentialsUser.Size = New System.Drawing.Size(61, 13)
        Me.lblCredentialsUser.TabIndex = 0
        Me.lblCredentialsUser.Text = "Username:"
        '
        'boxDescription
        '
        Me.boxDescription.AcceptsReturn = True
        Me.boxDescription.AcceptsTab = True
        Me.boxDescription.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.boxDescription.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.boxDescription.Location = New System.Drawing.Point(10, 92)
        Me.boxDescription.Multiline = True
        Me.boxDescription.Name = "boxDescription"
        Me.boxDescription.Size = New System.Drawing.Size(342, 52)
        Me.boxDescription.TabIndex = 5
        '
        'lblDescription
        '
        Me.lblDescription.AutoSize = True
        Me.lblDescription.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.lblDescription.Location = New System.Drawing.Point(6, 76)
        Me.lblDescription.Name = "lblDescription"
        Me.lblDescription.Size = New System.Drawing.Size(69, 13)
        Me.lblDescription.TabIndex = 4
        Me.lblDescription.Text = "Description:"
        '
        'boxSystemVersion
        '
        Me.boxSystemVersion.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.boxSystemVersion.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.boxSystemVersion.Location = New System.Drawing.Point(115, 48)
        Me.boxSystemVersion.Name = "boxSystemVersion"
        Me.boxSystemVersion.Size = New System.Drawing.Size(237, 22)
        Me.boxSystemVersion.TabIndex = 3
        '
        'lblVersion
        '
        Me.lblVersion.AutoSize = True
        Me.lblVersion.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.lblVersion.Location = New System.Drawing.Point(7, 52)
        Me.lblVersion.Name = "lblVersion"
        Me.lblVersion.Size = New System.Drawing.Size(49, 13)
        Me.lblVersion.TabIndex = 2
        Me.lblVersion.Text = "Version:"
        '
        'groupButtons
        '
        Me.groupButtons.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.groupButtons.Controls.Add(Me.btnAutoconnect)
        Me.groupButtons.Controls.Add(Me.buttonExport)
        Me.groupButtons.Controls.Add(Me.buttonImport)
        Me.groupButtons.Controls.Add(Me.buttonNewNode)
        Me.groupButtons.Controls.Add(Me.buttonSave)
        Me.groupButtons.Controls.Add(Me.buttonConnect)
        Me.groupButtons.Location = New System.Drawing.Point(367, 0)
        Me.groupButtons.Name = "groupButtons"
        Me.groupButtons.Size = New System.Drawing.Size(115, 89)
        Me.groupButtons.TabIndex = 6
        Me.groupButtons.TabStop = False
        '
        'btnAutoconnect
        '
        Me.btnAutoconnect.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnAutoconnect.Location = New System.Drawing.Point(89, 10)
        Me.btnAutoconnect.Margin = New System.Windows.Forms.Padding(0)
        Me.btnAutoconnect.Name = "btnAutoconnect"
        Me.btnAutoconnect.Size = New System.Drawing.Size(9, 21)
        Me.btnAutoconnect.TabIndex = 1
        Me.btnAutoconnect.Text = "▼"
        Me.ToolTip1.SetToolTip(Me.btnAutoconnect, "Autoconnect")
        Me.btnAutoconnect.UseVisualStyleBackColor = True
        '
        'buttonExport
        '
        Me.buttonExport.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.buttonExport.Font = New System.Drawing.Font("Segoe UI", 7.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.buttonExport.Location = New System.Drawing.Point(54, 35)
        Me.buttonExport.Name = "buttonExport"
        Me.buttonExport.Size = New System.Drawing.Size(44, 23)
        Me.buttonExport.TabIndex = 3
        Me.buttonExport.Text = "Export"
        Me.buttonExport.UseVisualStyleBackColor = True
        '
        'buttonImport
        '
        Me.buttonImport.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.buttonImport.Font = New System.Drawing.Font("Segoe UI", 7.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.buttonImport.ForeColor = System.Drawing.SystemColors.GrayText
        Me.buttonImport.Location = New System.Drawing.Point(54, 62)
        Me.buttonImport.Name = "buttonImport"
        Me.buttonImport.Size = New System.Drawing.Size(44, 23)
        Me.buttonImport.TabIndex = 5
        Me.buttonImport.Text = "Import"
        Me.buttonImport.UseVisualStyleBackColor = True
        '
        'buttonNewNode
        '
        Me.buttonNewNode.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.buttonNewNode.Font = New System.Drawing.Font("Segoe UI", 7.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.buttonNewNode.ForeColor = System.Drawing.SystemColors.GrayText
        Me.buttonNewNode.Location = New System.Drawing.Point(6, 62)
        Me.buttonNewNode.Name = "buttonNewNode"
        Me.buttonNewNode.Size = New System.Drawing.Size(44, 23)
        Me.buttonNewNode.TabIndex = 4
        Me.buttonNewNode.Text = "New"
        Me.buttonNewNode.UseVisualStyleBackColor = True
        '
        'buttonSave
        '
        Me.buttonSave.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.buttonSave.Font = New System.Drawing.Font("Segoe UI", 7.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.buttonSave.Location = New System.Drawing.Point(6, 35)
        Me.buttonSave.Name = "buttonSave"
        Me.buttonSave.Size = New System.Drawing.Size(44, 23)
        Me.buttonSave.TabIndex = 2
        Me.buttonSave.Text = "Save"
        Me.buttonSave.UseVisualStyleBackColor = True
        '
        'buttonConnect
        '
        Me.buttonConnect.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.buttonConnect.ForeColor = System.Drawing.Color.Green
        Me.buttonConnect.Location = New System.Drawing.Point(6, 9)
        Me.buttonConnect.Margin = New System.Windows.Forms.Padding(0)
        Me.buttonConnect.Name = "buttonConnect"
        Me.buttonConnect.Size = New System.Drawing.Size(84, 23)
        Me.buttonConnect.TabIndex = 0
        Me.buttonConnect.Text = "Connect"
        Me.buttonConnect.UseVisualStyleBackColor = True
        '
        'boxSystem
        '
        Me.boxSystem.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.boxSystem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.boxSystem.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.boxSystem.FormattingEnabled = True
        Me.boxSystem.Items.AddRange(New Object() {"Windows", "Linux", "Android", "MacOS", "other", "Application"})
        Me.boxSystem.Location = New System.Drawing.Point(115, 21)
        Me.boxSystem.Name = "boxSystem"
        Me.boxSystem.Size = New System.Drawing.Size(237, 21)
        Me.boxSystem.TabIndex = 1
        '
        'lblSystem
        '
        Me.lblSystem.AutoSize = True
        Me.lblSystem.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.lblSystem.Location = New System.Drawing.Point(7, 25)
        Me.lblSystem.Name = "lblSystem"
        Me.lblSystem.Size = New System.Drawing.Size(100, 13)
        Me.lblSystem.TabIndex = 0
        Me.lblSystem.Text = "Operating system:"
        '
        'groupConnectionSettings
        '
        Me.groupConnectionSettings.Controls.Add(Me.lblQuickConnect)
        Me.groupConnectionSettings.Controls.Add(Me.boxConnectOver)
        Me.groupConnectionSettings.Controls.Add(Me.boxPort)
        Me.groupConnectionSettings.Controls.Add(Me.lblPort)
        Me.groupConnectionSettings.Controls.Add(Me.boxIP)
        Me.groupConnectionSettings.Controls.Add(Me.lblIP)
        Me.groupConnectionSettings.Controls.Add(Me.boxName)
        Me.groupConnectionSettings.Controls.Add(Me.lblName)
        Me.groupConnectionSettings.Dock = System.Windows.Forms.DockStyle.Top
        Me.groupConnectionSettings.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.groupConnectionSettings.Location = New System.Drawing.Point(0, 0)
        Me.groupConnectionSettings.Name = "groupConnectionSettings"
        Me.groupConnectionSettings.Size = New System.Drawing.Size(638, 95)
        Me.groupConnectionSettings.TabIndex = 0
        Me.groupConnectionSettings.TabStop = False
        Me.groupConnectionSettings.Text = "Connection settings"
        '
        'lblQuickConnect
        '
        Me.lblQuickConnect.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblQuickConnect.AutoSize = True
        Me.lblQuickConnect.Font = New System.Drawing.Font("Segoe UI", 7.5!)
        Me.lblQuickConnect.LinkColor = System.Drawing.Color.DodgerBlue
        Me.lblQuickConnect.Location = New System.Drawing.Point(394, 0)
        Me.lblQuickConnect.Name = "lblQuickConnect"
        Me.lblQuickConnect.Size = New System.Drawing.Size(71, 12)
        Me.lblQuickConnect.TabIndex = 7
        Me.lblQuickConnect.TabStop = True
        Me.lblQuickConnect.Text = "Quick Connect"
        Me.lblQuickConnect.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.lblQuickConnect.VisitedLinkColor = System.Drawing.Color.DodgerBlue
        '
        'boxConnectOver
        '
        Me.boxConnectOver.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.boxConnectOver.AutoSize = True
        Me.boxConnectOver.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.boxConnectOver.Location = New System.Drawing.Point(372, 25)
        Me.boxConnectOver.Name = "boxConnectOver"
        Me.boxConnectOver.Size = New System.Drawing.Size(94, 17)
        Me.boxConnectOver.TabIndex = 6
        Me.boxConnectOver.Text = "Connect over"
        Me.boxConnectOver.UseVisualStyleBackColor = True
        '
        'boxPort
        '
        Me.boxPort.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.boxPort.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.boxPort.Location = New System.Drawing.Point(404, 56)
        Me.boxPort.Name = "boxPort"
        Me.boxPort.Size = New System.Drawing.Size(54, 22)
        Me.boxPort.TabIndex = 5
        Me.boxPort.Text = "3389"
        '
        'lblPort
        '
        Me.lblPort.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblPort.AutoSize = True
        Me.lblPort.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.lblPort.Location = New System.Drawing.Point(367, 59)
        Me.lblPort.Name = "lblPort"
        Me.lblPort.Size = New System.Drawing.Size(31, 13)
        Me.lblPort.TabIndex = 4
        Me.lblPort.Text = "Port:"
        '
        'boxIP
        '
        Me.boxIP.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.boxIP.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.boxIP.Location = New System.Drawing.Point(115, 56)
        Me.boxIP.Name = "boxIP"
        Me.boxIP.Size = New System.Drawing.Size(237, 22)
        Me.boxIP.TabIndex = 3
        '
        'lblIP
        '
        Me.lblIP.AutoSize = True
        Me.lblIP.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.lblIP.Location = New System.Drawing.Point(7, 53)
        Me.lblIP.Name = "lblIP"
        Me.lblIP.Size = New System.Drawing.Size(74, 26)
        Me.lblIP.TabIndex = 2
        Me.lblIP.Text = "IP Address or" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "hostname:"
        '
        'boxName
        '
        Me.boxName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.boxName.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.boxName.Location = New System.Drawing.Point(115, 23)
        Me.boxName.Name = "boxName"
        Me.boxName.Size = New System.Drawing.Size(237, 22)
        Me.boxName.TabIndex = 1
        '
        'lblName
        '
        Me.lblName.AutoSize = True
        Me.lblName.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.lblName.Location = New System.Drawing.Point(7, 26)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(39, 13)
        Me.lblName.TabIndex = 0
        Me.lblName.Text = "Name:"
        '
        'groupImage
        '
        Me.groupImage.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.groupImage.Controls.Add(Me.boxPicture)
        Me.groupImage.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.groupImage.Location = New System.Drawing.Point(723, 24)
        Me.groupImage.Name = "groupImage"
        Me.groupImage.Size = New System.Drawing.Size(169, 184)
        Me.groupImage.TabIndex = 1
        Me.groupImage.TabStop = False
        Me.groupImage.Text = "Image"
        '
        'boxPicture
        '
        Me.boxPicture.Dock = System.Windows.Forms.DockStyle.Fill
        Me.boxPicture.Location = New System.Drawing.Point(3, 18)
        Me.boxPicture.Name = "boxPicture"
        Me.boxPicture.Size = New System.Drawing.Size(163, 163)
        Me.boxPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.boxPicture.TabIndex = 0
        Me.boxPicture.TabStop = False
        '
        'menuBar
        '
        Me.menuBar.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.menuBar.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolsToolStripMenuItem, Me.OptionsToolStripMenuItem, Me.FTPServerToolStripMenuItem, Me.GreenshotToolStripMenuItem, Me.HelpToolStripMenuItem, Me.CompactModeToolStripMenuItem, Me.AutoconnectToolStripMenuItem})
        Me.menuBar.Location = New System.Drawing.Point(0, 0)
        Me.menuBar.Name = "menuBar"
        Me.menuBar.Size = New System.Drawing.Size(892, 24)
        Me.menuBar.TabIndex = 0
        Me.menuBar.Text = "MenuStrip1"
        '
        'ToolsToolStripMenuItem
        '
        Me.ToolsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LoadSourcesDatabaseToolStripMenuItem, Me.EditSourcesDatabaseToolStripMenuItem, Me.NewEmptySourcesDatabaseToolStripMenuItem, Me.ToolStripSeparator3, Me.AddNodeToolStripMenuItem, Me.ImportSourceToolStripMenuItem, Me.ExportSourceToolStripMenuItem, Me.SaveNodeToolStripMenuItem, Me.ToolStripSeparator2, Me.SaveStatisticsToolStripMenuItem, Me.ExitToolStripMenuItem})
        Me.ToolsToolStripMenuItem.Name = "ToolsToolStripMenuItem"
        Me.ToolsToolStripMenuItem.Size = New System.Drawing.Size(46, 20)
        Me.ToolsToolStripMenuItem.Text = "&Tools"
        '
        'LoadSourcesDatabaseToolStripMenuItem
        '
        Me.LoadSourcesDatabaseToolStripMenuItem.Image = CType(resources.GetObject("LoadSourcesDatabaseToolStripMenuItem.Image"), System.Drawing.Image)
        Me.LoadSourcesDatabaseToolStripMenuItem.Name = "LoadSourcesDatabaseToolStripMenuItem"
        Me.LoadSourcesDatabaseToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.O), System.Windows.Forms.Keys)
        Me.LoadSourcesDatabaseToolStripMenuItem.Size = New System.Drawing.Size(233, 22)
        Me.LoadSourcesDatabaseToolStripMenuItem.Text = "&Load sources database"
        '
        'EditSourcesDatabaseToolStripMenuItem
        '
        Me.EditSourcesDatabaseToolStripMenuItem.Image = CType(resources.GetObject("EditSourcesDatabaseToolStripMenuItem.Image"), System.Drawing.Image)
        Me.EditSourcesDatabaseToolStripMenuItem.Name = "EditSourcesDatabaseToolStripMenuItem"
        Me.EditSourcesDatabaseToolStripMenuItem.Size = New System.Drawing.Size(233, 22)
        Me.EditSourcesDatabaseToolStripMenuItem.Text = "&Edit sources database"
        '
        'NewEmptySourcesDatabaseToolStripMenuItem
        '
        Me.NewEmptySourcesDatabaseToolStripMenuItem.Image = CType(resources.GetObject("NewEmptySourcesDatabaseToolStripMenuItem.Image"), System.Drawing.Image)
        Me.NewEmptySourcesDatabaseToolStripMenuItem.Name = "NewEmptySourcesDatabaseToolStripMenuItem"
        Me.NewEmptySourcesDatabaseToolStripMenuItem.Size = New System.Drawing.Size(233, 22)
        Me.NewEmptySourcesDatabaseToolStripMenuItem.Text = "&New empty sources database"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(230, 6)
        '
        'AddNodeToolStripMenuItem
        '
        Me.AddNodeToolStripMenuItem.Image = CType(resources.GetObject("AddNodeToolStripMenuItem.Image"), System.Drawing.Image)
        Me.AddNodeToolStripMenuItem.Name = "AddNodeToolStripMenuItem"
        Me.AddNodeToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.N), System.Windows.Forms.Keys)
        Me.AddNodeToolStripMenuItem.Size = New System.Drawing.Size(233, 22)
        Me.AddNodeToolStripMenuItem.Text = "&New source"
        '
        'ImportSourceToolStripMenuItem
        '
        Me.ImportSourceToolStripMenuItem.Image = CType(resources.GetObject("ImportSourceToolStripMenuItem.Image"), System.Drawing.Image)
        Me.ImportSourceToolStripMenuItem.Name = "ImportSourceToolStripMenuItem"
        Me.ImportSourceToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.I), System.Windows.Forms.Keys)
        Me.ImportSourceToolStripMenuItem.Size = New System.Drawing.Size(233, 22)
        Me.ImportSourceToolStripMenuItem.Text = "&Import source"
        '
        'ExportSourceToolStripMenuItem
        '
        Me.ExportSourceToolStripMenuItem.Image = CType(resources.GetObject("ExportSourceToolStripMenuItem.Image"), System.Drawing.Image)
        Me.ExportSourceToolStripMenuItem.Name = "ExportSourceToolStripMenuItem"
        Me.ExportSourceToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.E), System.Windows.Forms.Keys)
        Me.ExportSourceToolStripMenuItem.Size = New System.Drawing.Size(233, 22)
        Me.ExportSourceToolStripMenuItem.Text = "E&xport source"
        '
        'SaveNodeToolStripMenuItem
        '
        Me.SaveNodeToolStripMenuItem.Image = CType(resources.GetObject("SaveNodeToolStripMenuItem.Image"), System.Drawing.Image)
        Me.SaveNodeToolStripMenuItem.Name = "SaveNodeToolStripMenuItem"
        Me.SaveNodeToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.S), System.Windows.Forms.Keys)
        Me.SaveNodeToolStripMenuItem.Size = New System.Drawing.Size(233, 22)
        Me.SaveNodeToolStripMenuItem.Text = "&Save source"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(230, 6)
        '
        'SaveStatisticsToolStripMenuItem
        '
        Me.SaveStatisticsToolStripMenuItem.Image = CType(resources.GetObject("SaveStatisticsToolStripMenuItem.Image"), System.Drawing.Image)
        Me.SaveStatisticsToolStripMenuItem.Name = "SaveStatisticsToolStripMenuItem"
        Me.SaveStatisticsToolStripMenuItem.Size = New System.Drawing.Size(233, 22)
        Me.SaveStatisticsToolStripMenuItem.Text = "&Save statistics"
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Image = CType(resources.GetObject("ExitToolStripMenuItem.Image"), System.Drawing.Image)
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.F4), System.Windows.Forms.Keys)
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(233, 22)
        Me.ExitToolStripMenuItem.Text = "&Exit"
        '
        'OptionsToolStripMenuItem
        '
        Me.OptionsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ColorOfStatisticsConsoleToolStripMenuItem, Me.ShowpreviewToolStripMenuItem, Me.ToolStripSeparator4, Me.CheckForupdateOnStartToolStripMenuItem, Me.ToolStripSeparator5, Me.AskBeforeCloseToolStripMenuItem, Me.SaveStatisticsOnCloseToolStripMenuItem, Me.KillChildProcessesOnCloseToolStripMenuItem})
        Me.OptionsToolStripMenuItem.Name = "OptionsToolStripMenuItem"
        Me.OptionsToolStripMenuItem.Size = New System.Drawing.Size(61, 20)
        Me.OptionsToolStripMenuItem.Text = "&Options"
        '
        'ColorOfStatisticsConsoleToolStripMenuItem
        '
        Me.ColorOfStatisticsConsoleToolStripMenuItem.BackColor = System.Drawing.SystemColors.Control
        Me.ColorOfStatisticsConsoleToolStripMenuItem.Image = CType(resources.GetObject("ColorOfStatisticsConsoleToolStripMenuItem.Image"), System.Drawing.Image)
        Me.ColorOfStatisticsConsoleToolStripMenuItem.Name = "ColorOfStatisticsConsoleToolStripMenuItem"
        Me.ColorOfStatisticsConsoleToolStripMenuItem.Size = New System.Drawing.Size(216, 22)
        Me.ColorOfStatisticsConsoleToolStripMenuItem.Text = "&Statistics console style"
        '
        'ShowpreviewToolStripMenuItem
        '
        Me.ShowpreviewToolStripMenuItem.Name = "ShowpreviewToolStripMenuItem"
        Me.ShowpreviewToolStripMenuItem.Size = New System.Drawing.Size(216, 22)
        Me.ShowpreviewToolStripMenuItem.Text = "Show &preview"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(213, 6)
        '
        'CheckForupdateOnStartToolStripMenuItem
        '
        Me.CheckForupdateOnStartToolStripMenuItem.Name = "CheckForupdateOnStartToolStripMenuItem"
        Me.CheckForupdateOnStartToolStripMenuItem.Size = New System.Drawing.Size(216, 22)
        Me.CheckForupdateOnStartToolStripMenuItem.Text = "Check for &update on start"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(213, 6)
        '
        'AskBeforeCloseToolStripMenuItem
        '
        Me.AskBeforeCloseToolStripMenuItem.Name = "AskBeforeCloseToolStripMenuItem"
        Me.AskBeforeCloseToolStripMenuItem.Size = New System.Drawing.Size(216, 22)
        Me.AskBeforeCloseToolStripMenuItem.Text = "&Ask before close"
        '
        'SaveStatisticsOnCloseToolStripMenuItem
        '
        Me.SaveStatisticsOnCloseToolStripMenuItem.Name = "SaveStatisticsOnCloseToolStripMenuItem"
        Me.SaveStatisticsOnCloseToolStripMenuItem.Size = New System.Drawing.Size(216, 22)
        Me.SaveStatisticsOnCloseToolStripMenuItem.Text = "&Save statistics on close"
        '
        'KillChildProcessesOnCloseToolStripMenuItem
        '
        Me.KillChildProcessesOnCloseToolStripMenuItem.Name = "KillChildProcessesOnCloseToolStripMenuItem"
        Me.KillChildProcessesOnCloseToolStripMenuItem.Size = New System.Drawing.Size(216, 22)
        Me.KillChildProcessesOnCloseToolStripMenuItem.Text = "&Kill child processes on close"
        '
        'FTPServerToolStripMenuItem
        '
        Me.FTPServerToolStripMenuItem.Name = "FTPServerToolStripMenuItem"
        Me.FTPServerToolStripMenuItem.Size = New System.Drawing.Size(70, 20)
        Me.FTPServerToolStripMenuItem.Text = "&FTP Server"
        Me.FTPServerToolStripMenuItem.Visible = False
        '
        'GreenshotToolStripMenuItem
        '
        Me.GreenshotToolStripMenuItem.Name = "GreenshotToolStripMenuItem"
        Me.GreenshotToolStripMenuItem.Size = New System.Drawing.Size(73, 20)
        Me.GreenshotToolStripMenuItem.Text = "&Greenshot"
        Me.GreenshotToolStripMenuItem.Visible = False
        '
        'HelpToolStripMenuItem
        '
        Me.HelpToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ViewHelpToolStripMenuItem, Me.ReportAnIssueToolStripMenuItem, Me.ToolStripSeparator1, Me.AboutToolStripMenuItem})
        Me.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem"
        Me.HelpToolStripMenuItem.Size = New System.Drawing.Size(43, 20)
        Me.HelpToolStripMenuItem.Text = "&Help"
        '
        'ViewHelpToolStripMenuItem
        '
        Me.ViewHelpToolStripMenuItem.Image = CType(resources.GetObject("ViewHelpToolStripMenuItem.Image"), System.Drawing.Image)
        Me.ViewHelpToolStripMenuItem.Name = "ViewHelpToolStripMenuItem"
        Me.ViewHelpToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F1
        Me.ViewHelpToolStripMenuItem.Size = New System.Drawing.Size(243, 22)
        Me.ViewHelpToolStripMenuItem.Text = "View &Help"
        '
        'ReportAnIssueToolStripMenuItem
        '
        Me.ReportAnIssueToolStripMenuItem.Image = CType(resources.GetObject("ReportAnIssueToolStripMenuItem.Image"), System.Drawing.Image)
        Me.ReportAnIssueToolStripMenuItem.Name = "ReportAnIssueToolStripMenuItem"
        Me.ReportAnIssueToolStripMenuItem.Size = New System.Drawing.Size(243, 22)
        Me.ReportAnIssueToolStripMenuItem.Text = "&Report an issue"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(240, 6)
        '
        'AboutToolStripMenuItem
        '
        Me.AboutToolStripMenuItem.Image = CType(resources.GetObject("AboutToolStripMenuItem.Image"), System.Drawing.Image)
        Me.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem"
        Me.AboutToolStripMenuItem.Size = New System.Drawing.Size(243, 22)
        Me.AboutToolStripMenuItem.Text = "&About Remote Desktop Manager"
        '
        'CompactModeToolStripMenuItem
        '
        Me.CompactModeToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.CompactModeToolStripMenuItem.Name = "CompactModeToolStripMenuItem"
        Me.CompactModeToolStripMenuItem.Size = New System.Drawing.Size(96, 20)
        Me.CompactModeToolStripMenuItem.Text = "&Compact mode"
        '
        'AutoconnectToolStripMenuItem
        '
        Me.AutoconnectToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.AutoconnectToolStripMenuItem.Name = "AutoconnectToolStripMenuItem"
        Me.AutoconnectToolStripMenuItem.Size = New System.Drawing.Size(119, 20)
        Me.AutoconnectToolStripMenuItem.Text = "Do &autoconnection"
        '
        'operatingSystemsImages
        '
        Me.operatingSystemsImages.ImageStream = CType(resources.GetObject("operatingSystemsImages.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.operatingSystemsImages.TransparentColor = System.Drawing.Color.Transparent
        Me.operatingSystemsImages.Images.SetKeyName(0, "windows.png")
        Me.operatingSystemsImages.Images.SetKeyName(1, "linux.png")
        Me.operatingSystemsImages.Images.SetKeyName(2, "android.png")
        Me.operatingSystemsImages.Images.SetKeyName(3, "apple.png")
        Me.operatingSystemsImages.Images.SetKeyName(4, "unknown.png")
        Me.operatingSystemsImages.Images.SetKeyName(5, "terminal.png")
        '
        'openSourceDb
        '
        Me.openSourceDb.DefaultExt = "rdman"
        Me.openSourceDb.FileName = "sources.rdman"
        Me.openSourceDb.Filter = "Sources database *.rdman|*.rdman|CSV file (sep. by semicolon) *.csv|*.csv"
        Me.openSourceDb.Title = "Open Sources Database file"
        '
        'saveStatistics
        '
        Me.saveStatistics.DefaultExt = "txt"
        Me.saveStatistics.FileName = "statistics.txt"
        Me.saveStatistics.Filter = "Text files *.txt|*.txt"
        Me.saveStatistics.Title = "Save Statistics file"
        '
        'monitorTimer
        '
        Me.monitorTimer.Interval = 1
        '
        'ftpPath
        '
        Me.ftpPath.Description = "Choose the path to directory which you want to share."
        '
        'processPreviewHover
        '
        Me.processPreviewHover.Interval = 40
        '
        'notifyIconCompactMode
        '
        Me.notifyIconCompactMode.BalloonTipText = "Open Remote Desktop Manager in compact mode by double click on this icon."
        Me.notifyIconCompactMode.BalloonTipTitle = "Remote Desktop Manager"
        Me.notifyIconCompactMode.Icon = CType(resources.GetObject("notifyIconCompactMode.Icon"), System.Drawing.Icon)
        Me.notifyIconCompactMode.Text = "Remote Desktop Manager"
        Me.notifyIconCompactMode.Visible = True
        '
        'showPasswordTimer
        '
        Me.showPasswordTimer.Interval = 5000
        '
        'mainForm
        '
        Me.AcceptButton = Me.buttonConnect
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(892, 523)
        Me.Controls.Add(Me.groupImage)
        Me.Controls.Add(Me.mainContainer)
        Me.Controls.Add(Me.menuBar)
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(800, 500)
        Me.Name = "mainForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Remote Desktop Manager"
        Me.mainContainer.Panel1.ResumeLayout(False)
        Me.mainContainer.Panel2.ResumeLayout(False)
        CType(Me.mainContainer, System.ComponentModel.ISupportInitialize).EndInit()
        Me.mainContainer.ResumeLayout(False)
        Me.containerSourcesMonitor.Panel1.ResumeLayout(False)
        Me.containerSourcesMonitor.Panel2.ResumeLayout(False)
        Me.containerSourcesMonitor.Panel2.PerformLayout()
        CType(Me.containerSourcesMonitor, System.ComponentModel.ISupportInitialize).EndInit()
        Me.containerSourcesMonitor.ResumeLayout(False)
        Me.groupSourcesList.ResumeLayout(False)
        Me.groupSourcesList.PerformLayout()
        Me.groupMonitor.ResumeLayout(False)
        Me.groupMonitor.PerformLayout()
        Me.contextMenuMonitor.ResumeLayout(False)
        Me.groupStatistics.ResumeLayout(False)
        Me.groupConnectOver.ResumeLayout(False)
        Me.groupConnectOver.PerformLayout()
        Me.groupResolutionSettings.ResumeLayout(False)
        Me.groupResolutionSettings.PerformLayout()
        Me.groupAdditionalInformations.ResumeLayout(False)
        Me.groupAdditionalInformations.PerformLayout()
        Me.boxCredentials.ResumeLayout(False)
        Me.boxCredentials.PerformLayout()
        Me.groupButtons.ResumeLayout(False)
        Me.groupConnectionSettings.ResumeLayout(False)
        Me.groupConnectionSettings.PerformLayout()
        Me.groupImage.ResumeLayout(False)
        CType(Me.boxPicture, System.ComponentModel.ISupportInitialize).EndInit()
        Me.menuBar.ResumeLayout(False)
        Me.menuBar.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents mainContainer As System.Windows.Forms.SplitContainer
    Friend WithEvents groupImage As System.Windows.Forms.GroupBox
    Friend WithEvents groupConnectionSettings As System.Windows.Forms.GroupBox
    Friend WithEvents boxIP As System.Windows.Forms.TextBox
    Friend WithEvents lblIP As System.Windows.Forms.Label
    Friend WithEvents boxName As System.Windows.Forms.TextBox
    Friend WithEvents lblName As System.Windows.Forms.Label
    Friend WithEvents boxPort As System.Windows.Forms.TextBox
    Friend WithEvents lblPort As System.Windows.Forms.Label
    Friend WithEvents groupAdditionalInformations As System.Windows.Forms.GroupBox
    Friend WithEvents boxSystem As System.Windows.Forms.ComboBox
    Friend WithEvents lblSystem As System.Windows.Forms.Label
    Friend WithEvents boxSystemVersion As System.Windows.Forms.TextBox
    Friend WithEvents lblVersion As System.Windows.Forms.Label
    Friend WithEvents boxDescription As System.Windows.Forms.TextBox
    Friend WithEvents lblDescription As System.Windows.Forms.Label
    Friend WithEvents groupStatistics As System.Windows.Forms.GroupBox
    Friend WithEvents buttonConnect As System.Windows.Forms.Button
    Friend WithEvents groupResolutionSettings As System.Windows.Forms.GroupBox
    Friend WithEvents lblWindowSizePix As System.Windows.Forms.Label
    Friend WithEvents lblWindowSizeX As System.Windows.Forms.Label
    Friend WithEvents boxHeight As System.Windows.Forms.TextBox
    Friend WithEvents boxMultimon As System.Windows.Forms.CheckBox
    Friend WithEvents boxWidth As System.Windows.Forms.TextBox
    Friend WithEvents menuBar As System.Windows.Forms.MenuStrip
    Friend WithEvents boxPicture As System.Windows.Forms.PictureBox
    Friend WithEvents ToolsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AddNodeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HelpToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ViewHelpToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents AboutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents buttonNewNode As System.Windows.Forms.Button
    Friend WithEvents buttonSave As System.Windows.Forms.Button
    Friend WithEvents operatingSystemsIcons As System.Windows.Forms.ImageList
    Friend WithEvents operatingSystemsImages As System.Windows.Forms.ImageList
    Friend WithEvents boxStatistics As System.Windows.Forms.RichTextBox
    Friend WithEvents groupButtons As System.Windows.Forms.GroupBox
    Friend WithEvents LoadSourcesDatabaseToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents openSourceDb As System.Windows.Forms.OpenFileDialog
    Friend WithEvents SaveStatisticsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents saveStatistics As System.Windows.Forms.SaveFileDialog
    Friend WithEvents SaveNodeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents sourcesList As System.Windows.Forms.ListView
    Friend WithEvents EditSourcesDatabaseToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents boxFullscreen As System.Windows.Forms.CheckBox
    Friend WithEvents NewEmptySourcesDatabaseToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents statisticsCommandLine As System.Windows.Forms.ComboBox
    Friend WithEvents groupConnectOver As System.Windows.Forms.GroupBox
    Friend WithEvents buttonLocateViewer As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents boxViewerPath As System.Windows.Forms.TextBox
    Friend WithEvents boxConnectOver As System.Windows.Forms.CheckBox
    Friend WithEvents OptionsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AskBeforeCloseToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CheckForupdateOnStartToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents boxSourcesPath As System.Windows.Forms.LinkLabel
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents SaveStatisticsOnCloseToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ColorOfStatisticsConsoleToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents monitor As System.Windows.Forms.ListView
    Friend WithEvents columnName As System.Windows.Forms.ColumnHeader
    Friend WithEvents columnIP As System.Windows.Forms.ColumnHeader
    Friend WithEvents columnState As System.Windows.Forms.ColumnHeader
    Friend WithEvents containerSourcesMonitor As System.Windows.Forms.SplitContainer
    Friend WithEvents columnPID As System.Windows.Forms.ColumnHeader
    Friend WithEvents monitorStates As System.Windows.Forms.ImageList
    Friend WithEvents monitorTimer As System.Windows.Forms.Timer
    Friend WithEvents columnArgs As System.Windows.Forms.ColumnHeader
    Friend WithEvents columnTime As System.Windows.Forms.ColumnHeader
    Friend WithEvents groupMonitor As System.Windows.Forms.GroupBox
    Friend WithEvents groupSourcesList As System.Windows.Forms.GroupBox
    Friend WithEvents ShowpreviewToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents KillChildProcessesOnCloseToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReportAnIssueToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FTPServerToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ftpPath As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents CompactModeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lblUsePutty As System.Windows.Forms.LinkLabel
    Friend WithEvents processPreviewHover As System.Windows.Forms.Timer
    Friend WithEvents pingAll As System.Windows.Forms.LinkLabel
    Friend WithEvents pingProgressBar As System.Windows.Forms.ProgressBar
    Friend WithEvents notifyIconCompactMode As System.Windows.Forms.NotifyIcon
    Friend WithEvents cleanTerminated As System.Windows.Forms.LinkLabel
    Friend WithEvents lblQuickConnect As System.Windows.Forms.LinkLabel
    Friend WithEvents buttonImport As System.Windows.Forms.Button
    Friend WithEvents buttonExport As System.Windows.Forms.Button
    Friend WithEvents ImportSourceToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExportSourceToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GreenshotToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents contextMenuMonitor As ContextMenuStrip
    Friend WithEvents MoveToNextScreenToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents boxCredentials As GroupBox
    Friend WithEvents textboxPassword As TextBox
    Friend WithEvents textboxUsername As TextBox
    Friend WithEvents lblCredentialsUser As Label
    Friend WithEvents btnAutoconnect As Button
    Friend WithEvents lblPassword As LinkLabel
    Friend WithEvents showPasswordTimer As Timer
    Friend WithEvents AutoconnectToolStripMenuItem As ToolStripMenuItem
End Class
