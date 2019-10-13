namespace TddByExample.UnitTests.Classes
{
    public class Money : IExpress
    {
        public readonly int Amount;
        
        public string Currency { get; }

        public IExpress Times(int multiplier)
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

        public IExpress Plus(IExpress addend)
        {
            return new Sum(this, addend);
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