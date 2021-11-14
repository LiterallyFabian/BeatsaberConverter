namespace BeatsaberConverter.BeatSaber
{
    internal class DifficultyBeatmapSet
    {
        public string _beatmapCharacteristicName { get; set; } = "Standard";

        public List<DifficultyBeatmap> _difficultyBeatmaps { get; set; } = new List<DifficultyBeatmap>();
    }
}