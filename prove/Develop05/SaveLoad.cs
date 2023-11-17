using System;
using System.Collections.Generic;
using System.IO;

class SaveLoad
{
    private const string _simpleGoal = "SimpleGoal";
    private const string _eternalGoal = "EternalGoal";
    private const string _checklistGoal = "ChecklistGoal";

    public void SaveData(string fileName, int userPoints, List<GoalBase> goalsList)
    {
        try
        {
            using (StreamWriter writer = new StreamWriter(fileName))
            {
                writer.WriteLine(userPoints);

                foreach (GoalBase goal in goalsList)
                {
                    string goalLine = GetGoalLine(goal);
                    writer.WriteLine(goalLine);
                }
            }

            Console.WriteLine($"Goals saved to {fileName}.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving goals: {ex.Message}");
        }
    }

    private string GetGoalLine(GoalBase goal)
    {
        if (goal is EternalGoal eternalGoal)
        {
            return $"{eternalGoal.GetType().Name}:{goal.GetName()},{goal.GetDescription()},{goal.GetPoints()}";
        }

        if (goal is ChecklistGoal checklistGoal)
        {
            return $"{checklistGoal.GetType().Name}:{goal.GetName()},{goal.GetDescription()},{goal.GetPoints()},{goal.IsComplete()},{checklistGoal.BonusPoints},{checklistGoal.BonusTargetCount},{checklistGoal.BonusActualCount}";
        }

        return $"{goal.GetType().Name}:{goal.GetName()},{goal.GetDescription()},{goal.GetPoints()},{goal.IsComplete()}";
    }

    public void LoadData(string fileName, ref int userPoints, List<GoalBase> goalsList, Program program)
    {
        try
        {
            using (StreamReader reader = new StreamReader(fileName))
            {
                int totalPoints = int.Parse(reader.ReadLine());
                userPoints = totalPoints;

                goalsList.Clear();

                while (!reader.EndOfStream)
                {
                    string goalLine = reader.ReadLine();
                    string[] goalData = goalLine.Split(':');
                    string[] goalProperties = goalData[1].Split(',');

                    ParseGoal(goalData, goalProperties, goalsList);
                }

                Console.WriteLine($"Goals loaded from {fileName}.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading goals: {ex.Message}");
        }
    }

    private void ParseGoal(string[] goalData, string[] goalProperties, List<GoalBase> goalsList)
    {
        string goalType = goalData[0];
        string goalName = goalProperties[0];
        string goalDescription = goalProperties[1];
        int goalPoints = int.Parse(goalProperties[2]);
        bool completionStatus = goalProperties.Length > 3 ? bool.Parse(goalProperties[3]) : false;

        int bonusPoints = 0;
        int bonusTargetCount = 0;
        int bonusActualCount = 0;

        if (goalProperties.Length >= 7)
        {
            bonusPoints = int.Parse(goalProperties[4]);
            bonusTargetCount = int.Parse(goalProperties[5]);
            bonusActualCount = int.Parse(goalProperties[6]);
        }

        switch (goalType)
        {
            case _simpleGoal:
                goalsList.Add(new SimpleGoal(goalName, goalDescription, goalPoints, completionStatus));
                break;

            case _eternalGoal:
                goalsList.Add(new EternalGoal(goalName, goalDescription, goalPoints));
                break;

            case _checklistGoal:
                goalsList.Add(new ChecklistGoal(goalName, goalDescription, goalPoints, completionStatus, bonusPoints, bonusTargetCount, bonusActualCount));
                break;
        }
    }
}