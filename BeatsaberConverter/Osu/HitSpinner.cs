namespace BeatsaberConverter.Osu
{
    internal class HitSpinner : HitObject
    {
        public int EndTime { get; set; }

        public HitSpinner(string line) : base(line)
        {
            string[] split = line.Split(',');
            EndTime = int.Parse(split[5]);
        }
    }
}