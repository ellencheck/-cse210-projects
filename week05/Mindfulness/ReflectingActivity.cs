public class ReflectingActivity : MindfulnessActivity
{
    public ReflectingActivity() : base("Reflecting", "Spend time reflecting on your thoughts and experiences.")
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
        Console.WriteLine("Reflecting activity complete!");
    }
}
