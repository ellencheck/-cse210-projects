// Program.cs
using System;
using System.Collections.Generic;

public partial class Program  
{
    public static void Main(string[] args)
    {
        List<Video> videos = new List<Video>
        {
            new Video("C# Basics", "John Doe", 600),
            new Video("Advanced C#", "Jane Smith", 1200),
            new Video("Design Patterns in C#", "Emily Johnson", 1800)
        };

        videos[0].AddComment(new Comment("Alice", "Great explanation!"));
        videos[0].AddComment(new Comment("Bob", "Very helpful, thanks!"));
        videos[0].AddComment(new Comment("Charlie", "I learned a lot!"));

        videos[1].AddComment(new Comment("David", "This was a bit fast, but useful."));
        videos[1].AddComment(new Comment("Eve", "Awesome content!"));
        videos[1].AddComment(new Comment("Frank", "Can you cover more topics?"));

        videos[2].AddComment(new Comment("Grace", "Best explanation of patterns!"));
        videos[2].AddComment(new Comment("Hank", "Really insightful!"));
        videos[2].AddComment(new Comment("Ivy", "Thank you for this!"));

        foreach (var video in videos)
        {
            video.DisplayInfo();
        }
    }
}
