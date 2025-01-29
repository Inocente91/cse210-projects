using System;

public class Program
{
    private static Journal _journal = new Journal();
    private static List<string> _prompts = new List<string>
    {
        "Who was the most interesting person I interacted with today?",
        "What was the best par of my day?",
        "How did I see the hand of the Lord in my life today?",
        "What was the strongest emotion I felt today?",
        "If I had one thing I could do over today, what would it be?"
    }:

    public static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the Journal");
            Console.WriteLine("3. Save the journal to a file");
            Console.WriteLine("Load the jorunal from a file");
            Console.WriteLine(" Exit");
            Console. Write("Choose an option: ");
            string choice = Console.ReadLine();
        }
    }








}