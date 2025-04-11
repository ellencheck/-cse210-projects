// SimpleGoal.cs
public class SimpleGoal : Goal
{
    public SimpleGoal(string name, string description, int points)
        : base(name, description, points)
    { }

    public override void RecordEvent()
    {
        IsCompleted = true;
        Program.AddScore(Points);
    }

    public override string GetStatus()
    {
        return $"{Name}: {Description} - Points: {Points} - Completed: {IsCompleted}";
    }

    public override string Serialize()
    {
        return $"SimpleGoal:{Name},{Description},{Points},{IsCompleted}";
    }
}
