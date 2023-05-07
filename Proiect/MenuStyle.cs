using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proiect
{
    internal class MenuStyle : Panel
    {
        private ButtonStyle home = new ButtonStyle("Home");
        private ButtonStyle imageEditor = new ButtonStyle("Image Editor");
        private ButtonStyle videoEditor = new ButtonStyle("Video Editor");
        private ButtonStyle audioEditor = new ButtonStyle("Audio Editor");
        private Panel topPanel = new Panel();
        public MenuStyle()
        {
            this.Dock = DockStyle.Left;
            this.BackColor = Color.FromArgb(51, 51, 76);
            this.setPane();
            
            this.Controls.Add(audioEditor);
            this.Controls.Add(videoEditor);
            this.Controls.Add(imageEditor);
            this.Controls.Add(home);
            this.Controls.Add(topPanel);
        }
        private void setPane()
        {
            topPanel.BackColor = this.BackColor;
            topPanel.Dock = DockStyle.Top;
            topPanel.Size = new Size(223, 80);
        }
        public void setSize(int v)
        {
            topPanel.BackColor = this.BackColor;
            topPanel.Dock = DockStyle.Top;
            topPanel.Size = new Size(223, topPanel.Size.Height+v);
        }
    }
}
