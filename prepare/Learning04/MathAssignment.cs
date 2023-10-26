//Create a new file for the MathAssignment class.
//Create this class and make sure to specify that it inherits from the base Assignment class.
//Add the attributes as private member variables. Make sure that you do not create new member variables for the ones you inherited from the base class.
//Create a constructor for your class that accepts all four parameters, have it call the base class constructor to set the base class attributes that way.
//Add the GetHomeworkList() method.
//Test your class by returning to the Main method and creating a new MathAssignment object and set its values. Make sure to test both the GetSummary() and the GetHomeworkList() methods.
public class MathAssignment : Assignment
{
    private string _txtbookSection;
    private string _problems;

    public MathAssignment(string studentName, string topic, string txtbookSection, string problems)
        : base(studentName, topic)
    {
        _txtbookSection = txtbookSection;
        _problems = problems;
    }

    public string GetHomeworkList()
    {
        return $"Section {_txtbookSection} Problems {_problems}";
    }
}