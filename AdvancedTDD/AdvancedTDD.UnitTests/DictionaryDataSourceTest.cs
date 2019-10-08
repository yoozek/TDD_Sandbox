using System.Collections.Generic;
using AdvancedTdd.Core;
using Moq;
using Xunit;

namespace AdvancedTDD.UnitTests
{
    public class DictionaryDataSourceTest
    {

        [Fact]
        public void TestEmptyFileName()
        {
            var mockDictionaryParser = new Mock<IDictionaryParser>();
            mockDictionaryParser
                .Setup(dp => dp.GetName())
                .Returns(string.Empty);

            var dict = new Dictionary(mockDictionaryParser.Object);
            Assert.Equal(dict.Name, string.Empty);
        }

        [Fact]
        public void TestEmptyFileTranslations()
        {
            var mockDictionaryParser = new Mock<IDictionaryParser>();
            mockDictionaryParser
                .Setup(dp => dp.GetTranslations())
                .Returns(new Dictionary<string, Dictionary<string, string>>());

            var dict = new Dictionary(mockDictionaryParser.Object);
            Assert.Equal(new string[] { }, dict.GetTranslation("against"));
        }

        [Fact]
        public void TestDictionaryName()
        {
            var mockDictionaryParser = new Mock<IDictionaryParser>();
            mockDictionaryParser
                .Setup(dp => dp.GetName())
                .Returns("en-fr");

            var dict = new Dictionary(mockDictionaryParser.Object);
            Assert.Equal("en-fr", dict.Name);
        }

        [Fact]
        public void TestMultipleTranslations()
        {
            var mockDictionaryParser = new Mock<IDictionaryParser>();
            mockDictionaryParser
                .Setup(dp => dp.GetTranslations())
                .Returns(new Dictionary<string, Dictionary<string, string>>
                {
                    {
                        "against", new Dictionary<string, string>
                        {
                            {"contre", "against"},
                            {"versus", "against"}
                        }
                    }
                });

            var dict = new Dictionary(mockDictionaryParser.Object);
            Assert.Equal(dict.GetTranslation("against"), new[] {"contre", "versus"});
        }

        [Fact]
        public void TestErroneousFile()
        {
            var mockDictionaryParser = new Mock<IDictionaryParser>();
            mockDictionaryParser
                .Setup(dp => dp.GetTranslations())
                .Throws(new DictionaryException("The file is erroneous"));

            Assert.Throws<DictionaryException>(() => new Dictionary(mockDictionaryParser.Object));
        }
        
    }
}