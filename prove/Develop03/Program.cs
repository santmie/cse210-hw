using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Proverbs 3:5-6 Trust in the Lord with all thine heart and lean not unto thine own understanding; in all thy ways acknowledge him, and he shall direct thy paths.");

        string scriptureText = "Trust in the Lord with all thine heart and lean not unto thine own understanding; in all thy ways acknowledge him, and he shall direct thy paths.";
        
        //create objects of the Scripture and Reference classes 
        Reference reference = new Reference("Proverbs", 3, new List<int> {5,6});
        Scripture scripture = new Scripture(scriptureText, reference);

        while (scripture.HasUnhiddenWords()) //while loop as long as method HasUnhiddenWords() of the scripture object returns true.
        {
            Console.WriteLine("\nPress enter to hide a word or type 'quit' to end:");
            string userInput = Console.ReadLine();

            if (userInput.ToLower() == "quit") //if the user's input is "quit" (converted to lowercase), the loop breaks and program ends
            {
                break;
            }
            
            Console.Clear(); //if the user's input is not "quit", the screen is cleared

            //then te HideRandomWords(3) method of the Scripture class is called to hide 3 random words
            //finally the DisplayScripture() method of the Scripture class is called to display scripture reference and the modified scripture text.
            scripture.HideRandomWords(3);
            scripture.DisplayScripture();
        }
    }
}