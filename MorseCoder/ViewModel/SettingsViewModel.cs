using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using MorseCoder.Interfaces;
using MorseCoder.PCL;

namespace MorseCoder.ViewModel
{
    public class SettingsViewModel : ViewModelBase
    {
        private IMorseCoderSettings _morseCoderSettings;

        private TranslationDirection _currentTranslationDirection;

        public TranslationDirection CurrentTranslationDirection
        {
            get
            {
                return _currentTranslationDirection;
            }
            set
            {
                Set(() => CurrentTranslationDirection, ref _currentTranslationDirection, value);
            }
        }

        public SettingsViewModel(IMorseCoderSettings morseCoderSettings)
        {
            _morseCoderSettings = morseCoderSettings;

            _currentTranslationDirection = morseCoderSettings.Direction;
                        
            MorseToAlphabetCommand = new RelayCommand(MorseToAlphabetCommandAction);
            AlphabetToMorseCommand = new RelayCommand(AlphabetToMorseCommandAction);
        }

        public RelayCommand MorseToAlphabetCommand { get; private set; }

        private void MorseToAlphabetCommandAction()
        {
            SetTranslationDirection(TranslationDirection.MorseToAlphabet);
        }
        
        public RelayCommand AlphabetToMorseCommand { get; private set; } 

        private void AlphabetToMorseCommandAction()
        {
            SetTranslationDirection(TranslationDirection.AlphabetToMorse);
        }

        private void SetTranslationDirection(TranslationDirection translationDirection)
        {
            _morseCoderSettings.Direction = translationDirection;

            CurrentTranslationDirection = _morseCoderSettings.Direction;            
        }
    }
}
