using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proiect
{
    internal class ContentImage:PictureBox
    {
        public int id;
        protected UserImage userImage = new UserImage() ;
        public ContentImage(int id)
        {
            this.Size = new Size(638, 538);
            this.id = id;
            
        }
        public void positionContent(int y)
        {
            this.Location = new Point(200,y);

        }
        public void loadImage()
        {
            userImage.loadImage(this);
        }
        public void convertToGrey()
        {
            userImage.convertToGrey(this);
        }
        public void histogram()
        {
            userImage.histogram();
        }
        public void brignes(TextBox alfa,TextBox beta)
        {
            userImage.Brignes(this, alfa, beta);
        }
        public void gama(TextBox gama)
        {
            userImage.gama(this,gama);
        }
        public UserImage GetImage()
        {
            return this.userImage;
        }
    }
}
