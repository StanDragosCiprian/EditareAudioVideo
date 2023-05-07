using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Imaging;

namespace Proiect
{
    internal class ButtonStyle:Button
    {
        public ButtonStyle(string buttonName) {
            this.Text = buttonName;    
            this.Size=new Size(223, 108);
            this.Dock = DockStyle.Top;
            this.BackColor = Color.FromArgb( 51, 51, 76);
            this.FlatStyle = FlatStyle.Flat;
            this.FlatAppearance.BorderSize = 0;
            this.ForeColor = Color.White;
            this.Font = new Font(this.Font.FontFamily, 16);
        }
    }
}
