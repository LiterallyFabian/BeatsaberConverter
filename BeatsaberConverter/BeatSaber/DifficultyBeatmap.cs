namespace BeatsaberConverter.BeatSaber
{
    internal enum Difficulty
    {
        Easy = 1,
        Normal = 3,
        Hard = 5,
        Expert = 7,
        ExpertPlus = 9
    }

    internal class DifficultyBeatmap
    {
        public Difficulty Difficulty { get; set; }

        public string _difficulty
        {
            get
            {
                return Difficulty.ToString();
            }
        }

        public int _difficultyRank
        {
            get
            {
                return (int)Difficulty;
            }
        }

        public string _beatmapFilename { get; set; }

        public int _noteJumpMovementSpeed { get; set; }

        public int _noteJumpStartBeatOffset { get; set; }
    }
}