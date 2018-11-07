using System.Linq;
using System.Collections.Generic;
using RomanCalculatorFramework.Interface;

namespace RomanCalculatorDataComponent
{
    public class NumberDataSet: INumberDataSet
    {
        public Dictionary<int, string> RomanNumberDataSet { get; set; }
        public NumberDataSet()
        {
            RomanNumberDataSet = new Dictionary<int, string>()
            {
                {0, "" },
                {1, "I" },
                {5, "V" },
                {10, "X" },
                {50, "L" },
                {100, "C" },
                {500, "D" },
                {1000, "M" }

            };
        }

        public string GetRomanVaue(int index)
        {
            return RomanNumberDataSet[index];
        }

        public int GetIntegerVaue(string RomanValue)
        {
            var value = RomanNumberDataSet.FirstOrDefault(x => x.Value == RomanValue);

            return value.Key;

        }
    }
}
