using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using MorseCoder.Interfaces;
using MorseCoder.PCL;
using MorseCoder.PCL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Windows.UI;
using Windows.UI.Xaml.Media;

namespace MorseCoder.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private ITranslator _translator;
        private IMorseCoderSettings _morseCoderSettings;

        private string _translation;
        private string _input;
        private TranslationDirection _direction;
        private Brush _backgroundBrush;

        public string Translation
        {
            get
            {
                return _translation;
            }
            set
            {
                Set(() => Translation, ref _translation, value);
            }
        }

        public string Input
        {
            get
            {
                return _input;
            }
            set
            {
                Translation = _translator.Translate(value);
                Set(() => Input, ref _input, value);
                _morseCoderSettings.Input = value;
            }
        }

        public Brush BackgroundBrush
        {
            get
            {
                return _backgroundBrush;
            }

            set
            {
                Set(() => BackgroundBrush, ref _backgroundBrush, value);
            }
        }

        public MainViewModel(IMorseCoderSettings morseCoderSettings)
        {
            _morseCoderSettings = morseCoderSettings;

            _input = _morseCoderSettings.Input;
            _direction = morseCoderSettings.Direction;

            DotCommand = new RelayCommand(DotCommandAction);
            DashCommand = new RelayCommand(DashCommandAction);
            SpaceCommand = new RelayCommand(SpaceCommandAction);

            switch (_direction)
            {
                case TranslationDirection.AlphabetToMorse:
                    _translator = new AlphabetToMorseTranslator();
                    BackgroundBrush = new SolidColorBrush(Colors.CadetBlue);
                    break;
                case TranslationDirection.MorseToAlphabet:
                    _translator = new MorseToAlphabetTranslator();
                    BackgroundBrush = new SolidColorBrush(Colors.Crimson);
                    break;
            }

            Translation = _translator.Translate(Input);                
        }

        public RelayCommand DotCommand { get; private set; }

        private void DotCommandAction()
        {
            Input += ".";
        }

        public RelayCommand DashCommand { get; private set; }

        private void DashCommandAction()
        {
            Input += "-";
        }

        public RelayCommand SpaceCommand { get; private set; }

        private void SpaceCommandAction()
        {
            Input += " ";
        }
    }
}
