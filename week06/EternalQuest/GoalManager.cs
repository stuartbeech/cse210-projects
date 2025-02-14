public class GoalManager
{
    private List<Goal> _goals;
    private int _score;

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
    }

    public int GetScore()
    {
        return _score;
    }

    public void SetScore(int score)
    {
        _score = score;
    }

    public enum GoalType
    {
        SimpleGoal = 1,
        EternalGoal = 2,
        ChecklistGoal = 3
    }

    public void Start()
    {
        bool quit = false;

        while (!quit)
        {
            DisplayPlayerInfo();
            DisplayMenu();

            string choice = Console.ReadLine();

            switch (choice)
            {
                case MenuOptions.CreateGoal:
                    CreateGoal();
                    break;
                case MenuOptions.ListGoals:
                    ListGoalDetails();
                    break;
                case MenuOptions.SaveGoals:
                    SaveGoals();
                    break;
                case MenuOptions.LoadGoals:
                    LoadGoals();
                    break;
                case MenuOptions.RecordEvent:
                    RecordEvent();
                    break;
                case MenuOptions.Quit:
                    Console.WriteLine("Thank you for playing the Eternal Quest.");
                    quit = true;
                    break;
                default:
                    Console.WriteLine("Invalid choice, please try again.");
                    break;
            }
        }
    }

    public void DisplayPlayerInfo()
    {
        Console.WriteLine($"\nYou have {_score} points.\n");
    }

    public static void DisplayMenu()
    {
        Console.WriteLine("Menu options:");
        Console.WriteLine("1. Create new goal");
        Console.WriteLine("2. List Goals");
        Console.WriteLine("3. Save Goals");
        Console.WriteLine("4. Load Goals");
        Console.WriteLine("5. Record Event");
        Console.WriteLine("6. Quit");
        Console.Write("\nSelect a choice from the menu: ");
    }

    public void ListGoalNames()
    {
        Console.WriteLine("\nThe goals are:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Goal goal = _goals[i];
            Console.WriteLine($"{i + 1}. {goal.GetShortName()}");
        }
    }

    public void ListGoalDetails()
    {
        if (_goals.Count > 0)
        {
            Console.WriteLine("\nThe goals are:");
            for (int i = 0; i < _goals.Count; i++)
            {
                Goal goal = _goals[i];
                Console.WriteLine($"{i + 1}. {goal.GetDetailsString()}");
            }
        }
        else
        {
            Console.WriteLine("\nThere are no goals saved.");
        }
    }

    public void CreateGoal()
    {
        Console.WriteLine("\nThe types of goals are: ");
        Console.WriteLine($"{(int)GoalType.SimpleGoal}. Simple Goal");
        Console.WriteLine($"{(int)GoalType.EternalGoal}. Eternal Goal");
        Console.WriteLine($"{(int)GoalType.ChecklistGoal}. Checklist Goal");

        Console.Write("\nWhich type of goal would you like to create? ");
        string userGoalType = Console.ReadLine();

        if (Enum.TryParse(userGoalType, true, out GoalType goalType) && Enum.IsDefined(typeof(GoalType), goalType))
        {
            Console.Write("What is the name of your goal? ");
            string shortName = Console.ReadLine();

            Console.Write("What is a short description of it? ");
            string description = Console.ReadLine();

            Console.Write("What is the amount of points associated with this goal? ");
            int points = int.Parse(Console.ReadLine());

            Goal newGoal = null;
            switch (goalType)
            {
                case GoalType.SimpleGoal:

                    newGoal = new SimpleGoal(shortName, description, points);
                    break;

                case GoalType.EternalGoal:
                    newGoal = new EternalGoal(shortName, description, points);
                    break;

                case GoalType.ChecklistGoal:
                    Console.Write("How many times does this goal need to be accomplished for a bonus? ");
                    int target = int.Parse(Console.ReadLine());

                    Console.Write("What is the bonus for accomplishing it that many times? ");
                    int bonus = int.Parse(Console.ReadLine());

                    newGoal = new ChecklistGoal(shortName, description, points, target, bonus);
                    break;

                default:
                    break;
            }

            if (newGoal != null)
            {
                _goals.Add(newGoal);
                Console.WriteLine("\nGoal created successfully!");
            }
        }
        else
        {
            Console.WriteLine("\nInvalid goal type. Please try again.");
        }
    }

    public void RecordEvent()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("\nYou have no goals to record events for.");
            return;
        }

        ListGoalNames();

        Console.Write("\nWhich goal did you accomplish? ");
        int goalIndex = int.Parse(Console.ReadLine()) - 1;

        if (goalIndex >= 0 && goalIndex < _goals.Count)
        {
            Goal goal = _goals[goalIndex];
            goal.RecordEvent();

            if (goal is ChecklistGoal checklistGoal && checklistGoal.IsComplete())
            {
                _score += checklistGoal.GetBonus();
                Console.WriteLine($"Congratulations! You earned an additional {checklistGoal.GetBonus()} bonus points.");
            }

            _score += goal.GetPoints();
            Console.WriteLine($"You now have {_score} points.");
        }
        else
        {
            Console.WriteLine("Invalid goal number.");
        }
    }

    public void SaveGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string fileName = Console.ReadLine();

        try
        {
            using (StreamWriter writer = new StreamWriter(fileName))
            {
                writer.WriteLine(_score);

                foreach (Goal goal in _goals)
                {
                    writer.WriteLine(goal.GetStringRepresentation());
                }
            }

            Console.WriteLine("\nGoals saved to file.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while saving goals to file: {ex.Message}");
        }
    }

    public void LoadGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string fileName = Console.ReadLine();

        if (File.Exists(fileName))
        {
            using (StreamReader reader = new StreamReader(fileName))
            {
                string firstLine = reader.ReadLine();

                if (int.TryParse(firstLine.Trim(), out int score))
                {
                    _score = score;
                }
                else
                {
                    Console.WriteLine("Invalid score format in file.");
                }

                string line;

                while ((line = reader.ReadLine()) != null)
                {
                    string[] goalData = line.Split(';');
                    if (goalData.Length == 0) continue;

                    string goalType = goalData[0].Trim();

                    switch (goalType)
                    {
                        case "SimpleGoal":
                            if (goalData.Length == 5)
                            {
                                string shortName = goalData[1].Trim();
                                string description = goalData[2].Trim();
                                int points = int.Parse(goalData[3].Trim());
                                bool isComplete = bool.Parse(goalData[4].Trim());

                                SimpleGoal simpleGoal = new SimpleGoal(shortName, description, points);
                                simpleGoal.SetIsComplete(isComplete);

                                _goals.Add(simpleGoal);
                            }
                            else
                            {
                                Console.WriteLine("Invalid SimpleGoal format, skipping this line.");
                            }
                            break;

                        case "EternalGoal":
                            if (goalData.Length == 4)
                            {
                                string shortName = goalData[1].Trim();
                                string description = goalData[2].Trim();
                                int points = int.Parse(goalData[3].Trim());

                                _goals.Add(new EternalGoal(shortName, description, points));
                            }
                            else
                            {
                                Console.WriteLine("Invalid EternalGoal format, skipping this line.");
                            }
                            break;

                        case "ChecklistGoal":
                            if (goalData.Length == 7)
                            {
                                string shortName = goalData[1].Trim();
                                string description = goalData[2].Trim();
                                int points = int.Parse(goalData[3].Trim());
                                int bonus = int.Parse(goalData[4].Trim());
                                int target = int.Parse(goalData[5].Trim());
                                int amountCompleted = int.Parse(goalData[6].Trim());

                                ChecklistGoal checklistGoal = new ChecklistGoal(shortName, description, points, target, bonus);
                                checklistGoal.SetAmountCompleted(amountCompleted);

                                _goals.Add(checklistGoal);
                            }
                            else
                            {
                                Console.WriteLine("Invalid ChecklistGoal format, skipping this line.");
                            }
                            break;

                        default:
                            Console.WriteLine($"Unknown goal type {goalType}, skipping this line.");
                            break;
                    }
                }
            }

            Console.WriteLine("\nGoals loaded from file.");
        }
        else
        {
            Console.WriteLine("\nNo saved goals found.");
        }
    }
}

