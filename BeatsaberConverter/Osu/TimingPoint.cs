using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeatsaberConverter.Osu
{
    internal class TimingPoint
    {
        public int Time { get; set; }

        public double BeatLength { get; set; }

        public int Meter { get; set; }

        public SampleSet SampleSet { get; set; }

        public int SampleIndex { get; set; }

        public int Volume { get; set; }

        public bool Uninherited { get; set; }

        public bool Kiai { get; set; }

        public TimingPoint(int time, double beatLength, int meter, SampleSet sampleSet, int sampleIndex, int volume, bool uninherited, bool kiai)
        {
            Time = time;
            BeatLength = beatLength;
            Meter = meter;
            SampleSet = sampleSet;
            SampleIndex = sampleIndex;
            Volume = volume;
            Uninherited = uninherited;
            Kiai = kiai;
        }
    }
}
