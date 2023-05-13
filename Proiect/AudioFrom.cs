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
        int indexImagae = 0;
        int indexLocationY = 40;
        int indexSelected = 0;
        private void AudioFrom_Load(object sender, EventArgs e)
        {
            menuStyle = new MenuStyle();
            this.Controls.Add(menuStyle);
            for (int i = 0; i < 20; i++)
            {
                audioList.Add(new ContentAudio(i));
                audioList[i].Click += getIndex;
            }
        }
        private void getIndex(object sender, EventArgs e)
        {
            indexSelected = ((ContentVideo)sender).id;
        }

        private void loadAudio_Click(object sender, EventArgs e)
        {
            this.Controls.Add(audioList[indexImagae]);
            audioList[indexImagae].positionContent(indexLocationY);
            audioList[indexImagae].loadAudio();
            audioList[indexImagae].displayAudio();
            indexImagae++;
            indexLocationY += 613;
        }
    }
}
