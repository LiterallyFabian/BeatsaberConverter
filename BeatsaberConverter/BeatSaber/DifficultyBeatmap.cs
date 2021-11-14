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

        public DifficultyBeatmap(Osu.Beatmap beatmap)
        {
            // clean version of the osu! difficulty name
            _beatmapFilename = new string(beatmap.Version.Where(m => !Path.GetInvalidFileNameChars().Contains(m)).ToArray()) + ".dat";
            difficulty = OsuToBeatSaberDiff(beatmap.Version);
        }

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
            // check if any of the strings include the osuDifficulty
            if (easy.Any(m => osuDifficulty.Contains(m)))
                closestDiff = Difficulty.Easy;
            else if (normal.Any(m => osuDifficulty.Contains(m)))
                closestDiff = Difficulty.Normal;
            else if (hard.Any(m => osuDifficulty.Contains(m)))
                closestDiff = Difficulty.Hard;
            else if (expert.Any(m => osuDifficulty.Contains(m)))
                closestDiff = Difficulty.Expert;

            Console.WriteLine($"Converted osu! difficulty \"{osuDifficulty}\" to BeatSaber difficulty \"{closestDiff}\".");
            return closestDiff;
        }
    }
}