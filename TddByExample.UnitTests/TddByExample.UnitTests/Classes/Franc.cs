namespace TddByExample.UnitTests.Classes
{
    public class Franc : Money
    {
        public Franc(int amount)
        {
            Amount = amount;
        }
        
        public Franc Times(int multiplier)
        {
            return new Franc(Amount * multiplier);
        }
    }
}