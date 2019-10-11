namespace TddByExample.UnitTests.Classes
{
    public class Money
    {
        protected int Amount;

        public override bool Equals(object obj)
                 {
                     var money = (Money) obj;
                     return Amount == money.Amount
                            && GetType() == money.GetType();
                 }
    }
}