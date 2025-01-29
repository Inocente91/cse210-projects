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
    }   
    }
