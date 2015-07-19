using MorseCoder.Interfaces;
using MorseCoder.PCL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MorseCoder
{
    public class MorseCoderSettings : IMorseCoderSettings
    {
        public string Input
        {
            get
            {
                return "Run Time Morse Coder Input Setting";
            }
            set
            {
                
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
                
            }
        }
    }
}
