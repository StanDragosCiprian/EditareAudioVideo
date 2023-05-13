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
            this.panel2 = new System.Windows.Forms.Panel();
            this.loadAudio = new System.Windows.Forms.Button();
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
            // loadAudio
            // 
            this.loadAudio.Location = new System.Drawing.Point(1331, 126);
            this.loadAudio.Name = "loadAudio";
            this.loadAudio.Size = new System.Drawing.Size(153, 23);
            this.loadAudio.TabIndex = 49;
            this.loadAudio.Text = "Load Audio ";
            this.loadAudio.UseVisualStyleBackColor = true;
            this.loadAudio.Click += new System.EventHandler(this.loadAudio_Click);
            // 
            // AudioFrom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1582, 853);
            this.Controls.Add(this.loadAudio);
            this.Controls.Add(this.panel2);
            this.Name = "AudioFrom";
            this.Text = "AudioFrom";
            this.Load += new System.EventHandler(this.AudioFrom_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button loadAudio;
    }
}