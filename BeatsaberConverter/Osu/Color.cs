namespace BeatsaberConverter.Osu
{
    internal class Color
    {
        public byte r, g, b;

        public Color(byte r, byte g, byte b)
        {
            this.r = r;
            this.g = g;
            this.b = b;
        }

        public Color(string line)
        {
            line = line.Split(" : ")[1];
            string[] bytes = line.Split(",");
            r = Convert.ToByte(bytes[0]);
            g = Convert.ToByte(bytes[1]);
            b = Convert.ToByte(bytes[2]);
        }
    }
}