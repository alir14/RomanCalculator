using System;
using RomanCalculatorFramework;
using RomanCalculatorFramework.Interface;

namespace RomanCalculatorBusinessComponent.IntegerToRomanNumber
{
    public class RomanNumberLessThanMillionThousand : BaseRomanBumberConvertor, IConvertToRomanNumber
    {
        public RomanNumberLessThanMillionThousand(INumberDataSet dataset, string number)
            : base(dataset, number)
        {
            base.Threshold = 3001;
            base.ArithmeticValue = 1000;
        }

        public string ConvertNumberToRomanValue()
        {
            var result = string.Empty;

            var value = Convert.ToInt32(this.Number) * 1000;

            if ((value) < Threshold)
            {
                result = CheckNumberLessthanBaseNumber(value);
            }

            return result;
        }

        protected override string AddingProcess(int value)
        {
            var result = string.Empty;

            for (int i = 0; i < value; i = i = i + 1000)
            {
                result += base.Add(ArithmeticValue);
            }

            return result;
        }

        protected string CheckNumberLessthanBaseNumber(int value)
        {
            base.BaseNumber = 1000;
            base.ExceptionValue = 3001;
            return base.CheckNumber(value);
        }
    }
}
