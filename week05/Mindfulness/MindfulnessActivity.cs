public abstract class MindfulnessActivity
{
    protected string _activityName;
    protected string _description;
    protected int _duration;

    public MindfulnessActivity(string activityName, string description)
    {
        _activityName = activityName;
        _description = description;
    }

    public abstract void StartActivity();
    public abstract void EndActivity();

    protected void PauseWithAnimation(int seconds)
    {
        for (int i = 0; i < seconds; i++)
        {
            Console.Write(".");
            System.Threading.Thread.Sleep(1000);
            Console.Clear();
        }
    }

    protected void TrackTime(int seconds)
    {
        DateTime startTime = DateTime.Now;
        for (int i = 0; i < seconds; i++)
        {
            Console.Write(".");
            System.Threading.Thread.Sleep(1000);
        }
        DateTime endTime = DateTime.Now;
        TimeSpan elapsedTime = endTime - startTime;
        Console.WriteLine($"\nTime spent: {elapsedTime.Minutes} minutes and {elapsedTime.Seconds} seconds");
    }

    public void AskDuration()
    {
        bool validInput = false;
        while (!validInput)
        {
            Console.WriteLine("Please enter the duration for this activity (in seconds): ");
            string input = Console.ReadLine();
            validInput = int.TryParse(input, out _duration);

            if (!validInput)
            {
                Console.WriteLine("Invalid input. Please enter a valid number of seconds.");
            }
        }
    }
}
