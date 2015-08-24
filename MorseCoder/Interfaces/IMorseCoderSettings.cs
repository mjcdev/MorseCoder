using MorseCoder.PCL;
using System;
using System.Collections.Generic;
using System.Text;

namespace MorseCoder.Interfaces
{
    public interface IMorseCoderSettings
    {
        string Input { get; set; }

        TranslationDirection Direction { get; set; }
    }
}
