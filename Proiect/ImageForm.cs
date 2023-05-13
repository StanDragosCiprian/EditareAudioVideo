using Emgu.CV.Structure;
using Emgu.CV;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proiect
{
    public partial class ImageForm : Form
    {
        public ImageForm()
        {
            InitializeComponent();
        }
        UserImage userImage = new UserImage();
        Rectangle rect;
        Point StartROI;
        bool MouseDown;
        Image<Bgr, byte> finalImage = null;
        int indexImagae = 0;
        int indexLocationY = 40;
        int indexSelected = 0;
        List<ContentImage> contentList = new List<ContentImage>();
        MenuStyle menuStyle;
        private void ImageForm_Load(object sender, EventArgs e)
        {
            
            menuStyle = new MenuStyle();
            menuStyle.switchEvent(this);
            menuStyle.makeEvent();
            this.Controls.Add(menuStyle);
        
            for (int i = 0; i < 20; i++)
            {
                contentList.Add(new ContentImage(i));
                contentList[i].Click += getIndex;
            }

        }
        private void button1_Click(object sender, EventArgs e)
        {

            this.Controls.Add(contentList[indexImagae]);
            contentList[indexImagae].positionContent(indexLocationY);
            //userImage.loadImage(contentList[indexImagae]);
            contentList[indexImagae].loadImage();
            //userImage.setNotProccesImage(userImage.getUserImage());
            indexImagae++;
            indexLocationY += 613;
        }
        private void button2_Click(object sender, EventArgs e)
        {

            contentList[indexSelected].convertToGrey();

        }
        private void getIndex(object sender, EventArgs e)
        {

            indexSelected = ((ContentImage)sender).id;

        }
        private void button3_Click(object sender, EventArgs e)
        {
            contentList[indexSelected].histogram();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            contentList[indexSelected].brignes(Alfa, Beta);

        }
        private void button5_Click(object sender, EventArgs e)
        {

            contentList[indexSelected].gama(gama);
        }
        private void pMouseMove(object sender, MouseEventArgs e)
        {
            if (contentList[indexSelected].Image == null)
            {
                return;
            }

            int width = Math.Max(StartROI.X, e.X) - Math.Min(StartROI.X, e.X);
            int height = Math.Max(StartROI.Y, e.Y) - Math.Min(StartROI.Y, e.Y);
            rect = new Rectangle(Math.Min(StartROI.X, e.X),
                Math.Min(StartROI.Y, e.Y),
                width,
                height);
            Refresh();

        }
        private void pMouseUp(object sender, MouseEventArgs e)
        {
            MouseDown = false;
            if (contentList[indexSelected].Image == null || rect == Rectangle.Empty)
            { return; }
            var img = new Bitmap(contentList[indexSelected].Image).ToImage<Bgr, byte>();
            img.ROI = rect;
            var imgROI = img.Copy();
            finalImage = imgROI;
            userImage.setUserImage(imgROI);

            pictureBox1.Image = userImage.getUserImage().ToBitmap();
        }
        private void pPaint(object sender, PaintEventArgs e)
        {
            if (MouseDown)
            {
                using (Pen pen = new Pen(Color.Red, 1))
                {
                    e.Graphics.DrawRectangle(pen, rect);
                }
            }

        }

        private void pMouseDown(object sender, MouseEventArgs e)
        {
            MouseDown = true;
            StartROI = e.Location;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            contentList[indexSelected].MouseMove += pMouseMove;
            contentList[indexSelected].MouseUp += pMouseUp;
            contentList[indexSelected].MouseDown += pMouseDown;
            contentList[indexSelected].Paint += pPaint;
        }
        
        
    }
}
