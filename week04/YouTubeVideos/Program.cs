using System;

class Program
{
    static void Main(string[] args)
    {
        // Console.WriteLine("Hello World! This is the YouTubeVideos Project.");

        Video lambo = new Video("I Rebuilt A Wrecked Lamborghini Urus", "Mat Armstrong", 7512);
        lambo.AddComment(new Comment("Alice", "Where do you buy auctioned vehicles?"));
        lambo.AddComment(new Comment("Michael", "So how much did the total come out to?"));
        lambo.AddComment(new Comment("Charlie", "Amazing job, congrats!"));

        Video garage = new Video("I Built My Dream Home Garage", "Mat Armstrong", 1738);
        garage.AddComment(new Comment("David", "I'm coming over!"));
        garage.AddComment(new Comment("Eva", "Nice."));

        Video house = new Video("I Bought My Dream House ... Again", "Mat Armstrong", 2070);
        house.AddComment(new Comment("Ian", "Super proud of you buddy. Also I'm moving in."));
        house.AddComment(new Comment("John", "100% Living the Dream. I've been here since the TT."));
        house.AddComment(new Comment("Samantha", "I love it. Well done, Mat."));

        List<Video> videos = new List<Video> { lambo, garage, house };

        foreach (Video video in videos)
        {
            Console.WriteLine($"Title: {video.GetTitle()}");
            Console.WriteLine($"Author: {video.GetAuthor()}");
            Console.WriteLine($"Length: {video.GetLength()} seconds");
            Console.WriteLine($"Number of Comments: {video.GetNumberOfComments()}\n");

            foreach (Comment comment in video.GetComments())
            {
                Console.WriteLine($"{comment.GetName()}: {comment.GetText()}");
            }

            Console.WriteLine();
        }
    }
}