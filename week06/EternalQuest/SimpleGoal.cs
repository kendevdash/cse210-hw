public class SimpleGoal : Goal
{
    private bool _isComplete;

    public SimpleGoal(string name, int points, bool isComplete = false) : base(name, points)
    {
        _isComplete = isComplete;
    }

    public override bool IsComplete => _isComplete;

    public override int RecordEvent()
    {
        if (_isComplete)
        {
            return 0;
        }

        _isComplete = true;
        return Points;
    }

    public override string GetDetailsString()
    {
        string mark = _isComplete ? "X" : " ";
        return $"[{mark}] {Name} ({Points} points)";
    }

    public override string GetStringRepresentation()
    {
        return $"SimpleGoal:{Name},{Points},{_isComplete}";
    }
}
