using System;

public class Running : Activity
{
    private double distance;  // Distance in miles

    public Running(string date, int duration, double distance) : base(date, duration)
    {
        this.distance = distance;
    }

    public override double GetDistance()
    {
        return distance;
    }

    public override double GetSpeed()
    {
        // Speed in mph
        return (distance / Duration) * 60;
    }

    public override double GetPace()
    {
        // Pace in minutes per mile
        return (Duration / distance);
    }
}
