using System;
using System.Collections.Generic;

public class ListingActivity : MindfulnessActivity
{
    private List<string> _prompts = new List<string>
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    public ListingActivity() : base("Listing", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
    {
    }

    public override void StartActivity()
    {
        Console.WriteLine($"Starting { _activityName } activity...");
        AskDuration();  // Ask user for duration
        Console.WriteLine($"Get ready for a { _activityName } activity for { _duration } seconds.");
        
        // Select a random prompt
        Random random = new Random();
        int index = random.Next(_prompts.Count);
        string prompt = _prompts[index];

        Console.WriteLine($"Your prompt: {prompt}");

        // Countdown to get them ready
        Countdown(5);

        Console.WriteLine("Start listing the items now. Press Enter after each item.");
        
        List<string> userEntries = new List<string>();
        DateTime endTime = DateTime.Now.AddSeconds(_duration);

        // Collect user input until the time runs out
        while (DateTime.Now < endTime)
        {
            string userInput = Console.ReadLine();
            if (!string.IsNullOrEmpty(userInput))
            {
                userEntries.Add(userInput);
            }
        }

        Console.WriteLine($"You listed {userEntries.Count} items.");
    }

    public override void EndActivity()
    {
        Console.WriteLine("Listing activity complete!");
    }

    // Helper method to handle countdown
    private void Countdown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.WriteLine(i);
            System.Threading.Thread.Sleep(1000);
        }
    }
}

