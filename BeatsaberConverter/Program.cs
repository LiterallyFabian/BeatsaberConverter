using BeatsaberConverter.Osu;

namespace BeatsaberConverter
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // test slider point delays
            Beatmap m = new Beatmap(@"..\\..\\..\\Itou Kanako - Kanashimi no Mukou he (FireballFlame) [Hard].osu");

            Converter.ToBeatSaber(m);
        }
    }
}