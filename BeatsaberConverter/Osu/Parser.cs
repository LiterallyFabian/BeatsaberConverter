using System.Text.RegularExpressions;

namespace BeatsaberConverter.Osu
{
    internal enum Section
    {
        None,
        General,
        Editor,
        Metadata,
        Difficulty,
        Events,
        TimingPoints,
        Colours,
        HitObjects
    }

    internal class Parser
    {
        private Beatmap _beatmap;
        private string _beatmapPath;
        private Section _section = Section.None;

        internal Parser(string path, Beatmap beatmap)
        {
            _beatmap = beatmap;
            _beatmapPath = path;
            Parse();
        }

        private void Parse()
        {
            foreach (string line in File.ReadLines(_beatmapPath))
            {
                // not the most beautiful way to set section but hey, why not.
                if (Regex.IsMatch(line, @"\[.+\]"))
                    _section = (Section)Enum.Parse(typeof(Section), line.Replace("[", "").Replace("]", ""));

                switch (_section)
                {
                    case Section.None:
                        if (line.Contains("osu file format"))
                            _beatmap.FileFormat = Convert.ToInt32(line.Replace("osu file format v", ""));
                        break;

                    #region General

                    case Section.General:
                        if (line.Contains("AudioFilename"))
                            _beatmap.AudioFilename = GetString(line);
                        else if (line.Contains("AudioLeadIn:"))
                            _beatmap.AudioLeadIn = GetInt(line);
                        else if (line.Contains("PreviewTime:"))
                            _beatmap.PreviewTime = GetInt(line);
                        else if (line.Contains("Countdown:"))
                            _beatmap.Countdown = (Countdown)Enum.Parse(typeof(Countdown), line);
                        else if (line.Contains("SampleSet:"))
                            _beatmap.SampleSet = (SampleSet)Enum.Parse(typeof(SampleSet), line);
                        else if (line.Contains("StackLeniency:"))
                            _beatmap.StackLeniency = GetDouble(line);
                        else if (line.Contains("Mode:"))
                            _beatmap.Mode = (Mode)Enum.Parse(typeof(Mode), line);
                        else if (line.Contains("LetterboxInBreaks:"))
                            _beatmap.LetterboxInBreaks = GetBool(line);
                        else if (line.Contains("UseSkinSprites:"))
                            _beatmap.UseSkinSprites = GetBool(line);
                        else if (line.Contains("OverlayPosition:"))
                            _beatmap.OverlayPosition = (OverlayPosition)Enum.Parse(typeof(OverlayPosition), line);
                        else if (line.Contains("SkinPreference:"))
                            _beatmap.SkinPreference = GetString(line);
                        else if (line.Contains("EpilepsyWarning:"))
                            _beatmap.EpilepsyWarning = GetBool(line);
                        else if (line.Contains("CountdownOffset:"))
                            _beatmap.CountdownOffset = GetInt(line);
                        else if (line.Contains("SpecialStyle:"))
                            _beatmap.SpecialStyle = GetBool(line);
                        else if (line.Contains("WidescreenStoryboard:"))
                            _beatmap.WidescreenStoryboard = GetBool(line);
                        else if (line.Contains("SamplesMatchPlaybackRate:"))
                            _beatmap.SamplesMatchPlaybackRate = GetBool(line);

                        break;

                    #endregion General

                    #region Editor

                    case Section.Editor:
                        if (line.Contains("Bookmarks:"))
                            _beatmap.Bookmarks = GetInts(line);
                        else if (line.Contains("DistanceSpacing:"))
                            _beatmap.DistanceSpacing = GetDouble(line);
                        else if (line.Contains("BeatDivisor:"))
                            _beatmap.BeatDivisor = GetInt(line);
                        else if (line.Contains("GridSize:"))
                            _beatmap.GridSize = GetInt(line);
                        else if (line.Contains("TimelineZoom:"))
                            _beatmap.TimelineZoom = GetDouble(line);
                        break;

                    #endregion Editor

                    #region Metadata

                    case Section.Metadata:
                        if (line.Contains("Title:"))
                            _beatmap.Title = GetString(line);
                        else if (line.Contains("TitleUnicode:"))
                            _beatmap.TitleUnicode = GetString(line);
                        else if (line.Contains("Artist:"))
                            _beatmap.Artist = GetString(line);
                        else if (line.Contains("ArtistUnicode:"))
                            _beatmap.ArtistUnicode = GetString(line);
                        else if (line.Contains("Creator:"))
                            _beatmap.Creator = GetString(line);
                        else if (line.Contains("Version:"))
                            _beatmap.Version = GetString(line);
                        else if (line.Contains("Source:"))
                            _beatmap.Source = GetString(line);
                        else if (line.Contains("Tags:"))
                            _beatmap.Tags = GetStrings(line);
                        else if (line.Contains("BeatmapID:"))
                            _beatmap.BeatmapID = GetInt(line);
                        else if (line.Contains("BeatmapSetID:"))
                            _beatmap.BeatmapSetID = GetInt(line);
                        break;

                    #endregion Metadata

                    #region Difficulty

                    case Section.Difficulty:
                        if (line.Contains("HPDrainRate:"))
                            _beatmap.HPDrainRate = GetDouble(line);
                        else if (line.Contains("CircleSize:"))
                            _beatmap.CircleSize = GetDouble(line);
                        else if (line.Contains("OverallDifficulty:"))
                            _beatmap.OverallDifficulty = GetDouble(line);
                        else if (line.Contains("ApproachRate:"))
                            _beatmap.ApproachRate = GetDouble(line);
                        else if (line.Contains("SliderMultiplier:"))
                            _beatmap.SliderMultiplier = GetDouble(line);
                        else if (line.Contains("SliderTickRate:"))
                            _beatmap.SliderTickRate = GetDouble(line);

                        break;

                    #endregion Difficulty

                    #region Events

                    case Section.Events:

                        break;

                    #endregion Events

                    #region TimingPoints

                    case Section.TimingPoints:
                        _beatmap.TimingPoints.Add(new TimingPoint(line));
                        break;

                    #endregion TimingPoints

                    #region Colours

                    case Section.Colours:
                        if (line.Contains("Combo"))
                            _beatmap.Colors.Add(new Color(line));
                        break;

                    #endregion Colours

                    #region HitObjects

                    case Section.HitObjects:

                        break;

                        #endregion HitObjects
                }
            }
        }

        #region Parsers

        public static int GetInt(string line)
        {
            return Convert.ToInt32(line.Split(": ")[1].Trim());
        }

        public static double GetDouble(string line)
        {
            return Convert.ToDouble(line.Split(": ")[1].Trim());
        }

        public static string GetString(string line)
        {
            int index = line.IndexOf(":");
            if (index == -1)
                return line;
            return line.Substring(line.IndexOf(":") + 1).Trim();
        }

        public static bool GetBool(string line)
        {
            return line.Contains('1'); // *should* work
        }

        public static List<int> GetInts(string line)
        {
            List<int> ints = new List<int>();
            foreach (string s in line.Split(':')[1].Split(','))
                ints.Add(Convert.ToInt32(s.Trim()));
            return ints;
        }

        public static List<string> GetStrings(string line)
        {
            return line.Split(": ")[1].Split(',').ToList();
        }

        #endregion Parsers
    }
}