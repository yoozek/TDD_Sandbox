using TddByExample.UnitTests.Classes;

namespace TddByExample.UnitTests
{
    public class Bank
    {
        public Money Reduce(IExpress source, string to)
        {
            return source.Reduce(to);
        }
    }
}