using System;

class Program
{
    static Journal _journal = new Journal();
    static PromptGenerator _promptGenerator = new PromptGenerator();

    static void Main(string[] args)
    {
        // Console.WriteLine("Hello World! This is the Journal Project.");

        Console.WriteLine("Welcome to the Journal Enrty program. Please select from the following options:");

        bool exit = false;
        while (!exit)
        {
            Console.WriteLine();
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Save the journal to a file");
            Console.WriteLine("4. Load the journal from a file");
            Console.WriteLine("5. Exit");
            Console.WriteLine();
            Console.Write("Choose an option: ");

            string option = Console.ReadLine();
            switch (option)
            {
                case "1":
                    WriteEntry();
                    break;
                case "2":
                    _journal.DisplayEntries();
                    break;
                case "3":
                    SaveJournal();
                    break;
                case "4":
                    LoadJournal();
                    break;
                case "5":
                    Console.WriteLine("Thank you. Have a nice day.");
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Please select a valid option.");
                    break;
            }
        }
    }

    static void WriteEntry()
    {
        string prompt = _promptGenerator.GetRandomPrompt();

        Console.WriteLine(prompt);
        Console.Write("Your response: ");

        string response = Console.ReadLine();
        string date = DateTime.Now.ToString("yyyy-MM-dd");

        Entry entry = new Entry();
        entry._promptText = prompt;
        entry._entryText = response;
        entry._date = date;

        _journal.AddEntry(entry);
    }

    static void SaveJournal()
    {
        Console.Write("Enter the filename to save the journal: ");

        string filename = Console.ReadLine();
        _journal.SaveToFile(filename + ".csv");
    }

    static void LoadJournal()
    {
        Console.Write("Enter the filename to load the journal: ");

        string filename = Console.ReadLine();
        _journal.LoadFromFile(filename + ".csv");
    }
}