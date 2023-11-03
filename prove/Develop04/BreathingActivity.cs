public class BreathingActivity : BaseMindfulness
{
    public BreathingActivity(string name, string description, int duration) : base (name, description) 
    {
        StartActivity();
    }

    public void StartBreathing()
    {
        Console.Clear();
        Console.WriteLine("Get ready...");
        DisplaySpinner(3); // Display the spinner for 3 seconds

        int secondsElapsed = 0;
        while (secondsElapsed < _duration)
        {
            int breatheInDuration = Math.Min(4, _duration - secondsElapsed); // breathe in duration should not exceed the remaining time
            Console.WriteLine();
            Console.Write("Breathe in...");
            DisplayCountdown(breatheInDuration);
            secondsElapsed += breatheInDuration;

            if (secondsElapsed >= _duration)
            {
                break; // if the total duration has been reached
            }

            int breatheOutDuration = Math.Min(6, _duration - secondsElapsed); // breathe out duration should not exceed the remaining time
            Console.Write("\nNow breathe out...");
            DisplayCountdown(breatheOutDuration);
            secondsElapsed += breatheOutDuration;

            Console.WriteLine();
        }

        EndActivity();

    }
}
