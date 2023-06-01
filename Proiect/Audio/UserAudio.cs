using NAudio.Utils;
using NAudio.Wave;
using NAudio.Wave.SampleProviders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proiect
{
    internal class UserAudio
    {
        private WaveOutEvent outputDevice;
        private AudioFileReader audioFile;
        private OpenFileDialog ofd;

        private void OnPlaybackStopped(object sender, StoppedEventArgs args)
        {
            outputDevice.Dispose();
            outputDevice = null;
            audioFile.Dispose();
            audioFile = null;
        }
        public OpenFileDialog getFileLocation()
        {
            return this.ofd;
        }
        public void loadAudio()
        {
            ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                if (this.outputDevice == null)
                {
                    this.outputDevice = new WaveOutEvent();
                    this.outputDevice.PlaybackStopped += this.OnPlaybackStopped;
                }
                if (this.audioFile == null)
                {
                    this.audioFile = new AudioFileReader(ofd.FileName);
                    this.outputDevice.Init(this.audioFile);
                }
            }

        }
        public void loadAudioExtern(OpenFileDialog ofd)
        {
            if (this.outputDevice == null)
            {
                this.outputDevice = new WaveOutEvent();
                this.outputDevice.PlaybackStopped += this.OnPlaybackStopped;
            }
            if (this.audioFile == null)
            {
                this.audioFile = new AudioFileReader(ofd.FileName);
                this.outputDevice.Init(this.audioFile);
            }
        }
        public void play()
        {
            this.outputDevice.Play();
        }
        public void converWav()
        {
            using (var reader = new Mp3FileReader(audioFile.FileName))
            {
                WaveFileWriter.CreateWaveFile(@"E:\Facultate\Editare audio video\Stuff (mp3cut.net).wav", reader);
            }
        }
        public void converMp3()
        {
            using (var reader = new MediaFoundationReader(@"E:\Facultate\Editare audio video\Stuff (mp3cut.net).wav"))
            {
                WaveFileWriter.CreateWaveFile(@"E:\Facultate\Editare audio video\Stuff.mp3", reader);
            }
        }
        public void mixt(OpenFileDialog ofd1, OpenFileDialog ofd2)
        {
            using (var reader1 = new AudioFileReader(ofd1.FileName))
            using (var reader2 = new AudioFileReader(ofd2.FileName))
            {
                var mixer = new MixingSampleProvider(new[] { reader1, reader2 });
                WaveFileWriter.CreateWaveFile16(@"E:\Facultate\Editare audio video\mix2.wav", mixer);
            }

        }
        public void mono()
        {
            using (var inputReader = new AudioFileReader(ofd.FileName))
            {
                var mono = new StereoToMonoSampleProvider(inputReader);
                mono.LeftVolume = 0.0f; // discard the left channel
                mono.RightVolume = 1.0f; // keep the right channel
                WaveFileWriter.CreateWaveFile16(@"E:\Facultate\Editare audio video\mono.wav", mono);
            }
        }
        public void sterio()
        {
            using (var inputReader = new AudioFileReader(ofd.FileName))
            {
                var stereo = new MonoToStereoSampleProvider(inputReader);
                stereo.LeftVolume = 0.0f; // silence in left channel
                stereo.RightVolume = 1.0f; // full volume in right channel
                WaveFileWriter.CreateWaveFile16(@"E:\Facultate\Editare audio video\sterio.wav", stereo);
            }
        }
        public void concatenating(OpenFileDialog ofd1, OpenFileDialog ofd2, OpenFileDialog ofd3)
        {

            var first = new AudioFileReader(ofd1.FileName);
            var second = new AudioFileReader(ofd2.FileName);
            var third = new AudioFileReader(ofd3.FileName);
            var playlist = new ConcatenatingSampleProvider(new[] { first, second, third });

            WaveFileWriter.CreateWaveFile16(@"E:\Facultate\Editare audio video\playlist.wav", playlist);
        }
        public void pitchLevel(TextBox text1, TextBox text2)
        {
            using (var inputReader = new AudioFileReader(ofd.FileName))
            {
                var stereo = new StereoToMonoSampleProvider(inputReader);
                stereo.LeftVolume = float.Parse(text1.Text);
                stereo.RightVolume = float.Parse(text2.Text);
                WaveFileWriter.CreateWaveFile16(@"E:\Facultate\Editare audio video\pitch.wav", stereo);
            }
        }
    }
}
