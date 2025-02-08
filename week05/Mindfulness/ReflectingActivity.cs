class ReflectingActivity : Activity
{
    protected List<string> _prompts;

    protected List<string> _usedPrompts;

    protected List<string> _questions;

    protected List<string> _usedQuestions;

    protected Random _random = new Random();

    public ReflectingActivity()
    {
        _name = "Reflecting";
        _description = "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.";
        _usedPrompts = [];
        _usedQuestions = [];

        _prompts =
        [
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something truly selfless."
        ];

        _questions =
        [
            "Why was this experience meaningful to you?",
            "Have you ever done anything like this before?",
            "How did you get started?",
            "How did you feel when it was complete?",
            "What made this time different than other times when you were not as successful?",
            "What is your favorite thing about this experience?",
            "What could you learn from this experience that applies to other situations?",
            "What did you learn about yourself through this experience?",
            "How can you keep this experience in mind in the future?"
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

        DisplayPrompt();

        Console.WriteLine("When you have something in mind, press enter to continue.");
        Console.ReadLine();

        Console.WriteLine("Now ponder on each of the following questions as they relate to this experience.\n");
        Console.Write("You may begin in:  ");
        ShowCountDown(4);

        Console.Clear();
        DisplayQuestions();

        Console.WriteLine();
        DisplayEndingMessage();
    }

    private void DisplayPrompt()
    {
        string prompt = GetRandomPrompt();

        Console.WriteLine("\nConsider the following prompt:\n");
        Console.WriteLine($"--- {prompt} ---\n");
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

    public void DisplayQuestions()
    {
        if (_questions.Count == 0)
        {
            ResetQuestions();
        }

        DateTime endTime = DateTime.Now.AddSeconds(_duration);

        while (DateTime.Now < endTime)
        {
            string question = GetRandomQuestion();
            Console.WriteLine($"> {question}");
            ShowSpinner(10);

            Console.Write("\r");
        }
    }

    private string GetRandomQuestion()
    {
        int index = _random.Next(_questions.Count);
        string question = _questions[index];

        _usedQuestions.Add(question);
        _questions.RemoveAt(index);

        return question;
    }

    private void ResetPrompts()
    {
        _prompts.AddRange(_usedPrompts);
        _usedPrompts.Clear();
    }

    private void ResetQuestions()
    {
        _questions.AddRange(_usedQuestions);
        _usedQuestions.Clear();
    }
}
