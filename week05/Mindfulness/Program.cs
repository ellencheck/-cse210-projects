using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<MindfulnessActivity> activities = new List<MindfulnessActivity>
        {
            new BreathingActivity(),
            new ListingActivity(),
            new ReflectingActivity()
        };

        Console.WriteLine("Welcome to the Mindfulness Program!");

        // Display activity options to the user
        Console.WriteLine("Please choose an activity:");
        for (int i = 0; i < activities.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {activities[i].GetType().Name}");
        }

        bool validInput = false;
        int choice = 0;
        while (!validInput)
        {
            string input = Console.ReadLine();
            validInput = int.TryParse(input, out choice) && choice >= 1 && choice <= activities.Count;
            if (!validInput)
            {
                Console.WriteLine("Invalid choice. Please choose a valid number.");
            }
        }

        // Start the chosen activity
        activities[choice - 1].StartActivity();
        activities[choice - 1].EndActivity();
    }
}
