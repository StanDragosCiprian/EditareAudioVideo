namespace Proiect
{
    partial class VideoForm
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
            this.videoEdit = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.videoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.writeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.combineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.playToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.effectsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ROI = new System.Windows.Forms.ToolStripMenuItem();
            this.greyScaleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.caruselToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.colorHistogramToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contentLoad = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.loadVideoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadCameraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.GamaValue = new System.Windows.Forms.Label();
            this.gama = new System.Windows.Forms.TextBox();
            this.Alfa = new System.Windows.Forms.TextBox();
            this.Beta = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.redToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.greenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.blueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.videoEdit.SuspendLayout();
            this.contentLoad.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1924, 99);
            this.panel2.TabIndex = 47;
            // 
            // videoEdit
            // 
            this.videoEdit.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.videoEdit.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.videoToolStripMenuItem,
            this.effectsToolStripMenuItem});
            this.videoEdit.Name = "contextMenuStrip1";
            this.videoEdit.Size = new System.Drawing.Size(211, 80);
            this.videoEdit.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.videoEdit_ItemClicked);
            // 
            // videoToolStripMenuItem
            // 
            this.videoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.writeToolStripMenuItem,
            this.combineToolStripMenuItem,
            this.playToolStripMenuItem,
            this.stopToolStripMenuItem});
            this.videoToolStripMenuItem.Name = "videoToolStripMenuItem";
            this.videoToolStripMenuItem.Size = new System.Drawing.Size(210, 24);
            this.videoToolStripMenuItem.Text = "Video";
            // 
            // writeToolStripMenuItem
            // 
            this.writeToolStripMenuItem.Name = "writeToolStripMenuItem";
            this.writeToolStripMenuItem.Size = new System.Drawing.Size(152, 26);
            this.writeToolStripMenuItem.Text = "Write";
            // 
            // combineToolStripMenuItem
            // 
            this.combineToolStripMenuItem.Name = "combineToolStripMenuItem";
            this.combineToolStripMenuItem.Size = new System.Drawing.Size(152, 26);
            this.combineToolStripMenuItem.Text = "Combine";
            this.combineToolStripMenuItem.Click += new System.EventHandler(this.combineToolStripMenuItem_Click);
            // 
            // playToolStripMenuItem
            // 
            this.playToolStripMenuItem.Name = "playToolStripMenuItem";
            this.playToolStripMenuItem.Size = new System.Drawing.Size(152, 26);
            this.playToolStripMenuItem.Text = "Play";
            this.playToolStripMenuItem.Click += new System.EventHandler(this.playToolStripMenuItem_Click);
            // 
            // stopToolStripMenuItem
            // 
            this.stopToolStripMenuItem.Name = "stopToolStripMenuItem";
            this.stopToolStripMenuItem.Size = new System.Drawing.Size(152, 26);
            this.stopToolStripMenuItem.Text = "Stop";
            this.stopToolStripMenuItem.Click += new System.EventHandler(this.stopToolStripMenuItem_Click);
            // 
            // effectsToolStripMenuItem
            // 
            this.effectsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ROI,
            this.greyScaleToolStripMenuItem,
            this.caruselToolStripMenuItem,
            this.bToolStripMenuItem,
            this.colorHistogramToolStripMenuItem});
            this.effectsToolStripMenuItem.Name = "effectsToolStripMenuItem";
            this.effectsToolStripMenuItem.Size = new System.Drawing.Size(210, 24);
            this.effectsToolStripMenuItem.Text = "Effects";
            // 
            // ROI
            // 
            this.ROI.Name = "ROI";
            this.ROI.Size = new System.Drawing.Size(225, 26);
            this.ROI.Text = "ROI";
            this.ROI.Click += new System.EventHandler(this.ROI_Click);
            // 
            // greyScaleToolStripMenuItem
            // 
            this.greyScaleToolStripMenuItem.Name = "greyScaleToolStripMenuItem";
            this.greyScaleToolStripMenuItem.Size = new System.Drawing.Size(225, 26);
            this.greyScaleToolStripMenuItem.Text = "GreyScale";
            this.greyScaleToolStripMenuItem.Click += new System.EventHandler(this.greyScaleToolStripMenuItem_Click);
            // 
            // caruselToolStripMenuItem
            // 
            this.caruselToolStripMenuItem.Name = "caruselToolStripMenuItem";
            this.caruselToolStripMenuItem.Size = new System.Drawing.Size(225, 26);
            this.caruselToolStripMenuItem.Text = "Carusel";
            this.caruselToolStripMenuItem.Click += new System.EventHandler(this.caruselToolStripMenuItem_Click);
            // 
            // bToolStripMenuItem
            // 
            this.bToolStripMenuItem.Name = "bToolStripMenuItem";
            this.bToolStripMenuItem.Size = new System.Drawing.Size(225, 26);
            this.bToolStripMenuItem.Text = "Brightness / gamma";
            this.bToolStripMenuItem.Click += new System.EventHandler(this.bToolStripMenuItem_Click);
            // 
            // colorHistogramToolStripMenuItem
            // 
            this.colorHistogramToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.redToolStripMenuItem,
            this.greenToolStripMenuItem,
            this.blueToolStripMenuItem});
            this.colorHistogramToolStripMenuItem.Name = "colorHistogramToolStripMenuItem";
            this.colorHistogramToolStripMenuItem.Size = new System.Drawing.Size(225, 26);
            this.colorHistogramToolStripMenuItem.Text = "Color histogram";
            // 
            // contentLoad
            // 
            this.contentLoad.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contentLoad.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadVideoToolStripMenuItem,
            this.loadImageToolStripMenuItem,
            this.loadCameraToolStripMenuItem});
            this.contentLoad.Name = "contextMenuStrip2";
            this.contentLoad.Size = new System.Drawing.Size(167, 76);
            this.contentLoad.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.contentLoad_ItemClicked);
            // 
            // loadVideoToolStripMenuItem
            // 
            this.loadVideoToolStripMenuItem.Name = "loadVideoToolStripMenuItem";
            this.loadVideoToolStripMenuItem.Size = new System.Drawing.Size(166, 24);
            this.loadVideoToolStripMenuItem.Text = "Load Video";
            // 
            // loadImageToolStripMenuItem
            // 
            this.loadImageToolStripMenuItem.Name = "loadImageToolStripMenuItem";
            this.loadImageToolStripMenuItem.Size = new System.Drawing.Size(166, 24);
            this.loadImageToolStripMenuItem.Text = "Load Image";
            // 
            // loadCameraToolStripMenuItem
            // 
            this.loadCameraToolStripMenuItem.Name = "loadCameraToolStripMenuItem";
            this.loadCameraToolStripMenuItem.Size = new System.Drawing.Size(166, 24);
            this.loadCameraToolStripMenuItem.Text = "Load Camera";
            // 
            // GamaValue
            // 
            this.GamaValue.AutoSize = true;
            this.GamaValue.Location = new System.Drawing.Point(1842, 228);
            this.GamaValue.Name = "GamaValue";
            this.GamaValue.Size = new System.Drawing.Size(44, 16);
            this.GamaValue.TabIndex = 55;
            this.GamaValue.Text = "Gama";
            this.GamaValue.Visible = false;
            // 
            // gama
            // 
            this.gama.Location = new System.Drawing.Point(1822, 203);
            this.gama.Name = "gama";
            this.gama.Size = new System.Drawing.Size(90, 22);
            this.gama.TabIndex = 54;
            this.gama.Visible = false;
            // 
            // Alfa
            // 
            this.Alfa.Location = new System.Drawing.Point(1610, 203);
            this.Alfa.Name = "Alfa";
            this.Alfa.Size = new System.Drawing.Size(100, 22);
            this.Alfa.TabIndex = 53;
            this.Alfa.Visible = false;
            // 
            // Beta
            // 
            this.Beta.Location = new System.Drawing.Point(1716, 203);
            this.Beta.Name = "Beta";
            this.Beta.Size = new System.Drawing.Size(100, 22);
            this.Beta.TabIndex = 52;
            this.Beta.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1746, 228);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 16);
            this.label2.TabIndex = 51;
            this.label2.Text = "Beta";
            this.label2.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1640, 228);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 16);
            this.label1.TabIndex = 50;
            this.label1.Text = "Alfa";
            this.label1.Visible = false;
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.button5.FlatAppearance.BorderSize = 0;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button5.ForeColor = System.Drawing.Color.White;
            this.button5.Location = new System.Drawing.Point(1610, 154);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(302, 43);
            this.button5.TabIndex = 49;
            this.button5.Text = "Gama";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Visible = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.button4.FlatAppearance.BorderSize = 0;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button4.ForeColor = System.Drawing.Color.White;
            this.button4.Location = new System.Drawing.Point(1610, 105);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(302, 43);
            this.button4.TabIndex = 48;
            this.button4.Text = "Brignes";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Visible = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // redToolStripMenuItem
            // 
            this.redToolStripMenuItem.Name = "redToolStripMenuItem";
            this.redToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.redToolStripMenuItem.Text = "Red";
            this.redToolStripMenuItem.Click += new System.EventHandler(this.redToolStripMenuItem_Click);
            // 
            // greenToolStripMenuItem
            // 
            this.greenToolStripMenuItem.Name = "greenToolStripMenuItem";
            this.greenToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.greenToolStripMenuItem.Text = "Green";
            this.greenToolStripMenuItem.Click += new System.EventHandler(this.greenToolStripMenuItem_Click);
            // 
            // blueToolStripMenuItem
            // 
            this.blueToolStripMenuItem.Name = "blueToolStripMenuItem";
            this.blueToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.blueToolStripMenuItem.Text = "Blue";
            this.blueToolStripMenuItem.Click += new System.EventHandler(this.blueToolStripMenuItem_Click);
            // 
            // VideoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1924, 1033);
            this.Controls.Add(this.GamaValue);
            this.Controls.Add(this.gama);
            this.Controls.Add(this.Alfa);
            this.Controls.Add(this.Beta);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.panel2);
            this.Name = "VideoForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "VideoForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.VideoForm_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.VideoForm_KeyPress);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.VideoForm_MouseDown);
            this.videoEdit.ResumeLayout(false);
            this.contentLoad.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ContextMenuStrip videoEdit;
        private System.Windows.Forms.ToolStripMenuItem videoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem writeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem combineToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem playToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stopToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem effectsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ROI;
        private System.Windows.Forms.ContextMenuStrip contentLoad;
        private System.Windows.Forms.ToolStripMenuItem loadVideoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadImageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadCameraToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem greyScaleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem caruselToolStripMenuItem;
        private System.Windows.Forms.Label GamaValue;
        private System.Windows.Forms.TextBox gama;
        private System.Windows.Forms.TextBox Alfa;
        private System.Windows.Forms.TextBox Beta;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.ToolStripMenuItem bToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem colorHistogramToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem redToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem greenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem blueToolStripMenuItem;
    }
}