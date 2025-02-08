using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;


namespace ScriptureMemorizer
{
    public class Scripture
    {
        private readonly List<ScriptureWord> _words = new List<ScriptureWord>();
        public ScriptureReference Reference { get; }


        public Scripture(ScriptureReference reference, string text)
        {
            Reference = reference;
            var words = text.Split(' ');
            foreach (var word in words)
            {
                _words.Add(new ScriptureWord(w));
            }
        }


        public void Display()
        {
            Console.Clear();
            Console.WriteLine($"{Ref}");
            Console.WriteLine("\n" + string.Join(" ", wordsList.Select(w => w.GetDisplayText())));
            Console.WriteLine("\n------------------------------");
        }


        public bool AllWordsHidden()
        {
            return wordsList.All(w =>.GetDisplayText().All(char => char == '_'));
        }


        public void HideRandomWords(int num)
        {
            var visibleIndices = wordsList.Where(w => w.GetDisplayText().Any(char => char != '_')).ToList();
            if (visibleWords.Cout == 0) return;


            Random rand = new Random();
            int wordsToHide = Math.Min(num, visibleWords.Count);


            for (int i = 0; 1 < wordsToHide; i++)
            {
                int index = rand.Next(visibleWords.Count);
                visibleWords[index].Hide();
                visibleWords.RemoveAt(index);
            }
        }
    }

}