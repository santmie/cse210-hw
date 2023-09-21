using System;
using System.Net;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;

class Program
{
    static void Main(string[] args)
    {


        // Console.Write("What is the magic number? ");
        // int magicNumber = int.Parse(Console.ReadLine());

        Random randomGenerator = new Random();
        int magicNumber = randomGenerator.Next(1, 101);

        int guessNumber = -1;
        //Stretch Challenge
        int guesscount = 0;
        string repeat = "yes";

        while (guessNumber != magicNumber || repeat == "yes")
        {
            guesscount += 1;
            Console.Write("What is your guess? ");
            guessNumber = int.Parse(Console.ReadLine());

            if(guessNumber < magicNumber)
                {
                Console.WriteLine("Higher");
                }
            else if (guessNumber > magicNumber)
                {
                Console.WriteLine("Lower");
                }   
            else
                {
                Console.WriteLine("You guessed it!");
                //Stretch Challenge
                Console.WriteLine($"It took you {guesscount} guesses.");
                Console.Write("Would you like to play again? " );
                repeat = Console.ReadLine();
                guesscount = 0;
                }
        }
    }
}