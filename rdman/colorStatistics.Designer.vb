<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class colorStatistics
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
        Me.OK_Button = New System.Windows.Forms.Button()
        Me.ColorDialog1 = New System.Windows.Forms.ColorDialog()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnTextColor = New System.Windows.Forms.Button()
        Me.btnBgColor = New System.Windows.Forms.Button()
        Me.fontSize = New System.Windows.Forms.NumericUpDown()
        Me.Label3 = New System.Windows.Forms.Label()
        CType(Me.fontSize, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'OK_Button
        '
        Me.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.OK_Button.Location = New System.Drawing.Point(62, 81)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(67, 23)
        Me.OK_Button.TabIndex = 0
        Me.OK_Button.Text = "OK"
        '
        'ColorDialog1
        '
        Me.ColorDialog1.AnyColor = True
        Me.ColorDialog1.FullOpen = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(66, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Color of text:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 33)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(106, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Color of background:"
        '
        'btnTextColor
        '
        Me.btnTextColor.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnTextColor.Location = New System.Drawing.Point(124, 6)
        Me.btnTextColor.Name = "btnTextColor"
        Me.btnTextColor.Size = New System.Drawing.Size(46, 18)
        Me.btnTextColor.TabIndex = 4
        Me.btnTextColor.UseVisualStyleBackColor = True
        '
        'btnBgColor
        '
        Me.btnBgColor.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnBgColor.Location = New System.Drawing.Point(124, 30)
        Me.btnBgColor.Name = "btnBgColor"
        Me.btnBgColor.Size = New System.Drawing.Size(46, 18)
        Me.btnBgColor.TabIndex = 5
        Me.btnBgColor.UseVisualStyleBackColor = True
        '
        'fontSize
        '
        Me.fontSize.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.fontSize.Location = New System.Drawing.Point(124, 55)
        Me.fontSize.Maximum = New Decimal(New Integer() {40, 0, 0, 0})
        Me.fontSize.Minimum = New Decimal(New Integer() {7, 0, 0, 0})
        Me.fontSize.Name = "fontSize"
        Me.fontSize.Size = New System.Drawing.Size(46, 20)
        Me.fontSize.TabIndex = 6
        Me.fontSize.Value = New Decimal(New Integer() {7, 0, 0, 0})
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 57)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(89, 13)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Font size (points):"
        '
        'colorStatistics
        '
        Me.AcceptButton = Me.OK_Button
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(189, 116)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.fontSize)
        Me.Controls.Add(Me.OK_Button)
        Me.Controls.Add(Me.btnBgColor)
        Me.Controls.Add(Me.btnTextColor)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "colorStatistics"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Statistics console style"
        CType(Me.fontSize, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents ColorDialog1 As System.Windows.Forms.ColorDialog
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnTextColor As System.Windows.Forms.Button
    Friend WithEvents btnBgColor As System.Windows.Forms.Button
    Friend WithEvents fontSize As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label3 As System.Windows.Forms.Label

End Class
