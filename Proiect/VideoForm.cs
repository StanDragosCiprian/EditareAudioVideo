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
    public partial class VideoForm : Form
    {
        public VideoForm()
        {
            InitializeComponent();
        }
        List<ContentVideo> videoList = new List<ContentVideo>(20);
        MenuStyle menuStyle;
        int indexImagae = 0;
        int indexLocationY = 40;
        int indexSelected = 0;
        UserImage userImage = new UserImage();
        private void VideoForm_Load(object sender, EventArgs e)
        {
            menuStyle = new MenuStyle();
            this.Controls.Add(menuStyle);

            for (int i = 0; i < 20; i++)
            {
                videoList.Add(new ContentVideo(i));
                videoList[i].Click += getIndex;
            }
        }
        private void button6_Click(object sender, EventArgs e)
        {
            this.Controls.Add(videoList[indexImagae]);
            videoList[indexImagae].positionContent(indexLocationY);
            videoList[indexImagae].loadVideo(numericUpDown1, label3);
            indexImagae++;
            indexLocationY += 613;
        }
        private void button12_Click(object sender, EventArgs e)
        {

        }
        private void getIndex(object sender, EventArgs e)
        {
            indexSelected = ((ContentVideo)sender).id;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            videoList[0].addImageIntoVideo(videoList[--indexImagae].GetImage());
        }

        private void button8_Click(object sender, EventArgs e)
        {
            videoList[--indexImagae].loadCamera();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            videoList[indexSelected].play();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Controls.Add(videoList[indexImagae]);
            videoList[indexImagae].positionContent(indexLocationY);
            videoList[indexImagae].loadImage();
            indexImagae++;
            indexLocationY += 613;

        }
    }
}
