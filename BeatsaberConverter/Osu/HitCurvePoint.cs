using System.Numerics;

namespace BeatsaberConverter.Osu
{
    internal class HitCurvePoint
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Vector2 Position
        {
            get { return new Vector2(X, Y); }
            set { X = (int)value.X; Y = (int)value.Y; }
        }

        public HitCurvePoint(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}