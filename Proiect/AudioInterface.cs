using NAudio.Gui;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect
{
    internal interface AudioInterface
    {
        WaveViewer waveViewer { get; }
        UserAudio UserAudio { get; }
    }
}
