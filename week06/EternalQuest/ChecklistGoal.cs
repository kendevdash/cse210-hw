public class ChecklistGoal : Goal
{
    private int _amountCompleted;
    private readonly int _target;
    private readonly int _bonus;

    public ChecklistGoal(string name, int points, int target, int bonus, int amountCompleted = 0)
        : base(name, points)
    {
        _target = target;
        _bonus = bonus;
        _amountCompleted = amountCompleted;
    }

    public override bool IsComplete => _amountCompleted >= _target;

    public override int RecordEvent()
    {
        if (IsComplete)
        {
            return 0;
        }

        _amountCompleted++;

        if (IsComplete)
        {
            return Points + _bonus;
        }

        return Points;
    }

    public override string GetDetailsString()
    {
        string mark = IsComplete ? "X" : " ";
        return $"[{mark}] {Name} ({Points} points) -- Completed {_amountCompleted}/{_target}";
    }

    public override string GetStringRepresentation()
    {
        return $"ChecklistGoal:{Name},{Points},{_target},{_bonus},{_amountCompleted}";
    }
}
