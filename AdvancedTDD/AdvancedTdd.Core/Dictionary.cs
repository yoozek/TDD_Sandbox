using System.Collections.Generic;
using System.Linq;

namespace AdvancedTdd.Core
{
    public class Dictionary
    {
        private readonly Dictionary<string, Dictionary<string, string>> _translations;
        public string Name { get; }

        public Dictionary(string name)
        {
            _translations = new Dictionary<string, Dictionary<string, string>>();
            Name = name;
        }

        public Dictionary(IDictionaryParser dictionaryParser)
        {
            _translations = dictionaryParser.GetTranslations();
            Name = dictionaryParser.GetName();
        }

        public void AddTranslation(string word1, string word2)
        {
            if (!_translations.ContainsKey(word1))
            {
                _translations.Add(word1, new Dictionary<string, string>{{word2, word1}});
            }
            else
            {
                _translations[word1].Add(word2, word1);
            }
        }

        public string[] GetTranslation(string word)
        {
            if (_translations.ContainsKey(word))
            {
                return _translations[word].Keys.ToArray();
            }
            else
            {
                return (from t in _translations
                    from v in t.Value.Values
                    where t.Value.ContainsKey(word)
                    select v).Distinct().ToArray();
            }
        }

        public bool IsEmpty()
        {
            return _translations.Count == 0;
        }
    }
}