namespace BeatsaberConverter.Osu
{
    internal interface IParseable<T>
    {
        T Parse(string line);
    }
}