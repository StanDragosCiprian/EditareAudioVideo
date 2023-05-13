using NAudio.Gui;
using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect
{
    internal class ContentAudio:WaveViewer
    {
        private UserAudio userAudio = new UserAudio();
        public int id;
        public void loadAudio()
        {
            this.userAudio.loadAudio();
        }
        public ContentAudio(int id)
        {
            this.Size = new Size(638, 538);
            this.id = id;
        }
        public void displayAudio()
        {
            using (var reader = new AudioFileReader(@"E:\Facultate\Editare audio video\120_F_StringChordReverse_732.wav"))
            {
                var sampleProvider = reader.ToSampleProvider().ToMono();
                int sampleCount = (int)(sampleProvider.WaveFormat.SampleRate * reader.TotalTime.TotalSeconds);
                float[] samples = new float[sampleCount];
                sampleProvider.Read(samples, 0, sampleCount);

                Bitmap bitmap = new Bitmap(this.Width, this.Height);
                int bytesPerPixel = Image.GetPixelFormatSize(bitmap.PixelFormat) / 8;
                BitmapData bitmapData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.WriteOnly, bitmap.PixelFormat);
                int stride = bitmapData.Stride;
                unsafe
                {
                    byte* ptrFirstPixel = (byte*)bitmapData.Scan0;
                    for (int x = 0; x < bitmap.Width; x++)
                    {
                        float sample = samples[(int)((float)x / bitmap.Width * sampleCount)];
                        int y = (int)(sample * (bitmap.Height / 2)) + (bitmap.Height / 2);
                        byte* currentLine = ptrFirstPixel + (y * stride);
                        for (int i = 0; i < bytesPerPixel; i++)
                            currentLine[x * bytesPerPixel] = 255;
                        currentLine[x * bytesPerPixel + 1] = 0;
                        currentLine[x * bytesPerPixel + 2] = 0;
                        currentLine[x * bytesPerPixel + 3] = 255;
                    }
                }
                bitmap.UnlockBits(bitmapData);

                this.BackgroundImage = bitmap;
            }

        }
        public void positionContent(int y)
        {
            this.Location = new Point(200, y);

        }
    }
}
