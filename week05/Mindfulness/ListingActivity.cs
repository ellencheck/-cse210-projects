public class ListingActivity : MindfulnessActivity
{
    public ListingActivity() : base("Listing", "List things you are grateful for or any other list-based activity.")
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
        Console.WriteLine("Listing activity complete!");
    }
}
