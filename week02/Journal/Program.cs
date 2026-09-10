/*
 * ============================================================================
 *  JOURNAL PROGRAM  -  CSE 210  -  Week 02
 * ============================================================================
 *
 *  CORE REQUIREMENTS
 *    - Write a new entry: a random prompt, the user's response, and today's
 *      date are stored together as an Entry.
 *    - Display every entry with its date and prompt.
 *    - Save the whole journal to a file.
 *    - Load the whole journal from a file.
 *    - Entry and Journal are separate classes, each in its own file whose
 *      name matches the class name.
 *
 *  CREATIVITY / EXCEEDS CORE REQUIREMENTS  (rubric criterion 10)
 *    1. Search entries (menu option 5): shows every entry whose response
 *       contains a keyword typed by the user.
 *    2. Journal statistics (menu option 6): reports how many entries exist
 *       and the total number of words written across all responses.
 *    3. User-chosen file names: save and load ask for the file name instead
 *       of using one hard-coded name, so more than one journal can be kept.
 *    4. Crash-safe loading: loading a file that does not exist shows a
 *       friendly message instead of throwing an exception.
 * ============================================================================
 */

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        bool running = true;

        Console.WriteLine("Welcome to the Journal Program!");
        Console.WriteLine();

        while (running)
        {
            Console.WriteLine("Please select one of the following choices:");
            Console.WriteLine("  1. Write a new entry");
            Console.WriteLine("  2. Display the journal");
            Console.WriteLine("  3. Save the journal to a file");
            Console.WriteLine("  4. Load the journal from a file");
            Console.WriteLine("  5. Search the entries");
            Console.WriteLine("  6. Journal statistics");
            Console.WriteLine("  7. Quit");
            Console.Write("What would you like to do? ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    WriteNewEntry(journal);
                    break;
                case "2":
                    journal.Display();
                    break;
                case "3":
                    Console.Write("What is the file name? ");
                    string saveName = Console.ReadLine();
                    journal.SaveToFile(saveName);
                    break;
                case "4":
                    Console.Write("What is the file name? ");
                    string loadName = Console.ReadLine();
                    journal.LoadFromFile(loadName);
                    break;
                case "5":
                    Console.Write("Enter a keyword to search for: ");
                    string keyword = Console.ReadLine();
                    journal.SearchEntries(keyword);
                    break;
                case "6":
                    journal.ShowStatistics();
                    break;
                case "7":
                    running = false;
                    Console.WriteLine("Goodbye!");
                    break;
                default:
                    Console.WriteLine("Please choose a number from 1 to 7.");
                    break;
            }

            Console.WriteLine();
        }
    }

    static void WriteNewEntry(Journal journal)
    {
        Entry entry = new Entry();
        entry._prompt = journal.GetRandomPrompt();

        Console.WriteLine();
        Console.WriteLine(entry._prompt);
        Console.Write("> ");
        entry._response = Console.ReadLine();
        entry._date = DateTime.Now.ToShortDateString();

        journal.AddEntry(entry);
    }
}
