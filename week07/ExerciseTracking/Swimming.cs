class Swimming : Activity
{
    private int _laps;

    public Swimming(string date, int durationMinutes, int laps) : base(date, durationMinutes)
    {
        _laps = laps;
    }

    public override double GetDistance()
    {
        double distanceInKm = _laps * 50.0 / 1000;
        return distanceInKm;
    }

    public override double GetSpeed()
    {
        return GetDistance() / GetDurationMinutes() * 60;
    }

    public override double GetPace()
    {
        return GetDurationMinutes() / GetDistance();
    }
}