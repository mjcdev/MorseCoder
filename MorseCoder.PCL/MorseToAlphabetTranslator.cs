using MorseCoder.PCL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MorseCoder.PCL
{
    public class MorseToAlphabetTranslator : ITranslator
    {
        private IList<Lookup> _dictionary;

        public MorseToAlphabetTranslator()
        {
            _dictionary = Lookup.PopulateDictionary();
        }

        public string Translate(string input)
        {
            var split = input.Split(new char[] { ' ' });  

            string output = string.Empty;

            foreach (var stringInput in split)
            {
                output += MorseToChar(stringInput);
            }
            
            return output;
        }

        private string MorseToChar(string input)
        {
            var lookup = _dictionary.Where(a => a.Morse == input).FirstOrDefault();

            if (lookup != null)
            {
                return lookup.Alphabet.ToString();
            }
            else
            {
                return input.ToString();
            }
        }

        public TranslationDirection Direction
        {
            get { return TranslationDirection.MorseToAlphabet; }
        }
    }
}
