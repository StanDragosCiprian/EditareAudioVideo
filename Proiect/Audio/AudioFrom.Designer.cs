namespace Proiect
{
    partial class AudioFrom
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.audioLoad = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.loadAudioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.audioEdit = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.audioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.playToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.convertWavToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.convertMp3ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.monoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sterioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.concatingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pitchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pauseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.audioLoad.SuspendLayout();
            this.audioEdit.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1582, 99);
            this.panel2.TabIndex = 48;
            // 
            // audioLoad
            // 
            this.audioLoad.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.audioLoad.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadAudioToolStripMenuItem});
            this.audioLoad.Name = "audioLoad";
            this.audioLoad.Size = new System.Drawing.Size(156, 28);
            // 
            // loadAudioToolStripMenuItem
            // 
            this.loadAudioToolStripMenuItem.Name = "loadAudioToolStripMenuItem";
            this.loadAudioToolStripMenuItem.Size = new System.Drawing.Size(155, 24);
            this.loadAudioToolStripMenuItem.Text = "Load Audio";
            this.loadAudioToolStripMenuItem.Click += new System.EventHandler(this.loadAudioToolStripMenuItem_Click);
            // 
            // audioEdit
            // 
            this.audioEdit.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.audioEdit.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.audioToolStripMenuItem});
            this.audioEdit.Name = "audioEdit";
            this.audioEdit.Size = new System.Drawing.Size(119, 28);
            // 
            // audioToolStripMenuItem
            // 
            this.audioToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.playToolStripMenuItem,
            this.pauseToolStripMenuItem,
            this.convertWavToolStripMenuItem,
            this.convertMp3ToolStripMenuItem,
            this.monoToolStripMenuItem,
            this.sterioToolStripMenuItem,
            this.concatingToolStripMenuItem,
            this.pitchToolStripMenuItem});
            this.audioToolStripMenuItem.Name = "audioToolStripMenuItem";
            this.audioToolStripMenuItem.Size = new System.Drawing.Size(210, 24);
            this.audioToolStripMenuItem.Text = "Audio";
            // 
            // playToolStripMenuItem
            // 
            this.playToolStripMenuItem.Name = "playToolStripMenuItem";
            this.playToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.playToolStripMenuItem.Text = "Play";
            this.playToolStripMenuItem.Click += new System.EventHandler(this.playToolStripMenuItem_Click);
            // 
            // convertWavToolStripMenuItem
            // 
            this.convertWavToolStripMenuItem.Name = "convertWavToolStripMenuItem";
            this.convertWavToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.convertWavToolStripMenuItem.Text = "Convert Wav";
            this.convertWavToolStripMenuItem.Click += new System.EventHandler(this.convertWavToolStripMenuItem_Click);
            // 
            // convertMp3ToolStripMenuItem
            // 
            this.convertMp3ToolStripMenuItem.Name = "convertMp3ToolStripMenuItem";
            this.convertMp3ToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.convertMp3ToolStripMenuItem.Text = "Convert Mp3";
            this.convertMp3ToolStripMenuItem.Click += new System.EventHandler(this.convertMp3ToolStripMenuItem_Click);
            // 
            // monoToolStripMenuItem
            // 
            this.monoToolStripMenuItem.Name = "monoToolStripMenuItem";
            this.monoToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.monoToolStripMenuItem.Text = "Mono";
            this.monoToolStripMenuItem.Click += new System.EventHandler(this.monoToolStripMenuItem_Click);
            // 
            // sterioToolStripMenuItem
            // 
            this.sterioToolStripMenuItem.Name = "sterioToolStripMenuItem";
            this.sterioToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.sterioToolStripMenuItem.Text = "Sterio";
            this.sterioToolStripMenuItem.Click += new System.EventHandler(this.sterioToolStripMenuItem_Click);
            // 
            // concatingToolStripMenuItem
            // 
            this.concatingToolStripMenuItem.Name = "concatingToolStripMenuItem";
            this.concatingToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.concatingToolStripMenuItem.Text = "Concating";
            this.concatingToolStripMenuItem.Click += new System.EventHandler(this.concatingToolStripMenuItem_Click);
            // 
            // pitchToolStripMenuItem
            // 
            this.pitchToolStripMenuItem.Name = "pitchToolStripMenuItem";
            this.pitchToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.pitchToolStripMenuItem.Text = "Pitch";
            this.pitchToolStripMenuItem.Click += new System.EventHandler(this.pitchToolStripMenuItem_Click);
            // 
            // pauseToolStripMenuItem
            // 
            this.pauseToolStripMenuItem.Name = "pauseToolStripMenuItem";
            this.pauseToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.pauseToolStripMenuItem.Text = "Pause";
            this.pauseToolStripMenuItem.Click += new System.EventHandler(this.pauseToolStripMenuItem_Click);
            // 
            // AudioFrom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1582, 853);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AudioFrom";
            this.Text = "AudioFrom";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.AudioFrom_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.AudioFrom_MouseDown);
            this.audioLoad.ResumeLayout(false);
            this.audioEdit.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ContextMenuStrip audioLoad;
        private System.Windows.Forms.ToolStripMenuItem loadAudioToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip audioEdit;
        private System.Windows.Forms.ToolStripMenuItem audioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem playToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem convertWavToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem convertMp3ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem monoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sterioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem concatingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pitchToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pauseToolStripMenuItem;
    }
}