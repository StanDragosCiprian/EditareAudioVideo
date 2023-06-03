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

        MenuStyle menuStyle;
        int id = 0;
        int indexLocationY = 85;
        int indexSelected = 0;


        public void abruptway()
        {
            int Fourcc = Convert.ToInt32(videoList[0].getVideo().capture.Get(CapProp.FourCC));
            int Width = Convert.ToInt32(videoList[0].getVideo().capture.Get(CapProp.FrameWidth));
            int Height = Convert.ToInt32(videoList[0].getVideo().capture.Get(CapProp.FrameHeight));
            var Fps = videoList[0].getVideo().capture.Get(CapProp.Fps);
            string destinationpath = @"E:\\Facultate\\Editare audio video\\VideoWriten.mp4";
            using (VideoWriter writer = new VideoWriter(destinationpath, Fourcc, Fps, new Size(Width, Height), true))
            {
                videoList.ForEach(allVideo => allVideo.getVideo().readFrame(writer));
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

        private void showMenu(MouseEventArgs e, ContextMenuStrip contextMenuStrip)
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
            cancelROIToolStripMenuItem.Visible = true;
            ((ToolStripMenuItem)sender).Click -= new EventHandler(ROI_Click);
        }
        private void greyScaleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            videoList[indexSelected].getVideo().setGreyScale(videoList[indexSelected]);
        }

        private void combineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            videoList[indexSelected].getVideo().combineVideo(videoList[0].getVideo());
        }

        private void caruselToolStripMenuItem_Click(object sender, EventArgs e)
        {
            videoList[indexSelected].getVideo().carousel();
        }

        private void bToolStripMenuItem_Click(object sender, EventArgs e)
        {

            madeLightVisible(true);
        }
        private void madeLightVisible(bool isVisible)
        {
            button4.Visible = isVisible;
            button5.Visible = isVisible;
            label1.Visible =  isVisible;
            label2.Visible = isVisible;
            GamaValue.Visible = isVisible;
            Alfa.Visible = isVisible;
            Beta.Visible = isVisible;
            gama.Visible = isVisible;
        }
       
        private void button4_Click(object sender, EventArgs e)
        {
            videoList[indexSelected].getVideo().brignesVidep(Alfa, Beta);
            madeLightVisible(false);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            videoList[indexSelected].getVideo().gamaVidep(gama);
            madeLightVisible(false);
        }

        private void redToolStripMenuItem_Click(object sender, EventArgs e)
        {
            videoList[indexSelected].getVideo().extractColor(new Bgr(255, 255, 0));
        }

        private void greenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            videoList[indexSelected].getVideo().extractColor(new Bgr(255, 0, 255));
        }

        private void blueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            videoList[indexSelected].getVideo().extractColor(new Bgr(0, 255, 255));
        }

        private void crossDissolveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            videoList[0].getVideo().crossDissolve(videoList[1].getVideo().getAllVideo());
        }
        private void getIndexAudio(object sender, EventArgs e)
        {
            indexSelected = ((ContentAudio)sender).id;
        }

        private void cancelROIToolStripMenuItem_Click(object sender, EventArgs e)
        {
            videoList[indexSelected].getVideo().cancelRoi();
            cancelROIToolStripMenuItem.Visible = false;
        }
        private void visibleVideoFrame(bool isVisible)
        {
            label3.Visible = isVisible;
            numericUpDown1.Visible = isVisible;
            jumpFrame.Visible = isVisible;
        }
        private void jumpFrameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            visibleVideoFrame(true);
            numericUpDown1.Value = videoList[indexSelected].getVideo().getTotalFrame();
            
        }


        private void jumpFrame_Click_1(object sender, EventArgs e)
        {
            videoList[indexSelected].getVideo().setFrame(((int)numericUpDown1.Value));
            visibleVideoFrame(false);
        }

        private void playBackToolStripMenuItem_Click(object sender, EventArgs e)
        {
            videoList[indexSelected].getVideo().playBackFrame();
        }

        private void writeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            abruptway();
        }
        private void resizeOption(bool isRect)
        {
            labelX.Visible =isRect;
            labelY.Visible = isRect;
            rectX.Visible = isRect;
            rectY.Visible = isRect;
            resizeRoi.Visible = isRect;
            rectX.Text = videoList[indexSelected].getVideo().Rect.X.ToString();
            rectY.Text = videoList[indexSelected].getVideo().Rect.Y.ToString();
        }
        private void resizeRoiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            resizeOption(true);
        }

        private void resizeRoi_Click(object sender, EventArgs e)
        {
            videoList[indexSelected].getVideo().resizeRoi(rectX, rectY);
        }
    }
}
