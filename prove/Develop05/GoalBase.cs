public abstract class GoalBase
{
    protected string _name;
    protected string _description;
    protected int _points;
    protected bool _completionStatus;

    public GoalBase(string name, string description, int points, bool completionStatus)
    {
        _name = name;
        _description = description;
        _points = points;
        _completionStatus = completionStatus;
    }

    public string GetName()
    {
        return _name; 
    }

    public string GetDescription()
    {
        return _description;
    }

    public int GetPoints()
    {
        return _points; 
    }

    public virtual int RecordEvent()
    {
        return _points;
    }

    public virtual bool? IsComplete()
    {
        return null;
    }
}