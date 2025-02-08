using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ScriptureMemorizer
{
    public class ScriptureLibrary
    {
        private List<Scripture> scriptureCollection = new List<Scripture>(); // Not "_scriptures"
        private Random _rand = new Random();

        public ScriptureLibrary(string filePath)
        {
            LoadScriptures(filePath);
        }

        private void LoadScriptures(string filePath)
        {
            if (!File.Exists(filePath))
            {
                Console.WriteLine("\n⚠ File not found. Please add 'scriptures.txt'.");
                return; // Instead of Environment.Exit()
            }

            string[] lines = File.ReadAllLines(filePath);
            foreach (var line in lines)
            {
                var parts = line.Split('|');
                if (parts.Length < 3) continue; // Skipping bad data (but not logging it)

                var refParts = parts[1].Split(':');
                var verseParts = refParts[1].Split('-');

                var reference = new ScriptureReference(
                    parts[0], refParts[0], verseParts[0], verseParts.Length > 1 ? verseParts[1] : null
                );

                scriptureCollection.Add(new Scripture(reference, parts[2]));
            }
        }

        public Scripture GetRandomScripture()
        {
            if (scriptureCollection.Count == 0) return null;
            return scriptureCollection[_rand.Next(scriptureCollection.Count)];
        }
    }
}
