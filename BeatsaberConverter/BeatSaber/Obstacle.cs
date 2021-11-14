namespace BeatsaberConverter.BeatSaber
{
    internal class Obstacle
    {
        /// <summary>
        /// The state of the obstacle.
        /// </summary>
        public enum Type
        {
            Full = 0,
            Crouch = 1
        }

        public double _time { get; set; }

        public int _lineIndex { get; set; }

        public int _type
        {
            get
            {
                return (int)type;
            }
        }

        private Type type { get; set; }

        public double _duration { get; set; }

        public int _width { get; set; }
    }
}