class Cycling : Activity
{
    private double _speed;

    public Cycling(string date, int durationMinutes, double speed) : base(date, durationMinutes)
    {
        _speed = speed;
    }

    public override double GetDistance()
    {
        return _speed * GetDurationMinutes() / 60;
    }

    public override double GetSpeed()
    {
        return _speed;
    }

    public override double GetPace()
    {
        return 60 / _speed;
    }
}