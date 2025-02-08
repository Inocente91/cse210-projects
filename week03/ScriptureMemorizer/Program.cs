using System;

namespace ScriptureMemorizer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("📜 Welcome to the Scripture Memorizer!");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();

            ScriptureLibrary library = new ScriptureLibrary("scriptures.txt");
            Scripture scripture = library.GetRandomScripture();

            if (scripture == null)
            {
                Console.WriteLine("\n⚠ No scriptures found. Try adding some to 'scriptures.txt'.");
                return;
            }

            int round = 1;
            while (true)
            {
                scripture.Display();

                if (scripture.AllWordsHidden())
                {
                    Console.WriteLine("\n🎉 You memorized it! Well done!");
                    Console.WriteLine("Press any key to exit.");
                    Console.ReadKey();
                    break;
                }

                Console.Write("\nPress Enter to hide words or type 'quit' to exit: ");
                string input = Console.ReadLine().Trim().ToLower();

                if (input == "quit")
                {
                    Console.WriteLine("\n👋 Goodbye! Thanks for playing.");
                    break;
                }

                scripture.HideRandomWords(round < 3 ? 2 : 3); // Less optimized but natural
                round++;
            }
        }
    }
}


