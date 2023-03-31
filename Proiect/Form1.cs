using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.UI;
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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Image<Bgr, byte> My_Imgae = null; 
        Image<Bgr, byte> finalImage = null;
        Image<Bgr, byte> outputImage = null;
        Image<Bgr, byte> g = null;
        Rectangle rect;
        Point StartROI;
        bool MouseDown;
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if(openFileDialog.ShowDialog() == DialogResult.OK)
            {
                My_Imgae = new Image<Bgr, byte>(openFileDialog.FileName);
                pictureBox1.Image = My_Imgae.ToBitmap();
                
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (My_Imgae != null)
            {
             
                for (int i = 0; i < My_Imgae.Width / 2; i++)
                {
                    for (int j = 0; j < My_Imgae.Height / 2; j++)
                    {
                        My_Imgae[j, i] = new Bgr(Color.FromArgb(0, 255, 255, 255));
                    }
                }
                Image<Gray, byte> gray_image = My_Imgae.Convert<Gray, byte>();
                pictureBox2.Image = gray_image.AsBitmap();
                gray_image[0, 0] = new Gray(200);

                
            }
            }

        private void button3_Click(object sender, EventArgs e)
        {
            HistogramViewer hist = new HistogramViewer();
            hist.HistogramCtrl.GenerateHistograms(My_Imgae, 255);
            hist.Text = "ce";
            hist.Show();
            HistogramViewer hist2 = new HistogramViewer();
            hist2.HistogramCtrl.GenerateHistograms(outputImage, 255);
            hist2.Show();
        }

      

        private void button4_Click(object sender, EventArgs e)
        {
            double alfa = double.Parse( Alfa.Text);
            double beta = double.Parse(Beta.Text);
           outputImage = My_Imgae.Mul(alfa)+beta;
            pictureBox3.Image= finalImage.ToBitmap();
         

        }

        private void button5_Click(object sender, EventArgs e)
        {
            outputImage = My_Imgae.Clone();
            outputImage._GammaCorrect(double.Parse(gama.Text));
            pictureBox3.Image = outputImage.ToBitmap();
        }

        private void GamaValue_Click(object sender, EventArgs e)
        {

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
            pictureBox2.Image = imgROI.ToBitmap();
            pictureBox3.Image = My_Imgae.ToBitmap();
            pictureBox3.Image= imgROI.ToBitmap();

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

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            MouseDown = true;
            StartROI = e.Location;
        }
    }
}
