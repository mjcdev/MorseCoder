using MorseCoder.PCL;

namespace MorseCoder.Messaging
{
    public class SettingsChangedMessage
    {
        public TranslationDirection TranslationDirection
        {
            get;
            private set;
        }

        public SettingsChangedMessage(TranslationDirection translationDirection)
        {
            TranslationDirection = translationDirection;
        }
    }
}
