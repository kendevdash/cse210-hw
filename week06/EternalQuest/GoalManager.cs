using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private const int _pointsPerLevel = 500;

    private readonly List<Goal> _goals = new List<Goal>();
    private int _score;

    public void Start()
    {
        bool running = true;

        while (running)
        {
            DisplayStatus();
            DisplayMenu();

            string choice = (Console.ReadLine() ?? "").Trim();
            Console.WriteLine();

            switch (choice)
            {
                case "1":
                    CreateGoal();
                    break;
                case "2":
                    ListGoals();
                    break;
                case "3":
                    SaveGoals();
                    break;
                case "4":
                    LoadGoals();
                    break;
                case "5":
                    RecordEvent();
                    break;
                case "6":
                    running = false;
                    break;
                default:
                    Console.WriteLine("That is not a valid menu option. Please try again.");
                    break;
            }
        }

        Console.WriteLine("Goodbye! Keep chasing your Eternal Quest.");
    }

    private int CurrentLevel(int score) => (score / _pointsPerLevel) + 1;

    private void DisplayStatus()
    {
        int level = CurrentLevel(_score);
        int pointsToNextLevel = (level * _pointsPerLevel) - _score;

        Console.WriteLine();
        Console.WriteLine($"Score: {_score}");
        Console.WriteLine($"Level: {level}  (Next level in {pointsToNextLevel} points)");
    }

    private void DisplayMenu()
    {
        Console.WriteLine();
        Console.WriteLine("Menu Options:");
        Console.WriteLine("  1. Create New Goal");
        Console.WriteLine("  2. List Goals");
        Console.WriteLine("  3. Save Goals");
        Console.WriteLine("  4. Load Goals");
        Console.WriteLine("  5. Record Event");
        Console.WriteLine("  6. Quit");
        Console.Write("Select a choice from the menu: ");
    }

    private void CreateGoal()
    {
        Console.WriteLine("The types of Goals are:");
        Console.WriteLine("  1. Simple Goal (completed once)");
        Console.WriteLine("  2. Eternal Goal (never ends, recorded repeatedly)");
        Console.WriteLine("  3. Checklist Goal (completed after a set number of times, with a bonus)");
        Console.Write("Which type of goal would you like to create? ");
        string type = (Console.ReadLine() ?? "").Trim();

        Console.Write("What is the name of your goal? ");
        string name = (Console.ReadLine() ?? "").Trim();

        int points = ReadInt("How many points is this goal worth? ");

        Goal goal;
        switch (type)
        {
            case "1":
                goal = new SimpleGoal(name, points);
                break;
            case "2":
                goal = new EternalGoal(name, points);
                break;
            case "3":
                int target = ReadInt("How many times does this goal need to be completed? ");
                int bonus = ReadInt("What is the bonus for completing it that many times? ");
                goal = new ChecklistGoal(name, points, target, bonus);
                break;
            default:
                Console.WriteLine("That is not a valid goal type. No goal was created.");
                return;
        }

        _goals.Add(goal);
        Console.WriteLine("Goal created!");
    }

    private void ListGoals()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("You have no goals yet. Create one from the menu!");
            return;
        }

        Console.WriteLine("Your goals are:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }
    }

    private void RecordEvent()
    {
        ListGoals();
        if (_goals.Count == 0)
        {
            return;
        }

        int index = ReadInt("Which goal did you accomplish? ") - 1;

        if (index < 0 || index >= _goals.Count)
        {
            Console.WriteLine("That is not a valid goal number.");
            return;
        }

        int previousLevel = CurrentLevel(_score);
        int pointsEarned = _goals[index].RecordEvent();
        _score += pointsEarned;

        if (pointsEarned > 0)
        {
            Console.WriteLine($"Congratulations! You earned {pointsEarned} points!");
        }
        else
        {
            Console.WriteLine("That goal has already been completed.");
        }

        // Creativity feature: a level-up celebration every 500 points.
        int newLevel = CurrentLevel(_score);
        if (newLevel > previousLevel)
        {
            Console.WriteLine();
            Console.WriteLine("*** LEVEL UP! ***");
            Console.WriteLine($"You reached Level {newLevel}!");
        }
    }

    private void SaveGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string filename = (Console.ReadLine() ?? "").Trim();
        if (filename.Length == 0)
        {
            filename = "goals.txt";
        }

        using (StreamWriter writer = new StreamWriter(filename))
        {
            writer.WriteLine(_score);
            foreach (Goal goal in _goals)
            {
                writer.WriteLine(goal.GetStringRepresentation());
            }
        }

        Console.WriteLine("Goals saved!");
    }

    private void LoadGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string filename = (Console.ReadLine() ?? "").Trim();
        if (filename.Length == 0)
        {
            filename = "goals.txt";
        }

        if (!File.Exists(filename))
        {
            Console.WriteLine("That file does not exist.");
            return;
        }

        string[] lines = File.ReadAllLines(filename);
        if (lines.Length == 0 || !int.TryParse(lines[0], out int loadedScore))
        {
            Console.WriteLine("That file is not a valid goals file.");
            return;
        }

        List<Goal> loadedGoals = new List<Goal>();

        for (int i = 1; i < lines.Length; i++)
        {
            if (lines[i].Length == 0)
            {
                continue;
            }

            string[] parts = lines[i].Split(':', 2);
            string goalType = parts[0];
            string[] data = parts[1].Split(',');

            switch (goalType)
            {
                case "SimpleGoal":
                    loadedGoals.Add(new SimpleGoal(data[0], int.Parse(data[1]), bool.Parse(data[2])));
                    break;
                case "EternalGoal":
                    loadedGoals.Add(new EternalGoal(data[0], int.Parse(data[1]), int.Parse(data[2])));
                    break;
                case "ChecklistGoal":
                    loadedGoals.Add(new ChecklistGoal(
                        data[0], int.Parse(data[1]), int.Parse(data[2]), int.Parse(data[3]), int.Parse(data[4])));
                    break;
                default:
                    Console.WriteLine($"Skipping unrecognized goal type: {goalType}");
                    break;
            }
        }

        _goals.Clear();
        _goals.AddRange(loadedGoals);
        _score = loadedScore;

        Console.WriteLine("Goals loaded!");
    }

    private int ReadInt(string prompt)
    {
        Console.Write(prompt);
        int result;
        while (!int.TryParse(Console.ReadLine(), out result))
        {
            Console.Write("Please enter a whole number: ");
        }
        return result;
    }
}
