using MorseCoder.Interfaces;
using MorseCoder.PCL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace MorseCoder
{
    public class MorseCoderSettings : IMorseCoderSettings
    {
        private const string _inputKey = "Input";
        private const string _directionKey = "Direction";

        private const string _inputDefault = "Type your Morse Code Text Here!";
        private const TranslationDirection _directionDefault = TranslationDirection.AlphabetToMorse;

        ApplicationDataContainer localSettings = ApplicationData.Current.LocalSettings;

        public string Input
        {
            get
            {                
                if (localSettings.Values.ContainsKey(_inputKey))
                {
                    return (string)localSettings.Values[_inputKey];
                }
                return _inputDefault;
            }
            set
            {
                localSettings.Values[_inputKey] = value;
            }
        }

        public TranslationDirection Direction
        {
            get
            {                
                if (localSettings.Values.ContainsKey(_directionKey))
                {
                    return (TranslationDirection)localSettings.Values[_directionKey];
                }
                return _directionDefault;
            }
            set
            {
                localSettings.Values[_directionKey] = value;
            }
        }
    }
}
