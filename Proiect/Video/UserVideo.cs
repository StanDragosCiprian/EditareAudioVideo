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
using System.Xml.Linq;
using Emgu.CV.VideoStab;
using System.Diagnostics;
namespace Proiect
{
    internal class UserVideo : UserImage
    {
        private int TotalFrame, FrameNo;
        private double Fps;
        private bool IsReadingFrame;
        public VideoCapture capture;
        protected List<Mat> video = new List<Mat>();
        protected List<Mat> video2 = new List<Mat>();
        protected List<Mat> roi = new List<Mat>();
        private PictureBox pictureBox1;
        OpenFileDialog ofd;
        int Fourcc;
        int Width;
        int Height;
        Mat mat;
        bool isRoi = false;
        public List<Mat> getAllVideo()
        {
            return video;
        }
        public void loadVideo(PictureBox pictureBox)
        {
            pictureBox1 = pictureBox;

            ofd = new OpenFileDialog();
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
            
            this.video2.AddRange(this.video);

        }
        public void comeBackVideo()
        {
            if (!isRoi)
            {
                this.video.Clear();
                this.video.AddRange(this.video2);
            }
            else
            {
                this.video.Clear();
                this.video.AddRange(this.roi);
            }
        }
        public void cancelRoi()
        {
           
                this.video.Clear();
                this.video.AddRange(this.video2);
            this.pictureBox1.Image = this.video[0].ToBitmap();
            this.isRoi = false;


        }
            public async void ReadAllFrames()
        {
            while (isPlaying())
            {
                this.FrameNo += 1;
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
            if (this.FrameNo > 0) {
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
            var FrameNo = 1;
            while (FrameNo < TotalFrame)
            {
                writer.Write(video[FrameNo-1]);
                FrameNo++;
            }
        }
        public void displayRoi(Rectangle rect)
        {
            this.isRoi = true;
            for (int index = 0; index < this.video.Count; index++)
            {
                var img = new Bitmap(this.video[index].ToBitmap()).ToImage<Bgr, byte>();
                img.ROI = rect;
                var imgROI = img.Copy();
                this.video[index] = imgROI.ToBitmap().ToMat();
            }
            this.roi.AddRange(this.video);
            pictureBox1.Image = video[this.FrameNo].ToBitmap();
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
            this.comeBackVideo();
            for (int index = 0; index < this.video.Count; index++)
            {
                this.setUserImage(this.video[index].ToImage<Bgr, byte>());
                this.video[index] = this.makeGrey().ToBitmap().ToMat();
            }

            pictureBox1.Image = video[this.FrameNo].ToBitmap();
            
        }
        private void treeFrameWait(ref int index, Bgr bgr)
        {
            for (int i = 0; i < 6; i++)
            {
                this.setUserImage(this.video[index].ToImage<Bgr, byte>());
                this.video[index] = this.subtractColor(bgr).Mat;
                index++;
            }
        }
        private void treeFrameGreyWait(ref int index)
        {
            for (int i = 0; i < 6; i++)
            {
                this.setUserImage(this.video[index].ToImage<Bgr, byte>());
                this.video[index] = this.makeGrey().ToBitmap().ToMat();
                index++;
            }
        }

        
        public void carousel()
        {
            this.comeBackVideo();
            int index = 0;
            while (index < TotalFrame)
            {
                try
                {
                    this.treeFrameGreyWait(ref index);
                    this.treeFrameWait(ref index, new Bgr(0, 0, 255));
                    this.treeFrameWait(ref index, new Bgr(0, 255, 0));
                    this.treeFrameWait(ref index, new Bgr(255, 0, 0));
                }catch(ArgumentOutOfRangeException e)
                {
                    pictureBox1.Image = video[this.FrameNo].ToBitmap();
                    break;
                }
            }
        }
        private void lastTenFrame(List<Mat> uVideo)
        {
            List<byte> alfaValue = new List<byte>() { 255, 130, 98, 90, 87, 80, 75, 63, 57, 9, 0 };
            alfaValue.Reverse();
            int index = 0;
            int totalFrame = uVideo.Count - 11;
            for (int frame= totalFrame; frame < uVideo.Count - 1; frame++)
            {

                Image<Bgr, byte> img = uVideo[frame].ToImage<Bgr, byte>();
                Image<Bgra, byte> imgWithAlpha = img.Convert<Bgra, byte>();
                for (int i = 0; i < imgWithAlpha.Height; i++)
                {
                    for (int j = 0; j < imgWithAlpha.Width; j++)
                    {
                        imgWithAlpha.Data[i, j, 3] = alfaValue[index];
                    }
                }
                uVideo[frame] = imgWithAlpha.Mat;
                index++;
            }
        }
        public void crossDissolve(List<Mat> uVideo)
        {
            
        
            this.setWritingVideo();
            string destinationpath = @"E:\\Facultate\\crossDissolve.mp4";
            using (VideoWriter writer = new VideoWriter(destinationpath, Fourcc, Fps, new Size(Width, Height), true))
            {
                var FrameNo = 1;
                var FrameNo2 = 0;
                double alpha = 0.0;
                Image<Bgra, byte> img1;
                while (FrameNo < (this.video.Count+uVideo.Count))
                {
                    try { 
                        
                    using (Image<Bgra, byte> img2 = uVideo[FrameNo2].ToImage<Bgra, byte>())
                    {
                            if(FrameNo< (this.video.Count - 50))
                            {
                                img1 = this.video[FrameNo].ToImage<Bgra, byte>();
                                writer.Write(img1.Mat);
                            }
                            else if(FrameNo > (this.video.Count - 50)&& FrameNo < this.video.Count)
                            {
                                img1 = this.video[FrameNo].ToImage<Bgra, byte>();
                                alpha += 0.01;
                                CvInvoke.AddWeighted(img1, alpha, img2, 1-alpha, 0.0, img1);
                                
                                writer.Write(img1.Mat);
                          
                            }
                            else
                            {
                                writer.Write(img2.Mat);
                                FrameNo2++;
                            }
                    }
                }catch(ArgumentOutOfRangeException e)
                {
                    break;
                }
                FrameNo++;
                }
            }
                

        }
        public void brignesVidep(TextBox alfa, TextBox beta)
        {
            this.comeBackVideo();
            for (int i = 0; i < video.Count; i++)
            {
                this.setUserImage(video[i].ToImage<Bgr, byte>());
                video[i] = this.Brignes(alfa, beta).Mat;
            }
            pictureBox1.Image = video[this.FrameNo].ToBitmap();
        }
        public void extractColor(Bgr bgr)
        {
            this.comeBackVideo();
            for (int i = 0; i < video.Count; i++)
            {

                this.setUserImage(this.video[i].ToImage<Bgr, byte>());
                this.video[i] = this.subtractColor(bgr).Mat;

            }
            pictureBox1.Image = video[this.FrameNo].ToBitmap();
        }
        public void gamaVidep(TextBox gama)
        {
            this.comeBackVideo();
            for (int i = 0; i < video.Count; i++)
            {
                this.setUserImage(video[i].ToImage<Bgr, byte>());
                video[i] = this.getGama(gama).Mat;
            }
            pictureBox1.Image = video[this.FrameNo].ToBitmap();
        }
        public void combineVideoAudio(OpenFileDialog audioFileName)
        {
            
            string videoPath = this.ofd.FileName;
            string audioPath = audioFileName.FileName;
            string outputPath = @"E:\Facultate\output.mp4";
            string text = "Hello World!";
            string fontPath = @"E:\Facultate\OpenSans-Bold.ttf";

            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = "ffmpeg.exe";
            startInfo.Arguments = $"-i \"{videoPath}\" -i \"{audioPath}\" -vf drawtext=\"fontfile={fontPath}: text='{text}': fontcolor=white: fontsize=24: box=1: boxcolor=black@0.5: boxborderw=5: x=(w-text_w)/2: y=(h-text_h)/2\" -c:v libx264 -c:a copy \"{outputPath}\"";
            startInfo.UseShellExecute = false;
            startInfo.RedirectStandardOutput = true;
            startInfo.RedirectStandardError = true;

            using (Process process = new Process())
            {
                process.StartInfo = startInfo;
                process.Start();
                process.WaitForExit();
            }
        }
    }
}