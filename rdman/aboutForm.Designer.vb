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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(aboutForm))
        Me.closeButton = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblLicense = New System.Windows.Forms.LinkLabel()
        Me.lblProducer = New System.Windows.Forms.LinkLabel()
        Me.lblGitHub = New System.Windows.Forms.LinkLabel()
        Me.sourcesTextBox = New System.Windows.Forms.RichTextBox()
        Me.SuspendLayout()
        '
        'closeButton
        '
        Me.closeButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.closeButton.BackColor = System.Drawing.Color.White
        Me.closeButton.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.closeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.closeButton.ForeColor = System.Drawing.SystemColors.ControlText
        Me.closeButton.Location = New System.Drawing.Point(383, 36)
        Me.closeButton.Name = "closeButton"
        Me.closeButton.Size = New System.Drawing.Size(23, 23)
        Me.closeButton.TabIndex = 0
        Me.closeButton.Text = "X"
        Me.closeButton.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.White
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label1.Location = New System.Drawing.Point(147, 68)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(57, 18)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Label1"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(147, 97)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(83, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Published under"
        '
        'lblLicense
        '
        Me.lblLicense.AutoSize = True
        Me.lblLicense.BackColor = System.Drawing.Color.White
        Me.lblLicense.LinkColor = System.Drawing.Color.DeepSkyBlue
        Me.lblLicense.Location = New System.Drawing.Point(229, 97)
        Me.lblLicense.Name = "lblLicense"
        Me.lblLicense.Size = New System.Drawing.Size(59, 13)
        Me.lblLicense.TabIndex = 3
        Me.lblLicense.TabStop = True
        Me.lblLicense.Text = "LinkLabel1"
        Me.lblLicense.VisitedLinkColor = System.Drawing.Color.DeepSkyBlue
        '
        'lblProducer
        '
        Me.lblProducer.AutoSize = True
        Me.lblProducer.BackColor = System.Drawing.Color.White
        Me.lblProducer.LinkColor = System.Drawing.Color.LimeGreen
        Me.lblProducer.Location = New System.Drawing.Point(283, 120)
        Me.lblProducer.Name = "lblProducer"
        Me.lblProducer.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblProducer.Size = New System.Drawing.Size(59, 13)
        Me.lblProducer.TabIndex = 4
        Me.lblProducer.TabStop = True
        Me.lblProducer.Text = "LinkLabel2"
        Me.lblProducer.VisitedLinkColor = System.Drawing.Color.LimeGreen
        '
        'lblGitHub
        '
        Me.lblGitHub.AutoSize = True
        Me.lblGitHub.BackColor = System.Drawing.Color.White
        Me.lblGitHub.LinkColor = System.Drawing.Color.DarkOrange
        Me.lblGitHub.Location = New System.Drawing.Point(147, 120)
        Me.lblGitHub.Name = "lblGitHub"
        Me.lblGitHub.Size = New System.Drawing.Size(102, 13)
        Me.lblGitHub.TabIndex = 5
        Me.lblGitHub.TabStop = True
        Me.lblGitHub.Text = "GitHub project page"
        Me.lblGitHub.VisitedLinkColor = System.Drawing.Color.DarkOrange
        '
        'sourcesTextBox
        '
        Me.sourcesTextBox.BackColor = System.Drawing.Color.White
        Me.sourcesTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.sourcesTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.4!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.sourcesTextBox.ForeColor = System.Drawing.Color.Gray
        Me.sourcesTextBox.Location = New System.Drawing.Point(46, 147)
        Me.sourcesTextBox.Name = "sourcesTextBox"
        Me.sourcesTextBox.ReadOnly = True
        Me.sourcesTextBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical
        Me.sourcesTextBox.Size = New System.Drawing.Size(360, 80)
        Me.sourcesTextBox.TabIndex = 6
        Me.sourcesTextBox.Text = ""
        '
        'aboutForm
        '
        Me.AcceptButton = Me.closeButton
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LavenderBlush
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ClientSize = New System.Drawing.Size(428, 246)
        Me.Controls.Add(Me.sourcesTextBox)
        Me.Controls.Add(Me.lblGitHub)
        Me.Controls.Add(Me.lblProducer)
        Me.Controls.Add(Me.lblLicense)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.closeButton)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "aboutForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "About Remote Desktop Manager"
        Me.TransparencyKey = System.Drawing.Color.LavenderBlush
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents closeButton As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblLicense As System.Windows.Forms.LinkLabel
    Friend WithEvents lblProducer As System.Windows.Forms.LinkLabel
    Friend WithEvents lblGitHub As System.Windows.Forms.LinkLabel
    Friend WithEvents sourcesTextBox As System.Windows.Forms.RichTextBox
End Class
