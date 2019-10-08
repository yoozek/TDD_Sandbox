using System.Collections.Generic;

namespace AdvancedTdd.Core
{
    public interface IDictionaryParser
    {
        string GetName();
        Dictionary<string, Dictionary<string, string>> GetTranslations();
    }
}