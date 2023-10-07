using System;
using System.Globalization;

// Unit 02 Develop: Journal Program
// Submitted by: Crisanta Advincula

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();

        Console.WriteLine("Welcome to the Journal Program");

        while (true)
        {
            //Provide a menu that allows the user choose options
            Console.WriteLine("Please select one of the following choices:\n1. Write\n2. Display\n3. Load\n4. Save\n5. Quit");
            
            try{
            //Showing Creativity and Exceeding Requirements
                //When a user enters a string instead of an integer, it can cause a runtime error and the program will terminate.
                //So it is very important to implement error handling exceptions to validate user input,
                //provide an error message, and assist the user in correcting their input.

                Console.Write("What would you like to do? ");
                string userInput = Console.ReadLine();
                int choice = int.Parse(userInput);

                if (choice == 1)
                //Write a new entry - Show the user a random prompt (from a list that you create), and save their response, the prompt, and the date as an Entry.
                    {
                        Prompt prompt = new Prompt();
                        Console.Write(prompt.GetRandomQuestion() + "\n> ");
                        string randQuestion = prompt.GetRandomQuestion();
                        string response =  Console.ReadLine();
                        Entry newEntry = new Entry(DateTime.Now, randQuestion, response);
                        journal.AddEntry(newEntry);

                    }
                else if (choice == 2)
                //Display the journal - Iterate through all entries in the journal and display them to the screen.
                    {
                        foreach (Entry entry in journal.GetEntries())
                        {
                            entry.DisplayEntry();
                        }
                    }
                else if (choice == 3)
                //Load the journal from a file - Prompt the user for a filename and then load the journal (a complete list of entries) from that file. This should replace any entries currently stored the journal.
                    {
                        journal.LoadFile();
                    }
                else if (choice == 4)
                //Save the journal to a file - Prompt the user for a filename and then save the current journal (the complete list of entries) to that file location.
                    {
                        journal.SaveToFile();
                    }
                else if (choice == 5)
                // Quit the program
                    {
                        Environment.Exit(0);               
                    }
                else
                    {
                //Showing Creativity and Exceeding Requirements
                    // When a user enters an integer that is not between 1 - 5.
                    // Program will prompt that the input is invalid and will start the loop again to
                    // select on one of the valid choices (1-5).
                        Console.WriteLine("Invalid input. Please enter a number between 1-5.\n");
                    }
            }

            //Exception handling, whenever a user inputs a string.
            catch (FormatException) 
                {
                    Console.WriteLine("Error: Invalid input. Please enter a valid integer.\n");
                } 
            catch (Exception ex) 
                {
                    Console.WriteLine("An error occurred: " + ex.Message + " Please enter a valid integer.\n");
                }
        }
    }
}