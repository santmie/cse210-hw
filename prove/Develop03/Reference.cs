using System;
public class Reference
{
    private string _book;
    private int _chapter;
    private List<int> _verses;

    public string GetBook() //returns the value of the _book 
    {
        return _book;
    }

    private void SetBook(string book) //assign a new value to the _book
    {
        _book = book; //sets the value of the _book variable to whatever string is passed to book parameter
    }

    public int GetChapter() //returns the value of the _chapter
    {
        return _chapter;
    }

    private void SetChapter(int chapter) //set a new value for the _chapter 
    {
        _chapter = chapter;  //sets the value of the _chapter variable to whatever integer is passed to chapter parameter
    }

    public List<int> GetVerses() //returns the value of the private _verses list
    {
        return _verses;
    }

    private void SetVerses(List<int> verses) // set the value of the _verses list
    {
        _verses = new List<int>(verses); //sets the value of the private _verses to a new list containing the same elements as the verses list
    }

    public Reference(string book, int chapter, List<int> verses) //constructor for Reference object with single verse
    {
        SetBook(book);
        SetChapter(chapter);
        SetVerses(verses);
    }

    public Reference(string book, int chapter, int verse) //constructor for Reference object with multiple verse
    {
        SetBook(book);
        SetChapter(chapter);
        SetVerses(new List<int> { verse });
    }

    public void AddVerse(int verse) //add the specified verse to the _verses list
    {
        _verses.Add(verse);
    }

    public override string ToString() //returns a string representation of the Reference object
    {
        if (_verses.Count == 1) //check if there is only one verse in the list of verses
        {
            return $"{GetBook()} {GetChapter()}:{_verses[0]}"; //returns the formatted string with the book, chapter, and the single verse
        }
        else
        {
            string versesString = string.Join(",", _verses); // Joins the list of verses into a comma-separated string (5,6)
            return $"{GetBook()} {GetChapter()}:{versesString}"; // Returns the formatted string with the book, chapter, and the comma-separated verses
        }
    }
}
