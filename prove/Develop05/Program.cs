using System;
using System.Collections.Generic;

class Program
{
    private List<GoalBase> _goalsList = new List<GoalBase>();
    private int _userPoints = 0; // Variable to track user points
    private int _bonusActualCount = 0; // Track how many times the checklist goal is accomplished

    static void Main(string[] args)
    {
        Program program = new Program();
        program.Run();
    }

    private void Run()
    {
        while (true)
        {
            DisplayMenu();
        }
    }

    private void DisplayMenu()
    {
        Console.WriteLine();
        Console.WriteLine($"You have {_userPoints} points."); // Display initial points
        Console.WriteLine();
        Console.WriteLine("Menu Options:");
        Console.WriteLine(" 1. Create New Goal");
        Console.WriteLine(" 2. List Goals");
        Console.WriteLine(" 3. Save Goals");
        Console.WriteLine(" 4. Load Goals");
        Console.WriteLine(" 5. Record Event");
        Console.WriteLine(" 6. Quit");
        Console.Write("Select a choice from the menu: ");

        int choice = int.Parse(Console.ReadLine());

        switch (choice)
        {
            case 1:
                CreateNewGoal();
                break;

            case 2:
                ListGoals();
                break;

            case 3:
                SaveGoals();
                break;

            case 4:
                LoadGoals();
                break;

            case 5:
                RecordCompletedEvent();
                break;

            case 6:
                Environment.Exit(0); // Exit the program
                break;

            default:
                Console.WriteLine("Invalid choice.");
                break;
        }
    }

    private void CreateNewGoal()
    {
        Console.WriteLine("The types of Goals are:");
        Console.WriteLine(" 1. Simple Goal");
        Console.WriteLine(" 2. Eternal Goal");
        Console.WriteLine(" 3. Checklist Goals");

        Console.Write("Which type of goal would you like to create? ");
        int goalChoice = int.Parse(Console.ReadLine());
        Console.Write("What is the name of your goal? ");
        string goalName = Console.ReadLine();
        Console.Write("What is a short description of it? ");
        string goalDescription = Console.ReadLine();
        Console.Write("What is the amount of points associated with this goal? ");
        int goalPoints = int.Parse(Console.ReadLine());
        bool completionStatus = false;

        if (goalChoice == 1)
        {
            SimpleGoal simpleGoal = new SimpleGoal(goalName, goalDescription, goalPoints, completionStatus);
            _goalsList.Add(simpleGoal);
        }
        else if (goalChoice == 2)
        {
            EternalGoal eternalGoal = new EternalGoal(goalName, goalDescription, goalPoints);
            _goalsList.Add(eternalGoal);
        }
        else if (goalChoice == 3)
        {
            Console.Write("How many times does this goal need to be accomplished for a bonus? ");
            int bonusTargetCount = int.Parse(Console.ReadLine());
            Console.Write("What is the bonus for accomplishing it that many times? ");
            int bonusPoints = int.Parse(Console.ReadLine());

            ChecklistGoal checklistGoal = new ChecklistGoal(goalName, goalDescription, goalPoints, completionStatus, bonusPoints, bonusTargetCount, _bonusActualCount);
            _goalsList.Add(checklistGoal);
        }
        else
        {
            Console.WriteLine("Invalid choice.");
        }
    }

    private void ListGoals()
    {
        Console.WriteLine("The goals are:");
        for (int i = 0; i < _goalsList.Count; i++)
        {
            if (_goalsList[i] is ChecklistGoal checklistGoal)
            {
                Console.WriteLine($"{i + 1}. [{(_goalsList[i].IsComplete() ?? false ? "X" : " ")}] {_goalsList[i].GetName()} ({_goalsList[i].GetDescription()}) -- Currently Completed: {checklistGoal.BonusActualCount}/{checklistGoal.BonusTargetCount}");
            }
            else
            {
                Console.WriteLine($"{i + 1}. [{(_goalsList[i].IsComplete() ?? false ? "X" : " ")}] {_goalsList[i].GetName()} ({_goalsList[i].GetDescription()})");
            }
        }
    }

    private void RecordCompletedEvent()
    {
        DisplayGoals();

        Console.Write("Which goal did you accomplish? ");
        int accomplishedGoalIndex = int.Parse(Console.ReadLine());

        if (accomplishedGoalIndex > 0 && accomplishedGoalIndex <= _goalsList.Count)
        {
            GoalBase accomplishedGoal = _goalsList[accomplishedGoalIndex - 1];
            int pointsEarned = accomplishedGoal.RecordEvent();

            Console.WriteLine($"Congratulations! You have earned {pointsEarned} points!");

            // Update and display the correct total points
            _userPoints += pointsEarned;
            Console.WriteLine($"You now have {_userPoints} total points.");
        }
        else
        {
            Console.WriteLine("Invalid goal selection.");
        }
    }

    public void DisplayGoals()
    {
        Console.WriteLine($"The goals are:");
        for (int i = 0; i < _goalsList.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goalsList[i].GetName()}");
        }
    }

    private void SaveGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string saveName = Console.ReadLine();
        SaveLoad saveFile = new SaveLoad();
        saveFile.SaveData(saveName, _userPoints, _goalsList);
    }

    private void LoadGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string loadName = Console.ReadLine();
        SaveLoad saveLoad = new SaveLoad();
        saveLoad.LoadData(loadName, ref _userPoints, _goalsList, this);
    }
}