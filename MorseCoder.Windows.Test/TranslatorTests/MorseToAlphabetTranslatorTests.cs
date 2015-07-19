using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using MorseCoder.PCL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MorseCoder.PCL.Test.TranslatorTests
{
    [TestClass]
    public class MorseToAlphabetTranslatorTests
    {
        [TestMethod]
        public void Translate_SingleCharacter_InDictionary()
        {
            ITranslator translator = new MorseToAlphabetTranslator();
            
            var expected = "A";

            var actual = translator.Translate(".- ");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Translate_SingleCharacter_NotInDictionary()
        {
            ITranslator translator = new MorseToAlphabetTranslator();

            var expected = ".-.--.-.-.-.-.-.--.";

            var actual = translator.Translate(".-.--.-.-.-.-.-.--.");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Translate_HelloWorld()
        {
            ITranslator translator = new MorseToAlphabetTranslator();

            var expected = "HELLO WORLD";

            var actual = translator.Translate(".... . .-.. .-.. --- / .-- --- .-. .-.. -.. ");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Translate_Mix()
        {
            ITranslator translator = new MorseToAlphabetTranslator();

            var expected = "ABC~DEF";

            var actual = translator.Translate(".- -... -.-. ~ -.. . ..-. ");

            Assert.AreEqual(expected, actual);
        }
    }
}
