using NAudio.Gui;
using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;


namespace Proiect
{
    public partial class AudioFrom : Form
    {
        public AudioFrom()
        {
            InitializeComponent();
        }
        List<ContentAudio> audioList = new List<ContentAudio>();
        List<int> audioSelected = new List<int>(3);
        MenuStyle menuStyle;
        int indexLocationY = 40;
        int indexSelected = 0;
        int id = 0;
        private void AudioFrom_Load(object sender, EventArgs e)
        {
            menuStyle = new MenuStyle();
            menuStyle.switchEvent(this);
            menuStyle.makeEvent();
            this.Controls.Add(menuStyle);
            this.KeyPreview = true;
        }
        private void getIndex(object sender, EventArgs e)
        {
            this.indexSelected = ((ContentAudio)sender).id;
            if ((Control.ModifierKeys & Keys.Shift) != 0)
            {
                audioSelected.Add(((ContentAudio)sender).id);
            }
        }


        private void audioEditEvents(object sender, MouseEventArgs e)
        {
            showMenu(e, audioEdit);
            indexSelected = ((ContentAudio)sender).id;
        }

        private void loadAudioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            audioList.Add(new ContentAudio(id));
            audioList[id].Click += getIndex;
            audioList[id].MouseDown += audioEditEvents;
            this.Controls.Add(audioList[id]);
            audioList[id].positionContent(indexLocationY);
            audioList[id].loadAudio();
            audioList[id].displayAudio();
            id++;
            indexLocationY += 613;
        }
        private void showMenu(MouseEventArgs e, ContextMenuStrip contextMenuStrip)
        {
            if (e.Button == MouseButtons.Right)
            {
                Point screenPoint = Cursor.Position;
                contextMenuStrip.Show(screenPoint);
            }
        }
        private void AudioFrom_MouseDown(object sender, MouseEventArgs e)
        {
            showMenu(e, audioLoad);
        }

        private void playToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.audioList[indexSelected].getAudio().play();
        }

        private void convertWavToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.audioList[indexSelected].getAudio().converWav();
        }

        private void convertMp3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.audioList[indexSelected].getAudio().converMp3();
        }

        private void mixtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.audioList[0].getAudio().mixt(this.audioList[0].getAudio().getFileLocation(), this.audioList[indexSelected].getAudio().getFileLocation());
        }

        private void monoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.audioList[indexSelected].getAudio().mono();
        }

        private void sterioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.audioList[indexSelected].getAudio().sterio();
        }

        private void concatingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.audioList[indexSelected].getAudio().concatenating(this.audioList[audioSelected[0]].getAudio().getFileLocation(), this.audioList[audioSelected[1]].getAudio().getFileLocation(), this.audioList[audioSelected[2]].getAudio().getFileLocation());
        }

        private void pitchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Visible = true;
            textBox2.Visible = true;
            button1.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.audioList[indexSelected].getAudio().pitchLevel(textBox1, textBox2);
        }
    }
}
