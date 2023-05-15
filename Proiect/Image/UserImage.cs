using Emgu.CV.Structure;
using Emgu.CV;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using Emgu.CV.UI;
using System.IO;

namespace Proiect
{
    internal class UserImage
    {
        private Image<Bgr, byte> My_Image = null;
        private Image<Bgr, byte> notProccesImage = null;
        private Image<Bgr, byte> outputImage = null;
        private Image<Gray, byte> gray_image = null;
        PictureBox pictureBox;
        public Image<Bgr, Byte> getUserImage()
        {
            return this.My_Image;
        }

        public void setUserImage(Image<Bgr, Byte> img)
        {
            this.My_Image = img;
        }
        public void setNotProccesImage(Image<Bgr, Byte> img)
        {
            this.notProccesImage = img;
        }
        public Image<Bgr, Byte> getNotProccesImage()
        {
            return this.notProccesImage;
        }
        public void setPictureBox(PictureBox pictureBox)
        {
            this.pictureBox = pictureBox;
        }
        public void loadImage()
        {

            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                this.My_Image = new Image<Bgr, byte>(openFileDialog.FileName);
                this.pictureBox.Image = this.My_Image.ToBitmap();

            }
        }

        public void convertToGrey()
        {
            if (this.My_Image != null)
            {

                for (int i = 0; i < this.My_Image.Width / 10; i++)
                {
                    for (int j = 0; j < this.My_Image.Height / 10; j++)
                    {
                        this.My_Image[j, i] = new Bgr(Color.FromArgb(0, 255, 255, 255));
                    }
                }
                this.gray_image = this.My_Image.Convert<Gray, byte>();
                this.pictureBox.Image = this.gray_image.AsBitmap();
                this.gray_image[0, 0] = new Gray(200);
            }

        }
        public Image<Gray,Byte> makeGrey()
        {
            if (this.My_Image != null)
            {

                for (int i = 0; i < this.My_Image.Width / 10; i++)
                {
                    for (int j = 0; j < this.My_Image.Height / 10; j++)
                    {
                        this.My_Image[j, i] = new Bgr(Color.FromArgb(0, 255, 255, 255));
                    }
                }
                this.gray_image = this.My_Image.Convert<Gray, byte>();
                return this.gray_image;
                //this.gray_image[0, 0] = new Gray(200);
            }
            return this.gray_image;
        }
        public void histogram()
        {
            HistogramViewer hist = new HistogramViewer();
            hist.HistogramCtrl.GenerateHistograms(this.My_Image, 255);
            hist.Text = "ce";
            hist.Show();
            HistogramViewer hist2 = new HistogramViewer();
            hist2.HistogramCtrl.GenerateHistograms(this.outputImage, 255);
            hist2.Show();
        }
        public void Brignes(ContentImage pictureBox, TextBox Alfa, TextBox Beta)
        {
            double alfa = double.Parse(Alfa.Text);
            double beta = double.Parse(Beta.Text);
            this.outputImage = this.My_Image.Mul(alfa) + beta;
            this.pictureBox.Image = this.outputImage.ToBitmap();
        }
        public void gama(ContentImage pictureBox, TextBox gama)
        {
            this.outputImage = this.My_Image.Clone();
            this.outputImage._GammaCorrect(double.Parse(gama.Text));
            this.pictureBox.Image = this.outputImage.ToBitmap();
        }
        public async void blendingImage(ContentImage picture)
        {
            string[] FileNames = Directory.GetFiles(@"C:\Users\Retro\Desktop\Random image", "*.png");
            List<Image<Bgr, byte>> listImages = new List<Image<Bgr, byte>>();
            foreach (var file in FileNames)
            {
                listImages.Add(new Image<Bgr, byte>(file));
            }
            for (int i = 0; i < listImages.Count - 1; i++)
            {
                for (double alpha = 0.0; alpha <= 1.0; alpha += 0.01)
                {
                    picture.Image = listImages[i + 1].AddWeighted(listImages[i], alpha, 1 - alpha, 0).AsBitmap();
                    await Task.Delay(25);
                }

            }
        }
    }
}
