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
        protected List<Mat> videoBackup = new List<Mat>();
        protected List<Mat> roi = new List<Mat>();
        private PictureBox pictureBox1;
        OpenFileDialog ofd;
        int Fourcc;
        int Width;
        int Height;
        Mat mat;
        Rectangle rect;
        bool isRoi = false;

        public Rectangle Rect { get => rect; set => rect = value; }
        public PictureBox PictureBox1 { get => pictureBox1; set => pictureBox1 = value; }
        public OpenFileDialog Ofd { get => ofd; set => ofd = value; }

        public List<Mat> getAllVideo()
        {
            return video;
        }
        public int getTotalFrame()
        {
            return this.TotalFrame;
        }
        public void setFrame(int frame)
        {
            this.FrameNo = frame;
            this.pictureBox1.Image = this.video[frame].ToBitmap();
        }
        public void load(OpenFileDialog ofd)
        {
                this.capture = new VideoCapture(ofd.FileName);
                mat = new Mat();
                this.capture.Read(mat);
                this.TotalFrame = (int)this.capture.Get(CapProp.FrameCount);
                this.Fps = this.capture.Get(CapProp.Fps);
                this.FrameNo = 1;
                this.fillVideo();
                this.pictureBox1.Image = this.video[0].ToBitmap();
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

            this.videoBackup.AddRange(this.video);

        }
        public void resizeRoi(TextBox rectX, TextBox rectY)
        {

            int x = int.Parse(rectX.Text);
            int y = int.Parse(rectY.Text);
            this.rect.X -= x;
            this.rect.Y -= y;  
            this.rect.Width += x;
            this.rect.Height += y;
            this.displayRoi(this.rect);
        }
        public void comeBackVideo()
        {

            this.video.Clear();
            this.video.AddRange(this.videoBackup);

        }
        public void combineWithRoi()
        {
            if (isRoi)
            {
                var FrameNo = 1;
                while (FrameNo < TotalFrame - 1)
                {
                    Image<Bgr, byte> img1 = this.video[FrameNo].ToImage<Bgr, byte>();
                    Image<Bgr, byte> img2 = this.roi[FrameNo].ToImage<Bgr, byte>();
                    for (int i = 0; i < img2.Height; i++)
                    {
                        for (int j = 0; j < img2.Width; j++)
                        {
                            img1.Data[i + rect.Y, j + rect.X, 0] = img2.Data[i, j, 0];
                            img1.Data[i + rect.Y, j + rect.X, 1] = img2.Data[i, j, 1];
                            img1.Data[i + rect.Y, j + rect.X, 2] = img2.Data[i, j, 2];
                        }
                    }
                    this.video[FrameNo] = img1.Mat;
                    FrameNo++;
                }
            }
        }

        public void cancelRoi()
        {

            this.video.Clear();
            this.video.AddRange(this.videoBackup);
            this.pictureBox1.Image = this.video[0].ToBitmap();
            this.isRoi = false;


        }
        public async void ReadAllFrames(int frame)
        {
            while (isPlaying())
            {

                pictureBox1.Image = video[this.FrameNo].ToBitmap();
                await Task.Delay(1000 / Convert.ToInt16(this.Fps));
                this.FrameNo += frame;
            }
        }
        public bool isPlaying()
        {
            return this.IsReadingFrame == true && this.FrameNo < this.TotalFrame-1;
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
            this.ReadAllFrames(1);
        }
        public void playBackFrame()
        {
            if (this.capture == null)
            {
                return;
            }
            this.IsReadingFrame = true;
            this.ReadAllFrames(-1);
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
            if (this.FrameNo > 0)
            {
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
            this.ReadAllFrames(1);
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
                writer.Write(video[FrameNo - 1]);
                FrameNo++;
            }
        }
        public void displayRoi(Rectangle rect)
        {
            this.isRoi = true;
            this.rect = rect;
            this.roi.Clear();
            for (int index = 0; index < this.video.Count; index++)
            {
                var img = new Bitmap(this.videoBackup[index].ToBitmap()).ToImage<Bgr, byte>();
                img.ROI = rect;
                var imgROI = img.Copy();
                this.roi.Add(imgROI.ToBitmap().ToMat());
            }
            this.combineWithRoi();
            pictureBox1.Image = this.video[this.FrameNo].ToBitmap();
        }

        public void setGreyScale(PictureBox picture)
        {
            this.comeBackVideo();
            for (int index = 0; index < this.video.Count; index++)
            {
                this.setUserImage(this.video[index].ToImage<Bgr, byte>());
                this.video[index] = this.makeGrey().ToBitmap().ToMat();
            }
            this.combineWithRoi();
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
                }
                catch (ArgumentOutOfRangeException e)
                {
                    pictureBox1.Image = video[this.FrameNo].ToBitmap();
                    break;
                }
            }
            this.combineWithRoi();
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
                while (FrameNo < (this.video.Count + uVideo.Count))
                {
                    try
                    {

                        using (Image<Bgra, byte> img2 = uVideo[FrameNo2].ToImage<Bgra, byte>())
                        {
                            if (FrameNo <= (this.video.Count - 12))
                            {
                                img1 = this.video[FrameNo].ToImage<Bgra, byte>();
                                writer.Write(img1.Mat);
                            }
                            else if (FrameNo > (this.video.Count - 12) && FrameNo < this.video.Count)
                            {
                                img1 = this.video[FrameNo].ToImage<Bgra, byte>();
                                alpha += 0.05;
                                CvInvoke.AddWeighted(img1, alpha, img2,  alpha, 0.0, img1);
                                
                                writer.Write(img1.Mat);
                                FrameNo2++;

                            }
                            else if(FrameNo >= this.video.Count && FrameNo < this.video.Count + uVideo.Count)
                            {
                                writer.Write(img2.Mat);
                                FrameNo2++;
                            }
                        }
                    }
                    catch (ArgumentOutOfRangeException e)
                    {
                        break;
                    }
                    FrameNo++;
                }
            }
        }
        public void brightnessVideo(TextBox alfa, TextBox beta)
        {
            this.comeBackVideo();
            for (int i = 0; i < video.Count; i++)
            {
                this.setUserImage(video[i].ToImage<Bgr, byte>());
                video[i] = this.brightness(alfa, beta).Mat;
            }
            this.combineWithRoi();
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
            this.combineWithRoi();
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
            this.combineWithRoi();
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
        private Image<Bgr, byte> combineImage(Image<Bgr, byte> img1, Image<Bgr, byte> img2,int x,int y)
        {
            for (int i = 0; i < img2.Height; i++)
            {
                for (int j = 0; j < img2.Width; j++)
                {
                    img1.Data[i + x, j + y, 0] = img2.Data[i, j, 0];
                    img1.Data[i + x, j + y, 1] = img2.Data[i, j, 1];
                    img1.Data[i + x, j + y, 2] = img2.Data[i, j, 2];
                }
            }
            return img1;
        }
        public void combineVideo(UserVideo userVideo)
        {

            this.setWritingVideo();
            string destinationpath = @"E:\Facultate\Editare audio video\CombineVideo.mp4";
            using (VideoWriter writer = new VideoWriter(destinationpath, this.Fourcc, this.Fps, new Size(this.Width, this.Height), true))
            {


                var FrameNo = 1;
                while (FrameNo < TotalFrame - 1)
                {
                    try
                    {
                        Image<Bgr, byte> img1 = this.video[FrameNo].ToImage<Bgr, byte>();
                        Image<Bgr, byte> img2 = userVideo.video[FrameNo].ToImage<Bgr, byte>();
                        img2.ROI = new Rectangle(10, 10, img2.Width, img2.Height);
                       var outputImage= combineImage(img1 , img2,10,10);

                        writer.Write(outputImage.Mat);

                        FrameNo++;
                    }
                    catch (Exception e)
                    {
                        Image<Bgr, byte> img1 = this.video[FrameNo].ToImage<Bgr, byte>();
                        writer.Write(img1);
                        FrameNo++;
                    }
                }
            }
        }
    }
}