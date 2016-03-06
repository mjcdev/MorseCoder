using MorseCoder.PCL.Interfaces;
using System;
using MorseCoder.PCL;

namespace MorseCoder.Windows.Test.TranslatorServiceTests.Translators
{
    public class DummyResponseTranslator : ITranslator
    {
        private const string DummyResponse = "DummyResponse";

        public TranslationDirection Direction
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public string Translate(string input)
        {
            return DummyResponse;
        }
    }
}
