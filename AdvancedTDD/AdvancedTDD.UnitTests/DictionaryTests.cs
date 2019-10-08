using System;
using System.Collections.Generic;
using AdvancedTdd.Core;
using Moq;
using Xunit;
using Xunit.Sdk;

namespace AdvancedTDD.UnitTests
{
    public class DictionaryTest
    {
        [Fact]
        public void TestDictionaryName()
        {
            var dict = new Dictionary("en-fr");
            Assert.Equal("en-fr", dict.Name);
        }

        [Fact]
        public void TestOneTranslation()
        {
            var dict = new Dictionary("en-fr");
            dict.AddTranslation("against", "contre");
            Assert.Equal("contre", dict.GetTranslation("against")[0]);
        }

        [Fact]
        public void TestIsEmpty1()
        {
            var dict = new Dictionary("en-fr");
            Assert.True(dict.IsEmpty());
        }

        [Fact]
        public void TestIsEmpty2()
        {
            var dict = new Dictionary("en-fr");
            dict.AddTranslation("against", "contre");
            Assert.False(dict.IsEmpty());
        }

        [Fact]
        public void TestMultipleTranslations()
        {
            var dict = new Dictionary("en-fr");
            dict.AddTranslation("against", "contre");
            dict.AddTranslation("against", "versus");

            var result = dict.GetTranslation("against");

            Assert.Equal(new string[] {"contre", "versus"}, result);
        }

        [Fact]
        public void TestReverseTranslation()
        {
            var dict = new Dictionary("en-fr");
            dict.AddTranslation("against", "contre");
            Assert.Equal("against", dict.GetTranslation("contre")[0]);
        }
    }
}