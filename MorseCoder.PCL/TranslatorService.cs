using MorseCoder.PCL.Interfaces;
using System.Collections.Generic;

namespace MorseCoder.PCL
{
    public class TranslatorService : ITranslatorService
    {
        private IDictionary<string, ITranslator> translators = new Dictionary<string, ITranslator>();

        public ICollection<string> TranslatorKeys
        {
            get
            {
                return translators.Keys;
            }
        }

        public void AddTranslator(string translatorKey, ITranslator translator)
        {
            translators.Add(translatorKey, translator);
        }

        public string Translate(string translatorKey, string input)
        {
            return translators[translatorKey].Translate(input);
        }
    }
}
