public class SimpleGoal : GoalBase
{
    public SimpleGoal(string name, string description, int points, bool completionStatus) 
        : base(name, description, points, completionStatus){}

    public override int RecordEvent() 
    {
        _completionStatus = true; // Mark the simple goal as complete
        return _points; // Return the point value associated with recording the event
    }

    public override bool? IsComplete()
    {
        // Implementation for checking if the simple goal is complete
        return _completionStatus;
    }
}