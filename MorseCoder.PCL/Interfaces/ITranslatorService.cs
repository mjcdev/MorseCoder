using System.Collections.Generic;

namespace MorseCoder.PCL.Interfaces
{
    public interface ITranslatorService
    {
        void AddTranslator(string translatorKey, ITranslator translator);

        ICollection<string> TranslatorKeys { get; }

        string Translate(string translatorKey, string input);
    }
}
