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
using Emgu.CV.Flann;


namespace Proiect
{
    internal class UserVideo:UserImage
    {

        private int TotalFrame, FrameNo;
        private double Fps;
        private bool IsReadingFrame;
        public VideoCapture capture;
        private List<Mat> video = new List<Mat>();

        private PictureBox pictureBox1;
        int Fourcc;
        int Width;
        int Height;
        Mat mat;
      
        public void loadVideo(PictureBox pictureBox)
        {
            pictureBox1 = pictureBox;

            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                this.capture = new VideoCapture(ofd.FileName);

                mat = new Mat();
                this.capture.Read(mat);
                

                this.TotalFrame = (int)this.capture.Get(CapProp.FrameCount);
                this.Fps = this.capture.Get(CapProp.Fps);
                this.FrameNo = 1;
                this.fillVideo();
                pictureBox.Image = video[0].ToBitmap();


            }
        }
        public void fillVideo()
        {
            int frame = 1;
            while (frame < TotalFrame)
            {
                Mat mat = new Mat();
                this.capture.Read(mat);
                this.video.Add(mat);
                frame++;
            }
        }
        public async void ReadAllFrames()
        {

            while (isPlaying())
            {
                this.FrameNo += 1;
                //mat = this.capture.QueryFrame();
                //this.setUserImage(mat.ToImage<Bgr, byte>());
                pictureBox1.Image = video[this.FrameNo].ToBitmap();
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
            pictureBox1.Image = video[this.FrameNo].ToBitmap();
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
    
        public void playForward()
        {
            if (this.capture == null)
            {
                return;
            }
            if (this.FrameNo < this.TotalFrame)
            {
                this.controlFrame(1);
            }
        }
        public void playBack()
        {
            if (this.capture == null)
            {
                return;
            }
       if(this.FrameNo>0) { 
            this.controlFrame(-1);
            }
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
            this.Fourcc = Convert.ToInt32(this.capture.Get(CapProp.FourCC));
            this.Width = Convert.ToInt32(this.capture.Get(CapProp.FrameWidth));
            this.Height = Convert.ToInt32(this.capture.Get(CapProp.FrameHeight));
            this.Fps = this.capture.Get(CapProp.Fps);

        }

        public void readFrame(VideoWriter writer)
        {
            this.setWritingVideo();


            var FrameNo = 0;
            while (FrameNo < TotalFrame)
            {
                writer.Write(video[FrameNo]);
                FrameNo++;
            }

        }
        public void displayRoi(Rectangle rect)
        {
            //mouseDown = false;
            //var img = new Bitmap(picture.Image).ToImage<Bgr, byte>();
            //img.ROI = rect;
            //var imgROI = img.Copy();
            //this.Image = imgROI.ToBitmap();
            for (int index = 0; index < this.video.Count; index++)
            {
                var img = new Bitmap(this.video[index].ToBitmap()).ToImage<Bgr, byte>();
                img.ROI = rect;
                var imgROI = img.Copy();
                this.video[index] = imgROI.ToBitmap().ToMat();
            }
        }
        public void combineVideo()
        {
            this.setWritingVideo();
            string destinationpath = @"E:\\Facultate\\Editare audio video\\zzz.mp4";
            using (VideoWriter writer = new VideoWriter(destinationpath, Fourcc, Fps, new Size(Width, Height), true))
            {


                var FrameNo = 1;
                while (FrameNo < TotalFrame)
                {

                    writer.Write(video[FrameNo].ToBitmap().ToMat());
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

            for(int index = 0; index < this.video.Count; index++)
            {
                this.setUserImage(this.video[index].ToImage<Bgr, byte>());
                this.video[index] = this.makeGrey().ToBitmap().ToMat();
            }
            
            
        }
        public void carousel()
        {
            for (int index = 0; index < this.video.Count; index++)
            {
                this.setUserImage(this.video[index].ToImage<Bgr, byte>());
                this.video[index] = this.makeGrey().ToBitmap().ToMat();
                index++;
                this.setUserImage(this.video[index].ToImage<Bgr, byte>());
         
            }
        }



    }
}
