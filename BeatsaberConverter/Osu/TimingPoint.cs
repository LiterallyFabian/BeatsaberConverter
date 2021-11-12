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

        private TimingPoint()
        {
        }

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

        public static TimingPoint Parse(string line)
        {
            TimingPoint timing = new TimingPoint();

            string[] data = line.Split(",");

            if (data.Length < 2) return null;

            timing.Time = Convert.ToInt32(data[0]);
            timing.BeatLength = Convert.ToDouble(data[1]);
            timing.Meter = Convert.ToInt32(data[2]);
            timing.SampleSet = (SampleSet)Convert.ToInt32(data[3]);
            timing.SampleIndex = Convert.ToInt32(data[4]);
            timing.Volume = Convert.ToInt32(data[5]);
            timing.Uninherited = data[6] == "1";
            timing.Kiai = data[7] == "1";

            return timing;
        }
    }
}