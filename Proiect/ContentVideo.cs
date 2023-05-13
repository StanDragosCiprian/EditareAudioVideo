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
        public UserVideo getVideo()
        {
            return this.userVideo;
        }
        public UserCamera getCamera()
        {
            return this.userCamera;
        }
        public ContentVideo(int id) : base(id)
        {
            this.Size = new Size(638, 538);
            this.id = id;
        }
    
    }
}
