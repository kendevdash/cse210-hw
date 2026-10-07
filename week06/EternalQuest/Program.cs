using System;

// Creativity: I added a level-up system that rewards the user every time
// they reach another 500 points. This goes beyond the required goal
// tracking and scoring functionality (see GoalManager.RecordEvent).

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to Eternal Quest!");

        GoalManager manager = new GoalManager();
        manager.Start();
    }
}
