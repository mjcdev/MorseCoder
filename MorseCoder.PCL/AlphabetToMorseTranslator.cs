using MorseCoder.PCL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MorseCoder.PCL
{
    public class AlphabetToMorseTranslator : ITranslator
    {
        private IList<Lookup> _dictionary;
        
        public AlphabetToMorseTranslator()
        {
            _dictionary = Lookup.PopulateDictionary();
        }

        public string Translate(string input)
        {
            var upper = input.ToUpper();
            var charArray = upper.ToCharArray();

            StringBuilder stringBuilder = new StringBuilder();

            foreach (var charInput in charArray)
            {
                stringBuilder.Append(CharToMorse(charInput));
                stringBuilder.Append(" ");
            }

            return stringBuilder.ToString();
        }

        private string CharToMorse(char input)
        {
            var lookup = _dictionary.Where(a => a.Alphabet == input).FirstOrDefault();
                
            if (lookup != null)
            {
                return lookup.Morse;
            }
            else
            {
                return input.ToString();
            }            
        }

        public TranslationDirection Direction
        {
            get { return TranslationDirection.AlphabetToMorse; }
        }
    }
}
