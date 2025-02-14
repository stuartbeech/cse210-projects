public class EternalGoal : Goal
{
    public EternalGoal(string shortName, string description, int points) : base(shortName, description, points)
    {
    }

    public override void RecordEvent()
    {
        Console.WriteLine($"Goal '{GetShortName()}' recorded! You earned {GetPoints()} points.");
    }

    public override bool IsComplete()
    {
        return false;
    }

    public override string GetStringRepresentation()
    {
        return $"EternalGoal;{GetShortName()};{GetDescription()};{GetPoints()}";
    }
}
