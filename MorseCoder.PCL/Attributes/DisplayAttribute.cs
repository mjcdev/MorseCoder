using System;

namespace MorseCoder.PCL.Attributes
{
    public class DisplayAttribute : Attribute
    {
        public string DisplayString
        {
            get;
            private set;
        }

        public DisplayAttribute(string displayString)
        {
            DisplayString = displayString;
        }
    }
}
