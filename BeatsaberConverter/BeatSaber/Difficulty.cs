using BeatsaberConverter.Osu;

namespace BeatsaberConverter.BeatSaber
{
    internal class Difficulty
    {
        public string _version { get; set; } = "2.0.0";

        public List<Note> _notes { get; set; } = new List<Note>();

        public List<Obstacle> _obstacles { get; set; } = new List<Obstacle>();

        public List<Event> _events { get; set; } = new List<Event>();

        public Difficulty()
        { }

        public Difficulty(Beatmap beatmap, Difficulty bsDiff)
        {
            int j = 0;
            for (int i = 0; i < beatmap.HitObjects.Count; i++)
            {
                var hitObject = beatmap.HitObjects[i];
                Note note = bsDiff._notes[j++];
                //note._cutDirection = (Note.CutDirection)bsDiff._notes[i]._cutDirection
                note._time = hitObject.Time / (1000.0 * (60 / beatmap.BPM));

                _notes.Add(note);

                // add new note for slider points
                if (hitObject.GetType() == typeof(HitSlider))
                {
                    foreach (int time in ((HitSlider)hitObject).SlideTimes)
                    {
                        Note sliderNote = bsDiff._notes[j++];
                        sliderNote._time = time / (1000.0 * (60 / beatmap.BPM));
                        _notes.Add(sliderNote);
                        Console.WriteLine(j);
                    }
                }
            }
        }
    }
}