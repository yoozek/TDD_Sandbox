namespace TddByExample.UnitTests.Classes
{
    public class Dollar : Money
    {
        
        
        public Dollar(int amount)
        {
            Amount = amount;
        }

        public override string Currency { get; } = "USD";

        public override Money Times(int multiplier)
        {
            return new Dollar(Amount * multiplier);
        }
    }
}