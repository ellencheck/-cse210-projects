// Goal.cs
public abstract class Goal
{
    public string Name { get; set; }
    public string Description { get; set; }
    public int Points { get; set; }
    public bool IsCompleted { get; set; }

    public Goal(string name, string description, int points)
    {
        Name = name;
        Description = description;
        Points = points;
        IsCompleted = false;
    }

    // Abstract method to record events
    public abstract void RecordEvent();

    // Abstract method to get status
    public abstract string GetStatus();

    // Abstract method for serializing the goal
    public abstract string Serialize();
}
