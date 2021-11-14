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

        public int _time { get; set; }

        public int _lineIndex { get; set; }

        public int _type
        {
            get
            {
                return (int)type;
            }
        }

        private Type type { get; set; }

        public int _duration { get; set; }

        public int _width { get; set; }
    }
}