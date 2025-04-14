using System;

public abstract class Activity
{
    private string date;
    private int duration;  // Duration in minutes

    // Constructor
    public Activity(string date, int duration)
    {
        this.date = date;
        this.duration = duration;
    }

    // Properties for encapsulation
    public string Date => date;
    public int Duration => duration;

    // Abstract methods for distance, speed, and pace
    public abstract double GetDistance(); // in miles or kilometers
    public abstract double GetSpeed();    // in mph or kph
    public abstract double GetPace();     // in min per mile or min per km

    // Method to get the summary
    public string GetSummary()
    {
        return $"{date} {this.GetType().Name} ({duration} min): " +
               $"Distance {GetDistance():0.0} miles, " +
               $"Speed: {GetSpeed():0.0} mph, " +
               $"Pace: {GetPace():0.0} min per mile";
    }
}
