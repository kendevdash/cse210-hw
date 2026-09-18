/*
 * ============================================================================
 *  SCRIPTURE MEMORIZER  -  CSE 210  -  Week 03
 * ============================================================================
 *
 *  CORE REQUIREMENTS
 *    - A Reference class stores the book/chapter/verse (or verse range) and
 *      displays itself, e.g. "John 3:16" or "Proverbs 3:5-6". It has two
 *      constructors: one for a single verse, one for a verse range.
 *    - A Word class tracks whether a single word is hidden and displays
 *      itself as the word or as underscores when hidden.
 *    - A Scripture class ties a Reference to a list of Words, can hide a
 *      given number of not-yet-hidden words at random, and reports once
 *      every word is hidden.
 *    - The program displays the scripture, then repeatedly hides more words
 *      each time the user presses Enter, clearing the screen between
 *      rounds, until every word is hidden or the user types "quit".
 *
 *  CREATIVITY / EXCEEDS CORE REQUIREMENTS
 *    1. Scripture library: a small list of scriptures is built in, and one
 *       is chosen at random each time the program starts (Program.Main).
 *    2. Punctuation-preserving hiding: only letters/digits turn into
 *       underscores, so "life." becomes "____." instead of "_____",
 *       keeping punctuation as a memory cue (Word.GetDisplayText).
 *    3. Progress indicator: after each round the program reports how many
 *       of the verse's words are still hidden, e.g. "14 of 27 words
 *       hidden." (Scripture.GetHiddenWordCount).
 * ============================================================================
 */

class Program
{
    static void Main(string[] args)
    {
        List<Scripture> scriptures = new List<Scripture>
        {
            new Scripture(
                new Reference("John", 3, 16),
                "For God so loved the world that he gave his only begotten Son that whoever believes in him should not perish but have eternal life."
            ),
            new Scripture(
                new Reference("Proverbs", 3, 5, 6),
                "Trust in the Lord with all your heart and lean not on your own understanding. In all your ways acknowledge him and he will make your paths straight."
            ),
            new Scripture(
                new Reference("Philippians", 4, 13),
                "I can do all things through Christ who strengthens me."
            )
        };

        Random random = new Random();
        Scripture scripture = scriptures[random.Next(scriptures.Count)];

        Console.Clear();
        Console.WriteLine(scripture.GetDisplayText());

        while (!scripture.AllWordsHidden())
        {
            Console.WriteLine();
            Console.Write("Press Enter to hide more words, or type \"quit\" to quit: ");
            string input = Console.ReadLine();

            if (input != null && input.Trim().ToLower() == "quit")
            {
                break;
            }

            scripture.HideRandomWords(3);

            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine($"{scripture.GetHiddenWordCount()} of {scripture.GetWordCount()} words hidden.");
        }
    }
}
