using System;

public class Cycling : Activity
{
    private double speed;  // Speed in mph

    public Cycling(string date, int duration, double speed) : base(date, duration)
    {
        this.speed = speed;
    }

    public override double GetDistance()
    {
        // Distance in miles calculated from speed and duration
        return (speed * Duration) / 60;
    }

    public override double GetSpeed()
    {
        return speed;  // Speed in mph
    }

    public override double GetPace()
    {
        // Pace in minutes per mile (time per distance)
        return Duration / GetDistance();
    }
}
