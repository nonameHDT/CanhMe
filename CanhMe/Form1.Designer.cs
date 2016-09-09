namespace CanhMe
{
    partial class Form1
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
			this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
			this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.mnuStart = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuStop = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuRestart = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuExit = new System.Windows.Forms.ToolStripMenuItem();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.contextMenuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// notifyIcon1
			// 
			this.notifyIcon1.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
			this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
			this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
			this.notifyIcon1.Text = "CanhMe";
			this.notifyIcon1.Visible = true;
			// 
			// contextMenuStrip1
			// 
			this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuStart,
            this.mnuStop,
            this.mnuRestart,
            this.mnuExit});
			this.contextMenuStrip1.Name = "contextMenuStrip1";
			this.contextMenuStrip1.Size = new System.Drawing.Size(111, 92);
			// 
			// mnuStart
			// 
			this.mnuStart.Name = "mnuStart";
			this.mnuStart.Size = new System.Drawing.Size(110, 22);
			this.mnuStart.Text = "Start";
			this.mnuStart.Click += new System.EventHandler(this.mnuStart_Click);
			// 
			// mnuStop
			// 
			this.mnuStop.Name = "mnuStop";
			this.mnuStop.Size = new System.Drawing.Size(110, 22);
			this.mnuStop.Text = "Stop";
			this.mnuStop.Click += new System.EventHandler(this.mnuStop_Click);
			// 
			// mnuRestart
			// 
			this.mnuRestart.Name = "mnuRestart";
			this.mnuRestart.Size = new System.Drawing.Size(110, 22);
			this.mnuRestart.Text = "Restart";
			this.mnuRestart.Click += new System.EventHandler(this.mnuRestart_Click);
			// 
			// mnuExit
			// 
			this.mnuExit.Name = "mnuExit";
			this.mnuExit.Size = new System.Drawing.Size(110, 22);
			this.mnuExit.Text = "Exit";
			this.mnuExit.Click += new System.EventHandler(this.mnuExit_Click);
			// 
			// timer1
			// 
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(573, 308);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "Form1";
			this.ShowInTaskbar = false;
			this.Text = "Form1";
			this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
			this.Load += new System.EventHandler(this.Form1_Load);
			this.contextMenuStrip1.ResumeLayout(false);
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnuStart;
        private System.Windows.Forms.ToolStripMenuItem mnuStop;
        private System.Windows.Forms.ToolStripMenuItem mnuRestart;
		private System.Windows.Forms.Timer timer1;
		private System.Windows.Forms.ToolStripMenuItem mnuExit;
	}
}

