namespace AppBarHelper
{
    partial class CompactWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CompactWindow));
            this.MainButtonIcons = new System.Windows.Forms.ImageList(this.components);
            this.RdmanIconsList = new System.Windows.Forms.ImageList(this.components);
            this.separator0 = new System.Windows.Forms.Panel();
            this.InfoToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.BtnAddConnection = new NoFocusCueButton();
            this.BtnMonitorPID = new NoFocusCueButton();
            this.PanelSources = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.PanelMonitored = new System.Windows.Forms.Panel();
            this.monitorStates = new System.Windows.Forms.ImageList(this.components);
            this.PanelSources.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainButtonIcons
            // 
            this.MainButtonIcons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("MainButtonIcons.ImageStream")));
            this.MainButtonIcons.TransparentColor = System.Drawing.Color.Transparent;
            this.MainButtonIcons.Images.SetKeyName(0, "04.png");
            this.MainButtonIcons.Images.SetKeyName(1, "04-Active.png");
            this.MainButtonIcons.Images.SetKeyName(2, "Gear.png");
            this.MainButtonIcons.Images.SetKeyName(3, "Gear-Active.png");
            // 
            // RdmanIconsList
            // 
            this.RdmanIconsList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("RdmanIconsList.ImageStream")));
            this.RdmanIconsList.TransparentColor = System.Drawing.Color.Transparent;
            this.RdmanIconsList.Images.SetKeyName(0, "00.png");
            this.RdmanIconsList.Images.SetKeyName(1, "01.png");
            this.RdmanIconsList.Images.SetKeyName(2, "02.png");
            this.RdmanIconsList.Images.SetKeyName(3, "04.png");
            this.RdmanIconsList.Images.SetKeyName(4, "04.png");
            this.RdmanIconsList.Images.SetKeyName(5, "04.png");
            this.RdmanIconsList.Images.SetKeyName(6, "06.png");
            this.RdmanIconsList.Images.SetKeyName(7, "00-Active.png");
            this.RdmanIconsList.Images.SetKeyName(8, "01-Active.png");
            this.RdmanIconsList.Images.SetKeyName(9, "02-Active.png");
            this.RdmanIconsList.Images.SetKeyName(10, "04-osActive.png");
            this.RdmanIconsList.Images.SetKeyName(11, "04-osActive.png");
            this.RdmanIconsList.Images.SetKeyName(12, "04-osActive.png");
            this.RdmanIconsList.Images.SetKeyName(13, "06-Active.png");
            // 
            // separator0
            // 
            this.separator0.BackColor = System.Drawing.Color.Black;
            this.separator0.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.separator0.Location = new System.Drawing.Point(0, 567);
            this.separator0.Name = "separator0";
            this.separator0.Size = new System.Drawing.Size(180, 1);
            this.separator0.TabIndex = 2;
            // 
            // InfoToolTip
            // 
            this.InfoToolTip.IsBalloon = true;
            // 
            // BtnAddConnection
            // 
            this.BtnAddConnection.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BtnAddConnection.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BtnAddConnection.FlatAppearance.BorderSize = 0;
            this.BtnAddConnection.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnAddConnection.ForeColor = System.Drawing.Color.White;
            this.BtnAddConnection.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnAddConnection.ImageIndex = 0;
            this.BtnAddConnection.ImageList = this.MainButtonIcons;
            this.BtnAddConnection.Location = new System.Drawing.Point(0, 568);
            this.BtnAddConnection.Margin = new System.Windows.Forms.Padding(0);
            this.BtnAddConnection.Name = "BtnAddConnection";
            this.BtnAddConnection.Size = new System.Drawing.Size(180, 32);
            this.BtnAddConnection.TabIndex = 1;
            this.BtnAddConnection.Text = "          Remote Desktop Manager";
            this.InfoToolTip.SetToolTip(this.BtnAddConnection, "Set Remote Desktop Manager to foreground, even when minimized.");
            this.BtnAddConnection.UseVisualStyleBackColor = true;
            this.BtnAddConnection.Click += new System.EventHandler(this.BtnAddConnection_Click);
            this.BtnAddConnection.MouseEnter += new System.EventHandler(this.BtnAddConnection_MouseEnter);
            this.BtnAddConnection.MouseLeave += new System.EventHandler(this.BtnAddConnection_MouseLeave);
            // 
            // BtnMonitorPID
            // 
            this.BtnMonitorPID.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BtnMonitorPID.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BtnMonitorPID.FlatAppearance.BorderSize = 0;
            this.BtnMonitorPID.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnMonitorPID.ForeColor = System.Drawing.Color.White;
            this.BtnMonitorPID.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnMonitorPID.ImageIndex = 2;
            this.BtnMonitorPID.ImageList = this.MainButtonIcons;
            this.BtnMonitorPID.Location = new System.Drawing.Point(0, 535);
            this.BtnMonitorPID.Margin = new System.Windows.Forms.Padding(0);
            this.BtnMonitorPID.Name = "BtnMonitorPID";
            this.BtnMonitorPID.Size = new System.Drawing.Size(180, 32);
            this.BtnMonitorPID.TabIndex = 4;
            this.BtnMonitorPID.Text = "          Monitor PID";
            this.InfoToolTip.SetToolTip(this.BtnMonitorPID, "Monitor application by its PID");
            this.BtnMonitorPID.UseVisualStyleBackColor = true;
            this.BtnMonitorPID.Click += new System.EventHandler(this.BtnMonitorPID_Click);
            this.BtnMonitorPID.MouseEnter += new System.EventHandler(this.BtnMonitorPID_MouseEnter);
            this.BtnMonitorPID.MouseLeave += new System.EventHandler(this.BtnMonitorPID_MouseLeave);
            // 
            // PanelSources
            // 
            this.PanelSources.AutoSize = true;
            this.PanelSources.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.PanelSources.Controls.Add(this.label1);
            this.PanelSources.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.PanelSources.Location = new System.Drawing.Point(0, 519);
            this.PanelSources.Name = "PanelSources";
            this.PanelSources.Size = new System.Drawing.Size(180, 16);
            this.PanelSources.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.ForeColor = System.Drawing.Color.DimGray;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(180, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Source list";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // PanelMonitored
            // 
            this.PanelMonitored.AutoSize = true;
            this.PanelMonitored.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.PanelMonitored.Dock = System.Windows.Forms.DockStyle.Top;
            this.PanelMonitored.Location = new System.Drawing.Point(0, 0);
            this.PanelMonitored.Name = "PanelMonitored";
            this.PanelMonitored.Size = new System.Drawing.Size(180, 0);
            this.PanelMonitored.TabIndex = 3;
            // 
            // monitorStates
            // 
            this.monitorStates.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("monitorStates.ImageStream")));
            this.monitorStates.TransparentColor = System.Drawing.Color.Transparent;
            this.monitorStates.Images.SetKeyName(0, "conn00.png");
            this.monitorStates.Images.SetKeyName(1, "conn01.png");
            this.monitorStates.Images.SetKeyName(2, "conn02.png");
            this.monitorStates.Images.SetKeyName(3, "conn03.png");
            this.monitorStates.Images.SetKeyName(4, "conn04.png");
            this.monitorStates.Images.SetKeyName(5, "conn00act.png");
            this.monitorStates.Images.SetKeyName(6, "conn01act.png");
            this.monitorStates.Images.SetKeyName(7, "conn02act.png");
            this.monitorStates.Images.SetKeyName(8, "conn03act.png");
            this.monitorStates.Images.SetKeyName(9, "conn04act.png");
            // 
            // CompactWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.ClientSize = new System.Drawing.Size(180, 600);
            this.Controls.Add(this.PanelMonitored);
            this.Controls.Add(this.PanelSources);
            this.Controls.Add(this.BtnMonitorPID);
            this.Controls.Add(this.separator0);
            this.Controls.Add(this.BtnAddConnection);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CompactWindow";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Remote Desktop Manager";
            this.TopMost = true;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.CompactWindow_FormClosed);
            this.Shown += new System.EventHandler(this.CompactWindow_Shown);
            this.LocationChanged += new System.EventHandler(this.CompactWindow_LocationChanged);
            this.PanelSources.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private NoFocusCueButton BtnAddConnection;
        private System.Windows.Forms.Panel separator0;
        private System.Windows.Forms.ImageList RdmanIconsList;
        private System.Windows.Forms.ImageList MainButtonIcons;
        private System.Windows.Forms.Panel PanelSources;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.ToolTip InfoToolTip;
        private System.Windows.Forms.Panel PanelMonitored;
        internal System.Windows.Forms.ImageList monitorStates;
        private NoFocusCueButton BtnMonitorPID;
    }
}