using TddByExample.UnitTests.Classes;

namespace TddByExample.UnitTests.Classes
{
    public class Money
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

        public static Dollar Dollar(int amount)
        {
            return new Dollar(amount, "USD");
        }


        public static Franc Franc(int amount)
        {
            return new Franc(amount, "CHF");
        }
    }
}