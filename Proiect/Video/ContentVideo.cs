using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Proiect
{
    internal class ContentVideo : ContentImage
    {
        private UserVideo userVideo = new UserVideo();

        private UserCamera userCamera = new UserCamera();
        Rectangle rect;
        Point StartROI;
        bool mouseDown;

        public UserVideo getVideo()
        {
            return this.userVideo;
        }

        public UserCamera getCamera()
        {
            return this.userCamera;
        }
        public ContentVideo(int id) : base(id)
        {
            this.Size = new Size(640, 360);
            this.id = id;
        }

        private void pictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (this.Image == null)
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
        private void pictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
            if (this.Image == null || rect == Rectangle.Empty)
            { return; }
            this.userVideo.displayRoi(rect);
            this.notInitMouseEvents();

        }
        private void pictureBox_Paint(object sender, PaintEventArgs e)
        {
            if (mouseDown)
            {
                using (Pen pen = new Pen(Color.Red, 1))
                {
                    e.Graphics.DrawRectangle(pen, rect);
                }
            }
        }
        private void pictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            StartROI = e.Location;
        }
        public void initMouseEvents()
        {
            this.Paint += this.pictureBox_Paint;
            this.MouseDown += this.pictureBox_MouseDown;
            this.MouseUp += this.pictureBox_MouseUp;
            this.MouseMove += this.pictureBox_MouseMove;
        }
        public void notInitMouseEvents()
        {
            this.Paint -= this.pictureBox_Paint;
            this.MouseDown -= this.pictureBox_MouseDown;
            this.MouseUp -= this.pictureBox_MouseUp;
            this.MouseMove -= this.pictureBox_MouseMove;
        }



    }
}
