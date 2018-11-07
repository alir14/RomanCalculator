using System;
using RomanCalculatorFramework.Interface;

namespace RomanCalculatorBusinessComponent.IntegerToRomanNumber
{
    public class RomanNumberLessThanHundred : BaseRomanBumberConvertor, IConvertToRomanNumber
    {
        public RomanNumberLessThanHundred(INumberDataSet dataset, string number)
            : base(dataset, number)
        {
            base.Threshold = 50;
            base.ArithmeticValue = 10;
        }

        public string ConvertNumberToRomanValue()
        {
            var result = string.Empty;

            var value = Convert.ToInt32(this.Number) * 10;

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

            for (int i = 0; i < value; i = i=i+10)
            {
                result += base.Add(ArithmeticValue);
            }

            return result;
        }

        protected string CheckNumberLessthanBaseNumber(int value)
        {
            base.BaseNumber = 10;
            base.ExceptionValue = 40;
            return base.CheckNumber(value);
        }

        protected string CheckNumberMorehanBaseNumber(int value)
        {
            base.BaseNumber = 50;
            base.ExceptionValue = 90;
            base.Threshold = 100;
            return base.CheckNumber(value);
        }
    }
}
