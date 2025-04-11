using System; 
using System.Collections.Generic;
using System.IO; 

public class GoalManager
{
    private List<Goal> _goals;
    private int _totalPoints;

    public GoalManager()
    {
        _goals = new List<Goal>();
        _totalPoints = 0;
    }

    public void AddGoal(Goal goal)
    {
        _goals.Add(goal);
    }

    public void RecordGoalEvent(int index)
    {
        if (index >= 0 && index < _goals.Count)
        {
            _goals[index].RecordEvent();
            _totalPoints += _goals[index].Points;
        }
    }

    public void PrintGoalStatus()
    {
        Console.WriteLine("Goals and Status:");
        foreach (var goal in _goals)
        {
            Console.WriteLine(goal.GetStatus());
        }
    }

    public void ShowTotalPoints()
    {
        Console.WriteLine($"Total Points: {_totalPoints}");
    }

    public void SaveGoals(string fileName)
    {
        using (StreamWriter sw = new StreamWriter(fileName))
        {
            foreach (var goal in _goals)
            {
                sw.WriteLine(goal.Serialize());  // Now correctly calls Serialize()
            }
        }
    }

    public void LoadGoals(string fileName)
    {
        if (File.Exists(fileName))
        {
            string[] goalLines = File.ReadAllLines(fileName);
            foreach (var line in goalLines)
            {
                string[] goalParts = line.Split(',');

                if (line.StartsWith("SimpleGoal"))
                {
                    _goals.Add(new SimpleGoal(goalParts[1], goalParts[2], int.Parse(goalParts[3])));
                }
                else if (line.StartsWith("EternalGoal"))
                {
                    _goals.Add(new EternalGoal(goalParts[1], goalParts[2], int.Parse(goalParts[3])));
                }
                else if (line.StartsWith("ChecklistGoal"))
                {
                    _goals.Add(new ChecklistGoal(goalParts[1], goalParts[2], int.Parse(goalParts[3]), int.Parse(goalParts[4])));
                }
            }
        }
    }
}
