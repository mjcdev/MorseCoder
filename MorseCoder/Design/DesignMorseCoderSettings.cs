using MorseCoder.Interfaces;
using MorseCoder.PCL;
using System;
using System.Collections.Generic;
using System.Text;

namespace MorseCoder.Design
{
    public class DesignMorseCoderSettings : IMorseCoderSettings
    {
        public string Input
        {
            get
            {
                return "Design Morse Coder Input Setting";
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public TranslationDirection Direction
        {
            get
            {
                return TranslationDirection.AlphabetToMorse;
            }
            set
            {
                throw new NotImplementedException();
            }
        }
    }
}
