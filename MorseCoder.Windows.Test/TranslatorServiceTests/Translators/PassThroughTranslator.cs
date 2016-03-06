using MorseCoder.PCL.Interfaces;
using System;
using MorseCoder.PCL;

namespace MorseCoder.Windows.Test.TranslatorServiceTests.Translators
{
    public class PassThroughTranslator : ITranslator
    {
        public TranslationDirection Direction
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public string Translate(string input)
        {
            return input;
        }
    }
}
