public class ListingActivity : BaseMindfulness
{
    public ListingActivity(string name, string description, int duration) : base (name, description) 
    {
        StartActivity();
    }

    private List<string> _prompts = new List<string>
    {
        "Who are people that you appreciate? ",
        "What are personal strengths of yours? ",
        "Who are people that you have helped this week? ",
        "When have you felt the Holy Ghost this month? ",
        "Who are some of your personal heroes? "
    };

    private static List<string> _responses = new List<string>(); //initialize an empty _responses list to store the responses

    public void StartListing()
    {
        Console.Clear();
        _responses.Clear(); // clear the _response list to remove all previous responses

        Console.WriteLine("Get ready...");
        DisplaySpinner(3); // Display the spinner for 3 seconds

        Random rnd = new Random();
        Console.WriteLine("\nList as many responses you can to the following prompt\n");
        string prompt = GetRandomPrompt(rnd);
        Console.WriteLine($"---{prompt}---");
       
        Console.Write("\nYou may begin in: ");
        DisplayCountdown(5); // Countdown for 5 seconds
        Console.WriteLine();

        int secondsElapsed = 0;
        while (secondsElapsed < _duration)
        {
            Console.Write("> ");
            string response = Console.ReadLine();
            
            int remainingTime = _duration - secondsElapsed;
            int maxInputTime = Math.Min(response.Length / 5, remainingTime);//calculate remaining time to avoid exceeding the duration, 5 characters per second

            _responses.Add(response); //add response to the _responses list

            secondsElapsed += maxInputTime; //increment the secondsElapsed variable by the time taken for the user input

            if (secondsElapsed >= _duration)
            {
                break;
            }
        }

        // Get the number of responses
        int numberOfResponses = _responses.Count;
        Console.WriteLine($"You listed {numberOfResponses} items");

        EndActivity();
    }

    private string GetRandomPrompt(Random rnd)
    {
        int index = rnd.Next(_prompts.Count);
        return _prompts[index];
    }
}