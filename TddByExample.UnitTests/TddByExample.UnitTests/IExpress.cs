using TddByExample.UnitTests.Classes;

namespace TddByExample.UnitTests
{
    public interface IExpress
    {
        Money Reduce(Bank bank, string to);
    }
}