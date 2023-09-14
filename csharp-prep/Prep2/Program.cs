using System;
using System.Reflection.Metadata;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is your grade percentage? ");
        string userInput = Console.ReadLine();
        int grade = int.Parse(userInput);

        string letter = "";

        if (grade >= 90)
            {
                letter ="A";
            }
        else if (grade >= 80)
            {
                letter ="B";
            }
        else if (grade >= 70)
            {
                letter ="C";
            }
        else if (grade >= 60)
            {
                letter ="D";
            }
        else
            {
                letter ="F";
            }

        // stretch challenge
        int remainder = grade % 10;
        string sign = "";

        if (remainder >= 7 && !(letter == "A" || letter == "F"))
            {
                sign = "+";
            }
        else if (remainder < 3 && letter != "F")
            {
                sign = "-";
            }
        else
            {
                sign = "";
            }

        Console.WriteLine($"Your grade is: {letter}{sign}");
        
        if (grade >= 70)
            {   
                Console.WriteLine("Congratulations! You passed the course.");
            }
        else
            {
                Console.WriteLine("Do better next time to pass the course.");
            }
    }
}