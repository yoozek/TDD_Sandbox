namespace TddByExample.UnitTests.Classes
{
    public abstract class Money
    {
        protected int Amount;
        public abstract string Currency { get; }

        public abstract Money Times(int multiplier);

        public override bool Equals(object obj)
        {
            var money = (Money) obj;
            return Amount == money.Amount
                   && GetType() == money.GetType();
        }

        public static Dollar Dollar(int amount)
        {
            return new Dollar(amount);
        }


        public static Franc Franc(int amount)
        {
            return new Franc(amount);
        }
    }
}