using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media.Media3D;

namespace Proiect
{
    internal class UserCamera
    {
        private Image<Bgr, Byte> newBackgroundImage = null;
        private static IBackgroundSubtractor fgDetector;
        private Camera camera;
        private VideoCapture cameraCapture;
        private PictureBox pictureBox1;
        private void ProcessFrames(object sender, EventArgs e)
        {

            Mat frame = this.cameraCapture.QueryFrame();
            Image<Bgr, byte> frameImage = frame.ToImage<Bgr, Byte>();

            Mat foregroundMask = new Mat();
            fgDetector.Apply(frame, foregroundMask);
            var foregroundMaskImage = foregroundMask.ToImage<Gray, Byte>();
            foregroundMaskImage = foregroundMaskImage.Not();

            var copyOfNewBackgroundImage = newBackgroundImage.Resize(foregroundMaskImage.Width, foregroundMaskImage.Height, Inter.Lanczos4);
            copyOfNewBackgroundImage = copyOfNewBackgroundImage.Copy(foregroundMaskImage);

            foregroundMaskImage = foregroundMaskImage.Not();
            frameImage = frameImage.Copy(foregroundMaskImage);
            frameImage = frameImage.Or(copyOfNewBackgroundImage);
            this.pictureBox1.Image = frameImage.ToBitmap();
        }
        public void init(PictureBox pictureBox, UserImage userImage)
        {
            this.pictureBox1 = pictureBox;
            this.newBackgroundImage = userImage.getUserImage();

            try
            {
                cameraCapture = new VideoCapture();
                fgDetector = new BackgroundSubtractorMOG2();
                Application.Idle += ProcessFrames;
            }
            catch (Exception es)
            {
                MessageBox.Show(es.Message);
                return;
            }
        }
    }
}
