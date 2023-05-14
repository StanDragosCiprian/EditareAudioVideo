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
            //for (int i = 0; i < 20; i++)
            //{
            //    audioList.Add(new ContentAudio(i));
            //    audioList[i].Click += getIndex;
            //}
        }
        private void getIndex(object sender, EventArgs e)
        {
            indexSelected = ((ContentVideo)sender).id;
        }

        private void loadAudio_Click(object sender, EventArgs e)
        {
            audioList.Add(new ContentAudio(id));
            audioList[id].Click += getIndex;
            this.Controls.Add(audioList[id]);
            audioList[id].positionContent(indexLocationY);
            audioList[id].loadAudio();
            audioList[id].displayAudio();
            id++;
            indexLocationY += 613;
        }
    }
}
