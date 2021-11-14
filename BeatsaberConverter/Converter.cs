using BeatsaberConverter.BeatSaber;
using BeatsaberConverter.Osu;

namespace BeatsaberConverter
{
    internal class Converter
    {
        public static void ToBeatSaber(string path)
        {
            ToBeatSaber(new Beatmap(path));
        }

        public static void ToBeatSaber(Beatmap beatmap)
        {
            Console.WriteLine($"Converting osu! beatmap \"{beatmap.Artist} - {beatmap.Title}\" to BeatSaber format...");
            Info info = new Info(beatmap);
        }
    }
}