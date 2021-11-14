using BeatsaberConverter.Osu;

namespace BeatsaberConverter
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // test slider point delays
            Beatmap m = new Beatmap(@"..\\..\\..\\slider debug.osu");

            Converter.ToBeatSaber(m);
        }
    }
}