using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using MorseCoder.PCL;
using MorseCoder.PCL.Interfaces;
using MorseCoder.Windows.Test.TranslatorServiceTests.Translators;
using System;
using System.Collections.Generic;

namespace MorseCoder.Windows.Test.TranslatorServiceTests
{
    [TestClass]
    public class TranslatorServiceTests
    {
        [TestMethod]
        public void TranslatorService_EmptyDictionary()
        {
            ITranslatorService translatorService = new TranslatorService();

            Assert.ThrowsException<KeyNotFoundException>(() => translatorService.Translate("Invalid Key", " "));
        }

        [TestMethod]
        public void TranslatorService_PopulatedDictionaryInvalidKey()
        {
            ITranslatorService translatorService = BuildTestTranslatorService();
            
            Assert.ThrowsException<KeyNotFoundException>(() => translatorService.Translate("Invalid Key", " "));
        }
        
        [TestMethod]
        public void TranslatorService_PassThrough()
        {
            ITranslatorService translatorService = BuildTestTranslatorService();
            const string passThrough = "Pass Through!";

            var response = translatorService.Translate(TranslatorKeys.PassThrough, passThrough);

            Assert.AreEqual(passThrough, response);
        }

        [TestMethod]
        public void TranslatorService_DummyResponse()
        {
            ITranslatorService translatorService = BuildTestTranslatorService();
            const string dummyResponse = "DummyResponse";

            var response = translatorService.Translate(TranslatorKeys.DummyResponse, "Whatever you like");

            Assert.AreEqual(dummyResponse, response);
        }

        [TestMethod]
        public void TranslatorService_AddTranslator()
        {
            var translatorService = new TranslatorService();

            translatorService.AddTranslator(TranslatorKeys.PassThrough, new PassThroughTranslator());

            Assert.IsTrue(translatorService.TranslatorKeys.Contains(TranslatorKeys.PassThrough));            
        }

        [TestMethod]
        public void TranslatorService_AddTranslatorDuplicateKey()
        {
            var translatorService = new TranslatorService();

            translatorService.AddTranslator(TranslatorKeys.PassThrough, new PassThroughTranslator());

            Assert.ThrowsException<ArgumentException>(() => translatorService.AddTranslator(TranslatorKeys.PassThrough, new PassThroughTranslator()));
        }
        
        private ITranslatorService BuildTestTranslatorService()
        {
            var translatorService = new TranslatorService();

            translatorService.AddTranslator(TranslatorKeys.PassThrough, new PassThroughTranslator());
            translatorService.AddTranslator(TranslatorKeys.DummyResponse, new DummyResponseTranslator());

            return translatorService;
        }
    }
}
