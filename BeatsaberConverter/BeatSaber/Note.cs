namespace BeatsaberConverter.BeatSaber
{
    internal class Note
    {
        public enum Type
        {
            Red = 0,
            Blue = 1,
            Bomb = 3
        }

        public enum CutDirection
        {
            Up = 0,
            Down = 1,
            Left = 2,
            Right = 3,
            UpLeft = 4,
            UpRight = 5,
            DownLeft = 6,
            DownRight = 7,
            Any = 8
        }

        public double _time { get; set; }
        public int _lineIndex { get; set; }
        public int _lineLayer { get; set; }

        public int _type
        {
            get
            {
                return (int)type;
            }
        }

        private Type type { get; set; }

        public int _cutDirection
        {
            get
            {
                return (int)cutDirection;
            }
        }

        private CutDirection cutDirection { get; set; }

        public Note(int time, int lineIndex, int lineLayer, Type type, CutDirection cutDirection)
        {
            this._time = time;
            this._lineIndex = lineIndex;
            this._lineLayer = lineLayer;
            this.type = type;
            this.cutDirection = cutDirection;
        }
    }
}