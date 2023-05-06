using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proiect
{
    internal class Content:PictureBox
    {
        public int id;
        public Content(int id)
        {
            this.Size = new Size(638, 538);
            this.id = id;
        }
        public void positionContent(int y)
        {
            this.Location = new Point(200,y);

        }
    }
}
