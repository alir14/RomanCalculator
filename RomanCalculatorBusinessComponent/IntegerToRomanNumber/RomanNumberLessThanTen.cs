using System;
using RomanCalculatorFramework.Interface;

namespace RomanCalculatorBusinessComponent.IntegerToRomanNumber
{
    internal class RomanNumberLessThanTen : BaseRomanBumberConvertor, IConvertToRomanNumber
    {

        public RomanNumberLessThanTen(INumberDataSet dataset, string number)
            :base (dataset, number)
        {
            base.Threshold = 5;
            base.ArithmeticValue = 1;
        }

        public string ConvertNumberToRomanValue()
        {
            var result = string.Empty;

            var value = Convert.ToInt32(this.Number);

            if (value < Threshold)
            {
                result = CheckNumberLessthanBaseNumber(value);
            }
            else
            {
                result = CheckNumberMorehanBaseNumber(value);
            }

            return result;
        }

        protected string CheckNumberLessthanBaseNumber(int value)
        {
            base.BaseNumber = 0;
            base.ExceptionValue = 4;
            return base.CheckNumber(value);
        }

        protected string CheckNumberMorehanBaseNumber(int value)
        {
            base.BaseNumber = 5;
            base.ExceptionValue = 9;
            base.Threshold = 10;
            return base.CheckNumber(value);
        }
    }
}
