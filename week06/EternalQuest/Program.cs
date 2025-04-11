using System;
using System.Collections.Generic;
using System.IO;

public class Program
{
    private static List<Goal> goals = new List<Goal>();
    private static int totalScore = 0;
    private static int playerLevel = 1;

    public static void Main()
    {
        bool running = true;

        while (running)
        {
            Console.Clear();
            Console.WriteLine("Eternal Quest - Goal Tracking");
            Console.WriteLine($"Score: {totalScore} | Level: {playerLevel}");
            Console.WriteLine("1. Create new goal");
            Console.WriteLine("2. Record event");
            Console.WriteLine("3. Show all goals");
            Console.WriteLine("4. Show score");
            Console.WriteLine("5. Save and Exit");
            Console.Write("Select an option: ");
            
            var option = Console.ReadLine();
            switch (option)
            {
                case "1":
                    CreateGoal();
                    break;
                case "2":
                    RecordEvent();
                    break;
                case "3":
                    ShowGoals();
                    break;
                case "4":
                    ShowScore();
                    break;
                case "5":
                    SaveGoals();
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid option.");
                    break;
            }
        }
    }

    // Creative addition: Enhanced the score system to reward leveling up
    public static void AddScore(int points)
    {
        totalScore += points;
        int newLevel = totalScore / 100 + 1;  // A level-up every 100 points, making the game feel progressive
        if (newLevel > playerLevel)
        {
            playerLevel = newLevel;
            Console.WriteLine($"🎉 Congratulations! You leveled up to Level {playerLevel}!");  // Motivational feedback
        }
    }

    // Creative addition: Ability to add different types of goals (Simple, Eternal, Checklist) - Flexibility for player
    private static void CreateGoal()
    {
        Console.WriteLine("Enter goal type (Simple, Eternal, Checklist): ");
        string goalType = Console.ReadLine().ToLower();

        Console.WriteLine("Enter goal name: ");
        string name = Console.ReadLine();

        Console.WriteLine("Enter goal description: ");
        string description = Console.ReadLine();

        Goal newGoal = null;

        if (goalType == "simple")
        {
            Console.WriteLine("Enter points for this goal: ");
            int points = int.Parse(Console.ReadLine());
            newGoal = new SimpleGoal(name, description, points);
        }
        else if (goalType == "eternal")
        {
            Console.WriteLine("Enter points per completion: ");
            int points = int.Parse(Console.ReadLine());
            newGoal = new EternalGoal(name, description, points);
        }
        else if (goalType == "checklist")
        {
            Console.WriteLine("Enter points per completion: ");
            int points = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter total times to complete this goal: ");
            int totalTimes = int.Parse(Console.ReadLine());
            newGoal = new ChecklistGoal(name, description, points, totalTimes);
        }

        if (newGoal != null)
        {
            goals.Add(newGoal);
            Console.WriteLine("Goal added successfully!");
        }
    }

    // Creative addition: Event recording, making the game interactive and immersive
    private static void RecordEvent()
    {
        Console.WriteLine("Enter goal name to record an event: ");
        string name = Console.ReadLine();

        Goal goal = goals.Find(g => g.Name == name);
        if (goal != null)
        {
            goal.RecordEvent();  // Recording progress for specific goals
            Console.WriteLine("Event recorded successfully!");
        }
        else
        {
            Console.WriteLine("Goal not found.");
        }
    }

    // Creative addition: Displaying all goals so the player can see progress and track multiple goals
    private static void ShowGoals()
    {
        foreach (var goal in goals)
        {
            Console.WriteLine(goal.GetStatus());  // A nice way to present goal progress and completion status
        }
    }

    // Creative addition: Show score to give the player clear feedback on their achievements
    private static void ShowScore()
    {
        Console.WriteLine($"Your total score is: {totalScore}");
    }

    // Saving goals to a file to keep track of the player's progress
    private static void SaveGoals()
    {
        Console.WriteLine("Saving goals...");
        using (StreamWriter writer = new StreamWriter("goals.txt"))
        {
            foreach (var goal in goals)
            {
                writer.WriteLine(goal.Serialize());  // Serialization allows saving game state for future sessions
            }
        }
    }

    // Load goals from file if they exist - gives the player a way to continue from where they left off
    private static void LoadGoals()
    {
        if (File.Exists("goals.txt"))
        {
            using (StreamReader reader = new StreamReader("goals.txt"))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    var parts = line.Split(',');
                    var type = parts[0];

                    Goal goal = null;
                    if (type == "SimpleGoal")
                    {
                        goal = new SimpleGoal(parts[1], parts[2], int.Parse(parts[3]));
                    }
                    else if (type == "EternalGoal")
                    {
                        goal = new EternalGoal(parts[1], parts[2], int.Parse(parts[3]));
                    }
                    else if (type == "ChecklistGoal")
                    {
                        goal = new ChecklistGoal(parts[1], parts[2], int.Parse(parts[3]), int.Parse(parts[4]));
                    }

                    if (goal != null)
                    {
                        goals.Add(goal);
                    }
                }
            }
        }
    }
}
