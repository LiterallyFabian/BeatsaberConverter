using System.Numerics;

namespace BeatsaberConverter.Osu
{
    internal class HitObject
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Vector2 Position
        {
            get { return new Vector2(X, Y); }
            set { X = (int)value.X; Y = (int)value.Y; }
        }

        public int Time { get; set; }

        public int HitSound { get; set; }

        public bool NewCombo { get; set; }

        public HitObject(string line)
        {
            string[] split = line.Split(',');
            X = int.Parse(split[0]);
            Y = int.Parse(split[1]);
            Time = int.Parse(split[2]);
            //NewCombo = split[3] == "1";
            HitSound = int.Parse(split[4]);
        }
    }
}