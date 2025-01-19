using System;

class Entry
{
    public string _promptText;
    public string _entryText;
    public string _date;

    public void Display()
    {
        Console.WriteLine($"Date: {_date}");
        Console.WriteLine($"Prompt: {_promptText}");
        Console.WriteLine($"Response: {_entryText}");
    }
}
