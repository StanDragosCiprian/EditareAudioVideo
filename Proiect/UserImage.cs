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
    private Image<Bgr, byte> My_Imgae = null;
    private Image<Bgr, byte> finalImage = null;
    private Image<Bgr, byte> outputImage = null;
    private Image<Gray, byte> gray_image = null;

        public Image<Bgr, Byte> getUserImage()
        {
            return this.My_Imgae;
        }
        public void setUserImage(Image<Bgr, Byte> img)
        {
            this.My_Imgae = img;
        }
        public void loadImage(PictureBox pictureBox)
    {
         
        OpenFileDialog openFileDialog  = new OpenFileDialog();
        if (openFileDialog.ShowDialog() == DialogResult.OK)
        {
            this.My_Imgae = new Image<Bgr, byte>(openFileDialog.FileName);
            pictureBox.Image= this.My_Imgae.ToBitmap();

        }
    
    }
    public void convertToGrey(PictureBox pictureBox)
    {
        if (this.My_Imgae != null)
        {

            for (int i = 0; i < this.My_Imgae.Width / 2; i++)
            {
                for (int j = 0; j < this.My_Imgae.Height / 2; j++)
                {
                    this.My_Imgae[j, i] = new Bgr(Color.FromArgb(0, 255, 255, 255));
                }
            }
            this.gray_image = this.My_Imgae.Convert<Gray, byte>();
            pictureBox.Image= this.gray_image.AsBitmap();
            this.gray_image[0, 0] = new Gray(200);


        }

    }
    public void histogram()
    {
        HistogramViewer hist = new HistogramViewer();
        hist.HistogramCtrl.GenerateHistograms(this.My_Imgae, 255);
        hist.Text = "ce";
        hist.Show();
            HistogramViewer hist2 = new HistogramViewer();
            hist2.HistogramCtrl.GenerateHistograms(this.outputImage, 255);
            hist2.Show();
        }
    public void Brignes(PictureBox pictureBox, TextBox Alfa, TextBox Beta)
    {
        double alfa = double.Parse(Alfa.Text);
        double beta = double.Parse(Beta.Text);
        this.outputImage = this.My_Imgae.Mul(alfa) + beta;
        pictureBox.Image = this.outputImage.ToBitmap();
    }
public void gama(PictureBox pictureBox, TextBox gama)
{
    this.outputImage = this.My_Imgae.Clone();
    this.outputImage._GammaCorrect(double.Parse(gama.Text));
    pictureBox.Image = this.outputImage.ToBitmap();
}
        public async void blendingImage(PictureBox picture)
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
