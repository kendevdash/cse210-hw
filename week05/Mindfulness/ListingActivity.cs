public class ListingActivity : Activity
{
    private List<string> _prompts;
    private Random _random;

    public ListingActivity()
        : base(
            "Listing Activity",
            "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
    {
        _random = new Random();

        _prompts = new List<string>
        {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?",
            "What are some things you are grateful for?",
            "What are some things that make you happy?",
            "What are some goals you are working toward?",
            "What are some talents or skills you have?",
            "What are some positive experiences you had this week?"
        };
    }

    public void Run()
    {
        DisplayStartingMessage();

        Console.WriteLine();
        Console.WriteLine("List as many responses as you can to the following prompt:");
        Console.WriteLine();

        string prompt = _prompts[_random.Next(_prompts.Count)];
        Console.WriteLine($"--- {prompt} ---");
        Console.WriteLine();

        Console.WriteLine("You may begin in:");
        ShowCountDown(5);
        Console.WriteLine();
        Console.WriteLine();

        List<string> answers = new List<string>();
        DateTime endTime = DateTime.Now.AddSeconds(GetDuration());

        while (DateTime.Now < endTime)
        {
            Console.Write("> ");
            string answer = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(answer))
            {
                answers.Add(answer);
            }
        }

        Console.WriteLine();
        Console.WriteLine($"You listed {answers.Count} items.");
        Console.WriteLine();

        DisplayEndingMessage();
    }
}
