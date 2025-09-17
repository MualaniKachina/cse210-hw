using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();

        // Video 1
        Video video1 = new Video("Exploring Space", "NASA", 300);
        video1.AddComment(new Comment("Alice", "Amazing video!"));
        video1.AddComment(new Comment("Bob", "Loved the visuals."));
        video1.AddComment(new Comment("Charlie", "I learned so much."));
        videos.Add(video1);

        // Video 2
        Video video2 = new Video("Cooking Pasta", "Chef Mario", 480);
        video2.AddComment(new Comment("David", "Great recipe."));
        video2.AddComment(new Comment("Eva", "Tried it today, delicious!"));
        video2.AddComment(new Comment("Frank", "Simple and easy to follow."));
        videos.Add(video2);

        // Video 3
        Video video3 = new Video("Guitar Lessons", "GuitarPro", 600);
        video3.AddComment(new Comment("Grace", "Helped me a lot!"));
        video3.AddComment(new Comment("Henry", "Best tutorial ever."));
        video3.AddComment(new Comment("Ivy", "More videos please!"));
        videos.Add(video3);

        // Displaying the videos
        foreach (Video v in videos)
        {
            Console.WriteLine($"Title: {v.Title}");
            Console.WriteLine($"Author: {v.Author}");
            Console.WriteLine($"Length: {v.Length} seconds");
            Console.WriteLine($"Number of Comments: {v.GetNumberOfComments()}");

            foreach (Comment c in v.GetComments())
            {
                Console.WriteLine($"  {c.Name}: {c.Text}");
            }

            Console.WriteLine(new string('-', 40));
        }
    }
}
