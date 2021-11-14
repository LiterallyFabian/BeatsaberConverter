namespace BeatsaberConverter.BeatSaber
{
    internal class Info
    {
        /// <summary>
        /// The version of the map format we are using. Currently, Beat Saber's map format is on version 2.0.0.
        /// </summary>
        public string _version { get; set; } = "2.0.0";

        /// <summary>
        /// This field describes the name of your song.
        /// </summary>
        public string _songName { get; set; }

        /// <summary>
        /// This field describes any additional titles that could go into your song.
        /// </summary>
        public string? _songSubName { get; set; }

        /// <summary>
        /// This field describes the main artist, group, band, brand, etc. for the song.
        /// </summary>
        public string _songAuthorName { get; set; }

        /// <summary>
        /// This field describes the person who created the map.
        /// </summary>
        public string _levelAuthorName { get; set; }

        /// <summary>
        /// This describes the Beats Per Minute (BPM) of your song.
        /// </summary>
        public double _beatsPerMinute { get; set; }

        /// <summary>
        /// See <see href="https://bsmg.wiki/mapping/map-format.html#shuffle">BSMG Wiki#shuffle</see>
        /// </summary>
        public int _shuffle { get; set; }

        /// <summary>
        /// See <see href="https://bsmg.wiki/mapping/map-format.html#shuffleperiod">BSMG Wiki#shufflePeriod</see>
        /// </summary>
        public double _shufflePeriod { get; set; }

        /// <summary>
        /// This controls the start time (in seconds) for the in-game preview of your map.
        /// </summary>
        public double _previewStartTime { get; set; }

        /// <summary>
        /// This controls the duration (in seconds) of the in-game preview of your map.
        /// </summary>
        public double _previewDuration { get; set; }

        /// <summary>
        /// This is the local location to your map's audio file.
        /// </summary>
        public string _songFilename { get; set; }

        /// <summary>
        /// This is the local location to your map's cover image.
        /// </summary>
        public string _coverImageFilename { get; set; }

        /// <summary>
        /// This defines the internal ID for the environment that the map uses.
        /// </summary>
        public string _environmentName { get; set; }

        /// <summary>
        /// This defines the internal ID for the environment that the map uses when playing in 360 Degree or 90 Degree levels.
        /// </summary>
        public string _allDirectionsEnvironmentName { get; set; }

        /// <summary>
        /// This describes the offset (in seconds) of the audio in game.
        /// </summary>
        public double _songTimeOffset { get; set; }

        /// <summary>
        /// This is an array of all <see href="https://bsmg.wiki/mapping/map-format.html#difficulty-beatmap-sets">Difficulty Beatmap Sets</see> defined in the map.
        /// </summary>
        public List<DifficultyBeatmapSet> _difficultyBeatmapSets { get; set; } = new List<DifficultyBeatmapSet>();

        public Info(Osu.Beatmap beatmap)
        {
            _songName = beatmap.Title;
            _songAuthorName = beatmap.Artist;
            _levelAuthorName = beatmap.Creator;
            _beatsPerMinute = (1 / beatmap.TimingPoints[0].BeatLength * 1000 * 60);

            // i'm not completely sure what these do, but they're required for the map to load properly
            // it's hopefully fine to leave them as is
            _shuffle = 0;
            _shufflePeriod = 0;

            _previewStartTime = beatmap.PreviewTime;
            _previewDuration = beatmap.HitObjects[beatmap.HitObjects.Count - 1].Time - beatmap.PreviewTime;
            _songFilename = beatmap.AudioFilename;
            _coverImageFilename = beatmap.BackgroundPath;
            _environmentName = "DefaultEnvironment";
            _allDirectionsEnvironmentName = "DefaultEnvironment";
            _songTimeOffset = 0;

            _difficultyBeatmapSets.Add(new DifficultyBeatmapSet());
            _difficultyBeatmapSets[0]._difficultyBeatmaps.Add(new DifficultyBeatmap(beatmap));
        }
    }
}