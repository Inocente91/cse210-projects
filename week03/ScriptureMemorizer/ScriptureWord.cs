namespace ScriptureMemorizer
{
    public class ScriptureWord
    {
        private string _text;
        private bool _isHidden;

        public ScriptureWord(string text)
        {
            _text = text;
            _isHidden = false;
        }

        public void Hide()
        {
            _isHidden = true;
        }

        public string GetDisplayText()
        {
            return _isHidden ? new string('_', _text.Length) : _text;
        }
    }
}
