using System;

class Program
{
    // Exceeding requirements:
    // Added logic to display star animations when a user completes the checklist goals
    // and receives the additional bonus

    static void Main(string[] args)
    {
        // Console.WriteLine("Hello World! This is the EternalQuest Project.");

        GoalManager goalManager = new GoalManager();
        goalManager.Start();
    }
}