using System;

public class ChecklistGoal : Goal
{
    public int TimesToComplete { get; set; }
    public int TimesCompleted { get; set; }

    // Constructor
    public ChecklistGoal(string name, string description, int points, int timesToComplete)
        : base(name, description, points)  // Assuming Goal constructor needs these parameters
    {
        this.TimesToComplete = timesToComplete;
        this.TimesCompleted = 0;
    }

    // Override RecordEvent method
    public override void RecordEvent()
    {
        if (TimesCompleted < TimesToComplete)
        {
            TimesCompleted++;
            this.Points += 50; // Earn 50 points each time the goal is completed.
        }
    }

    // Override GetStatus method
    public override string GetStatus()
    {
        return $"{Name}: Completed {TimesCompleted}/{TimesToComplete}";
    }

    // Override Serialize method to save goal data
    public override string Serialize()
    {
        return $"ChecklistGoal,{this.Name},{this.Description},{this.Points},{this.TimesCompleted},{this.TimesToComplete}";
    }
}
