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

        public List<HitSliderPoint> HitSliderPoints { get; set; } = new List<HitSliderPoint>();

        public int Slides { get; set; }

        public double Length { get; set; }

        public List<int> EdgeSounds { get; set; } = new List<int>();

        public HitSlider(string line) : base(line)
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

            // add a new HitSliderPoint for each in the array after the first one
            for (int i = 1; i < sliderPoints.Length; i++)
            {
                string[] sliderPoint = sliderPoints[i].Split(':');
                HitSliderPoints.Add(new HitSliderPoint(Convert.ToInt32(sliderPoint[0]), Convert.ToInt32(sliderPoint[1])));
            }

            Slides = Convert.ToInt32(split[6]);
            Length = Convert.ToDouble(split[7], CultureInfo.InvariantCulture);
            if (split.Length > 8)
                EdgeSounds = split[8].Split('|').Select(x => Convert.ToInt32(x)).ToList();
        }
    }
}