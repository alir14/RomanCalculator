using RomanCalculatorFramework;
using RomanCalculatorFramework.Interface;
using RomanCalculatorBusinessComponent.IntegerToRomanNumber;

namespace RomanCalculatorBusinessComponent.Factory
{
    public class RomanNumberToStringFactory
    {
        public string Number { get; set; }
        INumberDataSet numbersDataSet;

        public RomanNumberToStringFactory(string number, INumberDataSet dataSet)
        {
            this.Number = number;
            this.numbersDataSet = dataSet;
        }

        public IConvertToRomanNumber CreateInstance(int type)
        {
            switch (type)
            {
                case (int)NumberCategoriesEnums.ten:
                    return new RomanNumberLessThanTen(numbersDataSet, Number);
                case (int)NumberCategoriesEnums.hundred:
                    return new RomanNumberLessThanHundred(this.numbersDataSet, this.Number);
                case (int)NumberCategoriesEnums.thousands:
                    return new RomanNumberLessThanThousand(this.numbersDataSet, this.Number);
                case (int)NumberCategoriesEnums.million:
                    return new RomanNumberLessThanMillionThousand(this.numbersDataSet, this.Number);
                default:
                    return null;
            }
        }
    }
}
