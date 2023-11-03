using System;
public class BaseMindfulness
{
    private string _name {get; set;}
    private string _description {get; set;}
    public int _duration {get; set;}

    public BaseMindfulness(string name, string description)
    {
        _name = name;
        _description = description;
    }

    public void StartActivity()
    {
        Console.WriteLine($"Welcome to {_name}.\n\n{_description}\n");
        _duration = EnterDuration();
    }

    private static int EnterDuration()
    {
        Console.Write("How long, in seconds, would you like for your session? ");
        return int.Parse(Console.ReadLine());
    }

    public void DisplayCountdown(int seconds)
    {
        // Display a countdown timer
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b"); // Clear the displayed digit
        }
    }

    public void DisplaySpinner(int seconds)
    {
        for (int i = 0; i < seconds; i++)
        {
            Console.Write("/");
            Thread.Sleep(250);
            Console.Write("\b");
            Console.Write("-");
            Thread.Sleep(250);
            Console.Write("\b");
            Console.Write("\\");
            Thread.Sleep(250);
            Console.Write("\b");
            Console.Write("|");
            Thread.Sleep(250);
            Console.Write("\b \b \b \b"); // Clear the displayed spinner
        }
    }

    public void EndActivity()
    {
        // Concluding message for all activities
        Console.WriteLine("\n\nWell done!!");
        DisplaySpinner(3); // Display the spinner for 3 seconds
        Console.WriteLine($"\nYou have completed another {_duration} seconds of the {_name}.");
        DisplaySpinner(5); // Display the spinner for 5 seconds
        Console.Clear();
        Program.DisplayMenu();
    }
}