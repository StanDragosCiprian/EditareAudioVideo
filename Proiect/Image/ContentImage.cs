using System.Drawing;
using System.Windows.Forms;

namespace Proiect
{
    internal class ContentImage:PictureBox
    {
        public int id;
        protected UserImage userImage = new UserImage() ;
        public ContentImage(int id)
        {
            this.Size = new Size(640, 360);
            this.Cursor = Cursors.Hand;
            this.id = id;
            
        }
        public void positionContentY(int y)
        {
            this.Location = new Point(200,y);

        }
        public void positionContentX(int X)
        {
            this.Location = new Point(X, 200);

        }
        public void loadImage()
        {
            userImage.setPictureBox(this);
            userImage.loadImage();
        }
        public void convertToGrey()
        {
            userImage.convertToGrey();
        }
        public void histogram()
        {
            userImage.histogram();
        }
        public void brignes(TextBox alfa,TextBox beta)
        {
            userImage.brightness(this, alfa, beta);
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
