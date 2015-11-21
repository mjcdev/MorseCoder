using MorseCoder.PCL;
using MorseCoder.PCL.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace MorseCoder.Converters
{
    public class TranslationDirectionToDisplayConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value is TranslationDirection)
            {                
                var member = typeof(TranslationDirection).GetMember(value.ToString());
                var attributes =  member.First().GetCustomAttributes(typeof(DisplayAttribute), false);
                return ((DisplayAttribute)attributes.First()).DisplayString;
            }
            return new InvalidCastException("Input value not of type TranslationDirection");
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
