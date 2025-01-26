using System;

/*
  Added logic to read scriptures from a library and randomly display them to the user.
*/

class Program
{
    static void Main(string[] args)
    {
        // Console.WriteLine("Hello World! This is the ScriptureMemorizer Project.");

        List<Scripture> scriptures = new List<Scripture>
        {

            new Scripture(new Reference("Proverbs", 3, 5, 6), "Trust in the Lord with all thine heart and lean not unto thine own understanding; in all thy ways acknowledge Him, and He shall direct they paths."),
            new Scripture(new Reference("2 Nephi", 32, 5), "For behold, again I say unto you that if ye will enter in by the way, and receive the Holy Ghost, it will show unto you all things what ye should do."),
            new Scripture(new Reference("Alma", 37, 6), "Now ye may suppose that this is foolishness in me; but behold I say unto you, that by small and simple things are great things brought to pass; and small means in many instances doth confound the wise."),
            new Scripture(new Reference("3 Nephi", 28, 11), "And the Holy Ghost beareth record of the Father and me; and the Father giveth the Holy Ghost unto the children of men, because of me.")
        };

        List<Scripture> memorizeScriptures = new List<Scripture>(scriptures);

        Random random = new Random();

        while (memorizeScriptures.Count > 0)
        {
            int index = random.Next(memorizeScriptures.Count);
            Scripture scripture = memorizeScriptures[index];

            while (!scripture.IsCompletelyHidden())
            {
                Console.Clear();
                Console.WriteLine(scripture.GetDisplayText());

                scripture.HideRandomWords(4);

                Console.Write("\nPress Enter to continue or type 'quit' to finish: ");
                string input = Console.ReadLine().ToLower();

                if (input == "quit")
                {
                    Console.WriteLine("\nThanks for playing the Scripture Memorizer game.");
                    return;
                }
            }

            memorizeScriptures.Remove(scripture);
        }

        Console.Clear();
        Console.WriteLine("Congratulations! You have memorized all the scriptures.");
    }
}