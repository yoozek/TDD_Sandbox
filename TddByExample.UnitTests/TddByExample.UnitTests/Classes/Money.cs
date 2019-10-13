using System;
using TddByExample.UnitTests.Classes;

namespace TddByExample.UnitTests.Classes
{
    public class Money : IExpress
    {
        public int Amount;
        
        public string Currency { get; }

        public Money Times(int multiplier)
        {
            return new Money(Amount * multiplier, Currency);
        }

        public Money(int amount, string currency)
        {
            Amount = amount;
            Currency = currency;
        }
        
        public override bool Equals(object obj)
        {
            var money = (Money) obj;
            return Amount == money.Amount
                   && Currency == money.Currency;
        }

        public static Money Dollar(int amount)
        {
            return new Money(amount, "USD");
        }


        public static Money Franc(int amount)
        {
            return new Money(amount, "CHF");
        }

        public Sum Plus(Money money)
        {
            return new Sum(this, money);
        }

        public override string ToString()
        {
            return $"{Amount}{Currency}";
        }

        public Money Reduce(Bank bank, string to)
        {
            var rate = bank.Rate(Currency, to);
            return new Money(Amount / rate, to);
        }
    }
}