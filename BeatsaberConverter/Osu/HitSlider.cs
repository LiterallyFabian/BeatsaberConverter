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
    }
}