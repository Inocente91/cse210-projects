using System;


namespace ScriptureMemorizer
{
    public class ScriptureMemorizer
    {
        public string book;
        public string chapter;
        public string verseStart;
        public string verseEnd;


        public ScriptureReference(string b, string c, string vStart, string vEnd = null)
        {
            book = b;
            chapter = c;
            verseStart = vStart;
            verseEnd = vEnd;
        }


        public override string ToString()
        {
            return verseEnd != null ?
                $"{book} {chapter}:{verseStart}-{verseEnd}" :
                $"{book} {chapter}:{verseStart}";
        }
    }
}