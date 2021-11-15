namespace BeatsaberConverter.Osu
{
    #region Enums

    public enum SampleSet
    {
        None,
        Normal,
        Soft,
        Drum
    }

    public enum Countdown
    {
        NoCountdown = 0,
        Normal = 1,
        Half = 2,
        Double = 3
    }

    public enum Mode
    {
        Osu = 0,
        Taiko = 1,
        Catch = 2,
        Mania = 3
    }

    public enum OverlayPosition
    {
        NoChange,
        Below,
        Above
    }

    #endregion Enums

    internal class Beatmap
    {
        #region General

        public int FileFormat { get; set; }

        public string AudioFilename { get; set; } = "audio.mp3";
        public string AudioFilepath { get; set; }

        public int AudioLeadIn { get; set; } = 0;

        public int PreviewTime { get; set; } = -1;

        public Countdown Countdown { get; set; } = Countdown.Normal;

        public SampleSet SampleSet { get; set; } = SampleSet.Normal;

        public double StackLeniency { get; set; } = 0.7;

        public Mode Mode { get; set; } = Mode.Osu;

        public bool LetterboxInBreaks { get; set; } = false;

        public bool UseSkinSprites { get; set; } = false;

        public OverlayPosition OverlayPosition { get; set; } = OverlayPosition.NoChange;

        public string SkinPreference { get; set; }

        public bool EpilepsyWarning { get; set; } = false;

        public int CountdownOffset { get; set; } = 0;

        public bool SpecialStyle { get; set; } = false;

        public bool WidescreenStoryboard { get; set; } = false;

        public bool SamplesMatchPlaybackRate { get; set; } = false;

        public string BackgroundPath { get; set; }

        public double BPM { get; set; }

        #endregion General

        #region Editor

        public List<int> Bookmarks { get; set; } = new List<int>();

        public double DistanceSpacing { get; set; }

        public int BeatDivisor { get; set; }

        public int GridSize { get; set; }

        public double TimelineZoom { get; set; }

        #endregion Editor

        #region Metadata

        public string Title { get; set; }

        public string TitleUnicode { get; set; }

        public string Artist { get; set; }

        public string ArtistUnicode { get; set; }

        public string Creator { get; set; }

        public string Version { get; set; }

        public string Source { get; set; }

        public List<string> Tags { get; set; } = new List<string>();

        public int BeatmapID { get; set; }

        public int BeatmapSetID { get; set; }

        #endregion Metadata

        #region Difficulty

        public double HPDrainRate { get; set; }

        public double CircleSize { get; set; }

        public double OverallDifficulty { get; set; }

        public double ApproachRate { get; set; }

        public double SliderMultiplier { get; set; }

        public double SliderTickRate { get; set; }

        #endregion Difficulty

        public List<TimingPoint> TimingPoints { get; set; } = new List<TimingPoint>();

        public List<Color> Colors { get; set; } = new List<Color>();

        public List<HitObject> HitObjects { get; set; } = new List<HitObject>();

        public Beatmap(string path)
        {
            Console.WriteLine($"Parsing \"{path}\"...");
            _ = new Parser(path, this);
            Console.WriteLine($"\"{path}\" successfully parsed!");
        }

        internal TimingPoint GetClosestTiming(int time)
        {
            TimingPoint closest = TimingPoints[0];
            foreach (TimingPoint timing in TimingPoints)
            {
                if (timing.Time > time)
                {
                    break;
                }
                closest = timing;
            }
            return closest;
        }
    }
}