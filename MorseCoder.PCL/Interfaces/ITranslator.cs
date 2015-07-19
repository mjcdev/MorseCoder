using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MorseCoder.PCL.Interfaces
{
    public interface ITranslator
    {
        string Translate(string input);

        TranslationDirection Direction { get; }
    }
}
