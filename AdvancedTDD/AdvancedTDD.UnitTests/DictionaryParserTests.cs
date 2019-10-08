using System.Collections.Generic;
using System.Linq;
using AdvancedTdd.Core;
using Moq;
using Xunit;

namespace AdvancedTDD.UnitTests
{
    public class DictionaryParserTests
    {
        [Fact]
        public void TestEmptyFileName()
        {
            var mockDictionaryLoader = new Mock<IDictionaryLoader>();
            mockDictionaryLoader
                .Setup(dl => dl.GetLines())
                .Returns(new string[] { });
            
            var dictionaryParser = new DictionaryParser(mockDictionaryLoader.Object);
            
            Assert.Equal(string.Empty, dictionaryParser.GetName());
        }

        [Fact]
        public void TestEmptyFileTranslations()
        {
            var mockDictionaryLoader = new Mock<IDictionaryLoader>();
            mockDictionaryLoader
                .Setup(dl => dl.GetLines())
                .Returns(new string[] { });

            var dictionaryParser = new DictionaryParser(mockDictionaryLoader.Object);

            Assert.Equal(new Dictionary<string, Dictionary<string, string>>(), dictionaryParser.GetTranslations());
        }

        [Fact]
        public void TestDictionaryName()
        {
            var mockDictionaryLoader = new Mock<IDictionaryLoader>();
            mockDictionaryLoader
                .Setup(dl => dl.GetLines())
                .Returns(new string[] {"en-fr"});

            var dictionaryParser = new DictionaryParser(mockDictionaryLoader.Object);
            
            Assert.Equal("en-fr", dictionaryParser.GetName());
        }
    }
}