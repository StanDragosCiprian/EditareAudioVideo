using Emgu.CV.CvEnum;
using Emgu.CV;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media.Media3D;
using System.Reflection.Emit;
using Emgu.CV.Structure;
using System.Drawing;


namespace Proiect
{
    internal class UserVideo:UserImage
    {

        private int TotalFrame, FrameNo;
        private double Fps;
        private bool IsReadingFrame;
        public VideoCapture capture;
        public VideoCapture captureSecind= new VideoCapture("output.mp4");


        private PictureBox pictureBox1;
        int Fourcc;
        int Width;
        int Height;
        Control control;
        Mat mat;
        public void setControl(Control control)
        {
            this.control = control;
        }
        public void loadVideo(PictureBox pictureBox)
        {
            pictureBox1 = pictureBox;

            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                this.capture = new VideoCapture(ofd.FileName);

                mat = new Mat();
                this.capture.Read(mat);
                pictureBox.Image = mat.ToBitmap();

                this.TotalFrame = (int)this.capture.Get(CapProp.FrameCount);
                this.Fps = this.capture.Get(CapProp.Fps);
                this.FrameNo = 1;
                
           
            }
        }
        public async void ReadAllFrames()
        {

            while (isPlaying())
            {
                this.FrameNo += 1;
                mat = this.capture.QueryFrame();
                pictureBox1.Image = mat.ToBitmap();
                await Task.Delay(1000 / Convert.ToInt16(this.Fps));
              
            }
        }
        public bool isPlaying()
        {
            return this.IsReadingFrame == true && this.FrameNo < this.TotalFrame;
        }
        public async void controlFrame(int frame)
        {
            this.FrameNo += frame;
            this.capture.Set(CapProp.PosFrames, this.FrameNo);
            mat = this.capture.QueryFrame();
            //pictureBox1.Image = mat.ToBitmap();
            await Task.Delay(1000 / Convert.ToInt16(this.Fps));

        }


        public void play()
        {
            if (this.capture == null)
            {
                return;
            }
            this.IsReadingFrame = true;
            this.ReadAllFrames();
        }
        public Mat getMat()
        {
            return this.mat;
        }
        public void playForward()
        {
            if (this.capture == null)
            {
                return;
            }
            this.IsReadingFrame = true;
            this.controlFrame(1);
        }
        public void playBack()
        {
            if (this.capture == null)
            {
                return;
            }
       
            this.controlFrame(-1);
        }
        public void stop()
        {
            if (this.capture == null)
            {
                return;
            }
            this.IsReadingFrame = false;
            this.ReadAllFrames();
        }
        public void setWritingVideo()
        {
            int Fourcc = Convert.ToInt32(this.capture.Get(CapProp.FourCC));
            int Width = Convert.ToInt32(this.capture.Get(CapProp.FrameWidth));
            int Height = Convert.ToInt32(this.capture.Get(CapProp.FrameHeight));
            var Fps = this.capture.Get(CapProp.Fps);
            var TotalFrame = capture.Get(CapProp.FrameCount);
        }

        public void readFrame(VideoWriter writer)
        {
            this.setWritingVideo();
            Mat m = new Mat();

            var FrameNo = 1;
            while (FrameNo < TotalFrame)
            {
                capture.Read(m);
                Image<Bgr,byte> img=m.ToImage<Bgr,byte>();
                writer.Write(img.Mat);
                FrameNo++;
            }
        }
        public void generateNewVideo(PictureBox picture, Rectangle rect)
        {
            int Fourcc = Convert.ToInt32(capture.Get(CapProp.FourCC));
            int Width = Convert.ToInt32(capture.Get(CapProp.FrameWidth));
            int Height = Convert.ToInt32(capture.Get(CapProp.FrameHeight));
            var Fps = capture.Get(CapProp.Fps);
            string destinationpath = @"E:\\Facultate\\Editare audio video\\zzz.mp4";
            using (VideoWriter writer = new VideoWriter(destinationpath, Fourcc, Fps, new Size(Width, Height), true))
            {
           

                var FrameNo = 1;
                while (FrameNo < TotalFrame)
                {
                    capture.Read(mat);
                    Image<Bgr, byte> img = mat.ToImage<Bgr, byte>();
                    img.ROI = new Rectangle(0,0, rect.Width, rect.Height);
           
                    
                    FrameNo++;
                }

            }


        }
        public void writingVideo(UserImage userImage)
        {

            this.setWritingVideo();
            Image<Bgr, byte> logo = userImage.getUserImage();
            string destinationpath = @"E:\\Facultate\\test2.mp4";
            using (VideoWriter writer = new VideoWriter(destinationpath, Fourcc, Fps, new Size(Width, Height), true))
            {

                Mat m = new Mat();

                var FrameNo = 1;
                while (FrameNo < TotalFrame)
                {
                    capture.Read(m);
                    Image<Bgr, byte> img = m.ToImage<Bgr, byte>();
                    img.ROI = new Rectangle(10, 10, logo.Width, logo.Height);
                    logo.CopyTo(img);

                    img.ROI = Rectangle.Empty;

                    writer.Write(img.Mat);
                    FrameNo++;
                }

            }

        }
        public void setGreyScale(PictureBox picture)
        {
            this.setUserImage(mat.ToImage<Bgr, byte>());
            this.setPictureBox(picture);
            this.convertToGrey();
        }
     

    }
}
