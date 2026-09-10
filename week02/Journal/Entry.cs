public class Entry
{
    public string _date;
    public string _prompt;
    public string _response;

    // The Entry is responsible for showing itself, so this code is not
    // repeated everywhere an entry needs to be printed.
    public void Display()
    {
        Console.WriteLine($"Date: {_date}");
        Console.WriteLine($"Prompt: {_prompt}");
        Console.WriteLine($"Response: {_response}");
        Console.WriteLine();
    }
}
