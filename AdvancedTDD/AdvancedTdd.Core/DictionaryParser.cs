using System.Collections.Generic;

namespace AdvancedTdd.Core
{
    public class DictionaryParser
    {
        private readonly string[] _lines;

        public DictionaryParser(IDictionaryLoader dictionaryLoader)
        {
            _lines = dictionaryLoader.GetLines();
        }

        public string GetName()
        {
            return _lines.Length > 0 ? _lines[0] : string.Empty;
        }

        public Dictionary<string, Dictionary<string, string>> GetTranslations()
        {
            return new Dictionary<string, Dictionary<string, string>>();
        }
    }
}