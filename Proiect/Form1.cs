using Emgu.CV;
using Emgu.CV.CvEnum;

using Emgu.CV.Structure;
using Emgu.CV.UI;
using Emgu.CV.XPhoto;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proiect
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Image<Bgr, byte> finalImage = null;
        UserImage userImage = new UserImage();
        UserVideo userVideo = new UserVideo();
        UserVideo userVideo2 = new UserVideo();
        UserCamera userCamera = new UserCamera();
        UserAudio userAudio = new UserAudio();
        Rectangle rect;
        Point StartROI;
        bool MouseDown;
        MenuStyle menuStyle;
        //private Image<Bgr, Byte> newBackgroundImage = new Image<Bgr, byte>(@"C:\Users\Retro\Desktop\R.jpg");
        private static IBackgroundSubtractor fgDetector;
        private void button1_Click(object sender, EventArgs e)
        {
            userImage.loadImage(pictureBox1);
            userImage.setNotProccesImage(userImage.getUserImage());
        }
        private void button2_Click(object sender, EventArgs e)
        {
          //  userImage.convertToGrey(pictureBox2);
        }
        private void button3_Click(object sender, EventArgs e)
        {
            userImage.histogram();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            //userImage.Brignes(pictureBox2, Alfa, Beta);

        }
        private void button5_Click(object sender, EventArgs e)
        {

          //  userImage.gama(pictureBox2, gama);
        }
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (pictureBox1.Image == null)
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
        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            MouseDown = false;
            if (pictureBox1.Image == null || rect == Rectangle.Empty)
            { return; }
            var img = new Bitmap(pictureBox1.Image).ToImage<Bgr, byte>();
            img.ROI = rect;
            var imgROI = img.Copy();
            finalImage = imgROI;
            userImage.setUserImage(imgROI);

            pictureBox2.Image = userImage.getUserImage().ToBitmap();
        }
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            if (MouseDown)
            {
                using (Pen pen = new Pen(Color.Red, 1))
                {
                    e.Graphics.DrawRectangle(pen, rect);
                }
            }

        }
        private void button6_Click(object sender, EventArgs e)
        {
            userVideo.loadVideo(pictureBox3, numericUpDown1, label3);
        }
        private void button7_Click(object sender, EventArgs e)
        {
            userVideo.play();
            userVideo2.play();
        }
        private void button8_Click(object sender, EventArgs e)
        {
            userCamera.init(pictureBox4, userImage);
        }

        private async void button11_Click(object sender, EventArgs e)
        {
          //  userImage.blendingImage(pictureBox5);
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            MouseDown = true;
            StartROI = e.Location;
        }


        private void button10_Click(object sender, EventArgs e)
        {
            userVideo.writingVideo(userImage);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            userVideo2.loadVideo(pictureBox6, numericUpDown1, label3);
        }
        public  void abruptway()
        {
            int Fourcc = Convert.ToInt32(userVideo.capture.Get(CapProp.FourCC));
            int Width = Convert.ToInt32(userVideo.capture.Get(CapProp.FrameWidth));
            int Height = Convert.ToInt32(userVideo.capture.Get(CapProp.FrameHeight));
            var Fps = userVideo.capture.Get(CapProp.Fps);
            string destinationpath = @"E:\\Facultate\\Editare audio video\\zzz.mp4";
            using (VideoWriter writer = new VideoWriter(destinationpath, Fourcc, Fps, new Size(Width, Height), true))
            {
                userVideo.readFrame(writer);
                userVideo2.readFrame(writer);
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            abruptway();
        }

        private void loadAudio_Click(object sender, EventArgs e)
        {
            userAudio.loadAudio();
        }

        private void PlayAudio_Click(object sender, EventArgs e)
        {
            userAudio.play();
        }

        private void converWav_Click(object sender, EventArgs e)
        {
            userAudio.converWav();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            userAudio.converMp3();
        }

        private void Mix_Click(object sender, EventArgs e)
        {
            userAudio.mixt();
        }

        private void mono_Click(object sender, EventArgs e)
        {
            userAudio.mono();
        }

        private void sterio_Click(object sender, EventArgs e)
        {
            userAudio.sterio();
        }

        private void Concatenating_Click(object sender, EventArgs e)
        {
            userAudio.concatenating();
        }

        private void switchToImage_Click(object sender, EventArgs e)
        {
            this.Hide();
            ImageForm imageForm=new ImageForm();
            imageForm.ShowDialog();
            this.Close();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            this.Hide();
            VideoForm videoForm = new VideoForm();
            videoForm.ShowDialog();
            this.Close();

        }

        private void button15_Click(object sender, EventArgs e)
        {
            this.Hide();
            AudioFrom audioForm = new AudioFrom();
            audioForm.ShowDialog();
            this.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            menuStyle = new MenuStyle();
            menuStyle.switchEvent(this);
            menuStyle.makeEvent();
            this.Controls.Add(menuStyle);
        }
    }
}
