using System;
using RomanCalculatorFramework.Interface;

namespace RomanCalculatorBusinessComponent.IntegerToRomanNumber
{
    public class RomanNumberLessThanThousand : BaseRomanBumberConvertor, IConvertToRomanNumber
    {
        public RomanNumberLessThanThousand(INumberDataSet dataset, string number)
            : base(dataset, number)
        {
            base.Threshold = 500;
            base.ArithmeticValue = 100;
        }

        public string ConvertNumberToRomanValue()
        {
            var result = string.Empty;

            var value = Convert.ToInt32(this.Number) * 100;

            if ((value) < Threshold)
            {
                result = CheckNumberLessthanBaseNumber(value);
            }
            else
            {
                result = CheckNumberMorehanBaseNumber(value);
            }

            return result;
        }

        protected override string AddingProcess(int value)
        {
            var result = string.Empty;

            for (int i = 0; i < value; i = i = i + 100)
            {
                result += base.Add(ArithmeticValue);
            }

            return result;
        }

        protected string CheckNumberLessthanBaseNumber(int value)
        {
            base.BaseNumber = 100;
            base.ExceptionValue = 400;
            return base.CheckNumber(value);
        }

        protected string CheckNumberMorehanBaseNumber(int value)
        {
            base.BaseNumber = 500;
            base.ExceptionValue = 900;
            base.Threshold = 1000;
            return base.CheckNumber(value);
        }
    }
}
