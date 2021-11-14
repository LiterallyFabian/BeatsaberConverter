using BeatsaberConverter.Osu;

namespace BeatsaberConverter
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // test slider point delays
            Beatmap m = new Beatmap(@"..\\..\\..\\slider debug.osu");
            int previousTime = 0;
            foreach (HitObject hitObject in m.HitObjects)
            {
                if (hitObject.GetType() == typeof(HitSlider))
                    Console.WriteLine(((HitSlider)hitObject).CompletionTime);
                else
                {
                    // Console.WriteLine("O" + (hitObject.Time - previousTime));
                    previousTime = hitObject.Time;
                }
            }
        }
    }
}