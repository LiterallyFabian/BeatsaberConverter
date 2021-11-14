namespace BeatsaberConverter.BeatSaber
{
    internal class Difficulty
    {
        public string _version { get; set; } = "2.0.0";
        public Note[] _notes { get; set; } = Array.Empty<Note>();
        public Obstacle[] _obstacles { get; set; } = Array.Empty<Obstacle>();

        public Event[] _events { get; set; } = Array.Empty<Event>();
    }
}