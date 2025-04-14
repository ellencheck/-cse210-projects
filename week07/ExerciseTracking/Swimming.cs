using System;

public class Swimming : Activity
{
    private int laps;  // Number of laps
    private double lapLength; // Lap length in meters (default 50 meters)

    public Swimming(string date, int duration, int laps, double lapLength = 50) : base(date, duration)
    {
        this.laps = laps;
        this.lapLength = lapLength;
    }

    public override double GetDistance()
    {
        // Convert meters to miles: (laps * lapLength in meters)/1000 gives kilometers, then multiply by 0.62
        return (laps * lapLength / 1000) * 0.62;
    }

    public override double GetSpeed()
    {
        // Speed in mph
        return (GetDistance() / Duration) * 60;
    }

    public override double GetPace()
    {
        // Pace in minutes per mile
        return Duration / GetDistance();
    }
}
