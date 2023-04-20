using Emgu.CV.CvEnum;
using Emgu.CV;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Emgu.CV.DepthAI;
using System.Reflection.Emit;
using Emgu.CV.Structure;
using System.Drawing;

namespace Proiect
{
    internal class UserVideo
    {

        private int TotalFrame, FrameNo;
        private double Fps;
        private bool IsReadingFrame;
        private VideoCapture capture;

        private NumericUpDown numericUpDown1;
        private PictureBox pictureBox1;

        private System.Windows.Forms.Label label1;

        public void loadVideo(PictureBox pictureBox, NumericUpDown numericUpDown1, System.Windows.Forms.Label label)
        {
            pictureBox1 = pictureBox;
            label1 = label;
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                this.capture = new VideoCapture(ofd.FileName);
                Mat m = new Mat();
                this.capture.Read(m);
                pictureBox.Image = m.ToBitmap();

                this.TotalFrame = (int)this.capture.Get(CapProp.FrameCount);
                this.Fps = this.capture.Get(CapProp.Fps);
                this.FrameNo = 1;
                numericUpDown1.Value = this.FrameNo;
                numericUpDown1.Minimum = 0;
                numericUpDown1.Maximum = this.TotalFrame;
            }
        }
        public async void ReadAllFrames()
        {
            Mat m = new Mat();
            while (this.IsReadingFrame == true && this.FrameNo < this.TotalFrame)
            {
                this.FrameNo += 1;
                var mat = this.capture.QueryFrame();
                pictureBox1.Image = mat.ToBitmap();
                await Task.Delay(1000 / Convert.ToInt16(this.Fps));
                label1.Text = this.FrameNo.ToString() + "/" + this.TotalFrame.ToString();
            }
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

        public void wiriteToVideo(UserImage userImage)
        {
            VideoCapture capture = new VideoCapture(@"C:\Users\Retro\Desktop\Star Wars Reflections 4K Unreal Engine Real-Time Ray Tracing Demonstration (360).mp4");
            int Fourcc = Convert.ToInt32(capture.Get(CapProp.FourCC));
            int Width = Convert.ToInt32(capture.Get(CapProp.FrameWidth));
            int Height = Convert.ToInt32(capture.Get(CapProp.FrameHeight));
            var Fps = capture.Get(CapProp.Fps);
            var TotalFrame = capture.Get(CapProp.FrameCount);
            string destionpath = @"C:\Users\Retro\Desktop\Star Wars Reflections 4K Unreal Engine Real-Time Ray Tracing Demonstration (360).mp4";
            using (VideoWriter writer = new VideoWriter(destionpath, Fourcc, Fps, new Size(Width, Height), true))
            {
                Image<Bgr, byte> logo = userImage.getUserImage();
                Mat m = new Mat();
                var FrameNo = 1;
                while (FrameNo < TotalFrame)
                {
                    capture.Read(m);
                    Image<Bgr, byte> img = m.ToImage<Bgr, byte>();
                    img.ROI = new Rectangle(Width - logo.Width - 30, 10, logo.Width, logo.Height);
                    logo.CopyTo(img);
                    img.ROI = Rectangle.Empty;
                    writer.Write(img.Mat);
                    FrameNo++;
                }
            }
        }

    }
}
