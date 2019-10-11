using System;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.DataCollection;
using Xunit;

namespace TddByExample.UnitTests
{
    public class UnitTest1
    {
        [Fact]
        public void testMultiplication()
        {
            Dollar five = new Dollar(5);
            Assert.Equal(new Dollar(10), five.Times(2));
            Assert.Equal(new Dollar(15), five.Times(3));
        }

        [Fact]
        public void TwoDollarObjectsWithTheSameAmount_AreEqual()
        {
            Assert.True(condition: new Dollar(5).Equals(new Dollar(5)));
        }
        
        [Fact]
        public void TwoDollarObjectsWithDifferentAmounts_AreEqual()
        {
            Assert.False(condition: new Dollar(4).Equals(new Dollar(6)));
        }
    }

    public class Dollar
    {
        private readonly int _amount;

        public Dollar(int amount)
        {
            _amount = amount;
        }
        
        public Dollar Times(int multiplier)
        {
            return new Dollar(_amount * multiplier);
        }

        public override bool Equals(object obj)
        {
            var dollar = (Dollar) obj;
            return _amount == dollar._amount;
        }
    }
}