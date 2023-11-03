public class ReflectionActivity : BaseMindfulness
{
    public ReflectionActivity(string name, string description, int duration) : base (name, description) 
    {
        StartActivity();
    }

    private List<string> _prompts = new List<string>
    {
        "Think of a time when you stood up for someone else. ",
        "Think of a time when you did something really difficult. ",
        "Think of a time when you helped someone in need. ",
        "Think of a time when you did something truly selfless. "
    };

    private List<string> _questions = new List<string>
    {
        "Why was this experience meaningful to you? ",
        "Have you ever done anything like this before? ",
        "How did you get started? ",
        "How did you feel when it was complete? ",
        "What made this time different than other times when you were not as successful? ",
        "What is your favorite thing about this experience? ",
        "What could you learn from this experience that applies to other situations? ",
        "What did you learn about yourself through this experience? ",
        "How can you keep this experience in mind in the future? "
    };

    private List<string> _usedQuestions = new List<string>(); //initialize an empty _usedQuestions list to store the used questions

    public void StartReflection()
    {
        Console.Clear();
        _usedQuestions.Clear();//clear the previously stored used questions

        Console.WriteLine("Get ready...");
        DisplaySpinner(3); // Display the spinner for 3 seconds

        Random rnd = new Random();
        Console.WriteLine("\nConsider the following prompt:\n");
        string prompt = GetRandomPrompt(rnd);
        Console.WriteLine($"---{prompt}---");

        Console.WriteLine("\nWhen you have something in mind, press enter to continue.");
        Console.ReadLine(); // Wait for user input
        Console.WriteLine("Now ponder on each of the following questions as they related to this experience");
        
        Console.Write("You may begin in: ");
        DisplayCountdown(5); // Countdown for 5 seconds
        Console.Clear();

        int secondsElapsed = 0;
        while (secondsElapsed < _duration)
        {
            string question = GetRandomQuestion(rnd);
            Console.Write($"> {question}");

            int remainingTime = _duration - secondsElapsed;
            int spinTime = Math.Min(10, remainingTime); // spin time should not exceed the remaining time
            DisplaySpinner(spinTime); // display the spinner for the calculated time
            secondsElapsed += spinTime; // increment the secondsElapsed variable by the actual spin time
            Console.WriteLine();
        }

        EndActivity();
    }

    private string GetRandomPrompt(Random rnd)
    {
        int index = rnd.Next(_prompts.Count);
        return _prompts[index];
    }

    //Showing Creativity and Exceeding Requirements:
    private string GetRandomQuestion(Random rnd)
    {
        
        if (_usedQuestions.Count == _questions.Count)// check if all questions have been used
        {
            _usedQuestions.Clear(); //reset used questions if all questions have been used
        }

        string randomQuestion; 
        do //keep the loop until we find an unused question
        {
            int index = rnd.Next(_questions.Count); 
            randomQuestion = _questions[index]; 
        } while (_usedQuestions.Contains(randomQuestion)); //repeat process if question has been used before

        _usedQuestions.Add(randomQuestion); //add the selected question to the list of used questions
        return randomQuestion; //return the randomly selected question
    }
}