using FluentAssertions;
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
            five.Times(2).Should().Be(Money.Dollar(10));
            five.Times(3).Should().Be(Money.Dollar(15));
        }

        [Fact]
        public void testEquality()
        {
            Money.Dollar(5).Should().Be(Money.Dollar(5));
            Money.Dollar(4).Should().NotBe(Money.Dollar(6));
            Money.Franc(5).Should().NotBe(Money.Dollar(5));
        }

        [Fact]
        public void TwoDollarObjectsWithDifferentAmounts_AreEqual()
        {
            Money.Dollar(4).Should().NotBe(Money.Dollar(6));
            Assert.False(condition: Money.Dollar(4).Equals(Money.Dollar(6)));
        }

        [Fact]
        public void testCurrency()
        {
            Money.Dollar(1).Currency.Should().Be("USD");
            Money.Franc(1).Currency.Should().Be("CHF");
        }
    }
}