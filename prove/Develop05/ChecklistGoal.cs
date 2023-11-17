public class ChecklistGoal : GoalBase
{
    private int _bonusPoints;
    private int _bonusTargetCount;
    private int _bonusActualCount;

    public ChecklistGoal(string name, string description, int points, bool completionStatus, int bonusPoints, int bonusTargetCount, int bonusActualCount)
        : base(name, description, points, completionStatus)
    {
        _bonusPoints = bonusPoints;
        _bonusTargetCount = bonusTargetCount;
        _bonusActualCount = bonusActualCount;
    }

    public int BonusPoints
    {
        get { return _bonusPoints; }
        set { _bonusPoints = value; }
    }

    public int BonusTargetCount
    {
        get { return _bonusTargetCount; }
        set { _bonusTargetCount = value; }
    }

    public int BonusActualCount
    {
        get { return _bonusActualCount; }
        set { _bonusActualCount = value; }
    }

    public override int RecordEvent() 
    {
       int pointsEarned = base.RecordEvent();

        _bonusActualCount++;

        // If the goal is complete, set IsComplete to true
        if (_bonusActualCount == _bonusTargetCount)
        {
            _completionStatus = true;

            // Add bonus points to total points
            _points += _bonusPoints;

            // Include bonus points in the points earned
            pointsEarned += _bonusPoints;
        }
  
        return pointsEarned;
    }

    public override bool? IsComplete()
    {
        // Implementation for checking if the checklist goal is complete
        return _completionStatus;
    }
}