class Running : Activity
{
    private double _distance;

    public Running(string date, int durationMinutes, double distance) : base(date, durationMinutes)
    {
        _distance = distance;
    }

    public override double GetDistance()
    {
        return _distance;
    }

    public override double GetSpeed()
    {
        return _distance / GetDurationMinutes() * 60;
    }

    public override double GetPace()
    {
        return GetDurationMinutes() / _distance;
    }
}