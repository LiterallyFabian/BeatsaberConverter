namespace BeatsaberConverter.BeatSaber
{
    /// <summary>
    /// See <see href="https://bsmg.wiki/mapping/map-format.html#events-2">Events</see>
    /// </summary>
    internal class Event
    {
        public int _time { get; set; }

        public int _type { get; set; }

        public int _value { get; set; }
    }
}