using BeatsaberConverter.BeatSaber;
using BeatsaberConverter.Osu;
using Newtonsoft.Json;

namespace BeatsaberConverter
{
    internal class Converter
    {
        public static Beatmap bm;

        public static void ToBeatSaber(string path)
        {
            ToBeatSaber(new Beatmap(path));
        }

        public static void ToBeatSaber(Beatmap beatmap)
        {
            bm = beatmap;
            Console.WriteLine($"Converting osu! beatmap \"{beatmap.Artist} - {beatmap.Title}\" to BeatSaber format...");
            Info info = new Info(beatmap);

            Difficulty difficulty = new Difficulty(beatmap, JsonConvert.DeserializeObject<Difficulty>(File.ReadAllText("Hard.dat")));

            string dirPath = $"{beatmap.Artist} - {beatmap.Title}";
            Directory.CreateDirectory(dirPath);

            // save diff
            using StreamWriter sw = File.CreateText(Path.Combine(dirPath, info._difficultyBeatmapSets[0]._difficultyBeatmaps[0]._beatmapFilename));
            sw.WriteLine(JsonConvert.SerializeObject(difficulty));

            //save info
            using StreamWriter sw2 = File.CreateText(Path.Combine(dirPath, "Info.dat"));
            sw2.WriteLine(JsonConvert.SerializeObject(info));

            if (!File.Exists(Path.Combine(dirPath, beatmap.AudioFilename)))
                File.Copy(beatmap.AudioFilepath, Path.Combine(dirPath, beatmap.AudioFilename));
        }
    }
}