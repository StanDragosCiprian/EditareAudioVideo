using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proiect
{
    internal class ContentVideo : ContentImage
    {
        private UserVideo userVideo = new UserVideo();
        private UserCamera userCamera = new UserCamera();
        public UserVideo GetVideo()
        {
            return this.userVideo;
        }
        public ContentVideo(int id) : base(id)
        {
            this.Size = new Size(638, 538);
            this.id = id;
        }
        public void loadVideo(NumericUpDown numericUpDown,Label label)
        {
            this.userVideo.loadVideo(this, numericUpDown, label);
        }
        public void play()
        {
            this.userVideo.play();
        }
        public void loadCamera() {
            this.userCamera.init(this, this.userImage);
        }
        public void addImageIntoVideo(UserImage userImg)
        {
            this.userVideo.writingVideo(userImg);
        }
    }
}
