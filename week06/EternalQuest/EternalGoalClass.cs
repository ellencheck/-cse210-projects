// EternalGoalClass.cs
public class EternalGoal : Goal
{
    // Constructor for EternalGoal, passing parameters to the base class constructor
    public EternalGoal(string name, string description, int points)
        : base(name, description, points)  // Calls the base class constructor
    {
    }

    // Implementing abstract methods
    public override void RecordEvent()
    {
        // Implementation for recording events
    }

    public override string GetStatus()
    {
        // Implementation for getting the status
        return "Eternal Goal Status";
    }

    public override string Serialize()
    {
        // Implementation for serializing the goal
        return $"Name: {Name}, Description: {Description}, Points: {Points}";
    }
}
