abstract class Activity
{
    private string _date;

    private int _durationMinutes;

    public Activity(string date, int durationMinutes)
    {
        _date = date;
        _durationMinutes = durationMinutes;
    }

    public string GetDate()
    {
        return _date;
    }

    public int GetDurationMinutes()
    {
        return _durationMinutes;
    }

    public abstract double GetDistance();

    public abstract double GetSpeed();

    public abstract double GetPace();

    public string GetSummary()
    {
        return $"{GetDate()} {GetType().Name} ({GetDurationMinutes()} min): Distance {GetDistance()} km, Speed: {GetSpeed()} kph, Pace: {GetPace()} min per km";
    }
}