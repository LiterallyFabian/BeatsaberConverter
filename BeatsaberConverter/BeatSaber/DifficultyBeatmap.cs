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

        public int _noteJumpMovementSpeed { get; set; } = 10;

        public int _noteJumpStartBeatOffset { get; set; } = 0;

        /// <summary>
        /// Tries to convert an osu! difficulty name to beatsaber
        /// Eg. Insane (osu!) -> Expert (BeatSaber).
        /// </summary>
        /// <param name="osuDifficulty">The difficulty name in osu!</param>
        /// <returns></returns>
        public static Difficulty OsuToBeatSaberDiff(string osuDifficulty)
        {
            osuDifficulty = osuDifficulty.ToLower().Trim();

            string[] easy = { "easy", "kantan", "cup" };
            string[] normal = { "normal", "futsuu", "salad" };
            string[] hard = { "hard", "muzukashii", "platter" };
            string[] expert = { "insane", "expert", "oni", "inner", "ura oni", "rain", "overdose" };

            Difficulty closestDiff = Difficulty.ExpertPlus;
            if (easy.Contains(osuDifficulty))
            {
                closestDiff = Difficulty.Easy;
            }
            else if (normal.Contains(osuDifficulty))
            {
                closestDiff = Difficulty.Normal;
            }
            else if (hard.Contains(osuDifficulty))
            {
                closestDiff = Difficulty.Hard;
            }
            else if (expert.Contains(osuDifficulty))
            {
                closestDiff = Difficulty.Expert;
            }

            Console.WriteLine($"Converted osu! difficulty \"{osuDifficulty}\" to BeatSaber difficulty \"{closestDiff}\".");
            return closestDiff;
        }
    }
}