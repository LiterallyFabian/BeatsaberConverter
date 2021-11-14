namespace BeatsaberConverter.BeatSaber
{
    internal class DifficultyBeatmap
    {
        internal enum Difficulty
        {
            Easy = 1,
            Normal = 3,
            Hard = 5,
            Expert = 7,
            ExpertPlus = 9
        }

        public Difficulty difficulty { get; set; }

        public string _difficulty
        {
            get
            {
                return difficulty.ToString();
            }
        }

        public int _difficultyRank
        {
            get
            {
                return (int)difficulty;
            }
        }

        public string _beatmapFilename { get; set; }

        public int _noteJumpMovementSpeed { get; set; }

        public int _noteJumpStartBeatOffset { get; set; }
    }
}