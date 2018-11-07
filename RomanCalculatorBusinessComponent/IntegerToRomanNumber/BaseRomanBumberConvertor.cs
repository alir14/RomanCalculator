using System;
using RomanCalculatorFramework.Interface;

namespace RomanCalculatorBusinessComponent.IntegerToRomanNumber
{
    public class BaseRomanBumberConvertor
    {
        protected INumberDataSet numberDataset;
        protected string Number { get; set; }

        protected int BaseNumber { get; set; }
        protected int ExceptionValue { get; set; }
        protected int Threshold { get; set; }
        protected int ArithmeticValue { get; set; }

        public BaseRomanBumberConvertor(INumberDataSet dataset, string number)
        {
            numberDataset = dataset;
            this.Number = number;
        }

        protected virtual string CheckNumber(int value)
        {
            var result = string.Empty;

           if(value > 0)
            {
                if (value == ExceptionValue)
                {
                    result = Subtract(Threshold, ArithmeticValue);
                }
                else
                {
                    value = value - BaseNumber;

                    var BaseRomanValue = numberDataset.GetRomanVaue(BaseNumber);

                    result = AddingProcess(value);

                    result = string.Format("{0}{1}", BaseRomanValue, result).Trim();
                }
            }

            return result;
        }

        protected virtual string AddingProcess(int value)
        {
            var result = string.Empty;

            for (int i = 0; i < value; i++)
            {
                result += Add(ArithmeticValue);
            }

            return result;
        }

        protected string Subtract(int baseValue, int number)
        {
            var result = string.Empty;

            var value = numberDataset.GetRomanVaue(number);

            var baseNumber = numberDataset.GetRomanVaue(baseValue);

            return result = string.Format("{1}{0}", baseNumber, value);
        }

        protected string Add(int number)
        {
            var value = numberDataset.GetRomanVaue(number);

            return string.Format("{0}", value);
        }
    }
}
