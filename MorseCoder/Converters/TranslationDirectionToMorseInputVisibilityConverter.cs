using MorseCoder.PCL;
using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace MorseCoder.Converters
{
    public class TranslationDirectionToMorseInputVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value is TranslationDirection)
            {
                switch ((TranslationDirection)value)
                {
                    case TranslationDirection.AlphabetToMorse:
                        return Visibility.Collapsed;
                    case TranslationDirection.MorseToAlphabet:
                        return Visibility.Visible;
                    default:
                        return Visibility.Visible;
                }
            }
            return new InvalidCastException("Input value not of type TranslationDirection");
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
