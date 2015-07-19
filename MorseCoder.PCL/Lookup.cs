using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MorseCoder.PCL
{
    public class Lookup
    {
        public char Alphabet;
        public string Morse;

        public Lookup(char alphabet, string morse)
        {
            Alphabet = alphabet;
            Morse = morse;
        }

        public static IList<Lookup> PopulateDictionary()
        {
            var dictionary = new List<Lookup>
            {
                new Lookup(' ', "/"),                
                new Lookup('A', ".-"),
                new Lookup('B', "-..."),
                new Lookup('C', "-.-."),
                new Lookup('D', "-.."),
                new Lookup('E', "."),
                new Lookup('F', "..-."),
                new Lookup('G', "--."),
                new Lookup('H', "...."),
                new Lookup('I', ".."),
                new Lookup('J', ".---"),
                new Lookup('K', "-.-"),
                new Lookup('L', ".-.."),
                new Lookup('M', "--"),
                new Lookup('N', "-."),
                new Lookup('O', "---"),
                new Lookup('P', ".--."),
                new Lookup('Q', "--.-"),
                new Lookup('R', ".-."),
                new Lookup('S', "..."),
                new Lookup('T', "-"),
                new Lookup('U', "..-"),
                new Lookup('V', "...-"),
                new Lookup('W', ".--"),
                new Lookup('X', "-..-"),
                new Lookup('Y', "-.--"),
                new Lookup('Z', "--.."),
                new Lookup('0', "-----"),
                new Lookup('1', ".----"),
                new Lookup('2', "..---"),
                new Lookup('3', "...--"),
                new Lookup('4', "....-"),
                new Lookup('5',"....."),
                new Lookup('6', "-...."),
                new Lookup('7', "--..."),
                new Lookup('8', "---.."),
                new Lookup('9', "----."),
                new Lookup('.', ".-.-.-"),
                new Lookup(',', "--..--"),
                new Lookup('?',"..--.."),
                new Lookup('\'', ".----."),
                new Lookup('!', "-.-.--"),
                new Lookup('/', "-.-.--"),
                new Lookup('(', "-.--."),
                new Lookup(')', "-.--.-"),
                new Lookup('&', ".-..."),
                new Lookup(':', "---..."),
                new Lookup(';', "-.-.-."),
                new Lookup('=', "-...-"),
                new Lookup('+', ".-.-."),
                new Lookup('-', "-....-"),
                new Lookup('_', "..--.-"),
                new Lookup('"', ".-..-."),
                new Lookup('$', "...-..-"),
                new Lookup('@', ".--.-.")
            };

            return dictionary;
        }
    }
}
