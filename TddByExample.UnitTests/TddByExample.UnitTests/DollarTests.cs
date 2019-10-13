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

        [Fact]
        public void testSimpleAddition()
        {
            var five = Money.Dollar(5);
            IExpress sum = five.Plus(five);
            var bank = new Bank();
            
            Money reduced = bank.Reduce(sum, "USD");
            
            reduced.Should().Be(Money.Dollar(10));
        }

        [Fact]
        public void testPlusReturnsSum()
        {
            var five = Money.Dollar(5);
            
            IExpress result = five.Plus(five);
            
            Sum sum = (Sum) result;
            sum.Augend.Should().Be(five);
            sum.Addend.Should().Be(five);
        }

        [Fact]
        public void testReduceSum()
        {
            var sum = new Sum(Money.Dollar(3), Money.Dollar(4));
            var bank = new Bank();

            Money reduced = bank.Reduce(sum, "USD");

            reduced.Should().Be(Money.Dollar(7));
        }

        [Fact]
        public void testReduceMoney()
        {
            var bank = new Bank();
            
            var result = bank.Reduce(Money.Dollar(1), "USD");
            
            result.Should().Be(Money.Dollar(1));
        }

        [Fact]
        public void testReduceMoneyDifferentCurrency()
        {
            var bank = new Bank();
            bank.AddRate("CHF", "USD", 2);
            
            var result = bank.Reduce(Money.Franc(2), "USD");
            
            result.Should().Be(Money.Dollar(1));
        }

        [Fact]
        public void testIdentityRate()
        {
            new Bank().Rate("USD", "USD").Should().Be(1);
        }

        [Fact]
        public void testMixedAddition()
        {
            IExpress fiveDollars = Money.Dollar(5);
            IExpress tenFrancs = Money.Franc(10);
            var bank = new Bank();
            bank.AddRate("CHF", "USD", 2);

            var result = bank.Reduce(fiveDollars.Plus(tenFrancs), "USD");

            result.Should().Be(Money.Dollar(10));
        }

        [Fact]
        public void testSumPlusMoney()
        {
            IExpress fiveDollars = Money.Dollar(5);
            IExpress tenFrancs = Money.Franc(10);
            var bank = new Bank();
            bank.AddRate("CHF", "USD", 2);
            IExpress sum = new Sum(fiveDollars, tenFrancs).Plus(fiveDollars);

            Money result = bank.Reduce(sum, "USD");

            result.Should().Be(Money.Dollar(15));
        }
    }
}