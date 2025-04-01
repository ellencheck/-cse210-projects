public class BreathingActivity : MindfulnessActivity
{
    public BreathingActivity() : base("Breathing", "Focus on your breath to relax your mind.")
    {
    }

    public override void StartActivity()
    {
        Console.WriteLine($"Starting { _activityName } activity...");
        AskDuration();  // Ask user for duration
        Console.WriteLine($"Get ready for a { _activityName } activity for { _duration } seconds.");
        TrackTime(_duration);
    }

    public override void EndActivity()
    {
        Console.WriteLine("Breathing activity complete!");
    }
}
