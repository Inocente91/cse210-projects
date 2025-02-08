using System;
using System.Collections.Generic;
using System.Linq;

namespace ScriptureMemorizer
{
    public class Scripture
    {
        private List<ScriptureWord> wordsList = new List<ScriptureWord>(); // using "wordsList" instead of "_words"
        public ScriptureReference Ref { get; }

        public Scripture(ScriptureReference reference, string text)
        {
            Ref = reference;
            string[] words = text.Split(' ');
            foreach (string w in words)
            {
                wordsList.Add(new ScriptureWord(w));
            }
        }

        public void Display()
        {
            Console.Clear();
            Console.WriteLine($"📖 {Ref}");
            Console.WriteLine("\n" + string.Join(" ", wordsList.Select(w => w.GetDisplayText())));
            Console.WriteLine("\n---------------------------");
        }

        public bool AllWordsHidden()
        {
            return wordsList.All(w => w.GetDisplayText().All(c => c == '_'));
        }

        public void HideRandomWords(int num)
        {
            var visibleWords = wordsList.Where(w => w.GetDisplayText().Any(c => c != '_')).ToList();
            if (visibleWords.Count == 0) return;

            Random rand = new Random();
            int wordsToHide = Math.Min(num, visibleWords.Count);

            for (int i = 0; i < wordsToHide; i++)
            {
                int index = rand.Next(visibleWords.Count);
                visibleWords[index].Hide();
                visibleWords.RemoveAt(index); // Remove to avoid hiding the same word again
            }
        }
    }
}
