using System;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.DataCollection;
using TddByExample.UnitTests.Classes;
using Xunit;

namespace TddByExample.UnitTests
{
    public class DollarTests
    {
        [Fact]
        public void testDollarMultiplication()
        {
            Dollar five = new Dollar(5);
            Assert.Equal(new Dollar(10), five.Times(2));
            Assert.Equal(new Dollar(15), five.Times(3));
        }

        [Fact]
        public void testEquality()
        {
            Assert.True(condition: new Dollar(5).Equals(new Dollar(5)));
            Assert.False(condition: new Dollar(4).Equals(new Dollar(6)));
            Assert.True(condition: new Franc(5).Equals(new Franc(5)));
            Assert.False(condition: new Franc(4).Equals(new Franc(6)));
            Assert.False(new Franc(5).Equals(new Dollar(5)));
        }
        
        [Fact]
        public void testFrancMultiplication()
        {
            Franc five = new Franc(5);
            Assert.Equal(new Franc(10), five.Times(2));
            Assert.Equal(new Franc(15), five.Times(3));
        }
        
        [Fact]
        public void TwoDollarObjectsWithDifferentAmounts_AreEqual()
        {
            Assert.False(condition: new Dollar(4).Equals(new Dollar(6)));
        }
    }
}