using BeatsaberConverter.Osu;

namespace BeatsaberConverter
{
    public class Program
    {
        public static void Main(string[] args)
        {


            // test slider point delays
            Beatmap m = new Beatmap(@"..\\..\\..\\slider debug.osu");

            foreach (HitObject hitObject in m.HitObjects)
            {
                if (hitObject.GetType() == typeof(HitSlider))
                    foreach (HitSliderPoint hsp in ((HitSlider)hitObject).HitSliderPoints)
                        Console.WriteLine(hsp.Time);
                else
                    Console.WriteLine(hitObject.Time);
            }
        }
    }
}