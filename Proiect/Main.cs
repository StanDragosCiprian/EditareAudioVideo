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
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }
        MenuStyle menuStyle;

        UserVideo userVideo = new UserVideo();
        UserVideo userVideo2 = new UserVideo();

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
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.FileName = @"E:\Facultate\Editare audio video\SecondVideo.mp4";
            userVideo.PictureBox1=pictureBox1;
            userVideo.load(ofd);
            userVideo.play();
            userVideo2.PictureBox1 = pictureBox2;
            ofd.FileName = @"E:\Facultate\Editare audio video\CaruselFirstPage.mp4";
            userVideo2.load(ofd);
            userVideo2.play();

        }
    }
}
