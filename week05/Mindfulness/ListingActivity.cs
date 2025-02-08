class ListingActivity : Activity
{
    protected int _count;

    protected List<string> _prompts;

    protected List<string> _usedPrompts;

    protected Random _random = new Random();

    public ListingActivity()
    {
        _name = "Listing";
        _description = "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.";
        _count = 0;
        _usedPrompts = [];

        _prompts =
        [
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?"
        ];
    }

    public void Run()
    {
        DisplayStartingMessage();

        Console.Write("How long would you like your session to be (in seconds)? ");
        _duration = int.Parse(Console.ReadLine());

        Console.Clear();
        Console.WriteLine("Get ready...");
        ShowSpinner(4);

        string prompt = GetRandomPrompt();

        Console.WriteLine("\nList as many responses as you can to the following prompt:\n");
        Console.WriteLine($"--- {prompt} ---\n");

        Console.Write("You may begin in:  ");
        ShowCountDown(4);

        _count = GetListFromUser().Count;

        Console.WriteLine($"\nYou listed {_count} items.\n");
        DisplayEndingMessage();
    }

    private string GetRandomPrompt()
    {
        if (_prompts.Count == 0)
        {
            ResetPrompts();
        }

        int index = _random.Next(_prompts.Count);
        string prompt = _prompts[index];

        _usedPrompts.Add(prompt);
        _prompts.RemoveAt(index);

        return prompt;
    }

    private List<string> GetListFromUser()
    {
        List<string> items = [];
        DateTime endTime = DateTime.Now.AddSeconds(_duration);

        while (DateTime.Now < endTime)
        {
            Console.Write("> ");
            string item = Console.ReadLine();
            items.Add(item);
        }

        return items;
    }

    private void ResetPrompts()
    {
        _prompts.AddRange(_usedPrompts);
        _usedPrompts.Clear();
    }
}
