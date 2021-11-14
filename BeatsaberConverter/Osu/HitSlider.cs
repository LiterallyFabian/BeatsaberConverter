using System.Globalization;

namespace BeatsaberConverter.Osu
{
    internal class HitSlider : HitObject
    {
        public enum CurveType
        {
            Beizer,
            Catmull,
            Linear,
            Circle
        }

        public CurveType Curve { get; set; }

        public List<SliderCurvePoint> HitSliderPoints { get; set; } = new List<SliderCurvePoint>();

        /// <summary>
        /// Amount of times the player has to follow the slider's curve back-and-forth before the slider is complete. It can also be interpreted as the repeat count plus one.
        /// </summary>
        public int Slides { get; set; }

        /// <summary>
        /// Time when this slide will be hit, in milliseconds from the beginning of the beatmap's audio.
        /// </summary>
        public List<int> SlideTimes { get; set; } = new List<int>();

        /// <summary>
        /// Time in milliseconds that it takes to complete this slider.
        /// </summary>
        public int CompletionTime { get; set; }

        /// <summary>
        /// Visual length in osu! pixels of the slider.
        /// </summary>
        public double Length { get; set; }

        /// <summary>
        /// Hitsounds that play when hitting edges of the slider's curve. The first sound is the one that plays when the slider is first clicked, and the last sound is the one that plays when the slider's end is hit.
        /// </summary>
        public List<int> EdgeSounds { get; set; } = new List<int>();

        public HitSlider(string line, Beatmap beatmap) : base(line)
        {
            string[] split = line.Split(',');
            string[] sliderPoints = split[5].Split('|');

            // set slider curve type
            switch (sliderPoints[0])
            {
                case "B":
                    Curve = CurveType.Beizer;
                    break;

                case "C":
                    Curve = CurveType.Catmull;
                    break;

                case "L":
                    Curve = CurveType.Linear;
                    break;

                case "P":
                    Curve = CurveType.Circle;
                    break;
            }

            // add a new SliderCurvePoint for each in the array after the first one
            for (int i = 1; i < sliderPoints.Length; i++)
            {
                string[] sliderPoint = sliderPoints[i].Split(':');
                HitSliderPoints.Add(new SliderCurvePoint(Convert.ToInt32(sliderPoint[0]), Convert.ToInt32(sliderPoint[1])));
            }

            Slides = Convert.ToInt32(split[6]);
            Length = Convert.ToDouble(split[7], CultureInfo.InvariantCulture);
            if (split.Length > 8)
                EdgeSounds = split[8].Split('|').Select(x => Convert.ToInt32(x)).ToList();

            // set slider completion time
            CompletionTime = Convert.ToInt32(Length / (beatmap.SliderMultiplier * 100) * beatmap.GetClosestTiming(Time).ActualBeatLength * Slides);

            // add the time of each slide to the list
            for (int i = 0; i <= Slides; i++)
                SlideTimes.Add(Time + (CompletionTime / Slides) * i);
        }
    }
}