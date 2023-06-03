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
                var stereo1 = new StereoToMonoSampleProvider(reader1);
                stereo1.LeftVolume = 0.45f;
                stereo1.RightVolume = 0.45f;
                var stereo2 = new StereoToMonoSampleProvider(reader2);
                stereo2.LeftVolume = 0.35f;
                stereo2.RightVolume = 0.35f;
                var mixer = new MixingSampleProvider(new[] { stereo1, stereo2 });
                WaveFileWriter.CreateWaveFile16(@"E:\Facultate\Editare audio video\mix2.wav", mixer);
            }

        }
        public void mono()
        {
            using (var inputReader = new AudioFileReader(ofd.FileName))
            {
                var mono = new StereoToMonoSampleProvider(inputReader);
                mono.LeftVolume = 0.0f;
                mono.RightVolume = 1.0f;
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
        public void concatenating(OpenFileDialog ofd3)
        {

            var mixerStero = new AudioFileReader(@"E:\Facultate\Editare audio video\mix2.wav");
            var audio = new AudioFileReader(ofd3.FileName);
            var playlist = new ConcatenatingSampleProvider(new[] { mixerStero.ToMono(), audio.ToMono() });
            WaveFileWriter.CreateWaveFile16(@"E:\Facultate\Editare audio video\mixerStero.wav", playlist);

        }
        public void pitchLevel()
        {
            var inPath = @"E:\Facultate\Editare audio video\mixerStero.wav";
            var semitone = Math.Pow(2, 1.0 / 12);
            var upOneTone = semitone * semitone;
            var downOneTone = 1.0 / upOneTone;
            using (var reader = new MediaFoundationReader(inPath))
            {
                var pitch = new SmbPitchShiftingSampleProvider(reader.ToSampleProvider());

                WaveFileWriter.CreateWaveFile16(@"E:\Facultate\Editare audio video\pitch.wav", pitch);

            }
        }
    }
}
