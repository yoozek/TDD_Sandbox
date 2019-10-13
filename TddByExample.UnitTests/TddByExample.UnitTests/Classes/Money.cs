using TddByExample.UnitTests.Classes;

namespace TddByExample.UnitTests.Classes
{
    public class Money : Express
    {
        protected int Amount;
        
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

        public Express Plus(Money money)
        {
            return new Money(Amount + money.Amount, Currency);
        }
    }
}