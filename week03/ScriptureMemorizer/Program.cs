using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        List<Scripture> scriptures = LoadScriptures("scriptures.txt");
        if (scriptures.Count == 0)
        {
            Console.WriteLine("No scriptures found in the file.");
            return;
        }

        Random random = new Random();
        Scripture selectedScripture = scriptures[random.Next(scriptures.Count)];

        while (true)
         {
            Console.Clear();
            Console.WriteLine(selectedScripture.GetDisplayText());
            if (selectedScripture.IsCompletelyHidden())
                break;

            Console.WriteLine("\nPress Enter to hide words or type 'quit' to exit:");
            string input = Console.ReadLine();
            if (input.ToLower() == "quit")
                break;

            selectedScripture.HideRandomWords(3);        
         }   
    }

    static List<Scripture> LoadScriptures(string filePath)
    {
        List<Scripture> scriptures = new List<Scripture>();
        if (!File.Exists(filePath))
            return scriptures;
    }

}

