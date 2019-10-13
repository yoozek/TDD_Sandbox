using TddByExample.UnitTests.Classes;

namespace TddByExample.UnitTests
{
    public interface IExpress
    {
        Money Reduce(Bank bank, string to);
        IExpress Plus(IExpress addend);
        IExpress Times(int multiplier);
    }
}