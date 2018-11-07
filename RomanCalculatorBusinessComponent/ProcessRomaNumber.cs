using System.Linq;
using RomanCalculatorFramework;
using System.Text.RegularExpressions;
using RomanCalculatorFramework.Interface;
using RomanCalculatorBusinessComponent.Factory;
using RomanCalculatorBusinessComponent.RomanNumberToInteger;

namespace RomanCalculatorBusinessComponent
{
    public class ProcessRomaNumber
    {
        public string FirstNumber { get; set; }
        public string SecondNumber { get; set; }

        INumberDataSet numberDataset;

        public ProcessRomaNumber(string firstNumber , string secondNumber, INumberDataSet dataset)
        {
            this.FirstNumber = firstNumber;
            this.SecondNumber = secondNumber;

            this.numberDataset = dataset;
        }

        public string ProcessGivenNumber()
        {
            var result = string.Empty;

            try
            {
                if (Validataion(FirstNumber) && Validataion(SecondNumber))
                {
                    var converter = new ConvertRomanNumberToInger(numberDataset);

                    var firtInteger = converter.ConvertRomantoInt(FirstNumber);

                    var secondInteger = converter.ConvertRomantoInt(SecondNumber);

                    var calculateValue = firtInteger + secondInteger;

                    result = IntegertoRomanNumber(calculateValue);

                }
                else
                {
                    result = Consts.VALIDATION_ERROR_MESSAGE;
                }
            }
            catch
            {
                result = Consts.EXCEPTION_MESSAGE;
            }
            

            return result;
        }

        private string IntegertoRomanNumber(int number)
        {
            string result = string.Empty;
            //classify the number
            var listofnumber = number.ToString().ToArray().Reverse().ToList();

            //process each section
            for (int i = 0; i < listofnumber.Count; i++)
            {
                RomanNumberToStringFactory factory = new RomanNumberToStringFactory(listofnumber[i].ToString(), this.numberDataset);
                IConvertToRomanNumber process = factory.CreateInstance(i);
                var romanValue = process.ConvertNumberToRomanValue();

                result = string.Format("{1}{0}", result, romanValue).Trim();
            }

            return result;

        }

        private bool Validataion(string input)
        {
            bool result = false;

            string pattern1 = @"^[IVXLCDM]";
            string pattern2 = @"[IVXLCDM]$";


            if (!string.IsNullOrEmpty(input)
                && ((Regex.IsMatch(input, pattern1)) && Regex.IsMatch(input, pattern2)))
            {
                result = true;
            }

            return result;
        }
    }
}
