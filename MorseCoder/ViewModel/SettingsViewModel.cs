using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using MorseCoder.Interfaces;
using MorseCoder.Messaging;
using MorseCoder.PCL;

namespace MorseCoder.ViewModel
{
    public class SettingsViewModel : ViewModelBase
    {
        private IMorseCoderSettings _morseCoderSettings;
        private INavigationService _navigationService;

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

        public SettingsViewModel(IMorseCoderSettings morseCoderSettings, INavigationService navigationService)
        {
            _morseCoderSettings = morseCoderSettings;
            _navigationService = navigationService;

            _currentTranslationDirection = morseCoderSettings.Direction;
                        
            MorseToAlphabetCommand = new RelayCommand(MorseToAlphabetCommandAction);
            AlphabetToMorseCommand = new RelayCommand(AlphabetToMorseCommandAction);
            BackNavigationCommand = new RelayCommand(BackNavigationCommandAction);
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

        public RelayCommand BackNavigationCommand { get; private set; }

        private void BackNavigationCommandAction()
        {
            _navigationService.GoBack();
        }

        private void SetTranslationDirection(TranslationDirection translationDirection)
        {
            _morseCoderSettings.Direction = translationDirection;

            CurrentTranslationDirection = _morseCoderSettings.Direction;

            var settingsChangedMessage = new SettingsChangedMessage(CurrentTranslationDirection);
            MessengerInstance.Send(settingsChangedMessage);
        }       
    }
}
