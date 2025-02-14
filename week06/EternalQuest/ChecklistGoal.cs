public class ChecklistGoal : Goal
{
    private int _amountCompleted;

    private int _target;

    private int _bonus;

    public ChecklistGoal(string shortName, string description, int points, int target, int bonus) : base(shortName, description, points)
    {
        _amountCompleted = 0;
        _target = target;
        _bonus = bonus;
    }

    public int GetAmountCompleted()
    {
        return _amountCompleted;
    }

    public void SetAmountCompleted(int amountCompleted)
    {
        _amountCompleted = amountCompleted;
    }

    public int GetTarget()
    {
        return _target;
    }

    public void SetTarget(int target)
    {
        _target = target;
    }

    public int GetBonus()
    {
        return _bonus;
    }

    public void SetBonus(int bonus)
    {
        _bonus = bonus;
    }

    public override void RecordEvent()
    {
        if (_amountCompleted < _target)
        {
            _amountCompleted++;

            Console.WriteLine($"Goal '{GetShortName()}' completed! You earned {GetPoints()} points.");

            if (_amountCompleted == _target)
            {
                DisplayBonusStars();
            }
        }
        else
        {
            Console.WriteLine($"Goal '{GetShortName()}' has already been completed. You cannot record any more events.");
        }
    }

    public override bool IsComplete()
    {
        return _amountCompleted >= _target;
    }

    public override string GetDetailsString()
    {
        return $"[{(IsComplete() ? "X" : " ")}] {GetShortName()} ({GetDescription()}) -- currently completed: {_amountCompleted}/{_target}";
    }

    public override string GetStringRepresentation()
    {
        return $"ChecklistGoal;{GetShortName()};{GetDescription()};{GetPoints()};{_bonus};{_target};{_amountCompleted}";
    }

    private static void DisplayBonusStars()
    {
        Console.Clear();

        string starAnimation = "*";

        for (int i = 0; i < 5; i++)
        {
            Console.WriteLine(starAnimation);
            Thread.Sleep(500);
            starAnimation += "*";
        }

        for (int i = 5; i > 0; i--)
        {
            starAnimation = starAnimation.Remove(starAnimation.Length - 1);
            Console.WriteLine(starAnimation);
            Thread.Sleep(500);
        }

        Console.WriteLine("Bonus Unlocked! You are a star!\n");
    }
}
