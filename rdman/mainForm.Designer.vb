﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class mainForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim ListViewItem2 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("Add New Node", 5)
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(mainForm))
        Me.mainContainer = New System.Windows.Forms.SplitContainer()
        Me.sourcesList = New System.Windows.Forms.ListView()
        Me.operatingSystemsIcons = New System.Windows.Forms.ImageList(Me.components)
        Me.groupStatistics = New System.Windows.Forms.GroupBox()
        Me.boxStatistics = New System.Windows.Forms.RichTextBox()
        Me.statisticsCommandLine = New System.Windows.Forms.ComboBox()
        Me.groupConnectOver = New System.Windows.Forms.GroupBox()
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
        Me.boxDescription = New System.Windows.Forms.TextBox()
        Me.lblDescription = New System.Windows.Forms.Label()
        Me.boxSystemVersion = New System.Windows.Forms.TextBox()
        Me.lblVersion = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.buttonNewNode = New System.Windows.Forms.Button()
        Me.buttonSave = New System.Windows.Forms.Button()
        Me.buttonConnect = New System.Windows.Forms.Button()
        Me.boxSystem = New System.Windows.Forms.ComboBox()
        Me.lblSystem = New System.Windows.Forms.Label()
        Me.groupConnectionSettings = New System.Windows.Forms.GroupBox()
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
        Me.SaveNodeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.SaveStatisticsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HelpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ViewHelpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.AboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.operatingSystemsImages = New System.Windows.Forms.ImageList(Me.components)
        Me.openSourceDb = New System.Windows.Forms.OpenFileDialog()
        Me.saveStatistics = New System.Windows.Forms.SaveFileDialog()
        Me.OptionsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AskBeforeCloseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CheckForupdateOnStartToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.boxSourcesPath = New System.Windows.Forms.LinkLabel()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        CType(Me.mainContainer, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.mainContainer.Panel1.SuspendLayout()
        Me.mainContainer.Panel2.SuspendLayout()
        Me.mainContainer.SuspendLayout()
        Me.groupStatistics.SuspendLayout()
        Me.groupConnectOver.SuspendLayout()
        Me.groupResolutionSettings.SuspendLayout()
        Me.groupAdditionalInformations.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
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
        Me.mainContainer.Panel1.Controls.Add(Me.sourcesList)
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
        Me.mainContainer.SplitterDistance = 229
        Me.mainContainer.TabIndex = 1
        '
        'sourcesList
        '
        Me.sourcesList.Alignment = System.Windows.Forms.ListViewAlignment.Left
        Me.sourcesList.AutoArrange = False
        Me.sourcesList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.sourcesList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
        Me.sourcesList.HideSelection = False
        Me.sourcesList.Items.AddRange(New System.Windows.Forms.ListViewItem() {ListViewItem2})
        Me.sourcesList.LabelWrap = False
        Me.sourcesList.Location = New System.Drawing.Point(0, 0)
        Me.sourcesList.MultiSelect = False
        Me.sourcesList.Name = "sourcesList"
        Me.sourcesList.ShowGroups = False
        Me.sourcesList.Size = New System.Drawing.Size(229, 477)
        Me.sourcesList.SmallImageList = Me.operatingSystemsIcons
        Me.sourcesList.Sorting = System.Windows.Forms.SortOrder.Ascending
        Me.sourcesList.TabIndex = 0
        Me.sourcesList.TileSize = New System.Drawing.Size(150, 24)
        Me.sourcesList.UseCompatibleStateImageBehavior = False
        Me.sourcesList.View = System.Windows.Forms.View.SmallIcon
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
        Me.operatingSystemsIcons.Images.SetKeyName(5, "plus.ico")
        '
        'groupStatistics
        '
        Me.groupStatistics.Controls.Add(Me.boxStatistics)
        Me.groupStatistics.Controls.Add(Me.statisticsCommandLine)
        Me.groupStatistics.Dock = System.Windows.Forms.DockStyle.Fill
        Me.groupStatistics.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.groupStatistics.Location = New System.Drawing.Point(0, 342)
        Me.groupStatistics.Name = "groupStatistics"
        Me.groupStatistics.Size = New System.Drawing.Size(659, 157)
        Me.groupStatistics.TabIndex = 4
        Me.groupStatistics.TabStop = False
        Me.groupStatistics.Text = "Statistics"
        '
        'boxStatistics
        '
        Me.boxStatistics.AutoWordSelection = True
        Me.boxStatistics.BackColor = System.Drawing.Color.Black
        Me.boxStatistics.Dock = System.Windows.Forms.DockStyle.Fill
        Me.boxStatistics.Font = New System.Drawing.Font("Lucida Console", 8.0!)
        Me.boxStatistics.ForeColor = System.Drawing.Color.LawnGreen
        Me.boxStatistics.Location = New System.Drawing.Point(3, 18)
        Me.boxStatistics.Name = "boxStatistics"
        Me.boxStatistics.ReadOnly = True
        Me.boxStatistics.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical
        Me.boxStatistics.ShowSelectionMargin = True
        Me.boxStatistics.Size = New System.Drawing.Size(653, 117)
        Me.boxStatistics.TabIndex = 0
        Me.boxStatistics.Text = ""
        '
        'statisticsCommandLine
        '
        Me.statisticsCommandLine.AutoCompleteCustomSource.AddRange(New String() {"about", "clear", "connect", "editsources", "environment", "exit", "help", "loadsources", "newnode", "nodeconnectover", "connectover", "nodedescription", "description", "nodefullscreen", "fullscreen", "nodeheight", "height", "nodeip", "ip", "nodemultimon", "multimon", "nodename", "name", "nodeport", "port", "nodesystem", "system", "nodesystemversion", "version", "nodeviewerpath", "viewer", "nodewidth", "width", "savenode", "savestats"})
        Me.statisticsCommandLine.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.statisticsCommandLine.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.statisticsCommandLine.BackColor = System.Drawing.Color.Black
        Me.statisticsCommandLine.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.statisticsCommandLine.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.statisticsCommandLine.Font = New System.Drawing.Font("Lucida Console", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.statisticsCommandLine.ForeColor = System.Drawing.Color.LawnGreen
        Me.statisticsCommandLine.FormattingEnabled = True
        Me.statisticsCommandLine.Items.AddRange(New Object() {"about", "clear", "connect", "connectover", "description", "editsources", "environment", "exit", "fullscreen", "height", "help", "ip", "loadsources", "multimon", "name", "newnode", "nodeconnectover", "nodedescription", "nodefullscreen", "nodeheight", "nodeip", "nodemultimon", "nodename", "nodeport", "nodesystem", "nodesystemversion", "nodeviewerpath", "nodewidth", "port", "savenode", "savestats", "system", "version", "viewer", "width"})
        Me.statisticsCommandLine.Location = New System.Drawing.Point(3, 135)
        Me.statisticsCommandLine.Name = "statisticsCommandLine"
        Me.statisticsCommandLine.Size = New System.Drawing.Size(653, 19)
        Me.statisticsCommandLine.Sorted = True
        Me.statisticsCommandLine.TabIndex = 3
        Me.statisticsCommandLine.Text = "Write command and launch it by pressing enter."
        '
        'groupConnectOver
        '
        Me.groupConnectOver.Controls.Add(Me.buttonLocateViewer)
        Me.groupConnectOver.Controls.Add(Me.Label2)
        Me.groupConnectOver.Controls.Add(Me.boxViewerPath)
        Me.groupConnectOver.Dock = System.Windows.Forms.DockStyle.Top
        Me.groupConnectOver.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.groupConnectOver.Location = New System.Drawing.Point(0, 292)
        Me.groupConnectOver.Name = "groupConnectOver"
        Me.groupConnectOver.Size = New System.Drawing.Size(659, 50)
        Me.groupConnectOver.TabIndex = 3
        Me.groupConnectOver.TabStop = False
        Me.groupConnectOver.Text = "Connect over"
        Me.groupConnectOver.Visible = False
        '
        'buttonLocateViewer
        '
        Me.buttonLocateViewer.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.buttonLocateViewer.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.buttonLocateViewer.Location = New System.Drawing.Point(622, 19)
        Me.buttonLocateViewer.Name = "buttonLocateViewer"
        Me.buttonLocateViewer.Size = New System.Drawing.Size(25, 23)
        Me.buttonLocateViewer.TabIndex = 13
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
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Locate viewer:"
        '
        'boxViewerPath
        '
        Me.boxViewerPath.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.boxViewerPath.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.boxViewerPath.Location = New System.Drawing.Point(115, 20)
        Me.boxViewerPath.Name = "boxViewerPath"
        Me.boxViewerPath.Size = New System.Drawing.Size(501, 22)
        Me.boxViewerPath.TabIndex = 12
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
        Me.groupResolutionSettings.Size = New System.Drawing.Size(659, 50)
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
        Me.Label1.TabIndex = 8
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
        Me.boxFullscreen.TabIndex = 8
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
        Me.lblWindowSizePix.TabIndex = 5
        Me.lblWindowSizePix.Text = "pixels"
        '
        'lblWindowSizeX
        '
        Me.lblWindowSizeX.AutoSize = True
        Me.lblWindowSizeX.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.lblWindowSizeX.Location = New System.Drawing.Point(470, 24)
        Me.lblWindowSizeX.Name = "lblWindowSizeX"
        Me.lblWindowSizeX.Size = New System.Drawing.Size(12, 13)
        Me.lblWindowSizeX.TabIndex = 3
        Me.lblWindowSizeX.Text = "x"
        '
        'boxHeight
        '
        Me.boxHeight.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.boxHeight.Location = New System.Drawing.Point(485, 20)
        Me.boxHeight.Name = "boxHeight"
        Me.boxHeight.ReadOnly = True
        Me.boxHeight.Size = New System.Drawing.Size(48, 22)
        Me.boxHeight.TabIndex = 11
        '
        'boxMultimon
        '
        Me.boxMultimon.AutoSize = True
        Me.boxMultimon.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.boxMultimon.Location = New System.Drawing.Point(115, 22)
        Me.boxMultimon.Name = "boxMultimon"
        Me.boxMultimon.Size = New System.Drawing.Size(194, 17)
        Me.boxMultimon.TabIndex = 9
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
        Me.boxWidth.TabIndex = 10
        '
        'groupAdditionalInformations
        '
        Me.groupAdditionalInformations.Controls.Add(Me.boxDescription)
        Me.groupAdditionalInformations.Controls.Add(Me.lblDescription)
        Me.groupAdditionalInformations.Controls.Add(Me.boxSystemVersion)
        Me.groupAdditionalInformations.Controls.Add(Me.lblVersion)
        Me.groupAdditionalInformations.Controls.Add(Me.GroupBox1)
        Me.groupAdditionalInformations.Controls.Add(Me.boxSystem)
        Me.groupAdditionalInformations.Controls.Add(Me.lblSystem)
        Me.groupAdditionalInformations.Dock = System.Windows.Forms.DockStyle.Top
        Me.groupAdditionalInformations.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.groupAdditionalInformations.Location = New System.Drawing.Point(0, 95)
        Me.groupAdditionalInformations.Name = "groupAdditionalInformations"
        Me.groupAdditionalInformations.Size = New System.Drawing.Size(659, 147)
        Me.groupAdditionalInformations.TabIndex = 1
        Me.groupAdditionalInformations.TabStop = False
        Me.groupAdditionalInformations.Text = "Additional informations"
        '
        'boxDescription
        '
        Me.boxDescription.AcceptsReturn = True
        Me.boxDescription.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.boxDescription.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.boxDescription.Location = New System.Drawing.Point(3, 92)
        Me.boxDescription.Multiline = True
        Me.boxDescription.Name = "boxDescription"
        Me.boxDescription.Size = New System.Drawing.Size(653, 52)
        Me.boxDescription.TabIndex = 7
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
        Me.boxSystemVersion.Size = New System.Drawing.Size(258, 22)
        Me.boxSystemVersion.TabIndex = 6
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
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.buttonNewNode)
        Me.GroupBox1.Controls.Add(Me.buttonSave)
        Me.GroupBox1.Controls.Add(Me.buttonConnect)
        Me.GroupBox1.Location = New System.Drawing.Point(388, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(107, 90)
        Me.GroupBox1.TabIndex = 6
        Me.GroupBox1.TabStop = False
        '
        'buttonNewNode
        '
        Me.buttonNewNode.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.buttonNewNode.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.buttonNewNode.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.buttonNewNode.ForeColor = System.Drawing.SystemColors.GrayText
        Me.buttonNewNode.Location = New System.Drawing.Point(16, 63)
        Me.buttonNewNode.Name = "buttonNewNode"
        Me.buttonNewNode.Size = New System.Drawing.Size(75, 23)
        Me.buttonNewNode.TabIndex = 0
        Me.buttonNewNode.Text = "New Node"
        Me.buttonNewNode.UseVisualStyleBackColor = True
        '
        'buttonSave
        '
        Me.buttonSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.buttonSave.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.buttonSave.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.buttonSave.Location = New System.Drawing.Point(16, 36)
        Me.buttonSave.Name = "buttonSave"
        Me.buttonSave.Size = New System.Drawing.Size(75, 23)
        Me.buttonSave.TabIndex = 0
        Me.buttonSave.Text = "Save Node"
        Me.buttonSave.UseVisualStyleBackColor = True
        '
        'buttonConnect
        '
        Me.buttonConnect.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.buttonConnect.ForeColor = System.Drawing.Color.Green
        Me.buttonConnect.Location = New System.Drawing.Point(16, 9)
        Me.buttonConnect.Name = "buttonConnect"
        Me.buttonConnect.Size = New System.Drawing.Size(75, 23)
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
        Me.boxSystem.Items.AddRange(New Object() {"Windows", "Linux", "Android", "MacOS", "other"})
        Me.boxSystem.Location = New System.Drawing.Point(115, 21)
        Me.boxSystem.Name = "boxSystem"
        Me.boxSystem.Size = New System.Drawing.Size(258, 21)
        Me.boxSystem.TabIndex = 5
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
        Me.groupConnectionSettings.Size = New System.Drawing.Size(659, 95)
        Me.groupConnectionSettings.TabIndex = 0
        Me.groupConnectionSettings.TabStop = False
        Me.groupConnectionSettings.Text = "Connection settings"
        '
        'boxConnectOver
        '
        Me.boxConnectOver.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.boxConnectOver.AutoSize = True
        Me.boxConnectOver.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.boxConnectOver.Location = New System.Drawing.Point(393, 25)
        Me.boxConnectOver.Name = "boxConnectOver"
        Me.boxConnectOver.Size = New System.Drawing.Size(94, 17)
        Me.boxConnectOver.TabIndex = 4
        Me.boxConnectOver.Text = "Connect over"
        Me.boxConnectOver.UseVisualStyleBackColor = True
        '
        'boxPort
        '
        Me.boxPort.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.boxPort.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.boxPort.Location = New System.Drawing.Point(425, 56)
        Me.boxPort.Name = "boxPort"
        Me.boxPort.Size = New System.Drawing.Size(54, 22)
        Me.boxPort.TabIndex = 3
        Me.boxPort.Text = "3389"
        '
        'lblPort
        '
        Me.lblPort.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblPort.AutoSize = True
        Me.lblPort.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.lblPort.Location = New System.Drawing.Point(388, 59)
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
        Me.boxIP.Size = New System.Drawing.Size(258, 22)
        Me.boxIP.TabIndex = 2
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
        Me.boxName.Size = New System.Drawing.Size(258, 22)
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
        Me.groupImage.Size = New System.Drawing.Size(169, 185)
        Me.groupImage.TabIndex = 5
        Me.groupImage.TabStop = False
        Me.groupImage.Text = "Image"
        '
        'boxPicture
        '
        Me.boxPicture.Dock = System.Windows.Forms.DockStyle.Fill
        Me.boxPicture.Location = New System.Drawing.Point(3, 18)
        Me.boxPicture.Name = "boxPicture"
        Me.boxPicture.Size = New System.Drawing.Size(163, 164)
        Me.boxPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.boxPicture.TabIndex = 0
        Me.boxPicture.TabStop = False
        '
        'menuBar
        '
        Me.menuBar.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.menuBar.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolsToolStripMenuItem, Me.OptionsToolStripMenuItem, Me.HelpToolStripMenuItem})
        Me.menuBar.Location = New System.Drawing.Point(0, 0)
        Me.menuBar.Name = "menuBar"
        Me.menuBar.Size = New System.Drawing.Size(892, 24)
        Me.menuBar.TabIndex = 0
        Me.menuBar.Text = "MenuStrip1"
        '
        'ToolsToolStripMenuItem
        '
        Me.ToolsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LoadSourcesDatabaseToolStripMenuItem, Me.EditSourcesDatabaseToolStripMenuItem, Me.NewEmptySourcesDatabaseToolStripMenuItem, Me.ToolStripSeparator3, Me.AddNodeToolStripMenuItem, Me.SaveNodeToolStripMenuItem, Me.ToolStripSeparator2, Me.SaveStatisticsToolStripMenuItem, Me.ExitToolStripMenuItem})
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
        Me.AddNodeToolStripMenuItem.Text = "&New Node"
        '
        'SaveNodeToolStripMenuItem
        '
        Me.SaveNodeToolStripMenuItem.Image = CType(resources.GetObject("SaveNodeToolStripMenuItem.Image"), System.Drawing.Image)
        Me.SaveNodeToolStripMenuItem.Name = "SaveNodeToolStripMenuItem"
        Me.SaveNodeToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.S), System.Windows.Forms.Keys)
        Me.SaveNodeToolStripMenuItem.Size = New System.Drawing.Size(233, 22)
        Me.SaveNodeToolStripMenuItem.Text = "&Save Node"
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
        'HelpToolStripMenuItem
        '
        Me.HelpToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ViewHelpToolStripMenuItem, Me.ToolStripSeparator1, Me.AboutToolStripMenuItem})
        Me.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem"
        Me.HelpToolStripMenuItem.Size = New System.Drawing.Size(43, 20)
        Me.HelpToolStripMenuItem.Text = "&Help"
        '
        'ViewHelpToolStripMenuItem
        '
        Me.ViewHelpToolStripMenuItem.Image = CType(resources.GetObject("ViewHelpToolStripMenuItem.Image"), System.Drawing.Image)
        Me.ViewHelpToolStripMenuItem.Name = "ViewHelpToolStripMenuItem"
        Me.ViewHelpToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.F1), System.Windows.Forms.Keys)
        Me.ViewHelpToolStripMenuItem.Size = New System.Drawing.Size(243, 22)
        Me.ViewHelpToolStripMenuItem.Text = "View &Help"
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
        'operatingSystemsImages
        '
        Me.operatingSystemsImages.ImageStream = CType(resources.GetObject("operatingSystemsImages.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.operatingSystemsImages.TransparentColor = System.Drawing.Color.Transparent
        Me.operatingSystemsImages.Images.SetKeyName(0, "windows.png")
        Me.operatingSystemsImages.Images.SetKeyName(1, "linux.png")
        Me.operatingSystemsImages.Images.SetKeyName(2, "android.png")
        Me.operatingSystemsImages.Images.SetKeyName(3, "apple.png")
        Me.operatingSystemsImages.Images.SetKeyName(4, "unknown.png")
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
        'OptionsToolStripMenuItem
        '
        Me.OptionsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AskBeforeCloseToolStripMenuItem, Me.CheckForupdateOnStartToolStripMenuItem})
        Me.OptionsToolStripMenuItem.Name = "OptionsToolStripMenuItem"
        Me.OptionsToolStripMenuItem.Size = New System.Drawing.Size(61, 20)
        Me.OptionsToolStripMenuItem.Text = "&Options"
        '
        'AskBeforeCloseToolStripMenuItem
        '
        Me.AskBeforeCloseToolStripMenuItem.Checked = True
        Me.AskBeforeCloseToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked
        Me.AskBeforeCloseToolStripMenuItem.Name = "AskBeforeCloseToolStripMenuItem"
        Me.AskBeforeCloseToolStripMenuItem.Size = New System.Drawing.Size(206, 22)
        Me.AskBeforeCloseToolStripMenuItem.Text = "&Ask before close"
        '
        'CheckForupdateOnStartToolStripMenuItem
        '
        Me.CheckForupdateOnStartToolStripMenuItem.Checked = True
        Me.CheckForupdateOnStartToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckForupdateOnStartToolStripMenuItem.Name = "CheckForupdateOnStartToolStripMenuItem"
        Me.CheckForupdateOnStartToolStripMenuItem.Size = New System.Drawing.Size(206, 22)
        Me.CheckForupdateOnStartToolStripMenuItem.Text = "Check for &update on start"
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
        Me.boxSourcesPath.Size = New System.Drawing.Size(229, 22)
        Me.boxSourcesPath.TabIndex = 1
        Me.boxSourcesPath.Text = "Loaded: "
        Me.boxSourcesPath.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        Me.ToolTip1.SetToolTip(Me.boxSourcesPath, "Edit sources database")
        Me.boxSourcesPath.UseCompatibleTextRendering = True
        Me.boxSourcesPath.VisitedLinkColor = System.Drawing.Color.DodgerBlue
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
        Me.groupStatistics.ResumeLayout(False)
        Me.groupConnectOver.ResumeLayout(False)
        Me.groupConnectOver.PerformLayout()
        Me.groupResolutionSettings.ResumeLayout(False)
        Me.groupResolutionSettings.PerformLayout()
        Me.groupAdditionalInformations.ResumeLayout(False)
        Me.groupAdditionalInformations.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
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
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
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

End Class
