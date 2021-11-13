using BeatsaberConverter.Osu;

namespace BeatsaberConverter
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Beatmap m = new Beatmap(@"X:\Games\osu!\osu!\Songs\23585 Itou Kanako - Kanashimi no Mukou he\Itou Kanako - Kanashimi no Mukou he (FireballFlame) [Hard].osu");
            Console.WriteLine(m.HitObjects.Count);

        }
    }
}