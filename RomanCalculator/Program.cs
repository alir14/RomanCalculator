using System;
using RomanCalculatorDataComponent;
using RomanCalculatorBusinessComponent;
using RomanCalculatorFramework.Interface;

namespace RomanCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            string firstRomanNumber = string.Empty;
            string secondRomanNumber = string.Empty;
            string userInput = string.Empty;

            while (userInput != "q")
            {
                Console.WriteLine("please enter first Roman Number:");

                firstRomanNumber = Console.ReadLine();

                Console.WriteLine("please enter second Roman Number:");

                secondRomanNumber = Console.ReadLine();

                Console.WriteLine("The result is :");

                Console.WriteLine(ConvertRomanNumberToString(firstRomanNumber.ToUpper(),secondRomanNumber.ToUpper()));

                Console.WriteLine("Do you want to try again or quit? press y to continue or q to exit");

                userInput = Console.ReadLine();

                if (userInput == "y")
                    Console.Clear();
            }
        }

        static string ConvertRomanNumberToString(string firstNumber, string secondNumber)
        {
            INumberDataSet dataset = new NumberDataSet();
            var process = new ProcessRomaNumber(firstNumber,secondNumber, dataset);

            return process.ProcessGivenNumber();
        }
    }
}
