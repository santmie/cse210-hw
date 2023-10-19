using System;
public class Scripture
{
    private List<Word> _words;
    private Reference _reference;

    public Scripture(string text, Reference reference) //constructor for the Scripture class that takes two parameters (text and reference)
    {
        InitializeWords(text); // initialize the words based on the provided text
        _reference = reference; // hold a reference paramater for the Refernce object
    }

    private void InitializeWords(string text)
    {
        _words = new List<Word>(); //set an empty list of Word objects, which will store the words generated from the provided text
        foreach (var txt in text.Split(' ')) //splits the string text into individual words using space(' ') separator
        {
            _words.Add(new Word(txt)); //create a new Word object for each word in the text and adds it to the _words list
        }
    }

    public void HideRandomWords(int count)
    {
        if (HasUnhiddenWords())
        {
            var random = new Random(); //generate random numbers
            var indixes = new HashSet<int>(); // initializes a HashSet to store unique integer value (the index of the words to be hidden)
            while (indixes.Count < count) //loop continues until the number of elements in the indixes HashSet is less than the specified count (3)
            {
                int randomIndex = random.Next(_words.Count); //generate random index within the _words list
                indixes.Add(randomIndex); //randomly generated index is added to the indixes HashSet
                _words[randomIndex].Hide(); // call the Hide() method of the Word class on the word of the randomly generated index and hides it
            }
        }
    }

    public void DisplayScripture() //method to display the reference and the scripture to the console
    {
        Console.WriteLine("Reference: " + _reference.ToString()); //prints the reference to the console
        Console.WriteLine(string.Join(" ", _words.Select(word => word.ToString()))); //prints the words of the scripture to the console - joins all the Word objects in the _words list, converted to strings and words separated with space
    }

    public bool HasUnhiddenWords() //method to check if there is any unhidden words in the Scripture
    {
        foreach (var word in _words)
        {
            if (!word.GetHidden()) //check if the current word is not hidden by using the GetHidden() method of the Word class.
            {
                return true; // if any word is not hidden, return true
            }
        }
        return false; // if all words are hidden, return false
    }
}