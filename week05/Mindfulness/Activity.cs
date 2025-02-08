class Activity
{
    protected string _name;

    protected string _description;

    protected int _duration;

    public Activity()
    {
        _name = "";
        _description = "";
        _duration = 0;
    }

    public void DisplayStartingMessage()
    {
        Console.Clear();
        Console.WriteLine($"Welcome to the {_name} activity.\n");
        Console.WriteLine($"{_description}\n");
    }

    public void DisplayEndingMessage()
    {
        Console.WriteLine("Well done!!");
        ShowSpinner(4);

        Console.WriteLine();
        Console.WriteLine($"You have completed another {_duration} seconds of the {_name} Activity.");
        ShowSpinner(4);
    }

    public static void ShowSpinner(int seconds)
    {
        List<string> spinner = ["|", "/", "-", "\\"];

        for (int i = 0; i < seconds * 2; i++)
        {
            Console.Write($"\r{spinner[i % spinner.Count]}");
            Thread.Sleep(500);
        }
        Console.Write("\r ");
    }

    public static void ShowCountDown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write($"\b \b{i}");
            Thread.Sleep(1000);
        }
        Console.Write("\b \b");
        Console.WriteLine();
    }
}