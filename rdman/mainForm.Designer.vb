<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
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
        Me.statisticsCommandLine = New System.Windows.Forms.TextBox()
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
        Me.boxSystem = New System.Windows.Forms.ComboBox()
        Me.lblSystem = New System.Windows.Forms.Label()
        Me.groupConnectionSettings = New System.Windows.Forms.GroupBox()
        Me.boxPort = New System.Windows.Forms.TextBox()
        Me.lblPort = New System.Windows.Forms.Label()
        Me.buttonConnect = New System.Windows.Forms.Button()
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
        CType(Me.mainContainer, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.mainContainer.Panel1.SuspendLayout()
        Me.mainContainer.Panel2.SuspendLayout()
        Me.mainContainer.SuspendLayout()
        Me.groupStatistics.SuspendLayout()
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
        '
        'mainContainer.Panel2
        '
        Me.mainContainer.Panel2.Controls.Add(Me.groupStatistics)
        Me.mainContainer.Panel2.Controls.Add(Me.groupResolutionSettings)
        Me.mainContainer.Panel2.Controls.Add(Me.groupAdditionalInformations)
        Me.mainContainer.Panel2.Controls.Add(Me.groupConnectionSettings)
        Me.mainContainer.Size = New System.Drawing.Size(792, 487)
        Me.mainContainer.SplitterDistance = 204
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
        Me.sourcesList.Size = New System.Drawing.Size(204, 487)
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
        Me.groupStatistics.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.groupStatistics.Location = New System.Drawing.Point(0, 318)
        Me.groupStatistics.Name = "groupStatistics"
        Me.groupStatistics.Size = New System.Drawing.Size(584, 169)
        Me.groupStatistics.TabIndex = 5
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
        Me.boxStatistics.Location = New System.Drawing.Point(3, 16)
        Me.boxStatistics.Name = "boxStatistics"
        Me.boxStatistics.ReadOnly = True
        Me.boxStatistics.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical
        Me.boxStatistics.ShowSelectionMargin = True
        Me.boxStatistics.Size = New System.Drawing.Size(578, 130)
        Me.boxStatistics.TabIndex = 0
        Me.boxStatistics.Text = ""
        '
        'statisticsCommandLine
        '
        Me.statisticsCommandLine.AcceptsReturn = True
        Me.statisticsCommandLine.BackColor = System.Drawing.Color.Black
        Me.statisticsCommandLine.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.statisticsCommandLine.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.statisticsCommandLine.Font = New System.Drawing.Font("Lucida Console", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.statisticsCommandLine.ForeColor = System.Drawing.Color.LawnGreen
        Me.statisticsCommandLine.Location = New System.Drawing.Point(3, 146)
        Me.statisticsCommandLine.Multiline = True
        Me.statisticsCommandLine.Name = "statisticsCommandLine"
        Me.statisticsCommandLine.Size = New System.Drawing.Size(578, 20)
        Me.statisticsCommandLine.TabIndex = 1
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
        Me.groupResolutionSettings.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.groupResolutionSettings.Location = New System.Drawing.Point(0, 242)
        Me.groupResolutionSettings.Name = "groupResolutionSettings"
        Me.groupResolutionSettings.Size = New System.Drawing.Size(584, 76)
        Me.groupResolutionSettings.TabIndex = 1
        Me.groupResolutionSettings.TabStop = False
        Me.groupResolutionSettings.Text = "Resolution settings"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label1.Location = New System.Drawing.Point(173, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(70, 13)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "Window size:"
        '
        'boxFullscreen
        '
        Me.boxFullscreen.AutoSize = True
        Me.boxFullscreen.Checked = True
        Me.boxFullscreen.CheckState = System.Windows.Forms.CheckState.Checked
        Me.boxFullscreen.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.boxFullscreen.Location = New System.Drawing.Point(10, 22)
        Me.boxFullscreen.Name = "boxFullscreen"
        Me.boxFullscreen.Size = New System.Drawing.Size(74, 17)
        Me.boxFullscreen.TabIndex = 7
        Me.boxFullscreen.Text = "Fullscreen"
        Me.boxFullscreen.UseVisualStyleBackColor = True
        '
        'lblWindowSizePix
        '
        Me.lblWindowSizePix.AutoSize = True
        Me.lblWindowSizePix.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.lblWindowSizePix.Location = New System.Drawing.Point(369, 23)
        Me.lblWindowSizePix.Name = "lblWindowSizePix"
        Me.lblWindowSizePix.Size = New System.Drawing.Size(33, 13)
        Me.lblWindowSizePix.TabIndex = 5
        Me.lblWindowSizePix.Text = "pixels"
        '
        'lblWindowSizeX
        '
        Me.lblWindowSizeX.AutoSize = True
        Me.lblWindowSizeX.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.lblWindowSizeX.Location = New System.Drawing.Point(302, 23)
        Me.lblWindowSizeX.Name = "lblWindowSizeX"
        Me.lblWindowSizeX.Size = New System.Drawing.Size(12, 13)
        Me.lblWindowSizeX.TabIndex = 3
        Me.lblWindowSizeX.Text = "x"
        '
        'boxHeight
        '
        Me.boxHeight.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.boxHeight.Location = New System.Drawing.Point(317, 20)
        Me.boxHeight.Name = "boxHeight"
        Me.boxHeight.ReadOnly = True
        Me.boxHeight.Size = New System.Drawing.Size(48, 20)
        Me.boxHeight.TabIndex = 4
        '
        'boxMultimon
        '
        Me.boxMultimon.AutoSize = True
        Me.boxMultimon.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.boxMultimon.Location = New System.Drawing.Point(47, 45)
        Me.boxMultimon.Name = "boxMultimon"
        Me.boxMultimon.Size = New System.Drawing.Size(127, 17)
        Me.boxMultimon.TabIndex = 0
        Me.boxMultimon.Text = "Span remote desktop"
        Me.boxMultimon.UseVisualStyleBackColor = True
        '
        'boxWidth
        '
        Me.boxWidth.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.boxWidth.Location = New System.Drawing.Point(249, 20)
        Me.boxWidth.Name = "boxWidth"
        Me.boxWidth.ReadOnly = True
        Me.boxWidth.Size = New System.Drawing.Size(48, 20)
        Me.boxWidth.TabIndex = 2
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
        Me.groupAdditionalInformations.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.groupAdditionalInformations.Location = New System.Drawing.Point(0, 95)
        Me.groupAdditionalInformations.Name = "groupAdditionalInformations"
        Me.groupAdditionalInformations.Size = New System.Drawing.Size(584, 147)
        Me.groupAdditionalInformations.TabIndex = 2
        Me.groupAdditionalInformations.TabStop = False
        Me.groupAdditionalInformations.Text = "Additional informations"
        '
        'boxDescription
        '
        Me.boxDescription.AcceptsReturn = True
        Me.boxDescription.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.boxDescription.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.boxDescription.Location = New System.Drawing.Point(3, 92)
        Me.boxDescription.Multiline = True
        Me.boxDescription.Name = "boxDescription"
        Me.boxDescription.Size = New System.Drawing.Size(578, 52)
        Me.boxDescription.TabIndex = 5
        '
        'lblDescription
        '
        Me.lblDescription.AutoSize = True
        Me.lblDescription.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.lblDescription.Location = New System.Drawing.Point(6, 76)
        Me.lblDescription.Name = "lblDescription"
        Me.lblDescription.Size = New System.Drawing.Size(63, 13)
        Me.lblDescription.TabIndex = 4
        Me.lblDescription.Text = "Description:"
        '
        'boxSystemVersion
        '
        Me.boxSystemVersion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.boxSystemVersion.Location = New System.Drawing.Point(104, 49)
        Me.boxSystemVersion.Name = "boxSystemVersion"
        Me.boxSystemVersion.Size = New System.Drawing.Size(193, 20)
        Me.boxSystemVersion.TabIndex = 3
        '
        'lblVersion
        '
        Me.lblVersion.AutoSize = True
        Me.lblVersion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.lblVersion.Location = New System.Drawing.Point(7, 52)
        Me.lblVersion.Name = "lblVersion"
        Me.lblVersion.Size = New System.Drawing.Size(45, 13)
        Me.lblVersion.TabIndex = 2
        Me.lblVersion.Text = "Version:"
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.buttonNewNode)
        Me.GroupBox1.Controls.Add(Me.buttonSave)
        Me.GroupBox1.Location = New System.Drawing.Point(303, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(120, 90)
        Me.GroupBox1.TabIndex = 6
        Me.GroupBox1.TabStop = False
        '
        'buttonNewNode
        '
        Me.buttonNewNode.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.buttonNewNode.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.buttonNewNode.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.buttonNewNode.ForeColor = System.Drawing.SystemColors.GrayText
        Me.buttonNewNode.Location = New System.Drawing.Point(19, 47)
        Me.buttonNewNode.Name = "buttonNewNode"
        Me.buttonNewNode.Size = New System.Drawing.Size(75, 23)
        Me.buttonNewNode.TabIndex = 8
        Me.buttonNewNode.Text = "New Node"
        Me.buttonNewNode.UseVisualStyleBackColor = True
        '
        'buttonSave
        '
        Me.buttonSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.buttonSave.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.buttonSave.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.buttonSave.Location = New System.Drawing.Point(19, 20)
        Me.buttonSave.Name = "buttonSave"
        Me.buttonSave.Size = New System.Drawing.Size(75, 23)
        Me.buttonSave.TabIndex = 7
        Me.buttonSave.Text = "Save Node"
        Me.buttonSave.UseVisualStyleBackColor = True
        '
        'boxSystem
        '
        Me.boxSystem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.boxSystem.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.boxSystem.FormattingEnabled = True
        Me.boxSystem.Items.AddRange(New Object() {"Windows", "Linux", "Android", "MacOS", "other"})
        Me.boxSystem.Location = New System.Drawing.Point(104, 22)
        Me.boxSystem.Name = "boxSystem"
        Me.boxSystem.Size = New System.Drawing.Size(193, 21)
        Me.boxSystem.TabIndex = 1
        '
        'lblSystem
        '
        Me.lblSystem.AutoSize = True
        Me.lblSystem.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.lblSystem.Location = New System.Drawing.Point(7, 25)
        Me.lblSystem.Name = "lblSystem"
        Me.lblSystem.Size = New System.Drawing.Size(91, 13)
        Me.lblSystem.TabIndex = 0
        Me.lblSystem.Text = "Operating system:"
        '
        'groupConnectionSettings
        '
        Me.groupConnectionSettings.Controls.Add(Me.boxPort)
        Me.groupConnectionSettings.Controls.Add(Me.lblPort)
        Me.groupConnectionSettings.Controls.Add(Me.buttonConnect)
        Me.groupConnectionSettings.Controls.Add(Me.boxIP)
        Me.groupConnectionSettings.Controls.Add(Me.lblIP)
        Me.groupConnectionSettings.Controls.Add(Me.boxName)
        Me.groupConnectionSettings.Controls.Add(Me.lblName)
        Me.groupConnectionSettings.Dock = System.Windows.Forms.DockStyle.Top
        Me.groupConnectionSettings.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.groupConnectionSettings.Location = New System.Drawing.Point(0, 0)
        Me.groupConnectionSettings.Name = "groupConnectionSettings"
        Me.groupConnectionSettings.Size = New System.Drawing.Size(584, 95)
        Me.groupConnectionSettings.TabIndex = 0
        Me.groupConnectionSettings.TabStop = False
        Me.groupConnectionSettings.Text = "Connection settings"
        '
        'boxPort
        '
        Me.boxPort.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.boxPort.Location = New System.Drawing.Point(349, 56)
        Me.boxPort.Name = "boxPort"
        Me.boxPort.Size = New System.Drawing.Size(48, 20)
        Me.boxPort.TabIndex = 5
        Me.boxPort.Text = "3389"
        '
        'lblPort
        '
        Me.lblPort.AutoSize = True
        Me.lblPort.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.lblPort.Location = New System.Drawing.Point(314, 59)
        Me.lblPort.Name = "lblPort"
        Me.lblPort.Size = New System.Drawing.Size(29, 13)
        Me.lblPort.TabIndex = 4
        Me.lblPort.Text = "Port:"
        '
        'buttonConnect
        '
        Me.buttonConnect.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.buttonConnect.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.buttonConnect.ForeColor = System.Drawing.Color.Green
        Me.buttonConnect.Location = New System.Drawing.Point(322, 21)
        Me.buttonConnect.Name = "buttonConnect"
        Me.buttonConnect.Size = New System.Drawing.Size(75, 23)
        Me.buttonConnect.TabIndex = 0
        Me.buttonConnect.Text = "Connect"
        Me.buttonConnect.UseVisualStyleBackColor = True
        '
        'boxIP
        '
        Me.boxIP.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.boxIP.Location = New System.Drawing.Point(104, 56)
        Me.boxIP.Name = "boxIP"
        Me.boxIP.Size = New System.Drawing.Size(193, 20)
        Me.boxIP.TabIndex = 3
        '
        'lblIP
        '
        Me.lblIP.AutoSize = True
        Me.lblIP.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.lblIP.Location = New System.Drawing.Point(7, 53)
        Me.lblIP.Name = "lblIP"
        Me.lblIP.Size = New System.Drawing.Size(70, 26)
        Me.lblIP.TabIndex = 2
        Me.lblIP.Text = "IP Address or" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "hostname:"
        '
        'boxName
        '
        Me.boxName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.boxName.Location = New System.Drawing.Point(104, 23)
        Me.boxName.Name = "boxName"
        Me.boxName.Size = New System.Drawing.Size(193, 20)
        Me.boxName.TabIndex = 1
        '
        'lblName
        '
        Me.lblName.AutoSize = True
        Me.lblName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.lblName.Location = New System.Drawing.Point(7, 26)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(38, 13)
        Me.lblName.TabIndex = 0
        Me.lblName.Text = "Name:"
        '
        'groupImage
        '
        Me.groupImage.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.groupImage.Controls.Add(Me.boxPicture)
        Me.groupImage.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.groupImage.Location = New System.Drawing.Point(623, 24)
        Me.groupImage.Name = "groupImage"
        Me.groupImage.Size = New System.Drawing.Size(169, 185)
        Me.groupImage.TabIndex = 4
        Me.groupImage.TabStop = False
        Me.groupImage.Text = "Image"
        '
        'boxPicture
        '
        Me.boxPicture.Dock = System.Windows.Forms.DockStyle.Fill
        Me.boxPicture.Location = New System.Drawing.Point(3, 16)
        Me.boxPicture.Name = "boxPicture"
        Me.boxPicture.Size = New System.Drawing.Size(163, 166)
        Me.boxPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.boxPicture.TabIndex = 0
        Me.boxPicture.TabStop = False
        '
        'menuBar
        '
        Me.menuBar.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolsToolStripMenuItem, Me.HelpToolStripMenuItem})
        Me.menuBar.Location = New System.Drawing.Point(0, 0)
        Me.menuBar.Name = "menuBar"
        Me.menuBar.Size = New System.Drawing.Size(792, 24)
        Me.menuBar.TabIndex = 0
        Me.menuBar.Text = "MenuStrip1"
        '
        'ToolsToolStripMenuItem
        '
        Me.ToolsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LoadSourcesDatabaseToolStripMenuItem, Me.EditSourcesDatabaseToolStripMenuItem, Me.ToolStripSeparator3, Me.AddNodeToolStripMenuItem, Me.SaveNodeToolStripMenuItem, Me.ToolStripSeparator2, Me.SaveStatisticsToolStripMenuItem, Me.ExitToolStripMenuItem})
        Me.ToolsToolStripMenuItem.Name = "ToolsToolStripMenuItem"
        Me.ToolsToolStripMenuItem.Size = New System.Drawing.Size(47, 20)
        Me.ToolsToolStripMenuItem.Text = "&Tools"
        '
        'LoadSourcesDatabaseToolStripMenuItem
        '
        Me.LoadSourcesDatabaseToolStripMenuItem.Image = CType(resources.GetObject("LoadSourcesDatabaseToolStripMenuItem.Image"), System.Drawing.Image)
        Me.LoadSourcesDatabaseToolStripMenuItem.Name = "LoadSourcesDatabaseToolStripMenuItem"
        Me.LoadSourcesDatabaseToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.O), System.Windows.Forms.Keys)
        Me.LoadSourcesDatabaseToolStripMenuItem.Size = New System.Drawing.Size(232, 22)
        Me.LoadSourcesDatabaseToolStripMenuItem.Text = "&Load sources database"
        '
        'EditSourcesDatabaseToolStripMenuItem
        '
        Me.EditSourcesDatabaseToolStripMenuItem.Image = CType(resources.GetObject("EditSourcesDatabaseToolStripMenuItem.Image"), System.Drawing.Image)
        Me.EditSourcesDatabaseToolStripMenuItem.Name = "EditSourcesDatabaseToolStripMenuItem"
        Me.EditSourcesDatabaseToolStripMenuItem.Size = New System.Drawing.Size(232, 22)
        Me.EditSourcesDatabaseToolStripMenuItem.Text = "&Edit sources database"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(229, 6)
        '
        'AddNodeToolStripMenuItem
        '
        Me.AddNodeToolStripMenuItem.Image = CType(resources.GetObject("AddNodeToolStripMenuItem.Image"), System.Drawing.Image)
        Me.AddNodeToolStripMenuItem.Name = "AddNodeToolStripMenuItem"
        Me.AddNodeToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.N), System.Windows.Forms.Keys)
        Me.AddNodeToolStripMenuItem.Size = New System.Drawing.Size(232, 22)
        Me.AddNodeToolStripMenuItem.Text = "&New Node"
        '
        'SaveNodeToolStripMenuItem
        '
        Me.SaveNodeToolStripMenuItem.Image = CType(resources.GetObject("SaveNodeToolStripMenuItem.Image"), System.Drawing.Image)
        Me.SaveNodeToolStripMenuItem.Name = "SaveNodeToolStripMenuItem"
        Me.SaveNodeToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.S), System.Windows.Forms.Keys)
        Me.SaveNodeToolStripMenuItem.Size = New System.Drawing.Size(232, 22)
        Me.SaveNodeToolStripMenuItem.Text = "&Save Node"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(229, 6)
        '
        'SaveStatisticsToolStripMenuItem
        '
        Me.SaveStatisticsToolStripMenuItem.Image = CType(resources.GetObject("SaveStatisticsToolStripMenuItem.Image"), System.Drawing.Image)
        Me.SaveStatisticsToolStripMenuItem.Name = "SaveStatisticsToolStripMenuItem"
        Me.SaveStatisticsToolStripMenuItem.Size = New System.Drawing.Size(232, 22)
        Me.SaveStatisticsToolStripMenuItem.Text = "&Save statistics"
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Image = CType(resources.GetObject("ExitToolStripMenuItem.Image"), System.Drawing.Image)
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.F4), System.Windows.Forms.Keys)
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(232, 22)
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
        Me.openSourceDb.Filter = "Sources Database *.rdman|*.rdman|CSV file (sep. by semicolon) *.csv|*.csv"
        Me.openSourceDb.Title = "Open Sources Database file"
        '
        'saveStatistics
        '
        Me.saveStatistics.DefaultExt = "txt"
        Me.saveStatistics.FileName = "statistics.txt"
        Me.saveStatistics.Filter = "Text files *.txt|*.txt"
        Me.saveStatistics.Title = "Save Statistics file"
        '
        'mainForm
        '
        Me.AcceptButton = Me.buttonConnect
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(792, 511)
        Me.Controls.Add(Me.groupImage)
        Me.Controls.Add(Me.mainContainer)
        Me.Controls.Add(Me.menuBar)
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
        Me.groupStatistics.PerformLayout()
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
    Friend WithEvents statisticsCommandLine As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents boxFullscreen As System.Windows.Forms.CheckBox

End Class
