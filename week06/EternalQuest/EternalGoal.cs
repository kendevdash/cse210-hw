public class EternalGoal : Goal
{
    private int _timesCompleted;

    public EternalGoal(string name, int points, int timesCompleted = 0) : base(name, points)
    {
        _timesCompleted = timesCompleted;
    }

    // An eternal goal is, by definition, never "done".
    public override bool IsComplete => false;

    public override int RecordEvent()
    {
        _timesCompleted++;
        return Points;
    }

    public override string GetDetailsString()
    {
        return $"[∞] {Name} ({Points} points each time) -- recorded {_timesCompleted} times";
    }

    public override string GetStringRepresentation()
    {
        return $"EternalGoal:{Name},{Points},{_timesCompleted}";
    }
}
