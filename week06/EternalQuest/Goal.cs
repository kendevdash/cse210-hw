using System;

public abstract class Goal
{
    private readonly string _name;
    private readonly int _points;

    protected Goal(string name, int points)
    {
        _name = name;
        _points = points;
    }

    public string Name => _name;
    public int Points => _points;

    public abstract bool IsComplete { get; }

    // Records that the goal was worked on and returns the points earned.
    // Each goal type decides differently how many points that is.
    public abstract int RecordEvent();

    // Human-readable line shown in the goal list.
    public abstract string GetDetailsString();

    // Machine-readable line used when saving to a file.
    public abstract string GetStringRepresentation();
}
