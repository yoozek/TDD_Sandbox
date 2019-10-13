using TddByExample.UnitTests.Classes;

namespace TddByExample.UnitTests
{
    public class Sum : IExpress
    {
        public Sum(IExpress augend, IExpress addend)
        {
            Augend = augend;
            Addend = addend;
        }
        
        public IExpress Augend { get; set; }
        public IExpress Addend { get; set; }

        public Money Reduce(Bank bank, string to)
        {
            int amount = Augend.Reduce(bank, to).Amount 
                         + Addend.Reduce(bank, to).Amount;
            return new Money(amount, to);
        }

        public IExpress Plus(IExpress addend)
        {
            return new Sum(this, addend);
        }

        public IExpress Times(int multiplier)
        {
            return new Sum(Augend.Times(multiplier), Addend.Times(multiplier));
        }
    }
}