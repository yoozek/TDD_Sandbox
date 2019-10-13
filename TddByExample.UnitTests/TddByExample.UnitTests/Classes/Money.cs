namespace TddByExample.UnitTests.Classes
{
    public abstract class Money
    {
        protected int Amount;
        
        public string Currency { get; protected set; }

        public abstract Money Times(int multiplier);

        public Money(int amount, string currency)
        {
            Amount = amount;
            Currency = currency;
        }
        
        public override bool Equals(object obj)
        {
            var money = (Money) obj;
            return Amount == money.Amount
                   && GetType() == money.GetType();
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