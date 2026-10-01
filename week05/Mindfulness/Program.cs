/*
 * ============================================================================
 *  MINDFULNESS PROGRAM  -  CSE 210  -  Week 05
 * ============================================================================
 *
 *  CORE REQUIREMENTS
 *    - An Activity base class holds the behavior shared by every activity:
 *      the starting/ending messages, the duration prompt, and the spinner
 *      and countdown animations.
 *    - BreathingActivity, ReflectionActivity, and ListingActivity each
 *      inherit from Activity and add only what's unique to that activity,
 *      so the shared behavior is written once, not duplicated three times.
 *    - Reflection and Listing randomly select from a list of prompts
 *      (and, for Reflection, questions) each run.
 *    - A menu loop lets the user run any activity repeatedly or quit.
 *
 *  CREATIVITY / EXCEEDS CORE REQUIREMENTS
 *    1. Session summary: the program tracks every activity completed
 *       during the run (name + duration) and prints a summary with the
 *       total mindfulness time when the user quits (Program.Main).
 *    2. Expanded prompt/question pools: 8 reflection prompts, 9 reflection
 *       questions, and 10 listing prompts, so repeat sessions feel varied
 *       rather than repeating the same handful of items.
 * ============================================================================
 */

class Program
{
    static void Main(string[] args)
    {
        List<string> sessionLog = new List<string>();
        int totalSeconds = 0;

        while (true)
        {
            Console.Clear();

            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Start breathing activity");
            Console.WriteLine("  2. Start reflecting activity");
            Console.WriteLine("  3. Start listing activity");
            Console.WriteLine("  4. Quit");
            Console.Write("Select a choice from the menu: ");

            string choice = Console.ReadLine();

            if (choice == "1")
            {
                BreathingActivity activity = new BreathingActivity();
                activity.Run();
                sessionLog.Add($"{activity.GetName()}: {activity.GetDuration()} seconds");
                totalSeconds += activity.GetDuration();
            }
            else if (choice == "2")
            {
                ReflectionActivity activity = new ReflectionActivity();
                activity.Run();
                sessionLog.Add($"{activity.GetName()}: {activity.GetDuration()} seconds");
                totalSeconds += activity.GetDuration();
            }
            else if (choice == "3")
            {
                ListingActivity activity = new ListingActivity();
                activity.Run();
                sessionLog.Add($"{activity.GetName()}: {activity.GetDuration()} seconds");
                totalSeconds += activity.GetDuration();
            }
            else if (choice == "4")
            {
                Console.WriteLine();

                if (sessionLog.Count > 0)
                {
                    Console.WriteLine("Session Summary:");
                    foreach (string entry in sessionLog)
                    {
                        Console.WriteLine($" - {entry}");
                    }
                    Console.WriteLine($"Total mindfulness time this session: {totalSeconds} seconds");
                    Console.WriteLine();
                }

                Console.WriteLine("Thank you for using the Mindfulness Program.");
                break;
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("Invalid choice. Please select 1, 2, 3, or 4.");
                Console.WriteLine();
                Console.WriteLine("Press Enter to continue.");
                Console.ReadLine();
            }
        }
    }
}
