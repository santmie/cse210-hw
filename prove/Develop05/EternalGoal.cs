public class EternalGoal : GoalBase
{
    private int _totalEarnedPoints;

    public EternalGoal(string name, string description, int points) 
        : base(name, description, points, false)
    {
        // _initialPoints = initialPoints;
        _totalEarnedPoints = 0; // Initialize total earned points to zero
    }

    public override int RecordEvent()
    {
        // Increment points without marking as complete
        int pointsEarned = _points; // Store the initial points as points earned
        _totalEarnedPoints += _points; // Add the initial points to the total earned points

        return pointsEarned; // Return the points earned
    }

    public int GetTotalEarnedPoints()
    {
        return _totalEarnedPoints;
    }
}