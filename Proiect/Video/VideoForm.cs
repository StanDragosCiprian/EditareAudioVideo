using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Proiect
{
    public partial class VideoForm : Form
    {
        public VideoForm()
        {
            InitializeComponent();
        }
        List<ContentVideo> videoList = new List<ContentVideo>();
        bool isRoi = false;
        MenuStyle menuStyle;
        int id = 0;
        int indexLocationY = 85;
        int indexSelected = 0;
        UserImage userImage = new UserImage();
       
        public  void abruptway()
        {
            int Fourcc = Convert.ToInt32(videoList[0].getVideo().capture.Get(CapProp.FourCC));
            int Width = Convert.ToInt32(videoList[0].getVideo().capture.Get(CapProp.FrameWidth));
            int Height = Convert.ToInt32(videoList[0].getVideo().capture.Get(CapProp.FrameHeight));
            var Fps = videoList[0].getVideo().capture.Get(CapProp.Fps);
            string destinationpath = @"E:\\Facultate\\Editare audio video\\zzz.mp4";
            using (VideoWriter writer = new VideoWriter(destinationpath, Fourcc, Fps, new Size(Width, Height), true))
            {
                videoList.ForEach(allVideo =>  allVideo.getVideo().readFrame(writer) );
            }
        }
       
        private void getIndex(object sender, EventArgs e)
        {
            indexSelected = ((ContentVideo)sender).id;
        }

     

        private void button8_Click(object sender, EventArgs e)
        {
            videoList[--id].getCamera().loadCamera(videoList[--id], videoList[--id].GetImage());
        }

        private void button7_Click(object sender, EventArgs e)
        {
            videoList[indexSelected].getVideo().play();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            videoList.Add(new ContentVideo(id));
            videoList[id].Click += getIndex;
            this.Controls.Add(videoList[id]);
            videoList[id].positionContentY(indexLocationY);
            videoList[id].loadImage();
            id++;
            indexLocationY += 613;

        }

        private void VideoForm_MouseDown(object sender, MouseEventArgs e)
        {

            showMenu(e, contentLoad);
        }

        private void showMenu(MouseEventArgs e,ContextMenuStrip contextMenuStrip)
        {
            if (e.Button == MouseButtons.Right)
            {
                Point screenPoint = Cursor.Position;
                contextMenuStrip.Show(screenPoint);
            }
        }
        private void contentLoad_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

            switch (e.ClickedItem.Text)
            {
                case "Load Video":
                    loadVideo();
                break;
                case "Load Image":
                    loadImage();    
                break;
                case "Load Camera":
                    videoList[--id].getCamera().loadCamera(videoList[--id], videoList[--id].GetImage());
                    break;

            } 
            
        }
        private void loadVideo()
        {
            newContent(id);
            videoList[id].positionContentY(indexLocationY);
            videoList[id].getVideo().loadVideo(videoList[id]);
            id++;
            indexLocationY += 613;
        }
        private void loadImage()
        {
            newContent(id);
            videoList[id].positionContentY(indexLocationY);
            videoList[id].loadImage();
            id++;
            indexLocationY += 613;
        }
        private void newContent(int id)
        {
            videoList.Add(new ContentVideo(id));
            videoList[id].Click += getIndex;
            videoList[id].MouseDown += videoEditEvents;
            videoList[id].PreviewKeyDown += previewKeyDown;
            this.Controls.Add(videoList[id]);
        }
        private void previewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            
            switch (e.KeyCode)
            {
         
                case Keys.Left:
                    //if (videoList[indexSelected].getVideo().isPlaying())
                    //{
                    //    videoList[indexSelected].getVideo().playForward();
                    //}
                    MessageBox.Show("mere");
                    break;
                case Keys.Right:
 
                    break;
            }
        }
        private void videoEditEvents(object sender, MouseEventArgs e)
        {
            showMenu(e, videoEdit);
            indexSelected = ((ContentVideo)sender).id;
        }

        private void videoEdit_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            MessageBox.Show(e.ClickedItem.Text);
        }

        private void playToolStripMenuItem_Click(object sender, EventArgs e)
        {
            videoList[indexSelected].getVideo().play();
        }

        private void stopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            videoList[indexSelected].getVideo().stop();
        }



        private void VideoForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch (e.KeyChar)
            {
                case 'z':
                    videoList[indexSelected].getVideo().playBack();
                    break;
                case 'Z':
                    videoList[indexSelected].getVideo().playBack();
                   
                    break;
                case 'x':
                    
                        videoList[indexSelected].getVideo().playForward();
                   // videoList[indexSelected].displayRoi(videoList[indexSelected], videoList[indexSelected].getVideo().getMat().ToImage<Bgr, byte>());
              
                    break;
                case 'X':
                        videoList[indexSelected].getVideo().playForward();
                    break;
            }
        }

        private void VideoForm_Load(object sender, EventArgs e)
        {
            menuStyle = new MenuStyle();
            menuStyle.switchEvent(this);
            menuStyle.makeEvent();
            this.Controls.Add(menuStyle);
            this.KeyPreview = true;
        }

        private void ROI_Click(object sender, EventArgs e)
        {

            videoList[indexSelected].initMouseEvents();
            
            ((ToolStripMenuItem)sender).Click -= new EventHandler(ROI_Click);

        }
            

            private void greyScaleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            videoList[indexSelected].getVideo().setGreyScale(videoList[indexSelected]);
        }

        private void combineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            abruptway();
        }
    }
}
