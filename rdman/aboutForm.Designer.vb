<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class aboutForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(aboutForm))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblLicense = New System.Windows.Forms.LinkLabel()
        Me.lblProducer = New System.Windows.Forms.LinkLabel()
        Me.lblGitHub = New System.Windows.Forms.LinkLabel()
        Me.sourcesTextBox = New System.Windows.Forms.RichTextBox()
        Me.clickKRtkovo = New System.Windows.Forms.Panel()
        Me.clickClose = New System.Windows.Forms.Panel()
        Me.clickRDMan = New System.Windows.Forms.Panel()
        Me.clickEasterEgg = New System.Windows.Forms.Panel()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.White
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label1.Location = New System.Drawing.Point(156, 56)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(53, 20)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Label1"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.White
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(157, 122)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(92, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Published under"
        '
        'lblLicense
        '
        Me.lblLicense.AutoSize = True
        Me.lblLicense.BackColor = System.Drawing.Color.White
        Me.lblLicense.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLicense.LinkColor = System.Drawing.Color.DeepSkyBlue
        Me.lblLicense.Location = New System.Drawing.Point(249, 122)
        Me.lblLicense.Name = "lblLicense"
        Me.lblLicense.Size = New System.Drawing.Size(61, 13)
        Me.lblLicense.TabIndex = 3
        Me.lblLicense.TabStop = True
        Me.lblLicense.Text = "LinkLabel1"
        Me.lblLicense.VisitedLinkColor = System.Drawing.Color.DeepSkyBlue
        '
        'lblProducer
        '
        Me.lblProducer.AutoSize = True
        Me.lblProducer.BackColor = System.Drawing.Color.White
        Me.lblProducer.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProducer.LinkColor = System.Drawing.Color.LimeGreen
        Me.lblProducer.Location = New System.Drawing.Point(157, 82)
        Me.lblProducer.Name = "lblProducer"
        Me.lblProducer.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblProducer.Size = New System.Drawing.Size(65, 13)
        Me.lblProducer.TabIndex = 4
        Me.lblProducer.TabStop = True
        Me.lblProducer.Text = "KRtkovo.eu"
        Me.lblProducer.VisitedLinkColor = System.Drawing.Color.LimeGreen
        '
        'lblGitHub
        '
        Me.lblGitHub.AutoSize = True
        Me.lblGitHub.BackColor = System.Drawing.Color.White
        Me.lblGitHub.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGitHub.LinkColor = System.Drawing.Color.DarkOrange
        Me.lblGitHub.Location = New System.Drawing.Point(157, 102)
        Me.lblGitHub.Name = "lblGitHub"
        Me.lblGitHub.Size = New System.Drawing.Size(96, 13)
        Me.lblGitHub.TabIndex = 5
        Me.lblGitHub.TabStop = True
        Me.lblGitHub.Text = "Check for update"
        Me.lblGitHub.VisitedLinkColor = System.Drawing.Color.DarkOrange
        '
        'sourcesTextBox
        '
        Me.sourcesTextBox.BackColor = System.Drawing.Color.White
        Me.sourcesTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.sourcesTextBox.Font = New System.Drawing.Font("Segoe UI", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.sourcesTextBox.ForeColor = System.Drawing.Color.Gray
        Me.sourcesTextBox.Location = New System.Drawing.Point(135, 151)
        Me.sourcesTextBox.Name = "sourcesTextBox"
        Me.sourcesTextBox.ReadOnly = True
        Me.sourcesTextBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical
        Me.sourcesTextBox.Size = New System.Drawing.Size(285, 87)
        Me.sourcesTextBox.TabIndex = 6
        Me.sourcesTextBox.Text = "Text"
        '
        'clickKRtkovo
        '
        Me.clickKRtkovo.BackColor = System.Drawing.Color.Transparent
        Me.clickKRtkovo.Cursor = System.Windows.Forms.Cursors.Hand
        Me.clickKRtkovo.Location = New System.Drawing.Point(57, 159)
        Me.clickKRtkovo.Name = "clickKRtkovo"
        Me.clickKRtkovo.Size = New System.Drawing.Size(65, 65)
        Me.clickKRtkovo.TabIndex = 7
        Me.ToolTip1.SetToolTip(Me.clickKRtkovo, "Visit KRtkovo.eu")
        '
        'clickClose
        '
        Me.clickClose.BackColor = System.Drawing.Color.Transparent
        Me.clickClose.Cursor = System.Windows.Forms.Cursors.Hand
        Me.clickClose.Location = New System.Drawing.Point(429, 228)
        Me.clickClose.Name = "clickClose"
        Me.clickClose.Size = New System.Drawing.Size(25, 25)
        Me.clickClose.TabIndex = 8
        Me.ToolTip1.SetToolTip(Me.clickClose, "Close")
        '
        'clickRDMan
        '
        Me.clickRDMan.BackColor = System.Drawing.Color.Transparent
        Me.clickRDMan.Cursor = System.Windows.Forms.Cursors.Hand
        Me.clickRDMan.Location = New System.Drawing.Point(10, 10)
        Me.clickRDMan.Name = "clickRDMan"
        Me.clickRDMan.Size = New System.Drawing.Size(130, 130)
        Me.clickRDMan.TabIndex = 9
        Me.ToolTip1.SetToolTip(Me.clickRDMan, "Visit our GitHub!")
        '
        'clickEasterEgg
        '
        Me.clickEasterEgg.BackColor = System.Drawing.Color.Transparent
        Me.clickEasterEgg.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.clickEasterEgg.Location = New System.Drawing.Point(85, 240)
        Me.clickEasterEgg.Name = "clickEasterEgg"
        Me.clickEasterEgg.Size = New System.Drawing.Size(10, 11)
        Me.clickEasterEgg.TabIndex = 10
        Me.ToolTip1.SetToolTip(Me.clickEasterEgg, "You just lost the Game! ;-)")
        '
        'aboutForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.ClientSize = New System.Drawing.Size(460, 266)
        Me.Controls.Add(Me.clickEasterEgg)
        Me.Controls.Add(Me.clickRDMan)
        Me.Controls.Add(Me.clickClose)
        Me.Controls.Add(Me.clickKRtkovo)
        Me.Controls.Add(Me.sourcesTextBox)
        Me.Controls.Add(Me.lblGitHub)
        Me.Controls.Add(Me.lblProducer)
        Me.Controls.Add(Me.lblLicense)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "aboutForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "About Remote Desktop Manager"
        Me.TransparencyKey = System.Drawing.SystemColors.Control
        Me.ResumeLayout(False)
        Me.PerformLayout

End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblLicense As System.Windows.Forms.LinkLabel
    Friend WithEvents lblProducer As System.Windows.Forms.LinkLabel
    Friend WithEvents lblGitHub As System.Windows.Forms.LinkLabel
    Friend WithEvents sourcesTextBox As System.Windows.Forms.RichTextBox
    Friend WithEvents clickKRtkovo As System.Windows.Forms.Panel
    Friend WithEvents clickClose As System.Windows.Forms.Panel
    Friend WithEvents clickRDMan As System.Windows.Forms.Panel
    Friend WithEvents clickEasterEgg As System.Windows.Forms.Panel
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
End Class
