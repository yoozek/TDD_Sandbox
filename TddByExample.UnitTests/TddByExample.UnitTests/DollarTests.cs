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
            Money five = Money.Dollar(5);
            Assert.Equal(Money.Dollar(10), five.Times(2));
            Assert.Equal(Money.Dollar(15), five.Times(3));
        }

        [Fact]
        public void testEquality()
        {
            Assert.True(condition: Money.Dollar(5).Equals(Money.Dollar(5)));
            Assert.False(condition: Money.Dollar(4).Equals(Money.Dollar(6)));
            Assert.True(condition: Money.Franc(5).Equals(Money.Franc(5)));
            Assert.False(condition: Money.Franc(4).Equals(Money.Franc(6)));
            Assert.False(Money.Franc(5).Equals(Money.Dollar(5)));
        }
        
        [Fact]
        public void testFrancMultiplication()
        {
            Franc five = Money.Franc(5);
            Assert.Equal(Money.Franc(10), five.Times(2));
            Assert.Equal(Money.Franc(15), five.Times(3));
        }
        
        [Fact]
        public void TwoDollarObjectsWithDifferentAmounts_AreEqual()
        {
            Assert.False(condition: Money.Dollar(4).Equals(Money.Dollar(6)));
        }
    }
}