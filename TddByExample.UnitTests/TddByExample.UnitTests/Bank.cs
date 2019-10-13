using System;
using System.Collections.Generic;
using System.Linq;
using TddByExample.UnitTests.Classes;

namespace TddByExample.UnitTests
{
    public class Bank
    {
        private Dictionary<(string fromCurrency, string toCurrency), int> _rateDict 
            = new Dictionary<(string, string), int>();
        
        public Money Reduce(IExpress source, string to)
        {
            return source.Reduce(this, to);
        }

        public void AddRate(string fromCurrency, string toCurrency, int rate)
        {
            _rateDict.Add((fromCurrency, toCurrency), rate);
        }

        public int Rate(string from, string to)
        {
            if (from.Equals(to)) return 1;
            return _rateDict.First(r => r.Key.Equals((from, to))).Value;
        }
    }
}