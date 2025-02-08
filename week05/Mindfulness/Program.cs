using System;

class Program
{
    // Exceeding requirements:
    // Added logic in the Reflecting & Listing Activity classes to make sure no random prompts/questions
    // are selected until they have all been used at least once in that session.

    static void Main(string[] args)
    {
        // Console.WriteLine("Hello World! This is the Mindfulness Project.");

        Activity breathingActivity = new BreathingActivity();
        Activity reflectingActivity = new ReflectingActivity();
        Activity listingActivity = new ListingActivity();

        while (true)
        {
            Console.Clear();
            Console.WriteLine("Menu options:");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Exit");
            Console.Write("\nSelet a choice from the menu: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    ((BreathingActivity)breathingActivity).Run();
                    break;

                case "2":
                    ((ReflectingActivity)reflectingActivity).Run();
                    break;

                case "3":
                    ((ListingActivity)listingActivity).Run();
                    break;

                case "4":
                    Console.WriteLine("\nThank you for using the Mindfulness Program.");
                    return;

                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }

            Console.Write("\nPress any key to continue...");
            Console.ReadKey();
        }
    }
}