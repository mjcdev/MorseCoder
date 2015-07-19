using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using MorseCoder.PCL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MorseCoder.PCL.Test.TranslatorTests
{
    [TestClass]
    public class AlphabetToMorseTranslatorTests
    {
        [TestMethod]
        public void Translate_SingleCharacter_InDictionary()
        {
            ITranslator translator = new AlphabetToMorseTranslator();
            
            var expected = ".- ";

            var actual = translator.Translate("A");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Translate_SingleCharacter_NotInDictionary()
        {
            ITranslator translator = new AlphabetToMorseTranslator();

            var expected = "~ ";

            var actual = translator.Translate("~");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Translate_HelloWorld()
        {
            ITranslator translator = new AlphabetToMorseTranslator();

            var expected = ".... . .-.. .-.. --- / .-- --- .-. .-.. -.. ";

            var actual = translator.Translate("HELLO WORLD");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Translate_Mix()
        {
            ITranslator translator = new AlphabetToMorseTranslator();

            var expected = ".- -... -.-. ~ -.. . ..-. ";

            var actual = translator.Translate("ABC~DEF");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Translate_Case()
        {
            ITranslator translator = new AlphabetToMorseTranslator();

            var expected = ".- -... -.-. ";

            var actualLower = translator.Translate("abc");
            var actualUpper = translator.Translate("ABC");

            Assert.AreEqual(expected, actualLower);
            Assert.AreEqual(expected, actualUpper);
        }
    }
}
